// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable enable

using Azure.Provisioning.Primitives;
using System;

namespace Azure.Provisioning.CosmosDB;

/// <summary>
/// A CosmosDB Mongo API data source/sink.
/// </summary>
public partial class CosmosMongoDataTransferDataSourceSink : BaseCosmosDataTransferDataSourceSink
{
    /// <summary>
    /// Gets or sets the database name.
    /// </summary>
    public BicepValue<string> DatabaseName 
    {
        get { Initialize(); return _databaseName!; }
        set { Initialize(); _databaseName!.Assign(value); }
    }
    private BicepValue<string>? _databaseName;

    /// <summary>
    /// Gets or sets the collection name.
    /// </summary>
    public BicepValue<string> CollectionName 
    {
        get { Initialize(); return _collectionName!; }
        set { Initialize(); _collectionName!.Assign(value); }
    }
    private BicepValue<string>? _collectionName;

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
