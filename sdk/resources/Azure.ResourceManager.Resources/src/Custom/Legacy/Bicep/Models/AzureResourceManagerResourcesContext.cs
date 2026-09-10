// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#pragma warning disable CS0618

using System.ClientModel.Primitives;

namespace Azure.ResourceManager.Resources
{
    [ModelReaderWriterBuildable(typeof(Models.DecompiledFileDefinition))]
    [ModelReaderWriterBuildable(typeof(Models.DecompileOperationContent))]
    [ModelReaderWriterBuildable(typeof(Models.DecompileOperationSuccessResult))]
    public partial class AzureResourceManagerResourcesContext
    {
    }
}
