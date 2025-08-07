# Get Type Defintion By Type Name

This sample demonstrates how to call type related API using `TypeDefinitionClient`.

## Create a DataMapClient

First we need to create the DataMapClient using `Azure.Identity`.

The [Azure Identity library](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/identity/Azure.Identity/README.md) provides [role-based access control](https://learn.microsoft.com/azure/role-based-access-control/overview) support for authentication using Azure Active Directory.In order to leverage role-based access control for Service Bus, please refer to the [role-based access control documentation](https://learn.microsoft.com/azure/service-bus-messaging/service-bus-role-based-access-control). The simplest way to get started using the `Azure.Identity` library is to use the [DefaultAzureCredential](https://learn.microsoft.com/dotnet/api/azure.identity.defaultazurecredential?view=azure-dotnet).

```C# Snippet:CreateDataMapClient
Uri endpoint = TestEnvironment.Endpoint;
TokenCredential credential = new DefaultAzureCredential();
DataMapClient dataMapClient = new DataMapClient(endpoint, credential);
```

## Get Type By Name

```C# Snippet:GetTypeByName
TypeDefinition client = dataMapClient.GetTypeDefinitionClient();
Response response = client.GetByName("AtlasGlossary", null);
```