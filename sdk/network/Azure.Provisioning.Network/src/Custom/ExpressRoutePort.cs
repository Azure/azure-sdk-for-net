// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.Network;

public partial class ExpressRoutePort
{
    /// <summary> Gets or sets the ExpressRoute link resources. </summary>
    [CodeGenMember("Links")]
    public BicepList<ExpressRouteLink> LinkResources
    {
        get => Properties is null ? default : Properties.Links;
        set
        {
            if (Properties is null)
            {
                Properties = new ExpressRoutePortPropertiesFormat();
            }
            Properties.Links = value;
        }
    }

    /// <summary> Gets or sets the ExpressRoute link data models. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This property is deprecated and it will be removed in a future version. Please use LinkResources instead.")]
    public BicepList<ExpressRouteLinkData> Links
    {
        get
        {
            if (Properties is null)
            {
                Properties = new ExpressRoutePortPropertiesFormat();
            }
            return Properties.LinkData;
        }
        set
        {
            if (Properties is null)
            {
                Properties = new ExpressRoutePortPropertiesFormat();
            }
            Properties.LinkData = value;
        }
    }

    partial void DefineAdditionalProperties()
    {
    }
}

internal partial class ExpressRoutePortPropertiesFormat
{
#pragma warning disable CS0618
    private BicepList<ExpressRouteLinkData> _linkData;

    internal BicepList<ExpressRouteLinkData> LinkData
    {
        get { Initialize(); return _linkData; }
        set { Initialize(); _linkData.Assign(value); }
    }

    partial void DefineAdditionalProperties()
    {
        _linkData = DefineListProperty<ExpressRouteLinkData>("Links", new string[] { "links" });
    }
#pragma warning restore CS0618
}
