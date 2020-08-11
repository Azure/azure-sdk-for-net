# Release History

## 4.3.0 (Unreleased)


## 4.2.1 (Unreleased)


## 4.2.0
### Breaking Changes
- Built-in checkpoint store is rolling back to WindowsAzure.Storage due to API timeout issues. (https://github.com/Azure/azure-sdk-for-net/pull/10265)

### Improvements
- Custom checkpoint support added. (https://github.com/Azure/azure-sdk-for-net/pull/7448)
- Lease Manager improvements to reduce checkpoint store I/O. (https://github.com/Azure/azure-sdk-for-net/pull/9357)
- Enforce stricter request timeouts in Azure Storage Lease Manager. (https://github.com/Azure/azure-sdk-for-net/pull/9988)
- Limit max number of expired lease single host can acquire. This helps to avoud single host acquiring more leases than it can handle. (https://github.com/Azure/azure-sdk-for-net/pull/11062)

### Bug fixes
- PartitionManager to notify exception to error handler during store initialization. (https://github.com/Azure/azure-sdk-for-net/pull/8088)
- Limit receiver identifiers to maximum 64 characters to avoid receiver failures in processor host with long names. (https://github.com/Azure/azure-sdk-for-net/pull/9443)
- Enforce request timeout at ListBlobsSegmentedAsync call to avoid lease manager hung. (https://github.com/Azure/azure-sdk-for-net/pull/10019)
- Don't block PartitionManager loop on close pump call. This avoids expiry of all leases due to blocking renew lease cycle. (https://github.com/Azure/azure-sdk-for-net/pull/10188)

## 4.1.0
## Breaking Changes
None

### Improvements
- A new EPH constructor added to support custom TokenProvider with custom LeaseManager and CheckpointManager. (https://github.com/Azure/azure-sdk-for-net/pull/7201)
- Microsoft.Azure.Storage.Blob dependency moved to 11.0.0 release. (https://github.com/Azure/azure-sdk-for-net/pull/7372)
- Added processor host receiver identifier which will help during debugging lease management issues. (https://github.com/Azure/azure-sdk-for-net/pull/7428)
- Adding API to support custom checkpointing, (https://github.com/Azure/azure-sdk-for-net/pull/7448)

### Bug fixes
None
