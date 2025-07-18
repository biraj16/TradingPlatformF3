// In TradingConsole.Wpf/ViewModels/AnalysisResult.cs
using System.Collections.Generic;
using System.Linq;
using TradingConsole.Core.Models;
using TradingConsole.Wpf.Services;

namespace TradingConsole.Wpf.ViewModels
{
    public class AnalysisResult : ObservableModel
    {
        private bool _isExpanded;
        public bool IsExpanded
        {
            get => _isExpanded;
            set { if (_isExpanded != value) { _isExpanded = value; OnPropertyChanged(); } }
        }

        private List<string> _bullishDrivers = new List<string>();
        public List<string> BullishDrivers { get => _bullishDrivers; set { if (_bullishDrivers != value) { _bullishDrivers = value; OnPropertyChanged(); } } }

        private List<string> _bearishDrivers = new List<string>();
        public List<string> BearishDrivers { get => _bearishDrivers; set { if (_bearishDrivers != value) { _bearishDrivers = value; OnPropertyChanged(); } } }

        public List<string> KeySignalDrivers => BullishDrivers.Concat(BearishDrivers).ToList();

        private string _securityId = string.Empty;
        private string _symbol = string.Empty;
        private decimal _ltp;
        private decimal _vwap;
        private long _currentVolume;
        private long _avgVolume;
        private string _volumeSignal = "Neutral";
        private string _oiSignal = "N/A";
        private string _instrumentGroup = string.Empty;
        private string _underlyingGroup = string.Empty;
        private string _emaSignal1Min = "N/A";
        private string _emaSignal5Min = "N/A";
        private string _emaSignal15Min = "N/A";
        private string _vwapEmaSignal1Min = "N/A";
        private string _vwapEmaSignal5Min = "N/A";
        private string _vwapEmaSignal15Min = "N/A";
        private string _priceVsVwapSignal = "Neutral";
        private string _priceVsCloseSignal = "Neutral";
        private string _dayRangeSignal = "Neutral";
        private string _customLevelSignal = "N/A";
        private string _candleSignal1Min = "N/A";
        private string _candleSignal5Min = "N/A";
        private decimal _currentIv;
        private decimal _avgIv;
        private string _ivSignal = "N/A";

        private decimal _rsiValue1Min;
        public decimal RsiValue1Min { get => _rsiValue1Min; set { if (_rsiValue1Min != value) { _rsiValue1Min = value; OnPropertyChanged(); } } }
        private string _rsiSignal1Min = "N/A";
        public string RsiSignal1Min { get => _rsiSignal1Min; set { if (_rsiSignal1Min != value) { _rsiSignal1Min = value; OnPropertyChanged(); } } }
        private decimal _rsiValue5Min;
        public decimal RsiValue5Min { get => _rsiValue5Min; set { if (_rsiValue5Min != value) { _rsiValue5Min = value; OnPropertyChanged(); } } }
        private string _rsiSignal5Min = "N/A";
        public string RsiSignal5Min { get => _rsiSignal5Min; set { if (_rsiSignal5Min != value) { _rsiSignal5Min = value; OnPropertyChanged(); } } }

        private decimal _obvValue1Min;
        public decimal ObvValue1Min { get => _obvValue1Min; set { if (_obvValue1Min != value) { _obvValue1Min = value; OnPropertyChanged(); } } }
        private string _obvSignal1Min = "N/A";
        public string ObvSignal1Min { get => _obvSignal1Min; set { if (_obvSignal1Min != value) { _obvSignal1Min = value; OnPropertyChanged(); } } }
        private string _obvDivergenceSignal1Min = "N/A";
        public string ObvDivergenceSignal1Min { get => _obvDivergenceSignal1Min; set { if (_obvDivergenceSignal1Min != value) { _obvDivergenceSignal1Min = value; OnPropertyChanged(); } } }

        private decimal _obvValue5Min;
        public decimal ObvValue5Min { get => _obvValue5Min; set { if (_obvValue5Min != value) { _obvValue5Min = value; OnPropertyChanged(); } } }
        private string _obvSignal5Min = "N/A";
        public string ObvSignal5Min { get => _obvSignal5Min; set { if (_obvSignal5Min != value) { _obvSignal5Min = value; OnPropertyChanged(); } } }
        private string _obvDivergenceSignal5Min = "N/A";
        public string ObvDivergenceSignal5Min { get => _obvDivergenceSignal5Min; set { if (_obvDivergenceSignal5Min != value) { _obvDivergenceSignal5Min = value; OnPropertyChanged(); } } }

        private decimal _atr1Min;
        public decimal Atr1Min { get => _atr1Min; set { if (_atr1Min != value) { _atr1Min = value; OnPropertyChanged(); } } }
        private string _atrSignal1Min = "N/A";
        public string AtrSignal1Min { get => _atrSignal1Min; set { if (_atrSignal1Min != value) { _atrSignal1Min = value; OnPropertyChanged(); } } }

