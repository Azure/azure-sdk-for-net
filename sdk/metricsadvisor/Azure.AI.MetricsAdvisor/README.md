# Azure Metrics Advisor client library for .NET

Azure Cognitive Services Metrics Advisor is a cloud service that uses machine learning to monitor and detect anomalies in time series data. It includes the following capabilities:

- Analyze multi-dimensional data from multiple data sources.
- Identify and correlate anomalies.
- Configure and fine-tune the anomaly detection model used on your data.
- Diagnose anomalies and help with root cause analysis.

[Source code][metricsadv_client_src] | [Package (NuGet)][metricsadv_nuget_package] | [API reference documentation][metricsadv_refdocs] | [Product documentation][metricsadv_docs] | [Samples][metricsadv_samples]

## Getting started

### Install the package

Install the Azure Metrics Advisor client library for .NET with [NuGet][nuget]:

```PowerShell
dotnet add package Azure.AI.MetricsAdvisor --version 1.0.0-beta.4
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

In order to interact with the Metrics Advisor service, you'll need to create an instance of the [`MetricsAdvisorClient`][metrics_advisor_client_class] or the [`MetricsAdvisorAdministrationClient`][metrics_advisor_admin_client_class] classes. You will need an **endpoint**, a **subscription key**, and an **API key** to instantiate a client object.

#### Get the Endpoint and the Subscription Key

You can obtain the endpoint and the subscription key from the resource information in the [Azure Portal][azure_portal].

Alternately, you can use the [Azure CLI][azure_cli] snippet below to get the subscription key from the Metrics Advisor resource.

```Powershell
az cognitiveservices account keys list --resource-group <your-resource-group-name> --name <your-resource-name>
```

#### Get the API Key

You can obtain the API key in the [Metrics Advisor Web Portal][metricsadv_web_portal]. You'll be prompted to login for authentication.

Once logged in, fill in your Azure Active Directory, Subscription and Metrics Advisor resource name.

#### Create a MetricsAdvisorClient or a MetricsAdvisorAdministrationClient

Once you have the subscription and API keys, create a `MetricsAdvisorKeyCredential`. With the endpoint and the key credential, you can create a [`MetricsAdvisorClient`][metrics_advisor_client_class]:

```C# Snippet:CreateMetricsAdvisorClient
string endpoint = "<endpoint>";
string subscriptionKey = "<subscriptionKey>";
string apiKey = "<apiKey>";
var credential = new MetricsAdvisorKeyCredential(subscriptionKey, apiKey);
var client = new MetricsAdvisorClient(new Uri(endpoint), credential);
```

You can also create a [`MetricsAdvisorAdministrationClient`][metrics_advisor_admin_client_class] to perform administration operations:

```C# Snippet:CreateMetricsAdvisorAdministrationClient
string endpoint = "<endpoint>";
string subscriptionKey = "<subscriptionKey>";
string apiKey = "<apiKey>";
var credential = new MetricsAdvisorKeyCredential(subscriptionKey, apiKey);
var adminClient = new MetricsAdvisorAdministrationClient(new Uri(endpoint), credential);
```

#### Create a MetricsAdvisorClient or a MetricsAdvisorAdministrationClient with Azure Active Directory

`MetricsAdvisorKeyCredential` authentication is used in the examples in this getting started guide, but you can also authenticate with Azure Active Directory using the [Azure Identity library][azure_identity].

To use the [DefaultAzureCredential][DefaultAzureCredential] provider shown below, or other credential providers provided with the Azure SDK, please install the `Azure.Identity` package:

```PowerShell
Install-Package Azure.Identity
```

You will also need to [register a new AAD application][register_aad_app] and [grant access][aad_grant_access] to Metrics Advisor by assigning the `"Cognitive Services Metrics Advisor User"` role to your service principal. You may want to assign the `"Cognitive Services Metrics Advisor Administrator"` role instead if administrator privileges are required.

Set the values of the client ID, tenant ID, and client secret of the AAD application as environment variables: AZURE_CLIENT_ID, AZURE_TENANT_ID, AZURE_CLIENT_SECRET.

Once you have the environment variables set, you can create a [`MetricsAdvisorClient`][metrics_advisor_client_class]:

```C# Snippet:CreateMetricsAdvisorClientWithAad
string endpoint = "<endpoint>";
var client = new MetricsAdvisorClient(new Uri(endpoint), new DefaultAzureCredential());
```

Alternately, you can also create a [`MetricsAdvisorAdministrationClient`][metrics_advisor_admin_client_class] to perform administration operations:

```C# Snippet:CreateMetricsAdvisorAdministrationClientWithAad
string endpoint = "<endpoint>";
var adminClient = new MetricsAdvisorAdministrationClient(new Uri(endpoint), new DefaultAzureCredential());
```

## Key concepts

### MetricsAdvisorClient

`MetricsAdvisorClient` is the primary querying interface for developers using the Metrics Advisor client library. It provides synchronous and asynchronous methods to access a specific use of Metrics Advisor, such as listing incidents, retrieving root causes of incidents, and retrieving time series data.

### MetricsAdvisorAdministrationClient

`MetricsAdvisorAdministrationClient` is the interface responsible for managing entities in the Metrics Advisor resource. It provides synchronous and asynchronous methods for tasks such as creating and updating data feeds, anomaly detection configurations, and anomaly alerting configurations.

### Data Feed

A `DataFeed` ingests data from your data source, such as CosmosDB or a SQL server, and makes it available for the Metrics Advisor service. It's the entry point of data, and therefore, the first required agent to be set before anomaly detection can take place. See the sample [Create a data feed from a data source](#create-a-data-feed-from-a-data-source) below for more information.

### Data Feed Metric

A `DataFeedMetric`, or simply "metric", is a quantifiable measure to be monitored by the Metrics Advisor service. It could be the cost of a product over the months, or even a daily measure of temperature. The service will monitor how this value varies over time in search of any anomalous behavior. A [data feed](#data-feed) can ingest multiple metrics from the same data source.

### Data Feed Dimension

A `DataFeedDimension`, or simply "dimension", is a set of categorical values that characterize a [metric](#data-feed-metric). For instance, if a metric represents the cost of a product, the type of product (e.g., shoes, hats) and the city in which these values were measured (e.g., New York, Tokyo) could be used as a dimension. Possible dimension values would include: `(shoes, New York)`, `(shoes, Tokyo)`, `(hats, New York)`, and `(hats, Tokyo)`.

### Time Series

A time series is a series of data points indexed in time order. These data points describe the variation of the value of a [metric](#data-feed-metric) over time.

Given a metric, the Metrics Advisor service creates one series for every possible [dimension](#data-feed-dimension) value, which means that multiple time series can be monitored for the same metric.

### Data Point Anomaly

A `DataPointAnomaly`, or simply "anomaly", occurs when a data point in a [time series](#time-series) behaves unexpectedly. It may occur when a data point value is too high or too low, or when its value changes abruptly between close points. You can specify the conditions a data point must satisfy to be considered an anomaly with an `AnomalyDetectionConfiguration`. See the sample [Create an anomaly detection configuration](#create-an-anomaly-detection-configuration) below for more information.

### Anomaly Incident

Detected [anomalies](#data-point-anomaly) within the same [time series](#time-series) can be grouped into an `AnomalyIncident`, or simply "incident". The service looks for patterns across anomalies to determine which ones are likely to have the same cause, grouping them together.

### Anomaly Alert

An `AnomalyAlert`, or simply "alert", is triggered when a detected [anomaly](#data-point-anomaly) meets a specified criteria. For instance, an alert could be triggered every time an anomaly with high severity is detected. You can specify the conditions an anomaly must satisfy to trigger an alert with an `AnomalyAlertConfiguration`, which make use of [hooks](#notification-hook) to send notifications to the concerned parties every time an alert is triggered. These configurations are not set by default, so you need to create one in order to start triggering and receiving alerts. See the sample [Create an anomaly alert configuration](#create-an-anomaly-alert-configuration) below for more information.

### Notification Hook

A `NotificationHook`, or simply "hook", is a means of subscribing to [alerts](#anomaly-alert) notifications. You can pass a hook to an `AnomalyAlertConfiguration` and start getting notifications for every alert it creates. See the sample [Create a hook for receiving anomaly alerts](#create-a-hook-for-receiving-anomaly-alerts) below for more information.

### Thread safety
We guarantee that all client instance methods are thread-safe and independent of each other ([guideline](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-service-methods-thread-safety)). This ensures that the recommendation of reusing client instances is always safe, even across threads.

### Additional concepts
<!-- CLIENT COMMON BAR -->
[Client options](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/core/Azure.Core/README.md#configuring-service-clients-using-clientoptions) |
[Accessing the response](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/core/Azure.Core/README.md#accessing-http-response-details-using-responset) |
[Handling failures](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/core/Azure.Core/README.md#reporting-errors-requestfailedexception) |
[Diagnostics](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/core/Azure.Core/samples/Diagnostics.md) |
[Mocking](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/core/Azure.Core/README.md#mocking) |
[Client lifetime](https://devblogs.microsoft.com/azure-sdk/lifetime-management-and-thread-safety-guarantees-of-azure-sdk-net-clients/)
<!-- CLIENT COMMON BAR -->

## Examples

The following section provides several code snippets illustrating common patterns used in the Metrics Advisor .NET API. The snippets below make use of asynchronous service calls, but note that the Azure.AI.MetricsAdvisor package supports both synchronous and asynchronous APIs.

* [Create a data feed from a data source](#create-a-data-feed-from-a-data-source)
* [Check the ingestion status of a data feed](#check-the-ingestion-status-of-a-data-feed)
* [Create an anomaly detection configuration](#create-an-anomaly-detection-configuration)
* [Create a hook for receiving anomaly alerts](#create-a-hook-for-receiving-anomaly-alerts)
* [Create an anomaly alert configuration](#create-an-anomaly-alert-configuration)
* [Query detected anomalies and triggered alerts](#query-detected-anomalies-and-triggered-alerts)

### Create a data feed from a data source

Metrics Advisor supports multiple types of data sources. In this sample we'll illustrate how to create a [`DataFeed`](#data-feed) that extracts data from a SQL server.

```C# Snippet:CreateDataFeedAsync
string sqlServerConnectionString = "<connectionString>";
string sqlServerQuery = "<query>";

