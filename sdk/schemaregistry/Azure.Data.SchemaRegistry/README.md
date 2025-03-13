# Azure Schema Registry client library for .NET

Azure Schema Registry is a schema repository service hosted by Azure Event Hubs, providing schema storage, versioning, and management. The registry is leveraged by serializers to reduce payload size while describing payload structure with schema identifiers rather than full schemas.

## Getting started

### Install the package

Install the Azure Schema Registry client library for .NET with [NuGet][nuget]:

```dotnetcli
dotnet add package Azure.Data.SchemaRegistry
```

### Prerequisites

* An [Azure subscription][azure_sub]
* An [Event Hubs namespace][event_hubs_namespace]
* A [Schema Group][create_schema_group] of the correct serialization type

If you need to [create an Event Hubs namespace][create_event_hubs_namespace], you can use the Azure Portal or [Azure PowerShell][azure_powershell].

You can use Azure PowerShell to create the Event Hubs namespace with the following command:

```PowerShell
New-AzEventHubNamespace -ResourceGroupName myResourceGroup -NamespaceName namespace_name -Location eastus
```

### Authenticate the client

In order to interact with the Azure Schema Registry service, you'll need to create an instance of the [Schema Registry Client][schema_registry_client] class. To create this client, you'll need Azure resource credentials and the Event Hubs namespace hostname.

#### Get credentials

To acquire authenticated credentials and start interacting with Azure resources, please see the [getting started with Azure Identity guide][quickstart_guide].

#### Get Event Hubs namespace hostname

The simplest way is to use the [Azure portal][azure_portal] and navigate to your Event Hubs namespace. From the Overview tab, you'll see `Host name`. Copy the value from this field.

#### Create SchemaRegistryClient

Once you have the Azure resource credentials and the Event Hubs namespace hostname, you can create the [SchemaRegistryClient][schema_registry_client]. You'll also need the [Azure.Identity][azure_identity] package to create the credential.

```C# Snippet:SchemaRegistryCreateSchemaRegistryClient
// Create a new SchemaRegistry client using the default credential from Azure.Identity using environment variables previously set,
// including AZURE_CLIENT_ID, AZURE_CLIENT_SECRET, and AZURE_TENANT_ID.
// For more information on Azure.Identity usage, see: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md
string fullyQualifiedNamespace = "{hostname}.servicebus.windows.net";
var client = new SchemaRegistryClient(fullyQualifiedNamespace: fullyQualifiedNamespace, credential: new DefaultAzureCredential());
```

## Key concepts

### Schemas

A schema has 6 components:
- Group Name: The name of the group of schemas in the Schema Registry instance.
- Schema Name: The name of the schema.
- Schema ID: The ID assigned by the Schema Registry instance for the schema.
- Schema Format: The format used for serialization of the schema. For example, Avro.
- Schema Content: The string representation of the schema.
- Schema Version: The version assigned to the schema in the Schema Registry instance.

These components play different roles. Some are used as input into the operations and some are outputs. Currently, [SchemaProperties][schema_properties] only exposes those properties that are potential outputs that are used in SchemaRegistry operations. Those exposed properties are `Content` and `Id`.

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

The following shows examples of what is available through the `SchemaRegistryClient`. There are both sync and async methods available for these client operations.

* [Register a schema](#register-a-schema)
* [Retrieve a schema ID](#retrieve-a-schema-id)
* [Retrieve a schema](#retrieve-a-schema)

### Register a schema

Register a schema to be stored in the Azure Schema Registry.

```C# Snippet:SchemaRegistryRegisterSchema
string groupName = "<schema_group_name>";
string name = "employeeSample";
SchemaFormat format = SchemaFormat.Avro;
// Example schema's definition
string definition = @"
{
   ""type"" : ""record"",
    ""namespace"" : ""TestSchema"",
    ""name"" : ""Employee"",
    ""fields"" : [
    { ""name"" : ""Name"" , ""type"" : ""string"" },
    { ""name"" : ""Age"", ""type"" : ""int"" }
    ]
}";

Response<SchemaProperties> schemaProperties = client.RegisterSchema(groupName, name, definition, format);
```

### Retrieve a schema ID

Retrieve a previously registered schema ID from the Azure Schema Registry.

```C# Snippet:SchemaRegistryRetrieveSchemaId
string groupName = "<schema_group_name>";
string name = "employeeSample";
SchemaFormat format = SchemaFormat.Avro;
// Example schema's content
string content = @"
{
   ""type"" : ""record"",
    ""namespace"" : ""TestSchema"",
    ""name"" : ""Employee"",
    ""fields"" : [
    { ""name"" : ""Name"" , ""type"" : ""string"" },
    { ""name"" : ""Age"", ""type"" : ""int"" }
    ]
}";

SchemaProperties schemaProperties = client.GetSchemaProperties(groupName, name, content, format);
string schemaId = schemaProperties.Id;
```

### Retrieve a schema

Retrieve a previously registered schema's content from the Azure Schema Registry with either a schema ID or the group name, schema name, and version.

```C# Snippet:SchemaRegistryRetrieveSchema
var schemaId = "<schema_id>";
SchemaRegistrySchema schema = client.GetSchema(schemaId);
string definition = schema.Definition;
```

```C# Snippet:SchemaRegistryRetrieveSchemaVersion
string groupName = "<schema_group_name>";
string name = "<schema_id>";
int version = 1;
SchemaRegistrySchema schema = client.GetSchema(groupName, name, version);
string definition = schema.Definition;
```

## Troubleshooting

Information on troubleshooting steps will be provided as potential issues are discovered.

## Next steps

See [Azure Schema Registry][azure_schema_registry] for additional information.

## Contributing

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit [cla.microsoft.com][cla].

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (e.g., label, comment). Simply follow the instructions provided by the bot. You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct][code_of_conduct]. For more information see the [Code of Conduct FAQ][code_of_conduct_faq] or contact [opencode@microsoft.com][email_opencode] with any additional questions or comments.

<!-- LINKS -->
[nuget]: https://www.nuget.org/
[event_hubs_namespace]: https://learn.microsoft.com/azure/event-hubs/event-hubs-about
[create_schema_group]: https://learn.microsoft.com/azure/event-hubs/create-schema-registry#create-a-schema-group
[azure_powershell]: https://learn.microsoft.com/powershell/azure/
[create_event_hubs_namespace]: https://learn.microsoft.com/azure/event-hubs/event-hubs-quickstart-powershell#create-an-event-hubs-namespace
[quickstart_guide]: https://learn.microsoft.com/dotnet/api/overview/azure/identity-readme?view=azure-dotnet
[schema_registry_client]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/schemaregistry/Azure.Data.SchemaRegistry/src/SchemaRegistryClient.cs
[azure_portal]: https://ms.portal.azure.com/
[schema_properties]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/schemaregistry/Azure.Data.SchemaRegistry/src/SchemaProperties.cs
[azure_identity]: https://www.nuget.org/packages/Azure.Identity
[cla]: https://cla.microsoft.com
[code_of_conduct]: https://opensource.microsoft.com/codeofconduct/
[code_of_conduct_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[email_opencode]: mailto:opencode@microsoft.com
[azure_sub]: https://azure.microsoft.com/free/dotnet/
[azure_schema_registry]: https://aka.ms/schemaregistry
