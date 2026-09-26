// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Compatibility declaration for the PacketCaptureCreateOrUpdateContent type. </summary>
    public partial class PacketCaptureCreateOrUpdateContent
    {
        // Preserve the TypeSpec-generated property name because it maps to the same wire property as the preferred member.
        /// <inheritdoc cref="IsContinuousCapture"/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is deprecated and it will be removed in a future version. Please use IsContinuousCapture instead.")]
        public bool? ContinuousCapture
        {
            get => IsContinuousCapture;
            set => IsContinuousCapture = value;
        }
    }
}
