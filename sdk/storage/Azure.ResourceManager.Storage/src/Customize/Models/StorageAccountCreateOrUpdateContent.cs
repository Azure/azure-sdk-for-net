// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

// Backward-compat: Adds constructor overload matching prior GA (sku, kind, location) and
// hidden property aliases for renamed boolean properties. Constructor initializes Tags
// and Zones collections to avoid NRE during serialization.

using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.Storage.Models
{
    public partial class StorageAccountCreateOrUpdateContent
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("properties.defaultToOAuthAuthentication")]
        public bool? IsDefaultToOAuthAuthentication
        {
            get => Properties is null ? default : Properties.IsDefaultToOAuthAuthentication;
            set
            {
                if (Properties is null)
                {
                    Properties = new StorageAccountPropertiesCreateParameters();
                }
                Properties.IsDefaultToOAuthAuthentication = value;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("properties.enableExtendedGroups")]
        public bool? IsExtendedGroupEnabled
        {
            get => Properties is null ? default : Properties.IsExtendedGroupEnabled;
            set
            {
                if (Properties is null)
                {
                    Properties = new StorageAccountPropertiesCreateParameters();
                }
                Properties.IsExtendedGroupEnabled = value;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("properties.isNfsV3Enabled")]
        public bool? IsNfsV3Enabled
        {
            get => Properties is null ? default : Properties.IsNfsV3Enabled;
            set
            {
                if (Properties is null)
                {
                    Properties = new StorageAccountPropertiesCreateParameters();
                }
                Properties.IsNfsV3Enabled = value;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("properties.dualStackEndpointPreference.publishIpv6Endpoint")]
        public bool? IsIPv6EndpointToBePublished
        {
            get => Properties is null ? default : Properties.IsIPv6EndpointToBePublished;
            set
            {
                if (Properties is null)
                {
                    Properties = new StorageAccountPropertiesCreateParameters();
                }
                Properties.IsIPv6EndpointToBePublished = value;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public StorageAccountCreateOrUpdateContent(StorageSku sku, StorageKind kind, AzureLocation location) : this(sku, kind, location.ToString(), default, new ChangeTrackingList<string>(), default, new ChangeTrackingDictionary<string, string>(), default, default, default)
        {
        }
    }
}
