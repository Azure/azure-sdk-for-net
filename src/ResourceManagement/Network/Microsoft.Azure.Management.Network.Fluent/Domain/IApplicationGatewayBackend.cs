// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;

    /// <summary>
    /// An immutable client-side representation of an application gateway backend.
    /// </summary>
    /// <remarks>
    /// (Beta: This functionality is in preview and as such is subject to change in non-backwards compatible ways in
    /// future releases, including removal, regardless of any compatibility expectations set by the containing library
    /// version number.).
    /// </remarks>
    public interface IApplicationGatewayBackend  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Models.ApplicationGatewayBackendAddressPoolInner>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IChildResource<Microsoft.Azure.Management.Network.Fluent.IApplicationGateway>,
        Microsoft.Azure.Management.Network.Fluent.IHasBackendNics
    {
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
        bool ContainsIPAddress(string ipAddress);

        /// <summary>
        /// Gets addresses on the backend of the application gateway, indexed by their FQDN.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<Models.ApplicationGatewayBackendAddress> Addresses { get; }
    }
}