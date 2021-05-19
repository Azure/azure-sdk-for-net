# Azure.Search.Documents Code Generation

Run `/sdk/search/generate.ps1` to generate code.

## AutoRest Configuration
> see https://aka.ms/autorest

## Swagger Source(s)
AutoRest doesn't play nicely with multiple remote swagger files.  It will
however merge two local swagger files together automagically.  At some point,
we should merge the Service and Index swagger files together but for now we
copy them locally in `/sdk/search/generate.ps1` and reference them here.
```yaml
title: SearchServiceClient
input-file:
- https://raw.githubusercontent.com/Azure/azure-rest-api-specs/55c3979124d193ab8cd4c5409a3e9f67739ca571/specification/search/data-plane/Azure.Search/preview/2020-06-30/searchindex.json
- https://raw.githubusercontent.com/Azure/azure-rest-api-specs/55c3979124d193ab8cd4c5409a3e9f67739ca571/specification/search/data-plane/Azure.Search/preview/2020-06-30/searchservice.json
```

## Release hacks
We only want certain client methods for our search query client.
``` yaml
directive:
- remove-operation: Documents_AutocompleteGet
- remove-operation: Documents_SearchGet
- remove-operation: Documents_SuggestGet
```

## CodeGen hacks
These should eventually be fixed in the code generator.

## Swagger hacks
These should eventually be fixed in the swagger files.

### Mark definitions as objects
The modeler warns about models without an explicit type.
``` yaml
directive:
- from: swagger-document
  where: $.definitions.*
  transform: >
    if (typeof $.type === "undefined") {
        $.type = "object";
    }
```

### Make Loookup Document behave a little friendlier
It's currently an empty object and adding Additional Properties will generate
a more useful model.
``` yaml
directive:
- from: swagger-document
  where: $.paths["/docs('{key}')"].get.responses["200"].schema
  transform:  >
    $.additionalProperties = true;
```

### Rename one of SearchError definitions

SearchError is duplicated between two swaggers, rename one of them

``` yaml
directive:
- from: searchservice.json
  where: $.definitions.SearchError
  transform: $["x-ms-client-name"] = "SearchServiceError"
```

### Rename one of SearchMode definitions

