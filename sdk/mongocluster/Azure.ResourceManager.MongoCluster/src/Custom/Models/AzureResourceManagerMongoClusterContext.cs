// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ClientModel.Primitives;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.MongoCluster
{
    [ModelReaderWriterBuildable(typeof(SubResource))]
    public partial class AzureResourceManagerMongoClusterContext : ModelReaderWriterContext
    {
    }
}
