using CryptoExchange.Net.Converters;
using Huobi.Net.Enums.Swaps;
using System.Collections.Generic;

namespace Huobi.Net.Converters.Swaps
{
    internal class CoinSwapTransferTypeConverter : BaseConverter<CoinSwapTransferType>
    {
        public CoinSwapTransferTypeConverter() : this(true) { }

        public CoinSwapTransferTypeConverter(bool useQuotes) : base(useQuotes) { }

        protected override List<KeyValuePair<CoinSwapTransferType, string>> Mapping => new List<KeyValuePair<CoinSwapTransferType, string>>
        {
            new KeyValuePair<CoinSwapTransferType, string>(CoinSwapTransferType.Spot, "spot"),
            new KeyValuePair<CoinSwapTransferType, string>(CoinSwapTransferType.Swap, "swap")
        };
    }
}
