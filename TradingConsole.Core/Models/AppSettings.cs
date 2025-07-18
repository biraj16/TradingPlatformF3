// In TradingConsole.Core/Models/AppSettings.cs
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace TradingConsole.Core.Models
{
    public class SignalDriver : ObservableModel
    {
        private string _name = string.Empty;
        public string Name { get => _name; set => SetProperty(ref _name, value); }

        private int _weight;
        public int Weight { get => _weight; set => SetProperty(ref _weight, value); }

        private bool _isEnabled = true;
        public bool IsEnabled { get => _isEnabled; set => SetProperty(ref _isEnabled, value); }

        public SignalDriver(string name, int weight, bool isEnabled = true)
        {
            Name = name;
            Weight = weight;
            IsEnabled = isEnabled;
        }

        public SignalDriver() { }

        protected bool SetProperty<T>(ref T backingStore, T value, [System.Runtime.CompilerServices.CallerMemberName] string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value)) return false;
            backingStore = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }

    public class StrategySettings
    {
        public ObservableCollection<SignalDriver> TrendingBullDrivers { get; set; }
        public ObservableCollection<SignalDriver> TrendingBearDrivers { get; set; }
        public ObservableCollection<SignalDriver> RangeBoundBullishDrivers { get; set; }
        public ObservableCollection<SignalDriver> RangeBoundBearishDrivers { get; set; }
        public ObservableCollection<SignalDriver> VolatileBullishDrivers { get; set; }
        public ObservableCollection<SignalDriver> VolatileBearishDrivers { get; set; }

        public StrategySettings()
        {
            TrendingBullDrivers = new ObservableCollection<SignalDriver>
            {
                new SignalDriver("Institutional Intent is Bullish", 3),
                new SignalDriver("Price above VWAP", 2),
                new SignalDriver("5m VWAP EMA confirms trend", 1),
                new SignalDriver("OI confirms new longs", 2),
                new SignalDriver("IB breakout is extending", 2),
                new SignalDriver("IV contracting supports calm uptrend", 1),
                new SignalDriver("Bullish OBV Div at Profile Support", 3),
                new SignalDriver("Bullish RSI Div at Profile Support", 2)
            };

            TrendingBearDrivers = new ObservableCollection<SignalDriver>
            {
                new SignalDriver("Institutional Intent is Bearish", 3),
                new SignalDriver("Price below VWAP", 2),
                new SignalDriver("5m VWAP EMA confirms trend", 1),
                new SignalDriver("OI confirms new shorts", 2),
                new SignalDriver("IB breakdown is extending", 2),
                new SignalDriver("IV spiking confirms fear", 2),
                new SignalDriver("Bearish OBV Div at Profile Resistance", 3),
                new SignalDriver("Bearish RSI Div at Profile Resistance", 2)
            };

            RangeBoundBullishDrivers = new ObservableCollection<SignalDriver>
            {
                 new SignalDriver("Bullish OBV Div at range low", 3),
                 new SignalDriver("Bullish RSI Div at range low", 2),
                 new SignalDriver("Low volume suggests exhaustion (Bullish)", 1),
                 new SignalDriver("Possible range breakout with volume", 2)
            };

            RangeBoundBearishDrivers = new ObservableCollection<SignalDriver>
            {
                new SignalDriver("Bearish OBV Div at range high", 3),
                new SignalDriver("Bearish RSI Div at range high", 2),
                new SignalDriver("Low volume suggests exhaustion (Bearish)", 1),
                new SignalDriver("Possible range breakdown with volume", 2)
            };

            VolatileBullishDrivers = new ObservableCollection<SignalDriver>
            {
                new SignalDriver("Strong bullish confluence with Inst. backing", 4)
            };

            VolatileBearishDrivers = new ObservableCollection<SignalDriver>
            {
                new SignalDriver("Strong bearish confluence with Inst. backing", 4)
            };
        }
    }


    public class IndexLevels
    {
        public decimal NoTradeUpperBand { get; set; }
        public decimal NoTradeLowerBand { get; set; }
        public decimal SupportLevel { get; set; }
        public decimal ResistanceLevel { get; set; }
        public decimal Threshold { get; set; }
    }

    public class AppSettings
    {
        public Dictionary<string, int> FreezeQuantities { get; set; }
        public List<string> MonitoredSymbols { get; set; }
        public int ShortEmaLength { get; set; }
        public int LongEmaLength { get; set; }

        public int AtrPeriod { get; set; }
        public int AtrSmaPeriod { get; set; }

        public int RsiPeriod { get; set; }
        public int RsiDivergenceLookback { get; set; }
        public int VolumeHistoryLength { get; set; }
        public double VolumeBurstMultiplier { get; set; }
        public int IvHistoryLength { get; set; }
        public decimal IvSpikeThreshold { get; set; }

        public int ObvMovingAveragePeriod { get; set; }

        // --- NEW: Settings for VWAP Bands ---
        public decimal VwapUpperBandMultiplier { get; set; }
        public decimal VwapLowerBandMultiplier { get; set; }


        public Dictionary<string, IndexLevels> CustomIndexLevels { get; set; }
        public List<DateTime> MarketHolidays { get; set; }

        public bool IsAutoKillSwitchEnabled { get; set; }
        public decimal MaxDailyLossLimit { get; set; }

        public StrategySettings Strategy { get; set; }


        public AppSettings()
        {
            FreezeQuantities = new Dictionary<string, int>
            {
                { "NIFTY", 1800 },
                { "BANKNIFTY", 900 },
                { "FINNIFTY", 1800 },
                { "SENSEX", 1000 }
            };

            MonitoredSymbols = new List<string>
            {
                "IDX:Nifty 50",
                "IDX:Nifty Bank",
                "IDX:Sensex",
                "EQ:HDFCBANK",
                "EQ:ICICIBANK",
                "EQ:RELIANCE INDUSTRIES",
                "EQ:INFOSYS",
                "EQ:ITC",
                "EQ:TATA CONSULTANCY",
                "FUT:NIFTY",
                "FUT:BANKNIFTY",
                "FUT:HDFCBANK",
                "FUT:ICICIBANK",
                "FUT:RELIANCE",
                "FUT:INFY",
                "FUT:TCS"
            };

            ShortEmaLength = 9;
            LongEmaLength = 21;

            AtrPeriod = 14;
            AtrSmaPeriod = 10;

            RsiPeriod = 14;
            RsiDivergenceLookback = 20;
            VolumeHistoryLength = 12;
            VolumeBurstMultiplier = 2.0;
            IvHistoryLength = 15;
            IvSpikeThreshold = 0.01m;

            ObvMovingAveragePeriod = 20;

            // --- NEW: Default values for VWAP Bands ---
            VwapUpperBandMultiplier = 2.0m;
            VwapLowerBandMultiplier = 2.0m;

            MarketHolidays = new List<DateTime>();

            IsAutoKillSwitchEnabled = false;
            MaxDailyLossLimit = 8000;

            CustomIndexLevels = new Dictionary<string, IndexLevels>
            {
                {
                    "NIFTY", new IndexLevels {
                        NoTradeUpperBand = 24500, NoTradeLowerBand = 24900,
                        SupportLevel = 24500, ResistanceLevel = 25500, Threshold = 20
                    }
                },
                {
                    "BANKNIFTY", new IndexLevels {
                        NoTradeUpperBand = 57500, NoTradeLowerBand = 56000,
                        SupportLevel = 56000, ResistanceLevel = 58000, Threshold = 50
                    }
                },
                {
                    "SENSEX", new IndexLevels {
                        NoTradeUpperBand = 84000, NoTradeLowerBand = 82500,
                        SupportLevel = 80100, ResistanceLevel = 85000, Threshold = 100
                    }
                }
            };

            Strategy = new StrategySettings();
        }
    }
}
