using CryptoExchange.Net.Converters;
using Huobi.Net.Enums.Futures;
using System.Collections.Generic;

namespace Huobi.Net.Converters.Futures
{
    internal class UsdtSwapTransferTypeConverter : BaseConverter<UsdtSwapTransferType>
    {
        public UsdtSwapTransferTypeConverter() : this(true) { }

        public UsdtSwapTransferTypeConverter(bool useQuotes) : base(useQuotes) { }

        protected override List<KeyValuePair<UsdtSwapTransferType, string>> Mapping => new List<KeyValuePair<UsdtSwapTransferType, string>>
        {
            new KeyValuePair<UsdtSwapTransferType, string>(UsdtSwapTransferType.Spot, "spot"),
            new KeyValuePair<UsdtSwapTransferType, string>(UsdtSwapTransferType.LinearSwap, "linear-swap")
        };
    }
}