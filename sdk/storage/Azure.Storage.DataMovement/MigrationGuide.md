# Migration Guide: From Microsoft.Azure.Storage.DataMovement to Azure.Storage.DataMovement

This guide intends to assist customers in migrating from version 2 of the Azure Storage .NET Data Movement library to version 12.
It will focus on side-by-side comparisons for similar operations between the v12 package, [`Azure.Storage.Blobs`](https://www.nuget.org/packages/Azure.Storage.Blobs) and v11 package, [`Microsoft.Azure.Storage.Blob`](https://www.nuget.org/packages/Microsoft.Azure.Storage.Blob/).

Familiarity with the legacy data movement client library is assumed. For those new to the Azure Storage Data Movement client library for .NET, please refer to the [Quickstart](TODO) for the v12 library rather than this guide.

## Table of contents

- [Migration benefits](#migration-benefits)
- [General changes](#general-changes)
  - [Package and namespaces](#package-and-namespaces)
  - [Authentication](#authentication)
  - [Type structure](#type-structure)
- [Migration samples](#migration-samples)
- [Additional information](#additional-information)

## Migration benefits

Version 12 of the Data Movemenet library inherits all the benefits of the 12 storage client libraries, detailed in the next section. In addition, the following are benefits of the new design:

TODO

### Core client libraries

To understand why we created our version 12 client libraries, you may refer to the Tech Community blog post, [Announcing the Azure Storage v12 Client Libraries](https://techcommunity.microsoft.com/t5/azure-storage/announcing-the-azure-storage-v12-client-libraries/ba-p/1482394) or refer to our video [Introducing the New Azure SDKs](https://aka.ms/azsdk/intro).

Included are the following:
- Thread-safe synchronous and asynchronous APIs
- Improved performance
- Consistent and idiomatic code organization, naming, and API structure, aligned with a set of common guidelines
- The learning curve associated with the libraries was reduced

Note: The blog post linked above announces deprecation for previous versions of the library.

## General changes

### Package and namespaces

Package names and the namespaces root for version 12 Azure client libraries follow the pattern `Azure.[Area].[Service]` where the legacy libraries followed the pattern `Microsoft.Azure.[Area].[Service]`.

In this case, the legacy package was installed with:
```
dotnet add package Microsoft.Azure.Storage.Blob
```

While version 12 is now installed with:
```
dotnet add package Azure.Storage.DataMovement
dotnet add package Azure.Storage.DataMovement.Blobs
```

Note the separation of the Data Movement package from the Blob Storage Data Movement package. Packages to other storage services can be added or removed from your installation.

### Authentication

#### Azure Active Directory

TODO

You can view more [Identity samples](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/identity/Azure.Identity#examples) for how to authenticate with the Identity package.

#### SAS

TODO

#### Shared Key

TODO

### Type Structure

TODO TransferManager changes

TODO StorageResource, Container and Item

TODO Providers

## Migration Samples

TODO
- Upload
- Download
- S2S
- Progress reporting
- Error reporting
- Pause/Resume

## Additional information

### Links and references
- [Quickstart](TODO)
- [Samples](TODO)
- [DataMovement reference](TODO)
- [Announcing the Azure Storage v12 Client Libraries](https://techcommunity.microsoft.com/t5/azure-storage/announcing-the-azure-storage-v12-client-libraries/ba-p/1482394) blog post
