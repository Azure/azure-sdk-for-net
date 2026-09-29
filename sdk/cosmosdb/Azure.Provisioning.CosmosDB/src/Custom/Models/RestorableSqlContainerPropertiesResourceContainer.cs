// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using Azure;
using Azure.Provisioning;
using Azure.Provisioning.Primitives;

namespace Azure.Provisioning.CosmosDB;

// CUSTOMIZATION: Restore this response-only type from previous releases because provisioning
// generation prunes models that are reachable only from restorable list operations.
/// <summary> Cosmos DB SQL container resource object. </summary>
[EditorBrowsable(EditorBrowsableState.Never)]
[Obsolete("This type is retained only for backward compatibility and is not used by provisioning resources.")]
public partial class RestorableSqlContainerPropertiesResourceContainer : CosmosDBSqlContainerResourceInfo
{
    private BicepValue<string> _self;
    private BicepValue<string> _rid;
    private BicepValue<float> _timestamp;
    private BicepValue<ETag> _eTag;

    /// <summary> A system generated property that specifies the addressable path of the container resource. </summary>
    public BicepValue<string> Self
    {
        get
        {
            Initialize();
            return _self;
        }
    }

    /// <summary> A system generated property. A unique identifier. </summary>
    public BicepValue<string> Rid
    {
        get
        {
            Initialize();
            return _rid;
        }
    }

    /// <summary> A system generated property that denotes the last updated timestamp of the resource. </summary>
    public BicepValue<float> Timestamp
    {
        get
        {
            Initialize();
            return _timestamp;
        }
    }

    /// <summary> A system generated property representing the resource etag required for optimistic concurrency control. </summary>
    public BicepValue<ETag> ETag
    {
        get
        {
            Initialize();
            return _eTag;
        }
    }

    /// <summary> Creates a new RestorableSqlContainerPropertiesResourceContainer. </summary>
    public RestorableSqlContainerPropertiesResourceContainer()
    {
    }

    /// <inheritdoc />
    protected override void DefineProvisionableProperties()
    {
        base.DefineProvisionableProperties();
        _self = DefineProperty<string>(nameof(Self), new string[] { "_self" }, isOutput: true);
        _rid = DefineProperty<string>(nameof(Rid), new string[] { "_rid" }, isOutput: true);
        _timestamp = DefineProperty<float>(nameof(Timestamp), new string[] { "_ts" }, isOutput: true);
        _eTag = DefineProperty<ETag>(nameof(ETag), new string[] { "_etag" }, isOutput: true);
    }
}
