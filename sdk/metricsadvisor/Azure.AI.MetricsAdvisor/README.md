# Azure Metrics Advisor client library for .NET (TODO)

Brief description.

- Func 1.
- Func 2.

[Source code][metricsadv_client_src] | [Package (NuGet)][metricsadv_nuget_package] | [API reference documentation][metricsadv_refdocs] | [Product documentation][metricsadv_docs] | [Samples][metricsadv_samples]

## Getting started

### Install the package

Install the Azure Metrics Advisor client library for .NET with [NuGet][nuget]:

```PowerShell
dotnet add package Azure.AI.MetricsAdvisor --version 1.0.0-beta.1
```

### Prerequisites

* An [Azure subscription][azure_sub].
* An existing Metrics Advisor resource.

#### Create a Metrics Advisor resource

You can create a Metrics Advisor resource using:

**Option 1**: [Azure Portal][cognitive_resource_portal].

**Option 2**: [Azure CLI][cognitive_resource_cli].

Below is an example of how you can create a Metrics Advisor resource using the CLI:

```PowerShell
# Create a new resource group to hold the Metrics Advisor resource.
# If using an existing resource group, skip this step.
az group create --name <your-resource-name> --location <location>
```

```PowerShell
# Create the Metrics Advisor resource.
az cognitiveservices account create \
    --name <your-resource-name> \
    --resource-group <your-resource-group-name> \
    --kind MetricsAdvisor \
    --sku <sku> \
    --location <location>
    --yes
```

For more information about creating the resource or how to get the location and sku information see [here][cognitive_resource_cli].

### Authenticate the client

In order to interact with the Metrics Advisor service, you'll need to create an instance of the [`MetricsAdvisorClient`][metrics_advisor_client_class] or the [`MetricsAdvisorAdministrationClient`][metrics_advisor_admin_client_class] classes. You will need an **endpoint**, a **subscription key** and an **API key** to instantiate a client object.

#### Get the Endpoint and the Subscription Key

You can obtain the endpoint and the subscription key from the resource information in the [Azure Portal][azure_portal].

Alternately, you can use the [Azure CLI][azure_cli] snippet below to get the subscription key from the Metrics Advisor resource.

```Powershell
az cognitiveservices account keys list --resource-group <your-resource-group-name> --name <your-resource-name>
```

#### Get the API Key (TODO)

Stuff.

#### Create a MetricsAdvisorClient or a MetricsAdvisorAdministrationClient

Once you have the subscription and API keys, create a `MetricsAdvisorKeyCredential`. With the endpoint and the key credential, you can create a [`MetricsAdvisorClient`][metrics_advisor_client_class]:

```C# Snippet:CreateMetricsAdvisorClient
```

You can also create a [`MetricsAdvisorAdministrationClient`][metrics_advisor_administration_client_class] to perform administration operations:

```C# Snippet:CreateMetricsAdvisorAdministrationClient
```

## Key concepts (TODO)

### MetricsAdvisorClient (TODO)

### MetricsAdvisorAdministrationClient (TODO)

### Others (TODO)

## Examples

The following section provides several code snippets illustrating common patterns used in the Metrics Advisor .NET API. The snippets below make use of asynchronous service calls, but note that the Azure.AI.MetricsAdvisor package supports both synchronous and asynchronous APIs.

* [Create a data feed from a data source](#create-a-data-feed-from-a-data-source)
* [Check the ingestion status of a data feed](#check-the-ingestion-status-of-a-data-feed)
* [Create an anomaly detection configuration](#create-an-anomaly-detection-configuration)
* [Create a hook for receiving anomaly alerts](#create-a-hook-for-receiving-anomaly-alerts)
* [Create an anomaly alert configuration](#create-an-anomaly-alert-configuration)
* [Query detected anomalies and triggered alerts](#query-detected-anomalies-and-triggered-alerts)

### Create a data feed from a data source (TODO)

Info.

```C# Snippet:CreateDataFeedFromDataSource
```

### Check the ingestion status of a data feed (TODO)

```C# Snippet:CheckIngestionStatusOfDataFeed
```

### Create an anomaly detection configuration (TODO)

```C# Snippet:CreateAnomalyDetectionConfiguration
```

### Create a hook for receiving anomaly alerts (TODO)

```C# Snippet:CreateHookForReceivingAnomalyAlerts
```

### Create an anomaly alert configuration (TODO)

```C# Snippet:CreateAnomalyAlertConfiguration
```

### Query detected anomalies and triggered alerts (TODO)

```C# Snippet:QueryDetectedAnomaliesAndTriggeredAlerts
```

## Troubleshooting

### General

When you interact with the Cognitive Services Metrics Advisor client library using the .NET SDK, errors returned by the service will result in a `RequestFailedException` with the same HTTP status code returned by the [REST API][metricsadv_rest_api] request.

For example, if you try to get a data feed from the service with a non-existent ID, a `404` error is returned, indicating "Not Found".

```C# Snippet:MetricsAdvisorNotFound
```

Note that additional information is logged, such as the error message returned by the service.

```
Azure.RequestFailedException: Service request failed.
Status: 404 (Not Found)

Content:
{"code":"ERROR_INVALID_PARAMETER","message":"datafeedId is invalid."}

Headers:
X-Request-ID: REDACTED
x-envoy-upstream-service-time: REDACTED
apim-request-id: REDACTED
Strict-Transport-Security: REDACTED
X-Content-Type-Options: REDACTED
Date: Thu, 08 Oct 2020 09:04:31 GMT
Content-Length: 69
Content-Type: application/json; charset=utf-8
```

### Setting up console logging

The simplest way to see the logs is to enable console logging.

To create an Azure SDK log listener that outputs messages to the console use the `AzureEventSourceListener.CreateConsoleLogger` method.

```C#
// Setup a listener to monitor logged events.
using AzureEventSourceListener listener = AzureEventSourceListener.CreateConsoleLogger();
```

To learn more about other logging mechanisms see [Diagnostics Samples][logging].

## Next steps (TODO)

Forthcoming

## Contributing

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit [cla.microsoft.com][cla].

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (e.g., label, comment). Simply follow the instructions provided by the bot. You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct][code_of_conduct]. For more information see the [Code of Conduct FAQ][coc_faq] or contact [opencode@microsoft.com][coc_contact] with any additional questions or comments.

![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net%2Fsdk%2Fmetricsadvisor%2FAzure.AI.MetricsAdvisor%2FREADME.png)

<!-- LINKS -->
[metricsadv_client_src]: TODO
[metricsadv_docs]: TODO
[metricsadv_nuget_package]: TODO
[metricsadv_refdocs]: TODO
[metricsadv_rest_api]: TODO
[metricsadv_samples]: TODO

[metrics_advisor_admin_client_class]: TODO
[metrics_advisor_client_class]: TODO

[cognitive_resource_cli]: TODO
[cognitive_resource_portal]: TODO

[logging]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/core/Azure.Core/samples/Diagnostics.md

[azure_portal]: TODO
[azure_sub]: https://azure.microsoft.com/free/
[nuget]: https://www.nuget.org/

[cla]: https://cla.microsoft.com
[coc_contact]: mailto:opencode@microsoft.com
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[code_of_conduct]: https://opensource.microsoft.com/codeofconduct/
