using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using CryptoExchange.Net;
using CryptoExchange.Net.Objects;
using Huobi.Net.Converters.Futures;
using Huobi.Net.Enums.Futures;
using Huobi.Net.Interfaces.Clients.FuturesApi;
using Huobi.Net.Objects.Models.Futures;
using Newtonsoft.Json;

namespace Huobi.Net.Clients.FuturesApi
{
    /// <inheritdoc />
    public class HuobiClientFuturesCoinApiAccount : IHuobiClientFuturesCoinApiAccount
    {
        private const string BalancesEndpoint = "contract_account_info";
        private const string PositionsEndpoint = "contract_position_info";
        private const string SubAccountBalancesEndpoint = "contract_sub_account_info";
        private const string TransferEndpoint = "futures/transfer";

        private readonly HuobiClientFuturesCoinApi _baseClient;

        internal HuobiClientFuturesCoinApiAccount(HuobiClientFuturesCoinApi baseClient)
        {
            _baseClient = baseClient;
        }

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<HuobiFuturesBalance>>> GetBalancesAsync(string? symbol = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>();
            parameters.AddOptionalParameter("symbol", symbol);

            return await _baseClient.SendHuobiFuturesRequest<IEnumerable<HuobiFuturesBalance>>(_baseClient.GetUrl(BalancesEndpoint, "1"), HttpMethod.Post, ct, parameters, true, weight: 1).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<HuobiFuturesPosition>>> GetPositionsAsync(string? symbol = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>();
            parameters.AddOptionalParameter("symbol", symbol);

            return await _baseClient.SendHuobiFuturesRequest<IEnumerable<HuobiFuturesPosition>>(_baseClient.GetUrl(PositionsEndpoint, "1"), HttpMethod.Post, ct, parameters, true, weight: 1).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<HuobiFuturesBalance>>> GetSubAccountBalancesAsync(long subId, string? symbol = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>
            {
                { "sub_uid", subId.ToString(CultureInfo.InvariantCulture)}
            };
            parameters.AddOptionalParameter("symbol", symbol);

            return await _baseClient.SendHuobiFuturesRequest<IEnumerable<HuobiFuturesBalance>>(_baseClient.GetUrl(SubAccountBalancesEndpoint, "1"), HttpMethod.Post, ct, parameters, true, weight: 1).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<long>> TransferBetweenSpotAndFutures(string asset, decimal quantity, FutureTransferType transferType, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>
            {
                { "currency", asset },
                { "amount", quantity.ToString(CultureInfo.InvariantCulture) },
                { "type", JsonConvert.SerializeObject(transferType, new FutureTransferTypeConverter(false)) }
            };

            return await _baseClient.SendHuobiFuturesRequest<long>(_baseClient.GetUrl(TransferEndpoint, "1"), HttpMethod.Post, ct, parameters, true, weight: 1).ConfigureAwait(false);
        }
    }
}
