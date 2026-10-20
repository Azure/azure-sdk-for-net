// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System.ComponentModel;
using Azure.Provisioning.Primitives;

namespace Azure.Provisioning.CosmosDB;

// CUSTOMIZATION: Restore a supporting type for the preview-only Cassandra view API exposed by the
// previous GA package but omitted from the selected stable TypeSpec version.
/// <summary>
/// Cosmos DB Cassandra view resource object.
/// </summary>
[EditorBrowsable(EditorBrowsableState.Never)]
public partial class CassandraViewResource : ProvisionableConstruct
{
    private BicepValue<string>? _id;
    private BicepValue<string>? _viewDefinition;

    /// <summary>
    /// Name of the Cosmos DB Cassandra view.
    /// </summary>
    public BicepValue<string> Id
    {
        get { Initialize(); return _id!; }
        set { Initialize(); _id!.Assign(value); }
    }

    /// <summary>
    /// View Definition of the Cosmos DB Cassandra view.
    /// </summary>
    public BicepValue<string> ViewDefinition
    {
        get { Initialize(); return _viewDefinition!; }
        set { Initialize(); _viewDefinition!.Assign(value); }
    }

    /// <summary>
    /// Creates a new CassandraViewResource.
    /// </summary>
    public CassandraViewResource()
    {
    }

    /// <summary>
    /// Define all the provisionable properties of CassandraViewResource.
    /// </summary>
    protected override void DefineProvisionableProperties()
    {
        base.DefineProvisionableProperties();
        _id = DefineProperty<string>("Id", ["id"]);
        _viewDefinition = DefineProperty<string>("ViewDefinition", ["viewDefinition"]);
    }
}
