// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// An immutable client-side representation of an application gateway IP configuration.
    /// </summary>
    /// <remarks>
    /// (Beta: This functionality is in preview and as such is subject to change in non-backwards compatible ways in future releases, including removal, regardless of any compatibility expectations set by the containing library version number.)
    /// </remarks>
    public interface IApplicationGatewayIPConfiguration  :
        IHasInner<Models.ApplicationGatewayIPConfigurationInner>,
        IChildResource<Microsoft.Azure.Management.Network.Fluent.IApplicationGateway>
    {
        /// <return>
        /// The subnet the application gateway is in
        /// Note, this results in a separate call to Azure.
        /// </return>
        Microsoft.Azure.Management.Network.Fluent.ISubnet GetSubnet();

        /// <summary>
        /// Gets the resource ID of the virtual network the application gateway is in.
        /// </summary>
        string NetworkId { get; }

        /// <summary>
        /// Gets the name of the subnet the application gateway is in.
        /// </summary>
        string SubnetName { get; }
    }
}