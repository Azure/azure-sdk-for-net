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
  namespace: Azure.AI.Language.Conversations.Authoring

data-plane: true
model-namespace: false

modelerfour:
  lenient-model-deduplication: true
```

## Customizations

Customizations that should eventually be added to central autorest configuration.

### General customizations

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
  transform: |
    $["description"] = "Supported Cognitive Services endpoint (e.g., https://<resource-name>.cognitiveservices.azure.com).";
    $["format"] = "url";

# Define multilingual parameter as a boolean.
- where-operation: ConversationalAnalysisAuthoring_GetSupportedPrebuiltEntities
  transform: |
    var multilingualParam = $.parameters.find(param => param.name === "multilingual");
    multilingualParam.type = "boolean";

# Define HTTP 200 responses for LROs to document result model.
- where-operation: ConversationalAnalysisAuthoring_DeleteProject
  transform: |
    $.responses["200"] = {
      description: "The project deletion job result.",
      schema: {
        "$ref": "#/definitions/ConversationalAnalysisAuthoringProjectDeletionJobState"
      }
    };

- where-operation: ConversationalAnalysisAuthoring_Export
  transform: |
    $.responses["200"] = {
      description: "The status of the long running operation.",
      schema: {
        "$ref": "#/definitions/ConversationalAnalysisAuthoringExportProjectJobState"
      }
    };

- where-operation: ConversationalAnalysisAuthoring_Import
  transform: |
    $.responses["200"] = {
      description: "The details of the long running operation.",
      schema: {
        "$ref": "#/definitions/ConversationalAnalysisAuthoringImportProjectJobState"
      }
    };

- where-operation: ConversationalAnalysisAuthoring_Train
  transform: |
    $.responses["200"] = {
      description: "The training job result.",
      schema: {
        "$ref": "#/definitions/ConversationalAnalysisAuthoringTrainingJobState"
      }
    };

- where-operation: ConversationalAnalysisAuthoring_SwapDeployments
  transform: |
    $.responses["200"] = {
      description: "The swap deployment job result.",
      schema: {
        "$ref": "#/definitions/ConversationalAnalysisAuthoringDeploymentJobState"
      }
    };

- where-operation: ConversationalAnalysisAuthoring_DeployProject
  transform: |
    $.responses["200"] = {
      description: "The deployment job result.",
      schema: {
        "$ref": "#/definitions/ConversationalAnalysisAuthoringProjectDeployment"
      }
    };

- where-operation: ConversationalAnalysisAuthoring_DeleteDeployment
  transform: |
    $.responses["200"] = {
      description: "The deployment job result.",
      schema: {
        "$ref": "#/definitions/ConversationalAnalysisAuthoringDeploymentJobState"
      }
    };

- where-operation: ConversationalAnalysisAuthoring_CancelTrainingJob
  transform: |
    $.responses["200"] = {
      description: "The training job result.",
      schema: {
        "$ref": "#/definitions/ConversationalAnalysisAuthoringTrainingJobState"
      }
    };

# Move the stringIndexType parameter to the end for all operations referencing it.
- where-operation: ConversationalAnalysisAuthoring_Export
  transform: |
    var stringIndexTypeParamIndex = $.parameters.findIndex(param => param["$ref"] === "#/parameters/ConversationalAnalysisAuthoringStringIndexTypeQueryParameter");
    var stringIndexTypeParam = $.parameters[stringIndexTypeParamIndex];

    var apiVersionParamIndex = $.parameters.findIndex(param => param["$ref"] === "common.json#/parameters/ApiVersionParameter");
    var apiVersionParam = $.parameters[apiVersionParamIndex];

    $.parameters.splice(stringIndexTypeParamIndex, 1);
    $.parameters.splice(apiVersionParamIndex - 1, 1);

    $.parameters.push(stringIndexTypeParam);
    $.parameters.push(apiVersionParam);

# Rename operations to be consistent. Do this after other operation transforms for ease.
- rename-operation:
    from: ConversationalAnalysisAuthoring_Export
    to: ConversationalAnalysisAuthoring_ExportProject

- rename-operation:
    from: ConversationalAnalysisAuthoring_GetDeploymentStatus
    to: ConversationalAnalysisAuthoring_GetDeploymentJobStatus

- rename-operation:
    from: ConversationalAnalysisAuthoring_GetExportStatus
    to: ConversationalAnalysisAuthoring_GetExportProjectJobStatus

- rename-operation:
    from: ConversationalAnalysisAuthoring_GetImportStatus
    to: ConversationalAnalysisAuthoring_GetImportProjectJobStatus

- rename-operation:
    from: ConversationalAnalysisAuthoring_GetProjectDeletionStatus
    to: ConversationalAnalysisAuthoring_GetProjectDeletionJobStatus

- rename-operation:
    from: ConversationalAnalysisAuthoring_GetSwapDeploymentsStatus
    to: ConversationalAnalysisAuthoring_GetSwapDeploymentsJobStatus

- rename-operation:
    from: ConversationalAnalysisAuthoring_GetTrainingStatus
    to: ConversationalAnalysisAuthoring_GetTrainingJobStatus

- rename-operation:
    from: ConversationalAnalysisAuthoring_Import
    to: ConversationalAnalysisAuthoring_ImportProject
```

### C# customizations

``` yaml
directive:
# Always default to UTF16 string indices.
- from: swagger-document
  where: $.definitions.StringIndexType
  transform: |
    $["description"] = "Specifies the method used to interpret string offsets. Set this to \"Utf16CodeUnit\" for .NET strings, which are encoded as UTF-16.";
    $["x-ms-client-default"] = "Utf16CodeUnit";

- from: swagger-document
  where: $.definitions.ConversationalAnalysisAuthoringStringIndexType
  transform: |
    $["description"] = "Specifies the method used to interpret string offsets. Set this to \"Utf16CodeUnit\" for .NET strings, which are encoded as UTF-16.";
    $["x-ms-client-default"] = "Utf16CodeUnit";

- from: swagger-document
  where: $.parameters.ConversationalAnalysisAuthoringStringIndexTypeQueryParameter
  transform: |
    $["description"] = "Specifies the method used to interpret string offsets. Set this to \"Utf16CodeUnit\" for .NET strings, which are encoded as UTF-16.";
    $["x-ms-client-default"] = "Utf16CodeUnit";

# Remove explicit paging parameters until Azure/azure-sdk-for-net#29342 is resolved.
# where-operation-match (Azure/autorest#4565) and remove-parameter (Azure/autorest#4566) do not work correctly.
- from: swagger-document
  where: $.paths.*.*
  transform: |
    var paramRefs = [
        "common.json#/parameters/TopParameter",
        "common.json#/parameters/SkipParameter",
        "common.json#/parameters/MaxPageSizeParameter"
    ];
    if (/ConversationalAnalysisAuthoring_((List(Projects|Deployments|TrainedModels|TrainingJobs|TrainingConfigVersions))|Get(ModelEvaluationResults|SupportedLanguages|SupportedPrebuiltEntities))/.test($.operationId)) {
        $.parameters = $.parameters.filter(param => !paramRefs.includes(param["$ref"]));
    }
```
