// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;

    /// <summary>
    /// A client-side representation allowing user to get next hop for a packet from specific vm.
    /// </summary>
    public interface INextHop  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IExecutable<Microsoft.Azure.Management.Network.Fluent.INextHop>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasParent<Microsoft.Azure.Management.Network.Fluent.INetworkWatcher>
    {
        /// <summary>
        /// Gets the resource identifier of the target resource against which the action
        /// is to be performed.
        /// </summary>
        /// <summary>
        /// Gets the targetResourceId value.
        /// </summary>
        string TargetResourceId { get; }

        /// <summary>
        /// Gets the destination IP address.
        /// </summary>
        string DestinationIPAddress { get; }

        /// <summary>
        /// Gets the source IP address.
        /// </summary>
        string SourceIPAddress { get; }

        /// <summary>
        /// Gets the network interface id.
        /// </summary>
        string TargetNetworkInterfaceId { get; }

        /// <summary>
        /// Gets the next hop type.
        /// </summary>
        Models.NextHopType NextHopType { get; }

        /// <summary>
        /// Gets the resource identifier for the route table associated with the route
        /// being returned. If the route being returned does not correspond to any
        /// user created routes then this field will be the string 'System Route'.
        /// </summary>
        /// <summary>
        /// Gets the routeTableId value.
        /// </summary>
        string RouteTableId { get; }

        /// <summary>
        /// Gets the next hop IP Address.
        /// </summary>
        string NextHopIpAddress { get; }
    }
}