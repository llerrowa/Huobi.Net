using System.Collections.Generic;
using CryptoExchange.Net.Converters;
using Huobi.Net.Enums.Futures;

namespace Huobi.Net.Converters.Futures
{
    internal class FutureTransferTypeConverter : BaseConverter<FutureTransferType>
    {
        public FutureTransferTypeConverter() : this(true) { }

        public FutureTransferTypeConverter(bool useQuotes) : base(useQuotes) { }

        protected override List<KeyValuePair<FutureTransferType, string>> Mapping => new List<KeyValuePair<FutureTransferType, string>>
        {
            new KeyValuePair<FutureTransferType, string>(FutureTransferType.SpotToFutures, "pro-to-futures"),
            new KeyValuePair<FutureTransferType, string>(FutureTransferType.FuturesToSpot, "futures-to-pro")
        };
    }
}
