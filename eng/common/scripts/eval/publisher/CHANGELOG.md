# Changelog

## Unreleased

- Retain one complete, latest-attempt evaluation archive per build in Blob storage.
- Use authenticated Azure CLI publication instead of a custom Node Azure SDK transport.
- Read the storage account from pipeline-owned configuration and keep publishing policy in YAML.
- Pass archive identity explicitly and isolate token-bearing timeline verification from summary rendering.
- Preserve create-only uploads, checksum/provenance metadata, atomic receipts and authenticated notification recovery.
- Run shared/archive Node tests and tagged publisher PowerShell tests in the existing Windows/Linux PR CI job, without evaluations.
- Treat real redirect exceptions as permanent, reject noncanonical collision timestamps, and prevent receipt staging from overwriting saved archives.
- Read the dashboard refresh URL and Entra API resource from protected pipeline variables, validating both before acquiring notification credentials.
- Preserve uploaded archives when notification configuration is missing or invalid, and handle multiple Node installations in hosted CI regression tests.