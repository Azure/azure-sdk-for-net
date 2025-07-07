# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: SiteConfiguration
namespace: Azure.ResourceManager.siteconfiguration
# default tag is a preview version
require: https://github.com/Azure/azure-rest-api-specs/blob/292b2f01ed2c626f777fdb31ec0cd153db11c967/specification/edge/resource-manager/Microsoft.Edge/configurations/readme.md
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
  output-folder: $(this-folder)/../tests/Generated
  clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false
use-model-reader-writer: true
tag: package-2025-06-01

rename-mapping:
  BulkPublishSolutionParameter: BulkPublishSolutionContent
  InstallSolutionParameter: InstallSolutionContent
  BulkDeploySolutionParameter: BulkDeploySolutionContent
  RemoveRevisionParameter: RemoveRevisionContent
  RemoveVersionResponse: RemoveVersionResult
  SolutionDependencyParameter: SolutionDependencyContent
  SolutionTemplateParameter: SolutionTemplateContent
  TaskOption: TaskConfig
  UninstallSolutionParameter: UninstallSolutionContent
  UpdateExternalValidationStatusParameter: UpdateExternalValidationStatusContent
  SolutionVersionParameter: SolutionVersionContent
  VersionParameter: VersionContent
  WorkflowExecuteParameter: WorkflowExecuteContent
  WorkflowVersionParameter: WorkflowVersionContent
  WorkflowTemplateReviewParameter: WorkflowTemplateReviewContent
  DeployJobParameter: DeployJobContent
```


