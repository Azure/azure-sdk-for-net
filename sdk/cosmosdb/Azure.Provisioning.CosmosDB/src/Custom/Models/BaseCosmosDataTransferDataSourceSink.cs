// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable
#pragma warning disable CS1591

using System.ComponentModel;
using Azure.Provisioning.Primitives;

namespace Azure.Provisioning.CosmosDB;

[EditorBrowsable(EditorBrowsableState.Never)]
public partial class BaseCosmosDataTransferDataSourceSink : DataTransferDataSourceSink
{
    private BicepValue<string>? _remoteAccountName;

    public BicepValue<string> RemoteAccountName
    {
        get { Initialize(); return _remoteAccountName!; }
        set { Initialize(); _remoteAccountName!.Assign(value); }
    }

    public BaseCosmosDataTransferDataSourceSink() : base()
    {
    }

    protected override void DefineProvisionableProperties()
    {
        base.DefineProvisionableProperties();
        DefineProperty<string>("component", ["component"], defaultValue: "BaseCosmosDataTransferDataSourceSink");
        _remoteAccountName = DefineProperty<string>("RemoteAccountName", ["remoteAccountName"]);
    }
}
