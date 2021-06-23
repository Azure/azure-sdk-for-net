# Azure Schema Registry Apache Avro client library for .NET

Azure Schema Registry is a schema repository service hosted by Azure Event Hubs, providing schema storage, versioning, and management. This package provides an Avro serializer capable of serializing and deserializing payloads containing Schema Registry schema identifiers and Avro-encoded data.

## Getting started

### Install the package

Install the Azure Schema Registry Apache Avro library for .NET with [NuGet][nuget]:

```bash
dotnet add package Microsoft.Azure.Data.SchemaRegistry.ApacheAvro --version 1.0.0-beta.1
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

```C# Snippet:SchemaRegistryAvroCreateSchemaRegistryClient
// Create a new SchemaRegistry client using the default credential from Azure.Identity using environment variables previously set,
// including AZURE_CLIENT_ID, AZURE_CLIENT_SECRET, and AZURE_TENANT_ID.
// For more information on Azure.Identity usage, see: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md
var schemaRegistryClient = new SchemaRegistryClient(endpoint: endpoint, credential: new DefaultAzureCredential());
```

## Key concepts

### ObjectSerializer

This library provides a serializer, [SchemaRegistryAvroObjectSerializer][schema_registry_avro_serializer], that implements the [ObjectSerializer][object_serializer] abstract class. This allows a developer to use this serializer in any .NET Azure SDKs that utilize ObjectSerializer. The SchemaRegistryAvroObjectSerializer utilitizes a SchemaRegistryClient to construct messages using a wire format containing schema information such as a schema ID.

This serializer requires the [Apache Avro library][apache_avro_library]. The payload types accepted by this serializer include [GenericRecord][generic_record] and [ISpecificRecord][specific_record].

### Wire Format

The serializer in this library creates messages in a wire format. The format is the following:

- Bytes [0-3] – record format indicator – currently is \x00\x00\x00\x00
- Bytes [4-35] – UTF-8 GUID, identifying the schema in a Schema Registry instance
- Bytes [36-end] – serialized payload bytes

## Examples

The following shows examples of what is available through the SchemaRegistryAvroObjectSerializer. There are both sync and async methods available for these operations. These examples use a generated Apache Avro class [Employee.cs][employee] created using this schema:

```json
{
   "type" : "record",
    "namespace" : "TestSchema",
    "name" : "Employee",
    "fields" : [
        { "name" : "Name" , "type" : "string" },
        { "name" : "Age", "type" : "int" }
    ]
}
```

Details on generating a class using the Apache Avro library can be found in the [Avro C# Documentation][avro_csharp_documentation].

* [Serialize](#serialize)
* [Deserialize](#deserialize)

### Serialize

Register a schema to be stored in the Azure Schema Registry.

```C# Snippet:SchemaRegistryAvroSerialize
var employee = new Employee { Age = 42, Name = "John Doe" };

using var memoryStream = new MemoryStream();
var serializer = new SchemaRegistryAvroObjectSerializer(schemaRegistryClient, groupName, new SchemaRegistryAvroObjectSerializerOptions { AutoRegisterSchemas = true });
serializer.Serialize(memoryStream, employee, typeof(Employee), CancellationToken.None);
```

### Deserialize

Retrieve a previously registered schema ID from the Azure Schema Registry.

```C# Snippet:SchemaRegistryAvroDeserialize
var serializer = new SchemaRegistryAvroObjectSerializer(schemaRegistryClient, groupName, new SchemaRegistryAvroObjectSerializerOptions { AutoRegisterSchemas = true });
memoryStream.Position = 0;
Employee employee = (Employee)serializer.Deserialize(memoryStream, typeof(Employee), CancellationToken.None);
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
[quickstart_guide]: https://github.com/Azure/azure-sdk-for-net/blob/main/doc/mgmt_preview_quickstart.md
[schema_registry_client]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/schemaregistry/Azure.Data.SchemaRegistry/src/SchemaRegistryClient.cs
[azure_portal]: https://ms.portal.azure.com/
[schema_properties]: src/SchemaProperties.cs
[azure_identity]: https://www.nuget.org/packages/Azure.Identity
[cla]: https://cla.microsoft.com
[code_of_conduct]: https://opensource.microsoft.com/codeofconduct/
[code_of_conduct_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[email_opencode]: mailto:opencode@microsoft.com
[object_serializer]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/src/Serialization/ObjectSerializer.cs
[schema_registry_avro_serializer]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/schemaregistry/Microsoft.Azure.Data.SchemaRegistry.ApacheAvro/src/SchemaRegistryAvroObjectSerializer.cs
[employee]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/schemaregistry/Microsoft.Azure.Data.SchemaRegistry.ApacheAvro/tests/Models/Employee.cs
[avro_csharp_documentation]: https://avro.apache.org/docs/current/api/csharp/html/index.html
[apache_avro_library]: https://www.nuget.org/packages/Apache.Avro/
[generic_record]: https://avro.apache.org/docs/current/api/csharp/html/classAvro_1_1Generic_1_1GenericRecord.html
[specific_record]: https://avro.apache.org/docs/current/api/csharp/html/interfaceAvro_1_1Specific_1_1ISpecificRecord.html
[azure_sub]: https://azure.microsoft.com/free/
[azure_schema_registry]: https://aka.ms/schemaregistry
