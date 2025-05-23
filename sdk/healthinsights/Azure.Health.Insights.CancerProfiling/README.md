# Azure Cognitive Services Health Insights Cancer Profiling client library for .NET

[Health Insights][health_insights] is an Azure Applied AI Service built with the Azure Cognitive Services Framework, that leverages multiple Cognitive Services, Healthcare API services and other Azure resources.

The [Cancer Profiling model][cancer_profiling_docs] receives clinical records of oncology patients and outputs cancer staging, such as clinical stage TNM categories and pathologic stage TNM categories as well as tumor site, histology.

[Source code][cancer_profiling_client_src] | [Package (NuGet)][cancer_profiling_client_nuget_package] | [API reference documentation][cancer_profiling_api_documentation] | [Product documentation][product_docs]


## Getting started

### Prerequisites

- You need an [Azure subscription][azure_sub] to use this package.
- An existing Cognitive Services Health Insights instance.

### Install the package

Install the Azure Health Insights client Cancer Profiling library for .NET with [NuGet][nuget]:

```dotnetcli
dotnet add package Azure.Health.Insights.CancerProfiling --prerelease
```

This table shows the relationship between SDK versions and supported API versions of the service:

|SDK version|Supported API version of service |
|-------------|---------------|
|1.0.0-beta.1 | 2023-03-01-preview|

### Authenticate the client

You can find the endpoint for your Health Insights service resource using the [Azure Portal][azure_portal] or [Azure CLI][azure_cli]

```bash
# Get the endpoint for the Health Insights service resource
az cognitiveservices account show --name "resource-name" --resource-group "resource-group-name" --query "properties.endpoint"
```

#### Get the API Key

You can get the **API Key** from the Health Insights service resource in the Azure Portal.
Alternatively, you can use **Azure CLI** snippet below to get the API key of your resource.

```PowerShell
az cognitiveservices account keys list --resource-group <your-resource-group-name> --name <your-resource-name>
```

#### Create CancerProfilingClient with AzureKeyCredential

Once you have the value for the API key, create an `AzureKeyCredential`.  With the endpoint and key credential, you can create the [`CancerProfilingClient`][cancer_profiling_client_class]:

```C#
string endpoint = "<endpoint>";
string apiKey = "<apiKey>";
var credential = new AzureKeyCredential(apiKey);
var client = new CancerProfilingClient(new Uri(endpoint), credential);
```

## Key concepts
The Cancer Profiling model allows you to infer cancer attributes such as tumor site, histology, clinical stage TNM categories and pathologic stage TNM categories from unstructured clinical documents.

## Examples

- [Infer Cancer Profiling][samples_location]

### Cancer Profiling

```C# Snippet:HealthInsightsCancerProfilingClientInferCancerProfileAsync
OncoPhenotypeResults oncoResults = default;
try
{
    Operation<OncoPhenotypeResults> operation = await client.InferCancerProfileAsync(WaitUntil.Completed, oncoPhenotypeData);
    oncoResults = operation.Value;
}
catch (Exception ex)
{
    Console.WriteLine(ex.ToString());
    return;
}
```
```C# Snippet:HealthInsightsCancerProfilingInferCancerProfileAsyncViewResults
// View operation results
foreach (OncoPhenotypePatientResult patientResult in oncoResults.Patients)
{
    Console.WriteLine($"\n==== Inferences of Patient {patientResult.Id} ====");
    foreach (OncoPhenotypeInference oncoInference in patientResult.Inferences)
    {
        Console.WriteLine($"\n=== Clinical Type: {oncoInference.Type.ToString()}  Value: {oncoInference.Value}   ConfidenceScore: {oncoInference.ConfidenceScore} ===");
        foreach (InferenceEvidence evidence in oncoInference.Evidence)
        {
            if (evidence.PatientDataEvidence != null)
            {
                var dataEvidence = evidence.PatientDataEvidence;
                Console.WriteLine($"Evidence {dataEvidence.Id} {dataEvidence.Offset} {dataEvidence.Length} {dataEvidence.Text}");
            }
            if (evidence.PatientInfoEvidence != null)
            {
                var infoEvidence = evidence.PatientInfoEvidence;
                Console.WriteLine($"Evidence {infoEvidence.System} {infoEvidence.Code} {infoEvidence.Name} {infoEvidence.Value}");
            }
        }
    }
}
```

## Troubleshooting

### Setting up console logging

The simplest way to see the logs is to enable the console logging.
To create an Azure SDK log listener that outputs messages to console use the AzureEventSourceListener.CreateConsoleLogger method.

```C#
// Setup a listener to monitor logged events.
using AzureEventSourceListener listener = AzureEventSourceListener.CreateConsoleLogger();
```

To learn more about other logging mechanisms see [Diagnostics Samples][logging].

## Next steps

## Additional documentation

For more extensive documentation on Azure Health Insights Cancer Profiling, see the [Cancer Profiling documentation][cancer_profiling_docs] on learn.microsoft.com.

## Contributing

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit [cla.microsoft.com][cla].

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (e.g., label, comment). Simply follow the instructions provided by the bot. You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct][code_of_conduct]. For more information see the [Code of Conduct FAQ][coc_faq] or contact [opencode@microsoft.com][coc_contact] with any additional questions or comments.

<!-- LINKS -->
[health_insights]: https://learn.microsoft.com/azure/azure-health-insights/overview
[cancer_profiling_client_src]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/healthinsights/Azure.Health.Insights.CancerProfiling/src/
[cancer_profiling_client_nuget_package]: https://www.nuget.org/packages/Azure.Health.Insights.CancerProfiling/
[cancer_profiling_api_documentation]: https://learn.microsoft.com/rest/api/cognitiveservices/healthinsights/onco-phenotype
[cancer_profiling_client_class]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/healthinsights/Azure.Health.Insights.CancerProfiling/src/Generated/CancerProfilingClient.cs
[samples_location]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/healthinsights/Azure.Health.Insights.CancerProfiling/samples
[logging]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/core/Azure.Core/samples/Diagnostics.md
[azure_cli]: https://learn.microsoft.com/cli/azure
[azure_sub]: https://azure.microsoft.com/free/dotnet/
[nuget]: https://www.nuget.org/
[azure_portal]: https://ms.portal.azure.com/#create/Microsoft.CognitiveServicesHealthInsights
[cla]: https://cla.microsoft.com
[code_of_conduct]: https://opensource.microsoft.com/codeofconduct/
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[coc_contact]: mailto:opencode@microsoft.com
[cancer_profiling_docs]: https://learn.microsoft.com/azure/azure-health-insights/oncophenotype/overview
[product_docs]:https://learn.microsoft.com/azure/azure-health-insights/oncophenotype/
