# Azure SDK Code Generation for Data Plane

Run `dotnet build /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/552eaca3fb1940d5ec303746017d1764861031e6/specification/devcenter/data-plane/Microsoft.DevCenter/stable/2023-04-01/devcenter.json
  - https://github.com/Azure/azure-rest-api-specs/blob/552eaca3fb1940d5ec303746017d1764861031e6/specification/devcenter/data-plane/Microsoft.DevCenter/stable/2023-04-01/devbox.json
  - https://github.com/Azure/azure-rest-api-specs/blob/552eaca3fb1940d5ec303746017d1764861031e6/specification/devcenter/data-plane/Microsoft.DevCenter/stable/2023-04-01/environments.json

namespace: Azure.Developer.DevCenter
security: AADToken
security-scopes: https://devcenter.azure.com/.default
data-plane: true
keep-non-overloadable-protocol-signature: true

directive:

  # Move project name to method level parameters
  - from: swagger-document
    where: $.parameters["ProjectNameParameter"]
    transform: >-
      $["x-ms-parameter-location"] = "method"

  # Ensure we use Uri rather than string in .NET
  - from: swagger-document
    where: "$.parameters.EndpointParameter"
    transform: >-
      $["format"] = "url";

  # @autorest/csharp hasn't yet shipped a version which understands operation-location. Until then, pull the options.
  # TODO: remove these directives once fix makes it to a version of @autorest/csharp
  - from: swagger-document
    where-operation: DevBoxes_DeleteDevBox
    transform: >-
      delete $["x-ms-long-running-operation-options"];

  - from: swagger-document
    where-operation: DevBoxes_RestartDevBox
    transform: >-
      delete $["x-ms-long-running-operation-options"];

  - from: swagger-document
    where-operation: DevBoxes_StartDevBox
    transform: >-
      delete $["x-ms-long-running-operation-options"];

  - from: swagger-document
    where-operation: DevBoxes_StopDevBox
    transform: >-
      delete $["x-ms-long-running-operation-options"];

  # Override operation names to match SDK naming preferences
  - from: swagger-document
    where: $..[?(@.operationId !== undefined)]
    transform: >-
      const mappingTable = {
        "DevBoxes_DelayActions": "DevBoxes_DelayAllActions",
        "DevBoxes_GetDevBoxByUser": "DevBoxes_GetDevBox",
        "DevBoxes_ListDevBoxesByUser": "DevBoxes_ListDevBoxes",
        "DevBoxes_GetScheduleByPool": "DevBoxes_GetSchedule",
        "DevCenter_ListAllDevBoxes": "DevBoxes_ListAllDevBoxes",
        "DevCenter_ListAllDevBoxesByUser": "DevBoxes_ListAllDevBoxesByUser",
        "Environments_CreateOrReplaceEnvironment": "DeploymentEnvironments_CreateOrUpdateEnvironment",
        "Environments_DeleteEnvironment": "DeploymentEnvironments_DeleteEnvironment",
        "Environments_GetCatalog": "DeploymentEnvironments_GetCatalog",
        "Environments_GetEnvironmentByUser": "DeploymentEnvironments_GetEnvironment",
        "Environments_GetEnvironmentDefinition": "DeploymentEnvironments_GetEnvironmentDefinition",
        "Environments_ListCatalogsByProject": "DeploymentEnvironments_ListCatalogs",
        "Environments_ListEnvironmentDefinitionsByCatalog": "DeploymentEnvironments_ListEnvironmentDefinitionsByCatalog",
        "Environments_ListEnvironmentDefinitionsByProject": "DeploymentEnvironments_ListEnvironmentDefinitions",
        "Environments_ListEnvironments": "DeploymentEnvironments_ListAllEnvironments",
        "Environments_ListEnvironmentsByUser": "DeploymentEnvironments_ListEnvironments",
        "Environments_ListEnvironmentTypes": "DeploymentEnvironments_ListEnvironmentTypes",
        "DevBoxes_ListSchedulesByPool": "DevBoxes_ListSchedules",
      };

      $.operationId = (mappingTable[$.operationId] ?? $.operationId);

  - from: swagger-document
    where: $..[?(@.operationId == "DevBoxes_ListSchedules" || @.operationId == "DevBoxes_ListPools")]
    transform: >-
      topParam = $.parameters[1];
      $.parameters[1] = $.parameters[2];
      $.parameters[2] = topParam;
```
