# Release History

## 1.1.0-beta.1 (2026-11-13)

### Features Added

- Added multimodal embedding operations for text, queries, and document images, with dense, multi-vector, and combined results.
- Added inline and link delivery, output encoding and numeric precision selection, and embedding usage and warnings.
- Added flattened `GetEmbeddings` and `GetEmbeddingsAsync` methods; callers pass request settings directly rather than creating a request options object.
- Added .NET overloads that accept anonymous objects or dictionaries as embedding inputs and return typed results, without requiring `EmbeddingInput` instances. Omitted input kinds default to text; PascalCase members and SDK content kinds are supported, and unknown or duplicate properties are rejected.
- Added generic embedding result and usage models, with specialized multimodal implementations.

### Breaking Changes

- The default service API version is now `2026-11-01-preview`. Select `InferenceClientOptions.ServiceVersion.V2026_10_30` explicitly to continue using the stable semantic reranking API.

## 1.0.0 (2026-11-10)

### Features Added

- First stable release of the Azure.Data.AI client library for semantic reranking.
- Supports the generally available service API version `2026-10-30`.

### Breaking Changes

- Renamed `SemanticRerankingInferenceContent` to `SemanticRerankingContent`, `SemanticRerankingInferenceResult` to `SemanticRerankingResult`, and `SemanticRerankingMetaResult` to `SemanticRerankingMetadata`, including the corresponding model factory methods.
- Renamed the result's `Meta` property to `Metadata`; the JSON property remains `meta`.
- Changed `TargetPaths` from a settable string to an `IList<string>` collection with an API contract limit of 100 paths.

## 1.0.0-beta.1 (2026-09-28)

### Features Added

- Added the provisional TypeSpec-generated `InferenceClient` for Semantic Reranker operations.
- Added API-key authentication for the `Ocp-Apim-Subscription-Key` header.
- Added Microsoft Entra authentication using the `https://dbinference.azure.com/.default` scope.
- Added per-sentence relevance scores through `SemanticRerankingScore.SentenceScores`, opted into with `SemanticRerankingInferenceContent.ReturnSentenceScore`.
- Added result ordering control through `SemanticRerankingInferenceContent.Sort`.
- Added the `InferenceModelFactory` mocking factory.

### Bugs Fixed

- Fixed `InferenceClient(InferenceClientSettings)` so that API-key settings authenticate with the `Ocp-Apim-Subscription-Key` header instead of throwing `ArgumentNullException`. This also unblocks API-key authentication through `AddInferenceClient` and `AddKeyedInferenceClient`.
