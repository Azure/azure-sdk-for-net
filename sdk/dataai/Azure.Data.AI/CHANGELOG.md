# Release History

## 1.0.0-beta.1 (Unreleased)

### Features Added

- Added the provisional TypeSpec-generated `InferenceClient` for Semantic Reranker operations.
- Added API-key authentication for the `Ocp-Apim-Subscription-Key` header.
- Added Microsoft Entra authentication using the `https://dbinference.azure.com/.default` scope.
- Added per-sentence relevance scores through `SemanticRerankingScore.SentenceScores`, opted into with `SemanticRerankingInferenceRequest.ReturnSentenceScore`.
- Added result ordering control through `SemanticRerankingInferenceRequest.Sort`.
- Added the `InferenceModelFactory` mocking factory. The generator names this type from the package name (`Azure.Data.AI` produces `AIModelFactory`), so it is renamed through a supported `[CodeGenType]` customization to match the client surface.

### Breaking Changes

### Bugs Fixed

### Other Changes