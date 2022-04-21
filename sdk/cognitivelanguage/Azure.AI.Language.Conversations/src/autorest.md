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