        private decimal _atr5Min;
        public decimal Atr5Min { get => _atr5Min; set { if (_atr5Min != value) { _atr5Min = value; OnPropertyChanged(); } } }
        private string _atrSignal5Min = "N/A";
        public string AtrSignal5Min { get => _atrSignal5Min; set { if (_atrSignal5Min != value) { _atrSignal5Min = value; OnPropertyChanged(); } } }

        private decimal _ivRank;
        public decimal IvRank { get => _ivRank; set { if (_ivRank != value) { _ivRank = value; OnPropertyChanged(); } } }
        private decimal _ivPercentile;
        public decimal IvPercentile { get => _ivPercentile; set { if (_ivPercentile != value) { _ivPercentile = value; OnPropertyChanged(); } } }
        private string _ivTrendSignal = "N/A";
        public string IvTrendSignal { get => _ivTrendSignal; set { if (_ivTrendSignal != value) { _ivTrendSignal = value; OnPropertyChanged(); } } }

        public decimal CurrentIv { get => _currentIv; set { if (_currentIv != value) { _currentIv = value; OnPropertyChanged(); } } }
        public decimal AvgIv { get => _avgIv; set { if (_avgIv != value) { _avgIv = value; OnPropertyChanged(); } } }
        public string IvSignal { get => _ivSignal; set { if (_ivSignal != value) { _ivSignal = value; OnPropertyChanged(); } } }

        private decimal _developingPoc;
        public decimal DevelopingPoc { get => _developingPoc; set { if (_developingPoc != value) { _developingPoc = value; OnPropertyChanged(); } } }
        private decimal _developingVah;
        public decimal DevelopingVah { get => _developingVah; set { if (_developingVah != value) { _developingVah = value; OnPropertyChanged(); } } }
        private decimal _developingVal;
        public decimal DevelopingVal { get => _developingVal; set { if (_developingVal != value) { _developingVal = value; OnPropertyChanged(); } } }
        private decimal _developingVpoc;
        public decimal DevelopingVpoc { get => _developingVpoc; set { if (_developingVpoc != value) { _developingVpoc = value; OnPropertyChanged(); } } }

        private string _dailyBias = "Calculating...";
        public string DailyBias { get => _dailyBias; set { if (_dailyBias != value) { _dailyBias = value; OnPropertyChanged(); } } }

        private string _marketStructure = "N/A";
        public string MarketStructure { get => _marketStructure; set { if (_marketStructure != value) { _marketStructure = value; OnPropertyChanged(); } } }

        private decimal _initialBalanceHigh;
        public decimal InitialBalanceHigh { get => _initialBalanceHigh; set { if (_initialBalanceHigh != value) { _initialBalanceHigh = value; OnPropertyChanged(); } } }
        private decimal _initialBalanceLow;
        public decimal InitialBalanceLow { get => _initialBalanceLow; set { if (_initialBalanceLow != value) { _initialBalanceLow = value; OnPropertyChanged(); } } }
        private string _initialBalanceSignal = "N/A";
        public string InitialBalanceSignal { get => _initialBalanceSignal; set { if (_initialBalanceSignal != value) { _initialBalanceSignal = value; OnPropertyChanged(); } } }

        private string _marketProfileSignal = "N/A";
        public string MarketProfileSignal { get => _marketProfileSignal; set { if (_marketProfileSignal != value) { _marketProfileSignal = value; OnPropertyChanged(); } } }
        public string CandleSignal1Min { get => _candleSignal1Min; set { if (_candleSignal1Min != value) { _candleSignal1Min = value; OnPropertyChanged(); } } }
        public string CandleSignal5Min { get => _candleSignal5Min; set { if (_candleSignal5Min != value) { _candleSignal5Min = value; OnPropertyChanged(); } } }
        public string CustomLevelSignal { get => _customLevelSignal; set { if (_customLevelSignal != value) { _customLevelSignal = value; OnPropertyChanged(); } } }
        public string SecurityId { get => _securityId; set { _securityId = value; OnPropertyChanged(); } }
        public string Symbol { get => _symbol; set { _symbol = value; OnPropertyChanged(); } }
        public decimal LTP { get => _ltp; set { if (_ltp != value) { _ltp = value; OnPropertyChanged(); } } }
        public decimal Vwap { get => _vwap; set { if (_vwap != value) { _vwap = value; OnPropertyChanged(); } } }
        public long CurrentVolume { get => _currentVolume; set { if (_currentVolume != value) { _currentVolume = value; OnPropertyChanged(); } } }
        public long AvgVolume { get => _avgVolume; set { if (_avgVolume != value) { _avgVolume = value; OnPropertyChanged(); } } }
        public string VolumeSignal { get => _volumeSignal; set { if (_volumeSignal != value) { _volumeSignal = value; OnPropertyChanged(); } } }
        public string OiSignal { get => _oiSignal; set { if (_oiSignal != value) { _oiSignal = value; OnPropertyChanged(); } } }
        public string InstrumentGroup { get => _instrumentGroup; set { if (_instrumentGroup != value) { _instrumentGroup = value; OnPropertyChanged(); } } }
        public string UnderlyingGroup { get => _underlyingGroup; set { if (_underlyingGroup != value) { _underlyingGroup = value; OnPropertyChanged(); } } }
        public string EmaSignal1Min { get => _emaSignal1Min; set { if (_emaSignal1Min != value) { _emaSignal1Min = value; OnPropertyChanged(); } } }
        public string EmaSignal5Min { get => _emaSignal5Min; set { if (_emaSignal5Min != value) { _emaSignal5Min = value; OnPropertyChanged(); } } }
        public string EmaSignal15Min { get => _emaSignal15Min; set { if (_emaSignal15Min != value) { _emaSignal15Min = value; OnPropertyChanged(); } } }
        public string VwapEmaSignal1Min { get => _vwapEmaSignal1Min; set { if (_vwapEmaSignal1Min != value) { _vwapEmaSignal1Min = value; OnPropertyChanged(); } } }
        public string VwapEmaSignal5Min { get => _vwapEmaSignal5Min; set { if (_vwapEmaSignal5Min != value) { _vwapEmaSignal5Min = value; OnPropertyChanged(); } } }
        public string VwapEmaSignal15Min { get => _vwapEmaSignal15Min; set { if (_vwapEmaSignal15Min != value) { _vwapEmaSignal15Min = value; OnPropertyChanged(); } } }
        public string PriceVsVwapSignal { get => _priceVsVwapSignal; set { if (_priceVsVwapSignal != value) { _priceVsVwapSignal = value; OnPropertyChanged(); } } }
        public string PriceVsCloseSignal { get => _priceVsCloseSignal; set { if (_priceVsCloseSignal != value) { _priceVsCloseSignal = value; OnPropertyChanged(); } } }
        public string DayRangeSignal { get => _dayRangeSignal; set { if (_dayRangeSignal != value) { _dayRangeSignal = value; OnPropertyChanged(); } } }

