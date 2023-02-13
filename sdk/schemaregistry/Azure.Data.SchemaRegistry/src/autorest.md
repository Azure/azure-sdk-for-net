# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
title: SchemaRegistryClient
require: https://github.com/Azure/azure-rest-api-specs/blob/70e53bf07d4f67000743c05d281930f2713a988e/specification/schemaregistry/data-plane/readme.md
generation1-convenience-client: true
```

## Swagger workarounds

### Update producers arrays - get version

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

``` yaml
directive:
  from: swagger-document
  where: $.paths["/$schemaGroups/$schemas/{id}"].get
  transform: >
    $.produces = [
        "application/json; serialization=Avro",
        "application/json; serialization=Json",
        "application/octet-stream"]
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
        "text/plain; charset=utf-8"
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
        "text/plain; charset=utf-8"
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
        "text/plain; charset=utf-8"
       ];
    $["Content-Type"]["x-ms-enum"] = {
      "name": "ContentType",
      "modelAsString": true
    };  
```
