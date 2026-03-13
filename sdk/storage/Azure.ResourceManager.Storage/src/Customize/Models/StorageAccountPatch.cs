// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

// Backward-compat: Adds hidden aliases for older patch property names.
// Could use @@clientName in spec but would lose improved names.

using System.ComponentModel;

namespace Azure.ResourceManager.Storage.Models
{
    public partial class StorageAccountPatch
    {
        /// <summary> Backward-compatible alias for DefaultToOAuthAuthentication. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("properties.defaultToOAuthAuthentication")]
        public bool? IsDefaultToOAuthAuthentication
        {
            get => DefaultToOAuthAuthentication;
            set => DefaultToOAuthAuthentication = value;
        }

        /// <summary> Backward-compatible alias for EnableExtendedGroups. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("properties.enableExtendedGroups")]
        public bool? IsExtendedGroupEnabled
        {
            get => EnableExtendedGroups;
            set => EnableExtendedGroups = value;
        }

        /// <summary> Backward-compatible alias for PublishIpv6Endpoint. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("properties.dualStackEndpointPreference.publishIpv6Endpoint")]
        public bool? IsIPv6EndpointToBePublished
        {
            get => PublishIpv6Endpoint;
            set => PublishIpv6Endpoint = value;
        }
    }
}
