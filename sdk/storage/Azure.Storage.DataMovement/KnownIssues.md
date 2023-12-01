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
