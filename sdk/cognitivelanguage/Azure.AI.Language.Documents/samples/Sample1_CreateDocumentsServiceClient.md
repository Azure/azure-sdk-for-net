# Create a documents client

This sample demonstrates how to create a `DocumentsServiceClient`. To get started, you'll need to create an Azure AI Language resource endpoint and an API key. See the [README](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/cognitivelanguage/Azure.AI.Language.Documents/README.md) for links and instructions.

Start by importing the namespace for the `DocumentsServiceClient` and related classes:

```C# Snippet:DocumentsServiceClient_Namespaces
```

To create a client, you need an endpoint and credential. These can be stored in an environment variable, configuration setting, or any way that works for your application.

## Create a client with an API key

```C# Snippet:DocumentsServiceClient_Create
```

## Create a client for a specific API version

```C# Snippet:CreateDocumentsServiceClientForSpecificApiVersion
```

## Create a client with Microsoft Entra ID

Install the `Azure.Identity` package if you want to use `DefaultAzureCredential`.

```C# Snippet:Conversation_Identity_Namespace
```

```C# Snippet:DocumentsServiceClient_CreateWithDefaultAzureCredential
```
