// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayRequestRoutingRule.Update
{
    using Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Update;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ChildResourceActions;

    /// <summary>
    /// The entirety of an application gateway request routing rule update as part of an application gateway update.
    /// </summary>
    public interface IUpdate  :
        ISettable<Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Update.IUpdate>,
        IWithListener,
        IWithBackend,
        IWithBackendHttpConfiguration
    {
    }

    /// <summary>
    /// The stage of an application gateway request routing rule update allowing to specify an existing listener to
    /// associate the routing rule with.
    /// </summary>
    public interface IWithListener 
    {
        /// <summary>
        /// Associates the request routing rule with an existing frontend listener.
        /// <p>
        /// Also, note that a given listener can be used by no more than one request routing rule at a time.
        /// </summary>
        /// <param name="name">The name of a listener to reference.</param>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayRequestRoutingRule.Update.IUpdate FromListener(string name);
    }

    /// <summary>
    /// The stage of an application gateway request routing rule update allowing to specify the backend to associate the routing rule with.
    /// </summary>
    public interface IWithBackend 
    {
        /// <summary>
        /// Associates the request routing rule with an existing backend on this application gateway.
        /// </summary>
        /// <param name="name">The name of an existing backend.</param>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayRequestRoutingRule.Update.IUpdate ToBackend(string name);
    }

    /// <summary>
    /// The stage of an application gateway request routing rule update allowing to specify the backend HTTP settings configuration
    /// to associate the routing rule with.
    /// </summary>
    public interface IWithBackendHttpConfiguration 
    {
        /// <summary>
        /// Associates the specified backend HTTP settings configuration with this request routing rule.
        /// </summary>
        /// <param name="name">The name of a backend HTTP settings configuration.</param>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayRequestRoutingRule.Update.IUpdate ToBackendHttpConfiguration(string name);
    }
}