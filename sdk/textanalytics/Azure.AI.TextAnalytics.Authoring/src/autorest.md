# Azure Text Analytics Authoring Client for .NET

> see https://aka.ms/autorest

### Setup

Install Autorest v3

```ps
npm install -g autorest
```

### Generation

```ps
cd <swagger-folder>
autorest
```

## Configuration

```yaml
license-header: MICROSOFT_MIT_NO_VERSION
namespace: Azure.AI.TextAnalytics.Authoring
data-plane: true
tag: release_2022_10_01_preview
clear-output-folder: true
version-tolerant: true
security:
    - AADToken
    - AzureKey
security-scopes: https://cognitiveservices.azure.com/.default
security-header-name: ocp-apim-subscription-key
modelerfour:
  lenient-model-deduplication: true
```

## Batch Execution

```yaml
batch:
  - tag: release_2022_10_01_preview
```

## Authoring

These settings apply only when `--tag=release_2022_10_01_preview` is specified on the command line.

```yaml $(tag) == 'release_2022_10_01_preview'
input-file: https://raw.githubusercontent.com/Azure/azure-rest-api-specs/main/specification/cognitiveservices/data-plane/Language/preview/2022-10-01-preview/analyzetext-authoring.json
title: TextAuthoringClient
```

## Customizations

Customizations that should eventually be added to central autorest configuration.

### General customizations

```yaml
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
```

### C# customizations

```yaml
directive:
# Always default to UnicodeCodePoint string indices.
- from: swagger-document
  where: $.definitions.StringIndexType
  transform: |
    $["description"] = "Specifies the method used to interpret string offsets. Set to \"Utf16CodeUnit\" for .NET strings.";
    $["x-ms-client-default"] = "Utf16CodeUnit";
```

### Authoring API Directives

## Give LROs return types

```yaml $(tag) == 'release_2022_10_01_preview'
directive:
  - where-operation: TextAnalysisAuthoring_DeleteProject
    transform: >
      $["responses"]["200"] = {
        "description": "dummy schema to get poller response when calling .result()",
        "schema": {
          "$ref": "#/definitions/TextAnalysisAuthoringProjectDeletionJobState"
        }
      };
  - where-operation: TextAnalysisAuthoring_Export
    transform: >
      $["responses"]["200"] = {
        "description": "dummy schema to get poller response when calling .result()",
        "schema": {
          "$ref": "#/definitions/TextAnalysisAuthoringExportProjectJobState"
        }
      };
  - where-operation: TextAnalysisAuthoring_Import
    transform: >
      $["responses"]["200"] = {
        "description": "dummy schema to get poller response when calling .result()",
        "schema": {
          "$ref": "#/definitions/TextAnalysisAuthoringImportProjectJobState"
        }
      };
  - where-operation: TextAnalysisAuthoring_Train
    transform: >
      $["responses"]["200"] = {
        "description": "dummy schema to get poller response when calling .result()",
        "schema": {
          "$ref": "#/definitions/TextAnalysisAuthoringTrainingJobState"
        }
      };
  - where-operation: TextAnalysisAuthoring_DeployProject
    transform: >
      $["responses"]["200"] = {
        "description": "dummy schema to get poller response when calling .result()",
        "schema": {
          "$ref": "#/definitions/TextAnalysisAuthoringProjectDeployment"
        }
      };
  - where-operation: TextAnalysisAuthoring_SwapDeployments
    transform: >
      $["responses"]["200"] = {
        "description": "dummy schema to get poller response when calling .result()",
        "schema": {
          "$ref": "#/definitions/TextAnalysisAuthoringDeploymentJobState"
        }
      };
  - where-operation: TextAnalysisAuthoring_DeleteDeployment
    transform: >
      $["responses"]["200"] = {
        "description": "dummy schema to get poller response when calling .result()",
        "schema": {
          "$ref": "#/definitions/TextAnalysisAuthoringDeploymentJobState"
        }
      };
  - where-operation: TextAnalysisAuthoring_CancelTrainingJob
    transform: >
      $["responses"]["200"] = {
        "description": "dummy schema to get poller response when calling .result()",
        "schema": {
          "$ref": "#/definitions/TextAnalysisAuthoringTrainingJobState"
        }
      };
  - where-operation: TextAnalysisAuthoring_DeleteDeploymentFromResources
    transform: >
      $["responses"]["200"] = {
        "description": "dummy schema to get poller response when calling .result()",
        "schema": {
          "$ref": "#/definitions/TextAnalysisAuthoringDeploymentJobState"
        }
      };
  - where-operation: TextAnalysisAuthoring_LoadSnapshot
    transform: >
      $["responses"]["200"] = {
        "description": "dummy schema to get poller response when calling .result()",
        "schema": {
          "$ref": "#/definitions/TextAnalysisAuthoringLoadSnapshotJobState"
        }
      };
  - where-operation: TextAnalysisAuthoring_AssignDeploymentResources
    transform: >
      $["responses"]["200"] = {
        "description": "dummy schema to get poller response when calling .result()",
        "schema": {
          "$ref": "#/definitions/TextAnalysisAuthoringDeploymentResourcesJobState"
        }
      };
  - where-operation: TextAnalysisAuthoring_UnassignDeploymentResources
    transform: >
      $["responses"]["200"] = {
        "description": "dummy schema to get poller response when calling .result()",
        "schema": {
          "$ref": "#/definitions/TextAnalysisAuthoringDeploymentResourcesJobState"
        }
      };
```

