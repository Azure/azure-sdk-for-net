# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
# The title here is used to generate the single ClientOptions class name.
title: Question Answering
license-header: MICROSOFT_MIT_NO_VERSION

batch:
- input-file: https://raw.githubusercontent.com/Azure/azure-rest-api-specs/59ad2b7dd63e952822aa51e11a26a0af5724f996/specification/cognitiveservices/data-plane/Language/stable/2021-10-01/questionanswering.json
  clear-output-folder: true
  model-namespace: false
  generation1-convenience-client: true

- input-file: https://raw.githubusercontent.com/Azure/azure-rest-api-specs/59ad2b7dd63e952822aa51e11a26a0af5724f996/specification/cognitiveservices/data-plane/Language/stable/2021-10-01/questionanswering-authoring.json
  namespace: Azure.AI.Language.QuestionAnswering.Authoring
  add-credentials: true
  data-plane: true
  keep-non-overloadable-protocol-signature: true

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
- where-operation: QuestionAnsweringProjects_AddFeedback
  transform: >
    $["summary"] = "Add Active Learning feedback";

# Define HTTP 200 responses for LROs to document result model.
- where-operation: QuestionAnsweringProjects_DeployProject
  transform: |
    $.responses["200"] = {
      description: "Project deployment details.",
      schema: {
        "$ref": "#/definitions/ProjectDeployment"
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
    $["x-ms-pageable"] = {
      "nextLinkName": "nextLink",
      "itemName": "value"
    };
    $.responses["200"] = {
      description: "All the QnAs of a project.",
      schema: {
        "$ref": "#/definitions/QnaAssets"
      }
    };

- where-operation: QuestionAnsweringProjects_UpdateSources
  transform: |
    $["x-ms-pageable"] = {
      "nextLinkName": "nextLink",
      "itemName": "value"
    };
    $.responses["200"] = {
      description: "All the sources of a project.",
      schema: {
        "$ref": "#/definitions/QnaSources"
      }
    };

# Add links to REST documentation. Use any renamed operations preceeding this transform.
# BUGBUG: Cannot use where-operation-match: https://github.com/Azure/azure-sdk-for-net/issues/31451
- from: questionanswering-authoring.json
  where: $.paths.*.*
  transform: |
    var operationId = $.operationId.replace(/_/g, "/").replace(/([a-z0-9])([A-Z])/g, "$1-$2").toLowerCase();
    $["externalDocs"] = {
        url: "https://learn.microsoft.com/rest/api/cognitiveservices/questionanswering/" + operationId
    };

```

### C# customizations

``` yaml
directive:
# Remove explicit paging parameters until Azure/azure-sdk-for-net#29342 is resolved.
- from: questionanswering-authoring.json
  where: $.paths.*[?(@["x-ms-pageable"])]
  transform: |
    var paramRefs = [
        "common.json#/parameters/TopParameter",
        "common.json#/parameters/SkipParameter",
        "common.json#/parameters/MaxPageSizeParameter"
    ];
    $.parameters = $.parameters.filter(param => !paramRefs.includes(param["$ref"]));

```
