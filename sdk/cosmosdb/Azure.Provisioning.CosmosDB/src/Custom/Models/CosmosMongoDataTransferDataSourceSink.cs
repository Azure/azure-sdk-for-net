// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable
#pragma warning disable CS1591

using System.ComponentModel;
using Azure.Provisioning.Primitives;

namespace Azure.Provisioning.CosmosDB;

[EditorBrowsable(EditorBrowsableState.Never)]
public partial class CosmosMongoDataTransferDataSourceSink : BaseCosmosDataTransferDataSourceSink
{
    private BicepValue<string>? _databaseName;
    private BicepValue<string>? _collectionName;

    public BicepValue<string> DatabaseName
    {
        get { Initialize(); return _databaseName!; }
        set { Initialize(); _databaseName!.Assign(value); }
    }

    public BicepValue<string> CollectionName
    {
        get { Initialize(); return _collectionName!; }
        set { Initialize(); _collectionName!.Assign(value); }
    }

    public CosmosMongoDataTransferDataSourceSink() : base()
    {
    }

    protected override void DefineProvisionableProperties()
    {
        base.DefineProvisionableProperties();
        DefineProperty<string>("component", ["component"], defaultValue: "CosmosDBMongo");
        _databaseName = DefineProperty<string>("DatabaseName", ["databaseName"]);
        _collectionName = DefineProperty<string>("CollectionName", ["collectionName"]);
    }
}
