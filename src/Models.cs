namespace HLWhaleWatch
{
    /// <summary>
    /// Represents a whale position observed on Hyperliquid.
    /// </summary>
    public class WhalePosition
    {
        public string Address { get; set; } = string.Empty;
        public string Coin { get; set; } = string.Empty;
        public string Side { get; set; } = string.Empty;
        public decimal Size { get; set; }
        public decimal EntryPrice { get; set; }
        public decimal LiquidationPrice { get; set; }
        public decimal UnrealizedPnl { get; set; }
        public decimal Leverage { get; set; }
    }

    /// <summary>
    /// Represents a summary of a tracked wallet.
    /// </summary>
    public class WalletSummary
    {
        public string Address { get; set; } = string.Empty;
        public decimal TotalPnl { get; set; }
        public int PositionCount { get; set; }
        public decimal WinRate { get; set; }
    }

    /// <summary>
    /// Represents a position close to liquidation.
    /// </summary>
    public class LiquidationEntry
    {
        public string Address { get; set; } = string.Empty;
        public string Coin { get; set; } = string.Empty;
        public string Side { get; set; } = string.Empty;
        public decimal Size { get; set; }
        public decimal LiquidationPrice { get; set; }
        public decimal MarkPrice { get; set; }
        public decimal DistanceToLiqPercent { get; set; }
    }

    /// <summary>
    /// Represents long/short market sentiment data.
    /// </summary>
    public class SentimentData
    {
        public string Coin { get; set; } = string.Empty;
        public decimal LongPercentage { get; set; }
        public decimal ShortPercentage { get; set; }
        public decimal LongOi { get; set; }
        public decimal ShortOi { get; set; }
        public DateTime TimestampUtc { get; set; } = DateTime.UtcNow;
    }
}