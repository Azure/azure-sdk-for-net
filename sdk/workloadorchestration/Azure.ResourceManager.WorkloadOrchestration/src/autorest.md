# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: WorkloadOrchestration
namespace: Azure.ResourceManager.WorkloadOrchestration
# default tag is a preview version
require: C:\Users\audapure\Repo\Projects\swagger\azure-rest-api-specs-pr\specification\edge\resource-manager\Microsoft.Edge\configurationmanager\readme.md
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
  output-folder: $(this-folder)/../tests/Generated
  clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false
use-model-reader-writer: true
tag: package-2025-06-01-preview

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

```


