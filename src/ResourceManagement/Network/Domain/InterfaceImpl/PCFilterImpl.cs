// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent.PCFilter.Definition;
    using Microsoft.Azure.Management.Network.Fluent.PacketCapture.Definition;
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.Network.Fluent.HasProtocol.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition;
    using System.Collections.Generic;

    internal partial class PCFilterImpl 
    {
        /// <summary>
        /// Gets local IP Address to be filtered on. Notation: "127.0.0.1" for single address entry. "127.0.0.1-127.0.0.255" for range. "127.0.0.1;127.0.0.5"? for multiple entries. Multiple ranges not currently supported. Mixing ranges with multiple entries not currently supported. Default = null.
        /// </summary>
        string Microsoft.Azure.Management.Network.Fluent.IPCFilter.LocalIPAddress
        {
            get
            {
                return this.LocalIPAddress();
            }
        }

        /// <summary>
        /// Gets remote port to be filtered on. Notation: "80" for single port entry."80-85" for range. "80;443;" for multiple entries. Multiple ranges not currently supported. Mixing ranges with multiple entries not currently supported. Default = null.
        /// </summary>
        string Microsoft.Azure.Management.Network.Fluent.IPCFilter.RemotePort
        {
            get
            {
                return this.RemotePort();
            }
        }

        /// <summary>
        /// Gets protocol to be filtered on.
        /// </summary>
        Models.PcProtocol Microsoft.Azure.Management.Network.Fluent.IPCFilter.Protocol
        {
            get
            {
                return this.Protocol() as Models.PcProtocol;
            }
        }

        /// <summary>
        /// Gets remote IP Address to be filtered on. Notation: "127.0.0.1" for single address entry. "127.0.0.1-127.0.0.255" for range. "127.0.0.1;127.0.0.5;" for multiple entries. Multiple ranges not currently supported. Mixing ranges with multiple entries not currently supported. Default = null.
        /// </summary>
        string Microsoft.Azure.Management.Network.Fluent.IPCFilter.RemoteIPAddress
        {
            get
            {
                return this.RemoteIPAddress();
            }
        }

        /// <summary>
        /// Gets local port to be filtered on. Notation: "80" for single port entry."80-85" for range. "80;443;" for multiple entries. Multiple ranges not currently supported. Mixing ranges with multiple entries not currently supported. Default = null.
        /// </summary>
        string Microsoft.Azure.Management.Network.Fluent.IPCFilter.LocalPort
        {
            get
            {
                return this.LocalPort();
            }
        }

        /// <summary>
        /// Specifies the transport protocol.
        /// </summary>
        /// <param name="protocol">A transport protocol.</param>
        /// <return>The next stage of the definition.</return>
        PCFilter.Definition.IWithAttach<PacketCapture.Definition.IWithCreate> HasProtocol.Definition.IWithProtocol<PCFilter.Definition.IWithAttach<PacketCapture.Definition.IWithCreate>,Models.PcProtocol>.WithProtocol(PcProtocol protocol)
        {
            return this.WithProtocol(protocol) as PCFilter.Definition.IWithAttach<PacketCapture.Definition.IWithCreate>;
        }

        /// <summary>
        /// Gets the parent of this child object.
        /// </summary>
        Microsoft.Azure.Management.Network.Fluent.IPacketCapture Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasParent<Microsoft.Azure.Management.Network.Fluent.IPacketCapture>.Parent
        {
            get
            {
                return this.Parent() as Microsoft.Azure.Management.Network.Fluent.IPacketCapture;
            }
        }

        /// <summary>
        /// Set the list of remote ports to be filtered on.
        /// </summary>
        /// <param name="ports">List of remote ports.</param>
        /// <return>The next stage.</return>
        PCFilter.Definition.IDefinition<PacketCapture.Definition.IWithCreate> PCFilter.Definition.IWithRemotePort<PacketCapture.Definition.IWithCreate>.WithRemotePorts(IList<int> ports)
        {
            return this.WithRemotePorts(ports) as PCFilter.Definition.IDefinition<PacketCapture.Definition.IWithCreate>;
        }

        /// <summary>
        /// Set the remote port to be filtered on.
        /// </summary>
        /// <param name="port">Port number.</param>
        /// <return>The next stage.</return>
        PCFilter.Definition.IDefinition<PacketCapture.Definition.IWithCreate> PCFilter.Definition.IWithRemotePort<PacketCapture.Definition.IWithCreate>.WithRemotePort(int port)
        {
            return this.WithRemotePort(port) as PCFilter.Definition.IDefinition<PacketCapture.Definition.IWithCreate>;
        }

        /// <summary>
        /// Set the remote port range to be filtered on.
        /// </summary>
        /// <param name="startPort">Range start port number.</param>
        /// <param name="endPort">Range end port number.</param>
        /// <return>The next stage.</return>
        PCFilter.Definition.IDefinition<PacketCapture.Definition.IWithCreate> PCFilter.Definition.IWithRemotePort<PacketCapture.Definition.IWithCreate>.WithRemotePortRange(int startPort, int endPort)
        {
            return this.WithRemotePortRange(startPort, endPort) as PCFilter.Definition.IDefinition<PacketCapture.Definition.IWithCreate>;
        }

        /// <summary>
        /// Set remote IP addresses range to be filtered on.
        /// </summary>
        /// <param name="startIPAddress">Range start IP address.</param>
        /// <param name="endIPAddress">Range end IP address.</param>
        /// <return>The next stage.</return>
        PCFilter.Definition.IDefinition<PacketCapture.Definition.IWithCreate> PCFilter.Definition.IWithRemoteIPAddress<PacketCapture.Definition.IWithCreate>.WithRemoteIPAddressesRange(string startIPAddress, string endIPAddress)
        {
            return this.WithRemoteIPAddressesRange(startIPAddress, endIPAddress) as PCFilter.Definition.IDefinition<PacketCapture.Definition.IWithCreate>;
        }

        /// <summary>
        /// Set list of remote IP addresses to be filtered on.
        /// </summary>
        /// <param name="ipAddresses">List of IP addresses.</param>
        /// <return>The next stage.</return>
        PCFilter.Definition.IDefinition<PacketCapture.Definition.IWithCreate> PCFilter.Definition.IWithRemoteIPAddress<PacketCapture.Definition.IWithCreate>.WithRemoteIPAddresses(IList<string> ipAddresses)
        {
            return this.WithRemoteIPAddresses(ipAddresses) as PCFilter.Definition.IDefinition<PacketCapture.Definition.IWithCreate>;
        }

        /// <summary>
        /// Set remote IP address to be filtered on.
        /// </summary>
        /// <param name="ipAddress">Remote IP address.</param>
        /// <return>The next stage.</return>
        PCFilter.Definition.IDefinition<PacketCapture.Definition.IWithCreate> PCFilter.Definition.IWithRemoteIPAddress<PacketCapture.Definition.IWithCreate>.WithRemoteIPAddress(string ipAddress)
        {
            return this.WithRemoteIPAddress(ipAddress) as PCFilter.Definition.IDefinition<PacketCapture.Definition.IWithCreate>;
        }

        /// <summary>
        /// Attaches the child definition to the parent resource definiton.
        /// </summary>
        /// <return>The next stage of the parent definition.</return>
        PacketCapture.Definition.IWithCreate Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition.IInDefinition<PacketCapture.Definition.IWithCreate>.Attach()
        {
            return this.Attach() as PacketCapture.Definition.IWithCreate;
        }

        /// <summary>
        /// Set the local port range to be filtered on.
        /// </summary>
        /// <param name="startPort">Range start port number.</param>
        /// <param name="endPort">Range end port number.</param>
        /// <return>The next stage.</return>
        PCFilter.Definition.IDefinition<PacketCapture.Definition.IWithCreate> PCFilter.Definition.IWithLocalPort<PacketCapture.Definition.IWithCreate>.WithLocalPortRange(int startPort, int endPort)
        {
            return this.WithLocalPortRange(startPort, endPort) as PCFilter.Definition.IDefinition<PacketCapture.Definition.IWithCreate>;
        }

        /// <summary>
        /// Set the list of local ports to be filtered on.
        /// </summary>
        /// <param name="ports">List of local ports.</param>
        /// <return>The next stage.</return>
        PCFilter.Definition.IDefinition<PacketCapture.Definition.IWithCreate> PCFilter.Definition.IWithLocalPort<PacketCapture.Definition.IWithCreate>.WithLocalPorts(IList<int> ports)
        {
            return this.WithLocalPorts(ports) as PCFilter.Definition.IDefinition<PacketCapture.Definition.IWithCreate>;
        }

        /// <summary>
        /// Set the local port to be filtered on.
        /// </summary>
        /// <param name="port">Port number.</param>
        /// <return>The next stage.</return>
        PCFilter.Definition.IDefinition<PacketCapture.Definition.IWithCreate> PCFilter.Definition.IWithLocalPort<PacketCapture.Definition.IWithCreate>.WithLocalPort(int port)
        {
            return this.WithLocalPort(port) as PCFilter.Definition.IDefinition<PacketCapture.Definition.IWithCreate>;
        }

        /// <summary>
        /// Set local IP addresses range to be filtered on.
        /// </summary>
        /// <param name="startIPAddress">Range start IP address.</param>
        /// <param name="endIPAddress">Range end IP address.</param>
        /// <return>The next stage.</return>
        PCFilter.Definition.IDefinition<PacketCapture.Definition.IWithCreate> PCFilter.Definition.IWithLocalIP<PacketCapture.Definition.IWithCreate>.WithLocalIPAddressesRange(string startIPAddress, string endIPAddress)
        {
            return this.WithLocalIPAddressesRange(startIPAddress, endIPAddress) as PCFilter.Definition.IDefinition<PacketCapture.Definition.IWithCreate>;
        }

        /// <summary>
        /// Set list of local IP addresses to be filtered on.
        /// </summary>
        /// <param name="ipAddresses">List of IP address.</param>
        /// <return>The next stage.</return>
        PCFilter.Definition.IDefinition<PacketCapture.Definition.IWithCreate> PCFilter.Definition.IWithLocalIP<PacketCapture.Definition.IWithCreate>.WithLocalIPAddresses(IList<string> ipAddresses)
        {
            return this.WithLocalIPAddresses(ipAddresses) as PCFilter.Definition.IDefinition<PacketCapture.Definition.IWithCreate>;
        }

        /// <summary>
        /// Set local IP address to be filtered on.
        /// </summary>
        /// <param name="ipAddress">Local IP address.</param>
        /// <return>The next stage.</return>
        PCFilter.Definition.IDefinition<PacketCapture.Definition.IWithCreate> PCFilter.Definition.IWithLocalIP<PacketCapture.Definition.IWithCreate>.WithLocalIPAddress(string ipAddress)
        {
            return this.WithLocalIPAddress(ipAddress) as PCFilter.Definition.IDefinition<PacketCapture.Definition.IWithCreate>;
        }
    }
}