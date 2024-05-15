# Azure Developer Signing client library for .NET

Azure.Developer.Signing is a fully managed end-to-end signing solution for 3rd party developers. The Azure.Developer.Signing client library allows you to easily sign your bits without the hassle of managing certificate lifetimes.

Use the client library for Azure Developer Signing to:

* [Perform Signing of bits](https://docs.microsoft.com/azure)
* [Access Signing information](https://docs.microsoft.com/azure)

[Source code][source_root] | [Package (NuGet)][package] | [API reference documentation][reference_docs] | [Product documentation][azconfig_docs] | [Samples][source_samples]

  [Source code](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/trustedsigning/Azure.Developer.Signing/src) | [Package (NuGet)](https://www.nuget.org/packages) | [API reference documentation](https://azure.github.io/azure-sdk-for-net) | [Product documentation](https://docs.microsoft.com/azure)

## Getting started

### Install the package

Install the client library for .NET with [NuGet](https://www.nuget.org/ ):

```dotnetcli
dotnet add package Azure.Developer.Signing --prerelease
```

### Prerequisites

You must have an [Azure subscription](https://azure.microsoft.com/free/dotnet/). It is recommended that you compile using the latest [.NET SDK](https://dotnet.microsoft.com/download) 6.0 or higher with a [language version](https://docs.microsoft.com/dotnet/csharp/language-reference/configure-language-version#override-a-default) of `latest`.

To have the capability to perform signing actions a Signing Account, Certificate Profile and Identity Validation must be created. These resources can be created using the Azure portal or the Azure CLI.

### Authenticate the client

To access the client, you can use the [Token Credential authentication](https://learn.microsoft.com/dotnet/api/azure.core.tokencredential) method provided by Standard Azure Active Directory. The identity interacting with the resource must have the role of `Code Signing Certificate Profile Signer` on the resource. These roles need to be assigned from the Azure portal or by using the Azure CLI.

To use Entra ID authentication, add the Azure Identity package:

`dotnet add package Azure.Identity`

You will also need to register a new AAD application, or run locally or in an environment with a managed identity. If using an application, set the values of the client ID, tenant ID, and client secret of the AAD application as environment variables: AZURE_CLIENT_ID, AZURE_TENANT_ID, AZURE_CLIENT_SECRET.

## Key concepts

This library interacts with the Azure Developer Signing service using two principal concepts, these are:

- `Trusted Signing Accounts` – A Signing Account is the logical container holding certificate profiles and identity validations and is considered a Azure Developer Signing resource.
- `Certificate Profile` – A Certificate Profile is the template with the information that is used in the issued certificates. It is a sub-resource to a Code Signing Account resource.
- `Identity Validation` - An Identity Validation resource is the identity of the legal business or individual. This information will be in the Subject Name of the certificates and therefore is a pre-requisite resource to be able to create a Certificate Profile.

Since the interaction of the client is at the certificate profile level, the client is designed to interact with this entity. A region must be provided to ensure the request is routed to the specific appropiate environment.

```C# Snippet:Azure_Developer_Signing_CreateCertificateProfileClient
var credential = new DefaultAzureCredential();
CertificateProfile certificateProfileClient = new SigningClient(credential).GetCertificateProfileClient(region);
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

You can familiarize yourself with different APIs using [Samples](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/trustedsigning/Azure.Developer.Signing/samples).

### Signing bytes

Sign the digest corresponding to a file using an algorithm.

```C# Snippet:Azure_Developer_Signing_SigningBytes
CertificateProfile certificateProfileClient = new SigningClient(credential).GetCertificateProfileClient(region);

using RequestContent content = RequestContent.Create(new
{
    signatureAlgorithm,
    digest,
});

Operation<BinaryData> operation = certificateProfileClient.Sign(WaitUntil.Completed, accountName, profileName, content);
BinaryData responseData = operation.Value;

JsonElement result = JsonDocument.Parse(responseData.ToStream()).RootElement;
```

### List available customer extended key usages (EKUs)

Request all the available customer extended key usages from a certificate profile.

```C# Snippet:Azure_Developer_Signing_GetExtendedKeyUsages
CertificateProfile certificateProfileClient = new SigningClient(credential).GetCertificateProfileClient(region);

List<string> ekus = new();

foreach (BinaryData item in certificateProfileClient.GetExtendedKeyUsages(accountName, profileName, null))
{
    JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
    string eku = result.GetProperty("eku").ToString();

    ekus.Add(eku);
}
```

### Download the root certificate

Request the sign root certificate from a certificate profile.

```C# Snippet:Azure_Developer_Signing_GetSignRootCertificate
CertificateProfile certificateProfileClient = new SigningClient(credential).GetCertificateProfileClient(region);

Response<BinaryData> response = certificateProfileClient.GetSignRootCertificate(accountName, profileName);

byte[] rootCertificate = response.Value.ToArray();
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
[developersigning_contrib]: https://github.com/Azure/azure-sdk-for-net/blob/main/CONTRIBUTING.md
[style-guide-msft]: https://docs.microsoft.com/style-guide/capitalization
[style-guide-cloud]: https://aka.ms/azsdk/cloud-style-guide
[cla]: https://cla.microsoft.com
[code_of_conduct]: https://opensource.microsoft.com/codeofconduct/
[code_of_conduct_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[email_opencode]: mailto:opencode@microsoft.com

![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net/sdk/trustedsigning/Azure.Developer.Signing/README.png)

## Next steps

For more information on Azure SDK, please refer to [this website](https://azure.github.io/azure-sdk/)

![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net%2Fsdk%2Ftrustedsigning%2FAzure.Developer.Signing%2FREADME.png)
