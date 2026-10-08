// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.Core;

namespace Azure.Provisioning.Network;

public partial class NetworkIPConfiguration
{
    private BicepValue<ResourceType> _resourceType;

    // Subnet.ipConfigurations and PublicIPAddress.ipConfiguration are output-only usages.
    // Their IP configuration fields are not read-only in TypeSpec. Preserve the 1.1.0
    // setters by updating the registered properties model, including model replacements.
    /// <summary> Gets or sets the private IP address of the IP configuration. </summary>
    public BicepValue<string> PrivateIPAddress
    {
        get { return Properties.PrivateIPAddress; }
        set { Properties.PrivateIPAddress.Assign(value); }
    }

    /// <summary> Gets or sets the private IP address allocation method. </summary>
    public BicepValue<NetworkIPAllocationMethod> PrivateIPAllocationMethod
    {
        get { return Properties.PrivateIPAllocationMethod; }
        set { Properties.PrivateIPAllocationMethod.Assign(value); }
    }

    /// <summary> Gets or sets the reference to the subnet resource. </summary>
    public SubnetResource Subnet
    {
        get { return Properties.Subnet; }
        set { Properties.SetSubnet(value); }
    }

    /// <summary> Gets or sets the reference to the public IP resource. </summary>
    public PublicIPAddress PublicIPAddress
    {
        get { return Properties.PublicIPAddress; }
        set { Properties.SetPublicIPAddress(value); }
    }

    // TypeSpec does not mark name as read-only, and management exposes a setter.
    // Preserve the released setter despite provisioning's model-level writable-usage gate.
    /// <summary> The name of the IP configuration. </summary>
    public BicepValue<string> Name
    {
        get { Initialize(); return _name; }
        set { Initialize(); _name.Assign(value); }
    }
    private BicepValue<string> _name;

    // Preserve the output-only resource type and Bicep path shipped in 1.1.0.
    /// <summary> Resource type. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public BicepValue<ResourceType> ResourceType
    {
        get
        {
            Initialize();
            return _resourceType;
        }
    }

    partial void DefineAdditionalProperties()
    {
        _name = DefineProperty<string>(nameof(Name), new string[] { "name" });
        _resourceType = DefineProperty<ResourceType>(nameof(ResourceType), new string[] { "type" }, isOutput: true);
    }
}
