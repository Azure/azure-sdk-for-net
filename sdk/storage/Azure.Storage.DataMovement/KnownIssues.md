# Known Issues

Azure.Storage.DataMovement is still in beta. Not all functionality is currently implemented, and there are known issues that may cause problems for your application. Significant known issues are documented below

## Preserving properties and metadata on copy

When copying data between blobs, blob properties and blob metadata are not preserved. There is currently no support for this feature; properties and metadata can only be defined by the caller to be applied uniformly to each destination blob.

This limitation also exists for share files and directories.

### Client-side encryption support

**There is no support for copying client-side encrypted blobs.** Since client-side encryption is built on blob metadata, the necessary information to decrypt the blob will not be transferred in a service-to-service copy. Azure.Storage.Blobs will not be able to decrypt the copied blob. If that metadata is lost, your blob contents will be lost forever.

### BlobFuse support

BlobFuse uses custom blob metadata to manage it's directory structure. That metadata will currently be lost on a service to service copy.

## Blob HNS Support

There is currently no explicit support for Azure Blob Storage accounts with hierarchichal namespace enabled. This can manifest in unexpected errors with some transfers of multi-level directories. Single blob transfers and transfers of directories with no subdirectories should be unaffected by this lack of support.

## Transfer Sizes

The Azure Storage REST service has various limitations as to the size of request body it will accept, depending on the operation being performed. While the DataMovement library attempts to clamp transfer chunk sizes down to accepted levels, it is not always accurate. Please refer to the [REST documentation](https://learn.microsoft.com/rest/api/storageservices/) for information on transfer size limitations.

### Resume Behavior when Client Options are set

When calling `*StorageResourceProvider.FromClient` with a Storage Client (e.g. `BlobBaseClient`, `ShareFileClient`) initialized with `*ClientOptions` (e.g `BlobClientOptions`, `ShareClientOptions`). It is NOT guaranteed that properties set within the `*ClientOptions` will be respected when resuming a transfer.

### Encryption Scope Support

There is currently no support to specify an encryption scope for operations such as uploads, downloads, or copies.

### Recursive Directory Support

There is currently no support to handle operations that involve processing an entire directory, including all its subdirectories and files, automatically in a single command.

### Blob to File with OAuth/Entra ID

There is currently no support for transferring data from an Azure Blob Storage to a file system using authentication based on Microsoft Entra ID.

### Resume Transfers started from any Beta version

Transfers initiated with any beta version cannot be resumed due to a schema version change from string to int, which may lead to unexpected errors.

### Tag Support

There is currently no support for managing or utilizing tags. This means users cannot add, retrieve, or manage blob tags during a transfer.

### Public URL Copying

There is currently no support for copying blobs via Public URLs. However, the library does support copying Azure Storage URLs, which can be used for moving data within the Azure Storage ecosystem.

### Copy with a AzureSasCredential

There is currently no support for service-to-service copy given a client that was initialized with a AzureSasCredential from BlobStorageResourceProvider.FromClient and/or ShareStorageResourceProvider.FromClient.

### Fresh transfer vs Resumed transfer Performance

The performance of resumed transfers is currently lower than that of fresh transfers. This is due to fetching source properties on Resume.

### Last Written Time preservation for Share Files

There is currently a bug where Last Written Time is not preserved for Share Files.
