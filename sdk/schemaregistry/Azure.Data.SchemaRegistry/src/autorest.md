# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
title: SchemaRegistryClient
require: https://github.com/Azure/azure-rest-api-specs/blob/e88242fc7da7860d36ab4a1700e3404a51d53eeb/specification/schemaregistry/data-plane/readme.md
generation1-convenience-client: true
```

## Swagger workarounds

### Add Content-Type header to GetById operation and mark 415 as error

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
      "type": "string"});
     $.responses["415"]["x-ms-error-response"] = true
```

### Add Content-Type header to Register operation and mark 415 as error

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
    $.responses["415"]["x-ms-error-response"] = true
```