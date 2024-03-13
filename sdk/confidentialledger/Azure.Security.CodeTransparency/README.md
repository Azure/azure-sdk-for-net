# Azure Code Transparency client library for .NET

<!-- cspell:ignore cose merkle scitt -->

`Azure.Security.CodeTransparency` is based on a managed service complying with a [draft SCITT RFC][SCITT_ARCHITECTURE_RFC]. It is a managed service that allows countersigning [COSE signature envelopes][COSE_RFC]. Countersignatures are recorded and signed in the immutable merkle tree for any auditing purposes and [the receipt][SCITT_RECEIPT_RFC] gets issued.

- [OSS server application source code][Service_source_code]

## Getting started

### Install the package

Make sure you have access to the correct Nuget Feed.

Install the client library for .NET with [NuGet](https://www.nuget.org/ ):

```dotnetcli
dotnet add package Azure.Security.CodeTransparency --prerelease
```

### Prerequisites

- A running and accessible Code Transparency Service
- Ability to create `COSE_Sign1` envelopes, [an example script][CTS_claim_generator_script]
- Your signer details (CA cert or DID issuer) have to be configured in the running service, [about available configuration][CTS_configuration_doc]
- You can get a valid Bearer token if the service authentication is configured to require one, [see example](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/confidentialledger/Azure.Security.CodeTransparency/samples/Sample3_UseYourCredentials.md)

### Thread safety

We guarantee that all client instance methods are thread-safe and independent of each other ([guideline](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-service-methods-thread-safety)). This ensures that the recommendation of reusing client instances is always safe, even across threads.

### Authenticate the client

You can get a valid Bearer token if the service authentication is configured to require one, [see example](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/confidentialledger/Azure.Security.CodeTransparency/samples/Sample3_UseYourCredentials.md).

## Examples

You can familiarize yourself with different APIs by observing our [samples](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/confidentialledger/Azure.Security.CodeTransparency/samples).

### Key concepts

<!-- CLIENT COMMON BAR -->
[Client options](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#configuring-service-clients-using-clientoptions) |
[Accessing the response](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#accessing-http-response-details-using-responset) |
[Long-running operations](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#consuming-long-running-operations-using-operationt) |
[Handling failures](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#reporting-errors-requestfailedexception) |
[Diagnostics](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Diagnostics.md) |
[Mocking](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#mocking) |
[Client lifetime](https://devblogs.microsoft.com/azure-sdk/lifetime-management-and-thread-safety-guarantees-of-azure-sdk-net-clients/)
<!-- CLIENT COMMON BAR -->

## Troubleshooting

Response values returned from Azure confidential ledger client methods are `Response` objects, which contain information about the http response such as the http `Status` property and a `Headers` object containing more information about the failure.

## Next steps

For more extensive documentation, see the API [reference documentation](https://azure.github.io/azure-sdk-for-net/).
You may also read more about Microsoft Research's open-source [Confidential Consortium Framework][ccf].

## Contributing

This project welcomes contributions and suggestions.  Most contributions require
you to agree to a Contributor License Agreement (CLA) declaring that you have
the right to, and actually do, grant us the rights to use your contribution. For
details, visit [cla.microsoft.com][cla].

This project has adopted the [Microsoft Open Source Code of Conduct][coc].
For more information see the [Code of Conduct FAQ][coc_faq] or contact
[opencode@microsoft.com][coc_contact] with any additional questions or comments.

Working with the source code of this library. The following just builds on the existing documentation to make it more convenient.

### (Re)Generating the code

The code is generated from the Typespec, this is not specific to the current package. If you need to change anything in the generated code directory you will first need to update the Typespec first.

- Clone the repo containing the typespec: `git clone git@github.com:Azure/azure-rest-api-specs.git`
- Clone this repository: `git clone git@github.com:Azure/azure-sdk-for-net.git`
- Get into the directory that contains the typespec: `cd azure-rest-api-specs/specification/confidentialledger/Microsoft.CodeTransparency/`
- From within the Typespec directory regenerate the SDK by invoking a Powershell helper script and providing a path to the cloned SDK repository:

    ```sh
    pwsh ../../../eng/scripts/TypeSpec-Generate-Sdk.ps1 -SdkRepoRootDirectory ~/azure-sdk-for-net/
    ```

### Tests

#### Running the tests

From the root of this repository run:

```
dotnet test eng/service.proj /p:ServiceDirectory=confidentialledger /p:Project=Azure.Security.CodeTransparency
```

It is also possible to pass [additional flters](https://learn.microsoft.com/dotnet/core/testing/selective-unit-tests?pivots=nunit), e.g.:

```
dotnet test eng/service.proj /p:ServiceDirectory=confidentialledger /p:Project=Azure.Security.CodeTransparency --filter TestCategory!=Live

dotnet test eng/service.proj /p:ServiceDirectory=confidentialledger /p:Project=Azure.Security.CodeTransparency --filter Name~CreateEntryAsync
```

#### Adding new tests

The framework supports different types of tests: unit, live, recorded, more in the docs 
https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core.TestFramework/README.md

<!-- LINKS -->
[COSE_RFC]: https://www.rfc-editor.org/rfc/rfc8152.txt
[SCITT_ARCHITECTURE_RFC]: https://www.ietf.org/archive/id/draft-ietf-scitt-architecture-01.txt
[SCITT_RECEIPT_RFC]: https://www.ietf.org/archive/id/draft-birkholz-scitt-receipts-03.txt
[API_reference]: https://learn.microsoft.com/dotnet/api/azure.security.keyvault.keys
[Service_source_code]: https://github.com/microsoft/scitt-ccf-ledger
[CTS_claim_generator_script]: https://github.com/microsoft/scitt-ccf-ledger/tree/main/demo/cts_poc
[CTS_configuration_doc]: https://github.com/microsoft/scitt-ccf-ledger/blob/main/docs/configuration.md
[ccf]: https://github.com/Microsoft/CCF

![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net%2Fsdk%2Fconfidentialledger%2FAzure.Security.CodeTransparency%2FREADME.png)