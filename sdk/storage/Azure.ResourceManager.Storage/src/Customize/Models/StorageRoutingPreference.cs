// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.Storage.Models
{
    public partial class StorageRoutingPreference
    {
        /// <summary> Backward-compatible alias for PublishInternetEndpoints. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("publishInternetEndpoints")]
        public bool? IsInternetEndpointsPublished
        {
            get => PublishInternetEndpoints;
            set => PublishInternetEndpoints = value;
        }

        /// <summary> Backward-compatible alias for PublishMicrosoftEndpoints. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("publishMicrosoftEndpoints")]
        public bool? IsMicrosoftEndpointsPublished
        {
            get => PublishMicrosoftEndpoints;
            set => PublishMicrosoftEndpoints = value;
        }
    }
}
