// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using ApplicationGateway.Definition;
    using ApplicationGateway.Update;
    using ApplicationGatewayBackendHttpConfiguration.Definition;
    using ApplicationGatewayBackendHttpConfiguration.Update;
    using ApplicationGatewayBackendHttpConfiguration.UpdateDefinition;
    using Models;
    using HasPort.Definition;
    using HasPort.UpdateDefinition;
    using HasPort.Update;
    using HasProtocol.Definition;
    using HasProtocol.UpdateDefinition;
    using HasProtocol.Update;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ChildResource.Definition;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ChildResource.Update;

    internal partial class ApplicationGatewayBackendHttpConfigurationImpl 
    {
        /// <summary>
        /// Specifies the port number.
        /// </summary>
        /// <param name="portNumber">A port number.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayBackendHttpConfiguration.UpdateDefinition.IWithAttach<ApplicationGateway.Update.IUpdate> HasPort.UpdateDefinition.IWithPort<ApplicationGatewayBackendHttpConfiguration.UpdateDefinition.IWithAttach<ApplicationGateway.Update.IUpdate>>.WithPort(int portNumber)
        {
            return this.WithPort(portNumber) as ApplicationGatewayBackendHttpConfiguration.UpdateDefinition.IWithAttach<ApplicationGateway.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies the port number.
        /// </summary>
        /// <param name="portNumber">A port number.</param>
        /// <return>The next stage of the update.</return>
        ApplicationGatewayBackendHttpConfiguration.Update.IUpdate HasPort.Update.IWithPort<ApplicationGatewayBackendHttpConfiguration.Update.IUpdate>.WithPort(int portNumber)
        {
            return this.WithPort(portNumber) as ApplicationGatewayBackendHttpConfiguration.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the port number.
        /// </summary>
        /// <param name="portNumber">A port number.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayBackendHttpConfiguration.Definition.IWithAttach<ApplicationGateway.Definition.IWithCreate> HasPort.Definition.IWithPort<ApplicationGatewayBackendHttpConfiguration.Definition.IWithAttach<ApplicationGateway.Definition.IWithCreate>>.WithPort(int portNumber)
        {
            return this.WithPort(portNumber) as ApplicationGatewayBackendHttpConfiguration.Definition.IWithAttach<ApplicationGateway.Definition.IWithCreate>;
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
        /// Gets the port number.
        /// </summary>
        int Microsoft.Azure.Management.Network.Fluent.IHasPort.Port
        {
            get
            {
                return this.Port();
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
        /// Specifies the request timeout.
        /// </summary>
        /// <param name="seconds">A number of seconds.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayBackendHttpConfiguration.Update.IUpdate ApplicationGatewayBackendHttpConfiguration.Update.IWithRequestTimeout.WithRequestTimeout(int seconds)
        {
            return this.WithRequestTimeout(seconds) as ApplicationGatewayBackendHttpConfiguration.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the transport protocol.
        /// </summary>
        /// <param name="protocol">A transport protocol.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayBackendHttpConfiguration.UpdateDefinition.IWithAttach<ApplicationGateway.Update.IUpdate> HasProtocol.UpdateDefinition.IWithProtocol<ApplicationGatewayBackendHttpConfiguration.UpdateDefinition.IWithAttach<ApplicationGateway.Update.IUpdate>,Models.ApplicationGatewayProtocol>.WithProtocol(ApplicationGatewayProtocol protocol)
        {
            return this.WithProtocol(protocol) as ApplicationGatewayBackendHttpConfiguration.UpdateDefinition.IWithAttach<ApplicationGateway.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies the transport protocol.
        /// </summary>
        /// <param name="protocol">A transport protocol.</param>
        /// <return>The next stage of the update.</return>
        ApplicationGatewayBackendHttpConfiguration.Update.IUpdate HasProtocol.Update.IWithProtocol<ApplicationGatewayBackendHttpConfiguration.Update.IUpdate,Models.ApplicationGatewayProtocol>.WithProtocol(ApplicationGatewayProtocol protocol)
        {
            return this.WithProtocol(protocol) as ApplicationGatewayBackendHttpConfiguration.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the transport protocol.
        /// </summary>
        /// <param name="protocol">A transport protocol.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayBackendHttpConfiguration.Definition.IWithAttach<ApplicationGateway.Definition.IWithCreate> HasProtocol.Definition.IWithProtocol<ApplicationGatewayBackendHttpConfiguration.Definition.IWithAttach<ApplicationGateway.Definition.IWithCreate>,Models.ApplicationGatewayProtocol>.WithProtocol(ApplicationGatewayProtocol protocol)
        {
            return this.WithProtocol(protocol) as ApplicationGatewayBackendHttpConfiguration.Definition.IWithAttach<ApplicationGateway.Definition.IWithCreate>;
        }

        /// <summary>
        /// Gets HTTP request timeout in seconds. Requests will fail if no response is received within the specified time.
        /// </summary>
        int Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayBackendHttpConfiguration.RequestTimeout
        {
            get
            {
                return this.RequestTimeout();
            }
        }

        /// <summary>
        /// Gets true if cookie based affinity (sticky sessions) is enabled, else false.
        /// </summary>
        bool Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayBackendHttpConfiguration.CookieBasedAffinity
        {
            get
            {
                return this.CookieBasedAffinity();
            }
        }

        /// <summary>
        /// Specifies the request timeout.
        /// </summary>
        /// <param name="seconds">A number of seconds.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayBackendHttpConfiguration.UpdateDefinition.IWithAttach<ApplicationGateway.Update.IUpdate> ApplicationGatewayBackendHttpConfiguration.UpdateDefinition.IWithRequestTimeout<ApplicationGateway.Update.IUpdate>.WithRequestTimeout(int seconds)
        {
            return this.WithRequestTimeout(seconds) as ApplicationGatewayBackendHttpConfiguration.UpdateDefinition.IWithAttach<ApplicationGateway.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies the request timeout.
        /// </summary>
        /// <param name="seconds">A number of seconds.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayBackendHttpConfiguration.Definition.IWithAttach<ApplicationGateway.Definition.IWithCreate> ApplicationGatewayBackendHttpConfiguration.Definition.IWithRequestTimeout<ApplicationGateway.Definition.IWithCreate>.WithRequestTimeout(int seconds)
        {
            return this.WithRequestTimeout(seconds) as ApplicationGatewayBackendHttpConfiguration.Definition.IWithAttach<ApplicationGateway.Definition.IWithCreate>;
        }

        /// <summary>
        /// Disables cookie based affinity.
        /// </summary>
        /// <return>The next stage of the update.</return>
        ApplicationGatewayBackendHttpConfiguration.Update.IUpdate ApplicationGatewayBackendHttpConfiguration.Update.IWithAffinity.WithoutCookieBasedAffinity()
        {
            return this.WithoutCookieBasedAffinity() as ApplicationGatewayBackendHttpConfiguration.Update.IUpdate;
        }

        /// <summary>
        /// Enables cookie based affinity.
        /// </summary>
        /// <return>The next stage of the update.</return>
        ApplicationGatewayBackendHttpConfiguration.Update.IUpdate ApplicationGatewayBackendHttpConfiguration.Update.IWithAffinity.WithCookieBasedAffinity()
        {
            return this.WithCookieBasedAffinity() as ApplicationGatewayBackendHttpConfiguration.Update.IUpdate;
        }

        /// <summary>
        /// Disables cookie based affinity.
        /// </summary>
        /// <return>The next stage of the update.</return>
        ApplicationGatewayBackendHttpConfiguration.UpdateDefinition.IWithAttach<ApplicationGateway.Update.IUpdate> ApplicationGatewayBackendHttpConfiguration.UpdateDefinition.IWithAffinity<ApplicationGateway.Update.IUpdate>.WithoutCookieBasedAffinity()
        {
            return this.WithoutCookieBasedAffinity() as ApplicationGatewayBackendHttpConfiguration.UpdateDefinition.IWithAttach<ApplicationGateway.Update.IUpdate>;
        }

        /// <summary>
        /// Enables cookie based affinity.
        /// </summary>
        /// <return>The next stage of the update.</return>
        ApplicationGatewayBackendHttpConfiguration.UpdateDefinition.IWithAttach<ApplicationGateway.Update.IUpdate> ApplicationGatewayBackendHttpConfiguration.UpdateDefinition.IWithAffinity<ApplicationGateway.Update.IUpdate>.WithCookieBasedAffinity()
        {
            return this.WithCookieBasedAffinity() as ApplicationGatewayBackendHttpConfiguration.UpdateDefinition.IWithAttach<ApplicationGateway.Update.IUpdate>;
        }

        /// <summary>
        /// Enables cookie based affinity.
        /// </summary>
        /// <return>The next stage of the update.</return>
        ApplicationGatewayBackendHttpConfiguration.Definition.IWithAttach<ApplicationGateway.Definition.IWithCreate> ApplicationGatewayBackendHttpConfiguration.Definition.IWithAffinity<ApplicationGateway.Definition.IWithCreate>.WithCookieBasedAffinity()
        {
            return this.WithCookieBasedAffinity() as ApplicationGatewayBackendHttpConfiguration.Definition.IWithAttach<ApplicationGateway.Definition.IWithCreate>;
        }
    }
}