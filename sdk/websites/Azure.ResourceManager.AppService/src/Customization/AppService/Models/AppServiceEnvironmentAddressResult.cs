// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Net;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.AppService.Models
{
    // The AppServiceEnvironmentAddressResult class is a GA-compatibility shim for the original AppServiceEnvironmentAddressResult model, which was a plain payload returned by AppServiceEnvironmentResource.GetVipInfo (and slot variants).
    // After the TypeSpec migration, the underlying API surfaced as a singleton sub-resource (AppServiceEnvironmentAddressResource) with a *Data model (AppServiceEnvironmentAddressData).
    // To preserve the GA API surface, this class is retained.
    /// <summary>
    /// Describes main public IP address and any extra virtual IPs.
    /// Serialized Name: AddressResponse
    /// </summary>
    public partial class AppServiceEnvironmentAddressResult : ResourceData
    {
        /// <summary> Initializes a new instance of <see cref="AppServiceEnvironmentAddressResult"/>. </summary>
        public AppServiceEnvironmentAddressResult()
        {
            OutboundIPAddresses = new ChangeTrackingList<IPAddress>();
            VirtualIPMappings = new ChangeTrackingList<VirtualIPMapping>();
        }

        internal AppServiceEnvironmentAddressResult(
            ResourceIdentifier id,
            string name,
            ResourceType resourceType,
            SystemData systemData,
            string kind,
            IPAddress serviceIPAddress,
            IPAddress internalIPAddress,
            IList<IPAddress> outboundIPAddresses,
            IList<VirtualIPMapping> virtualIPMappings,
            IDictionary<string, BinaryData> rawData)
            : base(id, name, resourceType, systemData)
        {
            Kind = kind;
            ServiceIPAddress = serviceIPAddress;
            InternalIPAddress = internalIPAddress;
            OutboundIPAddresses = outboundIPAddresses ?? new ChangeTrackingList<IPAddress>();
            VirtualIPMappings = virtualIPMappings ?? new ChangeTrackingList<VirtualIPMapping>();
            _serializedAdditionalRawData = rawData;
        }

        /// <summary> Kind of resource. </summary>
        [WirePath("kind")]
        public string Kind { get; set; }

        /// <summary> Main public virtual IP. </summary>
        [WirePath("properties.serviceIpAddress")]
        public IPAddress ServiceIPAddress { get; set; }

        /// <summary> Virtual Network internal IP address of the App Service Environment if it is in internal load-balancing mode. </summary>
        [WirePath("properties.internalIpAddress")]
        public IPAddress InternalIPAddress { get; set; }

        /// <summary> IP addresses appearing on outbound connections. </summary>
        [WirePath("properties.outboundIpAddresses")]
        public IList<IPAddress> OutboundIPAddresses { get; }

        /// <summary> Additional virtual IPs. </summary>
        [WirePath("properties.vipMappings")]
        public IList<VirtualIPMapping> VirtualIPMappings { get; }

        internal IDictionary<string, BinaryData> _serializedAdditionalRawData;
    }
}
