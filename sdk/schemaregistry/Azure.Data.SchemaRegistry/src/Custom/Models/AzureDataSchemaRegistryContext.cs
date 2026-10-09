// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using Azure.Data.SchemaRegistry.Models;

namespace Azure.Data.SchemaRegistry
{
    // TODO: Remove this buildable model once https://github.com/Azure/azure-sdk-for-net/issues/63576 is fixed.
    [ModelReaderWriterBuildable(typeof(SchemaGroups))]
    public partial class AzureDataSchemaRegistryContext
    {
    }
}
