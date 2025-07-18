// In TradingConsole.Wpf/ViewModels/TradeSignalViewModel.cs
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace TradingConsole.Wpf.ViewModels
{
    public class TradeSignalViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<AnalysisResult> SignalResults { get; } = new ObservableCollection<AnalysisResult>();

        public TradeSignalViewModel()
        {
        }

        public void UpdateSignalResult(AnalysisResult newResult)
        {
            // This view is only for indices, so we filter out everything else.
            if (newResult.InstrumentGroup != "Indices")
            {
                return;
            }

            var existingResult = SignalResults.FirstOrDefault(r => r.SecurityId == newResult.SecurityId);

            if (existingResult != null)
            {
                existingResult.Symbol = newResult.Symbol;
                existingResult.ConvictionScore = newResult.ConvictionScore;
                existingResult.FinalTradeSignal = newResult.FinalTradeSignal;
            }
            else
            {
                SignalResults.Add(newResult);
            }
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
