# Release History

## 1.1.0-beta.1 (Unreleased)

### Features Added

- Added multimodal embedding operations for text, queries, and document images, with dense, multi-vector, and combined results.
- Added inline and link delivery, output encoding and numeric precision selection, and embedding usage and warnings.
- Added flattened `GetMultimodalEmbeddings` and `GetMultimodalEmbeddingsAsync` methods; callers pass request settings directly rather than creating a request options object.

### Breaking Changes

- The default service API version is now `2026-11-01-preview`. Select `InferenceClientOptions.ServiceVersion.V2026_10_30` explicitly to continue using the stable semantic reranking API.
- Renamed `SemanticRerankingInferenceContent` to `SemanticRerankingOptions`, `SemanticRerankingInferenceResult` to `SemanticRerankingResult`, and the previous `SemanticRerankingResult` response envelope to `SemanticRerankingOperationResult`.
- Renamed `MetaResult` and `Meta` to `SemanticRerankingMetadata` and `Metadata`. Renamed the latency members `DataPreprocessTime`, `InferenceTime`, and `PostProcessTime` to `DataPreprocessDuration`, `InferenceDuration`, and `PostProcessDuration`.

## 1.0.0 (2026-10-30)

### Features Added

- First stable release of the Azure.Data.AI client library for semantic reranking.
- Supports the generally available service API version `2026-10-30`.


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
