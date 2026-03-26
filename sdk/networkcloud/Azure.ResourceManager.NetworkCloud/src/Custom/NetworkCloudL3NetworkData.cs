// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.NetworkCloud.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.NetworkCloud
{
    [CodeGenSuppress("NetworkCloudL3NetworkData", typeof(AzureLocation), typeof(ResourceIdentifier), typeof(long), typeof(ExtendedLocation))]
    public partial class NetworkCloudL3NetworkData
    {
        /// <summary> The type of the IP address allocation. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IPAllocationType? IPAllocationType
        {
            get => Properties is null ? default : Properties.IPAllocationType;
            set
            {
                if (Properties is null)
                    Properties = new Models.L3NetworkProperties();
                Properties.IPAllocationType = value;
            }
        }

        /// <summary> The IPV4 prefix (CIDR) assigned to this L3 network. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string IPv4ConnectedPrefix
        {
            get => Properties?.IPv4ConnectedPrefix;
            set
            {
                if (Properties is null)
                    Properties = new Models.L3NetworkProperties();
                Properties.IPv4ConnectedPrefix = value;
            }
        }

        /// <summary> The IPV6 prefix (CIDR) assigned to this L3 network. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string IPv6ConnectedPrefix
        {
            get => Properties?.IPv6ConnectedPrefix;
            set
            {
                if (Properties is null)
                    Properties = new Models.L3NetworkProperties();
                Properties.IPv6ConnectedPrefix = value;
            }
        }

        /// <summary> Initializes a new instance of <see cref="NetworkCloudL3NetworkData"/>. </summary>
        public NetworkCloudL3NetworkData(AzureLocation location, ExtendedLocation extendedLocation, ResourceIdentifier l3IsolationDomainId, long vlan)
            : base(location)
        {
            Argument.AssertNotNull(extendedLocation, nameof(extendedLocation));
            Argument.AssertNotNull(l3IsolationDomainId, nameof(l3IsolationDomainId));
            Properties = new L3NetworkProperties(l3IsolationDomainId, vlan);
            ExtendedLocation = extendedLocation;
        }

        /// <summary> The extended location of the cluster associated with the resource. </summary>
        public Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation ExtendedLocation { get; set; }
    }
}
