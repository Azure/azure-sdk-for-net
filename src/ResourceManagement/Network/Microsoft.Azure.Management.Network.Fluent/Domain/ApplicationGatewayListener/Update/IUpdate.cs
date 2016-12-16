// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayListener.Update
{
    using Microsoft.Azure.Management.Network.Fluent.HasServerNameIndication.Update;
    using Microsoft.Azure.Management.Network.Fluent.HasSslCertificate.Update;
    using Microsoft.Azure.Management.Network.Fluent.HasHostName.Update;
    using Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Update;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ChildResourceActions;

    /// <summary>
    /// The stage of an application gateway frontend listener update allowing to require server name indication (SNI).
    /// </summary>
    public interface IWithServerNameIndication  :
        Microsoft.Azure.Management.Network.Fluent.HasServerNameIndication.Update.IWithServerNameIndication<Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayListener.Update.IUpdate>
    {
    }

    /// <summary>
    /// The stage of an application gateway frontend listener update allowing to specify the password for the private key of the imported SSL certificate.
    /// </summary>
    public interface IWithSslPassword  :
        Microsoft.Azure.Management.Network.Fluent.HasSslCertificate.Update.IWithSslPassword<Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayListener.Update.IUpdate>
    {
    }

    /// <summary>
    /// The stage of an application gateway frontend listener update allowing to specify the hostname of the website for which the
    /// traffic is received.
    /// </summary>
    public interface IWithHostName  :
        Microsoft.Azure.Management.Network.Fluent.HasHostName.Update.IWithHostName<Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayListener.Update.IUpdate>
    {
    }

    /// <summary>
    /// The stage of an application gateway frontend listener update allowing to specify the SSL certificate to associate with the listener.
    /// </summary>
    public interface IWithSslCertificate  :
        Microsoft.Azure.Management.Network.Fluent.HasSslCertificate.Update.IWithSslCertificate<Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayListener.Update.IUpdate>
    {
    }

    /// <summary>
    /// The entirety of an application gateway HTTP listener update as part of an application gateway update.
    /// </summary>
    public interface IUpdate  :
        ISettable<Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Update.IUpdate>,
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayListener.Update.IWithServerNameIndication,
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayListener.Update.IWithHostName,
        IWithProtocol,
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayListener.Update.IWithSslCertificate,
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayListener.Update.IWithSslPassword,
        IWithFrontendPort,
        IWithFrontend
    {
    }

    /// <summary>
    /// The stage of an application gateway frontend listener update allowing to specify the frontend IP configuration to associate the listener with.
    /// </summary>
    public interface IWithFrontend 
    {
        /// <summary>
        /// Associates the listener with the application gateway's private (internal) frontend.
        /// If the private frontend does not exist yet, it will be created under an auto-generated name
        /// and associated with the application gateway's subnet.
        /// </summary>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayListener.Update.IUpdate WithPrivateFrontend();

        /// <summary>
        /// Associates the listener with the application gateway's public (Internet-facing) frontend.
        /// If the public frontend does not exist yet, it will be created under an auto-generated name
        /// and associated with the application gateway's public IP address.
        /// </summary>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayListener.Update.IUpdate WithPublicFrontend();
    }

    /// <summary>
    /// The stage of an application gateway frontend listener update allowing to specify the protocol.
    /// </summary>
    public interface IWithProtocol 
    {
        /// <summary>
        /// Specifies that the listener is for the HTTP protocol.
        /// </summary>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayListener.Update.IUpdate WithHttp();

        /// <summary>
        /// Specifies that the listener is for the HTTPS protocol.
        /// </summary>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayListener.Update.IWithSslCertificate WithHttps();
    }

    /// <summary>
    /// The stage of an application gateway frontend listener update allowing to specify the frontend port to associate the listener with.
    /// </summary>
    public interface IWithFrontendPort 
    {
        /// <summary>
        /// Enables the listener to listen on the specified existing frontend port.
        /// </summary>
        /// <param name="name">The name of an existing frontend port.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayListener.Update.IUpdate WithFrontendPort(string name);

        /// <summary>
        /// Enables the listener to listen on the specified frontend port number.
        /// If a frontend port for this port number does not yet exist, a new will be created with an auto-generated name.
        /// </summary>
        /// <param name="portNumber">A port number.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayListener.Update.IUpdate WithFrontendPort(int portNumber);
    }
}