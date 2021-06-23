---
page_type: sample
languages:
- csharp
products:
- azure
- azure-cognitive-services
- azure-metrics-advisor
name: Azure Metrics Advisor samples for .NET
description: Samples for the Azure.AI.MetricsAdvisor client library
---

# Azure Metrics Advisor client SDK samples

Azure Cognitive Services Metrics Advisor is a cloud service that uses machine learning to monitor and detect anomalies in time series data. It includes the following capabilities:

- Analyze multi-dimensional data from multiple data sources.
- Identify and correlate anomalies.
- Configure and fine-tune the anomaly detection model used on your data.
- Diagnose anomalies and help with root cause analysis.

# Samples

|**Sample**|**Description**|
|---|---|
|[Data feed CRUD operations][metricsadv-sample1]|Create, get, update, list, and delete data feeds|
|[Data feed ingestion operations][metricsadv-sample2]|Check and refresh a data feed's ingestion status|
|[Anomaly detection configuration CRUD operations][metricsadv-sample3]|Create, get, update, list, and delete anomaly detection configurations|
|[Hook CRUD operations][metricsadv-sample4]|Create, get, update, list, and delete hooks|
|[Anomaly alert configuration CRUD operations][metricsadv-sample5]|Create, get, update, list, and delete anomaly alert configurations|
|[Query triggered alerts][metricsadv-sample6]|Get the alerts triggered by the service|
|[Query detected anomalies][metricsadv-sample7]|Get the anomalies detected by the service|
|[Query incidents and their root causes][metricsadv-sample8]|Get the incidents created by the service and root cause analysis|
|[Query time series information][metricsadv-sample9]|Get information about the time series monitored by the service|
|[Feedback CRUD operations][metricsadv-sample10]|Create, get, and list feedback|

<!-- LINKS -->
[metricsadv-sample1]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/metricsadvisor/Azure.AI.MetricsAdvisor/tests/Samples/Sample01_DataFeedCrudOperations.cs
[metricsadv-sample2]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/metricsadvisor/Azure.AI.MetricsAdvisor/tests/Samples/Sample02_DataFeedIngestionOperations.cs
[metricsadv-sample3]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/metricsadvisor/Azure.AI.MetricsAdvisor/tests/Samples/Sample03_DetectionConfigurationCrudOperations.cs
[metricsadv-sample4]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/metricsadvisor/Azure.AI.MetricsAdvisor/tests/Samples/Sample04_HookCrudOperations.cs
[metricsadv-sample5]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/metricsadvisor/Azure.AI.MetricsAdvisor/tests/Samples/Sample05_AlertConfigurationCrudOperations.cs
[metricsadv-sample6]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/metricsadvisor/Azure.AI.MetricsAdvisor/tests/Samples/Sample06_QueryTriggeredAlerts.cs
[metricsadv-sample7]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/metricsadvisor/Azure.AI.MetricsAdvisor/tests/Samples/Sample07_QueryDetectedAnomalies.cs
[metricsadv-sample8]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/metricsadvisor/Azure.AI.MetricsAdvisor/tests/Samples/Sample08_QueryIncidentsAndRootCauses.cs
[metricsadv-sample9]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/metricsadvisor/Azure.AI.MetricsAdvisor/tests/Samples/Sample09_QueryTimeSeriesInformation.cs
[metricsadv-sample10]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/metricsadvisor/Azure.AI.MetricsAdvisor/tests/Samples/Sample10_FeedbackCrudOperations.cs