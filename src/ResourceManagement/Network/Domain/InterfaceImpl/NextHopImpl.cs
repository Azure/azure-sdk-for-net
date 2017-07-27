// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Network.Fluent.NextHop.Definition;
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    internal partial class NextHopImpl 
    {
        /// <summary>
        /// Gets the next hop IP Address.
        /// </summary>
        string Microsoft.Azure.Management.Network.Fluent.INextHop.NextHopIpAddress
        {
            get
            {
                return this.NextHopIpAddress();
            }
        }

        /// <summary>
        /// Gets the source IP address.
        /// </summary>
        string Microsoft.Azure.Management.Network.Fluent.INextHop.SourceIPAddress
        {
            get
            {
                return this.SourceIPAddress();
            }
        }

        /// <summary>
        /// Gets the network interface id.
        /// </summary>
        string Microsoft.Azure.Management.Network.Fluent.INextHop.TargetNetworkInterfaceId
        {
            get
            {
                return this.TargetNetworkInterfaceId();
            }
        }

        /// <summary>
        /// Gets the next hop type.
        /// </summary>
        Models.NextHopType Microsoft.Azure.Management.Network.Fluent.INextHop.NextHopType
        {
            get
            {
                return this.NextHopType() as Models.NextHopType;
            }
        }

        /// <summary>
        /// Gets the destination IP address.
        /// </summary>
        string Microsoft.Azure.Management.Network.Fluent.INextHop.DestinationIPAddress
        {
            get
            {
                return this.DestinationIPAddress();
            }
        }

        /// <summary>
        /// Gets the resource identifier of the target resource against which the action
        /// is to be performed.
        /// </summary>
        /// <summary>
        /// Gets the targetResourceId value.
        /// </summary>
        string Microsoft.Azure.Management.Network.Fluent.INextHop.TargetResourceId
        {
            get
            {
                return this.TargetResourceId();
            }
        }

        /// <summary>
        /// Gets the resource identifier for the route table associated with the route
        /// being returned. If the route being returned does not correspond to any
        /// user created routes then this field will be the string 'System Route'.
        /// </summary>
        /// <summary>
        /// Gets the routeTableId value.
        /// </summary>
        string Microsoft.Azure.Management.Network.Fluent.INextHop.RouteTableId
        {
            get
            {
                return this.RouteTableId();
            }
        }

        /// <summary>
        /// Gets the parent of this child object.
        /// </summary>
        Microsoft.Azure.Management.Network.Fluent.INetworkWatcher Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasParent<Microsoft.Azure.Management.Network.Fluent.INetworkWatcher>.Parent
        {
            get
            {
                return this.Parent() as Microsoft.Azure.Management.Network.Fluent.INetworkWatcher;
            }
        }

        /// <summary>
        /// Set the targetResourceId value.
        /// </summary>
        /// <param name="vmId">The targetResourceId value to set.</param>
        /// <return>The VerificationIPFlow object itself.</return>
        NextHop.Definition.IWithSourceIP NextHop.Definition.IWithTargetResource.WithTargetResourceId(string vmId)
        {
            return this.WithTargetResourceId(vmId) as NextHop.Definition.IWithSourceIP;
        }

        /// <summary>
        /// Set the targetNetworkInterfaceId value.
        /// </summary>
        /// <param name="targetNetworkInterfaceId">The targetNetworkInterfaceId value to set.</param>
        /// <return>The VerificationIPFlow object itself.</return>
        NextHop.Definition.IWithExecute NextHop.Definition.IWithNetworkInterface.WithTargetNetworkInterfaceId(string targetNetworkInterfaceId)
        {
            return this.WithTargetNetworkInterfaceId(targetNetworkInterfaceId) as NextHop.Definition.IWithExecute;
        }

        /// <summary>
        /// Set the sourceIPAddress value.
        /// </summary>
        /// <param name="sourceIPAddress">The sourceIPAddress value to set.</param>
        /// <return>The VerificationIPFlow object itself.</return>
        NextHop.Definition.IWithDestinationIP NextHop.Definition.IWithSourceIP.WithSourceIPAddress(string sourceIPAddress)
        {
            return this.WithSourceIPAddress(sourceIPAddress) as NextHop.Definition.IWithDestinationIP;
        }

        /// <summary>
        /// Set the destinationIPAddress value.
        /// </summary>
        /// <param name="destinationIPAddress">The destinationIPAddress value to set.</param>
        /// <return>The VerificationIPFlow object itself.</return>
        NextHop.Definition.IWithExecute NextHop.Definition.IWithDestinationIP.WithDestinationIPAddress(string destinationIPAddress)
        {
            return this.WithDestinationIPAddress(destinationIPAddress) as NextHop.Definition.IWithExecute;
        }
    }
}