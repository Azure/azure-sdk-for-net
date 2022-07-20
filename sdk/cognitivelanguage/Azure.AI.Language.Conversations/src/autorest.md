# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
# The title here is used to generate the single ClientOptions class name.
title: Conversations
license-header: MICROSOFT_MIT_NO_VERSION

input-file:
- https://raw.githubusercontent.com/Azure/azure-rest-api-specs/e7f37e4e43b1d12fd1988fda3ed39624c4b23303/specification/cognitiveservices/data-plane/Language/preview/2022-05-15-preview/analyzeconversations.json
- https://raw.githubusercontent.com/Azure/azure-rest-api-specs/e7f37e4e43b1d12fd1988fda3ed39624c4b23303/specification/cognitiveservices/data-plane/Language/preview/2022-05-15-preview/analyzeconversations-authoring.json
clear-output-folder: true

data-plane: true
model-namespace: false

add-credential: true
credential-scopes: https://cognitiveservices.azure.com/.default

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
- where-operation: AnalyzeConversation_SubmitJob
  transform: |
    $.responses["200"] = {
      description: "Analysis job status and metadata.",
      schema: {
        "$ref": "#/definitions/AnalyzeConversationJobState"
      }
    };

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

# Update descriptions to include a link to the REST API documentation.
- from: analyzeconversations.json
  where: $.paths.*.*
  transform: |
    var operationId = $.operationId.substring("ConversationAnalysis_".length);
    // BUGBUG: Will not work until https://github.com/Azure/autorest.csharp/issues/2384 is fixed.
    $["externalDocs"] = {
        url: "https://docs.microsoft.com/rest/api/language/conversation-analysis-runtime/" + operationId.replace(/([a-z0�9])([A-Z])/g, "$1-$2").toLowerCase()
    };

- from: analyzeconversations-authoring.json
  where: $.paths.*.*
  transform: |
    var operationId = $.operationId.substring("ConversationalAnalysisAuthoring_".length);
    // BUGBUG: Will not work until https://github.com/Azure/autorest.csharp/issues/2384 is fixed.
    $["externalDocs"] = {
        url: "https://docs.microsoft.com/rest/api/language/conversational-analysis-authoring/" + operationId.replace(/([a-z0�9])([A-Z])/g, "$1-$2").toLowerCase()
    };

# Mark the LRO as internal so we can call it from an overload, which we can't do using transforms since that results in duplicate operationIds.
- where-operation: AnalyzeConversation_SubmitJob
  transform: |
    $["x-accessibility"] = "internal";

# Rename operations to be consistent. Do this after other operation transforms for ease.
- rename-operation:
    from: AnalyzeConversation_SubmitJob
    to: ConversationAnalysis_StartAnalyzeConversation

- rename-operation:
    from: AnalyzeConversation_JobStatus
    to: ConversationAnalysis_GetAnalyzeConversationJobStatus

- rename-operation:
    from: AnalyzeConversation_CancelJob
    to: ConversationAnalysis_CancelAnalyzeConversationJob

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
