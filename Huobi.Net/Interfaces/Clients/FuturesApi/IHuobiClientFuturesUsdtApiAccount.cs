﻿using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CryptoExchange.Net.Objects;
using Huobi.Net.Enums.Futures;
using Huobi.Net.Objects.Models.Futures;

namespace Huobi.Net.Interfaces.Clients.FuturesApi
{
    /// <summary>
    /// Huobi account endpoints. Account endpoints include balance info, withdraw/deposit info and requesting and account settings
    /// </summary>
    public interface IHuobiClientFuturesUsdtApiAccount
    {
        /// <summary>
        /// Gets a list of balances
        /// <para><a href="https://huobiapi.github.io/docs/usdt_swap/v1/en/#isolated-query-user-s-account-information" /></para>
        /// </summary>
        /// <param name="contractCode">The contract code to query balances for, returns all if null</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<HuobiFuturesUsdtBalance>>> GetBalancesIsolatedAsync(string? contractCode = null, CancellationToken ct = default);

        /// <summary>
        /// Gets a list of balances
        /// <para><a href="https://huobiapi.github.io/docs/usdt_swap/v1/en/#cross-query-user-39-s-account-information" /></para>
        /// </summary>
        /// <param name="marginAccount">The margin account to query balances for, i.e. "USDT", returns all if null</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<HuobiFuturesUsdtCrossBalance>>> GetBalancesCrossAsync(string? marginAccount = null, CancellationToken ct = default);

        /// <summary>
        /// Gets a list of positions
        /// <para><a href="https://huobiapi.github.io/docs/usdt_swap/v1/en/#isolated-query-user-s-position-information" /></para>
        /// </summary>
        /// <param name="symbol">The id of the account to get the balances for</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<HuobiFuturesUsdtPosition>>> GetPositionsIsolatedAsync(string? symbol = null, CancellationToken ct = default);

        /// <summary>
        /// Gets a list of positions
        /// <para><a href="https://huobiapi.github.io/docs/usdt_swap/v1/en/#cross-query-user-39-s-position-information" /></para>
        /// </summary>
        /// <param name="symbol">The id of the account to get the balances for</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<HuobiFuturesUsdtCrossPosition>>> GetPositionsCrossAsync(string? symbol = null, CancellationToken ct = default);

        /// <summary>
        /// Gets a list of balances for a sub-account
        /// <para><a href="https://huobiapi.github.io/docs/usdt_swap/v1/en/#isolated-query-a-single-sub-account-39-s-assets-information" /></para>
        /// </summary>
        /// <param name="subId">The sub-account id</param>
        /// <param name="contractCode">The contract code to query balances for, returns all if null</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<HuobiFuturesUsdtBalance>>> GetSubAccountBalancesIsolatedAsync(long subId, string? contractCode = null, CancellationToken ct = default);

        /// <summary>
        /// Gets a list of balances for a sub-account
        /// <para><a href="https://huobiapi.github.io/docs/usdt_swap/v1/en/#cross-query-a-batch-of-sub-account-39-s-assets-information" /></para>
        /// </summary>
        /// <param name="subId">The sub-account id</param>
        /// <param name="marginAccount">The margin account to query balances for, i.e. "USDT", returns all if null</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<HuobiFuturesUsdtCrossBalance>>> GetSubAccountBalancesCrossAsync(long subId, string? marginAccount = null, CancellationToken ct = default);

        /// <summary>
        /// Gets a list of balances for a sub-account
        /// <para><a href="https://huobiapi.github.io/docs/usdt_swap/v1/en/#isolated-query-a-single-sub-account-39-s-assets-information" /></para>
        /// </summary>
        /// <param name="subId">The sub-account id</param>
        /// <param name="contractCode">The contract code to query positions for, returns all if null</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<HuobiFuturesUsdtPosition>>> GetSubAccountPositionsIsolatedAsync(long subId, string? contractCode = null, CancellationToken ct = default);

        /// <summary>
        /// Gets a list of balances for a sub-account
        /// <para><a href="https://huobiapi.github.io/docs/usdt_swap/v1/en/#cross-query-a-sub-account-39-s-position-information" /></para>
        /// </summary>
        /// <param name="subId">The sub-account id</param>
        /// <param name="contractCode">The margin account to query positions for, i.e. "USDT", returns all if null</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<HuobiFuturesUsdtCrossPosition>>> GetSubAccountPositionsCrossAsync(long subId, string? contractCode = null, CancellationToken ct = default);
    }
}
