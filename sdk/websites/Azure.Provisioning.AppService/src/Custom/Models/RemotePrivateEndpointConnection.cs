// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Net;
using Azure.Provisioning;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.AppService;

public partial class RemotePrivateEndpointConnection
{
    // Work around https://github.com/Azure/azure-sdk-for-net/issues/61011 by preserving setters omitted from the response model.

    /// <summary> Kind of resource. </summary>
    [CodeGenMember("Kind")]
    public BicepValue<string> Kind
    {
        get { Initialize(); return _customKind; }
        set { Initialize(); _customKind.Assign(value); }
    }
    private BicepValue<string> _customKind;

    /// <summary> The state of a private link connection. </summary>
    [CodeGenMember("PrivateLinkServiceConnectionState")]
    public PrivateLinkConnectionState PrivateLinkServiceConnectionState
    {
        get { Initialize(); return _customPrivateLinkServiceConnectionState; }
        set { Initialize(); AssignOrReplace(ref _customPrivateLinkServiceConnectionState, value); }
    }
    private PrivateLinkConnectionState _customPrivateLinkServiceConnectionState;

    /// <summary> Private IP addresses mapped to the remote private endpoint. </summary>
    [CodeGenMember("IPAddresses")]
    public BicepList<IPAddress> IPAddresses
    {
        get { Initialize(); return _customIPAddresses; }
        set { Initialize(); _customIPAddresses.Assign(value); }
    }
    private BicepList<IPAddress> _customIPAddresses;

    partial void DefineAdditionalProperties()
    {
        _customKind = DefineProperty<string>(nameof(Kind), ["kind"]);
        _customPrivateLinkServiceConnectionState = DefineModelProperty<PrivateLinkConnectionState>(nameof(PrivateLinkServiceConnectionState), ["properties", "privateLinkServiceConnectionState"]);
        _customIPAddresses = DefineListProperty<IPAddress>(nameof(IPAddresses), ["properties", "ipAddresses"]);
    }
}
