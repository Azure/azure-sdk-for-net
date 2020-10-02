# Azure Schema Registry client library for .NET

Azure Schema Registry is a schema repository service hosted by Azure Event Hubs, providing schema storage, versioning, and management. The registry is leveraged by serializers to reduce payload size while describing payload structure with schema identifiers rather than full schemas.

## Getting started

### Install the package

Install the Azure Schema Registry client library for .NET with [NuGet][nuget]:

```bash
dotnet add package Azure.Data.SchemaRegistry --version 1.0.0-beta.1
```

### Prerequisites

* An [Azure subscription][azure_sub]
* An [Event Hubs namespace][event_hubs_namespace]

If you need to [create an Event Hubs namespace][create_event_hubs_namespace], you can use the Azure Portal or [Azure PowerShell][azure_powershell].

You can use Azure PowerShell to create the Event Hubs namespace with the following command:

```PowerShell
New-AzEventHubNamespace -ResourceGroupName myResourceGroup -NamespaceName namespace_name -Location eastus
```

### Authenticate the client

In order to interact with the Azure Schema Registry service, you'll need to create an instance of the [Schema Registry Client][schema_registry_client] class. To create this client, you'll need Azure resource credentials and the Event Hubs namespace hostname.

#### Get credentials

To acquire authenicated credentials and start interacting with Azure resources, please see the [quickstart guide here][quickstart_guide].

#### Get Event Hubs namespace hostname

The simpliest way is to use the [Azure portal][azure_portal] and navigate to your Event Hubs namespace. From the Overview tab, you'll see `Host name`. Copy the value from this field.

#### Create SchemaRegistryClient

Once you have the Azure resource credentials and the Event Hubs namespace hostname, you can create the [SchemaRegistryClient][schema_registry_client]. You'll also need the [Azure.Identity][azure_identity] package to create the credential.

```C# Snippet:SchemaRegistryCreateSchemaRegistryClient
string endpoint = "<event_hubs_namespace_hostname>";
var credentials = new ClientSecretCredential(
    "<tenant_id>",
    "<client_id>",
    "<client_secret>"
);
var client = new SchemaRegistryClient(endpoint, credentials);
```

## Key concepts

### Schemas

A schema has 6 components:
- Group Name: The name of the group of schemas in the Schema Registry instance.
- Schema Name: The name of the schema.
- Schema ID: The ID assigned by the Schema Registry instance for the schema.
- Serialization Type: The format used for serialization of the schema. For example, Avro.
- Schema Content: The string representation of the schema.
- Schema Version: The version assigned to the schema in the Schema Registry instance.

These components play different roles. Some are used as input into the operations and some are outputs. Currently, [SchemaProperties][schema_properties] only exposes those properties that are potential outputs that are used in SchemaRegistry operations. Those exposed properties are `Content` and `Id`.

## Examples

The following shows examples of what is available through the SchemaRegistryClient. There are both sync and async methods available for these client operations.

* [Register a schema](#register-a-schema)
* [Retrieve a schema ID](#retrieve-a-schema-id)
* [Retrieve a schema](#retrieve-a-schema)

### Register a schema

Register a schema to be stored in the Azure Schema Registry.

```C# Snippet:SchemaRegistryRegisterSchema
string schemaName = "<schema_name>";
string groupName = "<schema_group_name>";
SerializationType schemaType = SerializationType.Avro;
// Example schema's content
string schemaContent = @"
{
   ""type"" : ""record"",
    ""namespace"" : ""TestSchema"",
    ""name"" : ""Employee"",
    ""fields"" : [
    { ""name"" : ""Name"" , ""type"" : ""string"" },
    { ""name"" : ""Age"", ""type"" : ""int"" }
    ]
}";

Response<SchemaProperties> schemaProperties = client.RegisterSchema(groupName, schemaName, schemaType, schemaContent);
```

### Retrieve a schema ID

Retrieve a previously registered schema ID from the Azure Schema Registry.

```C# Snippet:SchemaRegistryRetrieveSchemaId
string schemaName = "<schema_name>";
string groupName = "<schema_group_name>";
SerializationType schemaType = SerializationType.Avro;
// Example schema's content
string schemaContent = @"
{
   ""type"" : ""record"",
    ""namespace"" : ""TestSchema"",
    ""name"" : ""Employee"",
    ""fields"" : [
    { ""name"" : ""Name"" , ""type"" : ""string"" },
    { ""name"" : ""Age"", ""type"" : ""int"" }
    ]
}";

Response<SchemaProperties> schemaProperties = client.GetSchemaId(groupName, schemaName, schemaType, schemaContent);
string schemaId = schemaProperties.Value.Id;
```

### Retrieve a schema

Retrieve a previously registered schema's content from the Azure Schema Registry.

```C# Snippet:SchemaRegistryRetrieveSchema
string schemaId = "<schema_id>";

Response<SchemaProperties> schemaProperties = client.GetSchema(schemaId);
string schemaContent = schemaProperties.Value.Content;
```

## Troubleshooting

Information on troubleshooting steps will be provided as potential issues are discovered.

## Next steps

See [Azure Schema Registry][azure_schema_registry] for additional information.

## Contributing

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit [cla.microsoft.com][cla].

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (e.g., label, comment). Simply follow the instructions provided by the bot. You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct][code_of_conduct]. For more information see the [Code of Conduct FAQ][code_of_conduct_faq] or contact [opencode@microsoft.com][email_opencode] with any additional questions or comments.

![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net%2Fsdk%2Ftemplate%2FAzure.Template%2FREADME.png)

<!-- LINKS -->
[nuget]: https://www.nuget.org/
[event_hubs_namespace]: https://docs.microsoft.com/azure/event-hubs/event-hubs-about
[azure_powershell]: https://docs.microsoft.com/powershell/azure/
[create_event_hubs_namespace]: https://docs.microsoft.com/azure/event-hubs/event-hubs-quickstart-powershell#create-an-event-hubs-namespace
[quickstart_guide]: https://github.com/Azure/azure-sdk-for-net/blob/master/doc/mgmt_preview_quickstart.md
[schema_registry_client]: https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/schemaregistry/Azure.Data.SchemaRegistry/src/SchemaRegistryClient.cs
[azure_portal]: https://ms.portal.azure.com/
[schema_properties]: https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/schemaregistry/Azure.Data.SchemaRegistry/src/SchemaProperties.cs
[azure_identity]: https://www.nuget.org/packages/Azure.Identity
[cla]: https://cla.microsoft.com
[code_of_conduct]: https://opensource.microsoft.com/codeofconduct/
[code_of_conduct_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[email_opencode]: mailto:opencode@microsoft.com
[azure_sub]: https://azure.microsoft.com/free/
[azure_schema_registry]: https://aka.ms/schemaregistry
