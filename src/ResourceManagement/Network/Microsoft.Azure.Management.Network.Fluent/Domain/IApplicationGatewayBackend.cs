// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using Models;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using System.Collections.Generic;

    /// <summary>
    /// An immutable client-side representation of an application gateway backend.
    /// </summary>
    public interface IApplicationGatewayBackend  :
        IWrapper<Models.ApplicationGatewayBackendAddressPoolInner>,
        IChildResource<Microsoft.Azure.Management.Network.Fluent.IApplicationGateway>,
        IHasBackendNics
    {
        /// <summary>
        /// Gets addresses on the backend of the application gateway, indexed by their FQDN.
        /// </summary>
        System.Collections.Generic.IList<Models.ApplicationGatewayBackendAddress> Addresses { get; }

        /// <summary>
        /// Checks whether the specified FQDN is referenced by this backend address pool.
        /// </summary>
        /// <param name="fqdn">A fully qualified domain name (FQDN).</param>
        /// <return>True if the specified FQDN is referenced by this backend, else false.</return>
        bool ContainsFqdn(string fqdn);

        /// <summary>
        /// Checks whether the specified IP address is referenced by this backend address pool.
        /// </summary>
        /// <param name="ipAddress">An IP address.</param>
        /// <return>True if the specified IP address is referenced by this backend, else false.</return>
        bool ContainsIpAddress(string ipAddress);
    }
}