// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using Azure.ResourceManager.ContainerInstance.Models;

namespace Azure.ResourceManager.ContainerInstance
{
    // Registers the restored GA models and resource with the generated serialization context.
    [ModelReaderWriterBuildable(typeof(ContainerGroupSandboxResource))]
    [ModelReaderWriterBuildable(typeof(ContainerGroupSandboxData))]
    [ModelReaderWriterBuildable(typeof(ContainerGroupSandboxProperties))]
    [ModelReaderWriterBuildable(typeof(ContainerSandboxGroupPatch))]
    [ModelReaderWriterBuildable(typeof(ContainerSandboxGroupAccessToken))]
    [ModelReaderWriterBuildable(typeof(SandboxGroupListResult))]
    [ModelReaderWriterBuildable(typeof(SandboxGroupNetworkProfile))]
    public partial class AzureResourceManagerContainerInstanceContext
    {
    }
}
