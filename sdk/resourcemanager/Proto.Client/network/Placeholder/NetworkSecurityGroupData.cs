// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.ResourceManager.Core;
using Azure.ResourceManager.Network.Models;
using System.Collections.Generic;

namespace Proto.Network
{
    /// <summary>
    /// A class representing the NetworkSecurityGroup data model.
    /// </summary>
    public class NetworkSecurityGroupData :
        TrackedResource<ResourceGroupResourceIdentifier, Azure.ResourceManager.Network.Models.NetworkSecurityGroup>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NetworkSecurityGroupData"/> class.
        /// </summary>
        /// <param name="nsg"> The network security group to initialize. </param>
        public NetworkSecurityGroupData(Azure.ResourceManager.Network.Models.NetworkSecurityGroup nsg)
            : base(nsg.Id, nsg.Location, nsg) 
        {
        }

        /// <summary> Resource tags. </summary>
        public override IDictionary<string, string> Tags => Model.Tags;

        /// <summary> The name property of the network security group resource. </summary>
        public override string Name => Model.Name;

        /// <summary> A unique read-only string that changes whenever the resource is updated. </summary>
        public string Etag => Model.Etag;

        /// <summary> A collection of security rules of the network security group. </summary>
        public IList<SecurityRule> SecurityRules
        {
            get => Model.SecurityRules;
        }

        /// <summary> The default security rules of network security group. </summary>
        public IReadOnlyList<SecurityRule> DefaultSecurityRules => Model.DefaultSecurityRules;

        /// <summary> A collection of references to network interfaces. </summary>
        public IReadOnlyList<Azure.ResourceManager.Network.Models.NetworkInterface> NetworkInterfaces => Model.NetworkInterfaces;

        /// <summary> A collection of references to subnets. </summary>
        public IReadOnlyList<Azure.ResourceManager.Network.Models.Subnet> Subnets => Model.Subnets;

        /// <summary> A collection of references to flow log resources. </summary>

        public IReadOnlyList<FlowLog> FlowLogs => Model.FlowLogs;

        /// <summary> The resource GUID property of the network security group resource. </summary>
        public string ResourceGuid => Model.ResourceGuid;

        /// <summary> The provisioning state of the network security group resource. </summary>
        public ProvisioningState? ProvisioningState => Model.ProvisioningState;
    }
}
