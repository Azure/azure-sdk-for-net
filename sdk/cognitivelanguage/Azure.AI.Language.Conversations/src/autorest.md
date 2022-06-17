# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
# The title here is used to generate the single ClientOptions class name.
title: Conversations
license-header: MICROSOFT_MIT_NO_VERSION

batch:
- input-file: https://raw.githubusercontent.com/Azure/azure-rest-api-specs/9be5d475168131b188f254f5d14b23086512a9d3/specification/cognitiveservices/data-plane/Language/stable/2022-05-01/analyzeconversations.json
  clear-output-folder: true
  model-namespace: false
  generation1-convenience-client: true

# TODO: Uncomment when we ship authoring support and remove ./ConversationsClientOptions.cs.
# - input-file: https://raw.githubusercontent.com/Azure/azure-rest-api-specs/9be5d475168131b188f254f5d14b23086512a9d3/specification/cognitiveservices/data-plane/Language/stable/2022-05-01/analyzeconversations-authoring.json
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
