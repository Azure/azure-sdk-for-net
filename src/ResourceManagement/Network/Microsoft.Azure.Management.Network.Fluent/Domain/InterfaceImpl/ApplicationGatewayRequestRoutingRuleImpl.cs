// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using ApplicationGateway.Definition;
    using ApplicationGateway.Update;
    using Models;
    using ApplicationGatewayRequestRoutingRule.Definition;
    using ApplicationGatewayRequestRoutingRule.Update;
    using ApplicationGatewayRequestRoutingRule.UpdateDefinition;
    using HasCookieBasedAffinity.Definition;
    using HasCookieBasedAffinity.UpdateDefinition;
    using HasHostName.Definition;
    using HasHostName.UpdateDefinition;
    using HasServerNameIndication.Definition;
    using HasServerNameIndication.UpdateDefinition;
    using HasSslCertificate.Definition;
    using HasSslCertificate.UpdateDefinition;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ChildResource.Definition;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ChildResource.Update;
    using Java.Io;
    using System.Collections.Generic;

    internal partial class ApplicationGatewayRequestRoutingRuleImpl 
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
        /// Associates the request routing rule with an existing backend on this application gateway.
        /// </summary>
        /// <param name="name">The name of an existing backend.</param>
        /// <return>The next stage of the update.</return>
        ApplicationGatewayRequestRoutingRule.Update.IUpdate ApplicationGatewayRequestRoutingRule.Update.IWithBackend.ToBackend(string name)
        {
            return this.ToBackend(name) as ApplicationGatewayRequestRoutingRule.Update.IUpdate;
        }

        /// <summary>
        /// Associates the specified backend HTTP settings configuration with this request routing rule.
        /// </summary>
        /// <param name="name">The name of a backend HTTP settings configuration.</param>
        /// <return>The next stage of the update.</return>
        ApplicationGatewayRequestRoutingRule.Update.IUpdate ApplicationGatewayRequestRoutingRule.Update.IWithBackendHttpConfiguration.ToBackendHttpConfiguration(string name)
        {
            return this.ToBackendHttpConfiguration(name) as ApplicationGatewayRequestRoutingRule.Update.IUpdate;
        }

        /// <summary>
        /// Enables the rule to apply to the application gateway's public (Internet-facing) frontend.
        /// If the public frontend IP configuration does not yet exist, it will be created under an auto-generated name.
        /// If the application gateway does not have a public IP address specified for its public frontend, one will be created
        /// automatically, unless a specific public IP address is specified in the application gateway definition's optional settings using
        /// {.
        /// </summary>
        /// <code>WithExistingPublicIpAddress(...)} or {.</code>
        /// <code>WithNewPublicIpAddress(...)}.</code>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayRequestRoutingRule.UpdateDefinition.IWithFrontendPort<ApplicationGateway.Update.IUpdate> ApplicationGatewayRequestRoutingRule.UpdateDefinition.IWithFrontend<ApplicationGateway.Update.IUpdate>.FromPublicFrontend()
        {
            return this.FromPublicFrontend() as ApplicationGatewayRequestRoutingRule.UpdateDefinition.IWithFrontendPort<ApplicationGateway.Update.IUpdate>;
        }

        /// <summary>
        /// Enables the rule to apply to the application gateway's private (internal) frontend.
        /// If the private frontend IP configuration does not yet exist, it will be created under an auto-generated name.
        /// If the application gateway does not have a subnet specified for its private frontend, one will be created automatically,
        /// unless a specific subnet is specified in the application gateway definition's optional settings using
        /// {.
        /// </summary>
        /// <code>WithExistingSubnet(...)}.</code>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayRequestRoutingRule.UpdateDefinition.IWithFrontendPort<ApplicationGateway.Update.IUpdate> ApplicationGatewayRequestRoutingRule.UpdateDefinition.IWithFrontend<ApplicationGateway.Update.IUpdate>.FromPrivateFrontend()
        {
            return this.FromPrivateFrontend() as ApplicationGatewayRequestRoutingRule.UpdateDefinition.IWithFrontendPort<ApplicationGateway.Update.IUpdate>;
        }

        /// <summary>
        /// Enables the rule to apply to the application gateway's public (Internet-facing) frontend.
        /// If the public frontend IP configuration does not yet exist, it will be created under an auto-generated name.
        /// If the application gateway does not have a public IP address specified for its public frontend, one will be created
        /// automatically, unless a specific public IP address is specified in the application gateway definition's optional settings using
        /// {.
        /// </summary>
        /// <code>WithExistingPublicIpAddress(...)} or {.</code>
        /// <code>WithNewPublicIpAddress(...)}.</code>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayRequestRoutingRule.Definition.IWithFrontendPort<ApplicationGateway.Definition.IWithRequestRoutingRuleOrCreate> ApplicationGatewayRequestRoutingRule.Definition.IWithFrontend<ApplicationGateway.Definition.IWithRequestRoutingRuleOrCreate>.FromPublicFrontend()
        {
            return this.FromPublicFrontend() as ApplicationGatewayRequestRoutingRule.Definition.IWithFrontendPort<ApplicationGateway.Definition.IWithRequestRoutingRuleOrCreate>;
        }

        /// <summary>
        /// Enables the rule to apply to the application gateway's private (internal) frontend.
        /// If the private frontend IP configuration does not yet exist, it will be created under an auto-generated name.
        /// If the application gateway does not have a subnet specified for its private frontend, one will be created automatically,
        /// unless a specific subnet is specified in the application gateway definition's optional settings using
        /// {.
        /// </summary>
        /// <code>WithExistingSubnet(...)}.</code>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayRequestRoutingRule.Definition.IWithFrontendPort<ApplicationGateway.Definition.IWithRequestRoutingRuleOrCreate> ApplicationGatewayRequestRoutingRule.Definition.IWithFrontend<ApplicationGateway.Definition.IWithRequestRoutingRuleOrCreate>.FromPrivateFrontend()
        {
            return this.FromPrivateFrontend() as ApplicationGatewayRequestRoutingRule.Definition.IWithFrontendPort<ApplicationGateway.Definition.IWithRequestRoutingRuleOrCreate>;
        }

        /// <summary>
        /// Specifies the host name to reference.
        /// </summary>
        /// <param name="hostName">An existing host name.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayRequestRoutingRule.UpdateDefinition.IWithAttach<ApplicationGateway.Update.IUpdate> HasHostName.UpdateDefinition.IWithHostName<ApplicationGatewayRequestRoutingRule.UpdateDefinition.IWithAttach<ApplicationGateway.Update.IUpdate>>.WithHostName(string hostName)
        {
            return this.WithHostName(hostName) as ApplicationGatewayRequestRoutingRule.UpdateDefinition.IWithAttach<ApplicationGateway.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies the hostname to reference.
        /// </summary>
        /// <param name="hostName">An existing frontend name on this load balancer.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayRequestRoutingRule.Definition.IWithAttach<ApplicationGateway.Definition.IWithRequestRoutingRuleOrCreate> HasHostName.Definition.IWithHostName<ApplicationGatewayRequestRoutingRule.Definition.IWithAttach<ApplicationGateway.Definition.IWithRequestRoutingRuleOrCreate>>.WithHostName(string hostName)
        {
            return this.WithHostName(hostName) as ApplicationGatewayRequestRoutingRule.Definition.IWithAttach<ApplicationGateway.Definition.IWithRequestRoutingRuleOrCreate>;
        }

        /// <summary>
        /// Gets the backend port number the network traffic is sent to.
        /// </summary>
        bool Microsoft.Azure.Management.Network.Fluent.IHasCookieBasedAffinity.CookieBasedAffinity
        {
            get
            {
                return this.CookieBasedAffinity();
            }
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
        /// Disables cookie based affinity.
        /// </summary>
        /// <return>The next stage of the update.</return>
        ApplicationGatewayRequestRoutingRule.UpdateDefinition.IWithAttach<ApplicationGateway.Update.IUpdate> HasCookieBasedAffinity.UpdateDefinition.IWithCookieBasedAffinity<ApplicationGatewayRequestRoutingRule.UpdateDefinition.IWithAttach<ApplicationGateway.Update.IUpdate>>.WithoutCookieBasedAffinity()
        {
            return this.WithoutCookieBasedAffinity() as ApplicationGatewayRequestRoutingRule.UpdateDefinition.IWithAttach<ApplicationGateway.Update.IUpdate>;
        }

        /// <summary>
        /// Enables cookie based affinity.
        /// </summary>
        /// <return>The next stage of the update.</return>
        ApplicationGatewayRequestRoutingRule.UpdateDefinition.IWithAttach<ApplicationGateway.Update.IUpdate> HasCookieBasedAffinity.UpdateDefinition.IWithCookieBasedAffinity<ApplicationGatewayRequestRoutingRule.UpdateDefinition.IWithAttach<ApplicationGateway.Update.IUpdate>>.WithCookieBasedAffinity()
        {
            return this.WithCookieBasedAffinity() as ApplicationGatewayRequestRoutingRule.UpdateDefinition.IWithAttach<ApplicationGateway.Update.IUpdate>;
        }

        /// <summary>
        /// Disables cookie based affinity.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayRequestRoutingRule.Definition.IWithAttach<ApplicationGateway.Definition.IWithRequestRoutingRuleOrCreate> HasCookieBasedAffinity.Definition.IWithCookieBasedAffinity<ApplicationGatewayRequestRoutingRule.Definition.IWithAttach<ApplicationGateway.Definition.IWithRequestRoutingRuleOrCreate>>.WithoutCookieBasedAffinity()
        {
            return this.WithoutCookieBasedAffinity() as ApplicationGatewayRequestRoutingRule.Definition.IWithAttach<ApplicationGateway.Definition.IWithRequestRoutingRuleOrCreate>;
        }

        /// <summary>
        /// Enables cookie based affinity.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayRequestRoutingRule.Definition.IWithAttach<ApplicationGateway.Definition.IWithRequestRoutingRuleOrCreate> HasCookieBasedAffinity.Definition.IWithCookieBasedAffinity<ApplicationGatewayRequestRoutingRule.Definition.IWithAttach<ApplicationGateway.Definition.IWithRequestRoutingRuleOrCreate>>.WithCookieBasedAffinity()
        {
            return this.WithCookieBasedAffinity() as ApplicationGatewayRequestRoutingRule.Definition.IWithAttach<ApplicationGateway.Definition.IWithRequestRoutingRuleOrCreate>;
        }

        /// <summary>
        /// Associates the request routing rule with an existing frontend listener.
        /// Also, note that a given listener can be used by no more than one request routing rule at a time.
        /// </summary>
        /// <param name="name">The name of a listener to reference.</param>
        /// <return>The next stage of the update.</return>
        ApplicationGatewayRequestRoutingRule.Update.IUpdate ApplicationGatewayRequestRoutingRule.Update.IWithListener.FromListener(string name)
        {
            return this.FromListener(name) as ApplicationGatewayRequestRoutingRule.Update.IUpdate;
        }

        /// <summary>
        /// Adds an IP address to the backend associated with this rule.
        /// If no backend has been associated with this rule yet, a new one will be created with an auto-generated name.
        /// This call can be used in a sequence to add multiple IP addresses.
        /// </summary>
        /// <param name="ipAddress">An IP address.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayRequestRoutingRule.UpdateDefinition.IWithBackendAddressOrAttach<ApplicationGateway.Update.IUpdate> ApplicationGatewayRequestRoutingRule.UpdateDefinition.IWithBackendAddress<ApplicationGateway.Update.IUpdate>.ToBackendIpAddress(string ipAddress)
        {
            return this.ToBackendIpAddress(ipAddress) as ApplicationGatewayRequestRoutingRule.UpdateDefinition.IWithBackendAddressOrAttach<ApplicationGateway.Update.IUpdate>;
        }

        /// <summary>
        /// Adds an FQDN (fully qualified domain name) to the backend associated with this rule.
        /// If no backend has been associated with this rule yet, a new one will be created with an auto-generated name.
        /// This call can be used in a sequence to add multiple FQDNs.
        /// </summary>
        /// <param name="fqdn">A fully qualified domain name.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayRequestRoutingRule.UpdateDefinition.IWithBackendAddressOrAttach<ApplicationGateway.Update.IUpdate> ApplicationGatewayRequestRoutingRule.UpdateDefinition.IWithBackendAddress<ApplicationGateway.Update.IUpdate>.ToBackendFqdn(string fqdn)
        {
            return this.ToBackendFqdn(fqdn) as ApplicationGatewayRequestRoutingRule.UpdateDefinition.IWithBackendAddressOrAttach<ApplicationGateway.Update.IUpdate>;
        }

        /// <summary>
        /// Adds an IP address to the backend associated with this rule.
        /// If no backend has been associated with this rule yet, a new one will be created with an auto-generated name.
        /// This call can be used in a sequence to add multiple IP addresses.
        /// </summary>
        /// <param name="ipAddress">An IP address.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayRequestRoutingRule.Definition.IWithBackendAddressOrAttach<ApplicationGateway.Definition.IWithRequestRoutingRuleOrCreate> ApplicationGatewayRequestRoutingRule.Definition.IWithBackendAddress<ApplicationGateway.Definition.IWithRequestRoutingRuleOrCreate>.ToBackendIpAddress(string ipAddress)
        {
            return this.ToBackendIpAddress(ipAddress) as ApplicationGatewayRequestRoutingRule.Definition.IWithBackendAddressOrAttach<ApplicationGateway.Definition.IWithRequestRoutingRuleOrCreate>;
        }

        /// <summary>
        /// Adds an FQDN (fully qualified domain name) to the backend associated with this rule.
        /// If no backend has been associated with this rule yet, a new one will be created with an auto-generated name.
        /// This call can be used in a sequence to add multiple FQDNs.
        /// </summary>
        /// <param name="fqdn">A fully qualified domain name.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayRequestRoutingRule.Definition.IWithBackendAddressOrAttach<ApplicationGateway.Definition.IWithRequestRoutingRuleOrCreate> ApplicationGatewayRequestRoutingRule.Definition.IWithBackendAddress<ApplicationGateway.Definition.IWithRequestRoutingRuleOrCreate>.ToBackendFqdn(string fqdn)
        {
            return this.ToBackendFqdn(fqdn) as ApplicationGatewayRequestRoutingRule.Definition.IWithBackendAddressOrAttach<ApplicationGateway.Definition.IWithRequestRoutingRuleOrCreate>;
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
        ApplicationGateway.Definition.IWithRequestRoutingRuleOrCreate Microsoft.Azure.Management.Resource.Fluent.Core.ChildResource.Definition.IInDefinition<ApplicationGateway.Definition.IWithRequestRoutingRuleOrCreate>.Attach()
        {
            return this.Attach() as ApplicationGateway.Definition.IWithRequestRoutingRuleOrCreate;
        }

        /// <summary>
        /// Gets the frontend port number the inbound network traffic is received on.
        /// </summary>
        int Microsoft.Azure.Management.Network.Fluent.IHasFrontendPort.FrontendPort
        {
            get
            {
                return this.FrontendPort();
            }
        }

        /// <summary>
        /// Associates the request routing rule with a backend on this application gateway.
        /// If the backend does not yet exist, it must be defined in the optional part of the application gateway definition,
        /// using {.
        /// </summary>
        /// <code>DefineBackend(...)}. The request routing rule references it only by name.</code>
        /// <param name="name">The name of an existing backend.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayRequestRoutingRule.UpdateDefinition.IWithAttach<ApplicationGateway.Update.IUpdate> ApplicationGatewayRequestRoutingRule.UpdateDefinition.IWithBackend<ApplicationGateway.Update.IUpdate>.ToBackend(string name)
        {
            return this.ToBackend(name) as ApplicationGatewayRequestRoutingRule.UpdateDefinition.IWithAttach<ApplicationGateway.Update.IUpdate>;
        }

        /// <summary>
        /// Associates the request routing rule with a backend on this application gateway.
        /// If the backend does not yet exist, it must be defined in the optional part of the application gateway definition,
        /// using {.
        /// </summary>
        /// <code>DefineBackend(...)}. The request routing rule references it only by name.</code>
        /// <param name="name">The name of an existing backend.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayRequestRoutingRule.Definition.IWithAttach<ApplicationGateway.Definition.IWithRequestRoutingRuleOrCreate> ApplicationGatewayRequestRoutingRule.Definition.IWithBackend<ApplicationGateway.Definition.IWithRequestRoutingRuleOrCreate>.ToBackend(string name)
        {
            return this.ToBackend(name) as ApplicationGatewayRequestRoutingRule.Definition.IWithAttach<ApplicationGateway.Definition.IWithRequestRoutingRuleOrCreate>;
        }

        /// <summary>
        /// Gets the associated backend HTTP settings configuration.
        /// </summary>
        Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayBackendHttpConfiguration Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayRequestRoutingRule.BackendHttpConfiguration
        {
            get
            {
                return this.BackendHttpConfiguration() as Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayBackendHttpConfiguration;
            }
        }

        /// <summary>
        /// Gets rule type.
        /// </summary>
        Models.ApplicationGatewayRequestRoutingRuleType Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayRequestRoutingRule.RuleType
        {
            get
            {
                return this.RuleType() as Models.ApplicationGatewayRequestRoutingRuleType;
            }
        }

        /// <summary>
        /// Gets the associated backend address pool.
        /// </summary>
        Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayBackend Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayRequestRoutingRule.Backend
        {
            get
            {
                return this.Backend() as Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayBackend;
            }
        }

        /// <summary>
        /// Gets the addresses assigned to the associated backend.
        /// </summary>
        System.Collections.Generic.IList<Models.ApplicationGatewayBackendAddress> Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayRequestRoutingRule.BackendAddresses
        {
            get
            {
                return this.BackendAddresses() as System.Collections.Generic.IList<Models.ApplicationGatewayBackendAddress>;
            }
        }

        /// <summary>
        /// Gets the frontend protocol.
        /// </summary>
        Models.ApplicationGatewayProtocol Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayRequestRoutingRule.FrontendProtocol
        {
            get
            {
                return this.FrontendProtocol() as Models.ApplicationGatewayProtocol;
            }
        }

        /// <return>The associated frontend HTTP listener.</return>
        Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayListener Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayRequestRoutingRule.Listener()
        {
            return this.Listener() as Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayListener;
        }

        /// <summary>
        /// Ensures server name indication (SNI) is not required.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayRequestRoutingRule.UpdateDefinition.IWithBackendHttpConfiguration<ApplicationGateway.Update.IUpdate> HasServerNameIndication.UpdateDefinition.IWithServerNameIndication<ApplicationGatewayRequestRoutingRule.UpdateDefinition.IWithBackendHttpConfiguration<ApplicationGateway.Update.IUpdate>>.WithoutServerNameIndication()
        {
            return this.WithoutServerNameIndication() as ApplicationGatewayRequestRoutingRule.UpdateDefinition.IWithBackendHttpConfiguration<ApplicationGateway.Update.IUpdate>;
        }

        /// <summary>
        /// Requires server name indication (SNI).
        /// </summary>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayRequestRoutingRule.UpdateDefinition.IWithBackendHttpConfiguration<ApplicationGateway.Update.IUpdate> HasServerNameIndication.UpdateDefinition.IWithServerNameIndication<ApplicationGatewayRequestRoutingRule.UpdateDefinition.IWithBackendHttpConfiguration<ApplicationGateway.Update.IUpdate>>.WithServerNameIndication()
        {
            return this.WithServerNameIndication() as ApplicationGatewayRequestRoutingRule.UpdateDefinition.IWithBackendHttpConfiguration<ApplicationGateway.Update.IUpdate>;
        }

        /// <summary>
        /// Ensures server name indication (SNI) is not required.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayRequestRoutingRule.Definition.IWithBackendHttpConfiguration<ApplicationGateway.Definition.IWithRequestRoutingRuleOrCreate> HasServerNameIndication.Definition.IWithServerNameIndication<ApplicationGatewayRequestRoutingRule.Definition.IWithBackendHttpConfiguration<ApplicationGateway.Definition.IWithRequestRoutingRuleOrCreate>>.WithoutServerNameIndication()
        {
            return this.WithoutServerNameIndication() as ApplicationGatewayRequestRoutingRule.Definition.IWithBackendHttpConfiguration<ApplicationGateway.Definition.IWithRequestRoutingRuleOrCreate>;
        }

        /// <summary>
        /// Requires server name indication (SNI).
        /// </summary>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayRequestRoutingRule.Definition.IWithBackendHttpConfiguration<ApplicationGateway.Definition.IWithRequestRoutingRuleOrCreate> HasServerNameIndication.Definition.IWithServerNameIndication<ApplicationGatewayRequestRoutingRule.Definition.IWithBackendHttpConfiguration<ApplicationGateway.Definition.IWithRequestRoutingRuleOrCreate>>.WithServerNameIndication()
        {
            return this.WithServerNameIndication() as ApplicationGatewayRequestRoutingRule.Definition.IWithBackendHttpConfiguration<ApplicationGateway.Definition.IWithRequestRoutingRuleOrCreate>;
        }

        /// <return>The associated public IP address.</return>
        Microsoft.Azure.Management.Network.Fluent.IPublicIpAddress Microsoft.Azure.Management.Network.Fluent.IHasPublicIpAddress.GetPublicIpAddress()
        {
            return this.GetPublicIpAddress() as Microsoft.Azure.Management.Network.Fluent.IPublicIpAddress;
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
        /// Associates the request routing rule with a frontend listener.
        /// If the listener with the specified name does not yet exist, it must be defined separately in the optional part
        /// of the application gateway definition, using {.
        /// </summary>
        /// <code>
        /// DefineListener(...)}.
        /// This only adds a reference to the listener by its name.
        /// Also, note that a given listener can be used by no more than one request routing rule at a time.
        /// </code>
        /// <param name="name">The name of a listener to reference.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayRequestRoutingRule.UpdateDefinition.IWithBackendHttpConfiguration<ApplicationGateway.Update.IUpdate> ApplicationGatewayRequestRoutingRule.UpdateDefinition.IWithListener<ApplicationGateway.Update.IUpdate>.FromListener(string name)
        {
            return this.FromListener(name) as ApplicationGatewayRequestRoutingRule.UpdateDefinition.IWithBackendHttpConfiguration<ApplicationGateway.Update.IUpdate>;
        }

        /// <summary>
        /// Associates the request routing rule with a frontend listener.
        /// If the listener with the specified name does not yet exist, it must be defined separately in the optional part
        /// of the application gateway definition, using {.
        /// </summary>
        /// <code>
        /// DefineListener(...)}.
        /// This only adds a reference to the listener by its name.
        /// Also, note that a given listener can be used by no more than one request routing rule at a time.
        /// </code>
        /// <param name="name">The name of a listener to reference.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayRequestRoutingRule.Definition.IWithBackendHttpConfiguration<ApplicationGateway.Definition.IWithRequestRoutingRuleOrCreate> ApplicationGatewayRequestRoutingRule.Definition.IWithListener<ApplicationGateway.Definition.IWithRequestRoutingRuleOrCreate>.FromListener(string name)
        {
            return this.FromListener(name) as ApplicationGatewayRequestRoutingRule.Definition.IWithBackendHttpConfiguration<ApplicationGateway.Definition.IWithRequestRoutingRuleOrCreate>;
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
        /// Specifies the PFX file to import the SSL certificate from to associated with this resource.
        /// The certificate will be named using an auto-generated name.
        /// </summary>
        /// <param name="pfxFile">An existing PFX file.</param>
        /// <return>The next stage of the definition.</return>
        HasSslCertificate.UpdateDefinition.IWithSslPassword<ApplicationGatewayRequestRoutingRule.UpdateDefinition.IWithBackendHttpConfigurationOrSni<ApplicationGateway.Update.IUpdate>> HasSslCertificate.UpdateDefinition.IWithSslCertificate<ApplicationGatewayRequestRoutingRule.UpdateDefinition.IWithBackendHttpConfigurationOrSni<ApplicationGateway.Update.IUpdate>>.WithSslCertificateFromPfxFile(File pfxFile)
        {
            return this.WithSslCertificateFromPfxFile(pfxFile) as HasSslCertificate.UpdateDefinition.IWithSslPassword<ApplicationGatewayRequestRoutingRule.UpdateDefinition.IWithBackendHttpConfigurationOrSni<ApplicationGateway.Update.IUpdate>>;
        }

        /// <summary>
        /// Specifies an SSL certificate to associate with this resource.
        /// If the certificate does not exist yet, it must be defined in the optional part of the parent resource definition.
        /// </summary>
        /// <param name="name">The name of an existing SSL certificate.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayRequestRoutingRule.UpdateDefinition.IWithBackendHttpConfigurationOrSni<ApplicationGateway.Update.IUpdate> HasSslCertificate.UpdateDefinition.IWithSslCertificate<ApplicationGatewayRequestRoutingRule.UpdateDefinition.IWithBackendHttpConfigurationOrSni<ApplicationGateway.Update.IUpdate>>.WithSslCertificate(string name)
        {
            return this.WithSslCertificate(name) as ApplicationGatewayRequestRoutingRule.UpdateDefinition.IWithBackendHttpConfigurationOrSni<ApplicationGateway.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies the PFX file to import the SSL certificate from to associated with this resource.
        /// The certificate will be named using an auto-generated name.
        /// </summary>
        /// <param name="pfxFile">An existing PFX file.</param>
        /// <return>The next stage of the definition.</return>
        HasSslCertificate.Definition.IWithSslPassword<ApplicationGatewayRequestRoutingRule.Definition.IWithBackendHttpConfigurationOrSni<ApplicationGateway.Definition.IWithRequestRoutingRuleOrCreate>> HasSslCertificate.Definition.IWithSslCertificate<ApplicationGatewayRequestRoutingRule.Definition.IWithBackendHttpConfigurationOrSni<ApplicationGateway.Definition.IWithRequestRoutingRuleOrCreate>>.WithSslCertificateFromPfxFile(File pfxFile)
        {
            return this.WithSslCertificateFromPfxFile(pfxFile) as HasSslCertificate.Definition.IWithSslPassword<ApplicationGatewayRequestRoutingRule.Definition.IWithBackendHttpConfigurationOrSni<ApplicationGateway.Definition.IWithRequestRoutingRuleOrCreate>>;
        }

        /// <summary>
        /// Specifies an SSL certificate to associate with this resource.
        /// If the certificate does not exist yet, it must be defined in the optional part of the parent resource definition.
        /// </summary>
        /// <param name="name">The name of an existing SSL certificate.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayRequestRoutingRule.Definition.IWithBackendHttpConfigurationOrSni<ApplicationGateway.Definition.IWithRequestRoutingRuleOrCreate> HasSslCertificate.Definition.IWithSslCertificate<ApplicationGatewayRequestRoutingRule.Definition.IWithBackendHttpConfigurationOrSni<ApplicationGateway.Definition.IWithRequestRoutingRuleOrCreate>>.WithSslCertificate(string name)
        {
            return this.WithSslCertificate(name) as ApplicationGatewayRequestRoutingRule.Definition.IWithBackendHttpConfigurationOrSni<ApplicationGateway.Definition.IWithRequestRoutingRuleOrCreate>;
        }

        /// <summary>
        /// Associates the specified backend HTTP settings configuration with this request routing rule.
        /// If the backend configuration does not exist yet, it must be defined in the optional part of the application gateway
        /// definition, using {.
        /// </summary>
        /// <code>DefineBackendHttpConfiguration(...)}. The request routing rule references it only by name.</code>
        /// <param name="name">The name of a backend HTTP settings configuration.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayRequestRoutingRule.UpdateDefinition.IWithBackendOrAddress<ApplicationGateway.Update.IUpdate> ApplicationGatewayRequestRoutingRule.UpdateDefinition.IWithBackendHttpConfiguration<ApplicationGateway.Update.IUpdate>.ToBackendHttpConfiguration(string name)
        {
            return this.ToBackendHttpConfiguration(name) as ApplicationGatewayRequestRoutingRule.UpdateDefinition.IWithBackendOrAddress<ApplicationGateway.Update.IUpdate>;
        }

        /// <summary>
        /// Creates a backend HTTP settings configuration for the specified backend port and the HTTP protocol, and associates it with this
        /// request routing rule.
        /// An auto-generated name will be used for this newly created configuration.
        /// </summary>
        /// <param name="portNumber">The port number for a new backend HTTP settings configuration.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayRequestRoutingRule.UpdateDefinition.IWithBackendOrAddress<ApplicationGateway.Update.IUpdate> ApplicationGatewayRequestRoutingRule.UpdateDefinition.IWithBackendHttpConfiguration<ApplicationGateway.Update.IUpdate>.ToBackendHttpPort(int portNumber)
        {
            return this.ToBackendHttpPort(portNumber) as ApplicationGatewayRequestRoutingRule.UpdateDefinition.IWithBackendOrAddress<ApplicationGateway.Update.IUpdate>;
        }

        /// <summary>
        /// Associates the specified backend HTTP settings configuration with this request routing rule.
        /// If the backend configuration does not exist yet, it must be defined in the optional part of the application gateway
        /// definition, using {.
        /// </summary>
        /// <code>DefineBackendHttpConfiguration(...)}. The request routing rule references it only by name.</code>
        /// <param name="name">The name of a backend HTTP settings configuration.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayRequestRoutingRule.Definition.IWithBackendOrAddress<ApplicationGateway.Definition.IWithRequestRoutingRuleOrCreate> ApplicationGatewayRequestRoutingRule.Definition.IWithBackendHttpConfiguration<ApplicationGateway.Definition.IWithRequestRoutingRuleOrCreate>.ToBackendHttpConfiguration(string name)
        {
            return this.ToBackendHttpConfiguration(name) as ApplicationGatewayRequestRoutingRule.Definition.IWithBackendOrAddress<ApplicationGateway.Definition.IWithRequestRoutingRuleOrCreate>;
        }

        /// <summary>
        /// Creates a backend HTTP settings configuration for the specified backend port and the HTTP protocol, and associates it with this
        /// request routing rule.
        /// An auto-generated name will be used for this newly created configuration.
        /// </summary>
        /// <param name="portNumber">The port number for a new backend HTTP settings configuration.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayRequestRoutingRule.Definition.IWithBackendOrAddress<ApplicationGateway.Definition.IWithRequestRoutingRuleOrCreate> ApplicationGatewayRequestRoutingRule.Definition.IWithBackendHttpConfiguration<ApplicationGateway.Definition.IWithRequestRoutingRuleOrCreate>.ToBackendHttpPort(int portNumber)
        {
            return this.ToBackendHttpPort(portNumber) as ApplicationGatewayRequestRoutingRule.Definition.IWithBackendOrAddress<ApplicationGateway.Definition.IWithRequestRoutingRuleOrCreate>;
        }

        /// <summary>
        /// Specifies the password for the specified PFX file containing the private key of the imported SSL certificate.
        /// </summary>
        /// <param name="password">The password of the imported PFX file.</param>
        /// <return>The next stage of the definition.</return>
        ReturnT HasSslCertificate.UpdateDefinition.IWithSslPassword<ReturnT>.WithSslCertificatePassword(string password)
        {
            return this.WithSslCertificatePassword(password) as ReturnT;
        }

        /// <summary>
        /// Specifies the password for the specified PFX file containing the private key of the imported SSL certificate.
        /// </summary>
        /// <param name="password">The password of the imported PFX file.</param>
        /// <return>The next stage of the definition.</return>
        ReturnT HasSslCertificate.Definition.IWithSslPassword<ReturnT>.WithSslCertificatePassword(string password)
        {
            return this.WithSslCertificatePassword(password) as ReturnT;
        }

        /// <summary>
        /// Gets the backend port number the network traffic is sent to.
        /// </summary>
        int Microsoft.Azure.Management.Network.Fluent.IHasBackendPort.BackendPort
        {
            get
            {
                return this.BackendPort();
            }
        }

        /// <summary>
        /// Associates a new listener for the specified port number and the HTTPS protocol with this rule.
        /// </summary>
        /// <param name="portNumber">The port number to listen to.</param>
        /// <return>The next stage of the definition, or null if the specified port number is already used for a different protocol.</return>
        ApplicationGatewayRequestRoutingRule.UpdateDefinition.IWithSslCertificate<ApplicationGateway.Update.IUpdate> ApplicationGatewayRequestRoutingRule.UpdateDefinition.IWithFrontendPort<ApplicationGateway.Update.IUpdate>.FromFrontendHttpsPort(int portNumber)
        {
            return this.FromFrontendHttpsPort(portNumber) as ApplicationGatewayRequestRoutingRule.UpdateDefinition.IWithSslCertificate<ApplicationGateway.Update.IUpdate>;
        }

        /// <summary>
        /// Associates a new listener for the specified port number and the HTTP protocol with this rule.
        /// </summary>
        /// <param name="portNumber">The port number to listen to.</param>
        /// <return>The next stage of the definition, or null if the specified port number is already used for a different protocol.</return>
        ApplicationGatewayRequestRoutingRule.UpdateDefinition.IWithBackendHttpConfiguration<ApplicationGateway.Update.IUpdate> ApplicationGatewayRequestRoutingRule.UpdateDefinition.IWithFrontendPort<ApplicationGateway.Update.IUpdate>.FromFrontendHttpPort(int portNumber)
        {
            return this.FromFrontendHttpPort(portNumber) as ApplicationGatewayRequestRoutingRule.UpdateDefinition.IWithBackendHttpConfiguration<ApplicationGateway.Update.IUpdate>;
        }

        /// <summary>
        /// Associates a new listener for the specified port number and the HTTPS protocol with this rule.
        /// </summary>
        /// <param name="portNumber">The port number to listen to.</param>
        /// <return>The next stage of the definition, or null if the specified port number is already used for a different protocol.</return>
        ApplicationGatewayRequestRoutingRule.Definition.IWithSslCertificate<ApplicationGateway.Definition.IWithRequestRoutingRuleOrCreate> ApplicationGatewayRequestRoutingRule.Definition.IWithFrontendPort<ApplicationGateway.Definition.IWithRequestRoutingRuleOrCreate>.FromFrontendHttpsPort(int portNumber)
        {
            return this.FromFrontendHttpsPort(portNumber) as ApplicationGatewayRequestRoutingRule.Definition.IWithSslCertificate<ApplicationGateway.Definition.IWithRequestRoutingRuleOrCreate>;
        }

        /// <summary>
        /// Associates a new listener for the specified port number and the HTTP protocol with this rule.
        /// </summary>
        /// <param name="portNumber">The port number to listen to.</param>
        /// <return>The next stage of the definition, or null if the specified port number is already used for a different protocol.</return>
        ApplicationGatewayRequestRoutingRule.Definition.IWithBackendHttpConfiguration<ApplicationGateway.Definition.IWithRequestRoutingRuleOrCreate> ApplicationGatewayRequestRoutingRule.Definition.IWithFrontendPort<ApplicationGateway.Definition.IWithRequestRoutingRuleOrCreate>.FromFrontendHttpPort(int portNumber)
        {
            return this.FromFrontendHttpPort(portNumber) as ApplicationGatewayRequestRoutingRule.Definition.IWithBackendHttpConfiguration<ApplicationGateway.Definition.IWithRequestRoutingRuleOrCreate>;
        }
    }
}