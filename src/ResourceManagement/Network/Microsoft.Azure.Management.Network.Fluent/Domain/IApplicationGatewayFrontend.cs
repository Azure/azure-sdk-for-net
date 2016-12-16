// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using Models;
    using Microsoft.Azure.Management.Resource.Fluent.Core;

    /// <summary>
    /// An immutable client-side representation of an application gateway frontend.
    /// </summary>
    public interface IApplicationGatewayFrontend  :
        IWrapper<Models.ApplicationGatewayFrontendIPConfigurationInner>,
        IChildResource<Microsoft.Azure.Management.Network.Fluent.IApplicationGateway>,
        IHasPrivateIpAddress,
        IHasSubnet,
        IHasPublicIpAddress
    {
        /// <return>The associated subnet.</return>
        Microsoft.Azure.Management.Network.Fluent.ISubnet GetSubnet();

        /// <summary>
        /// Gets true if the frontend is accessible via a public IP address, else false.
        /// </summary>
        bool IsPublic { get; }

        /// <summary>
        /// Gets true is the frontend is accessible via an private IP address.
        /// </summary>
        bool IsPrivate { get; }
    }
}