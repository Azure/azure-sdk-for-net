// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using Azure.Core;

namespace Azure.Provisioning.Network;

public partial class CustomIPPrefix
{
    // Preserve the pre-TypeSpec property name because it maps to the same Bicep property as the generated member.
    /// <inheritdoc cref="CustomIPPrefixParent"/>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This property is deprecated and it will be removed in a future version. Please use CustomIPPrefixParent instead.")]
    public BicepValue<ResourceIdentifier> ParentCustomIPPrefixId
    {
        get => CustomIPPrefixParent;
        set => CustomIPPrefixParent = value;
    }
}
