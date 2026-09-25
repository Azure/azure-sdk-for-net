// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network
{
    // Without suppression, the generator emits its default flattened Filters member. This replacement preserves the released
    // read-only Filters API and safely delegates to the nested list while Properties.Filters owns serialization.
    [CodeGenSuppress("Filters")]
    public partial class PacketCaptureData
    {
        // Restores the released IsContinuousCapture API as an alias of the canonical ContinuousCapture property.
        /// <summary> Gets whether continuous packet capture is enabled. </summary>
        public bool? IsContinuousCapture => ContinuousCapture;

        /// <summary> Gets or sets the Filters compatibility property. </summary>
        public IReadOnlyList<Models.PacketCaptureFilter> Filters
            => Properties is null ? default : new ReadOnlyCollection<Models.PacketCaptureFilter>(Properties.Filters);
    }
}
