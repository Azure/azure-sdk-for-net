// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// An immutable client-side representation of an application gateway frontend.
    /// </summary>
    /// <remarks>
    /// (Beta: This functionality is in preview and as such is subject to change in non-backwards compatible ways in
    /// future releases, including removal, regardless of any compatibility expectations set by the containing library
    /// version number.).
    /// </remarks>
    public interface IApplicationGatewayFrontend  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Models.ApplicationGatewayFrontendIPConfigurationInner>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IChildResource<Microsoft.Azure.Management.Network.Fluent.IApplicationGateway>,
        Microsoft.Azure.Management.Network.Fluent.IHasPrivateIPAddress,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasSubnet,
        Microsoft.Azure.Management.Network.Fluent.IHasPublicIPAddress
    {
        /// <return>The associated subnet.</return>
        Microsoft.Azure.Management.Network.Fluent.ISubnet GetSubnet();

        /// <summary>
        /// Gets true is the frontend is accessible via an private IP address.
        /// </summary>
        bool IsPrivate { get; }

        /// <summary>
        /// Gets true if the frontend is accessible via a public IP address, else false.
        /// </summary>
        bool IsPublic { get; }
    }
}