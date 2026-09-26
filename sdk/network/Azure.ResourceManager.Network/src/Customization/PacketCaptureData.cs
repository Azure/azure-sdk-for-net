// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Azure.ResourceManager.Network.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network
{
    // Without suppression, the generator emits its default flattened Filters member. This replacement preserves the released
    // read-only Filters API and safely delegates to the nested list while Properties.Filters owns serialization.
    [CodeGenSuppress("Filters")]
    public partial class PacketCaptureData
    {
        // Preserve the pre-TypeSpec property name because it maps to the same wire property as the generated member.
        /// <inheritdoc cref="IsContinuousCapture"/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is deprecated and it will be removed in a future version. Please use IsContinuousCapture instead.")]
        public bool? ContinuousCapture => IsContinuousCapture;

        /// <summary> Gets or sets the Filters compatibility property. </summary>
        public IReadOnlyList<PacketCaptureFilter> Filters
            => Properties is null ? default : new ReadOnlyCollection<PacketCaptureFilter>(Properties.Filters);
    }
}
