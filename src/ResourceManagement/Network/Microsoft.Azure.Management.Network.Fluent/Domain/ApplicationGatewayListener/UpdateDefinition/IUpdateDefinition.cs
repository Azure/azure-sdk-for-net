// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayListener.UpdateDefinition
{
    using Microsoft.Azure.Management.Network.Fluent.HasSslCertificate.UpdateDefinition;
    using Microsoft.Azure.Management.Network.Fluent.HasHostName.UpdateDefinition;
    using Microsoft.Azure.Management.Network.Fluent.HasServerNameIndication.UpdateDefinition;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ChildResource.Update;

    /// <summary>
    /// The stage of an application gateway frontend listener definition allowing to specify the password for the private key of the imported SSL certificate.
    /// </summary>
    /// <typeparam name="Parent">The stage of the parent application gateway definition to return to after attaching this definition.</typeparam>
    public interface IWithSslPassword<ParentT>  :
        Microsoft.Azure.Management.Network.Fluent.HasSslCertificate.UpdateDefinition.IWithSslPassword<Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayListener.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Update.IUpdate>>
    {
    }

    /// <summary>
    /// The stage of an application gateway frontend listener definition allowing to specify the hostname of the website for which the
    /// traffic is received.
    /// </summary>
    /// <typeparam name="Parent">The stage of the parent application gateway definition to return to after attaching this definition.</typeparam>
    public interface IWithHostName<ParentT>  :
        Microsoft.Azure.Management.Network.Fluent.HasHostName.UpdateDefinition.IWithHostName<Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayListener.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Update.IUpdate>>
    {
    }

    /// <summary>
    /// The stage of an application gateway frontend listener definition allowing to specify the protocol.
    /// </summary>
    /// <typeparam name="Parent">The stage of the parent application gateway definition to return to after attaching this definition.</typeparam>
    public interface IWithProtocol<ParentT> 
    {
        /// <summary>
        /// Specifies that the listener is for the HTTP protocol.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayListener.UpdateDefinition.IWithAttach<ParentT> WithHttp();

        /// <summary>
        /// Specifies that the listener is for the HTTPS protocol.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayListener.UpdateDefinition.IWithSslCertificate<ParentT> WithHttps();
    }

    /// <summary>
    /// The first stage of an application gateway HTTP listener configuration definition.
    /// </summary>
    /// <typeparam name="Parent">The stage of the parent application gateway definition to return to after attaching this definition.</typeparam>
    public interface IBlank<ParentT>  :
        IWithFrontend<ParentT>
    {
    }

    /// <summary>
    /// The entirety of an application gateway HTTP listener definition as part of an application gateway update.
    /// </summary>
    /// <typeparam name="Parent">The stage of the parent application gateway definition to return to after attaching this definition.</typeparam>
    public interface IUpdateDefinition<ParentT>  :
        IBlank<ParentT>,
        IWithFrontend<ParentT>,
        IWithFrontendPort<ParentT>,
        IWithAttach<ParentT>,
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayListener.UpdateDefinition.IWithSslCertificate<ParentT>,
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayListener.UpdateDefinition.IWithSslPassword<ParentT>
    {
    }

    /// <summary>
    /// The stage of an application gateway frontend listener definition allowing to require server name indication (SNI).
    /// </summary>
    /// <typeparam name="Parent">The stage of the parent application gateway definition to return to after attaching this definition.</typeparam>
    public interface IWithServerNameIndication<ParentT>  :
        Microsoft.Azure.Management.Network.Fluent.HasServerNameIndication.UpdateDefinition.IWithServerNameIndication<Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayListener.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Update.IUpdate>>
    {
    }

    /// <summary>
    /// The stage of an application gateway frontend listener definition allowing to specify the SSL certificate to associate with the listener.
    /// </summary>
    /// <typeparam name="Parent">The stage of the parent application gateway definition to return to after attaching this definition.</typeparam>
    public interface IWithSslCertificate<ParentT>  :
        Microsoft.Azure.Management.Network.Fluent.HasSslCertificate.UpdateDefinition.IWithSslCertificate<Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayListener.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Update.IUpdate>>
    {
    }

    /// <summary>
    /// The stage of an application gateway frontend listener definition allowing to specify the frontend port to associate the listener with.
    /// </summary>
    /// <typeparam name="Parent">The stage of the parent application gateway definition to return to after attaching this definition.</typeparam>
    public interface IWithFrontendPort<ParentT> 
    {
        /// <summary>
        /// Enables the listener to listen on the specified existing frontend port.
        /// </summary>
        /// <param name="name">The name of an existing frontend port.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayListener.UpdateDefinition.IWithAttach<ParentT> WithFrontendPort(string name);

        /// <summary>
        /// Enables the listener to listen on the specified frontend port number.
        /// If a frontend port for this port number does not yet exist, a new will be created with an auto-generated name.
        /// </summary>
        /// <param name="portNumber">A port number.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayListener.UpdateDefinition.IWithAttach<ParentT> WithFrontendPort(int portNumber);
    }

    /// <summary>
    /// The final stage of an application gateway HTTP listener definition.
    /// At this stage, any remaining optional settings can be specified, or the definition
    /// can be attached to the parent application gateway definition using WithAttach.attach().
    /// </summary>
    /// <typeparam name="Parent">The stage of the parent application gateway definition to return to after attaching this definition.</typeparam>
    public interface IWithAttach<ParentT>  :
        IInUpdate<ParentT>,
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayListener.UpdateDefinition.IWithServerNameIndication<ParentT>,
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayListener.UpdateDefinition.IWithHostName<ParentT>,
        IWithProtocol<ParentT>
    {
    }

    /// <summary>
    /// The stage of an application gateway frontend listener definition allowing to specify the frontend IP configuration to associate the listener with.
    /// </summary>
    /// <typeparam name="Parent">The stage of the parent application gateway definition to return to after attaching this definition.</typeparam>
    public interface IWithFrontend<ParentT> 
    {
        /// <summary>
        /// Associates the listener with the application gateway's private (internal) frontend.
        /// If the private frontend does not exist yet, it will be created under an auto-generated name
        /// and associated with the application gateway's subnet.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayListener.UpdateDefinition.IWithFrontendPort<ParentT> WithPrivateFrontend();

        /// <summary>
        /// Associates the listener with the application gateway's public (Internet-facing) frontend.
        /// If the public frontend does not exist yet, it will be created under an auto-generated name
        /// and associated with the application gateway's public IP address.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayListener.UpdateDefinition.IWithFrontendPort<ParentT> WithPublicFrontend();
    }
}