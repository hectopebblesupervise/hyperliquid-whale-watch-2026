# Developer Notes

## Overview

Hyperliquid Whale Watch is a desktop read-only tracker for the Hyperliquid decentralized exchange. It monitors large positions (whales), wallet PnL, liquidation radar, and market sentiment using the public Hyperliquid API.

## Data Source

The tracker uses the public Hyperliquid `/info` endpoint at `https://api.hyperliquid.xyz/info`. No API keys are required, and no private data is accessed. The tool is strictly read-only.

## Updating the Endpoint

If the Hyperliquid API endpoint changes, update the endpoint URL in `HyperliquidClient.cs`. The constant `DefaultEndpoint` is defined there for easy modification.

## Known Limitations

- All data is public and may be delayed.
- Accuracy depends on the Hyperliquid public API.
- The tracker does not trade, sign transactions, or access wallets.
- Whale thresholds are configurable in settings.