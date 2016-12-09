// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayListener.Definition
{
    using Microsoft.Azure.Management.Network.Fluent.HasSslCertificate.Definition;
    using Microsoft.Azure.Management.Network.Fluent.HasHostName.Definition;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ChildResource.Definition;
    using Microsoft.Azure.Management.Network.Fluent.HasServerNameIndication.Definition;

    /// <summary>
    /// The stage of an application gateway frontend listener definition allowing to specify the password for the private key of the imported SSL certificate.
    /// </summary>
    public interface IWithSslPassword<ParentT>  :
        Microsoft.Azure.Management.Network.Fluent.HasSslCertificate.Definition.IWithSslPassword<Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayListener.Definition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Definition.IWithCreate>>
    {
    }

    /// <summary>
    /// The stage of an application gateway frontend listener definition allowing to specify the hostname of the website for which the
    /// traffic is received.
    /// </summary>
    public interface IWithHostName<ParentT>  :
        Microsoft.Azure.Management.Network.Fluent.HasHostName.Definition.IWithHostName<Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayListener.Definition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Definition.IWithCreate>>
    {
    }

    /// <summary>
    /// The stage of an application gateway frontend listener definition allowing to specify the frontend IP configuration to associate the listener with.
    /// </summary>
    public interface IWithFrontend<ParentT> 
    {
        /// <summary>
        /// Associates the listener with the application gateway's private (internal) frontend.
        /// <p>
        /// If the private frontend does not exist yet, it will be created under an auto-generated name
        /// and associated with the application gateway's subnet.
        /// </summary>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayListener.Definition.IWithFrontendPort<ParentT> WithPrivateFrontend();

        /// <summary>
        /// Associates the listener with the application gateway's public (Internet-facing) frontend.
        /// <p>
        /// If the public frontend does not exist yet, it will be created under an auto-generated name
        /// and associated with the application gateway's public IP address.
        /// </summary>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayListener.Definition.IWithFrontendPort<ParentT> WithPublicFrontend();
    }

    /// <summary>
    /// The stage of an application gateway frontend listener definition allowing to specify the protocol.
    /// </summary>
    public interface IWithProtocol<ParentT> 
    {
        /// <summary>
        /// Specifies that the listener is for the HTTP protocol.
        /// </summary>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayListener.Definition.IWithAttach<ParentT> WithHttp();

        /// <summary>
        /// Specifies that the listener is for the HTTPS protocol.
        /// </summary>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayListener.Definition.IWithSslCertificate<ParentT> WithHttps();
    }

    /// <summary>
    /// The stage of an application gateway frontend listener definition allowing to specify the SSL certificate to associate with the listener.
    /// </summary>
    public interface IWithSslCertificate<ParentT>  :
        Microsoft.Azure.Management.Network.Fluent.HasSslCertificate.Definition.IWithSslCertificate<Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayListener.Definition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Definition.IWithCreate>>
    {
    }

    /// <summary>
    /// The final stage of an application gateway HTTP listener.
    /// <p>
    /// At this stage, any remaining optional settings can be specified, or the definition
    /// can be attached to the parent application gateway definition using WithAttach.attach().
    /// </summary>
    public interface IWithAttach<ParentT>  :
        IInDefinition<ParentT>,
        IWithProtocol<ParentT>,
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayListener.Definition.IWithHostName<ParentT>,
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayListener.Definition.IWithServerNameIndication<ParentT>
    {
    }

    /// <summary>
    /// The stage of an application gateway frontend listener definition allowing to specify the frontend port to associate the listener with.
    /// </summary>
    public interface IWithFrontendPort<ParentT> 
    {
        /// <summary>
        /// Enables the listener to listen on the specified existing frontend port.
        /// </summary>
        /// <param name="name">The name of an existing frontend port.</param>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayListener.Definition.IWithAttach<ParentT> WithFrontendPort(string name);

        /// <summary>
        /// Enables the listener to listen on the specified frontend port number.
        /// <p>If a frontend port for this port number does not yet exist, a new will be created with an auto-generated name.
        /// </summary>
        /// <param name="portNumber">A port number.</param>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayListener.Definition.IWithAttach<ParentT> WithFrontendPort(int portNumber);
    }

    /// <summary>
    /// The first stage of an application gateway HTTP listener.
    /// </summary>
    public interface IBlank<ParentT>  :
        IWithFrontend<ParentT>
    {
    }

    /// <summary>
    /// The stage of an application gateway frontend listener definition allowing to require server name indication (SNI).
    /// </summary>
    public interface IWithServerNameIndication<ParentT>  :
        Microsoft.Azure.Management.Network.Fluent.HasServerNameIndication.Definition.IWithServerNameIndication<Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayListener.Definition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Definition.IWithCreate>>
    {
    }

    /// <summary>
    /// The entirety of an application gateway HTTP listener definition.
    /// </summary>
    public interface IDefinition<ParentT>  :
        IBlank<ParentT>,
        IWithAttach<ParentT>,
        IWithFrontend<ParentT>,
        IWithFrontendPort<ParentT>,
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayListener.Definition.IWithSslCertificate<ParentT>,
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayListener.Definition.IWithSslPassword<ParentT>,
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayListener.Definition.IWithHostName<ParentT>
    {
    }
}