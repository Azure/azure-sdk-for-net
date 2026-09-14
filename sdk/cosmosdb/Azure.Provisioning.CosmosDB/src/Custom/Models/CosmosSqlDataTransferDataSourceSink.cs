// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System.ComponentModel;
using Azure.Provisioning.Primitives;

namespace Azure.Provisioning.CosmosDB;

// CUSTOMIZATION: Restore a supporting type for the preview-only data transfer API exposed by the
// previous GA package but omitted from the selected stable TypeSpec version.
/// <summary>
/// A CosmosDB No Sql API data source/sink.
/// </summary>
[EditorBrowsable(EditorBrowsableState.Never)]
public partial class CosmosSqlDataTransferDataSourceSink : BaseCosmosDataTransferDataSourceSink
{
    private BicepValue<string>? _databaseName;
    private BicepValue<string>? _containerName;

    /// <summary>
    /// Gets or sets the database name.
    /// </summary>
    public BicepValue<string> DatabaseName
    {
        get { Initialize(); return _databaseName!; }
        set { Initialize(); _databaseName!.Assign(value); }
    }

    /// <summary>
    /// Gets or sets the container name.
    /// </summary>
    public BicepValue<string> ContainerName
    {
        get { Initialize(); return _containerName!; }
        set { Initialize(); _containerName!.Assign(value); }
    }

    /// <summary>
    /// Creates a new CosmosSqlDataTransferDataSourceSink.
    /// </summary>
    public CosmosSqlDataTransferDataSourceSink() : base()
    {
    }

    /// <summary>
    /// Define all the provisionable properties of
    /// CosmosSqlDataTransferDataSourceSink.
    /// </summary>
    protected override void DefineProvisionableProperties()
    {
        base.DefineProvisionableProperties();
        DefineProperty<string>("component", ["component"], defaultValue: "CosmosDBSql");
        _databaseName = DefineProperty<string>("DatabaseName", ["databaseName"]);
        _containerName = DefineProperty<string>("ContainerName", ["containerName"]);
    }
}