var dataFeed = new DataFeed();

dataFeed.Name = "<dataFeedName>";
dataFeed.DataSource = new SqlServerDataFeedSource(sqlServerConnectionString, sqlServerQuery);
dataFeed.Granularity = new DataFeedGranularity(DataFeedGranularityType.Daily);

dataFeed.Schema = new DataFeedSchema();
dataFeed.Schema.MetricColumns.Add(new DataFeedMetric("cost"));
dataFeed.Schema.MetricColumns.Add(new DataFeedMetric("revenue"));
dataFeed.Schema.DimensionColumns.Add(new DataFeedDimension("category"));
dataFeed.Schema.DimensionColumns.Add(new DataFeedDimension("city"));

dataFeed.IngestionSettings = new DataFeedIngestionSettings(DateTimeOffset.Parse("2020-01-01T00:00:00Z"));

Response<DataFeed> response = await adminClient.CreateDataFeedAsync(dataFeed);

DataFeed createdDataFeed = response.Value;

Console.WriteLine($"Data feed ID: {createdDataFeed.Id}");
Console.WriteLine($"Data feed status: {createdDataFeed.Status.Value}");
Console.WriteLine($"Data feed created time: {createdDataFeed.CreatedTime.Value}");

Console.WriteLine($"Data feed administrators:");
foreach (string admin in createdDataFeed.AdministratorsEmails)
{
    Console.WriteLine($" - {admin}");
}

