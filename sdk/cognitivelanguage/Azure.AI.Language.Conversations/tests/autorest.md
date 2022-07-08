# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
# The title here is used to generate the single ClientOptions class name.
title: Conversations
license-header: MICROSOFT_MIT_NO_VERSION

input-file:
- https://raw.githubusercontent.com/Azure/azure-rest-api-specs/725f4ca360426a32d20e81eb945065e62c285d6a/specification/cognitiveservices/data-plane/Language/stable/2022-05-01/analyzeconversations.json

namespace: Azure.AI.Language.Conversations
model-namespace: false
output-folder: ./Generated
clear-output-folder: true

generation1-convenience-client: true

modelerfour:
  lenient-model-deduplication: true
```

## Customizations

Customizations that should eventually be added to central autorest configuration.

### General customizations

``` yaml
directive:
# Work around https://github.com/Azure/azure-sdk-for-net/issues/29141
- from: swagger-document
  where: $.definitions.AnalyzeConversationResultsKind
  transform: >
    $["enum"] = [
      "conversationalPIIResults",
      "conversationalSummarizationResults"
    ];

- from: swagger-document
  where: $.definitions.AnalyzeConversationConversationPIIResult
  transform: >
    $["x-ms-discriminator-value"] = "conversationalPIIResults";

- from: swagger-document
  where: $.definitions.AnalyzeConversationSummarizationResult
  transform: >
    $["x-ms-discriminator-value"] = "conversationalSummarizationResults";

# Always default to UTF16 string indices.
- from: swagger-document
  where: $.definitions.StringIndexType
  transform: >
    $["description"] = "Specifies the method used to interpret string offsets. Set this to \"Utf16CodeUnit\" for .NET strings, which are encoded as UTF-16.";
    $["x-ms-client-default"] = "Utf16CodeUnit";

# Fix Endpoint parameter description and format.
- from: swagger-document
  where: $.parameters.Endpoint
  transform: |
    $["description"] = "Supported Cognitive Services endpoint (e.g., https://<resource-name>.cognitiveservices.azure.com).";
    $["format"] = "url";

# Put all operations into a single REST client.
- rename-operation:
    from: AnalyzeConversation_SubmitJob
    to: ConversationAnalysis_SubmitJob
- rename-operation:
    from: AnalyzeConversation_JobStatus
    to: ConversationAnalysis_GetJobStatus
- rename-operation:
    from: AnalyzeConversation_CancelJob
    to: ConversationAnalysis_CancelJob
```
