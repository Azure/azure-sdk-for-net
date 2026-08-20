// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable
#pragma warning disable CS1591

using System.ComponentModel;
using Azure.Provisioning.Primitives;

namespace Azure.Provisioning.CosmosDB;

[EditorBrowsable(EditorBrowsableState.Never)]
public partial class CosmosDBErrorResult : ProvisionableConstruct
{
    private BicepValue<string>? _code;
    private BicepValue<string>? _message;

    public BicepValue<string> Code
    {
        get { Initialize(); return _code!; }
    }

    public BicepValue<string> Message
    {
        get { Initialize(); return _message!; }
    }

    public CosmosDBErrorResult()
    {
    }

    protected override void DefineProvisionableProperties()
    {
        base.DefineProvisionableProperties();
        _code = DefineProperty<string>("Code", ["code"], isOutput: true);
        _message = DefineProperty<string>("Message", ["message"], isOutput: true);
    }
}
