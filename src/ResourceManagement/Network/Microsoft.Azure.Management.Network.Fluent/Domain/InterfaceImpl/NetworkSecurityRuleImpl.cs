// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using NetworkSecurityGroup.Definition;
    using NetworkSecurityGroup.Update;
    using NetworkSecurityRule.Definition;
    using NetworkSecurityRule.Update;
    using NetworkSecurityRule.UpdateDefinition;
    using Models;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ChildResource.Definition;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ChildResource.Update;

    internal partial class NetworkSecurityRuleImpl
    {
        /// <summary>
        /// Specifies the priority to assign to this rule.
        /// <p>
        /// Security rules are applied in the order of their assigned priority.
        /// </summary>
        /// <param name="priority">The priority number in the range 100 to 4096.</param>
        NetworkSecurityRule.UpdateDefinition.IWithAttach<NetworkSecurityGroup.Update.IUpdate> NetworkSecurityRule.UpdateDefinition.IWithAttach<NetworkSecurityGroup.Update.IUpdate>.WithPriority(int priority)
        {
            return this.WithPriority(priority) as NetworkSecurityRule.UpdateDefinition.IWithAttach<NetworkSecurityGroup.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies a description for this security rule.
        /// </summary>
        /// <param name="descrtiption">A text description to associate with the security rule.</param>
        NetworkSecurityRule.UpdateDefinition.IWithAttach<NetworkSecurityGroup.Update.IUpdate> NetworkSecurityRule.UpdateDefinition.IWithAttach<NetworkSecurityGroup.Update.IUpdate>.WithDescription(string descrtiption)
        {
            return this.WithDescription(descrtiption) as NetworkSecurityRule.UpdateDefinition.IWithAttach<NetworkSecurityGroup.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies the priority to assign to this rule.
        /// <p>
        /// Security rules are applied in the order of their assigned priority.
        /// </summary>
        /// <param name="priority">The priority number in the range 100 to 4096.</param>
        NetworkSecurityRule.Definition.IWithAttach<NetworkSecurityGroup.Definition.IWithCreate> NetworkSecurityRule.Definition.IWithPriority<NetworkSecurityGroup.Definition.IWithCreate>.WithPriority(int priority)
        {
            return this.WithPriority(priority) as NetworkSecurityRule.Definition.IWithAttach<NetworkSecurityGroup.Definition.IWithCreate>;
        }

        /// <summary>
        /// Specifies a description for this security rule.
        /// </summary>
        /// <param name="description">The text description to associate with this security rule.</param>
        NetworkSecurityRule.Definition.IWithAttach<NetworkSecurityGroup.Definition.IWithCreate> NetworkSecurityRule.Definition.IWithDescription<NetworkSecurityGroup.Definition.IWithCreate>.WithDescription(string description)
        {
            return this.WithDescription(description) as NetworkSecurityRule.Definition.IWithAttach<NetworkSecurityGroup.Definition.IWithCreate>;
        }

        /// <summary>
        /// Specifies the protocol that this rule applies to.
        /// </summary>
        /// <param name="protocol">One of the supported protocols.</param>
        NetworkSecurityRule.Definition.IWithAttach<NetworkSecurityGroup.Definition.IWithCreate> NetworkSecurityRule.Definition.IWithProtocol<NetworkSecurityGroup.Definition.IWithCreate>.WithProtocol(string protocol)
        {
            return this.WithProtocol(protocol) as NetworkSecurityRule.Definition.IWithAttach<NetworkSecurityGroup.Definition.IWithCreate>;
        }

        /// <summary>
        /// Makes this rule apply to any supported protocol.
        /// </summary>
        NetworkSecurityRule.Definition.IWithAttach<NetworkSecurityGroup.Definition.IWithCreate> NetworkSecurityRule.Definition.IWithProtocol<NetworkSecurityGroup.Definition.IWithCreate>.WithAnyProtocol()
        {
            return this.WithAnyProtocol() as NetworkSecurityRule.Definition.IWithAttach<NetworkSecurityGroup.Definition.IWithCreate>;
        }

        /// <summary>
        /// Specifies the protocol that this rule applies to.
        /// </summary>
        /// <param name="protocol">One of the supported protocols.</param>
        NetworkSecurityRule.UpdateDefinition.IWithAttach<NetworkSecurityGroup.Update.IUpdate> NetworkSecurityRule.UpdateDefinition.IWithProtocol<NetworkSecurityGroup.Update.IUpdate>.WithProtocol(string protocol)
        {
            return this.WithProtocol(protocol) as NetworkSecurityRule.UpdateDefinition.IWithAttach<NetworkSecurityGroup.Update.IUpdate>;
        }

        /// <summary>
        /// Makes this rule apply to any supported protocol.
        /// </summary>
        NetworkSecurityRule.UpdateDefinition.IWithAttach<NetworkSecurityGroup.Update.IUpdate> NetworkSecurityRule.UpdateDefinition.IWithProtocol<NetworkSecurityGroup.Update.IUpdate>.WithAnyProtocol()
        {
            return this.WithAnyProtocol() as NetworkSecurityRule.UpdateDefinition.IWithAttach<NetworkSecurityGroup.Update.IUpdate>;
        }

        /// <summary>
        /// Attaches the child definition to the parent resource update.
        /// </summary>
        NetworkSecurityGroup.Update.IUpdate Microsoft.Azure.Management.Resource.Fluent.Core.ChildResource.Update.IInUpdate<NetworkSecurityGroup.Update.IUpdate>.Attach()
        {
            return this.Attach() as NetworkSecurityGroup.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the source port to which this rule applies.
        /// </summary>
        /// <param name="port">The source port number.</param>
        NetworkSecurityRule.Update.IUpdate NetworkSecurityRule.Update.IWithSourcePort.FromPort(int port)
        {
            return this.FromPort(port) as NetworkSecurityRule.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the source port range to which this rule applies.
        /// </summary>
        /// <param name="from">The starting port number.</param>
        /// <param name="to">The ending port number.</param>
        NetworkSecurityRule.Update.IUpdate NetworkSecurityRule.Update.IWithSourcePort.FromPortRange(int from, int to)
        {
            return this.FromPortRange(from, to) as NetworkSecurityRule.Update.IUpdate;
        }

        /// <summary>
        /// Makes this rule apply to any source port.
        /// </summary>
        NetworkSecurityRule.Update.IUpdate NetworkSecurityRule.Update.IWithSourcePort.FromAnyPort()
        {
            return this.FromAnyPort() as NetworkSecurityRule.Update.IUpdate;
        }

        /// <summary>
        /// Specifies that the rule applies to any traffic source address.
        /// </summary>
        NetworkSecurityRule.Update.IUpdate NetworkSecurityRule.Update.IWithSourceAddress.FromAnyAddress()
        {
            return this.FromAnyAddress() as NetworkSecurityRule.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the traffic source address prefix to which this rule applies.
        /// </summary>
        /// <param name="cidr">An IP address prefix expressed in the CIDR notation.</param>
        NetworkSecurityRule.Update.IUpdate NetworkSecurityRule.Update.IWithSourceAddress.FromAddress(string cidr)
        {
            return this.FromAddress(cidr) as NetworkSecurityRule.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the priority to assign to this security rule.
        /// <p>
        /// Security rules are applied in the order of their assigned priority.
        /// </summary>
        /// <param name="priority">The priority number in the range 100 to 4096.</param>
        NetworkSecurityRule.Update.IUpdate NetworkSecurityRule.Update.IUpdate.WithPriority(int priority)
        {
            return this.WithPriority(priority) as NetworkSecurityRule.Update.IUpdate;
        }

        /// <summary>
        /// Specifies a description for this security rule.
        /// </summary>
        /// <param name="description">A text description to associate with this security rule.</param>
        NetworkSecurityRule.Update.IUpdate NetworkSecurityRule.Update.IUpdate.WithDescription(string description)
        {
            return this.WithDescription(description) as NetworkSecurityRule.Update.IUpdate;
        }

        /// <summary>
        /// Blocks outbound traffic.
        /// </summary>
        NetworkSecurityRule.Definition.IWithSourceAddress<NetworkSecurityGroup.Definition.IWithCreate> NetworkSecurityRule.Definition.IWithDirectionAccess<NetworkSecurityGroup.Definition.IWithCreate>.DenyOutbound()
        {
            return this.DenyOutbound() as NetworkSecurityRule.Definition.IWithSourceAddress<NetworkSecurityGroup.Definition.IWithCreate>;
        }

        /// <summary>
        /// Allows inbound traffic.
        /// </summary>
        NetworkSecurityRule.Definition.IWithSourceAddress<NetworkSecurityGroup.Definition.IWithCreate> NetworkSecurityRule.Definition.IWithDirectionAccess<NetworkSecurityGroup.Definition.IWithCreate>.AllowInbound()
        {
            return this.AllowInbound() as NetworkSecurityRule.Definition.IWithSourceAddress<NetworkSecurityGroup.Definition.IWithCreate>;
        }

        /// <summary>
        /// Allows outbound traffic.
        /// </summary>
        NetworkSecurityRule.Definition.IWithSourceAddress<NetworkSecurityGroup.Definition.IWithCreate> NetworkSecurityRule.Definition.IWithDirectionAccess<NetworkSecurityGroup.Definition.IWithCreate>.AllowOutbound()
        {
            return this.AllowOutbound() as NetworkSecurityRule.Definition.IWithSourceAddress<NetworkSecurityGroup.Definition.IWithCreate>;
        }

        /// <summary>
        /// Blocks inbound traffic.
        /// </summary>
        NetworkSecurityRule.Definition.IWithSourceAddress<NetworkSecurityGroup.Definition.IWithCreate> NetworkSecurityRule.Definition.IWithDirectionAccess<NetworkSecurityGroup.Definition.IWithCreate>.DenyInbound()
        {
            return this.DenyInbound() as NetworkSecurityRule.Definition.IWithSourceAddress<NetworkSecurityGroup.Definition.IWithCreate>;
        }

        /// <summary>
        /// Blocks outbound traffic.
        /// </summary>
        NetworkSecurityRule.UpdateDefinition.IWithSourceAddress<NetworkSecurityGroup.Update.IUpdate> NetworkSecurityRule.UpdateDefinition.IWithDirectionAccess<NetworkSecurityGroup.Update.IUpdate>.DenyOutbound()
        {
            return this.DenyOutbound() as NetworkSecurityRule.UpdateDefinition.IWithSourceAddress<NetworkSecurityGroup.Update.IUpdate>;
        }

        /// <summary>
        /// Allows inbound traffic.
        /// </summary>
        NetworkSecurityRule.UpdateDefinition.IWithSourceAddress<NetworkSecurityGroup.Update.IUpdate> NetworkSecurityRule.UpdateDefinition.IWithDirectionAccess<NetworkSecurityGroup.Update.IUpdate>.AllowInbound()
        {
            return this.AllowInbound() as NetworkSecurityRule.UpdateDefinition.IWithSourceAddress<NetworkSecurityGroup.Update.IUpdate>;
        }

        /// <summary>
        /// Allows outbound traffic.
        /// </summary>
        NetworkSecurityRule.UpdateDefinition.IWithSourceAddress<NetworkSecurityGroup.Update.IUpdate> NetworkSecurityRule.UpdateDefinition.IWithDirectionAccess<NetworkSecurityGroup.Update.IUpdate>.AllowOutbound()
        {
            return this.AllowOutbound() as NetworkSecurityRule.UpdateDefinition.IWithSourceAddress<NetworkSecurityGroup.Update.IUpdate>;
        }

        /// <summary>
        /// Blocks inbound traffic.
        /// </summary>
        NetworkSecurityRule.UpdateDefinition.IWithSourceAddress<NetworkSecurityGroup.Update.IUpdate> NetworkSecurityRule.UpdateDefinition.IWithDirectionAccess<NetworkSecurityGroup.Update.IUpdate>.DenyInbound()
        {
            return this.DenyInbound() as NetworkSecurityRule.UpdateDefinition.IWithSourceAddress<NetworkSecurityGroup.Update.IUpdate>;
        }

        /// <summary>
        /// Attaches the child definition to the parent resource definiton.
        /// </summary>
        NetworkSecurityGroup.Definition.IWithCreate Microsoft.Azure.Management.Resource.Fluent.Core.ChildResource.Definition.IInDefinition<NetworkSecurityGroup.Definition.IWithCreate>.Attach()
        {
            return this.Attach() as NetworkSecurityGroup.Definition.IWithCreate;
        }

        string Microsoft.Azure.Management.Network.Fluent.INetworkSecurityRule.Access
        {
            get
            {
                return this.Access();
            }
        }

        string Microsoft.Azure.Management.Network.Fluent.INetworkSecurityRule.DestinationPortRange
        {
            get
            {
                return this.DestinationPortRange();
            }
        }

        string Microsoft.Azure.Management.Network.Fluent.INetworkSecurityRule.SourcePortRange
        {
            get
            {
                return this.SourcePortRange();
            }
        }

        string Microsoft.Azure.Management.Network.Fluent.INetworkSecurityRule.Protocol
        {
            get
            {
                return this.Protocol();
            }
        }

        string Microsoft.Azure.Management.Network.Fluent.INetworkSecurityRule.SourceAddressPrefix
        {
            get
            {
                return this.SourceAddressPrefix();
            }
        }

        string Microsoft.Azure.Management.Network.Fluent.INetworkSecurityRule.Description
        {
            get
            {
                return this.Description();
            }
        }

        string Microsoft.Azure.Management.Network.Fluent.INetworkSecurityRule.DestinationAddressPrefix
        {
            get
            {
                return this.DestinationAddressPrefix();
            }
        }

        int Microsoft.Azure.Management.Network.Fluent.INetworkSecurityRule.Priority
        {
            get
            {
                return this.Priority();
            }
        }

        string Microsoft.Azure.Management.Network.Fluent.INetworkSecurityRule.Direction
        {
            get
            {
                return this.Direction();
            }
        }

        /// <summary>
        /// Specifies that the rule applies to any traffic source address.
        /// </summary>
        NetworkSecurityRule.Definition.IWithSourcePort<NetworkSecurityGroup.Definition.IWithCreate> NetworkSecurityRule.Definition.IWithSourceAddress<NetworkSecurityGroup.Definition.IWithCreate>.FromAnyAddress()
        {
            return this.FromAnyAddress() as NetworkSecurityRule.Definition.IWithSourcePort<NetworkSecurityGroup.Definition.IWithCreate>;
        }

        /// <summary>
        /// Specifies the traffic source address prefix to which this rule applies.
        /// </summary>
        /// <param name="cidr">An IP address prefix expressed in the CIDR notation.</param>
        NetworkSecurityRule.Definition.IWithSourcePort<NetworkSecurityGroup.Definition.IWithCreate> NetworkSecurityRule.Definition.IWithSourceAddress<NetworkSecurityGroup.Definition.IWithCreate>.FromAddress(string cidr)
        {
            return this.FromAddress(cidr) as NetworkSecurityRule.Definition.IWithSourcePort<NetworkSecurityGroup.Definition.IWithCreate>;
        }

        /// <summary>
        /// Specifies that the rule applies to any traffic source address.
        /// </summary>
        NetworkSecurityRule.UpdateDefinition.IWithSourcePort<NetworkSecurityGroup.Update.IUpdate> NetworkSecurityRule.UpdateDefinition.IWithSourceAddress<NetworkSecurityGroup.Update.IUpdate>.FromAnyAddress()
        {
            return this.FromAnyAddress() as NetworkSecurityRule.UpdateDefinition.IWithSourcePort<NetworkSecurityGroup.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies the traffic source address prefix to which this rule applies.
        /// </summary>
        /// <param name="cidr">An IP address prefix expressed in the CIDR notation.</param>
        NetworkSecurityRule.UpdateDefinition.IWithSourcePort<NetworkSecurityGroup.Update.IUpdate> NetworkSecurityRule.UpdateDefinition.IWithSourceAddress<NetworkSecurityGroup.Update.IUpdate>.FromAddress(string cidr)
        {
            return this.FromAddress(cidr) as NetworkSecurityRule.UpdateDefinition.IWithSourcePort<NetworkSecurityGroup.Update.IUpdate>;
        }

        /// <summary>
        /// Blocks outbound traffic.
        /// </summary>
        NetworkSecurityRule.Update.IUpdate NetworkSecurityRule.Update.IWithDirectionAccess.DenyOutbound()
        {
            return this.DenyOutbound() as NetworkSecurityRule.Update.IUpdate;
        }

        /// <summary>
        /// Allows inbound traffic.
        /// </summary>
        NetworkSecurityRule.Update.IUpdate NetworkSecurityRule.Update.IWithDirectionAccess.AllowInbound()
        {
            return this.AllowInbound() as NetworkSecurityRule.Update.IUpdate;
        }

        /// <summary>
        /// Allows outbound traffic.
        /// </summary>
        NetworkSecurityRule.Update.IUpdate NetworkSecurityRule.Update.IWithDirectionAccess.AllowOutbound()
        {
            return this.AllowOutbound() as NetworkSecurityRule.Update.IUpdate;
        }

        /// <summary>
        /// Blocks inbound traffic.
        /// </summary>
        NetworkSecurityRule.Update.IUpdate NetworkSecurityRule.Update.IWithDirectionAccess.DenyInbound()
        {
            return this.DenyInbound() as NetworkSecurityRule.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the protocol that this rule applies to.
        /// </summary>
        /// <param name="protocol">One of the supported protocols.</param>
        NetworkSecurityRule.Update.IUpdate NetworkSecurityRule.Update.IWithProtocol.WithProtocol(string protocol)
        {
            return this.WithProtocol(protocol) as NetworkSecurityRule.Update.IUpdate;
        }

        /// <summary>
        /// Makes this rule apply to any supported protocol.
        /// </summary>
        NetworkSecurityRule.Update.IUpdate NetworkSecurityRule.Update.IWithProtocol.WithAnyProtocol()
        {
            return this.WithAnyProtocol() as NetworkSecurityRule.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the traffic destination address range to which this rule applies.
        /// </summary>
        /// <param name="cidr">An IP address range expressed in the CIDR notation.</param>
        NetworkSecurityRule.Update.IUpdate NetworkSecurityRule.Update.IWithDestinationAddress.ToAddress(string cidr)
        {
            return this.ToAddress(cidr) as NetworkSecurityRule.Update.IUpdate;
        }

        /// <summary>
        /// Makes the rule apply to any traffic destination address.
        /// </summary>
        NetworkSecurityRule.Update.IUpdate NetworkSecurityRule.Update.IWithDestinationAddress.ToAnyAddress()
        {
            return this.ToAnyAddress() as NetworkSecurityRule.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the source port to which this rule applies.
        /// </summary>
        /// <param name="port">The source port number.</param>
        NetworkSecurityRule.Definition.IWithDestinationAddress<NetworkSecurityGroup.Definition.IWithCreate> NetworkSecurityRule.Definition.IWithSourcePort<NetworkSecurityGroup.Definition.IWithCreate>.FromPort(int port)
        {
            return this.FromPort(port) as NetworkSecurityRule.Definition.IWithDestinationAddress<NetworkSecurityGroup.Definition.IWithCreate>;
        }

        /// <summary>
        /// Specifies the source port range to which this rule applies.
        /// </summary>
        /// <param name="from">The starting port number.</param>
        /// <param name="to">The ending port number.</param>
        NetworkSecurityRule.Definition.IWithDestinationAddress<NetworkSecurityGroup.Definition.IWithCreate> NetworkSecurityRule.Definition.IWithSourcePort<NetworkSecurityGroup.Definition.IWithCreate>.FromPortRange(int from, int to)
        {
            return this.FromPortRange(from, to) as NetworkSecurityRule.Definition.IWithDestinationAddress<NetworkSecurityGroup.Definition.IWithCreate>;
        }

        /// <summary>
        /// Makes this rule apply to any source port.
        /// </summary>
        NetworkSecurityRule.Definition.IWithDestinationAddress<NetworkSecurityGroup.Definition.IWithCreate> NetworkSecurityRule.Definition.IWithSourcePort<NetworkSecurityGroup.Definition.IWithCreate>.FromAnyPort()
        {
            return this.FromAnyPort() as NetworkSecurityRule.Definition.IWithDestinationAddress<NetworkSecurityGroup.Definition.IWithCreate>;
        }

        /// <summary>
        /// Specifies the source port to which this rule applies.
        /// </summary>
        /// <param name="port">The source port number.</param>
        NetworkSecurityRule.UpdateDefinition.IWithDestinationAddress<NetworkSecurityGroup.Update.IUpdate> NetworkSecurityRule.UpdateDefinition.IWithSourcePort<NetworkSecurityGroup.Update.IUpdate>.FromPort(int port)
        {
            return this.FromPort(port) as NetworkSecurityRule.UpdateDefinition.IWithDestinationAddress<NetworkSecurityGroup.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies the source port range to which this rule applies.
        /// </summary>
        /// <param name="from">The starting port number.</param>
        /// <param name="to">The ending port number.</param>
        NetworkSecurityRule.UpdateDefinition.IWithDestinationAddress<NetworkSecurityGroup.Update.IUpdate> NetworkSecurityRule.UpdateDefinition.IWithSourcePort<NetworkSecurityGroup.Update.IUpdate>.FromPortRange(int from, int to)
        {
            return this.FromPortRange(from, to) as NetworkSecurityRule.UpdateDefinition.IWithDestinationAddress<NetworkSecurityGroup.Update.IUpdate>;
        }

        /// <summary>
        /// Makes this rule apply to any source port.
        /// </summary>
        NetworkSecurityRule.UpdateDefinition.IWithDestinationAddress<NetworkSecurityGroup.Update.IUpdate> NetworkSecurityRule.UpdateDefinition.IWithSourcePort<NetworkSecurityGroup.Update.IUpdate>.FromAnyPort()
        {
            return this.FromAnyPort() as NetworkSecurityRule.UpdateDefinition.IWithDestinationAddress<NetworkSecurityGroup.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies the traffic destination address range to which this rule applies.
        /// </summary>
        /// <param name="cidr">An IP address range expressed in the CIDR notation.</param>
        NetworkSecurityRule.Definition.IWithDestinationPort<NetworkSecurityGroup.Definition.IWithCreate> NetworkSecurityRule.Definition.IWithDestinationAddress<NetworkSecurityGroup.Definition.IWithCreate>.ToAddress(string cidr)
        {
            return this.ToAddress(cidr) as NetworkSecurityRule.Definition.IWithDestinationPort<NetworkSecurityGroup.Definition.IWithCreate>;
        }

        /// <summary>
        /// Makes the rule apply to any traffic destination address.
        /// </summary>
        NetworkSecurityRule.Definition.IWithDestinationPort<NetworkSecurityGroup.Definition.IWithCreate> NetworkSecurityRule.Definition.IWithDestinationAddress<NetworkSecurityGroup.Definition.IWithCreate>.ToAnyAddress()
        {
            return this.ToAnyAddress() as NetworkSecurityRule.Definition.IWithDestinationPort<NetworkSecurityGroup.Definition.IWithCreate>;
        }

        /// <summary>
        /// Specifies the traffic destination address range to which this rule applies.
        /// </summary>
        /// <param name="cidr">An IP address range expressed in the CIDR notation.</param>
        NetworkSecurityRule.UpdateDefinition.IWithDestinationPort<NetworkSecurityGroup.Update.IUpdate> NetworkSecurityRule.UpdateDefinition.IWithDestinationAddress<NetworkSecurityGroup.Update.IUpdate>.ToAddress(string cidr)
        {
            return this.ToAddress(cidr) as NetworkSecurityRule.UpdateDefinition.IWithDestinationPort<NetworkSecurityGroup.Update.IUpdate>;
        }

        /// <summary>
        /// Makes the rule apply to any traffic destination address.
        /// </summary>
        NetworkSecurityRule.UpdateDefinition.IWithDestinationPort<NetworkSecurityGroup.Update.IUpdate> NetworkSecurityRule.UpdateDefinition.IWithDestinationAddress<NetworkSecurityGroup.Update.IUpdate>.ToAnyAddress()
        {
            return this.ToAnyAddress() as NetworkSecurityRule.UpdateDefinition.IWithDestinationPort<NetworkSecurityGroup.Update.IUpdate>;
        }

        string Microsoft.Azure.Management.Resource.Fluent.Core.IHasName.Name
        {
            get
            {
                return this.Name();
            }
        }

        /// <summary>
        /// Specifies the destination port range to which this rule applies.
        /// </summary>
        /// <param name="from">The starting port number.</param>
        /// <param name="to">The ending port number.</param>
        NetworkSecurityRule.Definition.IWithProtocol<NetworkSecurityGroup.Definition.IWithCreate> NetworkSecurityRule.Definition.IWithDestinationPort<NetworkSecurityGroup.Definition.IWithCreate>.ToPortRange(int from, int to)
        {
            return this.ToPortRange(from, to) as NetworkSecurityRule.Definition.IWithProtocol<NetworkSecurityGroup.Definition.IWithCreate>;
        }

        /// <summary>
        /// Specifies the destination port to which this rule applies.
        /// </summary>
        /// <param name="port">The destination port number.</param>
        NetworkSecurityRule.Definition.IWithProtocol<NetworkSecurityGroup.Definition.IWithCreate> NetworkSecurityRule.Definition.IWithDestinationPort<NetworkSecurityGroup.Definition.IWithCreate>.ToPort(int port)
        {
            return this.ToPort(port) as NetworkSecurityRule.Definition.IWithProtocol<NetworkSecurityGroup.Definition.IWithCreate>;
        }

        /// <summary>
        /// Makes this rule apply to any destination port.
        /// </summary>
        NetworkSecurityRule.Definition.IWithProtocol<NetworkSecurityGroup.Definition.IWithCreate> NetworkSecurityRule.Definition.IWithDestinationPort<NetworkSecurityGroup.Definition.IWithCreate>.ToAnyPort()
        {
            return this.ToAnyPort() as NetworkSecurityRule.Definition.IWithProtocol<NetworkSecurityGroup.Definition.IWithCreate>;
        }

        /// <summary>
        /// Specifies the destination port range to which this rule applies.
        /// </summary>
        /// <param name="from">The starting port number.</param>
        /// <param name="to">The ending port number.</param>
        NetworkSecurityRule.UpdateDefinition.IWithProtocol<NetworkSecurityGroup.Update.IUpdate> NetworkSecurityRule.UpdateDefinition.IWithDestinationPort<NetworkSecurityGroup.Update.IUpdate>.ToPortRange(int from, int to)
        {
            return this.ToPortRange(from, to) as NetworkSecurityRule.UpdateDefinition.IWithProtocol<NetworkSecurityGroup.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies the destination port to which this rule applies.
        /// </summary>
        /// <param name="port">The destination port number.</param>
        NetworkSecurityRule.UpdateDefinition.IWithProtocol<NetworkSecurityGroup.Update.IUpdate> NetworkSecurityRule.UpdateDefinition.IWithDestinationPort<NetworkSecurityGroup.Update.IUpdate>.ToPort(int port)
        {
            return this.ToPort(port) as NetworkSecurityRule.UpdateDefinition.IWithProtocol<NetworkSecurityGroup.Update.IUpdate>;
        }

        /// <summary>
        /// Makes this rule apply to any destination port.
        /// </summary>
        NetworkSecurityRule.UpdateDefinition.IWithProtocol<NetworkSecurityGroup.Update.IUpdate> NetworkSecurityRule.UpdateDefinition.IWithDestinationPort<NetworkSecurityGroup.Update.IUpdate>.ToAnyPort()
        {
            return this.ToAnyPort() as NetworkSecurityRule.UpdateDefinition.IWithProtocol<NetworkSecurityGroup.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies the destination port range to which this rule applies.
        /// </summary>
        /// <param name="from">The starting port number.</param>
        /// <param name="to">The ending port number.</param>
        NetworkSecurityRule.Update.IUpdate NetworkSecurityRule.Update.IWithDestinationPort.ToPortRange(int from, int to)
        {
            return this.ToPortRange(from, to) as NetworkSecurityRule.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the destination port to which this rule applies.
        /// </summary>
        /// <param name="port">The destination port number.</param>
        NetworkSecurityRule.Update.IUpdate NetworkSecurityRule.Update.IWithDestinationPort.ToPort(int port)
        {
            return this.ToPort(port) as NetworkSecurityRule.Update.IUpdate;
        }

        /// <summary>
        /// Makes this rule apply to any destination port.
        /// </summary>
        NetworkSecurityRule.Update.IUpdate NetworkSecurityRule.Update.IWithDestinationPort.ToAnyPort()
        {
            return this.ToAnyPort() as NetworkSecurityRule.Update.IUpdate;
        }
    }
}