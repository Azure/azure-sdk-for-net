# Azure Cognitive Services Anomaly Detector client library for .NET

[Anomaly Detector](https://learn.microsoft.com/azure/cognitive-services/Anomaly-Detector/overview) is an AI service with a set of APIs, which enables you to monitor and detect anomalies in your time series data with little machine learning (ML) knowledge, either batch validation or real-time inference.

[Source code][anomalydetector_client_src] | [Package (NuGet)][anomalydetector_nuget_package] | [API reference documentation][anomalydetector_refdocs] | [Product documentation][anomalydetector_docs]

## Getting started

### Prerequisites

- You need an [Azure subscription][azure_sub] to use this package.
- An existing Cognitive Services Anomaly Detector instance.

### Install the package

Install the Azure Anomaly Detector client library for .NET with [NuGet][nuget]:

```dotnetcli
dotnet add package Azure.AI.AnomalyDetector --prerelease
```

This table shows the relationship between SDK versions and supported API versions of the service:

|SDK version|Supported API version of service |
|-------------|---------------|
|3.0.0-preview.6| 1.1|
|3.0.0-preview.4, 3.0.0-preview.5| 1.1-preview-1|
|3.0.0-beta.3 | 1.1-preview|
|3.0.0-preview.1, 3.0.0-preview.2  | 1.0 |

### Authenticate the client

You can find the endpoint for your Anomaly Detector service resource using the
[Azure Portal](https://ms.portal.azure.com/#create/Microsoft.CognitiveServicesAnomalyDetector)
or [Azure CLI](https://learn.microsoft.com/cli/azure/):

```bash
# Get the endpoint for the Anomaly Detector service resource
az cognitiveservices account show --name "resource-name" --resource-group "resource-group-name" --query "properties.endpoint"
```

#### Get the API Key

You can get the **API Key** from the Anomaly Detector service resource in the Azure Portal.
Alternatively, you can use **Azure CLI** snippet below to get the API key of your resource.

```PowerShell
az cognitiveservices account keys list --resource-group <your-resource-group-name> --name <your-resource-name>
```

#### Create AnomalyDetectorClient with AzureKeyCredential

Once you have the value for the API key, create an `AzureKeyCredential`.  With the endpoint and key credential, you can create the [`AnomalyDetectorClient`][anomaly_detector_client_class]:

```C#
string endpoint = "<endpoint>";
string apiKey = "<apiKey>";
var credential = new AzureKeyCredential(apiKey);
var client = new AnomalyDetectorClient(new Uri(endpoint), credential);
```

## Key concepts

With the Anomaly Detector, you can either detect anomalies in one variable using **Univariate Anomaly Detection**, or detect anomalies in multiple variables with **Multivariate Anomaly Detection**.

|Feature  |Description  |
|---------|---------|
|Univariate Anomaly Detection | Detect anomalies in one variable, like revenue, cost, etc. The model was selected automatically based on your data pattern. |
|Multivariate Anomaly Detection| Detect anomalies in multiple variables with correlations, which are usually gathered from equipment or other complex system. The underlying model used is Graph attention network.|

### Univariate Anomaly Detection

The Univariate Anomaly Detection API enables you to monitor and detect abnormalities in your time series data without having to know machine learning. The algorithms adapt by automatically identifying and applying the best-fitting models to your data, regardless of industry, scenario, or data volume. Using your time series data, the API determines boundaries for anomaly detection, expected values, and which data points are anomalies.

Using the Anomaly Detector doesn't require any prior experience in machine learning, and the REST API enables you to easily integrate the service into your applications and processes.

With the Univariate Anomaly Detection, you can automatically detect anomalies throughout your time series data, or as they occur in real-time.

|Feature  |Description  |
|---------|---------|
| Streaming detection| Detect anomalies in your streaming data by using previously seen data points to determine if your latest one is an anomaly. This operation generates a model using the data points you send, and determines if the target point is an anomaly. By calling the API with each new data point you generate, you can monitor your data as it's created. |
| Batch detection | Use your time series to detect any anomalies that might exist throughout your data. This operation generates a model using your entire time series data, with each point analyzed with the same model.         |
| Change points detection | Use your time series to detect any trend change points that exist in your data. This operation generates a model using your entire time series data, with each point analyzed with the same model.    |

### Multivariate Anomaly Detection

The **Multivariate Anomaly Detection** APIs further enable developers by easily integrating advanced AI for detecting anomalies from groups of metrics, without the need for machine learning knowledge or labeled data. Dependencies and inter-correlations between up to 300 different signals are now automatically counted as key factors. This new capability helps you to proactively protect your complex systems such as software applications, servers, factory machines, spacecraft, or even your business, from failures.

With the Multivariate Anomaly Detection, you can automatically detect anomalies throughout your time series data, or as they occur in real-time. There are three processes to use Multivariate Anomaly Detection.

- **Training**: Use Train Model API to create and train a model, then use Get Model Status API to get the status and model metadata.
- **Inference**:
  - Use Async Inference API to trigger an asynchronous inference process and use Get Inference results API to get detection results on a batch of data.
  - You could also use Sync Inference API to trigger a detection on one timestamp every time.
- **Other operations**: List Model API and Delete Model API are supported in Multivariate Anomaly Detection model for model management.

### Thread safety

We guarantee that all client instance methods are thread-safe and independent of each other ([guideline](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-service-methods-thread-safety)). This ensures that the recommendation of reusing client instances is always safe, even across threads.

### Additional concepts
<!-- CLIENT COMMON BAR -->
[Client options](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#configuring-service-clients-using-clientoptions) |
[Accessing the response](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#accessing-http-response-details-using-responset) |
[Long-running operations](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#consuming-long-running-operations-using-operationt) |
[Handling failures](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#reporting-errors-requestfailedexception) |
[Diagnostics](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Diagnostics.md) |
[Mocking](https://learn.microsoft.com/dotnet/azure/sdk/unit-testing-mocking) |
[Client lifetime](https://devblogs.microsoft.com/azure-sdk/lifetime-management-and-thread-safety-guarantees-of-azure-sdk-net-clients/)
<!-- CLIENT COMMON BAR -->

## Examples

The following section provides several code snippets covering some of the most common Anomaly Detector service tasks, including:

- [Univariate Anomaly Detection - Batch detection](#batch-detection)
- [Univariate Anomaly Detection - Streaming detection](#streaming-detection)
- [Univariate Anomaly Detection - Detect change points](#detect-change-points)
- [Multivariate Anomaly Detection](#multivariate-anomaly-detection-sample)

### Batch detection

```C# Snippet:DetectEntireSeriesAnomaly
//detect
Console.WriteLine("Detecting anomalies in the entire time series.");

try
{
    Response response = client.GetUnivariateClient().DetectUnivariateEntireSeries(request.ToRequestContent());
    JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;

    bool hasAnomaly = false;
    for (int i = 0; i < request.Series.Count; ++i)
    {
        if (result.GetProperty("isAnomaly")[i].GetBoolean())
        {
            Console.WriteLine($"An anomaly was detected at index: {i}.");
            hasAnomaly = true;
        }
    }
    if (!hasAnomaly)
    {
        Console.WriteLine("No anomalies detected in the series.");
    }
}
catch (RequestFailedException ex)
{
    Console.WriteLine($"Entire detection failed: {ex.Message}");
    throw;
}
catch (Exception ex)
{
    Console.WriteLine($"Detection error. {ex.Message}");
    throw;
}
```

### Streaming Detection

```C# Snippet:DetectLastPointAnomaly
//detect
Console.WriteLine("Detecting the anomaly status of the latest point in the series.");

try
{
    UnivariateLastDetectionResult result = client.GetUnivariateClient().DetectUnivariateLastPoint(request);

    if (result.IsAnomaly)
    {
        Console.WriteLine("The latest point was detected as an anomaly.");
    }
    else
    {
        Console.WriteLine("The latest point was not detected as an anomaly.");
    }
}
catch (RequestFailedException ex)
{
    Console.WriteLine($"Last detection failed: {ex.Message}");
    throw;
}
catch (Exception ex)
{
    Console.WriteLine($"Detection error. {ex.Message}");
    throw;
}
```

### Detect change points

```C# Snippet:DetectChangePoint
//detect
Console.WriteLine("Detecting the change point in the series.");

UnivariateChangePointDetectionResult result = client.GetUnivariateClient().DetectUnivariateChangePoint(request);

if (result.IsChangePoint.Contains(true))
{
    Console.WriteLine("A change point was detected at index:");
    for (int i = 0; i < request.Series.Count; ++i)
    {
        if (result.IsChangePoint[i])
        {
            Console.Write(i);
            Console.Write(" ");
        }
    }
    Console.WriteLine();
}
else
{
    Console.WriteLine("No change point detected in the series.");
}
```

### Multivariate Anomaly Detection Sample

To see how to use Anomaly Detector library to conduct Multivariate Anomaly Detection, see this [sample](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/anomalydetector/Azure.AI.AnomalyDetector/tests/samples/Sample4_MultivariateDetect.cs).

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

These code samples show common scenario operations with the Azure Anomaly Detector library. More samples can be found under the [samples](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/anomalydetector/Azure.AI.AnomalyDetector/tests/samples/) directory.

- Univariate Anomaly Detection - Batch Detection: [Sample1_DetectEntireSeriesAnomaly.cs](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/anomalydetector/Azure.AI.AnomalyDetector/tests/samples/Sample1_DetectEntireSeriesAnomaly.cs)

- Univariate Anomaly Detection - Streaming Detection: [Sample2_DetectLastPointAnomaly.cs](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/anomalydetector/Azure.AI.AnomalyDetector/tests/samples/Sample2_DetectLastPointAnomaly.cs)

- Univariate Anomaly Detection - Change Point Detection: [Sample3_DetectChangePoint.cs](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/anomalydetector/Azure.AI.AnomalyDetector/tests/samples/Sample3_DetectChangePoint.cs)

- Multivariate Anomaly Detection: [Sample4_MultivariateDetect.cs](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/anomalydetector/Azure.AI.AnomalyDetector/tests/samples/Sample4_MultivariateDetect.cs)

### Additional documentation

For more extensive documentation on Azure Anomaly Detector, see the [Anomaly Detector documentation](https://learn.microsoft.com/azure/cognitive-services/anomaly-detector/overview) on learn.microsoft.com.

## Contributing

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit [cla.microsoft.com][cla].

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (e.g., label, comment). Simply follow the instructions provided by the bot. You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct][code_of_conduct]. For more information see the [Code of Conduct FAQ][coc_faq] or contact [opencode@microsoft.com][coc_contact] with any additional questions or comments.

<!-- LINKS -->
[anomalydetector_client_src]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/anomalydetector/Azure.AI.AnomalyDetector/src
[anomalydetector_docs]: https://learn.microsoft.com/azure/cognitive-services/anomaly-detector/
[anomalydetector_refdocs]: https://azure.github.io/azure-sdk-for-net/cognitiveservices.html
[anomalydetector_nuget_package]: https://www.nuget.org/packages/Azure.AI.AnomalyDetector
[anomaly_detector_client_class]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/anomalydetector/Azure.AI.AnomalyDetector/src/Generated/AnomalyDetectorClient.cs
[azure_identity]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/identity/Azure.Identity
[register_aad_app]: https://learn.microsoft.com/azure/cognitive-services/authentication#assign-a-role-to-a-service-principal
[aad_grant_access]: https://learn.microsoft.com/azure/cognitive-services/authentication#assign-a-role-to-a-service-principal
[custom_subdomain]: https://learn.microsoft.com/azure/cognitive-services/authentication#create-a-resource-with-a-custom-subdomain
[DefaultAzureCredential]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/identity/Azure.Identity/README.md
[cognitive_resource_cli]: https://learn.microsoft.com/azure/cognitive-services/cognitive-services-apis-create-account-cli
[logging]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/core/Azure.Core/samples/Diagnostics.md
[azure_cli]: https://learn.microsoft.com/cli/azure
[azure_sub]: https://azure.microsoft.com/free/dotnet/
[nuget]: https://www.nuget.org/
[azure_portal]: https://portal.azure.com
[cla]: https://cla.microsoft.com
[code_of_conduct]: https://opensource.microsoft.com/codeofconduct/
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[coc_contact]: mailto:opencode@microsoft.com
