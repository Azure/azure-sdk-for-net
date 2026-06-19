// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Network.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Compatibility declaration for the PacketCaptureCreateOrUpdateContent type. </summary>
    public partial class PacketCaptureCreateOrUpdateContent
    {
        /// <summary> Gets or sets the IsContinuousCapture compatibility property. </summary>
        public bool? IsContinuousCapture
        {
            get => ContinuousCapture;
            set => ContinuousCapture = value;
        }
    }
}