Console.WriteLine($"Metric IDs:");
foreach (DataFeedMetric metric in createdDataFeed.Schema.MetricColumns)
{
    Console.WriteLine($" - {metric.Name}: {metric.Id}");
}

Console.WriteLine($"Dimension columns:");
foreach (DataFeedDimension dimension in createdDataFeed.Schema.DimensionColumns)
{
    Console.WriteLine($" - {dimension.Name}");
}
```

### Check the ingestion status of a data feed

Check the ingestion status of a previously created [`DataFeed`](#data-feed).

```C# Snippet:GetDataFeedIngestionStatusesAsync
string dataFeedId = "<dataFeedId>";

var startTime = DateTimeOffset.Parse("2020-01-01T00:00:00Z");
var endTime = DateTimeOffset.Parse("2020-09-09T00:00:00Z");
var options = new GetDataFeedIngestionStatusesOptions(startTime, endTime)
{
    MaxPageSize = 5
};

Console.WriteLine("Ingestion statuses:");
Console.WriteLine();

int statusCount = 0;

await foreach (DataFeedIngestionStatus ingestionStatus in adminClient.GetDataFeedIngestionStatusesAsync(dataFeedId, options))
{
    Console.WriteLine($"Timestamp: {ingestionStatus.Timestamp}");
    Console.WriteLine($"Status: {ingestionStatus.Status}");
    Console.WriteLine($"Service message: {ingestionStatus.Message}");
    Console.WriteLine();

    // Print at most 5 statuses.
    if (++statusCount >= 5)
    {
        break;
    }
}
```

### Create an anomaly detection configuration

Create an [`AnomalyDetectionConfiguration`](#data-point-anomaly) to tell the service which data points should be considered anomalies.

```C# Snippet:CreateDetectionConfigurationAsync
string metricId = "<metricId>";
string configurationName = "<configurationName>";

