// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.Storage.Models
{
    public partial class StorageAccountCreateOrUpdateContent
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

        /// <summary> Backward-compatible alias for EnableNfsV3. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("properties.isNfsV3Enabled")]
        public bool? IsNfsV3Enabled
        {
            get => EnableNfsV3;
            set => EnableNfsV3 = value;
        }

        /// <summary> Backward-compatible alias for PublishIpv6Endpoint. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("properties.dualStackEndpointPreference.publishIpv6Endpoint")]
        public bool? IsIPv6EndpointToBePublished
        {
            get => PublishIpv6Endpoint;
            set => PublishIpv6Endpoint = value;
        }

        /// <summary> Backward-compatible constructor. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public StorageAccountCreateOrUpdateContent(StorageSku sku, StorageKind kind, AzureLocation location) : this(sku, kind, location.Name)
        {
        }
    }
}
