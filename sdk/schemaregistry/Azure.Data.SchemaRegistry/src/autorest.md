# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
title: SchemaRegistryClient
input-file:
    - https://github.com/Azure/azure-rest-api-specs/blob/70e53bf07d4f67000743c05d281930f2713a988e/specification/schemaregistry/data-plane/Microsoft.EventHub/stable/2022-10/schemaregistry.json
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
