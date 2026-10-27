# Changelog

## Unreleased

- Exclude older JUnit from summaries and selected test files when it does not match the latest verified timeline attempt; keep missing results incomplete.
- Keep shared publisher tests independent of Tools-only CI/Pester/redirect files, while retaining those checks in Tools and testing consumer copies.
- Pass the create-only wildcard as one `--if-none-match=*` argument so Linux cannot expand it into working-directory file names.
- Disable Azure CLI upload progress and parse only stdout so native stderr cannot corrupt a successful JSON result.
- Preserve safe upload/fallback exit codes and known storage error codes without logging CLI response bodies, tokens or request details.
- Exercise the actual Azure CLI against a localhost-only storage fixture, with a bounded startup deadline, synthetic parser diagnostics and no Azure credentials or model evaluations.
- Align entrypoint tests with the existing GitHub App migration instead of expecting the removed PAT variable group.
- Retain one complete, latest-attempt evaluation archive per build in Blob storage.
- Use authenticated Azure CLI publication instead of a custom Node Azure SDK transport.
- Read the storage account from pipeline-owned configuration and keep publishing policy in YAML.
- Pass archive identity explicitly and isolate token-bearing timeline verification from summary rendering.
- Preserve create-only uploads, checksum/provenance metadata and authenticated notification recovery.
- Run shared/archive Node tests and tagged publisher PowerShell tests in the existing Windows/Linux PR CI job, without evaluations.
- Treat real redirect exceptions as permanent and reject noncanonical collision timestamps.
- Read the dashboard refresh URL and Entra API resource from protected pipeline variables, validating both before acquiring notification credentials.
- Preserve uploaded archives when notification configuration is missing or invalid, and handle multiple Node installations in hosted CI regression tests.
- Remove optional local publication status files; log confirmed uploads before attempting warning-only dashboard notifications.
- Use Node 24.14.1+ and pinned pnpm 12.6.0 for the publisher, with a portable SHA512 lock and frozen installs isolated from consuming workspaces.
- Enforce required entries and byte/trial/entry budgets during construction, including merged JSONL, instead of decoding the new ZIP again.
- Validate exactly one Summary-selected attempt per expected shard and parse JSONL strings directly without repeated Buffer conversions.