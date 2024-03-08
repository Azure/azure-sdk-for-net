# Authenticate the client

This sample demonstrates how to authenticate the `DataMapClient`, which is the starting point for all interactions with the Data Map client library.

## Authenticate with Azure.Identity

The [Azure Identity library](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/identity/Azure.Identity/README.md) provides [role-based access control](https://docs.microsoft.com/azure/role-based-access-control/overview) support for authentication using Azure Active Directory.In order to leverage role-based access control for Service Bus, please refer to the [role-based access control documentation](https://docs.microsoft.com/azure/service-bus-messaging/service-bus-role-based-access-control). The simplest way to get started using the `Azure.Identity` `library is to use the [DefaultAzureCredential](https://learn.microsoft.com/dotnet/api/azure.identity.defaultazurecredential?view=azure-dotnet).

```C# Snippet:DataMapAuthAAD
// Create a DataMapClient that will authenticate through Active Directory
Uri endpoint = new Uri("<https://accountName.purview.azure.com>");
TokenCredential credential = new DefaultAzureCredential();
DataMapClient dataMapClient = new DataMapClient(endpoint, credential);
```