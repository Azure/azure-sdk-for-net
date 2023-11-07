# Known Issues

Azure.Storage.DataMovement is still in beta. Not all functionality is currently implemented, and there are known issues that may cause problems for your application. Significant known issues are documented below

## Preserving properties and metadata on copy

When copying data between blobs, blob properties and blob metadata are not preserved. There is currently no support for this feature; properties and metadata can only be defined by the caller to be applied uniformly to each destination blob.

This limitation also exists for share files and directories.

### Client-side encryption support

**There is no support for copying client-side encrypted blobs.** Since client-side encryption is built on blob metadata, the necessary information to decrypt the blob will not be transferred in a service-to-service copy. Azure.Storage.Blobs will not be able to decrypt the copied blob. If that metadata is lost, your blob contents will be lost forever.
