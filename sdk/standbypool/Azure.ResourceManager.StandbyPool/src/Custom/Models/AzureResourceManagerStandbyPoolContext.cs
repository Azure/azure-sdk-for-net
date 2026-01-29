// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ClientModel.Primitives;
using Azure;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.StandbyPool.Models;

namespace Azure.ResourceManager.StandbyPool
{
    /// <summary>
    /// Context class which will be filled in by the System.ClientModel.SourceGeneration.
    /// For more information <see href='https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/System.ClientModel/src/docs/ModelReaderWriterContext.md' />
    /// </summary>
    [ModelReaderWriterBuildable(typeof(WritableSubResource))]
    public partial class AzureResourceManagerStandbyPoolContext
    {
    }
}
