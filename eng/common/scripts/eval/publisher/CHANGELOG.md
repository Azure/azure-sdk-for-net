# Changelog

## Unreleased

- Retain one complete, latest-attempt evaluation archive per build in Blob storage.
- Use authenticated Azure CLI publication instead of a custom Node Azure SDK transport.
- Read the storage account from pipeline-owned configuration and keep publishing policy in YAML.
- Pass archive identity explicitly and isolate token-bearing timeline verification from summary rendering.
- Preserve create-only uploads, checksum/provenance metadata, atomic receipts and authenticated notification recovery.