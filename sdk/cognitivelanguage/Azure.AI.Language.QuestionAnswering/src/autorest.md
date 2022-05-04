# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
# The title here is used to generate the single ClientOptions class name.
title: Question Answering
license-header: MICROSOFT_MIT_NO_VERSION

batch:
- input-file: https://raw.githubusercontent.com/Azure/azure-rest-api-specs/1234/specification/cognitiveservices/data-plane/Language/stable/2021-10-01/questionanswering.json
  clear-output-folder: true
  model-namespace: false
  generation1-convenience-client: true

- input-file: https://raw.githubusercontent.com/Azure/azure-rest-api-specs/1234/specification/cognitiveservices/data-plane/Language/stable/2021-10-01/questionanswering-authoring.json
# namespace: Azure.AI.Language.QuestionAnswering.Projects
  add-credentials: true

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
### DocString edit

``` yaml
directive:
  - from: swagger-document
    where: $["paths"]["/query-knowledgebases/projects/{projectName}/feedback"]["post"]
    transform: >
        $["summary"] = "Add Active Learning feedback";
```

### C# customizations

``` yaml
directive:
- from: swagger-document
  where: $.parameters.Endpoint
  transform: $["format"] = "url"
```
