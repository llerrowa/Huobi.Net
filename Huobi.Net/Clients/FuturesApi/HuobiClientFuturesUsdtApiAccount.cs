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
    public class HuobiClientFuturesUsdtApiAccount : IHuobiClientFuturesUsdtApiAccount
    {
        private const string Api = "linear-swap-api";

        private const string BalancesIsolatedEndpoint = "swap_account_info";
        private const string BalancesCrossEndpoint = "swap_cross_account_info";
        private const string PositionsIsolatedEndpoint = "swap_position_info";
        private const string PositionsCrossEndpoint = "swap_cross_position_info";
        private const string SubAccountBalancesIsolatedEndpoint = "swap_sub_account_info";
        private const string SubAccountBalancesCrossEndpoint = "swap_cross_sub_account_info";
        private const string TransferEndpoint = "account/transfer";

        private readonly HuobiClientFuturesUsdtApi _baseClient;

        internal HuobiClientFuturesUsdtApiAccount(HuobiClientFuturesUsdtApi baseClient)
        {
            _baseClient = baseClient;
        }

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<HuobiFuturesUsdtBalance>>> GetBalancesIsolatedAsync(string? contractCode = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>();
            parameters.AddOptionalParameter("contract_code", contractCode);

            return await _baseClient.SendHuobiFuturesRequest<IEnumerable<HuobiFuturesUsdtBalance>>(_baseClient.GetUrl(BalancesIsolatedEndpoint, Api, "1"), HttpMethod.Post, ct, parameters, true, weight: 1).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<HuobiFuturesUsdtCrossBalance>>> GetBalancesCrossAsync(string? marginAccount = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>();
            parameters.AddOptionalParameter("margin_account", marginAccount);

            return await _baseClient.SendHuobiFuturesRequest<IEnumerable<HuobiFuturesUsdtCrossBalance>>(_baseClient.GetUrl(BalancesCrossEndpoint, Api, "1"), HttpMethod.Post, ct, parameters, true, weight: 1).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<HuobiFuturesUsdtPosition>>> GetPositionsIsolatedAsync(string? contractCode = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>();
            parameters.AddOptionalParameter("contract_code", contractCode);

            return await _baseClient.SendHuobiFuturesRequest<IEnumerable<HuobiFuturesUsdtPosition>>(_baseClient.GetUrl(PositionsIsolatedEndpoint, Api, "1"), HttpMethod.Post, ct, parameters, true, weight: 1).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<HuobiFuturesUsdtCrossPosition>>> GetPositionsCrossAsync(string? marginAccount = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>();
            parameters.AddOptionalParameter("margin_account", marginAccount);

            return await _baseClient.SendHuobiFuturesRequest<IEnumerable<HuobiFuturesUsdtCrossPosition>>(_baseClient.GetUrl(PositionsCrossEndpoint, Api, "1"), HttpMethod.Post, ct, parameters, true, weight: 1).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<HuobiFuturesUsdtBalance>>> GetSubAccountBalancesIsolatedAsync(long subId, string? contractCode = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>
            {
                { "sub_uid", subId.ToString(CultureInfo.InvariantCulture)}
            };
            parameters.AddOptionalParameter("contract_code", contractCode);

            return await _baseClient.SendHuobiFuturesRequest<IEnumerable<HuobiFuturesUsdtBalance>>(_baseClient.GetUrl(SubAccountBalancesIsolatedEndpoint, Api, "1"), HttpMethod.Post, ct, parameters, true, weight: 1).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<HuobiFuturesUsdtCrossBalance>>> GetSubAccountBalancesCrossAsync(long subId, string? marginAccount = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>
            {
                { "sub_uid", subId.ToString(CultureInfo.InvariantCulture)}
            };
            parameters.AddOptionalParameter("margin_account", marginAccount);

            return await _baseClient.SendHuobiFuturesRequest<IEnumerable<HuobiFuturesUsdtCrossBalance>>(_baseClient.GetUrl(SubAccountBalancesCrossEndpoint, Api, "1"), HttpMethod.Post, ct, parameters, true, weight: 1).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<long>> TransferBetweenSpotAndUsdtSwap(UsdtSwapTransferType from, UsdtSwapTransferType to, string asset, decimal quantity, string marginAccount, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>
            {
                { "type", JsonConvert.SerializeObject(from, new UsdtSwapTransferTypeConverter(false)) },
                { "to", JsonConvert.SerializeObject(to, new UsdtSwapTransferTypeConverter(false)) },
                { "currency", asset },
                { "amount", quantity.ToString(CultureInfo.InvariantCulture) },
                { "margin-account", marginAccount }
            };

            return await _baseClient.SendHuobiFuturesRequest<long>(_baseClient.GetUrl(TransferEndpoint, "2"), HttpMethod.Post, ct, parameters, true, weight: 1).ConfigureAwait(false);
        }
    }
}
