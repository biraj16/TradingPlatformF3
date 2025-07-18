// In TradingConsole.Core/Models/OptionChainRow.cs
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TradingConsole.Core.Models
{
    public enum OptionState
    {
        ITM,
        OTM,
        ATM
    }

    public class OptionChainRow : INotifyPropertyChanged
    {
        public OptionDetails CallOption { get; set; } = new OptionDetails();
        public OptionDetails PutOption { get; set; } = new OptionDetails();
        public decimal StrikePrice { get; set; }
        public bool IsAtm { get; set; }
        public OptionState CallState { get; set; }
        public OptionState PutState { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class OptionDetails : INotifyPropertyChanged
    {
        private string _securityId = string.Empty;
        private decimal _ltp;
        private decimal _previousClose;
        private decimal _iv;
        private decimal _oi;
        private decimal _oiChange;
        private decimal _oiChangePercent;
        private long _volume;
        private decimal _delta;

        public string SecurityId { get => _securityId; set { _securityId = value; OnPropertyChanged(nameof(SecurityId)); } }
        public decimal LTP { get => _ltp; set { if (_ltp != value) { _ltp = value; OnPropertyChanged(nameof(LTP)); OnPropertyChanged(nameof(LtpChange)); OnPropertyChanged(nameof(LtpChangePercent)); } } }
        public decimal PreviousClose { get => _previousClose; set { _previousClose = value; OnPropertyChanged(nameof(PreviousClose)); OnPropertyChanged(nameof(LtpChange)); OnPropertyChanged(nameof(LtpChangePercent)); } }
        public decimal LtpChange => LTP - PreviousClose;
        public decimal LtpChangePercent => PreviousClose == 0 ? 0 : (LtpChange / PreviousClose);
        public decimal IV { get => _iv; set { _iv = value; OnPropertyChanged(nameof(IV)); } }
        public decimal OI { get => _oi; set { _oi = value; OnPropertyChanged(nameof(OI)); } }
        public decimal OiChange { get => _oiChange; set { _oiChange = value; OnPropertyChanged(nameof(OiChange)); } }
        public decimal OiChangePercent { get => _oiChangePercent; set { _oiChangePercent = value; OnPropertyChanged(nameof(OiChangePercent)); } }
        public long Volume { get => _volume; set { _volume = value; OnPropertyChanged(nameof(Volume)); } }
        public decimal Delta { get => _delta; set { _delta = value; OnPropertyChanged(nameof(Delta)); } }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
