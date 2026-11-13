// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.ResourceManager.Dns.Models;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Dns
{
    public partial class DnsZoneData
    {
        private IList<WritableSubResource> _registrationVirtualNetworks;
        private IList<WritableSubResource> _resolutionVirtualNetworks;

        /// <summary> A list of references to virtual networks that register hostnames in this DNS zone. This is only used when ZoneType is Private. </summary>
        // The service schema uses DnsSubResourceInfo, but this property shipped in stable 1.1.1 as WritableSubResource.
        // Preserve the stable public contract while adapting the generated backing collection.
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is obsolete and will be removed in a future version. Please use RegistrationVirtualNetworkReferences instead.")]
        public IList<WritableSubResource> RegistrationVirtualNetworks
        {
            get
            {
                if (Properties is null)
                {
                    Properties = new ZoneProperties();
                }
                return _registrationVirtualNetworks ??= new DnsSubResourceInfoList(Properties.RegistrationVirtualNetworkReferences);
            }
        }

        /// <summary> A list of references to virtual networks that resolve records in this DNS zone. This is only used when ZoneType is Private. </summary>
        // The service schema uses DnsSubResourceInfo, but this property shipped in stable 1.1.1 as WritableSubResource.
        // Preserve the stable public contract while adapting the generated backing collection.
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is obsolete and will be removed in a future version. Please use ResolutionVirtualNetworkReferences instead.")]
        public IList<WritableSubResource> ResolutionVirtualNetworks
        {
            get
            {
                if (Properties is null)
                {
                    Properties = new ZoneProperties();
                }
                return _resolutionVirtualNetworks ??= new DnsSubResourceInfoList(Properties.ResolutionVirtualNetworkReferences);
            }
        }
    }
}
