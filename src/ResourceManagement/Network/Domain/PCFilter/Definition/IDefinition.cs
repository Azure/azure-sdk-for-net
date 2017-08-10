// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent.PCFilter.Definition
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.Network.Fluent.PacketCapture.Definition;
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.Network.Fluent.HasProtocol.Definition;

    public interface IWithAttach<ParentT>  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition.IInDefinition<ParentT>,
        Microsoft.Azure.Management.Network.Fluent.PCFilter.Definition.IBlank<ParentT>
    {
    }

    /// <summary>
    /// Set remote IP Address to be filtered on.
    /// Notation: "127.0.0.1" for single address entry. "127.0.0.1-127.0.0.255" for range. "127.0.0.1;127.0.0.5" for multiple entries.
    /// Multiple ranges not currently supported. Mixing ranges with multiple entries not currently supported. Default = null.
    /// </summary>
    public interface IWithRemoteIPAddress<ParentT> 
    {
        /// <summary>
        /// Set remote IP addresses range to be filtered on.
        /// </summary>
        /// <param name="startIPAddress">Range start IP address.</param>
        /// <param name="endIPAddress">Range end IP address.</param>
        /// <return>The next stage.</return>
        Microsoft.Azure.Management.Network.Fluent.PCFilter.Definition.IDefinition<ParentT> WithRemoteIPAddressesRange(string startIPAddress, string endIPAddress);

        /// <summary>
        /// Set remote IP address to be filtered on.
        /// </summary>
        /// <param name="ipAddress">Remote IP address.</param>
        /// <return>The next stage.</return>
        Microsoft.Azure.Management.Network.Fluent.PCFilter.Definition.IDefinition<ParentT> WithRemoteIPAddress(string ipAddress);

        /// <summary>
        /// Set list of remote IP addresses to be filtered on.
        /// </summary>
        /// <param name="ipAddresses">List of IP addresses.</param>
        /// <return>The next stage.</return>
        Microsoft.Azure.Management.Network.Fluent.PCFilter.Definition.IDefinition<ParentT> WithRemoteIPAddresses(IList<string> ipAddresses);
    }

    /// <summary>
    /// Set local port to be filtered on. Notation: "80" for single port entry."80-85" for range. "80;443;" for multiple entries.
    /// Multiple ranges not currently supported. Mixing ranges with multiple entries not currently supported. Default = null.
    /// </summary>
    public interface IWithLocalPort<ParentT> 
    {
        /// <summary>
        /// Set the local port to be filtered on.
        /// </summary>
        /// <param name="port">Port number.</param>
        /// <return>The next stage.</return>
        Microsoft.Azure.Management.Network.Fluent.PCFilter.Definition.IDefinition<ParentT> WithLocalPort(int port);

        /// <summary>
        /// Set the list of local ports to be filtered on.
        /// </summary>
        /// <param name="ports">List of local ports.</param>
        /// <return>The next stage.</return>
        Microsoft.Azure.Management.Network.Fluent.PCFilter.Definition.IDefinition<ParentT> WithLocalPorts(IList<int> ports);

        /// <summary>
        /// Set the local port range to be filtered on.
        /// </summary>
        /// <param name="startPort">Range start port number.</param>
        /// <param name="endPort">Range end port number.</param>
        /// <return>The next stage.</return>
        Microsoft.Azure.Management.Network.Fluent.PCFilter.Definition.IDefinition<ParentT> WithLocalPortRange(int startPort, int endPort);
    }

    /// <summary>
    /// Definition of packet capture filter.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IDefinition<ParentT>  :
        Microsoft.Azure.Management.Network.Fluent.PCFilter.Definition.IWithAttach<ParentT>
    {
    }

    public interface IBlank<ParentT>  :
        Microsoft.Azure.Management.Network.Fluent.HasProtocol.Definition.IWithProtocol<Microsoft.Azure.Management.Network.Fluent.PCFilter.Definition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.PacketCapture.Definition.IWithCreate>,Microsoft.Azure.Management.Network.Fluent.Models.PcProtocol>,
        Microsoft.Azure.Management.Network.Fluent.PCFilter.Definition.IWithLocalIP<ParentT>,
        Microsoft.Azure.Management.Network.Fluent.PCFilter.Definition.IWithRemoteIPAddress<ParentT>,
        Microsoft.Azure.Management.Network.Fluent.PCFilter.Definition.IWithLocalPort<ParentT>,
        Microsoft.Azure.Management.Network.Fluent.PCFilter.Definition.IWithRemotePort<ParentT>
    {
    }

    /// <summary>
    /// Set local port to be filtered on. Notation: "80" for single port entry."80-85" for range. "80;443;" for multiple entries.
    /// Multiple ranges not currently supported. Mixing ranges with multiple entries not currently supported. Default = null.
    /// </summary>
    public interface IWithRemotePort<ParentT> 
    {
        /// <summary>
        /// Set the remote port to be filtered on.
        /// </summary>
        /// <param name="port">Port number.</param>
        /// <return>The next stage.</return>
        Microsoft.Azure.Management.Network.Fluent.PCFilter.Definition.IDefinition<ParentT> WithRemotePort(int port);

        /// <summary>
        /// Set the remote port range to be filtered on.
        /// </summary>
        /// <param name="startPort">Range start port number.</param>
        /// <param name="endPort">Range end port number.</param>
        /// <return>The next stage.</return>
        Microsoft.Azure.Management.Network.Fluent.PCFilter.Definition.IDefinition<ParentT> WithRemotePortRange(int startPort, int endPort);

        /// <summary>
        /// Set the list of remote ports to be filtered on.
        /// </summary>
        /// <param name="ports">List of remote ports.</param>
        /// <return>The next stage.</return>
        Microsoft.Azure.Management.Network.Fluent.PCFilter.Definition.IDefinition<ParentT> WithRemotePorts(IList<int> ports);
    }

    /// <summary>
    /// Set local IP Address to be filtered on.
    /// Notation: "127.0.0.1" for single address entry. "127.0.0.1-127.0.0.255" for range. "127.0.0.1;127.0.0.5" for multiple entries.
    /// Multiple ranges not currently supported. Mixing ranges with multiple entries not currently supported. Default = null.
    /// </summary>
    public interface IWithLocalIP<ParentT> 
    {
        /// <summary>
        /// Set local IP addresses range to be filtered on.
        /// </summary>
        /// <param name="startIPAddress">Range start IP address.</param>
        /// <param name="endIPAddress">Range end IP address.</param>
        /// <return>The next stage.</return>
        Microsoft.Azure.Management.Network.Fluent.PCFilter.Definition.IDefinition<ParentT> WithLocalIPAddressesRange(string startIPAddress, string endIPAddress);

        /// <summary>
        /// Set list of local IP addresses to be filtered on.
        /// </summary>
        /// <param name="ipAddresses">List of IP address.</param>
        /// <return>The next stage.</return>
        Microsoft.Azure.Management.Network.Fluent.PCFilter.Definition.IDefinition<ParentT> WithLocalIPAddresses(IList<string> ipAddresses);

        /// <summary>
        /// Set local IP address to be filtered on.
        /// </summary>
        /// <param name="ipAddress">Local IP address.</param>
        /// <return>The next stage.</return>
        Microsoft.Azure.Management.Network.Fluent.PCFilter.Definition.IDefinition<ParentT> WithLocalIPAddress(string ipAddress);
    }
}