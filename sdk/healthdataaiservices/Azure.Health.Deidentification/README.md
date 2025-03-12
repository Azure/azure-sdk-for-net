# Azure Health.Deidentification client library for .NET

Azure.Health.Deidentification is a managed service that enables users to tag, redact, or surrogate health data.


<!-- TODO Add operation links once docs are generated -->

[Source code](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/healthdataaiservices/Azure.Health.Deidentification/src) | [Package (NuGet)](https://www.nuget.org/packages) | [API reference documentation](https://azure.github.io/azure-sdk-for-net) | [Product documentation](https://learn.microsoft.com/azure) | [Samples](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/healthdataaiservices/Azure.Health.Deidentification/samples)

## Getting started


### Install the package

Install the client library for .NET with [NuGet](https://www.nuget.org/ ):

```dotnetcli
dotnet add package Azure.Health.Deidentification
```

### Prerequisites

> You must have an `Azure subscription` and `Deid Service`.

### Authenticate the client

Pull `ServiceUrl` from your created Deidentification Service.

![Service Url Location](docs/images/ServiceUrl_Location.png)

Basic code snippet to create your Deidentification Client and Deidentify a string.

```cs
        const string serviceEndpoint = "https://example.api.cac001.deid.azure.com";
        TokenCredential credential = new DefaultAzureCredential();

        DeidentificationClient client = new(
            new Uri(serviceEndpoint),
            credential,
            new DeidentificationClientOptions()
        );

        DeidentificationContent content = new("Hello, John!");

        Response<DeidentificationResult> result = client.DeidentifyText(content);
        string outputString = result.Value.OutputText;
        Console.WriteLine(outputString); // Hello, Tom!
```

## Key concepts

**Operation Modes**
- Tag: Will return a structure of offset and length with the PHI category of the related text spans.
- Redact: Will return output text with placeholder stubbed text. ex. `[name]`
- Surrogate: Will return output text with synthetic replacements.
  - `My name is John Smith`
  - `My name is Tom Jones`

**Job Integration with Azure Storage**
Instead of sending text, you can send an Azure Storage Location to the service. We will asynchronously
process the list of files and output the deidentified files to a location of your choice.

Limitations:
- Maximum file count per job: 1000 documents
- Maximum file size per file: 2 MB

**Redaction Formatting**

[Redaction formatting guide](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/healthdataaiservices/Azure.Health.Deidentification/docs/HowTo-RedactionFormatting.md)

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

You can familiarize yourself with different APIs using [Samples](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/healthdataaiservices/Azure.Health.Deidentification/samples).

## Next steps

- Find a bug, or have feedback? Raise an issue with "Health Deidentification" Label.


## Troubleshooting

- **Unabled to Access Source or Target Storage**
  - Ensure you create your deid service with a system assigned managed identity
  - Ensure your storage account has given permissions to that managed identity

## Contributing

This project welcomes contributions and suggestions. Most contributions require
you to agree to a Contributor License Agreement (CLA) declaring that you have
the right to, and actually do, grant us the rights to use your contribution.
For details, visit https://cla.microsoft.com.

When you submit a pull request, a CLA-bot will automatically determine whether
you need to provide a CLA and decorate the PR appropriately (e.g., label,
comment). Simply follow the instructions provided by the bot. You will only
need to do this once across all repos using our CLA.

This project has adopted the
[Microsoft Open Source Code of Conduct][code_of_conduct]. For more information,
see the Code of Conduct FAQ or contact opencode@microsoft.com with any
additional questions or comments.

<!-- LINKS -->
[code_of_conduct]: https://opensource.microsoft.com/codeofconduct/
[style-guide-msft]: https://learn.microsoft.com/style-guide/capitalization
[style-guide-cloud]: https://aka.ms/azsdk/cloud-style-guide
