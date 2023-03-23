# Azure Cognitive Services Health Insights Cancer Profiling client library for .NET

<!-- [Health Insights](https://review.learn.microsoft.com/en-us/azure/cognitive-services/health-decision-support/overview?branch=main) is an Azure Applied AI Service built with the Azure Cognitive Services Framework, that leverages multiple Cognitive Services, Healthcare API services and other Azure resources.
The [Cancer Profiling model](https://review.learn.microsoft.com/en-us/azure/cognitive-services/health-decision-support/oncophenotype/overview?branch=main) receives clinical records of oncology patients and outputs cancer staging, such as clinical stage TNM categories and pathologic stage TNM categories as well as tumor site, histology. -->

[Health Insights] is an Azure Applied AI Service built with the Azure Cognitive Services Framework, that leverages multiple Cognitive Services, Healthcare API services and other Azure resources.
The [Cancer Profiling model] receives clinical records of oncology patients and outputs cancer staging, such as clinical stage TNM categories and pathologic stage TNM categories as well as tumor site, histology.

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
|1.0.0b1 | 2023-03-01-preview|

### Authenticate the client

You can find the endpoint for your Health Insights service resource using the
[Azure Portal](https://ms.portal.azure.com/#create/Microsoft.CognitiveServicesHealthInsights)
or [Azure CLI](https://learn.microsoft.com/cli/azure/):

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

### Long-Running Operations

For large documents which take a long time to execute, these operations are implemented as [**long-running operations**][dotnet_lro]. Long-running operations consist of an initial request sent to the service to start an operation, followed by polling the service at intervals to determine whether the operation has completed or failed, and if it has succeeded, to get the result.

For long running operations in the Azure SDK, the client exposes a `Start<operation-name>` method that returns an `Operation<T>` or a `PageableOperation<T>`.  You can use the extension method `WaitForCompletionAsync()` to wait for the operation to complete and obtain its result.  A sample code snippet is provided to illustrate using long-running operations [below](#run-multiple-actions-asynchronously).

## Key concepts
The Cancer Profiling model allows you to infer cancer attributes such as tumor site, histology, clinical stage TNM categories and pathologic stage TNM categories from unstructured clinical documents.

## Examples

- [Infer Cancer Profiling](#cancer-profiling)

### Cancer Profiling

```C# Snippet:HealthInsightsCancerProfilingClientInferCancerProfileAsync
OncoPhenotypeResult oncoPhenotypeResult = default;
try
{
    Operation<OncoPhenotypeResult> operation = await client.InferCancerProfileAsync(WaitUntil.Completed, oncoPhenotypeData);
    Response resp = operation.GetRawResponse();
    oncoPhenotypeResult = OncoPhenotypeResult.FromResponse(resp);
}
catch (Exception ex)
{
    Console.WriteLine(ex.ToString());
    return;
}
```
```C# Snippet:HealthInsightsCancerProfilingInferCancerProfileAsyncViewResults
// View operation results
if (oncoPhenotypeResult.Status == JobStatus.Succeeded)
{
    OncoPhenotypeResults oncoResults = oncoPhenotypeResult.Results;
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
}
else
{
    IReadOnlyList<ResponseError> oncoErrors = oncoPhenotypeResult.Errors;
    foreach (ResponseError error in oncoErrors)
    {
        Console.WriteLine($"{error.Code} : {error.Message}");
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

<!-- These code samples show common scenario operations with the Azure health Insights Cancer Profiling library. More samples can be found under the [samples](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/healthinsights/Azure.Health.Insights.CancerProfiling/tests/Samples/) directory.

- Infer Cancer Profile: [Sample_InferCancerProfile.cs](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/healthinsights/Azure.Health.Insights.CancerProfiling/tests/Samples/Sample_InferCancerProfile.cs) -->


### Additional documentation

<!-- For more extensive documentation on Azure Health Insights Cancer Profiling, see the [Cancer Profiling documentation](https://review.learn.microsoft.com/en-us/azure/cognitive-services/health-decision-support/oncophenotype/overview?branch=main) on docs.microsoft.com. -->

## Contributing

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit [cla.microsoft.com][cla].

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (e.g., label, comment). Simply follow the instructions provided by the bot. You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct][code_of_conduct]. For more information see the [Code of Conduct FAQ][coc_faq] or contact [opencode@microsoft.com][coc_contact] with any additional questions or comments.

<!-- LINKS -->
[cancer_profiling_client_class]:
 <!-- https://github.com/Azure/azure-sdk-for-net/tree/main/
sdk/healthinsights/Azure.Health.Insights.CancerProfiling/src/Generated/CancerProfilingClient.cs -->

[DefaultAzureCredential]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/identity/Azure.Identity/README.md
[cognitive_resource_cli]: https://docs.microsoft.com/azure/cognitive-services/cognitive-services-apis-create-account-cli
[logging]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/core/Azure.Core/samples/Diagnostics.md
[azure_cli]: https://docs.microsoft.com/cli/azure
[azure_sub]: https://azure.microsoft.com/free/dotnet/
[nuget]: https://www.nuget.org/
[azure_portal]: https://portal.azure.com
[cla]: https://cla.microsoft.com
[code_of_conduct]: https://opensource.microsoft.com/codeofconduct/
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[coc_contact]: mailto:opencode@microsoft.com
