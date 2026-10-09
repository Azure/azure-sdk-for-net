// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Provisioning.Resources;

namespace Azure.Provisioning.Network;

public partial class CustomIPPrefix
{
    private BicepList<WritableSubResource> _childCustomIPPrefixList;

    // Preserve the name and element type shipped in 1.1.0 without replacing ChildCustomIPPrefixes.
    // The different collection types require a separate output-only view of the same Bicep path.
    /// <inheritdoc cref="ChildCustomIPPrefixes"/>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This property is deprecated and it will be removed in a future version. Please use ChildCustomIPPrefixes instead.")]
    public BicepList<WritableSubResource> ChildCustomIPPrefixList
    {
        get
        {
            Initialize();
            return _childCustomIPPrefixList;
        }
    }

    partial void DefineAdditionalProperties()
    {
#pragma warning disable CS0618
        _childCustomIPPrefixList = DefineListProperty<WritableSubResource>(nameof(ChildCustomIPPrefixList), new string[] { "properties", "childCustomIpPrefixes" }, isOutput: true);
#pragma warning restore CS0618
    }
}
