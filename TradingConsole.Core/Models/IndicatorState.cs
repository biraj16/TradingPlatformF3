// In TradingConsole.Core/Models/IndicatorState.cs
using System.Collections.Generic;

namespace TradingConsole.Core.Models
{
    /// <summary>
    /// Holds the final calculated state of indicators for a specific instrument and timeframe
    /// to be persisted at the end of a trading session.
    /// </summary>
    public class IndicatorState
    {
        public decimal LastShortEma { get; set; }
        public decimal LastLongEma { get; set; }
        public decimal LastVwapShortEma { get; set; }
        public decimal LastVwapLongEma { get; set; }
        public decimal LastRsiAvgGain { get; set; }
        public decimal LastRsiAvgLoss { get; set; }
        public decimal LastAtr { get; set; }
        public decimal LastObv { get; set; }
        public decimal LastObvMovingAverage { get; set; }
    }

    /// <summary>
    /// Represents the entire database of saved indicator states, which will be serialized to JSON.
    /// </summary>
    public class IndicatorStateDatabase
    {
        /// <summary>
        /// The dictionary of saved states.
        /// Key: A composite key string in the format "{SecurityId}_{TimeframeMinutes}", e.g., "2885_5".
        /// </summary>
        public Dictionary<string, IndicatorState> States { get; set; } = new Dictionary<string, IndicatorState>();
    }
}
