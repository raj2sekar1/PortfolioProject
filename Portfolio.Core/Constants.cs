namespace Portfolio.Core;

public static class Constants
{
    public static class AssetSymbolConstants
    {
        public const string SYMBOL_1 = "AAPL";
        public const string SYMBOL_2 = "GOOG";
        public const string SYMBOL_3 = "TSLA";
    }

    public static class AssetTypeConstants
    {
        public const string TYPE_1 = "Stock";
        public const string TYPE_2 = "Bond";
    }

    public static class TransactionTypeConstants
    {
        public const string TYPE_BUY = "Buy";
        public const string TYPE_SELL = "Sell";
    }

    public static class MockMarketConstants
    {
        public static readonly Dictionary<string, decimal> PRICES = new()
        {
            { AssetSymbolConstants.SYMBOL_1, 200m },
            { AssetSymbolConstants.SYMBOL_2, 700m },
            { AssetSymbolConstants.SYMBOL_3, 100m }
        };
    }

    public static class ErrorConstants
    {
        public const string UNHANDLED_EXCEPTION = "Unhandled exception";
    }
}
