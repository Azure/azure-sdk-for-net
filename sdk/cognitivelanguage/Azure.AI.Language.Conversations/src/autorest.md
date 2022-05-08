# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
# The title here is used to generate the single ClientOptions class name.
title: Conversations
license-header: MICROSOFT_MIT_NO_VERSION

batch:
- input-file: https://raw.githubusercontent.com/Azure/azure-rest-api-specs/6e137f0849ff79637544c773ad6da9e7bff3faf1/specification/cognitiveservices/data-plane/Language/preview/2022-05-15-preview/analyzeconversations.json
  clear-output-folder: true
  model-namespace: false
  generation1-convenience-client: true

# TODO: Uncomment when we ship authoring support and remove ./ConversationsClientOptions.cs.
# - input-file: https://raw.githubusercontent.com/Azure/azure-rest-api-specs/33138867cd88a4a8689feb591a98dda26d96a63e/specification/cognitiveservices/data-plane/Language/preview/2021-07-15-preview/analyzeconversations-authoring.json
#   add-credentials: true
#   data-plane: true

modelerfour:
  lenient-model-deduplication: true
```

## Customizations

Customizations that should eventually be added to central autorest configuration.

### General customizations

Support automatically generating code for key credentials.

``` yaml
directive:
- from: swagger-document
  where: $.securityDefinitions
  transform: |
    $["AzureKey"] = $["apim_key"];
    delete $["apim_key"];

- from: swagger-document
  where: $.security
  transform: |
    $ = [
        {
          "AzureKey": []
        }
    ];
```

### C# customizations

``` yaml
directive:
- from: swagger-document
  where: $.parameters.Endpoint
  transform: $["format"] = "url"
```

```yaml
directive:
    - from: swagger-document
      where: $["paths"]["/analyze-conversations/jobs"]["post"]
      transform: >
          $["operationId"] = "ConversationAnalysis_SubmitJob";
```

```yaml
directive:
    - from: swagger-document
      where: $["paths"]["/analyze-conversations/jobs/{jobId}"]["get"]
      transform: >
          $["operationId"] = "ConversationAnalysis_JobStatus";
```
## Fix Swagger/API mismatch errors

### Change api version

```yaml
directive:
    - from: swagger-document
      where: $["info"]
      transform: >
          $["version"] = "2022-04-01-preview";
```

### Fix mis-matching task types

```yaml
directive:
    - from: swagger-document
      where: $["definitions"]["AnalyzeConversationSummarizationTask"]
      transform: >
        $["x-ms-discriminator-value"] = "IssueResolutionSummarization";
```

```yaml
directive:
    - from: swagger-document
      where: $["definitions"]["AnalyzeConversationPIITask"]
      transform: >
        $["x-ms-discriminator-value"] = "ConversationPII";
```

### Fix `modality` required errors and default values

```yaml
directive:
    - from: swagger-document
      where: $["definitions"]["ConversationItemBase"]
      transform: >
        $["required"] = ["id", "participantId", "modality"];
```

```yaml
directive:
    - from: swagger-document
      where: $["definitions"]
      transform: >
        $["ConversationItemBase"]["discriminator"] = "modality";
```

```yaml
directive:
    - from: swagger-document
      where: $["definitions"]
      transform: >
        $["TextConversationItem"]["x-ms-discriminator-value"] = "text";
```

```yaml
directive:
    - from: swagger-document
      where: $["definitions"]
      transform: >
        $["TranscriptConversationItem"]["x-ms-discriminator-value"] = "transcript";
```

### Fix `summary aspects` to be string instead of enum

```yaml
directive:
    - from: swagger-document
      where: $["definitions"]["ConversationSummarizationTaskParameters"]
      transform: >
        $["properties"]["summaryAspects"] = {
            "type": "string",
            "enum": [
              "Issue",
              "Resolution",
              "Issue, Resolution"
            ],
            "x-ms-enum": {
              "name": "SummaryAspectEnum",
              "modelAsString": true
            }
          };
```

### Fix `kind` enum values in action results

```yaml
directive:
    - from: swagger-document
      where: $["definitions"]["AnalyzeConversationResultsKind"]
      transform: >
        $["enum"] = ["issueResolutionSummaryResults", "conversationPIIResults"];
```

```yaml
directive:
    - from: swagger-document
      where: $["definitions"]["AnalyzeConversationSummarizationResult"]
      transform: >
        $["x-ms-discriminator-value"] = "issueResolutionSummaryResults";
```

```yaml
directive:
    - from: swagger-document
      where: $["definitions"]["AnalyzeConversationConversationPIIResult"]
      transform: >
        $["x-ms-discriminator-value"] = "conversationPIIResults";
```

### Fix mis-match in `TranscriptConversationItem` item structure

```yaml
directive:
    - from: swagger-document
      where: $["definitions"]["TranscriptConversationItem"]
      transform: >
        delete $["properties"]["itn"];
        delete $["properties"]["maskedItn"];
        delete $["properties"]["text"];
        delete $["properties"]["lexical"];
        delete $["properties"]["audioTimings"];
        delete $["required"];
```

```yaml
directive:
    - from: swagger-document
      where: $["definitions"]["TranscriptConversationItem"]
      transform: >
        $["properties"]["content"] = {
            "$ref": "#/definitions/TranscriptConversationItemContent"
          };
```

```yaml
directive:
    - from: swagger-document
      where: $["definitions"]
      transform: >
        $["TranscriptConversationItemContent"] = {
            "type": "object",
            "description": "Additional properties for supporting transcript conversation.",
            "required": [
                "text",
                "lexical",
                "itn",
                "maskedItn"
            ],
            "properties": {
                "text": {
                    "type": "string",
                    "description": "The display form of the recognized text from speech to text API, with punctuation and capitalization added."
                },
                "lexical": {
                    "type": "string",
                    "description": "The lexical form of the recognized text from speech to text API with the actual words recognized."
                },
                "itn": {
                    "type": "string",
                    "description": "Inverse Text Normalization representation of input. The inverse-text-normalized form is the recognized text from Microsoft’s Speech to Text API, with phone numbers, numbers, abbreviations, and other transformations applied."
                },
                "maskedItn": {
                    "type": "string",
                    "description": "The Inverse Text Normalized format with profanity masking applied."
                },
                "audioTimings": {
                    "type": "array",
                    "description": "The list of word level audio timing information",
                    "items": {
                        "$ref": "#/definitions/WordLevelTiming"
                    }
                }
            }
        };
```
