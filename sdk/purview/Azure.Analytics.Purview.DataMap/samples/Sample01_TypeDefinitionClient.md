# Type Definition Client

This sample demonstrates how to call type related API using `TypeDefinitionClient`.

## Get Type Defintion By Type Name

Before getting typeDefinitionClient, check [Authenticate the client](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/purview/Azure.Analytics.Purview.DataMap/samples/Sample00_AuthenticateClient.md) to create DataMapClient.

```C# Snippet:DataMapGetTypeByName
TypeDefinition client = dataMapClient.GetTypeDefinitionClient();
Response<AtlasTypeDef> response = client.GetByName("AtlasGlossary");
```