// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.Storage.Models
{
    public partial class StorageAccountPatch
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
                    Properties = new StorageAccountPropertiesUpdateParameters();
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
                    Properties = new StorageAccountPropertiesUpdateParameters();
                }
                Properties.IsExtendedGroupEnabled = value;
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
                    Properties = new StorageAccountPropertiesUpdateParameters();
                }
                Properties.IsIPv6EndpointToBePublished = value;
            }
        }
    }
}
