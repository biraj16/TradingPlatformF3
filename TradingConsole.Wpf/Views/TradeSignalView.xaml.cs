using System.Windows.Controls;
using System.Windows.Input;
using TradingConsole.Wpf.ViewModels;

namespace TradingConsole.Wpf.Views
{
    /// <summary>
    /// Interaction logic for TradeSignalView.xaml
    /// </summary>
    public partial class TradeSignalView : UserControl
    {
        public TradeSignalView()
        {
            InitializeComponent();
        }

        // --- NEW: Event handler to toggle the IsExpanded property on the data context of the clicked row ---
        private void DataGridRow_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (sender is DataGridRow row && row.DataContext is AnalysisResult result)
            {
                result.IsExpanded = !result.IsExpanded;
            }
        }
    }

    // --- NEW: A simple converter to hide the driver sections if the list is empty ---
    public class CountToVisibilityConverter : System.Windows.Data.IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is int count && count > 0)
            {
                return System.Windows.Visibility.Visible;
            }
            return System.Windows.Visibility.Collapsed;
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new System.NotImplementedException();
        }
    }
}
