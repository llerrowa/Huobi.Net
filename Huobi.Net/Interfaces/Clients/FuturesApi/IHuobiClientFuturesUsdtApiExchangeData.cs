﻿using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CryptoExchange.Net.Objects;
using Huobi.Net.Objects.Models.Futures;

namespace Huobi.Net.Interfaces.Clients.FuturesApi
{
    /// <summary>
    /// Huobi exchange data endpoints. Exchange data includes market data (tickers, order books, etc) and system status.
    /// </summary>
    public interface IHuobiClientFuturesUsdtApiExchangeData
    {
        /// <summary>
        /// Gets a list of supported symbols
        /// <para><a href="https://huobiapi.github.io/docs/usdt_swap/v1/en/#general-query-swap-info" /></para>
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<HuobiFuturesSymbol>>> GetSymbolsAsync(CancellationToken ct = default);
        
        /// <summary>
        /// Gets the server time
        /// <para><a href="https://huobiapi.github.io/docs/usdt_swap/v1/en/#get-current-system-timestamp" /></para>
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<DateTime>> GetServerTimeAsync(CancellationToken ct = default);
    }
}
