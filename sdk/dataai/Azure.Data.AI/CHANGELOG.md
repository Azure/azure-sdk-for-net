# Release History

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
