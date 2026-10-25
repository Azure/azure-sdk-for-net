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
    public partial class PacketCaptureData
    {
        // Preserve the pre-TypeSpec property name because it maps to the same wire property as the generated member.
        /// <inheritdoc cref="IsContinuousCapture"/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is deprecated and it will be removed in a future version. Please use IsContinuousCapture instead.")]
        public bool? ContinuousCapture => IsContinuousCapture;

        // 1.15.0 exposed a read-only view; the shared request properties must retain their writable filter list.
        /// <summary> Gets the packet capture filters. </summary>
        [CodeGenMember("Filters")]
        [WirePath("properties.filters")]
        public IReadOnlyList<PacketCaptureFilter> Filters
        {
            get
            {
                var properties = Properties;
                return properties is null ? null : new ReadOnlyCollection<PacketCaptureFilter>(properties.Filters);
            }
        }
    }
}
