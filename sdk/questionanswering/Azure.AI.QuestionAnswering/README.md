# Azure Question Answering client library for .NET

Azure Question Answering (formerly QnA Maker) is a cloud-based Natural Language Processing (NLP) service that allows you to create a natural conversational layer over your data. It is used to find the most appropriate answer for any input from your custom knowledge base (KB) of information.

The Azure Question Answering client library allows you to ask questions against a knowledge base and, if the knowledge base is configured accordingly, ask follow up questions.

> [!NOTE]
> This README content is incomplete.

## Getting started

This section should include everything a developer needs to do to install and create their first client connection *very quickly*.

### Install the package

First, provide instruction for obtaining and installing the package or library. This section might include only a single line of code, like `pip install package-name`, but should enable a developer to successfully install the package from NuGet, pip, npm, Maven, or even cloning a GitHub repository.

### Prerequisites

Include a section after the install command that details any requirements that must be satisfied before a developer can [authenticate](#authenticate-the-client) and test all of the snippets in the [Examples](#examples) section. For example, for Cosmos DB:

> You must have an [Azure subscription](https://azure.microsoft.com/free/), [Cosmos DB account](https://docs.microsoft.com/azure/cosmos-db/account-overview) (SQL API), and [Python 3.6+](https://www.python.org/downloads/) to use this package.

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
[Client options](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/core/Azure.Core/README.md#configuring-service-clients-using-clientoptions) |
[Accessing the response](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/core/Azure.Core/README.md#accessing-http-response-details-using-responset) |
[Long-running operations](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/core/Azure.Core/README.md#consuming-long-running-operations-using-operationt) |
[Handling failures](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/core/Azure.Core/README.md#reporting-errors-requestfailedexception) |
[Diagnostics](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/core/Azure.Core/samples/Diagnostics.md) |
[Mocking](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/core/Azure.Core/README.md#mocking) |
[Client lifetime](https://devblogs.microsoft.com/azure-sdk/lifetime-management-and-thread-safety-guarantees-of-azure-sdk-net-clients/)
<!-- CLIENT COMMON BAR -->

## Examples

Include code snippets and short descriptions for each task you listed in the [Introduction](#introduction) (the bulleted list). Briefly explain each operation, but include enough clarity to explain complex or otherwise tricky operations.

If possible, use the same example snippets that your in-code documentation uses. For example, use the snippets in your `examples.py` that Sphinx ingests via its [literalinclude](https://www.sphinx-doc.org/en/1.5/markup/code.html?highlight=code%20examples#includes) directive. The `examples.py` file containing the snippets should reside alongside your package's code, and should be tested in an automated fashion.

Each example in the *Examples* section starts with an H3 that describes the example. At the top of this section, just under the *Examples* H2, add a bulleted list linking to each example H3. Each example should deep-link to the types and/or members used in the example.

* [Create the thing](#create-the-thing)
* [Get the thing](#get-the-thing)
* [List the things](#list-the-things)

### Create the thing

Use the `create_thing` method to create a Thing reference; this method does not make a network call. To persist the Thing in the service, call `Thing.save`.

```Python
thing = client.create_thing(id, name)
thing.save()
```

### Get the thing

The `get_thing` method retrieves a Thing from the service. The `id` parameter is the unique ID of the Thing, not its "name" property.

```C# Snippet:GetSecret
var client = new MiniSecretClient(new Uri(endpoint), new DefaultAzureCredential());

SecretBundle secret = client.GetSecret("TestSecret");

Console.WriteLine(secret.Value);
```Python
things = client.list_things()
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

![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net%2Fsdk%2Fquestionanswering%2FAzure.AI.QuestionAnswering%2FREADME.png)
