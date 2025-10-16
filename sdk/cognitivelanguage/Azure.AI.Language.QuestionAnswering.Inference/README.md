# Azure Inference client library for .NET

This section should give out brief introduction of the client library.

* First sentence: **Describe the service** briefly. You can usually use the first line of the service's docs landing page for this (Example: [Cosmos DB docs landing page](https://learn.microsoft.com/azure/cosmos-db/)).
* Next, add a **bulleted list** of the **most common tasks** supported by the package or library, prefaced with "Use the client library for [Product Name] to:". Then, provide code snippets for these tasks in the [Examples](#examples) section later in the document. Keep the task list short but include those tasks most developers need to perform with your package.

  [Source code](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/cognitivelanguage/Azure.AI.Language.QuestionAnswering.Inference/src) | [Package (NuGet)](https://www.nuget.org/packages/Azure.AI.Language.QuestionAnswering.Inference) | [API reference documentation](https://azure.github.io/azure-sdk-for-net) | [Product documentation](https://learn.microsoft.com/azure)

## Getting started

This section should include everything a developer needs to do to install and create their first client connection *very quickly*.

### Install the package

First, provide instruction for obtaining and installing the package or library. This section might include only a single line of code, like `dotnet add package package-name`, but should enable a developer to successfully install the package from NuGet, npm, or even cloning a GitHub repository.

Install the client library for .NET with [NuGet](https://www.nuget.org/ ):

```dotnetcli
dotnet add package Azure.AI.Language.QuestionAnswering.Inference --prerelease
```

### Prerequisites

Include a section after the install command that details any requirements that must be satisfied before a developer can [authenticate](#authenticate-the-client) and test all of the snippets in the [Examples](#examples) section. For example, for Cosmos DB:

> You must have an [Azure subscription](https://azure.microsoft.com/free/dotnet/) and [Cosmos DB account](https://learn.microsoft.com/azure/cosmos-db/account-overview) (SQL API). In order to take advantage of the C# 8.0 syntax, it is recommended that you compile using the [.NET Core SDK](https://dotnet.microsoft.com/download) 3.0 or higher with a [language version](https://learn.microsoft.com/dotnet/csharp/language-reference/configure-language-version#override-a-default) of `latest`.  It is also possible to compile with the .NET Core SDK 2.1.x using a language version of `preview`.

### Authenticate the client

If your library requires authentication for use, such as for Azure services, include instructions and example code needed for initializing and authenticating.

For example, include details on obtaining an account key and endpoint URI, setting environment variables for each, and initializing the client object.

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
[Mocking](https://learn.microsoft.com/dotnet/azure/sdk/unit-testing-mocking) |
[Client lifetime](https://devblogs.microsoft.com/azure-sdk/lifetime-management-and-thread-safety-guarantees-of-azure-sdk-net-clients/)
<!-- CLIENT COMMON BAR -->

## Examples

You can familiarize yourself with different APIs using [Samples](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/cognitivelanguage/Azure.AI.Language.QuestionAnswering.Inference/samples).

### <scenario>

You can create a client and call the client's `<operation>` method.

```C# Snippet:Azure_AI_Language_QuestionAnswering_Inference_Scenario
Console.WriteLine("Hello, world!");
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
[style-guide-msft]: https://learn.microsoft.com/style-guide/capitalization
[style-guide-cloud]: https://aka.ms/azsdk/cloud-style-guide
