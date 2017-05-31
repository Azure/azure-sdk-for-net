// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackendHttpConfiguration.Update
{
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.Network.Fluent.HasProtocol.Update;
    using Microsoft.Azure.Management.Network.Fluent.HasPort.Update;
    using Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResourceActions;

    /// <summary>
    /// The stage of an application gateway backend HTTP configuration allowing to specify the request timeout.
    /// </summary>
    public interface IWithRequestTimeout 
    {
        /// <summary>
        /// Specifies the request timeout.
        /// </summary>
        /// <param name="seconds">A number of seconds.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackendHttpConfiguration.Update.IUpdate WithRequestTimeout(int seconds);
    }

    /// <summary>
    /// The stage of an application gateway backend HTTP configuration allowing to specify the protocol.
    /// </summary>
    public interface IWithProtocol  :
        Microsoft.Azure.Management.Network.Fluent.HasProtocol.Update.IWithProtocol<Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackendHttpConfiguration.Update.IUpdate,Microsoft.Azure.Management.Network.Fluent.Models.ApplicationGatewayProtocol>
    {
    }

    /// <summary>
    /// The stage of an application gateway backend HTTP configuration allowing to specify the port number.
    /// </summary>
    public interface IWithPort  :
        Microsoft.Azure.Management.Network.Fluent.HasPort.Update.IWithPort<Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackendHttpConfiguration.Update.IUpdate>
    {
    }

    /// <summary>
    /// The stage of an application gateway backend HTTP configuration allowing to associate an existing probe.
    /// </summary>
    public interface IWithProbe  :
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackendHttpConfiguration.Update.IWithProbeBeta
    {
    }

    /// <summary>
    /// The stage of an application gateway backend HTTP configuration allowing to enable or disable cookie based affinity.
    /// </summary>
    public interface IWithAffinity 
    {
        /// <summary>
        /// Disables cookie based affinity.
        /// </summary>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackendHttpConfiguration.Update.IUpdate WithoutCookieBasedAffinity();

        /// <summary>
        /// Enables cookie based affinity.
        /// </summary>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackendHttpConfiguration.Update.IUpdate WithCookieBasedAffinity();
    }

    /// <summary>
    /// The entirety of an application gateway backend HTTP configuration update as part of an application gateway update.
    /// </summary>
    public interface IUpdate  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResourceActions.ISettable<Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Update.IUpdate>,
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackendHttpConfiguration.Update.IWithPort,
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackendHttpConfiguration.Update.IWithAffinity,
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackendHttpConfiguration.Update.IWithProtocol,
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackendHttpConfiguration.Update.IWithRequestTimeout,
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackendHttpConfiguration.Update.IWithProbe
    {
    }

    /// <summary>
    /// The stage of an application gateway backend HTTP configuration allowing to associate an existing probe.
    /// </summary>
    public interface IWithProbeBeta  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Specifies an existing probe on this application gateway to associate with this backend.
        /// If the probe with the specified name does not yet exist, it must be defined separately in the optional part
        /// of the application gateway definition. This only adds a reference to the probe by its name.
        /// </summary>
        /// <param name="name">The name of an existing probe.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackendHttpConfiguration.Update.IUpdate WithProbe(string name);

        /// <summary>
        /// Removes the association with a probe.
        /// </summary>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackendHttpConfiguration.Update.IUpdate WithoutProbe();
    }
}