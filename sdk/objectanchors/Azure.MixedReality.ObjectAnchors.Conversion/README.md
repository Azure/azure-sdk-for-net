# Azure Object Anchors client library for .NET

Azure Object Anchors enables an application to detect an object in the physical world using a 3D model and estimate its 6-DoF pose. This package supports the conversion of an existing 3D asset into a form that can be used by the Object Anchors runtime to detect physical objects.

[Source code](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/objectanchors/Azure.MixedReality.ObjectAnchors.Conversion/src) | [Package (NuGet)](https://www.nuget.org/packages/Azure.MixedReality.ObjectAnchors.Conversion/)

- [Azure Object Anchors client library for .NET](#azure-object-anchors-client-library-for-net)
  - [Getting started](#getting-started)
    - [Install the package](#install-the-package)
    - [Prerequisites](#prerequisites)
    - [Authenticate the client](#authenticate-the-client)
  - [Key concepts](#key-concepts)
    - [ObjectAnchorsConversionClient](#objectanchorsconversionclient)
  - [Examples](#examples)
    - [Upload an asset for Object Anchors asset conversion](#upload-an-asset-for-object-anchors-asset-conversion)
    - [Start 3D asset conversion](#start-3d-asset-conversion)
    - [Poll an existing ObjectAnchors asset conversion until completion and download the result](#poll-an-existing-objectanchors-asset-conversion-until-completion-and-download-the-result)
  - [Troubleshooting](#troubleshooting)
  - [Next steps](#next-steps)
  - [Contributing](#contributing)

## Getting started

### Install the package

Install the Azure Object Anchors client library for .NET with [NuGet](https://www.nuget.org/):

```dotnetcli
dotnet add package Azure.MixedReality.ObjectAnchors.Conversion --prerelease
```

Add a package reference:

```xml
<PackageReference Include="Azure.MixedReality.ObjectAnchors.Conversion" Version="0.1.0-beta.0" />
```

### Prerequisites

- You must have an [Azure subscription](https://azure.microsoft.com/free/dotnet/).
- You must have an [Azure Object Anchors](https://review.learn.microsoft.com/azure/object-anchors/) account.

### Authenticate the client

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

See [here](https://learn.microsoft.com/azure/spatial-anchors/concepts/authentication) for detailed instructions and information.

## Key concepts

### ObjectAnchorsConversionClient

The `ObjectAnchorsConversionClient` is the client library used to access the Object Anchors asset conversion service. From there, a storage upload URI will be provided for users to upload their assets for conversion into a format that is usable by the Object Anchors runtime.

Assets uploaded to the Microsoft-hosted URI obtained from the client will be retained for **48 hours**.

The final converted model in Microsoft-hosted storage will be retained for **48 hours**. 

## Examples

### Upload an asset for Object Anchors asset conversion

```csharp
AzureKeyCredential credential = new AzureKeyCredential(accountKey);

ObjectAnchorsConversionClient client = new ObjectAnchorsConversionClient(accountId, accountDomain, credential);

AssetUploadUriResult uploadUriResult = await client.GetAssetUploadUriAsync();

Uri uploadedInputAssetUri = uploadUriResult.UploadUri;

BlobClient blobClient = new BlobClient(uploadedInputAssetUri);

using (FileStream fs = File.OpenRead(localFilePath))
{
  await blobClient.UploadAsync(fs);
}
```

### Start 3D asset conversion

```csharp
AssetConversionOptions assetConversionOptions = new AssetConversionOptions(uploadedInputAssetUri, AssetFileType.FromFilePath(localFilePath), assetGravity, scale);

// Or you can pass in an optional parameter DisableDetectScaleUnits if you are converting a FBX, specifying whether or not you want to disable automatic detection of the embedded scale units. 
// The detection is enabled by default.
AssetConversionOptions assetConversionOptions = new AssetConversionOptions(uploadedInputAssetUri, AssetFileType.FromFilePath(localFilePath), assetGravity, scale, disableDetectScaleUnits: true);

AssetConversionOperation operation = await client.StartAssetConversionAsync(assetConversionOptions);

Guid jobId = new Guid(operation.Id);
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

using (FileStream file = File.OpenWrite(localFileDownloadPath))
{
    await downloadInfo.Content.CopyToAsync(file);
    FileInfo fileInfo = new FileInfo(localFileDownloadPath);
}
```

## Troubleshooting

- See [Error Handling](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md#error-handling) for Azure.Identity.
- See [Logging](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md#logging) for Azure.Identity.

## Next steps

- Read the [Product documentation](https://review.learn.microsoft.com/azure/object-anchors/)

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
