---
page_type: sample
languages:
- csharp
products:
- azure
- azure-storage
- azure-event-hubs
urlFragment: line-counter
name: LineCounter
description: Sample that illustrates using Storage and Event Hubs clients along with ASP.NET Core integration, distributed tracing and hosted services.
---

# LineCounter
This is a sample app that illustrates using Storage and Event Hubs clients along with ASP.NET Core integration, distributed tracing and hosted services.
It allows users to upload a file to a blob, which triggers an Event Hubs event containing the file name. 
The Event Hubs Processor receives the event, and then the app downloads the blob and counts the number of lines in the file.

# Configuration

To run the sample set the following configuration properties using manage user secrets command in VS or user secrets command line https://docs.microsoft.com/aspnet/core/security/app-secrets?view=aspnetcore-2.2&tabs=windows#set-a-secret

``` json
{
  "Blob": {
    "connectionString": "..."
  },
  "Uploads": {
    "connectionString": "...",
    "eventHubName": "..."
  },
  "Results": {
    "connectionString": "...",
    "eventHubName": "..."
  }
}
```

To light up App Insights, add the InstrumentationKey key and value to the ApplicationInsights node in appsettings.json

``` json
{
  "ApplicationInsights": {
    "InstrumentationKey": "..."
  }
}
```
