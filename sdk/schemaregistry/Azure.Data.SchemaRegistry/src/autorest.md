# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
title: SchemaRegistryClient
require: https://github.com/Azure/azure-rest-api-specs/blob/c364b64a6b412ffd7507dea71ae53251d35748c1/specification/schemaregistry/data-plane/readme.md
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
        "application/json; serialization=json",
        "text/plain; charset=utf-8",
        "text/vnd.ms.protobuf"
      ],
      "x-ms-enum": {
        "name": "ContentType",
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
        "application/json; serialization=json",
        "text/plain; charset=utf-8",
        "text/vnd.ms.protobuf"
       ];
    $["Content-Type"]["x-ms-enum"] = {
      "name": "ContentType",
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
        "application/json; serialization=json",
        "text/plain; charset=utf-8",
        "text/vnd.ms.protobuf"
       ];
    $["Content-Type"]["x-ms-enum"] = {
      "name": "ContentType",
      "modelAsString": true
    };  
```
