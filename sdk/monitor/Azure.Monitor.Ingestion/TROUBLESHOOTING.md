# Troubleshooting Azure Monitor Ingestion client library issues

This troubleshooting guide contains instructions to diagnose frequently encountered issues while using the Azure Monitor Ingestion client library for .NET.

## Table of contents

* [General troubleshooting](#general-troubleshooting)
    * [Enable client logging](#enable-client-logging)
* [Troubleshooting logs ingestion](#troubleshooting-logs-ingestion)
    * [Troubleshooting authorization errors](#troubleshooting-authorization-errors)
    * [Troubleshooting missing logs](#troubleshooting-missing-logs)
    * [Troubleshooting slow logs upload](#troubleshooting-slow-logs-upload)

## General troubleshooting

### Enable client logging

To troubleshoot issues with the library, first enable logging to monitor the behavior of the application. The errors and warnings in the logs generally provide useful insights into what went wrong and sometimes include corrective actions to fix issues.

This library uses the standard [logging](https://learn.microsoft.com/dotnet/azure/sdk/logging) library. Basic information about HTTP requests and responses, such as URIs and headers, is logged at the `INFO` level.

The simplest way to see the logs is to enable console logging. To create an Azure SDK log listener that outputs messages to the console, use the [AzureEventSourceListener.CreateConsoleLogger](https://learn.microsoft.com/dotnet/api/azure.core.diagnostics.azureeventsourcelistener.createconsolelogger?view=azure-dotnet) method:

```csharp
using Azure.Core.Diagnostics;

// set up a listener to monitor logged events
using AzureEventSourceListener listener = AzureEventSourceListener.CreateConsoleLogger();
```

## Troubleshooting logs ingestion

### Troubleshooting authorization errors

If you get an error with HTTP status code 403 (Forbidden), it means that the provided credentials have insufficient permissions to upload logs to the specified Data Collection Endpoint (DCE) and Data Collection Rule (DCR) ID.

```text
Status code 403, "{"error":{"code":"OperationFailed","message":"The 
authentication token provided does not have access to ingest data for the data collection rule with immutable Id 
'<REDACTED>' PipelineAccessResult: AccessGranted: False, IsRbacPresent: False, IsDcrDceBindingValid: , DcrArmId: <REDACTED>,
 Message: Required authorization action was not found for tenantId <REDACTED> objectId <REDACTED> on resourceId <REDACTED>
 ConfigurationId: <REDACTED>.."}}"
```

1. Check that the application or user making the request has sufficient permissions:
   * See this document to [manage access to DCR](https://learn.microsoft.com/azure/azure-monitor/logs/tutorial-logs-ingestion-portal#assign-permissions-to-the-dcr).
   * To ingest logs, ensure the service principal is assigned the **Monitoring Metrics Publisher** role for the DCR.
1. If the user or application is granted sufficient privileges to upload logs, ensure you're authenticating as that user/application. If you're authenticating using the [DefaultAzureCredential](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md#defaultazurecredential), check the logs to verify that the credential used is the one you expected. To enable logging, see the [Enable client logging](#enable-client-logging) section.
1. The permissions may take up to 30 minutes to propagate. If the permissions were granted recently, retry after some time.

### Troubleshooting missing logs

When you send logs to Azure Monitor for ingestion, the request may succeed, but you may not see the data appear in the designated Log Analytics workspace table as configured in the DCR. To investigate and resolve this issue, ensure the following:

* Double-check that you're using the correct DCE when configuring the `LogsIngestionClient`. Using the wrong endpoint can result in data not being properly sent to the Log Analytics workspace.

* Make sure you provide the correct DCR ID to the `Upload` method. The DCR ID is an immutable identifier that determines the transformation rules applied to the uploaded logs and directs them to the appropriate Log Analytics workspace table.

* Verify that the custom table specified in the DCR exists in the Log Analytics workspace. Ensure that you provide the accurate name of the custom table to the upload method. Mismatched table names can lead to logs not being stored correctly.

* Confirm that the logs you're sending adhere to the format expected by the DCR. The data should be in the form of a JSON object or array, structured according to the requirements specified in the DCR. Additionally, it's essential to encode the request body in UTF-8 to avoid any data transmission issues.

* Keep in mind that data ingestion may take some time, especially if you're sending data to a specific table for the first time. In such cases, allow up to 15 minutes for the data to be fully ingested and available for querying and analysis.

### Troubleshooting slow logs upload

If you experience delays when uploading logs, it could be due to reaching service limits, which may trigger the rate limiter to throttle your client. To determine if your client has reached service limits, you can enable logging and check if the service is returning errors with an HTTP status code 429. For more information on service limits, see the [Azure Monitor service limits documentation](https://learn.microsoft.com/azure/azure-monitor/service-limits#logs-ingestion-api).

To enable client logging and to troubleshoot this issue further, see the instructions provided in the section titled [Enable client logging](#enable-client-logging).

If there are no throttling errors, then consider increasing the concurrency to upload multiple log requests in parallel. To set the concurrency, use the `UploadLogsOptions.MaxConcurrency` property.

```C# Snippet:UploadWithMaxConcurrency
var endpoint = new Uri("<data_collection_endpoint_uri>");
var ruleId = "<data_collection_rule_id>";
var streamName = "<stream_name>";

var credential = new DefaultAzureCredential();
var client = new LogsIngestionClient(endpoint, credential);

DateTimeOffset currentTime = DateTimeOffset.UtcNow;

var entries = new List<object>();
for (int i = 0; i < 100; i++)
{
    entries.Add(
        new {
            Time = currentTime,
            Computer = "Computer" + i.ToString(),
            AdditionalContext = i
        }
    );
}
// Set concurrency in LogsUploadOptions
var options = new LogsUploadOptions
{
    MaxConcurrency = 10
};

// Upload our logs
Response response = client.Upload(ruleId, streamName, entries, options);
```