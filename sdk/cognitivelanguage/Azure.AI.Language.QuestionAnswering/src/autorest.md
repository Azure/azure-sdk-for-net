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

# TODO: Uncomment when we ship authoring support and remove ./QuestionAnsweringClientOptions.cs.
- input-file: https://raw.githubusercontent.com/Azure/azure-rest-api-specs/2fe971edcf58b3351e6e5e67d269d4b4c7cc2c5f/specification/cognitiveservices/data-plane/Language/stable/2021-10-01/questionanswering-authoring.json
# namespace: Azure.AI.Language.QuestionAnswering.Projects
  add-credentials: true
  data-plane: true

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

### OperationId renames QuestionAnsweringAuthoring -> QuestionAnsweringProjects

<!-- TODO: If these transforms are not needed, remove them. https://github.com/Azure/azure-sdk-for-net/issues/26173 -->

```yaml
directive:
  - from: swagger-document
    where: $["paths"]["/query-knowledgebases/projects"]["get"]
    transform: >
        $["operationId"] = "QuestionAnsweringProjects_ListProjects";

  - from: swagger-document
    where: $["paths"]["/query-knowledgebases/projects/{projectName}"]["get"]
    transform: >
        $["operationId"] = "QuestionAnsweringProjects_GetProjectDetails";
  
  - from: swagger-document
    where: $["paths"]["/query-knowledgebases/projects/{projectName}"]["patch"]
    transform: >
        $["operationId"] = "QuestionAnsweringProjects_CreateProject";

  - from: swagger-document
    where: $["paths"]["/query-knowledgebases/projects/{projectName}"]["delete"]
    transform: >
        $["operationId"] = "QuestionAnsweringProjects_DeleteProject";

  - from: swagger-document
    where: $["paths"]["/query-knowledgebases/projects/deletion-jobs/{jobId}"]["get"]
    transform: >
        $["operationId"] = "QuestionAnsweringProjects_GetDeleteStatus";

  - from: swagger-document
    where: $["paths"]["/query-knowledgebases/projects/{projectName}/:export"]["post"]
    transform: >
        $["operationId"] = "QuestionAnsweringProjects_Export";

  - from: swagger-document
    where: $["paths"]["/query-knowledgebases/projects/{projectName}/export/jobs/{jobId}"]["get"]
    transform: >
        $["operationId"] = "QuestionAnsweringProjects_GetExportStatus";

  - from: swagger-document
    where: $["paths"]["/query-knowledgebases/projects/{projectName}/:import"]["post"]
    transform: >
        $["operationId"] = "QuestionAnsweringProjects_Import";

  - from: swagger-document
    where: $["paths"]["/query-knowledgebases/projects/{projectName}/import/jobs/{jobId}"]["get"]
    transform: >
        $["operationId"] = "QuestionAnsweringProjects_GetImportStatus";

  - from: swagger-document
    where: $["paths"]["/query-knowledgebases/projects/{projectName}/deployments/{deploymentName}"]["put"]
    transform: >
        $["operationId"] = "QuestionAnsweringProjects_DeployProject";

  - from: swagger-document
    where: $["paths"]["/query-knowledgebases/projects/{projectName}/deployments/{deploymentName}/jobs/{jobId}"]["get"]
    transform: >
        $["operationId"] = "QuestionAnsweringProjects_GetDeployStatus";

  - from: swagger-document
    where: $["paths"]["/query-knowledgebases/projects/{projectName}/deployments"]["get"]
    transform: >
        $["operationId"] = "QuestionAnsweringProjects_ListDeployments";

  - from: swagger-document
    where: $["paths"]["/query-knowledgebases/projects/{projectName}/synonyms"]["get"]
    transform: >
        $["operationId"] = "QuestionAnsweringProjects_GetSynonyms";

  - from: swagger-document
    where: $["paths"]["/query-knowledgebases/projects/{projectName}/synonyms"]["put"]
    transform: >
        $["operationId"] = "QuestionAnsweringProjects_UpdateSynonyms";

  - from: swagger-document
    where: $["paths"]["/query-knowledgebases/projects/{projectName}/sources"]["get"]
    transform: >
        $["operationId"] = "QuestionAnsweringProjects_GetSources";

  - from: swagger-document
    where: $["paths"]["/query-knowledgebases/projects/{projectName}/sources"]["patch"]
    transform: >
        $["operationId"] = "QuestionAnsweringProjects_UpdateSources";

  - from: swagger-document
    where: $["paths"]["/query-knowledgebases/projects/{projectName}/sources/jobs/{jobId}"]["get"]
    transform: >
        $["operationId"] = "QuestionAnsweringProjects_GetUpdateSourcesStatus";

  - from: swagger-document
    where: $["paths"]["/query-knowledgebases/projects/{projectName}/qnas"]["get"]
    transform: >
        $["operationId"] = "QuestionAnsweringProjects_GetQnas";

  - from: swagger-document
    where: $["paths"]["/query-knowledgebases/projects/{projectName}/qnas"]["patch"]
    transform: >
        $["operationId"] = "QuestionAnsweringProjects_UpdateQnas";

  - from: swagger-document
    where: $["paths"]["/query-knowledgebases/projects/{projectName}/qnas/jobs/{jobId}"]["get"]
    transform: >
        $["operationId"] = "QuestionAnsweringProjects_GetUpdateQnasStatus";

  - from: swagger-document
    where: $["paths"]["/query-knowledgebases/projects/{projectName}/feedback"]["post"]
    transform: >
        $["operationId"] = "QuestionAnsweringProjects_AddFeedback";

  - from: swagger-document
    where: $["paths"]["/:query-knowledgebases"]["post"]
    transform: >
        $["operationId"] = "QuestionAnswering_GetAnswers";

  - from: swagger-document
    where: $["paths"]["/:query-text"]["post"]
    transform: >
        $["operationId"] = "QuestionAnswering_GetAnswersFromText";

```
### C# customizations

``` yaml
directive:
- from: swagger-document
  where: $.parameters.Endpoint
  transform: $["format"] = "url"
```
