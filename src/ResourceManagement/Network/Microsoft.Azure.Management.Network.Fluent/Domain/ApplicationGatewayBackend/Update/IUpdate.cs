// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackend.Update
{
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Update;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ChildResourceActions;

    /// <summary>
    /// The stage of an application gateway backend update allowing to add an address to the backend.
    /// </summary>
    public interface IWithAddress 
    {
        /// <summary>
        /// Adds the specified existing IP address to the backend.
        /// </summary>
        /// <param name="ipAddress">An IP address.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackend.Update.IUpdate WithIpAddress(string ipAddress);

        /// <summary>
        /// Ensures the specified IP address is not associated with this backend.
        /// </summary>
        /// <param name="ipAddress">An IP address.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackend.Update.IUpdate WithoutIpAddress(string ipAddress);

        /// <summary>
        /// Ensures the specified fully qualified domain name (FQDN) is not associated with this backend.
        /// </summary>
        /// <param name="fqdn">A fully qualified domain name.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackend.Update.IUpdate WithoutFqdn(string fqdn);

        /// <summary>
        /// Ensure the specified address is not associated with this backend.
        /// </summary>
        /// <param name="address">An existing address currently associated with the backend.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackend.Update.IUpdate WithoutAddress(ApplicationGatewayBackendAddress address);

        /// <summary>
        /// Adds the specified existing fully qualified domain name (FQDN) to the backend.
        /// </summary>
        /// <param name="fqdn">A fully qualified domain name (FQDN).</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackend.Update.IUpdate WithFqdn(string fqdn);
    }

    /// <summary>
    /// The entirety of an application gateway backend update as part of an application gateway update.
    /// </summary>
    public interface IUpdate  :
        ISettable<Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Update.IUpdate>,
        IWithAddress
    {
    }
}