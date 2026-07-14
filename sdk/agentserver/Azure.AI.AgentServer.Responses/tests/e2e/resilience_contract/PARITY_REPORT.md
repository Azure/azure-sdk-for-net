# Resilience Contract — .NET Parity Report (e2e)

This file is the e2e-folder companion to the canonical
[`docs/dotnet-python-parity-report.md`](../../../docs/dotnet-python-parity-report.md),
mirroring the Python `tests/e2e/resilience_contract/PARITY_REPORT.md` location.

- **Coverage matrix**: [`CONTRACT_COVERAGE.md`](./CONTRACT_COVERAGE.md) — every
  normative contract clause mapped to its .NET test or the task that adds it.
- **Full parity analysis, severities, and Python-side action items**: see the
  canonical report linked above.

## Snapshot

| Layer | Status |
|-------|--------|
| Recovery payload schema (9-field, fail-closed) | ✅ parity, green |
| Dispatch matrix (classify/decide) | ✅ parity, green |
| Conversation chain id (cross-language digest) | ✅ parity, green |
| Chain metadata facade | ✅ parity, green |
| Internal-metadata persist-but-strip | ✅ parity, green |
| Public developer surface + docs + samples | ✅ parity |
| Deep crash-recovery orchestration (row×path, streaming reconnect, steering, fail-loud) | ⏳ pending — see coverage matrix task IDs |
