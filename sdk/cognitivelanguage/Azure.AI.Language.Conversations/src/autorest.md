# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
# The title here is used to generate the single ClientOptions class name.
title: Conversations
license-header: MICROSOFT_MIT_NO_VERSION

batch:
- input-file: https://raw.githubusercontent.com/Azure/azure-rest-api-specs/725f4ca360426a32d20e81eb945065e62c285d6a/specification/cognitiveservices/data-plane/Language/stable/2022-05-01/analyzeconversations.json
  clear-output-folder: true

- input-file: https://raw.githubusercontent.com/Azure/azure-rest-api-specs/725f4ca360426a32d20e81eb945065e62c285d6a/specification/cognitiveservices/data-plane/Language/stable/2022-05-01/analyzeconversations-authoring.json

data-plane: true
model-namespace: false

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

# Always default to UTF16 string indices.
- from: swagger-document
  where: $.definitions.StringIndexType
  transform: >
    $["description"] = "Specifies the method used to interpret string offsets. Set this to \"Utf16CodeUnit\" for .NET strings, which are encoded as UTF-16.";
    $["x-ms-client-default"] = "Utf16CodeUnit";

- from: swagger-document
  where: $.definitions.ConversationalAnalysisAuthoringStringIndexType
  transform: >
    $["description"] = "Specifies the method used to interpret string offsets. Set this to \"Utf16CodeUnit\" for .NET strings, which are encoded as UTF-16.";
    $["x-ms-client-default"] = "Utf16CodeUnit";

- from: swagger-document
  where: $.parameters.ConversationalAnalysisAuthoringStringIndexTypeQueryParameter
  transform: >
    $["description"] = "Specifies the method used to interpret string offsets. Set this to \"Utf16CodeUnit\" for .NET strings, which are encoded as UTF-16.";
    $["x-ms-client-default"] = "Utf16CodeUnit";

# Correct Endpoint parameter description to reference right domain suffix.
- from: swagger-document
  where: $.parameters.Endpoint
  transform: >
    $["description"] = "Supported Cognitive Services endpoint (e.g., https://<resource-name>.cognitiveservices.azure.com)."
```
