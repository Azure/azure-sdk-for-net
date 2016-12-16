// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackendHttpConfiguration.UpdateDefinition
{
    using Microsoft.Azure.Management.Resource.Fluent.Core.ChildResource.Update;
    using Microsoft.Azure.Management.Network.Fluent.HasPort.UpdateDefinition;
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.Network.Fluent.HasProtocol.UpdateDefinition;

    /// <summary>
    /// The first stage of an application gateway backend HTTP configuration definition.
    /// </summary>
    /// <typeparam name="Parent">The stage of the parent application gateway definition to return to after attaching this definition.</typeparam>
    public interface IBlank<ParentT>  :
        IWithAttach<ParentT>
    {
    }

    /// <summary>
    /// The final stage of an application gateway backend HTTP configuration definition.
    /// At this stage, any remaining optional settings can be specified, or the definition
    /// can be attached to the parent application gateway definition using WithAttach.attach().
    /// </summary>
    /// <typeparam name="Parent">The stage of the parent application gateway definition to return to after attaching this definition.</typeparam>
    public interface IWithAttach<ParentT>  :
        IInUpdate<ParentT>,
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackendHttpConfiguration.UpdateDefinition.IWithPort<ParentT>,
        IWithAffinity<ParentT>,
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackendHttpConfiguration.UpdateDefinition.IWithProtocol<ParentT>,
        IWithRequestTimeout<ParentT>
    {
    }

    /// <summary>
    /// The stage of an application gateway backend HTTP configuration allowing to enable or disable cookie based affinity.
    /// </summary>
    /// <typeparam name="Parent">The stage of the parent application gateway definition to return to after attaching this definition.</typeparam>
    public interface IWithAffinity<ParentT> 
    {
        /// <summary>
        /// Disables cookie based affinity.
        /// </summary>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackendHttpConfiguration.UpdateDefinition.IWithAttach<ParentT> WithoutCookieBasedAffinity();

        /// <summary>
        /// Enables cookie based affinity.
        /// </summary>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackendHttpConfiguration.UpdateDefinition.IWithAttach<ParentT> WithCookieBasedAffinity();
    }

    /// <summary>
    /// The entirety of an application gateway backend HTTP configuration definition as part of an application gateway update.
    /// </summary>
    /// <typeparam name="Parent">The stage of the parent application gateway definition to return to after attaching this definition.</typeparam>
    public interface IUpdateDefinition<ParentT>  :
        IBlank<ParentT>,
        IWithAttach<ParentT>
    {
    }

    /// <summary>
    /// The stage of an application gateway backend HTTP configuration allowing to specify the request timeout.
    /// </summary>
    /// <typeparam name="Parent">The stage of the parent application gateway definition to return to after attaching this definition.</typeparam>
    public interface IWithRequestTimeout<ParentT> 
    {
        /// <summary>
        /// Specifies the request timeout.
        /// </summary>
        /// <param name="seconds">A number of seconds.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackendHttpConfiguration.UpdateDefinition.IWithAttach<ParentT> WithRequestTimeout(int seconds);
    }

    /// <summary>
    /// The stage of an application gateway backend HTTP configuration allowing to specify the port number.
    /// </summary>
    /// <typeparam name="Parent">The stage of the parent application gateway definition to return to after attaching this definition.</typeparam>
    public interface IWithPort<ParentT>  :
        Microsoft.Azure.Management.Network.Fluent.HasPort.UpdateDefinition.IWithPort<Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackendHttpConfiguration.UpdateDefinition.IWithAttach<ParentT>>
    {
    }

    /// <summary>
    /// The stage of an application gateway backend HTTP configuration allowing to specify the protocol.
    /// </summary>
    /// <typeparam name="Parent">The stage of the parent application gateway definition to return to after attaching this definition.</typeparam>
    public interface IWithProtocol<ParentT>  :
        Microsoft.Azure.Management.Network.Fluent.HasProtocol.UpdateDefinition.IWithProtocol<Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackendHttpConfiguration.UpdateDefinition.IWithAttach<ParentT>,Microsoft.Azure.Management.Network.Fluent.Models.ApplicationGatewayProtocol>
    {
    }
}