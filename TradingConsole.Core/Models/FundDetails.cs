using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TradingConsole.Core.Models
{
    public class FundDetails : INotifyPropertyChanged
    {
        // ... all properties ...
        private decimal _availableBalance;
        public decimal AvailableBalance { get => _availableBalance; set { if (_availableBalance != value) { _availableBalance = value; OnPropertyChanged(); } } }
        private decimal _utilizedMargin;
        public decimal UtilizedMargin { get => _utilizedMargin; set { if (_utilizedMargin != value) { _utilizedMargin = value; OnPropertyChanged(); } } }
        private decimal _collateral;
        public decimal Collateral { get => _collateral; set { if (_collateral != value) { _collateral = value; OnPropertyChanged(); } } }
        private decimal _withdrawableBalance;
        public decimal WithdrawableBalance { get => _withdrawableBalance; set { if (_withdrawableBalance != value) { _withdrawableBalance = value; OnPropertyChanged(); } } }


        public event PropertyChangedEventHandler? PropertyChanged; // FIX: Nullable event
        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null) // FIX: Nullable propertyName
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
