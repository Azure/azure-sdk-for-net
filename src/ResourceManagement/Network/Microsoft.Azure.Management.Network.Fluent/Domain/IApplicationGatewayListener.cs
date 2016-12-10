// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using Models;
    using Microsoft.Azure.Management.Resource.Fluent.Core;

    /// <summary>
    /// An immutable client-side representation of an application gateway's HTTP listener.
    /// </summary>
    public interface IApplicationGatewayListener  :
        IWrapper<Models.ApplicationGatewayHttpListenerInner>,
        IChildResource<Microsoft.Azure.Management.Network.Fluent.IApplicationGateway>,
        IHasSslCertificate<Microsoft.Azure.Management.Network.Fluent.IApplicationGatewaySslCertificate>,
        IHasPublicIpAddress,
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