var detectionConfiguration = new AnomalyDetectionConfiguration()
{
    MetricId = metricId,
    Name = configurationName,
    WholeSeriesDetectionConditions = new MetricWholeSeriesDetectionCondition()
};

var detectCondition = detectionConfiguration.WholeSeriesDetectionConditions;

var hardSuppress = new SuppressCondition(1, 100);
detectCondition.HardThresholdCondition = new HardThresholdCondition(AnomalyDetectorDirection.Down, hardSuppress)
{
    LowerBound = 5.0
};

var smartSuppress = new SuppressCondition(4, 50);
detectCondition.SmartDetectionCondition = new SmartDetectionCondition(10.0, AnomalyDetectorDirection.Up, smartSuppress);

detectCondition.CrossConditionsOperator = DetectionConditionsOperator.Or;

Response<AnomalyDetectionConfiguration> response = await adminClient.CreateDetectionConfigurationAsync(detectionConfiguration);

AnomalyDetectionConfiguration createdDetectionConfiguration = response.Value;

Console.WriteLine($"Anomaly detection configuration ID: {createdDetectionConfiguration.Id}");
```

### Create a hook for receiving anomaly alerts

Metrics Advisor supports the [`EmailNotificationHook`](#notification-hook) and the [`WebNotificationHook`](#notification-hook) classes as means of subscribing to [alerts](#anomaly-alert) notifications. In this example we'll illustrate how to create an `EmailNotificationHook`. Note that you need to pass the hook to an anomaly alert configuration to start getting notifications. See the sample [Create an anomaly alert configuration](#create-an-anomaly-alert-configuration) below for more information.

```C# Snippet:CreateHookAsync
string hookName = "<hookName>";

var emailHook = new EmailNotificationHook(hookName);

emailHook.EmailsToAlert.Add("email1@sample.com");
emailHook.EmailsToAlert.Add("email2@sample.com");

Response<NotificationHook> response = await adminClient.CreateHookAsync(emailHook);

NotificationHook createdHook = response.Value;

Console.WriteLine($"Hook ID: {createdHook.Id}");
```

### Create an anomaly alert configuration

Create an [`AnomalyAlertConfiguration`](#anomaly-alert) to tell the service which anomalies should trigger alerts.

```C# Snippet:CreateAlertConfigurationAsync
string hookId = "<hookId>";
string anomalyDetectionConfigurationId = "<anomalyDetectionConfigurationId>";
string configurationName = "<configurationName>";

AnomalyAlertConfiguration alertConfiguration = new AnomalyAlertConfiguration()
{
    Name = configurationName
};

alertConfiguration.IdsOfHooksToAlert.Add(hookId);

var scope = MetricAnomalyAlertScope.GetScopeForWholeSeries();
var metricAlertConfiguration = new MetricAnomalyAlertConfiguration(anomalyDetectionConfigurationId, scope);

alertConfiguration.MetricAlertConfigurations.Add(metricAlertConfiguration);

Response<AnomalyAlertConfiguration> response = await adminClient.CreateAlertConfigurationAsync(alertConfiguration);

AnomalyAlertConfiguration createdAlertConfiguration = response.Value;

Console.WriteLine($"Alert configuration ID: {createdAlertConfiguration.Id}");
```

### Query detected anomalies and triggered alerts

Look through the [alerts](#anomaly-alert) created by a given anomaly alert configuration.

```C# Snippet:GetAlertsAsync
string anomalyAlertConfigurationId = "<anomalyAlertConfigurationId>";

