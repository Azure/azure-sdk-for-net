// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using Azure.Core;

namespace Azure.Provisioning.Network;

public partial class VirtualNetworkApplianceIPConfiguration
{
    // VirtualNetworkAppliance.ipConfigurations is output-only, making the enclosing
    // model non-settable despite these fields being writable in TypeSpec. Restore
    // the 1.1.0 setters through the registered properties model for Bicep serialization.
    /// <summary> Gets or sets whether this is the primary IP configuration. </summary>
    public BicepValue<bool> Primary
    {
        get { return Properties.Primary; }
        set { Properties.Primary.Assign(value); }
    }

    /// <summary> Gets or sets the private IP address. </summary>
    public BicepValue<string> PrivateIPAddress
    {
        get { return Properties.PrivateIPAddress; }
        set { Properties.PrivateIPAddress.Assign(value); }
    }

    /// <summary> Gets or sets the private IP address version. </summary>
    public BicepValue<NetworkIPVersion> PrivateIPAddressVersion
    {
        get { return Properties.PrivateIPAddressVersion; }
        set { Properties.PrivateIPAddressVersion.Assign(value); }
    }

    /// <summary> Gets or sets the private IP address allocation method. </summary>
    public BicepValue<NetworkIPAllocationMethod> PrivateIPAllocationMethod
    {
        get { return Properties.PrivateIPAllocationMethod; }
        set { Properties.PrivateIPAllocationMethod.Assign(value); }
    }

    // TypeSpec does not mark name as read-only, and management exposes a setter.
    // Preserve the released setter despite provisioning's model-level writable-usage gate.
    /// <summary> The name of the virtual network appliance IP configuration. </summary>
    public BicepValue<string> Name
    {
        get { Initialize(); return _name!; }
        set { Initialize(); _name!.Assign(value); }
    }
    private BicepValue<string>? _name;

    partial void DefineAdditionalProperties()
    {
        _name = DefineProperty<string>(nameof(Name), new string[] { "name" });
    }

    /// <inheritdoc cref="Type"/>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This property is deprecated and it will be removed in a future version. Please use Type instead.")]
    public BicepValue<ResourceType> ResourceType => ResourceTypeCompatibility.FromType(Type);
}
