# Registering and retrieving Avro, Json, and custom schemas

The following shows examples of how to use the basic functionality of the `SchemaRegistryClient` with each of the available schema format types. All of the client methods can be used with each format by passing in the proper 'SchemaFormat' value when needed.

Schema Registry schema groups can only accept one format of schemas.

In the current service version, the Schema Registry service only accepts and validates draft 3 JSON schemas. Functionality to support additional drafts of JSON will be added.

- [Registering and retrieving Avro, Json, and custom schemas](#registering-and-retrieving-avro-json-and-custom-schemas)
    - [Register an Avro schema](#register-an-avro-schema)
    - [Retrieve an Avro schema](#retrieve-an-avro-schema)
    - [Register a Json schema (preview)](#register-a-json-schema-preview)
    - [Retrieve a Json schema (preview)](#retrieve-a-json-schema-preview)
    - [Register a custom schema (preview)](#register-a-custom-schema-preview)
    - [Retrieve a custom schema (preview)](#retrieve-a-custom-schema-preview)

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

Response<SchemaProperties> schemaProperties = avroClient.RegisterSchema(groupName, name, definition, format);
```

### Retrieve an Avro schema

Retrieve a previously registered schema's content from the Azure Schema Registry with either a schema ID or the group name, schema name, and version. This is the same regardless of schema format.

```C# Snippet:SchemaRegistryRetrieveSchemaAvro
SchemaRegistrySchema schema = avroClient.GetSchema(schemaId);
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
    }
}";

Response<SchemaProperties> schemaProperties = jsonClient.RegisterSchema(groupName, name, definition, format);
```

### Retrieve a Json schema

Retrieve a previously registered schema's content from the Azure Schema Registry with either a schema ID or the group name, schema name, and version. This is the same regardless of schema format.

```C# Snippet:SchemaRegistryRetrieveSchemaJson
SchemaRegistrySchema schema = jsonClient.GetSchema(schemaId);
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

Response<SchemaProperties> schemaProperties = customClient.RegisterSchema(groupName, name, definition, format);
```

### Retrieve a custom schema

Retrieve a previously registered schema's content from the Azure Schema Registry with either a schema ID or the group name, schema name, and version. This is the same regardless of schema format.

```C# Snippet:SchemaRegistryRetrieveSchemaCustom
SchemaRegistrySchema schema = customClient.GetSchema(schemaId);
string definition = schema.Definition;
```
