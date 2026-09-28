# Release History

## 1.0.0-beta.1 (Unreleased)

### Features Added

- Added the provisional TypeSpec-generated `InferenceClient` for Semantic Reranker operations.
- Added API-key authentication for the `Ocp-Apim-Subscription-Key` header.
- Added Microsoft Entra authentication using the `https://dbinference.azure.com/.default` scope.
- Added per-sentence relevance scores through `SemanticRerankingScore.SentenceScores`, opted into with `SemanticRerankingInferenceContent.ReturnSentenceScore`.
- Added result ordering control through `SemanticRerankingInferenceContent.Sort`.
- Added the `InferenceModelFactory` mocking factory.

### Breaking Changes

### Bugs Fixed

- Fixed `InferenceClient(InferenceClientSettings)` so that API-key settings authenticate with the `Ocp-Apim-Subscription-Key` header instead of throwing `ArgumentNullException`. This also unblocks API-key authentication through `AddInferenceClient` and `AddKeyedInferenceClient`.

### Other Changes