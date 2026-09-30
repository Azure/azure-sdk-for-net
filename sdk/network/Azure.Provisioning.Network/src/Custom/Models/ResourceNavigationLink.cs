// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Provisioning.Network;

public partial class ResourceNavigationLink
{
    // Subnet.resourceNavigationLinks is output-only, making this model non-settable.
    // The link fields themselves are writable in TypeSpec. Preserve their 1.1.0 setters
    // by assigning the existing Bicep values registered under properties.
    /// <summary> Gets or sets the link to the external resource. </summary>
    public BicepValue<ResourceIdentifier> Link
    {
        get { return Properties.Link; }
        set { Properties.Link.Assign(value); }
    }

    /// <summary> Gets or sets the type of the linked resource. </summary>
    public BicepValue<ResourceType> LinkedResourceType
    {
        get { return Properties.LinkedResourceType; }
        set { Properties.LinkedResourceType.Assign(value); }
    }

    // TypeSpec does not mark name as read-only, and management exposes a setter.
    // Preserve the released setter despite provisioning's model-level writable-usage gate.
    /// <summary> The name of the resource navigation link. </summary>
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
