// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using Azure.Core;

namespace Azure.Provisioning.Network;

public partial class ServiceAssociationLink
{
    // Subnet.serviceAssociationLinks is output-only, so enclosing-model usage removes
    // setters from otherwise writable fields. Preserve the 1.1.0 assignment APIs using
    // the registered properties model, including the existing locations list.
    /// <summary> Gets or sets whether the resource can be deleted. </summary>
    public BicepValue<bool> AllowDelete
    {
        get { return Properties.AllowDelete; }
        set { Properties.AllowDelete.Assign(value); }
    }

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

    /// <summary> Gets or sets the locations of the service association link. </summary>
    public BicepList<AzureLocation> Locations
    {
        get { return Properties.Locations; }
        set { Properties.Locations.Assign(value); }
    }

    // TypeSpec does not mark name as read-only, and management exposes a setter.
    // Preserve the released setter despite provisioning's model-level writable-usage gate.
    /// <summary> The name of the service association link. </summary>
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
