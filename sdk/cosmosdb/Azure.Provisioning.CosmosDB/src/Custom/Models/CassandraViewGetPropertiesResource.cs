// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable
#pragma warning disable CS1591

using System.ComponentModel;
using Azure;
using Azure.Provisioning.Primitives;

namespace Azure.Provisioning.CosmosDB;

[EditorBrowsable(EditorBrowsableState.Never)]
public partial class CassandraViewGetPropertiesResource : CassandraViewResource
{
    private BicepValue<string>? _rid;
    private BicepValue<float>? _timestamp;
    private BicepValue<ETag>? _eTag;

    public BicepValue<string> Rid
    {
        get { Initialize(); return _rid!; }
    }

    public BicepValue<float> Timestamp
    {
        get { Initialize(); return _timestamp!; }
    }

    public BicepValue<ETag> ETag
    {
        get { Initialize(); return _eTag!; }
    }

    public CassandraViewGetPropertiesResource() : base()
    {
    }

    protected override void DefineProvisionableProperties()
    {
        base.DefineProvisionableProperties();
        _rid = DefineProperty<string>("Rid", ["_rid"], isOutput: true);
        _timestamp = DefineProperty<float>("Timestamp", ["_ts"], isOutput: true);
        _eTag = DefineProperty<ETag>("ETag", ["_etag"], isOutput: true);
    }
}
