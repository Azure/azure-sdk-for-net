// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network
{
    [CodeGenSuppress("Filters")]
    public partial class PacketCaptureData
    {
        /// <summary> Gets the continuous capture compatibility value. </summary>
        public bool? IsContinuousCapture => ContinuousCapture;

        /// <summary> Gets or sets the Filters compatibility property. </summary>
        public IReadOnlyList<Models.PacketCaptureFilter> Filters => Properties?.Filters as IReadOnlyList<Models.PacketCaptureFilter>;
    }
}
