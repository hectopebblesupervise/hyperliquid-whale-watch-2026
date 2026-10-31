using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Interop;

namespace HLWhaleWatch
{
    /// <summary>
    /// Main window for Hyperliquid Whale Watch.
    /// Handles UI events, Hyperliquid client integration, and dashboard updates.
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly HyperliquidClient _apiClient = new HyperliquidClient();
        private readonly Settings _settings = Settings.Load();

        public MainWindow()
        {
            InitializeComponent();
            UpdateStatus("Ready");
        }

        private async void BtnRefreshWhales_Click(object sender, RoutedEventArgs e)
        {
            btnRefreshWhales.IsEnabled = false;
            UpdateStatus("Fetching whale positions...");

            try
            {
                var positions = await _apiClient.GetWhalePositionsAsync();
                lstWhales.Items.Clear();
                if (positions != null)
                {
                    foreach (var p in positions)
                    {
                        lstWhales.Items.Add(
                            $"{p.Address.Substring(0, 8)}... | {p.Coin} {p.Side} | Size: {p.Size:N2} | PnL: {p.UnrealizedPnl:N2} | Lev: {p.Leverage}x");
                    }
                }
                UpdateStatus("Whale positions updated");
            }
            catch (Exception)
            {
                UpdateStatus("Error fetching whale positions");
            }
            finally
            {
                btnRefreshWhales.IsEnabled = true;
            }
        }

        private void BtnAddWallet_Click(object sender, RoutedEventArgs e)
        {
            var address = txtWalletAddress.Text.Trim();
            if (string.IsNullOrEmpty(address))
            {
                txtStatus.Text = "Wallet address required";
                return;
            }

            if (!_settings.TrackedWallets.Contains(address))
            {
                _settings.TrackedWallets.Add(address);
                _settings.Save();
            }

            txtWalletAddress.Clear();
            RefreshWallets();
            txtStatus.Text = $"Wallet {address} added";
        }

        private async void BtnRefreshLiq_Click(object sender, RoutedEventArgs e)
        {
            btnRefreshLiq.IsEnabled = false;
            UpdateStatus("Fetching liquidation radar...");

            try
            {
                var liquidations = await _apiClient.GetLiquidationRadarAsync();
                lstLiquidations.Items.Clear();
                if (liquidations != null)
                {
                    foreach (var liq in liquidations)
                    {
                        lstLiquidations.Items.Add(
                            $"{liq.Address.Substring(0, 8)}... | {liq.Coin} {liq.Side} | Liq: {liq.LiquidationPrice:N2} | Dist: {liq.DistanceToLiqPercent:F1}%");
                    }
                }
                UpdateStatus("Liquidation radar updated");
            }
            catch (Exception)
            {
                UpdateStatus("Error fetching liquidation data");
            }
            finally
            {
                btnRefreshLiq.IsEnabled = true;
            }
        }

        private async void BtnRefreshSentiment_Click(object sender, RoutedEventArgs e)
        {
            btnRefreshSentiment.IsEnabled = false;
            UpdateStatus("Fetching sentiment data...");

            try
            {
                var sentiment = await _apiClient.GetLongShortRatioAsync("BTC");
                lstSentiment.Items.Clear();
                if (sentiment != null)
                {
                    lstSentiment.Items.Add(
                        $"{sentiment.Coin}: Long {sentiment.LongPercentage:F1}% | Short {sentiment.ShortPercentage:F1}% | OI Long: {sentiment.LongOi:N0} | OI Short: {sentiment.ShortOi:N0}");
                }
                UpdateStatus("Sentiment updated");
            }
            catch (Exception)
            {
                UpdateStatus("Error fetching sentiment data");
            }
            finally
            {
                btnRefreshSentiment.IsEnabled = true;
            }
        }

        private void RefreshWallets()
        {
            lstWallets.Items.Clear();
            foreach (var w in _settings.TrackedWallets)
            {
                lstWallets.Items.Add(w.Substring(0, Math.Min(12, w.Length)) + "...");
            }
        }

        private void UpdateStatus(string message)
        {
            txtStatus.Text = message;
        }

        protected override void OnClosed(EventArgs e)
        {
            _apiClient?.Dispose();
            base.OnClosed(e);
        }
    }
}