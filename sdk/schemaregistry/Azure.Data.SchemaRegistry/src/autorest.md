# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
title: SchemaRegistryClient
require: https://github.com/Azure/azure-rest-api-specs/blob/70e53bf07d4f67000743c05d281930f2713a988e/specification/schemaregistry/data-plane/readme.md
generation1-convenience-client: true
```

## Swagger workarounds

### Add Content-Type header to GetById operation

``` yaml
directive:
  from: swagger-document
  where: $.paths["/$schemaGroups/{groupName}/schemas/{schemaName}:get-id"].post
  transform: >
    $.parameters.push({
      "name": "Content-Type",
      "in": "header",
      "description": "Content type of the schema.",
      "required": true,
      "type": "string",
      "enum": [
        "application/json; serialization=Avro",
        "application/json; serialization=Json",
        "text/plain; charset=utf-8"
      ],
      "x-ms-enum": {
        "name": "SchemaFormat",
        "modelAsString": true
       }});
```

### Add Content-Type header to Register operation

``` yaml
directive:
  from: swagger-document
  where: $.paths["/$schemaGroups/{groupName}/schemas/{schemaName}"].put
  transform: >
    $.parameters.push({
      "name": "Content-Type",
      "in": "header",
      "description": "Content type of the schema.",
      "required": true,
      "type": "string"});
```

### Enrich Content-Type header in response headers for operations returning the schema

``` yaml
directive:
  from: swagger-document
  where: $.paths["/$schemaGroups/$schemas/{id}"].get.responses["200"].headers
  transform: >
    $["Content-Type"]["enum"] = [
        "application/json; serialization=Avro",
        "application/json; serialization=Json",
        "text/plain; charset=utf-8"
       ];
    $["Content-Type"]["x-ms-enum"] = {
      "name": "SchemaFormat",
      "modelAsString": true
    };  
```

``` yaml
directive:
  from: swagger-document
  where: $.paths["/$schemaGroups/{groupName}/schemas/{schemaName}/versions/{schemaVersion}"].get.responses["200"].headers
  transform: >
    $["Content-Type"]["enum"] = [
        "application/json; serialization=Avro",
        "application/json; serialization=Json",
        "text/plain; charset=utf-8"
       ];
    $["Content-Type"]["x-ms-enum"] = {
      "name": "SchemaFormat",
      "modelAsString": true
    };  
```
