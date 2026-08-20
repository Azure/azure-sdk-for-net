// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable
#pragma warning disable CS1591

using System.ComponentModel;
using Azure.Provisioning.Primitives;

namespace Azure.Provisioning.CosmosDB;

[EditorBrowsable(EditorBrowsableState.Never)]
public partial class CosmosCassandraDataTransferDataSourceSink : BaseCosmosDataTransferDataSourceSink
{
    private BicepValue<string>? _keyspaceName;
    private BicepValue<string>? _tableName;

    public BicepValue<string> KeyspaceName
    {
        get { Initialize(); return _keyspaceName!; }
        set { Initialize(); _keyspaceName!.Assign(value); }
    }

    public BicepValue<string> TableName
    {
        get { Initialize(); return _tableName!; }
        set { Initialize(); _tableName!.Assign(value); }
    }

    public CosmosCassandraDataTransferDataSourceSink() : base()
    {
    }

    protected override void DefineProvisionableProperties()
    {
        base.DefineProvisionableProperties();
        DefineProperty<string>("component", ["component"], defaultValue: "CosmosDBCassandra");
        _keyspaceName = DefineProperty<string>("KeyspaceName", ["keyspaceName"]);
        _tableName = DefineProperty<string>("TableName", ["tableName"]);
    }
}
