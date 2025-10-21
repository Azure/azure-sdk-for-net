// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.ProviderHub.Models
{
    /// <summary> The ProviderHubExtendedLocationType. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum ProviderHubExtendedLocationType
    {
        /// <summary> NotSpecified. </summary>
        NotSpecified,
        /// <summary> EdgeZone. </summary>
        EdgeZone,
        /// <summary> ArcZone. </summary>
        ArcZone,
        /// <summary> CustomLocation. </summary>
        CustomLocation
    }
}
