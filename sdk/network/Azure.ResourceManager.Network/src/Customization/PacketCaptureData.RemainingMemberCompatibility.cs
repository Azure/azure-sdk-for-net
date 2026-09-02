// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Resources.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network
{
    /// <summary> Compatibility declaration for the PacketCaptureData type. </summary>
    [CodeGenSuppress("Filters")]
    public partial class PacketCaptureData
    {
        /// <summary> Gets or sets the Filters compatibility property. </summary>
        public IReadOnlyList<Models.PacketCaptureFilter> Filters => Properties?.Filters as IReadOnlyList<Models.PacketCaptureFilter>;
    }
}
