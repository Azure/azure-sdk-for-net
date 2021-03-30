// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Core;
using System;
using System.Collections.Generic;

namespace Proto.Network
{
    /// <summary>
    /// A class representing the public IP address data model.
    /// </summary>
    public class PublicIPAddressData : TrackedResource<ResourceGroupResourceIdentifier, PublicIPAddress>
    {
        /// <summary>
        /// Gets the resource type definition for a public IP address.
        /// </summary>
        public static ResourceType ResourceType => "Microsoft.Network/publicIpAddresses";

        /// <summary>
        /// Initializes a new instance of the <see cref="PublicIPAddressData"/> class.
        /// </summary>
        /// <param name="ip"> The public IP address to initialize. </param>
        public PublicIPAddressData(PublicIPAddress ip) : base(ip.Id, ip.Location, ip)
        {
        }

        /// <summary> Resource tags. </summary>
        public override IDictionary<string, string> Tags => Model.Tags;

        /// <summary> The name property of the network security group resource. </summary>
        public override string Name => Model.Name;

        /// <summary> The public IP address SKU. </summary>
        public PublicIPAddressSku Sku
        {
            get => Model.Sku;
            set => Model.Sku = value;
        }

        /// <summary> A unique read-only string that changes whenever the resource is updated. </summary>
        public string Etag => Model.Etag;

        /// <summary> A list of availability zones denoting the IP allocated for the resource needs to come from. </summary>
        public IList<string> Zones
        {
            get => Model.Zones;
        }

        /// <summary> The public IP address allocation method. </summary>
        public IPAllocationMethod? PublicIPAllocationMethod
        {
            get => Model.PublicIPAllocationMethod;
            set => Model.PublicIPAllocationMethod = value;
        }

        /// <summary> The public IP address version. </summary>
        public IPVersion? PublicIPAddressVersion
        {
            get => Model.PublicIPAddressVersion;
            set => Model.PublicIPAddressVersion = value;
        }

        /// <summary> The IP configuration associated with the public IP address. </summary>
        public IPConfiguration IpConfiguration => Model.IpConfiguration;

        /// <summary> The FQDN of the DNS record associated with the public IP address. </summary>
        public PublicIPAddressDnsSettings DnsSettings
        {
            get => Model.DnsSettings;
            set => Model.DnsSettings = value;
        }

        /// <summary> The DDoS protection custom policy associated with the public IP address. </summary>
        public DdosSettings DdosSettings
        {
            get => Model.DdosSettings;
            set => Model.DdosSettings = value;
        }

        /// <summary> The list of tags associated with the public IP address. </summary>
        public IList<IpTag> IpTags
        {
            get => Model.IpTags;
        }

        /// <summary> The IP address associated with the public IP address resource. </summary>
        public string IpAddress
        {
            get => Model.IpAddress;
            set => Model.IpAddress = value;
        }

        /// <summary> The Public IP Prefix this Public IP Address should be allocated from. </summary>
        public SubResource PublicIPPrefix
        {
            get => Model.PublicIPPrefix;
            set => Model.PublicIPPrefix = value;
        }

        /// <summary> The idle timeout of the public IP address. </summary>
        public int? IdleTimeoutInMinutes
        {
            get => Model.IdleTimeoutInMinutes;
            set => Model.IdleTimeoutInMinutes = value;
        }

        /// <summary> The resource GUID property of the public IP address resource. </summary>
        public string ResourceGuid => Model.ResourceGuid;

        /// <summary> The provisioning state of the public IP address resource. </summary>
        public ProvisioningState? ProvisioningState => Model.ProvisioningState;
    }
}