SearchMode is duplicated across swaggers. Rename one of them, even though it will be internalized.
This prevents the serializer from attempting to use undefined values until [Azure/autorest.csharp#583](https://github.com/Azure/autorest.csharp/issues/583) is fixed.

```yaml
directive:
- from: searchservice.json
  where: $.definitions.Suggester.properties.searchMode
  transform: $["x-ms-enum"].name = "SuggesterMode";
```

### Add nullable annotations

``` yaml
directive:
  from: swagger-document
  where: $.definitions.SynonymMap
  transform: >
    $.properties.encryptionKey["x-nullable"] = true;
```

``` yaml
directive:
  from: swagger-document
  where: $.definitions.SearchField
  transform: >
    $.properties.indexAnalyzer["x-nullable"] = true;
    $.properties.searchAnalyzer["x-nullable"] = true;
    $.properties.analyzer["x-nullable"] = true;
```

``` yaml
directive:
  from: swagger-document
  where: $.definitions.ScoringProfile
  transform: >
    $.properties.text["x-nullable"] = true;
    $.properties.functionAggregation["x-nullable"] = true;
```

``` yaml
directive:
  from: swagger-document
  where: $.definitions.SearchIndex
  transform: >
    $.properties.encryptionKey["x-nullable"] = true;
    $.properties.corsOptions["x-nullable"] = true;
```

``` yaml
directive:
  from: swagger-document
  where: $.definitions.BM25Similarity
  transform: >
    $.properties.k1["x-nullable"] = true;
    $.properties.b["x-nullable"] = true;
```

``` yaml
directive:
  from: swagger-document
  where: $.definitions.SearchIndexerDataSource
  transform: >
    $.properties.dataChangeDetectionPolicy["x-nullable"] = true;
```

``` yaml
directive:
  from: swagger-document
  where: $.definitions.SearchIndexerDataSource
  transform: >
    $.properties.dataDeletionDetectionPolicy["x-nullable"] = true;
```

``` yaml
directive:
  from: swagger-document
  where: $.definitions.SearchIndexer
  transform: >
    $.properties.disabled["x-nullable"] = true;
    $.properties.schedule["x-nullable"] = true;
    $.properties.parameters["x-nullable"] = true;
```

``` yaml
directive:
  from: swagger-document
  where: $.definitions.SearchIndexerStatus
  transform: >
    $.properties.lastResult["x-nullable"] = true;
```

``` yaml
directive:
  from: swagger-document
  where: $.definitions.TextTranslationSkill
  transform: >
    $.properties.suggestedFrom["x-nullable"] = true;
```

``` yaml
directive:
  from: swagger-document
  where: $.definitions.IndexingParameters
  transform: >
    $.properties.batchSize["x-nullable"] = true;
    $.properties.maxFailedItems["x-nullable"] = true;
    $.properties.maxFailedItemsPerBatch["x-nullable"] = true;
```

``` yaml
directive:
  from: swagger-document
  where: $.definitions.FieldMapping
  transform: >
    $.properties.mappingFunction["x-nullable"] = true;
```

``` yaml
directive:
  from: swagger-document
  where: $.definitions.IndexerExecutionResult
  transform: >
    $.properties.endTime["x-nullable"] = true;
```

``` yaml
directive:
  from: swagger-document
  where: $.definitions.CorsOptions
  transform: >
    $.properties.maxAgeInSeconds["x-nullable"] = true;
```

#### Skills

``` yaml
directive:
- from: swagger-document
  where: $.definitions.EntityRecognitionSkill
  transform: >
    $.properties.defaultLanguageCode["x-nullable"] = true;

- from: swagger-document
  where: $.definitions.ImageAnalysisSkill
  transform: >
    $.properties.defaultLanguageCode["x-nullable"] = true;

- from: swagger-document
  where: $.definitions.KeyPhraseExtractionSkill
  transform: >
    $.properties.defaultLanguageCode["x-nullable"] = true;

- from: swagger-document
  where: $.definitions.OcrSkill
  transform: >
    $.properties.defaultLanguageCode["x-nullable"] = true;
    $.properties.detectOrientation["x-nullable"] = true;

- from: swagger-document
  where: $.definitions.SentimentSkill
  transform: >
    $.properties.defaultLanguageCode["x-nullable"] = true;

- from: swagger-document
  where: $.definitions.SplitSkill
  transform: >
    $.properties.defaultLanguageCode["x-nullable"] = true;

- from: swagger-document
  where: $.definitions.TextTranslationSkill
  transform: >
    $.properties.defaultFromLanguageCode["x-nullable"] = true;

- from: swagger-document
  where: $.definitions.WebApiSkill
  transform: >
    $.properties.httpHeaders["x-nullable"] = true;
    $.properties.timeout["x-nullable"] = true;
```

## C# Customizations
Shape the swagger APIs to produce the best C# API possible.  We can consider
fixing these in the swagger files if they would benefit other languages.

### Property name changes
Change the name of some properties so they are properly CamelCased.
``` yaml
modelerfour:
  naming:
    override:
      "@odata.type": ODataType
```

### Disable parameter grouping

AutoRest C# supports parameter grouping now, temporary disabling to reduce the change size.

``` yaml
modelerfour:
  group-parameters: false
```

### Set odata.metadata Accept header in operations

searchindex.json needs odata.metadata=none and searchservice.json needs odata.metadata=minimal in the Accept header.

```yaml
directive:
- from: swagger-document
  where: $.paths
  transform: >
    for (var path in $) {
      for (var opName in $[path]) {
        var accept = "application/json; odata.metadata=";
        accept += path.startsWith("/docs") ? "none" : "minimal";

        var op = $[path][opName];
        op.parameters.push({
          name: "Accept",
          "in": "header",
          required: true,
          type: "string",
          enum: [ accept ],
          "x-ms-parameter-location": "method"
        });
      }
    }

    return $;
```

### Move service models to Azure.Search.Documents.Indexes.Models

Models in searchservice.json should be moved to Azure.Search.Documents.Indexes.Models.

```yaml
directive:
  from: searchservice.json
  where: $.definitions.*
  transform: >
    $["x-namespace"] = "Azure.Search.Documents.Indexes.Models"
```

### Relocate x-ms-client-request-id parameter

Remove the `x-ms-client-request-id` parameter from all methods and put it on the client.
This will be later removed when https://github.com/Azure/autorest.csharp/issues/782 is resolved.
Several attempts at just removing the parameter have caused downstream issues, so relocating it for now.

```yaml
directive:
  from: swagger-document
  where: $.parameters.ClientRequestIdParameter
  transform: $["x-ms-parameter-location"] = "client";
```
