# Introduction

Introduction to Time Series Insights.

# Time Series Insights Samples

You can explore the time series insights APIs (using the client library) using the samples project.

## Creating the time series insights client

To create a new time series insights client, you need the endpoint to an Azure Time Series Insights instance and supply credentials.
In the sample below, you can set `TsiEndpoint`, `TenantId`, `ClientId`, and `ClientSecret` as command-line arguments.
The client requires an instance of [TokenCredential](https://docs.microsoft.com/dotnet/api/azure.core.tokencredential?view=azure-dotnet).
In this samples, we illustrate how to use one derived class: ClientSecretCredential.

```C# Snippet:TimeSeriesInsightsSampleCreateServiceClientWithClientSecret
// DefaultAzureCredential supports different authentication mechanisms and determines the appropriate credential type based of the environment it is executing in.
// It attempts to use multiple credential types in an order until it finds a working credential.
var tokenCredential = new DefaultAzureCredential();

var client = new TimeSeriesInsightsClient(
    tsiEndpoint,
    tokenCredential);
```

