# Azure.Search.Documents Code Generation

Run `dotnet build /t:GenerateCode` in the `src` directory to generate SDK code.

See the [Contributing guidelines](https://github.com/Azure/azure-sdk-for-net/blob/fe0bf0e7e84a406ec2102c194ea05ccd5011a141/sdk/search/CONTRIBUTING.md) for more details.

## AutoRest Configuration
> see https://aka.ms/autorest

```yaml
use-model-reader-writer: true
```

## Swagger Source(s)
```yaml
title: SearchServiceClient
input-file:
 - https://github.com/Azure/azure-rest-api-specs/blob/5fda13cee42cecc2e7da20bb4fd82bec5be9d0c7/specification/search/data-plane/Azure.Search/stable/2025-09-01/searchindex.json
 - https://github.com/Azure/azure-rest-api-specs/blob/5fda13cee42cecc2e7da20bb4fd82bec5be9d0c7/specification/search/data-plane/Azure.Search/stable/2025-09-01/searchservice.json
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
### Remove models that have newer versions

These classes have `CodeGenModel` pointing to newer models. Don't try to generate the
old models into the same class.

```yaml
directive:
  - remove-model: EdgeNGramTokenFilter
  - remove-model: KeywordTokenizer
  - remove-model: LuceneStandardTokenizer
  - remove-model: NGramTokenFilter
```

### Retain `rerankWithOriginalVectors` and `defaultOversampling` in `VectorSearchCompressionConfiguration`

```yaml
directive:
- from: "searchservice.json"
  where: $.definitions.VectorSearchCompressionConfiguration
  transform: >
    $.properties.rerankWithOriginalVectors = {
      "type": "boolean",
      "description": "If set to true, once the ordered set of results calculated using compressed vectors are obtained, they will be reranked again by recalculating the full-precision similarity scores. This will improve recall at the expense of latency.\nFor use with only service version 2024-07-01. If using 2025-09-01 or later, use RescoringOptions.rescoringEnabled.",
      "x-nullable": true
    };
    $.properties.defaultOversampling = {
      "type": "number",
      "format": "double",
      "description": "Default oversampling factor. Oversampling will internally request more documents (specified by this multiplier) in the initial search. This increases the set of results that will be reranked using recomputed similarity scores from full-precision vectors. Minimum value is 1, meaning no oversampling (1x). This parameter can only be set when rerankWithOriginalVectors is true. Higher values improve recall at the expense of latency.\nFor use with only service version 2024-07-01. If using 2025-09-01 or later, use RescoringOptions.defaultOversampling.",
      "x-nullable": true
    };
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

### Archboard feedback for 2024-07-01

```yaml
directive:
- from: "searchservice.json"
  where: $.definitions
  transform: >
    $.AzureOpenAIParameters["x-ms-client-name"] = "AzureOpenAIVectorizerParameters";
    $.AzureOpenAIParameters.properties.authIdentity["x-ms-client-name"] = "AuthenticationIdentity";
    $.AzureOpenAIParameters.properties.resourceUri["x-ms-client-name"] = "resourceUri";

    $.VectorSearchVectorizer.properties.name["x-ms-client-name"] = "VectorizerName";
    $.AzureOpenAIVectorizer.properties.azureOpenAIParameters["x-ms-client-name"] = "Parameters";

    $.ScalarQuantizationVectorSearchCompressionConfiguration["x-ms-client-name"] = "ScalarQuantizationCompression";
    $.BinaryQuantizationVectorSearchCompressionConfiguration["x-ms-client-name"] = "BinaryQuantizationCompression";
    $.VectorSearchCompressionConfiguration["x-ms-client-name"] = "VectorSearchCompression";
    $.VectorSearchCompressionConfiguration.properties.name["x-ms-client-name"] = "CompressionName";
    $.VectorSearchProfile.properties.compression["x-ms-client-name"] = "CompressionName";

    $.OcrSkillLineEnding["x-ms-client-name"] = "OcrLineEnding";
    $.OcrSkillLineEnding["x-ms-enum"].name = "OcrLineEnding";

    $.SearchIndexerDataUserAssignedIdentity.properties.userAssignedIdentity["x-ms-format"] = "arm-id";
    $.SearchIndexerIndexProjections["x-ms-client-name"] = "SearchIndexerIndexProjection";
    $.SearchIndexerSkillset.properties.indexProjections["x-ms-client-name"] = "indexProjection";

    $.VectorSearchCompressionTargetDataType["x-ms-client-name"] = "VectorSearchCompressionTarget";
    $.VectorSearchCompressionTargetDataType["x-ms-enum"].name = "VectorSearchCompressionTarget";

    $.WebApiVectorizer.properties.customWebApiParameters["x-ms-client-name"] = "Parameters";
    $.WebApiParameters["x-ms-client-name"] = "WebApiVectorizerParameters";
    $.WebApiParameters.properties.uri["x-ms-client-name"] = "uri";
```

### Change VectorizableImageUrlQuery.Url type to Uri

```yaml
directive:
  from: swagger-document
  where: $.definitions.VectorizableImageUrlQuery.properties.url
  transform: $.format = "url"
```

### Set `hybridSearch` property to be type `HybridSearch` in SearchRequest

``` yaml
directive:
  - from: searchindex.json
    where: $.definitions.SearchRequest.properties
    transform: >
        delete $.hybridSearch["type"];
        delete $.hybridSearch.items;
        $.hybridSearch["$ref"] = "#/definitions/HybridSearch";
```

### Enable `RawVectorQuery.vector` as embedding field

```yaml
directive:
- from: searchindex.json
  where: $.definitions.RawVectorQuery.properties.vector
  transform: $["x-ms-embedding-vector"] = true;
```

### Make `VectorSearchAlgorithmKind` internal

```yaml
directive:
- from: searchservice.json
  where: $.definitions.VectorSearchAlgorithmKind
  transform: $["x-accessibility"] = "internal"
```

### Make `VectorSearchCompressionKind` internal

```yaml
directive:
- from: searchservice.json
  where: $.definitions.VectorSearchCompressionKind
  transform: $["x-accessibility"] = "internal"
```

### Make `VectorSearchCompressionKind` internal

```yaml
directive:
- from: searchservice.json
  where: $.definitions.VectorSearchCompressionKind
  transform: $["x-accessibility"] = "internal"
```

### Make `VectorQueryKind` internal

```yaml
directive:
- from: searchindex.json
  where: $.definitions.VectorQueryKind
  transform: $["x-accessibility"] = "internal"
```

### Make `VectorSearchVectorizerKind` internal

```yaml
directive:
- from: searchservice.json
  where: $.definitions.VectorSearchVectorizerKind
  transform: $["x-accessibility"] = "internal"
```

### Make `VectorThresholdKind` internal

```yaml
directive:
- from: searchindex.json
  where: $.definitions.VectorThresholdKind
  transform: $["x-accessibility"] = "internal"
```

### Rename `RawVectorQuery` to `VectorizedQuery`

```yaml
directive:
- from: searchindex.json
  where: $.definitions.RawVectorQuery
  transform: $["x-ms-client-name"] = "VectorizedQuery";
```

### Rename `AMLVectorizer` to `AzureMachineLearningVectorizer`

```yaml
directive:
- from: searchservice.json
  where: $.definitions.AMLVectorizer
  transform: $["x-ms-client-name"] = "AzureMachineLearningVectorizer";
```

### Rename `AMLParameters` to `AzureMachineLearningParameters`

```yaml
directive:
- from: searchservice.json
  where: $.definitions.AMLParameters
  transform: $["x-ms-client-name"] = "AzureMachineLearningParameters";
```

### Rename `ServiceLimits.maxStoragePerIndex` to `ServiceLimits.maxStoragePerIndexInBytes`

```yaml
directive:
- from: searchservice.json
  where: $.definitions.ServiceLimits
  transform: $.properties.maxStoragePerIndex["x-ms-client-name"] = "maxStoragePerIndexInBytes";
```

### Rename `PIIDetectionSkill.minimumPrecision` to `PIIDetectionSkill.MinPrecision`

```yaml
directive:
  - from: searchservice.json
    where: $.definitions.PIIDetectionSkill
    transform: $.properties.minimumPrecision["x-ms-client-name"] = "MinPrecision";
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