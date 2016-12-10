// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using ApplicationGateway.Definition;
    using ApplicationGateway.Update;
    using ApplicationGatewayListener.Definition;
    using ApplicationGatewayListener.Update;
    using ApplicationGatewayListener.UpdateDefinition;
    using Models;
    using HasHostName.Definition;
    using HasHostName.UpdateDefinition;
    using HasHostName.Update;
    using HasServerNameIndication.Definition;
    using HasServerNameIndication.UpdateDefinition;
    using HasServerNameIndication.Update;
    using HasSslCertificate.Definition;
    using HasSslCertificate.UpdateDefinition;
    using HasSslCertificate.Update;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ChildResource.Definition;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ChildResource.Update;
    using Java.Io;

    internal partial class ApplicationGatewayListenerImpl 
    {
        /// <summary>
        /// Gets the associated host name.
        /// </summary>
        string Microsoft.Azure.Management.Network.Fluent.IHasHostName.HostName
        {
            get
            {
                return this.HostName();
            }
        }

        /// <summary>
        /// Gets the name of the subnet associated with this resource.
        /// </summary>
        string Microsoft.Azure.Management.Resource.Fluent.Core.IHasSubnet.SubnetName
        {
            get
            {
                return this.SubnetName();
            }
        }

        /// <summary>
        /// Gets the resource ID of the virtual network whose subnet is associated with this resource.
        /// </summary>
        string Microsoft.Azure.Management.Resource.Fluent.Core.IHasSubnet.NetworkId
        {
            get
            {
                return this.NetworkId();
            }
        }

        /// <summary>
        /// Specifies that the listener is for the HTTP protocol.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayListener.Definition.IWithAttach<ApplicationGateway.Definition.IWithCreate> ApplicationGatewayListener.Definition.IWithProtocol<ApplicationGateway.Definition.IWithCreate>.WithHttp()
        {
            return this.WithHttp() as ApplicationGatewayListener.Definition.IWithAttach<ApplicationGateway.Definition.IWithCreate>;
        }

        /// <summary>
        /// Specifies that the listener is for the HTTPS protocol.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayListener.Definition.IWithSslCertificate<ApplicationGateway.Definition.IWithCreate> ApplicationGatewayListener.Definition.IWithProtocol<ApplicationGateway.Definition.IWithCreate>.WithHttps()
        {
            return this.WithHttps() as ApplicationGatewayListener.Definition.IWithSslCertificate<ApplicationGateway.Definition.IWithCreate>;
        }

        /// <summary>
        /// Specifies that the listener is for the HTTP protocol.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayListener.UpdateDefinition.IWithAttach<ApplicationGateway.Update.IUpdate> ApplicationGatewayListener.UpdateDefinition.IWithProtocol<ApplicationGateway.Update.IUpdate>.WithHttp()
        {
            return this.WithHttp() as ApplicationGatewayListener.UpdateDefinition.IWithAttach<ApplicationGateway.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies that the listener is for the HTTPS protocol.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayListener.UpdateDefinition.IWithSslCertificate<ApplicationGateway.Update.IUpdate> ApplicationGatewayListener.UpdateDefinition.IWithProtocol<ApplicationGateway.Update.IUpdate>.WithHttps()
        {
            return this.WithHttps() as ApplicationGatewayListener.UpdateDefinition.IWithSslCertificate<ApplicationGateway.Update.IUpdate>;
        }

        /// <summary>
        /// Associates the listener with the application gateway's private (internal) frontend.
        /// If the private frontend does not exist yet, it will be created under an auto-generated name
        /// and associated with the application gateway's subnet.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayListener.Definition.IWithFrontendPort<ApplicationGateway.Definition.IWithCreate> ApplicationGatewayListener.Definition.IWithFrontend<ApplicationGateway.Definition.IWithCreate>.WithPrivateFrontend()
        {
            return this.WithPrivateFrontend() as ApplicationGatewayListener.Definition.IWithFrontendPort<ApplicationGateway.Definition.IWithCreate>;
        }

        /// <summary>
        /// Associates the listener with the application gateway's public (Internet-facing) frontend.
        /// If the public frontend does not exist yet, it will be created under an auto-generated name
        /// and associated with the application gateway's public IP address.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayListener.Definition.IWithFrontendPort<ApplicationGateway.Definition.IWithCreate> ApplicationGatewayListener.Definition.IWithFrontend<ApplicationGateway.Definition.IWithCreate>.WithPublicFrontend()
        {
            return this.WithPublicFrontend() as ApplicationGatewayListener.Definition.IWithFrontendPort<ApplicationGateway.Definition.IWithCreate>;
        }

        /// <summary>
        /// Associates the listener with the application gateway's private (internal) frontend.
        /// If the private frontend does not exist yet, it will be created under an auto-generated name
        /// and associated with the application gateway's subnet.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayListener.UpdateDefinition.IWithFrontendPort<ApplicationGateway.Update.IUpdate> ApplicationGatewayListener.UpdateDefinition.IWithFrontend<ApplicationGateway.Update.IUpdate>.WithPrivateFrontend()
        {
            return this.WithPrivateFrontend() as ApplicationGatewayListener.UpdateDefinition.IWithFrontendPort<ApplicationGateway.Update.IUpdate>;
        }

        /// <summary>
        /// Associates the listener with the application gateway's public (Internet-facing) frontend.
        /// If the public frontend does not exist yet, it will be created under an auto-generated name
        /// and associated with the application gateway's public IP address.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayListener.UpdateDefinition.IWithFrontendPort<ApplicationGateway.Update.IUpdate> ApplicationGatewayListener.UpdateDefinition.IWithFrontend<ApplicationGateway.Update.IUpdate>.WithPublicFrontend()
        {
            return this.WithPublicFrontend() as ApplicationGatewayListener.UpdateDefinition.IWithFrontendPort<ApplicationGateway.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies the host name.
        /// </summary>
        /// <param name="hostName">An existing host name.</param>
        /// <return>The next stage of the update.</return>
        ApplicationGatewayListener.Update.IUpdate HasHostName.Update.IWithHostName<ApplicationGatewayListener.Update.IUpdate>.WithHostName(string hostName)
        {
            return this.WithHostName(hostName) as ApplicationGatewayListener.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the hostname to reference.
        /// </summary>
        /// <param name="hostName">An existing frontend name on this load balancer.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayListener.Definition.IWithAttach<ApplicationGateway.Definition.IWithCreate> HasHostName.Definition.IWithHostName<ApplicationGatewayListener.Definition.IWithAttach<ApplicationGateway.Definition.IWithCreate>>.WithHostName(string hostName)
        {
            return this.WithHostName(hostName) as ApplicationGatewayListener.Definition.IWithAttach<ApplicationGateway.Definition.IWithCreate>;
        }

        /// <summary>
        /// Specifies the host name to reference.
        /// </summary>
        /// <param name="hostName">An existing host name.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayListener.UpdateDefinition.IWithAttach<ApplicationGateway.Update.IUpdate> HasHostName.UpdateDefinition.IWithHostName<ApplicationGatewayListener.UpdateDefinition.IWithAttach<ApplicationGateway.Update.IUpdate>>.WithHostName(string hostName)
        {
            return this.WithHostName(hostName) as ApplicationGatewayListener.UpdateDefinition.IWithAttach<ApplicationGateway.Update.IUpdate>;
        }

        /// <summary>
        /// Gets true if server name indication (SNI) is required, else false.
        /// </summary>
        bool Microsoft.Azure.Management.Network.Fluent.IHasServerNameIndication.RequiresServerNameIndication
        {
            get
            {
                return this.RequiresServerNameIndication();
            }
        }

        /// <summary>
        /// Attaches the child definition to the parent resource update.
        /// </summary>
        /// <return>The next stage of the parent definition.</return>
        ApplicationGateway.Update.IUpdate Microsoft.Azure.Management.Resource.Fluent.Core.ChildResource.Update.IInUpdate<ApplicationGateway.Update.IUpdate>.Attach()
        {
            return this.Attach() as ApplicationGateway.Update.IUpdate;
        }

        /// <summary>
        /// Attaches the child definition to the parent resource definiton.
        /// </summary>
        /// <return>The next stage of the parent definition.</return>
        ApplicationGateway.Definition.IWithCreate Microsoft.Azure.Management.Resource.Fluent.Core.ChildResource.Definition.IInDefinition<ApplicationGateway.Definition.IWithCreate>.Attach()
        {
            return this.Attach() as ApplicationGateway.Definition.IWithCreate;
        }

        /// <summary>
        /// Enables the listener to listen on the specified existing frontend port.
        /// </summary>
        /// <param name="name">The name of an existing frontend port.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayListener.Update.IUpdate ApplicationGatewayListener.Update.IWithFrontendPort.WithFrontendPort(string name)
        {
            return this.WithFrontendPort(name) as ApplicationGatewayListener.Update.IUpdate;
        }

        /// <summary>
        /// Enables the listener to listen on the specified frontend port number.
        /// If a frontend port for this port number does not yet exist, a new will be created with an auto-generated name.
        /// </summary>
        /// <param name="portNumber">A port number.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayListener.Update.IUpdate ApplicationGatewayListener.Update.IWithFrontendPort.WithFrontendPort(int portNumber)
        {
            return this.WithFrontendPort(portNumber) as ApplicationGatewayListener.Update.IUpdate;
        }

        /// <summary>
        /// Ensures server name indication (SNI) is not required.
        /// </summary>
        /// <return>The next stage of the update.</return>
        ApplicationGatewayListener.Update.IUpdate HasServerNameIndication.Update.IWithServerNameIndication<ApplicationGatewayListener.Update.IUpdate>.WithoutServerNameIndication()
        {
            return this.WithoutServerNameIndication() as ApplicationGatewayListener.Update.IUpdate;
        }

        /// <summary>
        /// Requires server name indication (SNI).
        /// </summary>
        /// <return>The next stage of the update.</return>
        ApplicationGatewayListener.Update.IUpdate HasServerNameIndication.Update.IWithServerNameIndication<ApplicationGatewayListener.Update.IUpdate>.WithServerNameIndication()
        {
            return this.WithServerNameIndication() as ApplicationGatewayListener.Update.IUpdate;
        }

        /// <summary>
        /// Ensures server name indication (SNI) is not required.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayListener.Definition.IWithAttach<ApplicationGateway.Definition.IWithCreate> HasServerNameIndication.Definition.IWithServerNameIndication<ApplicationGatewayListener.Definition.IWithAttach<ApplicationGateway.Definition.IWithCreate>>.WithoutServerNameIndication()
        {
            return this.WithoutServerNameIndication() as ApplicationGatewayListener.Definition.IWithAttach<ApplicationGateway.Definition.IWithCreate>;
        }

        /// <summary>
        /// Requires server name indication (SNI).
        /// </summary>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayListener.Definition.IWithAttach<ApplicationGateway.Definition.IWithCreate> HasServerNameIndication.Definition.IWithServerNameIndication<ApplicationGatewayListener.Definition.IWithAttach<ApplicationGateway.Definition.IWithCreate>>.WithServerNameIndication()
        {
            return this.WithServerNameIndication() as ApplicationGatewayListener.Definition.IWithAttach<ApplicationGateway.Definition.IWithCreate>;
        }

        /// <summary>
        /// Ensures server name indication (SNI) is not required.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayListener.UpdateDefinition.IWithAttach<ApplicationGateway.Update.IUpdate> HasServerNameIndication.UpdateDefinition.IWithServerNameIndication<ApplicationGatewayListener.UpdateDefinition.IWithAttach<ApplicationGateway.Update.IUpdate>>.WithoutServerNameIndication()
        {
            return this.WithoutServerNameIndication() as ApplicationGatewayListener.UpdateDefinition.IWithAttach<ApplicationGateway.Update.IUpdate>;
        }

        /// <summary>
        /// Requires server name indication (SNI).
        /// </summary>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayListener.UpdateDefinition.IWithAttach<ApplicationGateway.Update.IUpdate> HasServerNameIndication.UpdateDefinition.IWithServerNameIndication<ApplicationGatewayListener.UpdateDefinition.IWithAttach<ApplicationGateway.Update.IUpdate>>.WithServerNameIndication()
        {
            return this.WithServerNameIndication() as ApplicationGatewayListener.UpdateDefinition.IWithAttach<ApplicationGateway.Update.IUpdate>;
        }

        /// <summary>
        /// Gets the resource ID of the associated public IP address.
        /// </summary>
        string Microsoft.Azure.Management.Network.Fluent.IHasPublicIpAddress.PublicIpAddressId
        {
            get
            {
                return this.PublicIpAddressId();
            }
        }

        /// <return>The associated public IP address.</return>
        Microsoft.Azure.Management.Network.Fluent.IPublicIpAddress Microsoft.Azure.Management.Network.Fluent.IHasPublicIpAddress.GetPublicIpAddress()
        {
            return this.GetPublicIpAddress() as Microsoft.Azure.Management.Network.Fluent.IPublicIpAddress;
        }

        /// <summary>
        /// Gets the associated SSL certificate, if any.
        /// </summary>
        Microsoft.Azure.Management.Network.Fluent.IApplicationGatewaySslCertificate Microsoft.Azure.Management.Network.Fluent.IHasSslCertificate<Microsoft.Azure.Management.Network.Fluent.IApplicationGatewaySslCertificate>.SslCertificate
        {
            get
            {
                return this.SslCertificate() as Microsoft.Azure.Management.Network.Fluent.IApplicationGatewaySslCertificate;
            }
        }

        /// <summary>
        /// Associates the listener with the application gateway's private (internal) frontend.
        /// If the private frontend does not exist yet, it will be created under an auto-generated name
        /// and associated with the application gateway's subnet.
        /// </summary>
        /// <return>The next stage of the update.</return>
        ApplicationGatewayListener.Update.IUpdate ApplicationGatewayListener.Update.IWithFrontend.WithPrivateFrontend()
        {
            return this.WithPrivateFrontend() as ApplicationGatewayListener.Update.IUpdate;
        }

        /// <summary>
        /// Associates the listener with the application gateway's public (Internet-facing) frontend.
        /// If the public frontend does not exist yet, it will be created under an auto-generated name
        /// and associated with the application gateway's public IP address.
        /// </summary>
        /// <return>The next stage of the update.</return>
        ApplicationGatewayListener.Update.IUpdate ApplicationGatewayListener.Update.IWithFrontend.WithPublicFrontend()
        {
            return this.WithPublicFrontend() as ApplicationGatewayListener.Update.IUpdate;
        }

        /// <summary>
        /// Specifies that the listener is for the HTTP protocol.
        /// </summary>
        /// <return>The next stage of the update.</return>
        ApplicationGatewayListener.Update.IUpdate ApplicationGatewayListener.Update.IWithProtocol.WithHttp()
        {
            return this.WithHttp() as ApplicationGatewayListener.Update.IUpdate;
        }

        /// <summary>
        /// Specifies that the listener is for the HTTPS protocol.
        /// </summary>
        /// <return>The next stage of the update.</return>
        ApplicationGatewayListener.Update.IWithSslCertificate ApplicationGatewayListener.Update.IWithProtocol.WithHttps()
        {
            return this.WithHttps() as ApplicationGatewayListener.Update.IWithSslCertificate;
        }

        /// <summary>
        /// Gets the frontend IP configuration this listener is associated with.
        /// </summary>
        Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayFrontend Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayListener.Frontend
        {
            get
            {
                return this.Frontend() as Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayFrontend;
            }
        }

        /// <summary>
        /// Gets the name of the frontend port the listener is listening on.
        /// </summary>
        string Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayListener.FrontendPortName
        {
            get
            {
                return this.FrontendPortName();
            }
        }

        /// <summary>
        /// Gets the number of the frontend port the listener is listening on.
        /// </summary>
        int Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayListener.FrontendPortNumber
        {
            get
            {
                return this.FrontendPortNumber();
            }
        }

        /// <summary>
        /// Gets the name of the resource.
        /// </summary>
        string Microsoft.Azure.Management.Resource.Fluent.Core.IHasName.Name
        {
            get
            {
                return this.Name();
            }
        }

        /// <summary>
        /// Specifies the PFX file to import the SSL certificate from to associate with this resource.
        /// The certificate will be named using an auto-generated name.
        /// </summary>
        /// <param name="pfxFile">An existing PFX file.</param>
        /// <return>The next stage of the definition.</return>
        HasSslCertificate.Update.IWithSslPassword<ApplicationGatewayListener.Update.IUpdate> HasSslCertificate.Update.IWithSslCertificate<ApplicationGatewayListener.Update.IUpdate>.WithSslCertificateFromPfxFile(File pfxFile)
        {
            return this.WithSslCertificateFromPfxFile(pfxFile) as HasSslCertificate.Update.IWithSslPassword<ApplicationGatewayListener.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies an SSL certificate to associate with this resource.
        /// If the certificate does not exist yet, it must be defined in the parent resource update.
        /// </summary>
        /// <param name="name">The name of an existing SSL certificate associated with this application gateway.</param>
        /// <return>The next stage of the update.</return>
        ApplicationGatewayListener.Update.IUpdate HasSslCertificate.Update.IWithSslCertificate<ApplicationGatewayListener.Update.IUpdate>.WithSslCertificate(string name)
        {
            return this.WithSslCertificate(name) as ApplicationGatewayListener.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the PFX file to import the SSL certificate from to associated with this resource.
        /// The certificate will be named using an auto-generated name.
        /// </summary>
        /// <param name="pfxFile">An existing PFX file.</param>
        /// <return>The next stage of the definition.</return>
        HasSslCertificate.Definition.IWithSslPassword<ApplicationGatewayListener.Definition.IWithAttach<ApplicationGateway.Definition.IWithCreate>> HasSslCertificate.Definition.IWithSslCertificate<ApplicationGatewayListener.Definition.IWithAttach<ApplicationGateway.Definition.IWithCreate>>.WithSslCertificateFromPfxFile(File pfxFile)
        {
            return this.WithSslCertificateFromPfxFile(pfxFile) as HasSslCertificate.Definition.IWithSslPassword<ApplicationGatewayListener.Definition.IWithAttach<ApplicationGateway.Definition.IWithCreate>>;
        }

        /// <summary>
        /// Specifies an SSL certificate to associate with this resource.
        /// If the certificate does not exist yet, it must be defined in the optional part of the parent resource definition.
        /// </summary>
        /// <param name="name">The name of an existing SSL certificate.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayListener.Definition.IWithAttach<ApplicationGateway.Definition.IWithCreate> HasSslCertificate.Definition.IWithSslCertificate<ApplicationGatewayListener.Definition.IWithAttach<ApplicationGateway.Definition.IWithCreate>>.WithSslCertificate(string name)
        {
            return this.WithSslCertificate(name) as ApplicationGatewayListener.Definition.IWithAttach<ApplicationGateway.Definition.IWithCreate>;
        }

        /// <summary>
        /// Specifies the PFX file to import the SSL certificate from to associated with this resource.
        /// The certificate will be named using an auto-generated name.
        /// </summary>
        /// <param name="pfxFile">An existing PFX file.</param>
        /// <return>The next stage of the definition.</return>
        HasSslCertificate.UpdateDefinition.IWithSslPassword<ApplicationGatewayListener.UpdateDefinition.IWithAttach<ApplicationGateway.Update.IUpdate>> HasSslCertificate.UpdateDefinition.IWithSslCertificate<ApplicationGatewayListener.UpdateDefinition.IWithAttach<ApplicationGateway.Update.IUpdate>>.WithSslCertificateFromPfxFile(File pfxFile)
        {
            return this.WithSslCertificateFromPfxFile(pfxFile) as HasSslCertificate.UpdateDefinition.IWithSslPassword<ApplicationGatewayListener.UpdateDefinition.IWithAttach<ApplicationGateway.Update.IUpdate>>;
        }

        /// <summary>
        /// Specifies an SSL certificate to associate with this resource.
        /// If the certificate does not exist yet, it must be defined in the optional part of the parent resource definition.
        /// </summary>
        /// <param name="name">The name of an existing SSL certificate.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayListener.UpdateDefinition.IWithAttach<ApplicationGateway.Update.IUpdate> HasSslCertificate.UpdateDefinition.IWithSslCertificate<ApplicationGatewayListener.UpdateDefinition.IWithAttach<ApplicationGateway.Update.IUpdate>>.WithSslCertificate(string name)
        {
            return this.WithSslCertificate(name) as ApplicationGatewayListener.UpdateDefinition.IWithAttach<ApplicationGateway.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies the password for the specified PFX file containing the private key of the imported SSL certificate.
        /// </summary>
        /// <param name="password">The password of the imported PFX file.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayListener.Update.IUpdate HasSslCertificate.Update.IWithSslPassword<ApplicationGatewayListener.Update.IUpdate>.WithSslCertificatePassword(string password)
        {
            return this.WithSslCertificatePassword(password) as ApplicationGatewayListener.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the password for the specified PFX file containing the private key of the imported SSL certificate.
        /// </summary>
        /// <param name="password">The password of the imported PFX file.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayListener.Definition.IWithAttach<ApplicationGateway.Definition.IWithCreate> HasSslCertificate.Definition.IWithSslPassword<ApplicationGatewayListener.Definition.IWithAttach<ApplicationGateway.Definition.IWithCreate>>.WithSslCertificatePassword(string password)
        {
            return this.WithSslCertificatePassword(password) as ApplicationGatewayListener.Definition.IWithAttach<ApplicationGateway.Definition.IWithCreate>;
        }

        /// <summary>
        /// Specifies the password for the specified PFX file containing the private key of the imported SSL certificate.
        /// </summary>
        /// <param name="password">The password of the imported PFX file.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayListener.UpdateDefinition.IWithAttach<ApplicationGateway.Update.IUpdate> HasSslCertificate.UpdateDefinition.IWithSslPassword<ApplicationGatewayListener.UpdateDefinition.IWithAttach<ApplicationGateway.Update.IUpdate>>.WithSslCertificatePassword(string password)
        {
            return this.WithSslCertificatePassword(password) as ApplicationGatewayListener.UpdateDefinition.IWithAttach<ApplicationGateway.Update.IUpdate>;
        }

        /// <summary>
        /// Gets the protocol.
        /// </summary>
        Models.ApplicationGatewayProtocol Microsoft.Azure.Management.Network.Fluent.IHasProtocol<Models.ApplicationGatewayProtocol>.Protocol
        {
            get
            {
                return this.Protocol() as Models.ApplicationGatewayProtocol;
            }
        }

        /// <summary>
        /// Enables the listener to listen on the specified existing frontend port.
        /// </summary>
        /// <param name="name">The name of an existing frontend port.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayListener.Definition.IWithAttach<ApplicationGateway.Definition.IWithCreate> ApplicationGatewayListener.Definition.IWithFrontendPort<ApplicationGateway.Definition.IWithCreate>.WithFrontendPort(string name)
        {
            return this.WithFrontendPort(name) as ApplicationGatewayListener.Definition.IWithAttach<ApplicationGateway.Definition.IWithCreate>;
        }

        /// <summary>
        /// Enables the listener to listen on the specified frontend port number.
        /// If a frontend port for this port number does not yet exist, a new will be created with an auto-generated name.
        /// </summary>
        /// <param name="portNumber">A port number.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayListener.Definition.IWithAttach<ApplicationGateway.Definition.IWithCreate> ApplicationGatewayListener.Definition.IWithFrontendPort<ApplicationGateway.Definition.IWithCreate>.WithFrontendPort(int portNumber)
        {
            return this.WithFrontendPort(portNumber) as ApplicationGatewayListener.Definition.IWithAttach<ApplicationGateway.Definition.IWithCreate>;
        }

        /// <summary>
        /// Enables the listener to listen on the specified existing frontend port.
        /// </summary>
        /// <param name="name">The name of an existing frontend port.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayListener.UpdateDefinition.IWithAttach<ApplicationGateway.Update.IUpdate> ApplicationGatewayListener.UpdateDefinition.IWithFrontendPort<ApplicationGateway.Update.IUpdate>.WithFrontendPort(string name)
        {
            return this.WithFrontendPort(name) as ApplicationGatewayListener.UpdateDefinition.IWithAttach<ApplicationGateway.Update.IUpdate>;
        }

        /// <summary>
        /// Enables the listener to listen on the specified frontend port number.
        /// If a frontend port for this port number does not yet exist, a new will be created with an auto-generated name.
        /// </summary>
        /// <param name="portNumber">A port number.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayListener.UpdateDefinition.IWithAttach<ApplicationGateway.Update.IUpdate> ApplicationGatewayListener.UpdateDefinition.IWithFrontendPort<ApplicationGateway.Update.IUpdate>.WithFrontendPort(int portNumber)
        {
            return this.WithFrontendPort(portNumber) as ApplicationGatewayListener.UpdateDefinition.IWithAttach<ApplicationGateway.Update.IUpdate>;
        }
    }
}