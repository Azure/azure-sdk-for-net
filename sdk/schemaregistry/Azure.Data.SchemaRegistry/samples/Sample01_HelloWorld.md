# Registering and retrieving Avro, Json, and custom schemas

The following shows examples of what is available through the `SchemaRegistryClient`. There are both sync and async methods available for these client operations.

- [Registering and retrieving Avro, Json, and custom schemas](#registering-and-retrieving-avro-json-and-custom-schemas)
    - [Register a schema Avro](#register-a-schema-avro)
    - [Retrieve a schema Avro](#retrieve-a-schema-avro)
    - [Register a schema Json](#register-a-schema-json)
    - [Retrieve a schema Json](#retrieve-a-schema-json)
    - [Register a schema custom](#register-a-schema-custom)
    - [Retrieve a schema custom](#retrieve-a-schema-custom)
  - [Contributing](#contributing)

### Register a schema Avro

Register a schema to be stored in the Azure Schema Registry.

```C# Snippet:SchemaRegistryRegisterSchemaAvro
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

### Retrieve a schema Avro

Retrieve a previously registered schema's content from the Azure Schema Registry with either a schema ID or the group name, schema name, and version.

```C# Snippet:SchemaRegistryRetrieveSchemaAvro
SchemaRegistrySchema schema = client.GetSchema(schemaId);
string definition = schema.Definition;
```

### Register a schema Json

Register a schema to be stored in the Azure Schema Registry.

```C# Snippet:SchemaRegistryRegisterSchemaJson
string name = "employeeSample";
SchemaFormat format = SchemaFormat.Json;
// Example schema's definition
string definition = @"
{
    $schema: ""https://json-schema.org/draft/2020-12/schema"",
    $id: ""https://example.com/product.schema.json"",
    title: ""Product"",
    description: ""A product from the catalog"",
    type: ""object"",
    properties: {
        name: {
        type: ""string"",
        required: true,
    },
    favoriteNumber: {
        type: ""integer"",
        required: true,
    },
},
required: [""name"", ""favoriteNumber""],
}";

Response<SchemaProperties> schemaProperties = client.RegisterSchema(groupName, name, definition, format);
```

### Retrieve a schema Json

Retrieve a previously registered schema's content from the Azure Schema Registry with either a schema ID or the group name, schema name, and version.

```C# Snippet:SchemaRegistryRetrieveSchemaJson
SchemaRegistrySchema schema = client.GetSchema(schemaId);
string definition = schema.Definition;
```

### Register a schema custom

Register a schema to be stored in the Azure Schema Registry.

```C# Snippet:SchemaRegistryRegisterSchemaCustom
string name = "employeeSample";
SchemaFormat format = SchemaFormat.Custom;
// Example schema's definition
string definition = @"
{
    NAME: string
    OCCUPATION: string
    EMAIL: string
}";

Response<SchemaProperties> schemaProperties = client.RegisterSchema(groupName, name, definition, format);
```

### Retrieve a schema custom

Retrieve a previously registered schema's content from the Azure Schema Registry with either a schema ID or the group name, schema name, and version.

```C# Snippet:SchemaRegistryRetrieveSchemaCustom
SchemaRegistrySchema schema = client.GetSchema(schemaId);
string definition = schema.Definition;
```

## Contributing

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit [cla.microsoft.com][cla].

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (e.g., label, comment). Simply follow the instructions provided by the bot. You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct][code_of_conduct]. For more information see the [Code of Conduct FAQ][code_of_conduct_faq] or contact [opencode@microsoft.com][email_opencode] with any additional questions or comments.

![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net%2Fsdk%2Ftemplate%2FAzure.Template%2FREADME.png)
