// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System.ComponentModel;
using Azure.Provisioning.Primitives;

namespace Azure.Provisioning.CosmosDB;

// CUSTOMIZATION: Restore a supporting type for the preview-only data transfer API exposed by the
// previous GA package but omitted from the selected stable TypeSpec version.
/// <summary>
/// Base class for all DataTransfer source/sink             Please note
/// Azure.ResourceManager.CosmosDB.Models.DataTransferDataSourceSink is the
/// base class. According to the scenario, a derived class of the base class
/// might need to be assigned here, or this property needs to be casted to one
/// of the possible derived classes.             The available derived classes
/// include
/// Azure.ResourceManager.CosmosDB.Models.AzureBlobDataTransferDataSourceSink,
/// Azure.ResourceManager.CosmosDB.Models.BaseCosmosDataTransferDataSourceSink,
/// Azure.ResourceManager.CosmosDB.Models.CosmosCassandraDataTransferDataSourceSink,
/// Azure.ResourceManager.CosmosDB.Models.CosmosMongoDataTransferDataSourceSink,
/// Azure.ResourceManager.CosmosDB.Models.CosmosMongoVCoreDataTransferDataSourceSink
/// and
/// Azure.ResourceManager.CosmosDB.Models.CosmosSqlDataTransferDataSourceSink.
/// </summary>
[EditorBrowsable(EditorBrowsableState.Never)]
public partial class DataTransferDataSourceSink : ProvisionableConstruct
{
    /// <summary>
    /// Creates a new DataTransferDataSourceSink.
    /// </summary>
    public DataTransferDataSourceSink()
    {
    }

    /// <summary>
    /// Define all the provisionable properties of DataTransferDataSourceSink.
    /// </summary>
    protected override void DefineProvisionableProperties()
    {
        base.DefineProvisionableProperties();
    }
}
