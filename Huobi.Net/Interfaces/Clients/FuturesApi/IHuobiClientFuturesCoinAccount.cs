
using System.Collections.Generic;
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
    public interface IHuobiClientFuturesCoinApiAccount
    {
        /// <summary>
        /// Gets a list of balances
        /// <para><a href="https://huobiapi.github.io/docs/dm/v1/en/#query-user-s-account-information" /></para>
        /// </summary>
        /// <param name="symbol">The id of the account to get the balances for</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<HuobiFuturesBalance>>> GetBalancesAsync(string? symbol = null, CancellationToken ct = default);

        /// <summary>
        /// Gets a list of positions
        /// <para><a href="https://huobiapi.github.io/docs/dm/v1/en/#query-user-s-position-information" /></para>
        /// </summary>
        /// <param name="symbol">The id of the account to get the balances for</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<HuobiFuturesPosition>>> GetPositionsAsync(string? symbol = null, CancellationToken ct = default);

        /// <summary>
        /// Gets a list of balances for a sub-account
        /// <para><a href="https://huobiapi.github.io/docs/dm/v1/en/#query-a-single-sub-account-39-s-assets-information-2" /></para>
        /// </summary>
        /// <param name="subId">The sub-account id</param>
        /// <param name="symbol">The id of the account to get the balances for</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<HuobiFuturesBalance>>> GetSubAccountBalancesAsync(long subId, string? symbol = null, CancellationToken ct = default);

        /// <summary>
        /// Transfer margin between spot and futures account
        /// <para><a href="https://huobiapi.github.io/docs/dm/v1/en/#transfer-margin-between-spot-account-and-future-account" /></para>
        /// </summary>
        /// <param name="asset">The asset to transfer</param>
        /// <param name="quantity">The amount to transfer</param>
        /// <param name="transferType">The direction of the transfer</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<long>> TransferBetweenSpotAndFutures(string asset, decimal quantity, FutureTransferType transferType, CancellationToken ct = default);
    }
}
