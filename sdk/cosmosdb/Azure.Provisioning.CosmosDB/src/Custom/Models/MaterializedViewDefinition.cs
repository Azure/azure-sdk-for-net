// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using Azure.Provisioning;
using Azure.Provisioning.Primitives;

namespace Azure.Provisioning.CosmosDB;

// CUSTOMIZATION: Restore this preview-only type exposed by the previous GA package because the
// selected stable TypeSpec version does not include it.
/// <summary> Materialized View definition for the container. </summary>
[EditorBrowsable(EditorBrowsableState.Never)]
public partial class MaterializedViewDefinition : ProvisionableConstruct
{
    private BicepValue<string> _sourceCollectionRid;
    private BicepValue<string> _sourceCollectionId;
    private BicepValue<string> _definition;

    /// <summary> An unique identifier for the source collection. This is a system generated property. </summary>
    public BicepValue<string> SourceCollectionRid
    {
        get
        {
            Initialize();
            return _sourceCollectionRid;
        }
    }

    /// <summary> The name of the source container on which the Materialized View will be created. </summary>
    public BicepValue<string> SourceCollectionId
    {
        get
        {
            Initialize();
            return _sourceCollectionId;
        }
        set
        {
            Initialize();
            _sourceCollectionId.Assign(value);
        }
    }

    /// <summary>
    /// The definition should be an SQL query which would be used to fetch data from the source
    /// container to populate into the Materialized View container.
    /// </summary>
    public BicepValue<string> Definition
    {
        get
        {
            Initialize();
            return _definition;
        }
        set
        {
            Initialize();
            _definition.Assign(value);
        }
    }

    /// <summary> Creates a new MaterializedViewDefinition. </summary>
    public MaterializedViewDefinition()
    {
    }

    /// <inheritdoc />
    protected override void DefineProvisionableProperties()
    {
        base.DefineProvisionableProperties();
        _sourceCollectionRid = DefineProperty<string>(
            nameof(SourceCollectionRid),
            new string[] { "sourceCollectionRid" },
            isOutput: true);
        _sourceCollectionId = DefineProperty<string>(
            nameof(SourceCollectionId),
            new string[] { "sourceCollectionId" });
        _definition = DefineProperty<string>(
            nameof(Definition),
            new string[] { "definition" });
    }
}
