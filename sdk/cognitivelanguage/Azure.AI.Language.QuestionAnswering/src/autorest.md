# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
# The title here is used to generate the single ClientOptions class name.
title: Question Answering
license-header: MICROSOFT_MIT_NO_VERSION

batch:
- input-file: https://raw.githubusercontent.com/Azure/azure-rest-api-specs/2fe971edcf58b3351e6e5e67d269d4b4c7cc2c5f/specification/cognitiveservices/data-plane/Language/stable/2021-10-01/questionanswering.json
  clear-output-folder: true
  model-namespace: false
  generation1-convenience-client: true

- input-file: https://raw.githubusercontent.com/Azure/azure-rest-api-specs/b791f57426508cb2793a8911650a416dcb11c6a6/specification/cognitiveservices/data-plane/Language/stable/2021-10-01/questionanswering-authoring.json
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
# Support automatically generating code for key credentials.
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

# Fix Endpoint parameter description and format.
- from: swagger-document
  where: $.parameters.Endpoint
  transform: $["format"] = "url"

# Update documentation.
- from: swagger-document
  where: $["paths"]["/query-knowledgebases/projects/{projectName}/feedback"]["post"]
  transform: >
    $["summary"] = "Add Active Learning feedback";

# Define HTTP 200 responses for LROs to document result model.
- where-operation: QuestionAnsweringProjects_DeleteProject
  transform: |
    $.responses["200"] = {
      description: "Project delete job status.",
      schema: {
        "$ref": "#/definitions/JobState"
      }
    };

- where-operation: QuestionAnsweringProjects_DeployProject
  transform: |
    $.responses["200"] = {
      description: "Deploy job state.",
      schema: {
        "$ref": "#/definitions/JobState"
      }
    };

- where-operation: QuestionAnsweringProjects_Import
  transform: |
    $.responses["200"] = {
      description: "Gets the status of an Import job.",
      schema: {
        "$ref": "#/definitions/JobState"
      }
    };

- where-operation: QuestionAnsweringProjects_UpdateQnas
  transform: |
    $.responses["200"] = {
      description: "Update QnAs job state.",
      schema: {
        "$ref": "#/definitions/JobState"
      }
    };

- where-operation: QuestionAnsweringProjects_UpdateSources
  transform: |
    $.responses["200"] = {
      description: "Update sources job state.",
      schema: {
        "$ref": "#/definitions/JobState"
      }
    };
```
