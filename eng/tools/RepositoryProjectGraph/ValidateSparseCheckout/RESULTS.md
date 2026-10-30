# Sparse-checkout validation results

Record reviewed campaigns here; keep generated logs and graph artifacts beneath
`artifacts/validation/RepositoryProjectGraph/sparse-checkout` or in an external artifact store.
Every row must name the exact source commit and matrix scope. “All” means all cases in the recorded
manifest, not all repository pipelines.

| Date | Source commit | Host/image | Matrix scope | Cases | Passed | Failed | Result evidence | Notes |
|---|---|---|---|---:|---:|---:|---|---|
| _pending_ |  |  |  |  |  |  |  |  |

## Required campaign notes

- `checkout-graph.json` SHA-256 and schema version
- .NET SDKs, OS image, architecture, and whether execution was native or emulated
- whether PackageInfo/graph/map were freshly generated
- artifact and matrix filters, if any
- whether recordings and Azurite setup ran
- sparse-only failures versus failures reproduced in a full checkout
- omitted hosts, configurations, test categories, or setup steps
- links or paths to `summary.json`, `summary.md`, and retained failure logs
