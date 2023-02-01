# Registering and retrieving Avro, Json, and custom schemas (preview)

The following shows examples of how to use the basic functionality of the `SchemaRegistryClient` with each of the available schema format types. All of the client methods can be used with each format by passing in the proper 'SchemaFormat' value when needed.

Each Event Hubs Namespace can only accept one format of schemas.

In the current service version, the Schema Registry service only accepts and validates draft 3 Json schemas. Functionality to support additional drafts of Json will be added.

- [Registering and retrieving Avro, Json, and custom schemas (preview)](#registering-and-retrieving-avro-json-and-custom-schemas-preview)
    - [Register an Avro schema](#register-an-avro-schema)
    - [Retrieve an Avro schema](#retrieve-an-avro-schema)
    - [Register a Json schema](#register-a-json-schema)
    - [Retrieve a Json schema](#retrieve-a-json-schema)
    - [Register a custom schema](#register-a-custom-schema)
    - [Retrieve a custom schema](#retrieve-a-custom-schema)
  - [Contributing](#contributing)

### Register an Avro schema

Register an Avro schema to be stored in the Azure Schema Registry.

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

### Retrieve an Avro schema

Retrieve a previously registered schema's content from the Azure Schema Registry with either a schema ID or the group name, schema name, and version. This is the same regardless of schema format.

```C# Snippet:SchemaRegistryRetrieveSchemaAvro
SchemaRegistrySchema schema = client.GetSchema(schemaId);
string definition = schema.Definition;
```

### Register a Json schema

Register a Json schema to be stored in the Azure Schema Registry.

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

### Retrieve a Json schema

Retrieve a previously registered schema's content from the Azure Schema Registry with either a schema ID or the group name, schema name, and version. This is the same regardless of schema format.

```C# Snippet:SchemaRegistryRetrieveSchemaJson
SchemaRegistrySchema schema = client.GetSchema(schemaId);
string definition = schema.Definition;
```

### Register a custom schema

Register a custom schema to be stored in the Azure Schema Registry.

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

### Retrieve a custom schema

Retrieve a previously registered schema's content from the Azure Schema Registry with either a schema ID or the group name, schema name, and version. This is the same regardless of schema format.

```C# Snippet:SchemaRegistryRetrieveSchemaCustom
SchemaRegistrySchema schema = client.GetSchema(schemaId);
string definition = schema.Definition;
```

## Contributing

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit [cla.microsoft.com][cla].

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (e.g., label, comment). Simply follow the instructions provided by the bot. You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct][code_of_conduct]. For more information see the [Code of Conduct FAQ][code_of_conduct_faq] or contact [opencode@microsoft.com][email_opencode] with any additional questions or comments.

![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net%2Fsdk%2Ftemplate%2FAzure.Template%2FREADME.png)
