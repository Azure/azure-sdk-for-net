// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Provisioning.Network;

public partial class ContainerNetworkInterface
{
    // NetworkProfile.containerNetworkInterfaces is output-only, so usage analysis removes
    // this setter even though container.id is writable. Preserve the 1.1.0 assignment API
    // through the registered properties.container.id value, not independent storage.
    /// <summary> Gets or sets the ID of the container attached to this network interface. </summary>
    public BicepValue<ResourceIdentifier> ContainerId
    {
        get { return Properties.ContainerId; }
        set { Properties.ContainerId.Assign(value); }
    }

    // TypeSpec does not mark name as read-only, and management exposes a setter.
    // Preserve the released setter despite provisioning's model-level writable-usage gate.
    /// <summary> The name of the container network interface. </summary>
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
}
