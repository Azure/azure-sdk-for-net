// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackend.UpdateDefinition
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Update;

    /// <summary>
    /// The entirety of an application gateway backend definition as part of an application gateway update.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent application gateway definition to return to after attaching this definition.</typeparam>
    public interface IUpdateDefinition<ParentT>  :
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackend.UpdateDefinition.IBlank<ParentT>,
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackend.UpdateDefinition.IWithAttach<ParentT>
    {
    }

    /// <summary>
    /// The final stage of an application gateway backend definition.
    /// At this stage, any remaining optional settings can be specified, or the definition
    /// can be attached to the parent application gateway definition using  WithAttach.attach().
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent application gateway definition to return to after attaching this definition.</typeparam>
    public interface IWithAttach<ParentT>  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Update.IInUpdate<ParentT>,
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackend.UpdateDefinition.IWithAddress<ParentT>
    {
    }

    /// <summary>
    /// The stage of an application gateway backed definition allowing to add an address to the backend.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent application gateway definition to return to after attaching this definition.</typeparam>
    public interface IWithAddress<ParentT> 
    {
        /// <summary>
        /// Adds the specified existing fully qualified domain name (FQDN) to the backend.
        /// </summary>
        /// <param name="fqdn">A fully qualified domain name (FQDN).</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackend.UpdateDefinition.IWithAttach<ParentT> WithFqdn(string fqdn);

        /// <summary>
        /// Adds the specified existing IP address to the backend.
        /// </summary>
        /// <param name="ipAddress">An IP address.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackend.UpdateDefinition.IWithAttach<ParentT> WithIPAddress(string ipAddress);
    }

    /// <summary>
    /// The first stage of an application gateway backend definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent application gateway definition to return to after attaching this definition.</typeparam>
    public interface IBlank<ParentT>  :
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackend.UpdateDefinition.IWithAttach<ParentT>
    {
    }
}