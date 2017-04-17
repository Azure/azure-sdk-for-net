// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackend.Definition
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition;

    /// <summary>
    /// The stage of an application gateway backend definition allowing to add an address to the backend.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent application gateway definition to return to after attaching this definition.</typeparam>
    public interface IWithAddress<ParentT> 
    {
        /// <summary>
        /// Adds the specified existing fully qualified domain name (FQDN) to the backend.
        /// This call can be made in a sequence to add multiple FQDNs.
        /// </summary>
        /// <param name="fqdn">A fully qualified domain name (FQDN).</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackend.Definition.IWithAttach<ParentT> WithFqdn(string fqdn);

        /// <summary>
        /// Adds the specified existing IP address to the backend.
        /// This call can be made in a sequence to add multiple IP addresses.
        /// </summary>
        /// <param name="ipAddress">An IP address.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackend.Definition.IWithAttach<ParentT> WithIPAddress(string ipAddress);
    }

    /// <summary>
    /// The final stage of an application gateway backend definition.
    /// At this stage, any remaining optional settings can be specified, or the definition
    /// can be attached to the parent application gateway definition using  WithAttach.attach().
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent application gateway definition to return to after attaching this definition.</typeparam>
    public interface IWithAttach<ParentT>  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition.IInDefinition<ParentT>,
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackend.Definition.IWithAddress<ParentT>
    {
    }

    /// <summary>
    /// The entirety of an application gateway backend definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent application gateway definition to return to after attaching this definition.</typeparam>
    public interface IDefinition<ParentT>  :
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackend.Definition.IBlank<ParentT>,
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackend.Definition.IWithAttach<ParentT>
    {
    }

    /// <summary>
    /// The first stage of an application gateway backend definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent application gateway definition to return to after attaching this definition.</typeparam>
    public interface IBlank<ParentT>  :
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackend.Definition.IWithAttach<ParentT>
    {
    }
}