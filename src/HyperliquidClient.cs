using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace HLWhaleWatch
{
    /// <summary>
    /// Client for the public Hyperliquid Info API.
    /// Provides read-only access to whale positions, wallet data, liquidation radar, and sentiment.
    /// </summary>
    public class HyperliquidClient : IDisposable
    {
        private readonly HttpClient _httpClient;

        /// <summary>
        /// Default public Hyperliquid info endpoint.
        /// TODO: replace with actual endpoint if it changes.
        /// </summary>
        public const string DefaultEndpoint = "https://api.hyperliquid.xyz/info";

        public HyperliquidClient(string? endpoint = null)
        {
            _httpClient = new HttpClient
            {
                Timeout = TimeSpan.FromSeconds(30)
            };
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            _httpClient.DefaultRequestHeaders.Add("Content-Type", "application/json");
            Endpoint = endpoint ?? DefaultEndpoint;
        }

        public string Endpoint { get; }

        /// <summary>
        /// Sends a JSON-RPC style request to the Hyperliquid info API.
        /// </summary>
        private async Task<T?> PostAsync<T>(object payload)
        {
            try
            {
                var json = JsonSerializer.Serialize(payload);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync(Endpoint, content);
                response.EnsureSuccessStatusCode();

                var responseJson = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<T>(responseJson);
            }
            catch (HttpRequestException)
            {
                // HTTP error (e.g., 500, 503, connection refused)
                return default;
            }
            catch (TaskCanceledException)
            {
                // Request timeout
                return default;
            }
            catch (JsonException)
            {
                // Invalid JSON response
                return default;
            }
        }

        /// <summary>
        /// Gets whale positions (large positions across the market).
        /// </summary>
        public async Task<List<WhalePosition>?> GetWhalePositionsAsync()
        {
            // TODO: implement actual API payload structure for Hyperliquid /info endpoint
            var payload = new { type = "whalePositions" };
            return await PostAsync<List<WhalePosition>>(payload);
        }

        /// <summary>
        /// Gets positions for a specific wallet address.
        /// </summary>
        /// <param name="address">Wallet address to query.</param>
        public async Task<List<WhalePosition>?> GetWalletPositionsAsync(string address)
        {
            // TODO: implement actual API payload structure
            var payload = new { type = "walletPositions", address = address };
            return await PostAsync<List<WhalePosition>>(payload);
        }

        /// <summary>
        /// Gets positions close to liquidation (liquidation radar).
        /// </summary>
        public async Task<List<LiquidationEntry>?> GetLiquidationRadarAsync()
        {
            // TODO: implement actual API payload structure
            var payload = new { type = "liquidationRadar" };
            return await PostAsync<List<LiquidationEntry>>(payload);
        }

        /// <summary>
        /// Gets long/short ratio sentiment for a coin.
        /// </summary>
        /// <param name="coin">Coin symbol, e.g. "BTC".</param>
        public async Task<SentimentData?> GetLongShortRatioAsync(string coin)
        {
            // TODO: implement actual API payload structure
            var payload = new { type = "longShortRatio", coin = coin };
            return await PostAsync<SentimentData>(payload);
        }

        public void Dispose()
        {
            _httpClient?.Dispose();
        }
    }
}