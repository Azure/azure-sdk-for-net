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
description: Sample that illustrates using blob and event hub clients along with ASP.NET Core integration, distributed tracing and hosted services.
---


# Configuration

To run the sample set the following configuration properties using manage user secrets command in VS or user secrets command line https://docs.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-2.2&tabs=windows#set-a-secret

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