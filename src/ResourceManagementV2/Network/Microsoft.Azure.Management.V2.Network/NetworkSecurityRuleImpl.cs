/**
* Copyright (c) Microsoft Corporation. All rights reserved.
* Licensed under the MIT License. See License.txt in the project root for
* license information.
*/ 

namespace Microsoft.Azure.Management.V2.Network
{

    using NetworkSecurityRule.Update;
    using NetworkSecurityRule.Definition;
    using Microsoft.Azure.Management.Network.Models;
    using NetworkSecurityRule.UpdateDefinition;
    using NetworkSecurityGroup.Definition;
    using Microsoft.Azure.Management.V2.Resource.Core;
    using NetworkSecurityGroup.Update;
    using Resource.Core.ChildResourceActions;
    using System;

    /// <summary>
    /// Implementation for {@link NetworkSecurityRule} and its create and update interfaces.
    /// </summary>
    public class NetworkSecurityRuleImpl  :
        ChildResource<SecurityRuleInner,NetworkSecurityGroupImpl>,
        INetworkSecurityRule,
        IDefinition<IWithCreate>,
        IUpdateDefinition<NetworkSecurityGroup.Update.IUpdate>,
        NetworkSecurityRule.Update.IUpdate
    {
        internal  NetworkSecurityRuleImpl (SecurityRuleInner inner, NetworkSecurityGroupImpl parent) :
            base(inner.Id, inner, parent)
        {
        }

        public string Name
        {
            get
            {
                return this.Inner.Name;
            }
        }
        public string Direction
        {
            get
            {
                return this.Inner.Direction;
            }
        }
        public string Protocol
        {
            get
            {
                return this.Inner.Protocol;
            }
        }
        public string Access
        {
            get
            {
                return this.Inner.Access;
            }
        }
        public string SourceAddressPrefix
        {
            get
            {
                return this.Inner.SourceAddressPrefix;
            }
        }
        public string SourcePortRange
        {
            get
            {
                return this.Inner.SourcePortRange;
            }
        }

        public string DestinationAddressPrefix
        {
            get
            {
                return this.Inner.DestinationAddressPrefix;
            }
        }
        public string DestinationPortRange
        {
            get
            {
                return this.Inner.DestinationPortRange;
            }
        }
        public int? Priority
        {
            get
            {
                return this.Inner.Priority;


                return null;
            }
        }
        public NetworkSecurityRuleImpl AllowInbound ()
        {
            return this
                .WithDirection(SecurityRuleDirection.Inbound)
                .WithAccess(SecurityRuleAccess.Allow);
        }

        public NetworkSecurityRuleImpl AllowOutbound ()
        {

            // return this
            // .withDirection(SecurityRuleDirection.OUTBOUND)
            // .withAccess(SecurityRuleAccess.ALLOW);

            return this;
        }

        public NetworkSecurityRuleImpl DenyInbound ()
        {

            // return this
            // .withDirection(SecurityRuleDirection.INBOUND)
            // .withAccess(SecurityRuleAccess.DENY);

            return this;
        }

        public NetworkSecurityRuleImpl DenyOutbound ()
        {
            return this
                .WithDirection(SecurityRuleDirection.Outbound)
                .WithAccess(SecurityRuleAccess.Deny);
        }

        public NetworkSecurityRuleImpl WithProtocol (string protocol)
        {
            this.Inner.Protocol = protocol;
            return this;
        }

        public NetworkSecurityRuleImpl WithAnyProtocol ()
        {
            return this.WithProtocol(SecurityRuleProtocol.Asterisk);
        }

        public NetworkSecurityRuleImpl FromAddress (string cidr)
        {
            this.Inner.SourceAddressPrefix = cidr;
            return this;
        }

        public NetworkSecurityRuleImpl FromAnyAddress ()
        {
            this.Inner.SourceAddressPrefix = "*";
            return this;
        }

        public NetworkSecurityRuleImpl FromPort (int port)
        {
            this.Inner.SourcePortRange = port.ToString();
            return this;
        }

        public NetworkSecurityRuleImpl FromAnyPort ()
        {
            this.Inner.SourcePortRange = "*";
            return this;
        }

        public NetworkSecurityRuleImpl FromPortRange (int from, int to)
        {
            this.Inner.SourcePortRange = from + "-" + to;
            return this;
        }

        public NetworkSecurityRuleImpl ToAddress (string cidr)
        {
            this.Inner.DestinationAddressPrefix = cidr;
            return this;
        }

        public NetworkSecurityRuleImpl ToAnyAddress ()
        {
            this.Inner.DestinationAddressPrefix = "*";
            return this;
        }

        public NetworkSecurityRuleImpl ToPort (int port)
        {
            this.Inner.DestinationPortRange = port.ToString();
            return this;
        }

        public NetworkSecurityRuleImpl ToAnyPort ()
        {
            this.Inner.DestinationPortRange = "*";
            return this;
        }

        public NetworkSecurityRuleImpl ToPortRange (int from, int to)
        {
            this.Inner.DestinationPortRange = from + "-" + to;
            return this;
        }

        public NetworkSecurityRuleImpl WithPriority (int priority)
        {
            if (priority < 100 || priority > 4096)
            {
                throw new System.ArgumentOutOfRangeException("The priority number of a network security rule must be between 100 and 4096.");
            }

            this.Inner.Priority = priority;
            return this;
        }

        public NetworkSecurityRuleImpl WithDescription (string description)
        {
            this.Inner.Description = description;
            return this;
        }

        private NetworkSecurityRuleImpl WithDirection (string direction)
        {
            this.Inner.Direction = direction;
            return this;
        }

        private NetworkSecurityRuleImpl WithAccess (string permission)
        {
            this.Inner.Access = permission;
            return this;
        }

        public NetworkSecurityGroupImpl Attach ()
        {
            this.Parent.Inner.SecurityRules.Add(this.Inner);
            return this.Parent;
        }

        public string Description
        {
            get
            {
                return this.Inner.Description;
            }
        }

        /// <summary>
        /// Specifies the priority to assign to this rule.
        /// <p>
        /// Security rules are applied in the order of their assigned priority.
        /// </summary>
        /// <param name="priority">priority the priority number in the range 100 to 4096</param>
        /// <returns>the next stage of the update</returns>
        NetworkSecurityRule.UpdateDefinition.IWithAttach<NetworkSecurityGroup.Update.IUpdate> NetworkSecurityRule.UpdateDefinition.IWithAttach<NetworkSecurityGroup.Update.IUpdate>.WithPriority(int priority)
        {
            return this.WithPriority(priority) as NetworkSecurityRule.UpdateDefinition.IWithAttach<NetworkSecurityGroup.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies a description for this security rule.
        /// </summary>
        /// <param name="descrtiption">descrtiption a text description to associate with the security rule</param>
        /// <returns>the next stage</returns>
        NetworkSecurityRule.UpdateDefinition.IWithAttach<NetworkSecurityGroup.Update.IUpdate> NetworkSecurityRule.UpdateDefinition.IWithAttach<NetworkSecurityGroup.Update.IUpdate>.WithDescription(string descrtiption)
        {
            return this.WithDescription(descrtiption) as NetworkSecurityRule.UpdateDefinition.IWithAttach<NetworkSecurityGroup.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies the priority to assign to this rule.
        /// <p>
        /// Security rules are applied in the order of their assigned priority.
        /// </summary>
        /// <param name="priority">priority the priority number in the range 100 to 4096</param>
        /// <returns>the next stage</returns>
        NetworkSecurityRule.Definition.IWithAttach<IWithCreate> NetworkSecurityRule.Definition.IWithPriority<IWithCreate>.WithPriority(int priority)
        {
            return this.WithPriority(priority) as NetworkSecurityRule.Definition.IWithAttach<IWithCreate>;
        }

        /// <summary>
        /// Specifies a description for this security rule.
        /// </summary>
        /// <param name="description">description the text description to associate with this security rule</param>
        /// <returns>the next stage</returns>
        NetworkSecurityRule.Definition.IWithAttach<IWithCreate> NetworkSecurityRule.Definition.IWithDescription<IWithCreate>.WithDescription(string description)
        {
            return this.WithDescription(description) as NetworkSecurityRule.Definition.IWithAttach<IWithCreate>;
        }

        /// <summary>
        /// Specifies the protocol that this rule applies to.
        /// </summary>
        /// <param name="protocol">protocol one of the supported protocols</param>
        /// <returns>the next stage of the security rule definition</returns>
        NetworkSecurityRule.Definition.IWithAttach<IWithCreate> NetworkSecurityRule.Definition.IWithProtocol<IWithCreate>.WithProtocol(string protocol)
        {
            return this.WithProtocol(protocol) as NetworkSecurityRule.Definition.IWithAttach<IWithCreate>;
        }

        /// <summary>
        /// Makes this rule apply to any supported protocol.
        /// </summary>
        /// <returns>the next stage of the security rule definition</returns>
        NetworkSecurityRule.Definition.IWithAttach<IWithCreate> NetworkSecurityRule.Definition.IWithProtocol<IWithCreate>.WithAnyProtocol()
        {
            return this.WithAnyProtocol() as NetworkSecurityRule.Definition.IWithAttach<IWithCreate>;
        }

        /// <summary>
        /// Specifies the protocol that this rule applies to.
        /// </summary>
        /// <param name="protocol">protocol one of the supported protocols</param>
        /// <returns>the next stage of the security rule definition</returns>
        NetworkSecurityRule.UpdateDefinition.IWithAttach<NetworkSecurityGroup.Update.IUpdate> NetworkSecurityRule.UpdateDefinition.IWithProtocol<NetworkSecurityGroup.Update.IUpdate>.WithProtocol(string protocol)
        {
            return this.WithProtocol(protocol) as NetworkSecurityRule.UpdateDefinition.IWithAttach<NetworkSecurityGroup.Update.IUpdate>;
        }

        /// <summary>
        /// Makes this rule apply to any supported protocol.
        /// </summary>
        /// <returns>the next stage of the security rule definition</returns>
        NetworkSecurityRule.UpdateDefinition.IWithAttach<NetworkSecurityGroup.Update.IUpdate> NetworkSecurityRule.UpdateDefinition.IWithProtocol<NetworkSecurityGroup.Update.IUpdate>.WithAnyProtocol()
        {
            return this.WithAnyProtocol() as NetworkSecurityRule.UpdateDefinition.IWithAttach<NetworkSecurityGroup.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies the priority to assign to this security rule.
        /// <p>
        /// Security rules are applied in the order of their assigned priority.
        /// </summary>
        /// <param name="priority">priority the priority number in the range 100 to 4096</param>
        /// <returns>the next stage of the update</returns>
        NetworkSecurityRule.Update.IUpdate NetworkSecurityRule.Update.IUpdate.WithPriority(int priority)
        {
            return this.WithPriority(priority) as NetworkSecurityRule.Update.IUpdate;
        }

        /// <summary>
        /// Specifies a description for this security rule.
        /// </summary>
        /// <param name="description">description a text description to associate with this security rule</param>
        /// <returns>the next stage</returns>
        NetworkSecurityRule.Update.IUpdate NetworkSecurityRule.Update.IUpdate.WithDescription(string description)
        {
            return this.WithDescription(description) as NetworkSecurityRule.Update.IUpdate;
        }

        NetworkSecurityGroup.Update.IUpdate Microsoft.Azure.Management.V2.Resource.Core.ChildResource.Update.IInUpdate<NetworkSecurityGroup.Update.IUpdate>.Attach()
        {
            return this.Attach() as NetworkSecurityGroup.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the source port to which this rule applies.
        /// </summary>
        /// <param name="port">port the source port number</param>
        /// <returns>the next stage of the security rule definition</returns>
        NetworkSecurityRule.Update.IUpdate NetworkSecurityRule.Update.IWithSourcePort.FromPort(int port)
        {
            return this.FromPort(port) as NetworkSecurityRule.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the source port range to which this rule applies.
        /// </summary>
        /// <param name="from">from the starting port number</param>
        /// <param name="to">to the ending port number</param>
        /// <returns>the next stage of the security rule definition</returns>
        NetworkSecurityRule.Update.IUpdate NetworkSecurityRule.Update.IWithSourcePort.FromPortRange(int from, int to)
        {
            return this.FromPortRange(from, to) as NetworkSecurityRule.Update.IUpdate;
        }

        /// <summary>
        /// Makes this rule apply to any source port.
        /// </summary>
        /// <returns>the next stage of the security rule definition</returns>
        NetworkSecurityRule.Update.IUpdate NetworkSecurityRule.Update.IWithSourcePort.FromAnyPort
        {
            get
            {
                return this.FromAnyPort() as NetworkSecurityRule.Update.IUpdate;
            }
        }

        /// <summary>
        /// Specifies that the rule applies to any traffic source address.
        /// </summary>
        /// <returns>the next stage of the security rule definition</returns>
        NetworkSecurityRule.Update.IUpdate NetworkSecurityRule.Update.IWithSourceAddress.FromAnyAddress
        {
            get
            {
                return this.FromAnyAddress() as NetworkSecurityRule.Update.IUpdate;
            }
        }

        /// <summary>
        /// Specifies the traffic source address prefix to which this rule applies.
        /// </summary>
        /// <param name="cidr">cidr an IP address prefix expressed in the CIDR notation</param>
        /// <returns>the next stage of the security rule definition</returns>
        NetworkSecurityRule.Update.IUpdate NetworkSecurityRule.Update.IWithSourceAddress.FromAddress(string cidr)
        {
            return this.FromAddress(cidr) as NetworkSecurityRule.Update.IUpdate;
        }

        /// <summary>
        /// Blocks outbound traffic.
        /// </summary>
        /// <returns>the next stage of the security rule definition</returns>
        NetworkSecurityRule.Definition.IWithSourceAddress<IWithCreate> NetworkSecurityRule.Definition.IWithDirectionAccess<IWithCreate>.DenyOutbound
        {
            get
            {
                return this.DenyOutbound() as NetworkSecurityRule.Definition.IWithSourceAddress<IWithCreate>;
            }
        }
        /// <summary>
        /// Allows inbound traffic.
        /// </summary>
        /// <returns>the next stage of the security rule definition</returns>
        NetworkSecurityRule.Definition.IWithSourceAddress<IWithCreate> NetworkSecurityRule.Definition.IWithDirectionAccess<IWithCreate>.AllowInbound
        {
            get
            {
                return this.AllowInbound() as NetworkSecurityRule.Definition.IWithSourceAddress<IWithCreate>;
            }
        }
        /// <summary>
        /// Allows outbound traffic.
        /// </summary>
        /// <returns>the next stage of the security rule definition</returns>
        NetworkSecurityRule.Definition.IWithSourceAddress<IWithCreate> NetworkSecurityRule.Definition.IWithDirectionAccess<IWithCreate>.AllowOutbound
        {
            get
            {
                return this.AllowOutbound() as NetworkSecurityRule.Definition.IWithSourceAddress<IWithCreate>;
            }
        }
        /// <summary>
        /// Blocks inbound traffic.
        /// </summary>
        /// <returns>the next stage of the security rule definition</returns>
        NetworkSecurityRule.Definition.IWithSourceAddress<IWithCreate> NetworkSecurityRule.Definition.IWithDirectionAccess<IWithCreate>.DenyInbound
        {
            get
            {
                return this.DenyInbound() as NetworkSecurityRule.Definition.IWithSourceAddress<IWithCreate>;
            }
        }
        /// <summary>
        /// Blocks outbound traffic.
        /// </summary>
        /// <returns>the next stage of the security rule definition</returns>
        NetworkSecurityRule.UpdateDefinition.IWithSourceAddress<NetworkSecurityGroup.Update.IUpdate> NetworkSecurityRule.UpdateDefinition.IWithDirectionAccess<NetworkSecurityGroup.Update.IUpdate>.DenyOutbound
        {
            get
            {
                return this.DenyOutbound() as NetworkSecurityRule.UpdateDefinition.IWithSourceAddress<NetworkSecurityGroup.Update.IUpdate>;
            }
        }
        /// <summary>
        /// Allows inbound traffic.
        /// </summary>
        /// <returns>the next stage of the security rule definition</returns>
        NetworkSecurityRule.UpdateDefinition.IWithSourceAddress<NetworkSecurityGroup.Update.IUpdate> NetworkSecurityRule.UpdateDefinition.IWithDirectionAccess<NetworkSecurityGroup.Update.IUpdate>.AllowInbound
        {
            get
            {
                return this.AllowInbound() as NetworkSecurityRule.UpdateDefinition.IWithSourceAddress<NetworkSecurityGroup.Update.IUpdate>;
            }
        }
        /// <summary>
        /// Allows outbound traffic.
        /// </summary>
        /// <returns>the next stage of the security rule definition</returns>
        NetworkSecurityRule.UpdateDefinition.IWithSourceAddress<NetworkSecurityGroup.Update.IUpdate> NetworkSecurityRule.UpdateDefinition.IWithDirectionAccess<NetworkSecurityGroup.Update.IUpdate>.AllowOutbound
        {
            get
            {
                return this.AllowOutbound() as NetworkSecurityRule.UpdateDefinition.IWithSourceAddress<NetworkSecurityGroup.Update.IUpdate>;
            }
        }
        /// <summary>
        /// Blocks inbound traffic.
        /// </summary>
        /// <returns>the next stage of the security rule definition</returns>
        NetworkSecurityRule.UpdateDefinition.IWithSourceAddress<NetworkSecurityGroup.Update.IUpdate> NetworkSecurityRule.UpdateDefinition.IWithDirectionAccess<NetworkSecurityGroup.Update.IUpdate>.DenyInbound
        {
            get
            {
                return this.DenyInbound() as NetworkSecurityRule.UpdateDefinition.IWithSourceAddress<NetworkSecurityGroup.Update.IUpdate>;
            }
        }
        IWithCreate Microsoft.Azure.Management.V2.Resource.Core.ChildResource.Definition.IInDefinition<IWithCreate>.Attach()
        {
            return this.Attach() as IWithCreate;
        }

        /// <returns>the type of access the rule enforces</returns>
        string INetworkSecurityRule.Access
        {
            get
            {
                return this.Access;
            }
        }
        /// <returns>the source port range that the rule applies to, in the format "##-##", where "*" means "any"</returns>
        string INetworkSecurityRule.SourcePortRange
        {
            get
            {
                return this.SourcePortRange as string;
            }
        }
        /// <returns>the destination port range that the rule applies to, in the format "##-##", where "*" means any</returns>
        string INetworkSecurityRule.DestinationPortRange
        {
            get
            {
                return this.DestinationPortRange as string;
            }
        }
        /// <returns>the network protocol the rule applies to</returns>
        string INetworkSecurityRule.Protocol
        {
            get
            {
                return this.Protocol;
            }
        }

        /// <returns>the source address prefix the rule applies to, expressed using the CIDR notation in the format: "###.###.###.###/##",</returns>
        /// <returns>and "*" means "any"</returns>
        string INetworkSecurityRule.SourceAddressPrefix
        {
            get
            {
                return this.SourceAddressPrefix as string;
            }
        }
        /// <returns>the user-defined description of the security rule</returns>
        string INetworkSecurityRule.Description
        {
            get
            {
                return this.Description as string;
            }
        }
        /// <returns>the destination address prefix the rule applies to, expressed using the CIDR notation in the format: "###.###.###.###/##",</returns>
        /// <returns>and "*" means "any"</returns>
        string INetworkSecurityRule.DestinationAddressPrefix
        {
            get
            {
                return this.DestinationAddressPrefix as string;
            }
        }
        /// <returns>the priority number of this rule based on which this rule will be applied relative to the priority numbers of any other rules specified</returns>
        /// <returns>for this network security group</returns>
        int? INetworkSecurityRule.Priority
        {
            get
            {
                return this.Priority;
            }
        }

        /// <returns>the network traffic direction the rule applies to</returns>
        string INetworkSecurityRule.Direction
        {
            get
            {
                return this.Direction;
            }
        }
        /// <summary>
        /// Specifies that the rule applies to any traffic source address.
        /// </summary>
        /// <returns>the next stage of the security rule definition</returns>
        NetworkSecurityRule.Definition.IWithSourcePort<IWithCreate> NetworkSecurityRule.Definition.IWithSourceAddress<IWithCreate>.FromAnyAddress
        {
            get
            {
                return this.FromAnyAddress() as NetworkSecurityRule.Definition.IWithSourcePort<IWithCreate>;
            }
        }
        /// <summary>
        /// Specifies the traffic source address prefix to which this rule applies.
        /// </summary>
        /// <param name="cidr">cidr an IP address prefix expressed in the CIDR notation</param>
        /// <returns>the next stage of the security rule definition</returns>
        NetworkSecurityRule.Definition.IWithSourcePort<IWithCreate> NetworkSecurityRule.Definition.IWithSourceAddress<IWithCreate>.FromAddress(string cidr)
        {
            return this.FromAddress(cidr) as NetworkSecurityRule.Definition.IWithSourcePort<IWithCreate>;
        }

        /// <summary>
        /// Specifies that the rule applies to any traffic source address.
        /// </summary>
        /// <returns>the next stage of the security rule definition</returns>
        NetworkSecurityRule.UpdateDefinition.IWithSourcePort<NetworkSecurityGroup.Update.IUpdate> NetworkSecurityRule.UpdateDefinition.IWithSourceAddress<NetworkSecurityGroup.Update.IUpdate>.FromAnyAddress
        {
            get
            {
                return this.FromAnyAddress() as NetworkSecurityRule.UpdateDefinition.IWithSourcePort<NetworkSecurityGroup.Update.IUpdate>;
            }
        }
        /// <summary>
        /// Specifies the traffic source address prefix to which this rule applies.
        /// </summary>
        /// <param name="cidr">cidr an IP address prefix expressed in the CIDR notation</param>
        /// <returns>the next stage of the security rule definition</returns>
        NetworkSecurityRule.UpdateDefinition.IWithSourcePort<NetworkSecurityGroup.Update.IUpdate> NetworkSecurityRule.UpdateDefinition.IWithSourceAddress<NetworkSecurityGroup.Update.IUpdate>.FromAddress(string cidr)
        {
            return this.FromAddress(cidr) as NetworkSecurityRule.UpdateDefinition.IWithSourcePort<NetworkSecurityGroup.Update.IUpdate>;
        }

        /// <summary>
        /// Blocks outbound traffic.
        /// </summary>
        /// <returns>the next stage of the security rule definition</returns>
        NetworkSecurityRule.Update.IUpdate NetworkSecurityRule.Update.IWithDirectionAccess.DenyOutbound
        {
            get
            {
                return this.DenyOutbound() as NetworkSecurityRule.Update.IUpdate;
            }
        }

        /// <summary>
        /// Allows inbound traffic.
        /// </summary>
        /// <returns>the next stage of the security rule definition</returns>
        NetworkSecurityRule.Update.IUpdate NetworkSecurityRule.Update.IWithDirectionAccess.AllowInbound
        {
            get
            {
                return this.AllowInbound() as NetworkSecurityRule.Update.IUpdate;
            }
        }

        /// <summary>
        /// Allows outbound traffic.
        /// </summary>
        /// <returns>the next stage of the security rule definition</returns>
        NetworkSecurityRule.Update.IUpdate NetworkSecurityRule.Update.IWithDirectionAccess.AllowOutbound
        {
            get
            {
                return this.AllowOutbound() as NetworkSecurityRule.Update.IUpdate;
            }
        }

        /// <summary>
        /// Blocks inbound traffic.
        /// </summary>
        /// <returns>the next stage of the security rule definition</returns>
        NetworkSecurityRule.Update.IUpdate NetworkSecurityRule.Update.IWithDirectionAccess.DenyInbound
        {
            get
            {
                return this.DenyInbound() as NetworkSecurityRule.Update.IUpdate;
            }
        }

        /// <summary>
        /// Specifies the protocol that this rule applies to.
        /// </summary>
        /// <param name="protocol">protocol one of the supported protocols</param>
        /// <returns>the next stage of the security rule definition</returns>
        NetworkSecurityRule.Update.IUpdate NetworkSecurityRule.Update.IWithProtocol.WithProtocol(string protocol)
        {
            return this.WithProtocol(protocol) as NetworkSecurityRule.Update.IUpdate;
        }

        /// <summary>
        /// Makes this rule apply to any supported protocol.
        /// </summary>
        /// <returns>the next stage of the security rule definition</returns>
        NetworkSecurityRule.Update.IUpdate NetworkSecurityRule.Update.IWithProtocol.WithAnyProtocol()
        {
            return this.WithAnyProtocol() as NetworkSecurityRule.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the traffic destination address range to which this rule applies.
        /// </summary>
        /// <param name="cidr">cidr an IP address range expressed in the CIDR notation</param>
        /// <returns>the next stage of the security rule definition</returns>
        NetworkSecurityRule.Update.IUpdate NetworkSecurityRule.Update.IWithDestinationAddress.ToAddress(string cidr)
        {
            return this.ToAddress(cidr) as NetworkSecurityRule.Update.IUpdate;
        }

        /// <summary>
        /// Makes the rule apply to any traffic destination address.
        /// </summary>
        /// <returns>the next stage of the security rule definition</returns>
        NetworkSecurityRule.Update.IUpdate NetworkSecurityRule.Update.IWithDestinationAddress.ToAnyAddress
        {
            get
            {
                return this.ToAnyAddress() as NetworkSecurityRule.Update.IUpdate;
            }
        }

        /// <summary>
        /// Specifies the source port to which this rule applies.
        /// </summary>
        /// <param name="port">port the source port number</param>
        /// <returns>the next stage of the security rule definition</returns>
        NetworkSecurityRule.Definition.IWithDestinationAddress<IWithCreate> NetworkSecurityRule.Definition.IWithSourcePort<IWithCreate>.FromPort(int port)
        {
            return this.FromPort(port) as NetworkSecurityRule.Definition.IWithDestinationAddress<IWithCreate>;
        }

        /// <summary>
        /// Specifies the source port range to which this rule applies.
        /// </summary>
        /// <param name="from">from the starting port number</param>
        /// <param name="to">to the ending port number</param>
        /// <returns>the next stage of the security rule definition</returns>
        NetworkSecurityRule.Definition.IWithDestinationAddress<IWithCreate> NetworkSecurityRule.Definition.IWithSourcePort<IWithCreate>.FromPortRange(int from, int to)
        {
            return this.FromPortRange(from, to) as NetworkSecurityRule.Definition.IWithDestinationAddress<IWithCreate>;
        }

        /// <summary>
        /// Makes this rule apply to any source port.
        /// </summary>
        /// <returns>the next stage of the security rule definition</returns>
        NetworkSecurityRule.Definition.IWithDestinationAddress<IWithCreate> NetworkSecurityRule.Definition.IWithSourcePort<IWithCreate>.FromAnyPort
        {
            get
            {
                return this.FromAnyPort() as NetworkSecurityRule.Definition.IWithDestinationAddress<IWithCreate>;
            }
        }
        /// <summary>
        /// Specifies the source port to which this rule applies.
        /// </summary>
        /// <param name="port">port the source port number</param>
        /// <returns>the next stage of the security rule definition</returns>
        NetworkSecurityRule.UpdateDefinition.IWithDestinationAddress<NetworkSecurityGroup.Update.IUpdate> NetworkSecurityRule.UpdateDefinition.IWithSourcePort<NetworkSecurityGroup.Update.IUpdate>.FromPort(int port)
        {
            return this.FromPort(port) as NetworkSecurityRule.UpdateDefinition.IWithDestinationAddress<NetworkSecurityGroup.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies the source port range to which this rule applies.
        /// </summary>
        /// <param name="from">from the starting port number</param>
        /// <param name="to">to the ending port number</param>
        /// <returns>the next stage of the security rule definition</returns>
        NetworkSecurityRule.UpdateDefinition.IWithDestinationAddress<NetworkSecurityGroup.Update.IUpdate> NetworkSecurityRule.UpdateDefinition.IWithSourcePort<NetworkSecurityGroup.Update.IUpdate>.FromPortRange(int from, int to)
        {
            return this.FromPortRange(from, to) as NetworkSecurityRule.UpdateDefinition.IWithDestinationAddress<NetworkSecurityGroup.Update.IUpdate>;
        }

        /// <summary>
        /// Makes this rule apply to any source port.
        /// </summary>
        /// <returns>the next stage of the security rule definition</returns>
        NetworkSecurityRule.UpdateDefinition.IWithDestinationAddress<NetworkSecurityGroup.Update.IUpdate> NetworkSecurityRule.UpdateDefinition.IWithSourcePort<NetworkSecurityGroup.Update.IUpdate>.FromAnyPort
        {
            get
            {
                return this.FromAnyPort() as NetworkSecurityRule.UpdateDefinition.IWithDestinationAddress<NetworkSecurityGroup.Update.IUpdate>;
            }
        }
        /// <summary>
        /// Specifies the traffic destination address range to which this rule applies.
        /// </summary>
        /// <param name="cidr">cidr an IP address range expressed in the CIDR notation</param>
        /// <returns>the next stage of the security rule definition</returns>
        NetworkSecurityRule.Definition.IWithDestinationPort<IWithCreate> NetworkSecurityRule.Definition.IWithDestinationAddress<IWithCreate>.ToAddress(string cidr)
        {
            return this.ToAddress(cidr) as NetworkSecurityRule.Definition.IWithDestinationPort<IWithCreate>;
        }

        /// <summary>
        /// Makes the rule apply to any traffic destination address.
        /// </summary>
        /// <returns>the next stage of the security rule definition</returns>
        NetworkSecurityRule.Definition.IWithDestinationPort<IWithCreate> NetworkSecurityRule.Definition.IWithDestinationAddress<IWithCreate>.ToAnyAddress
        {
            get
            {
                return this.ToAnyAddress() as NetworkSecurityRule.Definition.IWithDestinationPort<IWithCreate>;
            }
        }
        /// <summary>
        /// Specifies the traffic destination address range to which this rule applies.
        /// </summary>
        /// <param name="cidr">cidr an IP address range expressed in the CIDR notation</param>
        /// <returns>the next stage of the security rule definition</returns>
        NetworkSecurityRule.UpdateDefinition.IWithDestinationPort<NetworkSecurityGroup.Update.IUpdate> NetworkSecurityRule.UpdateDefinition.IWithDestinationAddress<NetworkSecurityGroup.Update.IUpdate>.ToAddress(string cidr)
        {
            return this.ToAddress(cidr) as NetworkSecurityRule.UpdateDefinition.IWithDestinationPort<NetworkSecurityGroup.Update.IUpdate>;
        }

        /// <summary>
        /// Makes the rule apply to any traffic destination address.
        /// </summary>
        /// <returns>the next stage of the security rule definition</returns>
        NetworkSecurityRule.UpdateDefinition.IWithDestinationPort<NetworkSecurityGroup.Update.IUpdate> NetworkSecurityRule.UpdateDefinition.IWithDestinationAddress<NetworkSecurityGroup.Update.IUpdate>.ToAnyAddress
        {
            get
            {
                return this.ToAnyAddress() as NetworkSecurityRule.UpdateDefinition.IWithDestinationPort<NetworkSecurityGroup.Update.IUpdate>;
            }
        }
        /// <summary>
        /// Specifies the destination port range to which this rule applies.
        /// </summary>
        /// <param name="from">from the starting port number</param>
        /// <param name="to">to the ending port number</param>
        /// <returns>the next stage of the security rule definition</returns>
        NetworkSecurityRule.Definition.IWithProtocol<IWithCreate> NetworkSecurityRule.Definition.IWithDestinationPort<IWithCreate>.ToPortRange(int from, int to)
        {
            return this.ToPortRange(from, to) as NetworkSecurityRule.Definition.IWithProtocol<IWithCreate>;
        }

        /// <summary>
        /// Specifies the destination port to which this rule applies.
        /// </summary>
        /// <param name="port">port the destination port number</param>
        /// <returns>the next stage of the security rule definition</returns>
        NetworkSecurityRule.Definition.IWithProtocol<IWithCreate> NetworkSecurityRule.Definition.IWithDestinationPort<IWithCreate>.ToPort(int port)
        {
            return this.ToPort(port) as NetworkSecurityRule.Definition.IWithProtocol<IWithCreate>;
        }

        /// <summary>
        /// Makes this rule apply to any destination port.
        /// </summary>
        /// <returns>the next stage of the security rule definition</returns>
        NetworkSecurityRule.Definition.IWithProtocol<IWithCreate> NetworkSecurityRule.Definition.IWithDestinationPort<IWithCreate>.ToAnyPort
        {
            get
            {
                return this.ToAnyPort() as NetworkSecurityRule.Definition.IWithProtocol<IWithCreate>;
            }
        }
        /// <summary>
        /// Specifies the destination port range to which this rule applies.
        /// </summary>
        /// <param name="from">from the starting port number</param>
        /// <param name="to">to the ending port number</param>
        /// <returns>the next stage of the security rule definition</returns>
        NetworkSecurityRule.UpdateDefinition.IWithProtocol<NetworkSecurityGroup.Update.IUpdate> NetworkSecurityRule.UpdateDefinition.IWithDestinationPort<NetworkSecurityGroup.Update.IUpdate>.ToPortRange(int from, int to)
        {
            return this.ToPortRange(from, to) as NetworkSecurityRule.UpdateDefinition.IWithProtocol<NetworkSecurityGroup.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies the destination port to which this rule applies.
        /// </summary>
        /// <param name="port">port the destination port number</param>
        /// <returns>the next stage of the security rule definition</returns>
        NetworkSecurityRule.UpdateDefinition.IWithProtocol<NetworkSecurityGroup.Update.IUpdate> NetworkSecurityRule.UpdateDefinition.IWithDestinationPort<NetworkSecurityGroup.Update.IUpdate>.ToPort(int port)
        {
            return this.ToPort(port) as NetworkSecurityRule.UpdateDefinition.IWithProtocol<NetworkSecurityGroup.Update.IUpdate>;
        }

        /// <summary>
        /// Makes this rule apply to any destination port.
        /// </summary>
        /// <returns>the next stage of the security rule definition</returns>
        NetworkSecurityRule.UpdateDefinition.IWithProtocol<NetworkSecurityGroup.Update.IUpdate> NetworkSecurityRule.UpdateDefinition.IWithDestinationPort<NetworkSecurityGroup.Update.IUpdate>.ToAnyPort
        {
            get
            {
                return this.ToAnyPort() as NetworkSecurityRule.UpdateDefinition.IWithProtocol<NetworkSecurityGroup.Update.IUpdate>;
            }
        }
        /// <summary>
        /// Specifies the destination port range to which this rule applies.
        /// </summary>
        /// <param name="from">from the starting port number</param>
        /// <param name="to">to the ending port number</param>
        /// <returns>the next stage of the security rule definition</returns>
        NetworkSecurityRule.Update.IUpdate NetworkSecurityRule.Update.IWithDestinationPort.ToPortRange(int from, int to)
        {
            return this.ToPortRange(from, to) as NetworkSecurityRule.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the destination port to which this rule applies.
        /// </summary>
        /// <param name="port">port the destination port number</param>
        /// <returns>the next stage of the security rule definition</returns>
        NetworkSecurityRule.Update.IUpdate NetworkSecurityRule.Update.IWithDestinationPort.ToPort(int port)
        {
            return this.ToPort(port) as NetworkSecurityRule.Update.IUpdate;
        }

        NetworkSecurityGroup.Update.IUpdate ISettable<NetworkSecurityGroup.Update.IUpdate>.Parent()
        {
            return base.Parent;
        }

        /// <summary>
        /// Makes this rule apply to any destination port.
        /// </summary>
        /// <returns>the next stage of the security rule definition</returns>
        NetworkSecurityRule.Update.IUpdate NetworkSecurityRule.Update.IWithDestinationPort.ToAnyPort
        {
            get
            {
                return this.ToAnyPort() as NetworkSecurityRule.Update.IUpdate;
            }
        }

        /// <returns>the name of the child resource</returns>
        string Microsoft.Azure.Management.V2.Resource.Core.IChildResource.Name
        {
            get
            {
                return this.Name as string;
            }
        }
    }
}