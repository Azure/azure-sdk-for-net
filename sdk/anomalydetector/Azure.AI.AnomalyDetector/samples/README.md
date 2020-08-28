---
page_type: sample
languages:
- csharp
products:
- azure
- azure-cognitive-services
- azure-anomaly-detector
name: Azure Anomaly Detector samples for .NET
description: Samples for the Azure.AI.AnomalyDetector client library
---

# Azure Anomaly Detector client SDK Samples
These code samples show common scenario operations with the Anomaly Detector client library.

|**File Name**|**Description**|
|----------------|-------------|
|[Sample1_DetectEntireSeriesAnomaly.cs][sample_detect_entire_series_anomaly] |Detecting anomalies in the entire time series.|
|[Sample2_DetectLastPointAnomaly.cs][sample_detect_last_point_anomaly] |Detecting the anomaly status of the latest data point.|
|[Sample3_DetectChangePoint.cs][sample_detect_change_point] |Detecting change points in the entire time series.|

## Prerequisites
* Azure subscription - [Create one for free][azure_subscription].
* The current version of [.NET Core][dotnet_core].
* Once you have your Azure subscription, [create an Anomaly Detector resource][create_anomaly_detector_resource] in the Azure portal to get your key and endpoint. Wait for it to deploy and click the **Go to resource** button. You can use the free pricing tier (F0) to try the service, and upgrade later to a paid tier for production. You will need the key and endpoint from the resource you create to connect your application to the Anomaly Detector API.

## Setting up
### Create two environment variables for authentication:
* ANOMALY_DETECTOR_ENDPOINT - The resource endpoint for sending API requests. You will get it from your Anomaly Detector resource.
* ANOMALY_DETECTOR_API_KEY - The api key for authenticating your requests. You will get it from your Anomaly Detector resource.

### Install the client library for your project:
<code>dotnet add package Microsoft.Azure.CognitiveServices.AnomalyDetector --version 3.0.0-preview.1</code>

### Sample data
Copy the [sample data][data] to proper location.





[azure_subscription]: https://azure.microsoft.com/free/cognitive-services
[dotnet_core]: https://dotnet.microsoft.com/download/dotnet-core
[create_anomaly_detector_resource]: https://ms.portal.azure.com/#create/Microsoft.CognitiveServicesAnomalyDetector

[sample_detect_entire_series_anomaly]: ./Sample1_DetectEntireSeriesAnomaly.cs
[sample_detect_last_point_anomaly]: ./Sample2_DetectLastPointAnomaly.cs
[sample_detect_change_point]: ./Sample3_DetectChangePoint.cs
[data]: ./data