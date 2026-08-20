// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable
#pragma warning disable CS1591

using System.ComponentModel;
using Azure.Provisioning.Primitives;

namespace Azure.Provisioning.CosmosDB;

[EditorBrowsable(EditorBrowsableState.Never)]
public partial class CosmosSqlDataTransferDataSourceSink : BaseCosmosDataTransferDataSourceSink
{
    private BicepValue<string>? _databaseName;
    private BicepValue<string>? _containerName;

    public BicepValue<string> DatabaseName
    {
        get { Initialize(); return _databaseName!; }
        set { Initialize(); _databaseName!.Assign(value); }
    }

    public BicepValue<string> ContainerName
    {
        get { Initialize(); return _containerName!; }
        set { Initialize(); _containerName!.Assign(value); }
    }

    public CosmosSqlDataTransferDataSourceSink() : base()
    {
    }

    protected override void DefineProvisionableProperties()
    {
        base.DefineProvisionableProperties();
        DefineProperty<string>("component", ["component"], defaultValue: "CosmosDBSql");
        _databaseName = DefineProperty<string>("DatabaseName", ["databaseName"]);
        _containerName = DefineProperty<string>("ContainerName", ["containerName"]);
    }
}
