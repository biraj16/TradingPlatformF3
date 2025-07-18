using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TradingConsole.Core.Models
{
    public class Position : INotifyPropertyChanged
    {
        private bool _isSelected;
        private decimal _lastTradedPrice;

        public bool IsSelected { get => _isSelected; set { if (_isSelected != value) { _isSelected = value; OnPropertyChanged(); } } }
        // --- FIX: Initialized non-nullable string properties ---
        public string SecurityId { get; set; } = string.Empty;
        public string Ticker { get; set; } = string.Empty;
        public string ProductType { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal AveragePrice { get; set; }
        public decimal RealizedPnl { get; set; }
        public decimal SellAverage { get; set; }
        public int BuyQuantity { get; set; }
        public int SellQuantity { get; set; }
        public decimal LastTradedPrice { get => _lastTradedPrice; set { if (_lastTradedPrice != value) { _lastTradedPrice = value; OnPropertyChanged(); OnPropertyChanged(nameof(UnrealizedPnl)); } } }
        public decimal UnrealizedPnl
        {
            get
            {
                if (Quantity > 0) // Long position
                {
                    return Quantity * (LastTradedPrice - AveragePrice);
                }
                else if (Quantity < 0) // Short position
                {
                    return Math.Abs(Quantity) * (AveragePrice - LastTradedPrice);
                }
                else
                {
                    return 0;
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
