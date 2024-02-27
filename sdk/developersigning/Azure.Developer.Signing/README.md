# Azure.Developer.Signing client library for .NET

Azure.Developer.Signing is a managed service that simplifies the signing process for developers, making it more accessible to all.

Use the client library for Azure Developer Signing to:

* [Perform Signing of bits](https://docs.microsoft.com/azure)
* [Access Signing information](https://docs.microsoft.com/azure)

[Source code][source_root] | [Package (NuGet)][package] | [API reference documentation][reference_docs] | [Product documentation][azconfig_docs] | [Samples][source_samples]

  [Source code](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/developer-signing/Azure.Developer.Signing/src) | [Package (NuGet)](https://www.nuget.org/packages) | [API reference documentation](https://azure.github.io/azure-sdk-for-net) | [Product documentation](https://docs.microsoft.com/azure)

## Getting started

### Install the package

Install the client library for .NET with [NuGet](https://www.nuget.org/ ):

```dotnetcli
dotnet add package Azure.Developer.Signing --prerelease
```

### Prerequisites

You must have an [Azure subscription](https://azure.microsoft.com/free/dotnet/). In order to take advantage of the C# 8.0 syntax, it is recommended that you compile using the [.NET Core SDK](https://dotnet.microsoft.com/download) 6.0 or higher with a [language version](https://docs.microsoft.com/dotnet/csharp/language-reference/configure-language-version#override-a-default) of `latest`.  It is also possible to compile with the .NET Core SDK 2.1.x using a language version of `preview`.

### Authenticate the client

To access the client, you can use the [Token Credential authentication](https://learn.microsoft.com/dotnet/api/azure.core.tokencredential) method provided by Standard Azure Active Directory. The identity interacting with the resource must have the role of `Code Signing Certificate Profile Signer` on the resource. These roles need to be assigned from the Azure portal or by using the Azure CLI.

To use Azure Active Directory authentication, add the Azure Identity package:

`dotnet add package Azure.Identity`

You will also need to register a new AAD application, or run locally or in an environment with a managed identity. If using an application, set the values of the client ID, tenant ID, and client secret of the AAD application as environment variables: AZURE_CLIENT_ID, AZURE_TENANT_ID, AZURE_CLIENT_SECRET.

## Key concepts

This library interacts with the Azure Developer Signing service using two principal concepts, these are:

- `Code Signing Accounts` – Logical container holding certificate profiles and considered the Azure Developer Signing resource.
- `Certificate Profile` – Template with the information that is used in the issued certificates, and a sub-resource to a Code Signing Account resource.

Since the interaction of the client is at the certificate profile level, the client is designed to interact with this entity.

```C# Snippet:Azure_Developer_Signing_CreateCertificateProfileClient_Scenario
    var credential = new DefaultAzureCredential();
    var certificateProfileClient = new SigningClient(credential).GetCertificateProfileClient(region);
```

### Thread safety

We guarantee that all client instance methods are thread-safe and independent of each other ([guideline](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-service-methods-thread-safety)). This ensures that the recommendation of reusing client instances is always safe, even across threads.

### Additional concepts
<!-- CLIENT COMMON BAR -->
[Client options](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#configuring-service-clients-using-clientoptions) |
[Accessing the response](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#accessing-http-response-details-using-responset) |
[Long-running operations](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#consuming-long-running-operations-using-operationt) |
[Handling failures](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#reporting-errors-requestfailedexception) |
[Diagnostics](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Diagnostics.md) |
[Mocking](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#mocking) |
[Client lifetime](https://devblogs.microsoft.com/azure-sdk/lifetime-management-and-thread-safety-guarantees-of-azure-sdk-net-clients/)
<!-- CLIENT COMMON BAR -->

## Examples

You can familiarize yourself with different APIs using [Samples](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/developer-signing/Azure.Developer.Signing/samples).

### Sign bits

```C# Snippet:Azure_Developer_Signing_SigningASampleFile
    var credential = new DefaultAzureCredential();
    var signClient = new SigningClient(credential);
    var CertificatProfileClient = signClient.GetCertificateProfileClient(region);
    //Add Signing here...
```

### List Available customer EKUs

```C# Snippet:Azure_Developer_Signing_ListAvailableCustomerEKUs
    var credential = new DefaultAzureCredential();
    var signClient = new SigningClient(credential);
    var CertificatProfileClient = signClient.GetCertificateProfileClient(region);
    //List Available customer EKUs here...
```

### Download Root Certificate

```C# Snippet:Azure_Developer_Signing_GetRootCertificate
    var credential = new DefaultAzureCredential();
    var signClient = new SigningClient(credential);
    var CertificatProfileClient = signClient.GetCertificateProfileClient(region);
    //Get Root Certificate here...
```

## Troubleshooting

Errors may occur during the Signing Action due to problems with Azure resources or your Azure configuration. You can view the `errorDetails` property on the SignResult if the signing action fails, it will show more information about the problem and how to resolve it.

Ensure that your client has the correct permissions to perform the action you are trying to perform. For example, if you are trying to sign a file, ensure that your client has the `Code Signing Certificate Profile Signer` role on the resource.

## Contributing

See the [DeveloperSigning CONTRIBUTING.md][developersigning_contrib] for details on building, testing, and contributing to this library.

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit [cla.microsoft.com][cla].

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (e.g., label, comment). Simply follow the instructions provided by the bot. You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct][code_of_conduct]. For more information see the [Code of Conduct FAQ][code_of_conduct_faq] or contact [opencode@microsoft.com][email_opencode] with any additional questions or comments.

<!-- LINKS -->
[developersigning_contrib]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/developersigning/CONTRIBUTING.md
[style-guide-msft]: https://docs.microsoft.com/style-guide/capitalization
[style-guide-cloud]: https://aka.ms/azsdk/cloud-style-guide
[cla]: https://cla.microsoft.com
[code_of_conduct]: https://opensource.microsoft.com/codeofconduct/
[code_of_conduct_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[email_opencode]: mailto:opencode@microsoft.com

![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net/sdk/developer-signing/Azure.Developer.Signing/README.png)

## Next steps

For more information on Azure SDK, please refer to [this website](https://azure.github.io/azure-sdk/)
