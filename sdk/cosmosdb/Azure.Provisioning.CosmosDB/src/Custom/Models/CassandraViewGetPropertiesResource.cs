// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System.ComponentModel;
using Azure;
using Azure.Provisioning.Primitives;

namespace Azure.Provisioning.CosmosDB;

// CUSTOMIZATION: Restore a supporting type for the preview-only Cassandra view API exposed by the
// previous GA package but omitted from the selected stable TypeSpec version.
/// <summary>
/// The CassandraViewGetPropertiesResource.
/// </summary>
[EditorBrowsable(EditorBrowsableState.Never)]
public partial class CassandraViewGetPropertiesResource : CassandraViewResource
{
    private BicepValue<string>? _rid;
    private BicepValue<float>? _timestamp;
    private BicepValue<ETag>? _eTag;

    /// <summary>
    /// A system generated property. A unique identifier.
    /// </summary>
    public BicepValue<string> Rid
    {
        get { Initialize(); return _rid!; }
    }

    /// <summary>
    /// A system generated property that denotes the last updated timestamp of
    /// the resource.
    /// </summary>
    public BicepValue<float> Timestamp
    {
        get { Initialize(); return _timestamp!; }
    }

    /// <summary>
    /// A system generated property representing the resource etag required for
    /// optimistic concurrency control.
    /// </summary>
    public BicepValue<ETag> ETag
    {
        get { Initialize(); return _eTag!; }
    }

    /// <summary>
    /// Creates a new CassandraViewGetPropertiesResource.
    /// </summary>
    public CassandraViewGetPropertiesResource() : base()
    {
    }

    /// <summary>
    /// Define all the provisionable properties of
    /// CassandraViewGetPropertiesResource.
    /// </summary>
    protected override void DefineProvisionableProperties()
    {
        base.DefineProvisionableProperties();
        _rid = DefineProperty<string>("Rid", ["_rid"], isOutput: true);
        _timestamp = DefineProperty<float>("Timestamp", ["_ts"], isOutput: true);
        _eTag = DefineProperty<ETag>("ETag", ["_etag"], isOutput: true);
    }
}
