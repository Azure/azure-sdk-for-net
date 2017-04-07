// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// An immutable client-side representation of an application gateway's HTTP listener.
    /// </summary>
    /// <remarks>
    /// (Beta: This functionality is in preview and as such is subject to change in non-backwards compatible ways in
    /// future releases, including removal, regardless of any compatibility expectations set by the containing library
    /// version number.).
    /// </remarks>
    public interface IApplicationGatewayListener  :
        IHasInner<Models.ApplicationGatewayHttpListenerInner>,
        IChildResource<Microsoft.Azure.Management.Network.Fluent.IApplicationGateway>,
        IHasSslCertificate<Microsoft.Azure.Management.Network.Fluent.IApplicationGatewaySslCertificate>,
        IHasPublicIPAddress,
        IHasProtocol<Models.ApplicationGatewayProtocol>,
        IHasHostName,
        IHasServerNameIndication,
        IHasSubnet
    {
        /// <summary>
        /// Gets the number of the frontend port the listener is listening on.
        /// </summary>
        int FrontendPortNumber { get; }

        /// <summary>
        /// Gets the frontend IP configuration this listener is associated with.
        /// </summary>
        Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayFrontend Frontend { get; }

        /// <summary>
        /// Gets the name of the frontend port the listener is listening on.
        /// </summary>
        string FrontendPortName { get; }
    }
}