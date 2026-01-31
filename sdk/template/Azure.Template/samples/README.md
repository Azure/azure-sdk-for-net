---
page_type: sample
languages:
- csharp
products:
# Including relevant stubs from https://review.learn.microsoft.com/help/contribute/metadata-taxonomies#product
- azure
name: Azure.Template samples for .NET
description: Samples for the Azure.Template client library.
---

# Azure.Template Samples

This template demonstrates a complete TypeSpec-generated Azure SDK with the Widget Analytics service as an example.

## Prerequisites

To use these samples, you'll first need to set up resources. See [getting started](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/template/Azure.Template/README.md#getting-started) for details.

## Install the package

```C# Snippet:Azure_Template
using Azure.Identity;
```

## Getting Widgets

You can create a client and call the client's `GetWidgets` method:

```C# Snippet:Azure_Template_GetWidgets
string endpoint = "https://your-service-endpoint";
var credential = new DefaultAzureCredential();
var client = new WidgetAnalyticsClient(new Uri(endpoint), credential);
AzureWidgets widgetsClient = client.GetAzureWidgetsClient();

// List all widgets
foreach (WidgetSuite widget in widgetsClient.GetWidgets())
{
    Console.WriteLine($"Widget: {widget.ManufacturerId}");
}
```

## Getting Widgets Asynchronously

You can also call the `GetWidgetsAsync` method to list widgets asynchronously:

```C# Snippet:Azure_Template_GetWidgetsAsync
string endpoint = "https://your-service-endpoint";
var credential = new DefaultAzureCredential();
var client = new WidgetAnalyticsClient(new Uri(endpoint), credential);
AzureWidgets widgetsClient = client.GetAzureWidgetsClient();

// List all widgets asynchronously
await foreach (WidgetSuite widget in widgetsClient.GetWidgetsAsync())
{
    Console.WriteLine($"Widget: {widget.ManufacturerId}");
}
```
