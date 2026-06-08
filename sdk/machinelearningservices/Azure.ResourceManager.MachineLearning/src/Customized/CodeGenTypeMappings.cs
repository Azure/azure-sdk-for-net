// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable SA1402 // Backward-compat CodeGenType stubs are grouped to avoid dozens of one-line files.

using Azure.ResourceManager.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.MachineLearning
{
    // Customized: preserve legacy public ARM resource type names during TypeSpec migration.
    [CodeGenType("CodeContainerCollection")]
    public partial class MachineLearningCodeContainerCollection { }

    [CodeGenType("CodeContainerResource")]
    public partial class MachineLearningCodeContainerResource { }

    [CodeGenType("CodeVersionResource")]
    public partial class MachineLearningCodeVersionResource { }

    [CodeGenType("ComponentContainerCollection")]
    public partial class MachineLearningComponentContainerCollection { }

    [CodeGenType("ComponentContainerResource")]
    public partial class MachineLearningComponentContainerResource { }

    [CodeGenType("ComponentVersionResource")]
    public partial class MachineLearningComponentVersionResource { }

    [CodeGenType("ComputeResourceCollection")]
    public partial class MachineLearningComputeCollection { }

    [CodeGenType("ComputeResourceData")]
    public partial class MachineLearningComputeData : TrackedResourceData { }

    [CodeGenType("DataContainerCollection")]
    public partial class MachineLearningDataContainerCollection { }

    [CodeGenType("DataVersionBaseData")]
    public partial class MachineLearningDataVersionData { }

    [CodeGenType("JobBaseData")]
    public partial class MachineLearningJobData { }

    [CodeGenType("DataVersionResource")]
    public partial class MachineLearningDataVersionResource { }

    [CodeGenType("EnvironmentContainerCollection")]
    public partial class MachineLearningEnvironmentContainerCollection { }

    [CodeGenType("EnvironmentVersionResource")]
    public partial class MachineLearningEnvironmentVersionResource { }

    [CodeGenType("ModelContainerCollection")]
    public partial class MachineLearningModelContainerCollection { }

    [CodeGenType("ModelContainerResource")]
    public partial class MachineLearningModelContainerResource { }

    [CodeGenType("ModelVersionResource")]
    public partial class MachineLearningModelVersionResource { }

    [CodeGenType("OutboundRuleCollection")]
    public partial class MachineLearningOutboundRuleBasicCollection { }

    [CodeGenType("OutboundRuleResource")]
    public partial class MachineLearningOutboundRuleBasicResource { }

    [CodeGenType("MachineLearningOutboundRuleBasicResourceData")]
    public partial class MachineLearningOutboundRuleBasicData { }

    [CodeGenType("RegistryCodeContainerCollection")]
    public partial class MachineLearningRegistryCodeContainerCollection { }

    [CodeGenType("RegistryCodeContainerResource")]
    public partial class MachineLearningRegistryCodeContainerResource { }

    [CodeGenType("RegistryCodeVersionCollection")]
    public partial class MachineLearningRegistryCodeVersionCollection { }

    [CodeGenType("RegistryCodeVersionResource")]
    public partial class MachineLearningRegistryCodeVersionResource { }

    [CodeGenType("RegistryComponentContainerCollection")]
    public partial class MachineLearninRegistryComponentContainerCollection { }

    [CodeGenType("RegistryComponentContainerResource")]
    public partial class MachineLearninRegistryComponentContainerResource { }

    [CodeGenType("RegistryComponentVersionCollection")]
    public partial class MachineLearninRegistryComponentVersionCollection { }

    [CodeGenType("RegistryComponentVersionResource")]
    public partial class MachineLearninRegistryComponentVersionResource { }

    [CodeGenType("RegistryDataContainerCollection")]
    public partial class MachineLearningRegistryDataContainerCollection { }

    [CodeGenType("RegistryDataContainerResource")]
    public partial class MachineLearningRegistryDataContainerResource { }

    [CodeGenType("RegistryDataVersionCollection")]
    public partial class MachineLearningRegistryDataVersionCollection { }

    [CodeGenType("RegistryDataVersionResource")]
    public partial class MachineLearningRegistryDataVersionResource { }

    [CodeGenType("RegistryEnvironmentContainerCollection")]
    public partial class MachineLearningRegistryEnvironmentContainerCollection { }

    [CodeGenType("RegistryEnvironmentContainerResource")]
    public partial class MachineLearningRegistryEnvironmentContainerResource { }

    [CodeGenType("RegistryEnvironmentVersionCollection")]
    public partial class MachineLearningRegistryEnvironmentVersionCollection { }

    [CodeGenType("RegistryEnvironmentVersionResource")]
    public partial class MachineLearningRegistryEnvironmentVersionResource { }

    [CodeGenType("RegistryModelContainerCollection")]
    public partial class MachineLearningRegistryModelContainerCollection { }

    [CodeGenType("RegistryModelContainerResource")]
    public partial class MachineLearningRegistryModelContainerResource { }

    [CodeGenType("RegistryModelVersionCollection")]
    public partial class MachineLearningRegistryModelVersionCollection { }

    [CodeGenType("RegistryModelVersionResource")]
    public partial class MachineLearningRegistryModelVersionResource { }

    [CodeGenType("WorkspaceConnectionPropertiesV2BasicResourceCollection")]
    public partial class MachineLearningWorkspaceConnectionCollection { }
}

#pragma warning restore SA1402
