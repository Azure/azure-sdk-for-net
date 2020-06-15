## Microsoft.Azure.Management.StorageSync release notes

### Changes in 20202-03-01

- Support private links for Azure File Sync
- Additional cloud tiering status support, including:
    - Local cache performance metrics
    - Status for tiering policies

### Changes in 2019-06-01

- Support for cloud tiering health and recall status for server endpoints

### Changes in 2019-03-01

- Support for Invoke Change Detection command

### Changes in 2019-02-01

- Support for tracking parallel upload and download for server endpoints
- Rename the StorageAccountShareName parameter for cloud endpoints to AzureFileShareName

### Changes in 2018-04-02

- First version containing provisioning and deprovisioning of StorageSyncService, SyncGroup, CloudEndpoint , RegisteredServer and ServerEndpoint. It includes Recall operation as well.