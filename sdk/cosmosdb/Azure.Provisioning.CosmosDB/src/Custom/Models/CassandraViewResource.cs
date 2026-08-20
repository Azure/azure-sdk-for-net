// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable
#pragma warning disable CS1591

using System.ComponentModel;
using Azure.Provisioning.Primitives;

namespace Azure.Provisioning.CosmosDB;

[EditorBrowsable(EditorBrowsableState.Never)]
public partial class CassandraViewResource : ProvisionableConstruct
{
    private BicepValue<string>? _id;
    private BicepValue<string>? _viewDefinition;

    public BicepValue<string> Id
    {
        get { Initialize(); return _id!; }
        set { Initialize(); _id!.Assign(value); }
    }

    public BicepValue<string> ViewDefinition
    {
        get { Initialize(); return _viewDefinition!; }
        set { Initialize(); _viewDefinition!.Assign(value); }
    }

    public CassandraViewResource()
    {
    }

    protected override void DefineProvisionableProperties()
    {
        base.DefineProvisionableProperties();
        _id = DefineProperty<string>("Id", ["id"]);
        _viewDefinition = DefineProperty<string>("ViewDefinition", ["viewDefinition"]);
    }
}
