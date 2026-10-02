// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using Azure.Data.SchemaRegistry.Models;

namespace Azure.Data.SchemaRegistry
{
    [ModelReaderWriterBuildable(typeof(SchemaGroups))]
    [ModelReaderWriterBuildable(typeof(SchemaVersions))]
    public partial class AzureDataSchemaRegistryContext
    {
    }
}
