# Azure Object Anchors client library for .NET

Azure Object Anchors enables an application to detect an object in the physical world using a 3D model and estimate its 6-DoF pose. This package supports the conversion of an existing 3D asset into a form that can be used by the Object Anchors runtime to detect physical objects.

[Source code](https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/mixedreality/Azure.MixedReality.ObjectAnchors) | NuGet

- [Azure Object Anchors client library for .NET](#azure-object-anchors-client-library-for-net)
  - [Getting started](#getting-started)
    - [Install the package](#install-the-package)
    - [Prerequisites](#prerequisites)
    - [Construct and authenticate the client](#construct-and-authenticate-the-client)
  - [Key concepts](#key-concepts)
    - [ObjectAnchorsClient](#ObjectAnchorsClient)
  - [Examples](#examples)
    - [Upload an asset for Object Anchors asset conversion](#upload-an-asset-for-object-anchors-asset-conversion)
    - [Begin Object Anchors asset conversion after uploading an asset](#begin-object-anchors-asset-conversion-after-uploading-an-asset)
    - [Poll an existing ObjectAnchors asset conversion until completion and download the result](#poll-an-existing-objectanchors-asset-conversion-until-completion-and-download-the-result)
  - [Troubleshooting](#troubleshooting)
  - [Contributing](#contributing)

## Getting started

### Install the package

Install the Azure Object Anchors client library for .NET using one of the following methods.

From Visual Studio Package Manager:

```powershell
Install-Package Azure.MixedReality.ObjectAnchors
```

From .NET CLI

```dotnetcli
dotnet add package Azure.MixedReality.ObjectAnchors
```

Add a package reference:

```xml
<PackageReference Include="Azure.MixedReality.ObjectAnchors" Version="0.1.0-beta.0" />
```

### Prerequisites

- You must have an [Azure subscription](https://azure.microsoft.com/free/).
- You must have an [Azure Object Anchors](https://review.docs.microsoft.com/azure/object-anchors/) account.

### Construct and authenticate the client

Mixed Reality services support a few different forms of authentication:

- Account Key authentication
  - Account keys enable you to get started quickly with using Mixed Reality services. But before you deploy your application
    to production, we recommend that you update your app to use Azure AD authentication.
- Azure Active Directory (AD) token authentication
  - If you're building an enterprise application and your company is using Azure AD as its identity system, you can use
    user-based Azure AD authentication in your app. You then grant access to your Object Anchors account by using your
    existing Azure AD security groups. You can also grant access directly to users in your organization.
  - Otherwise, we recommend that you obtain Azure AD tokens from a web service that supports your app. We recommend this
    method for production applications because it allows you to avoid embedding the credentials for access to the Object Anchors asset conversion service in your client application.

See [here](https://docs.microsoft.com/azure/spatial-anchors/concepts/authentication) for detailed instructions and information.

## Key concepts

### ObjectAnchorsClient

The `ObjectAnchorsClient` is the client library used to access the Object Anchors asset conversion service. From there, a storage upload URI will be provided for users to upload their assets for conversion into a format that is usable by the Object Anchors runtime.

Assets uploaded to the Microsoft-hosted URI obtained from the client will be retained for **48 hours**.

The final converted model in Microsoft-hosted storage will be retained for **48 hours**. 

## Examples

### Upload an asset for Object Anchors asset conversion

```csharp
TokenCredential credential = new DefaultAzureCredential(true);

ObjectAnchorsClient client = new ObjectAnchorsClient(account, credential);

Uri uploadedInputAssetUri = (await client.GetAssetUploadUriAsync()).Value.InputAssetUploadUri;

BlobClient blobClient = new BlobClient(uploadedInputAssetUri);

using (FileStream fs = File.OpenRead(localFilePath))
{
  await blobClient.UploadAsync(fs);
}
```

### Begin Object Anchors asset conversion after uploading an asset

```csharp
StartAssetConversionOptions ingestionJobOptions = new StartAssetConversionOptions(uploadedInputAssetUri, AssetFileType.FromFilePath(localFilePath), assetGravity, scale);

AssetConversionOperation operation = await client.StartAssetConversionAsync(ingestionJobOptions);

Guid operationId = new Guid(operation.Id);
```

### Poll an existing ObjectAnchors asset conversion until completion and download the result

```csharp
AssetConversionOperation operation = new AssetConversionOperation(assetConversionJobId, client);

await operation.WaitForCompletionAsync();

if (!operation.HasCompletedSuccessfully)
{
  throw new Exception("The asset conversion operation completed with an unsuccessful status");
}

BlobClient blobClient = new BlobClient(operation.Value.OutputModelUri);

BlobDownloadInfo downloadInfo = await blobClient.DownloadAsync();
```

## Troubleshooting

- See [Error Handling](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/identity/Azure.Identity/README.md#error-handling) for Azure.Identity.
- See [Logging](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/identity/Azure.Identity/README.md#logging) for Azure.Identity.

## Contributing

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License
Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution.
For details, visit [https://cla.microsoft.com](https://cla.microsoft.com).

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the
PR appropriately (e.g., label, comment). Simply follow the instructions provided by the bot. You will only need to do this
once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/).
For more information see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or contact
[opencode@microsoft.com](mailto:opencode@microsoft.com) with any additional questions or comments.