        private int _convictionScore;
        public int ConvictionScore { get => _convictionScore; set { if (_convictionScore != value) { _convictionScore = value; OnPropertyChanged(); } } }

        private string _finalTradeSignal = "Analyzing...";
        public string FinalTradeSignal { get => _finalTradeSignal; set { if (_finalTradeSignal != value) { _finalTradeSignal = value; OnPropertyChanged(); } } }

        private decimal _stopLoss;
        public decimal StopLoss { get => _stopLoss; set { if (_stopLoss != value) { _stopLoss = value; OnPropertyChanged(); } } }

        private decimal _targetPrice;
        public decimal TargetPrice { get => _targetPrice; set { if (_targetPrice != value) { _targetPrice = value; OnPropertyChanged(); } } }

        private string _institutionalIntent = "N/A";
        public string InstitutionalIntent { get => _institutionalIntent; set { if (_institutionalIntent != value) { _institutionalIntent = value; OnPropertyChanged(); } } }

        // --- NEW: Properties for Advanced Analysis ---
        private string _openTypeSignal = "N/A";
        public string OpenTypeSignal { get => _openTypeSignal; set => SetProperty(ref _openTypeSignal, value); }

        private string _yesterdayProfileSignal = "N/A";
        public string YesterdayProfileSignal { get => _yesterdayProfileSignal; set => SetProperty(ref _yesterdayProfileSignal, value); }

        private string _vwapBandSignal = "N/A";
        public string VwapBandSignal { get => _vwapBandSignal; set => SetProperty(ref _vwapBandSignal, value); }

        private decimal _vwapUpperBand;
        public decimal VwapUpperBand { get => _vwapUpperBand; set => SetProperty(ref _vwapUpperBand, value); }

        private decimal _vwapLowerBand;
        public decimal VwapLowerBand { get => _vwapLowerBand; set => SetProperty(ref _vwapLowerBand, value); }

        private decimal _anchoredVwap;
        public decimal AnchoredVwap { get => _anchoredVwap; set => SetProperty(ref _anchoredVwap, value); }

        private IntradayContext _intradayContext;
        public IntradayContext IntradayContext { get => _intradayContext; set => SetProperty(ref _intradayContext, value); }

        private string _marketNarrative = "Analyzing...";
        public string MarketNarrative { get => _marketNarrative; set => SetProperty(ref _marketNarrative, value); }


        public string FullGroupIdentifier
        {
            get
            {
                if (InstrumentGroup == "Options")
                {
                    if (UnderlyingGroup.ToUpper().Contains("NIFTY") && !UnderlyingGroup.ToUpper().Contains("BANK")) return "Nifty Options";
                    if (UnderlyingGroup.ToUpper().Contains("BANKNIFTY")) return "Banknifty Options";
                    if (UnderlyingGroup.ToUpper().Contains("SENSEX")) return "Sensex Options";
                    return "Other Stock Options";
                }
                if (InstrumentGroup == "Futures")
                {
                    if (UnderlyingGroup.ToUpper().Contains("NIFTY") || UnderlyingGroup.ToUpper().Contains("BANKNIFTY") || UnderlyingGroup.ToUpper().Contains("SENSEX"))
                        return "Index Futures";
                    return "Stock Futures";
                }
                return InstrumentGroup;
            }
        }
    }
}
