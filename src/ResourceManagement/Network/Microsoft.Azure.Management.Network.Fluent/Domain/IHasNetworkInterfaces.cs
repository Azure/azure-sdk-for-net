// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Fluent.Network
{

    using System.Collections.Generic;
    /// <summary>
    /// Interface exposing a list of network interfaces.
    /// </summary>
    public interface IHasNetworkInterfaces 
    {
        /// <summary>
        /// Gets the primary network interface.
        /// <p>
        /// Note that this method can result in a call to the cloud to fetch the network interface information.
        /// </summary>
        /// <returns>the primary network interface associated with this resource</returns>
        Microsoft.Azure.Management.Fluent.Network.INetworkInterface GetPrimaryNetworkInterface();

        /// <returns>the resource id of the primary network interface associated with this resource</returns>
        string PrimaryNetworkInterfaceId { get; }

        /// <returns>the list of resource IDs of the network interfaces associated with this resource</returns>
        System.Collections.Generic.IList<string> NetworkInterfaceIds { get; }

    }
}