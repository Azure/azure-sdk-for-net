// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ClientModel.Primitives;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.OracleDatabase.Models;

namespace Azure.ResourceManager.OracleDatabase
{
    // These 2 types are missing ModelReaderWriterBuildable attribute when migrating to new codegen, will be fixed in future codegen release.
    [ModelReaderWriterBuildable(typeof(ArmPlan))]
    [ModelReaderWriterBuildable(typeof(OracleDBVersionCollectionGetAllOptions))]
    public partial class AzureResourceManagerOracleDatabaseContext : ModelReaderWriterContext
    {
    }
}
