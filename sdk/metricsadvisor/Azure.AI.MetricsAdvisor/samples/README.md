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
|[Credential entity CRUD operations][metricsadv-sample2]|Create, get, update, list, and delete credential entities|
|[Feedback CRUD operations][metricsadv-sample11]|Create, get, and list feedback|

<!-- LINKS -->
[metricsadv-sample1]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/metricsadvisor/Azure.AI.MetricsAdvisor/tests/Samples/Sample01_DataFeedCrudOperations.cs
[metricsadv-sample2]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/metricsadvisor/Azure.AI.MetricsAdvisor/tests/Samples/Sample02_CredentialEntityCrudOperations.cs
[metricsadv-sample11]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/metricsadvisor/Azure.AI.MetricsAdvisor/tests/Samples/Sample11_FeedbackCrudOperations.cs