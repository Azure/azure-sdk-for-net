// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using System.Collections.Generic;

    /// <summary>
    /// Interface exposing a list of network interfaces.
    /// </summary>
    public interface IHasNetworkInterfaces 
    {
        /// <summary>
        /// Gets the primary network interface.
        /// Note that this method can result in a call to the cloud to fetch the network interface information.
        /// </summary>
        /// <return>The primary network interface associated with this resource.</return>
        Microsoft.Azure.Management.Network.Fluent.INetworkInterface GetPrimaryNetworkInterface();

        /// <summary>
        /// Gets the resource id of the primary network interface associated with this resource.
        /// </summary>
        string PrimaryNetworkInterfaceId { get; }

        /// <summary>
        /// Gets the list of resource IDs of the network interfaces associated with this resource.
        /// </summary>
        System.Collections.Generic.IList<string> NetworkInterfaceIds { get; }
    }
}