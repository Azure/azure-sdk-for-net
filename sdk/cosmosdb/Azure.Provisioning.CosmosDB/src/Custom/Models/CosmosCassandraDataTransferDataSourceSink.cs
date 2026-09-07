// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System.ComponentModel;
using Azure.Provisioning.Primitives;

namespace Azure.Provisioning.CosmosDB;

// CUSTOMIZATION: Restore a supporting type for the preview-only data transfer API exposed by the
// previous GA package but omitted from the selected stable TypeSpec version.
/// <summary>
/// A CosmosDB Cassandra API data source/sink.
/// </summary>
[EditorBrowsable(EditorBrowsableState.Never)]
public partial class CosmosCassandraDataTransferDataSourceSink : BaseCosmosDataTransferDataSourceSink
{
    private BicepValue<string>? _keyspaceName;
    private BicepValue<string>? _tableName;

    /// <summary>
    /// Gets or sets the keyspace name.
    /// </summary>
    public BicepValue<string> KeyspaceName
    {
        get { Initialize(); return _keyspaceName!; }
        set { Initialize(); _keyspaceName!.Assign(value); }
    }

    /// <summary>
    /// Gets or sets the table name.
    /// </summary>
    public BicepValue<string> TableName
    {
        get { Initialize(); return _tableName!; }
        set { Initialize(); _tableName!.Assign(value); }
    }

    /// <summary>
    /// Creates a new CosmosCassandraDataTransferDataSourceSink.
    /// </summary>
    public CosmosCassandraDataTransferDataSourceSink() : base()
    {
    }

    /// <summary>
    /// Define all the provisionable properties of
    /// CosmosCassandraDataTransferDataSourceSink.
    /// </summary>
    protected override void DefineProvisionableProperties()
    {
        base.DefineProvisionableProperties();
        DefineProperty<string>("component", ["component"], defaultValue: "CosmosDBCassandra");
        _keyspaceName = DefineProperty<string>("KeyspaceName", ["keyspaceName"]);
        _tableName = DefineProperty<string>("TableName", ["tableName"]);
    }
}
