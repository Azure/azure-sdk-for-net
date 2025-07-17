using Azure.Core;
using Azure.ResourceManager.Resources.DeploymentStacks.Models;
using System.ClientModel.Primitives;

namespace Azure.ResourceManager.Resources.DeploymentStacks;

[ModelReaderWriterBuildable(typeof(ActionOnUnmanage))]
[ModelReaderWriterBuildable(typeof(DenySettings))]
[ModelReaderWriterBuildable(typeof(DeploymentParameter))]
[ModelReaderWriterBuildable(typeof(DeploymentStackData))]
[ModelReaderWriterBuildable(typeof(DeploymentStackResource))]
[ModelReaderWriterBuildable(typeof(DeploymentStackListResult))]
[ModelReaderWriterBuildable(typeof(DeploymentStacksDebugSetting))]
[ModelReaderWriterBuildable(typeof(DeploymentStacksParametersLink))]
[ModelReaderWriterBuildable(typeof(DeploymentStacksTemplateLink))]
[ModelReaderWriterBuildable(typeof(DeploymentStackTemplateDefinition))]
[ModelReaderWriterBuildable(typeof(DeploymentStackValidateProperties))]
[ModelReaderWriterBuildable(typeof(DeploymentStackValidateResult))]
[ModelReaderWriterBuildable(typeof(HttpMessage))]
[ModelReaderWriterBuildable(typeof(KeyVaultParameterReference))]
[ModelReaderWriterBuildable(typeof(ManagedResourceReference))]
[ModelReaderWriterBuildable(typeof(ResourceReference))]
[ModelReaderWriterBuildable(typeof(ResourceReferenceExtended))]
public partial class AzureResourceManagerResourcesDeploymentStacksContext
{
}