## Rename `body` param for operations

```yaml $(tag) == 'release_2022_10_01_preview'
directive:
  - where-operation: TextAnalysisAuthoring_CreateProject
    transform: >
        $.parameters[1]["x-ms-client-name"] = "project_options";
  - where-operation: TextAnalysisAuthoring_Import
    transform: >
        $.parameters[1]["x-ms-client-name"] = "project_data";
  - where-operation: TextAnalysisAuthoring_Train
    transform: >
        $.parameters[1]["x-ms-client-name"] = "training_options";
  - where-operation: TextAnalysisAuthoring_SwapDeployments
    transform: >
        $.parameters[1]["x-ms-client-name"] = "deployments";
  - where-operation: TextAnalysisAuthoring_DeployProject
    transform: >
        $.parameters[2]["x-ms-client-name"] = "deployment_options";
```

## Rename Authoring client operations

```yaml $(tag) == 'release_2022_10_01_preview'
directive:
  - rename-operation:
      from: TextAnalysisAuthoring_ListProjects
      to: ListProjects
  - rename-operation:
      from: TextAnalysisAuthoring_CreateProject
      to: CreateProject
  - rename-operation:
      from: TextAnalysisAuthoring_GetProject
      to: GetProject
  - rename-operation:
      from: TextAnalysisAuthoring_DeleteProject
      to: DeleteProject
  - rename-operation:
      from: TextAnalysisAuthoring_Export
      to: ExportProject
  - rename-operation:
      from: TextAnalysisAuthoring_Import
      to: ImportProject
  - rename-operation:
      from: TextAnalysisAuthoring_Train
      to: Train
  - rename-operation:
      from: TextAnalysisAuthoring_ListDeployments
      to: ListDeployments
  - rename-operation:
      from: TextAnalysisAuthoring_SwapDeployments
      to: SwapDeployments
  - rename-operation:
      from: TextAnalysisAuthoring_GetDeployment
      to: GetDeployment
  - rename-operation:
      from: TextAnalysisAuthoring_DeployProject
      to: DeployProject
  - rename-operation:
      from: TextAnalysisAuthoring_DeleteDeployment
      to: DeleteDeployment
  - rename-operation:
      from: TextAnalysisAuthoring_ListTrainedModels
      to: ListTrainedModels
  - rename-operation:
      from: TextAnalysisAuthoring_GetTrainedModel
      to: GetTrainedModel
  - rename-operation:
      from: TextAnalysisAuthoring_DeleteTrainedModel
      to: DeleteTrainedModel
  - rename-operation:
      from: TextAnalysisAuthoring_GetModelEvaluationResults
      to: ListModelEvaluationResults
  - rename-operation:
      from: TextAnalysisAuthoring_GetModelEvaluationSummary
      to: GetModelEvaluationSummary
  - rename-operation:
      from: TextAnalysisAuthoring_ListTrainingJobs
      to: ListTrainingJobs
  - rename-operation:
      from: TextAnalysisAuthoring_CancelTrainingJob
      to: CancelTrainingJob
  - rename-operation:
      from: TextAnalysisAuthoring_GetSupportedLanguages
      to: ListSupportedLanguages
  - rename-operation:
      from: TextAnalysisAuthoring_ListTrainingConfigVersions
      to: ListTrainingConfigVersions
  - rename-operation:
      from: TextAnalysisAuthoring_GetProjectDeletionStatus
      to: GetProjectDeletionJobStatus
  - rename-operation:
      from: TextAnalysisAuthoring_GetTrainingStatus
      to: GetTrainingJobStatus
  - rename-operation:
      from: TextAnalysisAuthoring_GetDeploymentStatus
      to: GetDeploymentJobStatus
  - rename-operation:
      from: TextAnalysisAuthoring_GetSwapDeploymentsStatus
      to: GetSwapDeploymentsJobStatus
  - rename-operation:
      from: TextAnalysisAuthoring_GetExportStatus
      to: GetExportProjectJobStatus
  - rename-operation:
      from: TextAnalysisAuthoring_GetImportStatus
      to: GetImportProjectJobStatus
  - rename-operation:
      from: TextAnalysisAuthoring_DeleteDeploymentFromResources
      to: DeleteDeploymentFromResources
  - rename-operation:
      from: TextAnalysisAuthoring_GetDeploymentDeleteFromResourcesStatus
      to: GetDeploymentDeleteFromResourcesStatus
  - rename-operation:
      from: TextAnalysisAuthoring_LoadSnapshot
      to: LoadSnapshot
  - rename-operation:
      from: TextAnalysisAuthoring_GetLoadSnapshotStatus
      to: GetLoadSnapshotStatus
  - rename-operation:
      from: TextAnalysisAuthoring_ListDeploymentResources
      to: ListDeploymentResources
  - rename-operation:
      from: TextAnalysisAuthoring_AssignDeploymentResources
      to: AssignDeploymentResources
  - rename-operation:
      from: TextAnalysisAuthoring_UnassignDeploymentResources
      to: UnassignDeploymentResources
  - rename-operation:
      from: TextAnalysisAuthoring_GetAssignDeploymentResourcesStatus
      to: GetAssignDeploymentResourcesStatus
  - rename-operation:
      from: TextAnalysisAuthoring_GetUnassignDeploymentResourcesStatus
      to: GetUnassignDeploymentResourcesStatus
  - rename-operation:
      from: TextAnalysisAuthoring_ListAssignedResourceDeployments
      to: ListAssignedResourceDeployments
```