// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System.ComponentModel;
using Azure.Provisioning.Primitives;

namespace Azure.Provisioning.CosmosDB;

// CUSTOMIZATION: Restore a supporting type for the preview-only data transfer API exposed by the
// previous GA package but omitted from the selected stable TypeSpec version.
/// <summary>
/// A base CosmosDB data source/sink             Please note
/// Azure.ResourceManager.CosmosDB.Models.BaseCosmosDataTransferDataSourceSink
/// is the base class. According to the scenario, a derived class of the base
/// class might need to be assigned here, or this property needs to be casted
/// to one of the possible derived classes.             The available derived
/// classes include
/// Azure.ResourceManager.CosmosDB.Models.CosmosCassandraDataTransferDataSourceSink,
/// Azure.ResourceManager.CosmosDB.Models.CosmosMongoDataTransferDataSourceSink
/// and
/// Azure.ResourceManager.CosmosDB.Models.CosmosSqlDataTransferDataSourceSink.
/// </summary>
[EditorBrowsable(EditorBrowsableState.Never)]
public partial class BaseCosmosDataTransferDataSourceSink : DataTransferDataSourceSink
{
    private BicepValue<string>? _remoteAccountName;

    /// <summary>
    /// Gets or sets the remote account name.
    /// </summary>
    public BicepValue<string> RemoteAccountName
    {
        get { Initialize(); return _remoteAccountName!; }
        set { Initialize(); _remoteAccountName!.Assign(value); }
    }

    /// <summary>
    /// Creates a new BaseCosmosDataTransferDataSourceSink.
    /// </summary>
    public BaseCosmosDataTransferDataSourceSink() : base()
    {
    }

    /// <summary>
    /// Define all the provisionable properties of
    /// BaseCosmosDataTransferDataSourceSink.
    /// </summary>
    protected override void DefineProvisionableProperties()
    {
        base.DefineProvisionableProperties();
        DefineProperty<string>("component", ["component"], defaultValue: "BaseCosmosDataTransferDataSourceSink");
        _remoteAccountName = DefineProperty<string>("RemoteAccountName", ["remoteAccountName"]);
    }
}
