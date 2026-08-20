// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System.ComponentModel;
using Azure.Provisioning.Primitives;

namespace Azure.Provisioning.CosmosDB;

/// <summary>
/// A CosmosDB Mongo API data source/sink.
/// </summary>
[EditorBrowsable(EditorBrowsableState.Never)]
public partial class CosmosMongoDataTransferDataSourceSink : BaseCosmosDataTransferDataSourceSink
{
    private BicepValue<string>? _databaseName;
    private BicepValue<string>? _collectionName;

    /// <summary>
    /// Gets or sets the database name.
    /// </summary>
    public BicepValue<string> DatabaseName
    {
        get { Initialize(); return _databaseName!; }
        set { Initialize(); _databaseName!.Assign(value); }
    }

    /// <summary>
    /// Gets or sets the collection name.
    /// </summary>
    public BicepValue<string> CollectionName
    {
        get { Initialize(); return _collectionName!; }
        set { Initialize(); _collectionName!.Assign(value); }
    }

    /// <summary>
    /// Creates a new CosmosMongoDataTransferDataSourceSink.
    /// </summary>
    public CosmosMongoDataTransferDataSourceSink() : base()
    {
    }

    /// <summary>
    /// Define all the provisionable properties of
    /// CosmosMongoDataTransferDataSourceSink.
    /// </summary>
    protected override void DefineProvisionableProperties()
    {
        base.DefineProvisionableProperties();
        DefineProperty<string>("component", ["component"], defaultValue: "CosmosDBMongo");
        _databaseName = DefineProperty<string>("DatabaseName", ["databaseName"]);
        _collectionName = DefineProperty<string>("CollectionName", ["collectionName"]);
    }
}
