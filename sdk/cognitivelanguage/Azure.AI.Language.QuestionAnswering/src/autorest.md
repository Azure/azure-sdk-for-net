# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
# The title here is used to generate the single ClientOptions class name.
title: Question Answering
license-header: MICROSOFT_MIT_NO_VERSION

batch:
- input-file: https://raw.githubusercontent.com/Azure/azure-rest-api-specs/34a2c0723155d134311419fd997925ce96b85bec/specification/cognitiveservices/data-plane/Language/stable/2021-10-01/questionanswering.json
  clear-output-folder: true
  model-namespace: false

# TODO: Uncomment when we ship authoring support and remove ./QuestionAnsweringClientOptions.cs.
# - input-file: https://raw.githubusercontent.com/Azure/azure-rest-api-specs/34a2c0723155d134311419fd997925ce96b85bec/specification/cognitiveservices/data-plane/Language/stable/2021-10-01/questionanswering-authoring.json
#   add-credentials: true
#   low-level-client: true

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
