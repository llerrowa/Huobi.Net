﻿using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using CryptoExchange.Net;
using CryptoExchange.Net.Objects;
using Huobi.Net.Clients.SwapsApi;
using Huobi.Net.Converters.Futures;
using Huobi.Net.Enums.Swaps;
using Huobi.Net.Interfaces.Clients.SwapsApi;
using Huobi.Net.Objects.Models.Swaps;
using Newtonsoft.Json;

namespace Huobi.Net.Clients.FuturesApi
{
    /// <inheritdoc />
    public class HuobiClientSwapsCoinApiAccount : IHuobiClientSwapsCoinApiAccount
    {
        private const string Api = "swap-api";
        private const string BalancesEndpoint = "swap_account_info";
        private const string PositionsEndpoint = "swap_position_info";
        private const string SubAccountBalancesEndpoint = "swap_sub_account_info";
        private const string TransferEndpoint = "account/transfer";

        private readonly HuobiClientSwapsCoinApi _baseClient;

        internal HuobiClientSwapsCoinApiAccount(HuobiClientSwapsCoinApi baseClient)
        {
            _baseClient = baseClient;
        }

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<HuobiSwapsBalance>>> GetBalancesAsync(string? symbol = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>();
            parameters.AddOptionalParameter("symbol", symbol);

            return await _baseClient.SendHuobiFuturesRequest<IEnumerable<HuobiSwapsBalance>>(_baseClient.GetUrl(BalancesEndpoint, Api, "1"), HttpMethod.Post, ct, parameters, true, weight: 1).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<HuobiSwapsPosition>>> GetPositionsAsync(string? symbol = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>();
            parameters.AddOptionalParameter("symbol", symbol);

            return await _baseClient.SendHuobiFuturesRequest<IEnumerable<HuobiSwapsPosition>>(_baseClient.GetUrl(PositionsEndpoint, Api, "1"), HttpMethod.Post, ct, parameters, true, weight: 1).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<HuobiSwapsBalance>>> GetSubAccountBalancesAsync(long subId, string? symbol = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>
            {
                { "sub_uid", subId.ToString(CultureInfo.InvariantCulture)}
            };
            parameters.AddOptionalParameter("symbol", symbol);

            return await _baseClient.SendHuobiFuturesRequest<IEnumerable<HuobiSwapsBalance>>(_baseClient.GetUrl(SubAccountBalancesEndpoint, Api, "1"), HttpMethod.Post, ct, parameters, true, weight: 1).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<long>> TransferBetweenSpotAndFutures(CoinSwapTransferType from, CoinSwapTransferType to, string asset, decimal quantity, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>
            {
                { "type", JsonConvert.SerializeObject(from, new UsdtSwapTransferTypeConverter(false)) },
                { "to", JsonConvert.SerializeObject(to, new UsdtSwapTransferTypeConverter(false)) },
                { "currency", asset },
                { "amount", quantity.ToString(CultureInfo.InvariantCulture) },
            };

            return await _baseClient.SendHuobiFuturesRequest<long>(_baseClient.GetUrl(TransferEndpoint, "2"), HttpMethod.Post, ct, parameters, true, weight: 1).ConfigureAwait(false);
        }
    }
}
