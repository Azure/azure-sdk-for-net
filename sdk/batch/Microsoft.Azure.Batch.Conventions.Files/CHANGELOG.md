# Release History

## 3.6.0
The changes incorporated in this version are the product of migrating from the deprecated WindowsAzure .NET Storage SDK to the current Azure.Storage SDK. As a result, all the changes included in this version are **Breaking**:

- Replaced the following WindowsAzure SDK class references with the following Azure.Storage counterparts:
    | v11 | v12 |
|-------|--------|
| `CloudStorageAccount` | `BlobServiceClient` |
| `CloudBlobContainer`  | `BlobContainerClient` |
| `ICloudBlob` | `BlobBaseClient` |
| `CloudAppendBlob` | `AppendBlobClient` |

 - CloudJobExtensions
     - Modified the following method headers to replace `CloudStorageAccount` to accepting an instance of **BlobServiceClient**
         - `OutputStorage`
         - `PrepareOutputStorageAsync`
         - `GetOutputStorageContainerUrl`

  - CloudTaskExtensions
      - Modified the `TaskOutputStorage` method header to replace `CloudStorageAccount` to accepting an instance of **BlobServiceClient**
    
  - JobOutputStorage
      - Removed the IRetryPolicy

## 3.6.0-preview.1 (Unreleased)

### Bug fixes
- Updated dependency versions.