var startTime = DateTimeOffset.Parse("2020-01-01T00:00:00Z");
var endTime = DateTimeOffset.UtcNow;
var options = new GetAlertsOptions(startTime, endTime, AlertQueryTimeMode.AnomalyTime)
{
    MaxPageSize = 5
};

int alertCount = 0;

await foreach (AnomalyAlert alert in client.GetAlertsAsync(anomalyAlertConfigurationId, options))
{
    Console.WriteLine($"Alert created at: {alert.CreatedTime}");
    Console.WriteLine($"Alert at timestamp: {alert.Timestamp}");
    Console.WriteLine($"Id: {alert.Id}");
    Console.WriteLine();

    // Print at most 5 alerts.
    if (++alertCount >= 5)
    {
        break;
    }
}
```

Once you know an alert's ID, list the [anomalies](#data-point-anomaly) that triggered this alert.

```C# Snippet:GetAnomaliesForAlertAsync
string alertConfigurationId = "<alertConfigurationId>";
string alertId = "<alertId>";

var options = new GetAnomaliesForAlertOptions() { MaxPageSize = 3 };

int anomalyCount = 0;

await foreach (DataPointAnomaly anomaly in client.GetAnomaliesForAlertAsync(alertConfigurationId, alertId, options))
{
    Console.WriteLine($"Anomaly detection configuration ID: {anomaly.DetectionConfigurationId}");
    Console.WriteLine($"Data feed ID: {anomaly.DataFeedId}");
    Console.WriteLine($"Metric ID: {anomaly.MetricId}");
    Console.WriteLine($"Anomaly value: {anomaly.Value}");

    if (anomaly.ExpectedValue.HasValue)
    {
        Console.WriteLine($"Anomaly expected value: {anomaly.ExpectedValue}");
    }

    Console.WriteLine($"Anomaly at timestamp: {anomaly.Timestamp}");
    Console.WriteLine($"Anomaly detected at: {anomaly.CreatedTime}");
    Console.WriteLine($"Status: {anomaly.Status}");
    Console.WriteLine($"Severity: {anomaly.Severity}");
    Console.WriteLine("Series key:");

    foreach (KeyValuePair<string, string> keyValuePair in anomaly.SeriesKey.AsDictionary())
    {
        Console.WriteLine($"  Dimension '{keyValuePair.Key}': {keyValuePair.Value}");
    }

    Console.WriteLine();

    // Print at most 3 anomalies.
    if (++anomalyCount >= 3)
    {
        break;
    }
}
```

## Troubleshooting

### General

When you interact with the Cognitive Services Metrics Advisor client library using the .NET SDK, errors returned by the service will result in a `RequestFailedException` with the same HTTP status code returned by the [REST API][metricsadv_rest_api] request.

For example, if you try to get a data feed from the service with a non-existent ID, a `404` error is returned, indicating "Not Found".

```C# Snippet:MetricsAdvisorNotFound
string dataFeedId = "00000000-0000-0000-0000-000000000000";

