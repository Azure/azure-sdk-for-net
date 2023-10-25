# Azure.Search.Documents Code Generation

Run `dotnet build /t:GenerateCode` in the `src` directory to generate SDK code.

See the [Contributing guidelines](https://github.com/Azure/azure-sdk-for-net/blob/fe0bf0e7e84a406ec2102c194ea05ccd5011a141/sdk/search/CONTRIBUTING.md) for more details.

## AutoRest Configuration
> see https://aka.ms/autorest

## Swagger Source(s)
```yaml
title: SearchServiceClient
input-file:
 - https://github.com/Azure/azure-rest-api-specs/blob/d52c50c22ec7f573d49fc3b4c6c931491d92ec8b/specification/search/data-plane/Azure.Search/stable/2023-11-01/searchindex.json
 - https://github.com/Azure/azure-rest-api-specs/blob/d52c50c22ec7f573d49fc3b4c6c931491d92ec8b/specification/search/data-plane/Azure.Search/stable/2023-11-01/searchservice.json
generation1-convenience-client: true
deserialize-null-collection-as-null-value: true
```

## Release hacks
We only want certain client methods for our search query client.
``` yaml
directive:
- remove-operation: Documents_AutocompleteGet
- remove-operation: Documents_SearchGet
- remove-operation: Documents_SuggestGet
```

### Suppress Abstract Base Class

``` yaml
suppress-abstract-base-class:
- CharFilter
- CognitiveServicesAccount
- DataChangeDetectionPolicy
- DataDeletionDetectionPolicy
- LexicalAnalyzer
- LexicalNormalizer
- LexicalTokenizer
- ScoringFunction
- SearchIndexerDataIdentity
- SearchIndexerSkill
- Similarity
- TokenFilter
```


## CodeGen hacks
These should eventually be fixed in the code generator.

## Swagger hacks
These should eventually be fixed in the swagger files.
``` yaml
directive:
  from: swagger-document
  where: $.definitions.LexicalNormalizer
  transform: >
    $["discriminator"] = "@odata.type";
```

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

### Make Lookup Document behave a little friendlier
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

### Rename `Dimensions`

 To ensure alignment with `VectorSearchConfiguration` in intellisense and documentation, rename the `Dimensions` to `VectorSearchDimensions`.

```yaml
directive:
- from: searchservice.json
  where: $.definitions.SearchField.properties.dimensions
  transform: $["x-ms-client-name"] = "vectorSearchDimensions";
```

### Rename `VectorSearchProfile`

```yaml
directive:
- from: searchservice.json
  where: $.definitions.SearchField.properties.vectorSearchProfile
  transform: $["x-ms-client-name"] = "vectorSearchProfileName";
```

### Make `RawVectorQuery.vector` field Required

```yaml
directive:
- from: searchindex.json
  where: $.definitions.RawVectorQuery
  transform: $["required"] = ["vector"]
```

### Make `SemanticField.fieldName` field Required

```yaml
directive:
- from: searchservice.json
  where: $.definitions.SemanticField
  transform: $["required"] = ["fieldName"]
```

### Make `VectorSearchAlgorithmKind` internal

```yaml
directive:
- from: searchservice.json
  where: $.definitions.VectorSearchAlgorithmKind
  transform: $["x-accessibility"] = "internal"
```

### Make `VectorQueryKind` internal

```yaml
directive:
- from: searchindex.json
  where: $.definitions.VectorQueryKind
  transform: $["x-accessibility"] = "internal"
```

### Rename `PrioritizedFields` to `SemanticPrioritizedFields`

```yaml
directive:
- from: searchservice.json
  where: $.definitions.PrioritizedFields
  transform: $["x-ms-client-name"] = "SemanticPrioritizedFields";
```

### Rename `SemanticErrorHandling` to `SemanticErrorMode`

```yaml
directive:
- from: searchindex.json
  where: $.definitions.SemanticErrorHandling
  transform: $["x-ms-enum"].name = "SemanticErrorMode";
```

### Rename `SemanticPartialResponseReason` to `SemanticErrorReason`

```yaml
directive:
- from: searchindex.json
  where: $.definitions.SemanticPartialResponseReason
  transform: $["x-ms-enum"].name = "SemanticErrorReason";
```

### Rename `SemanticPartialResponseType` to `SemanticSearchResultsType`

```yaml
directive:
- from: searchindex.json
  where: $.definitions.SemanticPartialResponseType
  transform: $["x-ms-enum"].name = "SemanticSearchResultsType";
```

### Rename `VectorQuery` to `VectorizableQuery`

```yaml
directive:
- from: searchindex.json
  where: $.definitions.VectorQuery
  transform: $["x-ms-client-name"] = "VectorizableQuery";
```


### Rename `VectorSearchProfile.algorithm` to `VectorSearchProfile.algorithmConfigurationName`

```yaml
directive:
- from: searchservice.json
  where: $.definitions.VectorSearchProfile.properties.algorithm
  transform: $["x-ms-client-name"] = "algorithmConfigurationName";
```

### Rename `RawVectorQuery` to `VectorQuery`

```yaml
directive:
- from: searchindex.json
  where: $.definitions.RawVectorQuery
  transform: $["x-ms-client-name"] = "VectorQuery";
```

### Rename `ExhaustiveKnnVectorSearchAlgorithmConfiguration` to `ExhaustiveKnnAlgorithmConfiguration`

```yaml
directive:
- from: searchservice.json
  where: $.definitions.ExhaustiveKnnVectorSearchAlgorithmConfiguration
  transform: $["x-ms-client-name"] = "ExhaustiveKnnAlgorithmConfiguration";
```

### Rename `HnswVectorSearchAlgorithmConfiguration` to `HnswAlgorithmConfiguration`

```yaml
directive:
- from: searchservice.json
  where: $.definitions.HnswVectorSearchAlgorithmConfiguration
  transform: $["x-ms-client-name"] = "HnswAlgorithmConfiguration";
```

### Rename `SemanticSettings` to `SemanticSearch`

```yaml
directive:
  - from: searchservice.json
    where: $.definitions.SemanticSettings
    transform: $["x-ms-client-name"] = "SemanticSearch";
```

### Rename `SearchIndex.semanticSettings` to `SearchIndex.SemanticSearch`

```yaml
directive:
  - from: searchservice.json
    where: $.definitions.SearchIndex.properties.semantic
    transform: $["x-ms-client-name"] = "SemanticSearch";
```

### Rename `SemanticSettings.defaultConfiguration` to `SemanticSettings.DefaultConfigurationName`

```yaml
directive:
  - from: searchservice.json
    where: $.definitions.SemanticSettings.properties.defaultConfiguration
    transform: $["x-ms-client-name"] = "DefaultConfigurationName";
```

### Rename `PIIDetectionSkill.maskingCharacter` to `PIIDetectionSkill.mask`

```yaml
directive:
  - from: searchservice.json
    where: $.definitions.PIIDetectionSkill
    transform: >
      $.properties.maskingCharacter["x-ms-client-name"] = "mask";
      $.properties.minimumPrecision["x-ms-client-name"] = "MinPrecision";
```

### Add `Edm.Single` in `SearchFieldDataType`

In the case of a vector field, the `Edm.Single` data type was missing. Therefore, it is now being added to the `SearchFieldDataType`.

```yaml
directive:
- from: swagger-document
  where: $.definitions.SearchFieldDataType
  transform: >
    $.enum.push("Edm.Single");
    $["x-ms-enum"].values.push({
      "value": "Edm.Single",
      "name": "Single",
      "description": "Indicates that a field contains a single-precision floating point number. This is only valid when used with Collection(Edm.Single)."
    });  
```

### Add `arm-id` format for `AuthResourceId`

 Add `"format": "arm-id"` for `AuthResourceId` to generate as [Azure.Core.ResourceIdentifier](https://learn.microsoft.com/dotnet/api/azure.core.resourceidentifier?view=azure-dotnet).

```yaml
directive:
- from: searchservice.json
  where: $.definitions.WebApiSkill.properties.authResourceId
  transform: $["x-ms-format"] = "arm-id";
```

### Rename `VectorQuery` property `K`

 Rename `VectorQuery` property `K` to `KNearestNeighborsCount`

```yaml
directive:
- from: searchindex.json
  where: $.definitions.VectorQuery.properties.k
  transform: $["x-ms-client-name"] = "KNearestNeighborsCount";
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
    $.properties.statusDetail["x-nullable"] = true;
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
          "x-ms-enum": { "modelAsString": false },
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

## Seal single value enums

Prevents the creation of single-value extensible enum in generated code. The following single-value enum will be generated as string constant.

```yaml
directive:
  from: swagger-document
  where: $.parameters.PreferHeaderParameter
  transform: >
    $["x-ms-enum"] = {
      "modelAsString": false
    }
```
