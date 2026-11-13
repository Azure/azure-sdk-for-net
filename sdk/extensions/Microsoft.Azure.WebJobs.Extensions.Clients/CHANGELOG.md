# Release History

## 1.0.0-beta.1 (Unreleased)

- Initial release of the package.
- `StorageClientProvider` now prefers an explicit `{subdomain}ServiceUri` configuration value over `accountName` when both are present, and honors an optional `endpointSuffix` setting when constructing the service URI from `accountName`. This enables sovereign-cloud (e.g. Azure US Government, Azure China) deployments where the Azure Functions host injects `accountName` automatically. ([#57543](https://github.com/Azure/azure-sdk-for-net/issues/57543))