try
{
    Response<DataFeed> response = await adminClient.GetDataFeedAsync(dataFeedId);
}
catch (RequestFailedException ex)
{
    Console.WriteLine(ex.ToString());
}
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
// Set up a listener to monitor logged events.
using AzureEventSourceListener listener = AzureEventSourceListener.CreateConsoleLogger();
```

To learn more about other logging mechanisms see [Diagnostics Samples][logging].

## Next steps

Samples showing how to use the Cognitive Services Metrics Advisor library are available in this GitHub repository. Samples are provided for each main functional area:

- [Data feed CRUD operations][metricsadv-sample1]
- [Data feed ingestion operations][metricsadv-sample2]
- [Anomaly detection configuration CRUD operations][metricsadv-sample3]
- [Hook CRUD operations][metricsadv-sample4]
- [Anomaly alert configuration CRUD operations][metricsadv-sample5]
- [Query triggered alerts][metricsadv-sample6]
- [Query detected anomalies][metricsadv-sample7]
- [Query incidents and their root causes][metricsadv-sample8]
- [Query time series information][metricsadv-sample9]
- [Feedback CRUD operations][metricsadv-sample10]

## Contributing

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit [cla.microsoft.com][cla].

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (e.g., label, comment). Simply follow the instructions provided by the bot. You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct][code_of_conduct]. For more information see the [Code of Conduct FAQ][coc_faq] or contact [opencode@microsoft.com][coc_contact] with any additional questions or comments.

![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net%2Fsdk%2Fmetricsadvisor%2FAzure.AI.MetricsAdvisor%2FREADME.png)

<!-- LINKS -->
[metricsadv_client_src]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/metricsadvisor/Azure.AI.MetricsAdvisor/src
[metricsadv_docs]: https://docs.microsoft.com/azure/cognitive-services/metrics-advisor
[metricsadv_nuget_package]: https://www.nuget.org/packages/Azure.AI.MetricsAdvisor
[metricsadv_refdocs]: https://aka.ms/azsdk/net/docs/ref/metricsadvisor
[metricsadv_rest_api]: https://westus2.dev.cognitive.microsoft.com/docs/services/MetricsAdvisor
[metricsadv_samples]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/metricsadvisor/Azure.AI.MetricsAdvisor/samples/README.md
[metricsadv_web_portal]: https://metricsadvisor.azurewebsites.net

[metrics_advisor_admin_client_class]: https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/metricsadvisor/Azure.AI.MetricsAdvisor/src/MetricsAdvisorAdministrationClient.cs
[metrics_advisor_client_class]: https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/metricsadvisor/Azure.AI.MetricsAdvisor/src/MetricsAdvisorClient.cs

[metricsadv-sample1]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/metricsadvisor/Azure.AI.MetricsAdvisor/tests/Samples/Sample01_DataFeedCrudOperations.cs
[metricsadv-sample2]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/metricsadvisor/Azure.AI.MetricsAdvisor/tests/Samples/Sample02_DataFeedIngestionOperations.cs
[metricsadv-sample3]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/metricsadvisor/Azure.AI.MetricsAdvisor/tests/Samples/Sample03_DetectionConfigurationCrudOperations.cs
[metricsadv-sample4]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/metricsadvisor/Azure.AI.MetricsAdvisor/tests/Samples/Sample04_HookCrudOperations.cs
[metricsadv-sample5]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/metricsadvisor/Azure.AI.MetricsAdvisor/tests/Samples/Sample05_AlertConfigurationCrudOperations.cs
[metricsadv-sample6]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/metricsadvisor/Azure.AI.MetricsAdvisor/tests/Samples/Sample06_QueryTriggeredAlerts.cs
[metricsadv-sample7]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/metricsadvisor/Azure.AI.MetricsAdvisor/tests/Samples/Sample07_QueryDetectedAnomalies.cs
[metricsadv-sample8]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/metricsadvisor/Azure.AI.MetricsAdvisor/tests/Samples/Sample08_QueryIncidentsAndRootCauses.cs
[metricsadv-sample9]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/metricsadvisor/Azure.AI.MetricsAdvisor/tests/Samples/Sample09_QueryTimeSeriesInformation.cs
[metricsadv-sample10]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/metricsadvisor/Azure.AI.MetricsAdvisor/tests/Samples/Sample10_FeedbackCrudOperations.cs

[aad_grant_access]: https://docs.microsoft.com/azure/cognitive-services/authentication#assign-a-role-to-a-service-principal
[azure_identity]: https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/identity/Azure.Identity/README.md
[cognitive_resource_cli]: https://docs.microsoft.com/azure/cognitive-services/cognitive-services-apis-create-account-cli
[cognitive_resource_portal]: https://docs.microsoft.com/azure/cognitive-services/cognitive-services-apis-create-account
[DefaultAzureCredential]: https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/identity/Azure.Identity/README.md#defaultazurecredential
[register_aad_app]: https://docs.microsoft.com/azure/cognitive-services/authentication#assign-a-role-to-a-service-principal

[logging]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/core/Azure.Core/samples/Diagnostics.md

[azure_cli]: https://docs.microsoft.com/cli/azure
[azure_portal]: https://portal.azure.com
[azure_sub]: https://azure.microsoft.com/free
[nuget]: https://www.nuget.org

[cla]: https://cla.microsoft.com
[coc_contact]: mailto:opencode@microsoft.com
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq
[code_of_conduct]: https://opensource.microsoft.com/codeofconduct
