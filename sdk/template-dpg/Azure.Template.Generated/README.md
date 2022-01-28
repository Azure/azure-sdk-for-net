# README.md template

Use the guidelines in each section of this template to ensure consistency and readability of your README. The README resides in your package's GitHub repository at the root of its directory within the repo. It's also used as the package distribution page (NuGet) and as a Quickstart on docs.microsoft.com. See [Azure.Template.Generated/README.md](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/template-dpg/Azure.Template.Generated/README.md) for an example following this template.

**Title**: The H1 of your README should be in the format: `# [Product Name] client library for [Language]`

* All headings, including the H1, should use **sentence-style capitalization**. Refer to the [Microsoft Style Guide][style-guide-msft] and [Microsoft Cloud Style Guide][style-guide-cloud] for more information.
* Example: `# Azure Batch client library for .NET`

# Azure Template client library for .NET

**Introduction**: The introduction appears directly under the title (H1) of your README.

* **DO NOT** use an "Introduction" or "Overview" heading (H2) for this section.
* First sentence: **Describe the service** briefly. You can usually use the first line of the service's docs landing page for this (Example: [Cosmos DB docs landing page](https://docs.microsoft.com/azure/cosmos-db/)).
* Next, add a **bulleted list** of the **most common tasks** supported by the package or library, prefaced with "Use the client library for [Product Name] to:". Then, provide code snippets for these tasks in the [Examples](#examples) section later in the document. Keep the task list short but include those tasks most developers need to perform with your package.
* Include this single line of links targeting your product's content at the bottom of the introduction, making any adjustments as necessary:

  [Source code](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/template-dpg/Azure.Template.Generated/src) | [Package (NuGet)](https://www.nuget.org/packages/Azure.AI.AnomalyDetector) | [API reference documentation](https://azure.github.io/azure-sdk-for-net/anomalydetector.html) | [Product documentation](https://docs.microsoft.com/azure/cognitive-services/anomaly-detector/)

> TIP: Your README should be as **brief** as possible but **no more brief** than necessary to get a developer new to Azure, the service, or the package up and running quickly. Keep it brief, but include everything a developer needs to make their first API call successfully.

## Getting started

This section should include everything a developer needs to do to install and create their first client connection *very quickly*.

### Install the package

First, provide instruction for obtaining and installing the package or library. This section might include only a single line of code, like `dotnet add package package-name`, but should enable a developer to successfully install the package from NuGet, npm, or even cloning a GitHub repository.

### Prerequisites

Include a section after the install command that details any requirements that must be satisfied before a developer can [authenticate](#authenticate-the-client) and test all of the snippets in the [Examples](#examples) section. For example, for Cosmos DB:

> You must have an [Azure subscription](https://azure.microsoft.com/free/dotnet/) and [Cosmos DB account](https://docs.microsoft.com/azure/cosmos-db/account-overview) (SQL API). In order to take advantage of the C# 8.0 syntax, it is recommended that you compile using the [.NET Core SDK](https://dotnet.microsoft.com/download) 3.0 or higher with a [language version](https://docs.microsoft.com/dotnet/csharp/language-reference/configure-language-version#override-a-default) of `latest`.  It is also possible to compile with the .NET Core SDK 2.1.x using a language version of `preview`.

### Authenticate the client

If your library requires authentication for use, such as for Azure services, include instructions and example code needed for initializing and authenticating.

For example, include details on obtaining an account key and endpoint URI, setting environment variables for each, and initializing the client object.

```C# Snippet:TemplateServiceAuthenticate
var serviceClient = new TemplateServiceClient(new Uri(endpoint), new DefaultAzureCredential());
```

## Key concepts

The *Key concepts* section should describe the functionality of the main classes. Point out the most important and useful classes in the package (with links to their reference pages) and explain how those classes work together. Feel free to use bulleted lists, tables, code blocks, or even diagrams for clarity.

Include the *Thread safety* and *Additional concepts* sections below at the end of your *Key concepts* section. You may remove or add links depending on what your library makes use of:

### Thread safety
We guarantee that all client instance methods are thread-safe and independent of each other ([guideline](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-service-methods-thread-safety)). This ensures that the recommendation of reusing client instances is always safe, even across threads.

### Additional concepts
<!-- CLIENT COMMON BAR -->
[Client options](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#configuring-service-clients-using-clientoptions) |
[Accessing the response](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#accessing-http-response-details-using-responset) |
[Long-running operations](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#consuming-long-running-operations-using-operationt) |
[Handling failures](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#reporting-errors-requestfailedexception) |
[Diagnostics](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Diagnostics.md) |
[Mocking](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#mocking) |
[Client lifetime](https://devblogs.microsoft.com/azure-sdk/lifetime-management-and-thread-safety-guarantees-of-azure-sdk-net-clients/)
<!-- CLIENT COMMON BAR -->

## Examples

Include code snippets and short descriptions for each task you listed in the [Introduction](#introduction) (the bulleted list). Briefly explain each operation, but include enough clarity to explain complex or otherwise tricky operations.

If possible, use the same example snippets that your in-code documentation uses. For example, use the snippets in your `samples`. The `sample` file containing the snippets should reside alongside your package's code, and should be tested in an automated fashion. Please refer [this](https://github.com/Azure/azure-sdk-for-net/blob/main/CONTRIBUTING.md#updating-sample-snippets) doc to know more about snippets.

Each example in the *Examples* section starts with an H3 that describes the example. At the top of this section, just under the *Examples* H2, add a bulleted list linking to each example H3. Each example should deep-link to the types and/or members used in the example.

* [Create resource](#create-resource)
* [Get resource](#get-resource)
* [List resources](#list-resources)
* [Delete resource](#delete-resource)

### Create resource

Use the `Create` method to create a resource.

```C# Snippet:CreateResource
var client = GetClient();
var resource = new
{
    name = "TemplateResource",
    id = "123",
};
Response response = await client.CreateAsync(RequestContent.Create(resource));
using JsonDocument resourceJson = JsonDocument.Parse(response.Content.ToMemory());
string resourceName = resourceJson.RootElement.GetProperty("name").ToString();
string resourceId = resourceJson.RootElement.GetProperty("id").ToString();
Console.WriteLine($"Name: {resourceName} \n Id: {resourceId}.");
```

### Get resource

The `Get` method retrieves a data from the service. The `id` parameter is the unique ID of the resource.

```C# Snippet:RetrieveResource
var client = GetClient();
var response = await client.GetResourceAsync("123");
using JsonDocument resourceJson = JsonDocument.Parse(response.Content.ToMemory());
string resourceName = resourceJson.RootElement.GetProperty("name").ToString();
string resourceId = resourceJson.RootElement.GetProperty("id").ToString();
Console.WriteLine($"Name: {resourceName} \n Id: {resourceId}.");
```

### List resources

The `GetResources` method retrieves the list of resources from the service.

```C# Snippet:ListResources
var client = GetClient();
AsyncPageable<BinaryData> pageable = client.GetResourcesAsync();
await foreach (var page in pageable.AsPages())
{
    foreach (var resourceBinaryData in page.Values)
    {
        using JsonDocument resourceJson = JsonDocument.Parse(resourceBinaryData.ToMemory());
        Console.WriteLine(resourceJson.RootElement.GetProperty("name").ToString());
        Console.WriteLine(resourceJson.RootElement.GetProperty("id").ToString());
    }
}
```

### Delete resource

The `Delete` method deletes the resource from the service.

```C# Snippet:DeleteResource
var client = GetClient();
await client.DeleteAsync("123");
```

## Troubleshooting

Describe common errors and exceptions, how to "unpack" them if necessary, and include guidance for graceful handling and recovery.

Provide information to help developers avoid throttling or other service-enforced errors they might encounter. For example, provide guidance and examples for using retry or connection policies in the API.

If the package or a related package supports it, include tips for logging or enabling instrumentation to help them debug their code.

## Next steps

* Provide a link to additional code examples, ideally to those sitting alongside the README in the package's `/samples` directory.
* If appropriate, point users to other packages that might be useful.
* If you think there's a good chance that developers might stumble across your package in error (because they're searching for specific functionality and mistakenly think the package provides that functionality), point them to the packages they might be looking for.

## Contributing

This is a template, but your SDK readme should include details on how to contribute code to the repo/package.

<!-- LINKS -->
[style-guide-msft]: https://docs.microsoft.com/style-guide/capitalization
[style-guide-cloud]: https://aka.ms/azsdk/cloud-style-guide

![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net%2Fsdk%2Ftemplate%2FAzure.Template%2FREADME.png)
