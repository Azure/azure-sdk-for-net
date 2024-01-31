# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
title: SchemaRegistryClient
require: https://github.com/Azure/azure-rest-api-specs/blob/c364b64a6b412ffd7507dea71ae53251d35748c1/specification/schemaregistry/data-plane/readme.md
generation1-convenience-client: true
```

## Swagger workarounds

### Update producers arrays - get version
Because of some limitations of swagger and Autorest, Autorest cannot properly deduce that we would like to have an object return type to put on this method if we have a mix of "text/..." and "application/..." outputs in the produces array. Because of this we need to have "application/octet-stream" as a kind of stand-in for the the text outputs (Custom: "text/plain; charset=utf-8" and Protobuf: "text/vnd.ms.protobuf"). We have to determine what the output is on the client side based on the content-type.

``` yaml
directive:
  from: swagger-document
  where: $.paths["/$schemaGroups/{groupName}/schemas/{schemaName}/versions/{schemaVersion}"].get
  transform: >
    $.produces = [
        "application/json; serialization=Avro",
        "application/json; serialization=json",
        "application/octet-stream"
    ]
```

### Update producers arrays - get id
We need to use "application/octet-stream" here for the same reason as above.

``` yaml
directive:
  from: swagger-document
  where: $.paths["/$schemaGroups/$schemas/{id}"].get
  transform: >
    $.produces = [
        "application/json; serialization=Avro",
        "application/json; serialization=json",
        "application/octet-stream"
    ]
```

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
