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
        get { return Properties is null ? default : Properties.PrivateLinkServiceConnectionState; }
        set { EnsureProperties(); Properties.SetPrivateLinkServiceConnectionState(value); }
    }

    /// <summary> Private IP addresses mapped to the remote private endpoint. </summary>
    [CodeGenMember("IPAddresses")]
    public BicepList<IPAddress> IPAddresses
    {
        get { return Properties is null ? default : Properties.IPAddresses; }
        set { EnsureProperties(); Properties.IPAddresses.Assign(value); }
    }

    partial void DefineAdditionalProperties()
    {
        _customKind = DefineProperty<string>(nameof(Kind), ["kind"]);
    }

    private void EnsureProperties()
    {
        if (Properties is null)
        {
            AssignOrReplace(ref _properties, new RemotePrivateEndpointConnectionProperties());
        }
    }
}

internal partial class RemotePrivateEndpointConnectionProperties
{
    internal void SetPrivateLinkServiceConnectionState(PrivateLinkConnectionState value)
    {
        Initialize();
        AssignOrReplace(ref _privateLinkServiceConnectionState, value);
    }
}
