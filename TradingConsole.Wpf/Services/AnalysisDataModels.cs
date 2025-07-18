// In TradingConsole.Wpf/Services/AnalysisDataModels.cs
using System;
using System.Collections.Generic;
using System.Linq;
using TradingConsole.Core.Models;

namespace TradingConsole.Wpf.Services
{
    public class Candle
    {
        public DateTime Timestamp { get; set; }
        public decimal Open { get; set; }
        public decimal High { get; set; }
        public decimal Low { get; set; }
        public decimal Close { get; set; }
        public long Volume { get; set; }
        public long OpenInterest { get; set; }

        public decimal Vwap { get; set; }
        // --- NEW: Property for Anchored VWAP ---
        public decimal AnchoredVwap { get; set; }
        internal decimal CumulativePriceVolume { get; set; } = 0;
        internal long CumulativeVolume { get; set; } = 0;


        public override string ToString()
        {
            return $"T: {Timestamp:HH:mm:ss}, O: {Open}, H: {High}, L: {Low}, C: {Close}, V: {Volume}";
        }
    }

    public class EmaState
    {
        public decimal CurrentShortEma { get; set; }
        public decimal CurrentLongEma { get; set; }
    }

    public class RsiState
    {
        public decimal AvgGain { get; set; }
        public decimal AvgLoss { get; set; }
        public List<decimal> RsiValues { get; } = new List<decimal>();
    }

    public class AtrState
    {
        public decimal CurrentAtr { get; set; }
        public List<decimal> AtrValues { get; } = new List<decimal>();
    }

    public class ObvState
    {
        public decimal CurrentObv { get; set; }
        public List<decimal> ObvValues { get; } = new List<decimal>();
        public decimal CurrentMovingAverage { get; set; }
    }

    public class RelativeStrengthState
    {
        public List<decimal> BasisDeltaHistory { get; } = new List<decimal>();
        public List<decimal> OptionsDeltaHistory { get; } = new List<decimal>();
        public string InstitutionalIntentSignal { get; set; } = "Neutral";
    }


    public class IntradayIvState
    {
        public decimal DayHighIv { get; set; } = 0;
        public decimal DayLowIv { get; set; } = decimal.MaxValue;
        public List<decimal> IvPercentileHistory { get; } = new List<decimal>();

        internal enum PriceZone { Inside, Above, Below }
        internal class CustomLevelState
        {
            public int BreakoutCount { get; set; }
            public int BreakdownCount { get; set; }
            public PriceZone LastZone { get; set; } = PriceZone.Inside;
        }
    }

    public class MarketProfile
    {
        public SortedDictionary<decimal, List<char>> TpoLevels { get; } = new SortedDictionary<decimal, List<char>>();
        public SortedDictionary<decimal, long> VolumeLevels { get; } = new SortedDictionary<decimal, long>();
        public TpoInfo TpoLevelsInfo { get; set; } = new TpoInfo();
        public VolumeProfileInfo VolumeProfileInfo { get; set; } = new VolumeProfileInfo();
        public decimal TickSize { get; }
        private readonly DateTime _sessionStartTime;
        private readonly DateTime _initialBalanceEndTime;

        public string LastMarketSignal { get; set; } = string.Empty;
        public DateTime Date { get; set; }

        public decimal InitialBalanceHigh { get; private set; }
        public decimal InitialBalanceLow { get; private set; }
        public bool IsInitialBalanceSet { get; private set; }

        public TpoInfo DevelopingTpoLevels { get; set; } = new TpoInfo();
        public VolumeProfileInfo DevelopingVolumeProfile { get; set; } = new VolumeProfileInfo();


        public MarketProfile(decimal tickSize, DateTime sessionStartTime)
        {
            TickSize = tickSize;
            _sessionStartTime = sessionStartTime;
            _initialBalanceEndTime = _sessionStartTime.AddMinutes(30);
            Date = sessionStartTime.Date;
            InitialBalanceLow = decimal.MaxValue;
        }

        public char GetTpoPeriod(DateTime timestamp)
        {
            var elapsed = timestamp - _sessionStartTime;
            int periodIndex = (int)(elapsed.TotalMinutes / 30);
            return (char)('A' + periodIndex);
        }

        public decimal QuantizePrice(decimal price)
        {
            return Math.Round(price / TickSize) * TickSize;
        }

        public void UpdateInitialBalance(Candle candle)
        {
            if (candle.Timestamp <= _initialBalanceEndTime)
            {
                InitialBalanceHigh = Math.Max(InitialBalanceHigh, candle.High);
                InitialBalanceLow = Math.Min(InitialBalanceLow, candle.Low);
            }
            else if (!IsInitialBalanceSet)
            {
                IsInitialBalanceSet = true;
            }
        }

        public MarketProfileData ToMarketProfileData()
        {
            var tpoCounts = this.TpoLevels.ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Count);

            return new MarketProfileData
            {
                Date = this.Date,
                TpoLevelsInfo = this.DevelopingTpoLevels,
                VolumeProfileInfo = this.DevelopingVolumeProfile,
                TpoCounts = tpoCounts,
                VolumeLevels = new Dictionary<decimal, long>(this.VolumeLevels)
            };
        }
    }
}
