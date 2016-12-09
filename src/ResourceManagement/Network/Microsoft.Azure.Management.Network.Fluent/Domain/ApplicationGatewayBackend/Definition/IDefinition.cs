// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackend.Definition
{
    using Microsoft.Azure.Management.Resource.Fluent.Core.ChildResource.Definition;

    /// <summary>
    /// The stage of an application gateway backend definition allowing to add an address to the backend.
    /// </summary>
    public interface IWithAddress<ParentT> 
    {
        /// <summary>
        /// Adds the specified existing IP address to the backend.
        /// <p>
        /// This call can be made in a sequence to add multiple IP addresses.
        /// </summary>
        /// <param name="ipAddress">An IP address.</param>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackend.Definition.IWithAttach<ParentT> WithIpAddress(string ipAddress);

        /// <summary>
        /// Adds the specified existing fully qualified domain name (FQDN) to the backend.
        /// <p>
        /// This call can be made in a sequence to add multiple FQDNs.
        /// </summary>
        /// <param name="fqdn">A fully qualified domain name (FQDN).</param>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackend.Definition.IWithAttach<ParentT> WithFqdn(string fqdn);
    }

    /// <summary>
    /// The final stage of an application gateway backend definition.
    /// <p>
    /// At this stage, any remaining optional settings can be specified, or the definition
    /// can be attached to the parent application gateway definition using WithAttach.attach().
    /// </summary>
    public interface IWithAttach<ParentT>  :
        IInDefinition<ParentT>,
        IWithAddress<ParentT>
    {
    }

    /// <summary>
    /// The entirety of an application gateway backend definition.
    /// </summary>
    public interface IDefinition<ParentT>  :
        IBlank<ParentT>,
        IWithAttach<ParentT>
    {
    }

    /// <summary>
    /// The first stage of an application gateway backend definition.
    /// </summary>
    public interface IBlank<ParentT>  :
        IWithAttach<ParentT>
    {
    }
}