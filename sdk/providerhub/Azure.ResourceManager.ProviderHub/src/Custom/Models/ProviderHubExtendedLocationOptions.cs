// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.ResourceManager.ProviderHub.Models
{
    /// <summary> The ProviderHubExtendedLocationOptions. </summary>
    public partial class ProviderHubExtendedLocationOptions
    {
        /// <summary> Gets or sets the extended location options type. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string ExtendedLocationOptionsType { get => LocationType?.ToString(); set => LocationType = new ProviderExtendedLocationType(value); }
        /// <summary> Gets or sets the supported policy. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string SupportedPolicy { get => SupportedLocationPolicy.ToString(); set => SupportedLocationPolicy = new ResourceTypeExtendedLocationPolicy(value); }
    }
}
