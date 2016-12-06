// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{

    using Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.UpdateDefinition;
    using Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Update;
    using Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Definition;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.Network.Fluent.NetworkSecurityGroup.Definition;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ChildResource.Update;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ChildResource.Definition;
    using Microsoft.Azure.Management.Network.Fluent.NetworkSecurityGroup.Update;
    public partial class NetworkSecurityRuleImpl 
    {
        /// <summary>
        /// Specifies the priority to assign to this rule.
        /// <p>
        /// Security rules are applied in the order of their assigned priority.
        /// </summary>
        /// <param name="priority">priority the priority number in the range 100 to 4096</param>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.NetworkSecurityGroup.Update.IUpdate> Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.NetworkSecurityGroup.Update.IUpdate>.WithPriority(int priority) { 
            return this.WithPriority( priority) as Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.NetworkSecurityGroup.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies a description for this security rule.
        /// </summary>
        /// <param name="descrtiption">descrtiption a text description to associate with the security rule</param>
        /// <returns>the next stage</returns>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.NetworkSecurityGroup.Update.IUpdate> Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.NetworkSecurityGroup.Update.IUpdate>.WithDescription(string descrtiption) { 
            return this.WithDescription( descrtiption) as Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.NetworkSecurityGroup.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies the priority to assign to this rule.
        /// <p>
        /// Security rules are applied in the order of their assigned priority.
        /// </summary>
        /// <param name="priority">priority the priority number in the range 100 to 4096</param>
        /// <returns>the next stage</returns>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Definition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.NetworkSecurityGroup.Definition.IWithCreate> Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Definition.IWithPriority<Microsoft.Azure.Management.Network.Fluent.NetworkSecurityGroup.Definition.IWithCreate>.WithPriority(int priority) { 
            return this.WithPriority( priority) as Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Definition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.NetworkSecurityGroup.Definition.IWithCreate>;
        }

        /// <summary>
        /// Specifies a description for this security rule.
        /// </summary>
        /// <param name="description">description the text description to associate with this security rule</param>
        /// <returns>the next stage</returns>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Definition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.NetworkSecurityGroup.Definition.IWithCreate> Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Definition.IWithDescription<Microsoft.Azure.Management.Network.Fluent.NetworkSecurityGroup.Definition.IWithCreate>.WithDescription(string description) { 
            return this.WithDescription( description) as Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Definition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.NetworkSecurityGroup.Definition.IWithCreate>;
        }

        /// <summary>
        /// Specifies the protocol that this rule applies to.
        /// </summary>
        /// <param name="protocol">protocol one of the supported protocols</param>
        /// <returns>the next stage of the security rule definition</returns>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Definition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.NetworkSecurityGroup.Definition.IWithCreate> Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Definition.IWithProtocol<Microsoft.Azure.Management.Network.Fluent.NetworkSecurityGroup.Definition.IWithCreate>.WithProtocol(string protocol) { 
            return this.WithProtocol( protocol) as Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Definition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.NetworkSecurityGroup.Definition.IWithCreate>;
        }

        /// <summary>
        /// Makes this rule apply to any supported protocol.
        /// </summary>
        /// <returns>the next stage of the security rule definition</returns>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Definition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.NetworkSecurityGroup.Definition.IWithCreate> Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Definition.IWithProtocol<Microsoft.Azure.Management.Network.Fluent.NetworkSecurityGroup.Definition.IWithCreate>.WithAnyProtocol() { 
            return this.WithAnyProtocol() as Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Definition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.NetworkSecurityGroup.Definition.IWithCreate>;
        }

        /// <summary>
        /// Specifies the protocol that this rule applies to.
        /// </summary>
        /// <param name="protocol">protocol one of the supported protocols</param>
        /// <returns>the next stage of the security rule definition</returns>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.NetworkSecurityGroup.Update.IUpdate> Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.UpdateDefinition.IWithProtocol<Microsoft.Azure.Management.Network.Fluent.NetworkSecurityGroup.Update.IUpdate>.WithProtocol(string protocol) { 
            return this.WithProtocol( protocol) as Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.NetworkSecurityGroup.Update.IUpdate>;
        }

        /// <summary>
        /// Makes this rule apply to any supported protocol.
        /// </summary>
        /// <returns>the next stage of the security rule definition</returns>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.NetworkSecurityGroup.Update.IUpdate> Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.UpdateDefinition.IWithProtocol<Microsoft.Azure.Management.Network.Fluent.NetworkSecurityGroup.Update.IUpdate>.WithAnyProtocol() { 
            return this.WithAnyProtocol() as Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.NetworkSecurityGroup.Update.IUpdate>;
        }

        /// <summary>
        /// Attaches the child definition to the parent resource update.
        /// </summary>
        /// <returns>the next stage of the parent definition</returns>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityGroup.Update.IUpdate Microsoft.Azure.Management.Resource.Fluent.Core.ChildResource.Update.IInUpdate<Microsoft.Azure.Management.Network.Fluent.NetworkSecurityGroup.Update.IUpdate>.Attach() { 
            return this.Attach() as Microsoft.Azure.Management.Network.Fluent.NetworkSecurityGroup.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the source port to which this rule applies.
        /// </summary>
        /// <param name="port">port the source port number</param>
        /// <returns>the next stage of the security rule definition</returns>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Update.IUpdate Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Update.IWithSourcePort.FromPort(int port) { 
            return this.FromPort( port) as Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the source port range to which this rule applies.
        /// </summary>
        /// <param name="from">from the starting port number</param>
        /// <param name="to">to the ending port number</param>
        /// <returns>the next stage of the security rule definition</returns>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Update.IUpdate Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Update.IWithSourcePort.FromPortRange(int from, int to) { 
            return this.FromPortRange( from,  to) as Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Update.IUpdate;
        }

        /// <summary>
        /// Makes this rule apply to any source port.
        /// </summary>
        /// <returns>the next stage of the security rule definition</returns>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Update.IUpdate Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Update.IWithSourcePort.FromAnyPort() { 
            return this.FromAnyPort() as Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Update.IUpdate;
        }

        /// <summary>
        /// Specifies that the rule applies to any traffic source address.
        /// </summary>
        /// <returns>the next stage of the security rule definition</returns>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Update.IUpdate Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Update.IWithSourceAddress.FromAnyAddress() { 
            return this.FromAnyAddress() as Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the traffic source address prefix to which this rule applies.
        /// </summary>
        /// <param name="cidr">cidr an IP address prefix expressed in the CIDR notation</param>
        /// <returns>the next stage of the security rule definition</returns>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Update.IUpdate Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Update.IWithSourceAddress.FromAddress(string cidr) { 
            return this.FromAddress( cidr) as Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Update.IUpdate;
        }

        /// <summary>
        /// Blocks outbound traffic.
        /// </summary>
        /// <returns>the next stage of the security rule definition</returns>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Definition.IWithSourceAddress<Microsoft.Azure.Management.Network.Fluent.NetworkSecurityGroup.Definition.IWithCreate> Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Definition.IWithDirectionAccess<Microsoft.Azure.Management.Network.Fluent.NetworkSecurityGroup.Definition.IWithCreate>.DenyOutbound() { 
            return this.DenyOutbound() as Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Definition.IWithSourceAddress<Microsoft.Azure.Management.Network.Fluent.NetworkSecurityGroup.Definition.IWithCreate>;
        }

        /// <summary>
        /// Allows inbound traffic.
        /// </summary>
        /// <returns>the next stage of the security rule definition</returns>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Definition.IWithSourceAddress<Microsoft.Azure.Management.Network.Fluent.NetworkSecurityGroup.Definition.IWithCreate> Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Definition.IWithDirectionAccess<Microsoft.Azure.Management.Network.Fluent.NetworkSecurityGroup.Definition.IWithCreate>.AllowInbound() { 
            return this.AllowInbound() as Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Definition.IWithSourceAddress<Microsoft.Azure.Management.Network.Fluent.NetworkSecurityGroup.Definition.IWithCreate>;
        }

        /// <summary>
        /// Allows outbound traffic.
        /// </summary>
        /// <returns>the next stage of the security rule definition</returns>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Definition.IWithSourceAddress<Microsoft.Azure.Management.Network.Fluent.NetworkSecurityGroup.Definition.IWithCreate> Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Definition.IWithDirectionAccess<Microsoft.Azure.Management.Network.Fluent.NetworkSecurityGroup.Definition.IWithCreate>.AllowOutbound() { 
            return this.AllowOutbound() as Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Definition.IWithSourceAddress<Microsoft.Azure.Management.Network.Fluent.NetworkSecurityGroup.Definition.IWithCreate>;
        }

        /// <summary>
        /// Blocks inbound traffic.
        /// </summary>
        /// <returns>the next stage of the security rule definition</returns>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Definition.IWithSourceAddress<Microsoft.Azure.Management.Network.Fluent.NetworkSecurityGroup.Definition.IWithCreate> Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Definition.IWithDirectionAccess<Microsoft.Azure.Management.Network.Fluent.NetworkSecurityGroup.Definition.IWithCreate>.DenyInbound() { 
            return this.DenyInbound() as Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Definition.IWithSourceAddress<Microsoft.Azure.Management.Network.Fluent.NetworkSecurityGroup.Definition.IWithCreate>;
        }

        /// <summary>
        /// Blocks outbound traffic.
        /// </summary>
        /// <returns>the next stage of the security rule definition</returns>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.UpdateDefinition.IWithSourceAddress<Microsoft.Azure.Management.Network.Fluent.NetworkSecurityGroup.Update.IUpdate> Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.UpdateDefinition.IWithDirectionAccess<Microsoft.Azure.Management.Network.Fluent.NetworkSecurityGroup.Update.IUpdate>.DenyOutbound() { 
            return this.DenyOutbound() as Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.UpdateDefinition.IWithSourceAddress<Microsoft.Azure.Management.Network.Fluent.NetworkSecurityGroup.Update.IUpdate>;
        }

        /// <summary>
        /// Allows inbound traffic.
        /// </summary>
        /// <returns>the next stage of the security rule definition</returns>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.UpdateDefinition.IWithSourceAddress<Microsoft.Azure.Management.Network.Fluent.NetworkSecurityGroup.Update.IUpdate> Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.UpdateDefinition.IWithDirectionAccess<Microsoft.Azure.Management.Network.Fluent.NetworkSecurityGroup.Update.IUpdate>.AllowInbound() { 
            return this.AllowInbound() as Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.UpdateDefinition.IWithSourceAddress<Microsoft.Azure.Management.Network.Fluent.NetworkSecurityGroup.Update.IUpdate>;
        }

        /// <summary>
        /// Allows outbound traffic.
        /// </summary>
        /// <returns>the next stage of the security rule definition</returns>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.UpdateDefinition.IWithSourceAddress<Microsoft.Azure.Management.Network.Fluent.NetworkSecurityGroup.Update.IUpdate> Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.UpdateDefinition.IWithDirectionAccess<Microsoft.Azure.Management.Network.Fluent.NetworkSecurityGroup.Update.IUpdate>.AllowOutbound() { 
            return this.AllowOutbound() as Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.UpdateDefinition.IWithSourceAddress<Microsoft.Azure.Management.Network.Fluent.NetworkSecurityGroup.Update.IUpdate>;
        }

        /// <summary>
        /// Blocks inbound traffic.
        /// </summary>
        /// <returns>the next stage of the security rule definition</returns>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.UpdateDefinition.IWithSourceAddress<Microsoft.Azure.Management.Network.Fluent.NetworkSecurityGroup.Update.IUpdate> Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.UpdateDefinition.IWithDirectionAccess<Microsoft.Azure.Management.Network.Fluent.NetworkSecurityGroup.Update.IUpdate>.DenyInbound() { 
            return this.DenyInbound() as Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.UpdateDefinition.IWithSourceAddress<Microsoft.Azure.Management.Network.Fluent.NetworkSecurityGroup.Update.IUpdate>;
        }

        /// <summary>
        /// Attaches the child definition to the parent resource definiton.
        /// </summary>
        /// <returns>the next stage of the parent definition</returns>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityGroup.Definition.IWithCreate Microsoft.Azure.Management.Resource.Fluent.Core.ChildResource.Definition.IInDefinition<Microsoft.Azure.Management.Network.Fluent.NetworkSecurityGroup.Definition.IWithCreate>.Attach() { 
            return this.Attach() as Microsoft.Azure.Management.Network.Fluent.NetworkSecurityGroup.Definition.IWithCreate;
        }

        /// <returns>the type of access the rule enforces</returns>
        string Microsoft.Azure.Management.Network.Fluent.INetworkSecurityRule.Access
        {
            get
            { 
            return this.Access() as string;
            }
        }
        /// <returns>the source port range that the rule applies to, in the format "##-##", where "*" means "any"</returns>
        string Microsoft.Azure.Management.Network.Fluent.INetworkSecurityRule.SourcePortRange
        {
            get
            { 
            return this.SourcePortRange() as string;
            }
        }
        /// <returns>the destination port range that the rule applies to, in the format "##-##", where "*" means any</returns>
        string Microsoft.Azure.Management.Network.Fluent.INetworkSecurityRule.DestinationPortRange
        {
            get
            { 
            return this.DestinationPortRange() as string;
            }
        }
        /// <returns>the network protocol the rule applies to</returns>
        string Microsoft.Azure.Management.Network.Fluent.INetworkSecurityRule.Protocol
        {
            get
            { 
            return this.Protocol() as string;
            }
        }
        /// <returns>the source address prefix the rule applies to, expressed using the CIDR notation in the format: "###.###.###.###/##",</returns>
        /// <returns>and "*" means "any"</returns>
        string Microsoft.Azure.Management.Network.Fluent.INetworkSecurityRule.SourceAddressPrefix
        {
            get
            { 
            return this.SourceAddressPrefix() as string;
            }
        }
        /// <returns>the user-defined description of the security rule</returns>
        string Microsoft.Azure.Management.Network.Fluent.INetworkSecurityRule.Description
        {
            get
            { 
            return this.Description() as string;
            }
        }
        /// <returns>the destination address prefix the rule applies to, expressed using the CIDR notation in the format: "###.###.###.###/##",</returns>
        /// <returns>and "*" means "any"</returns>
        string Microsoft.Azure.Management.Network.Fluent.INetworkSecurityRule.DestinationAddressPrefix
        {
            get
            { 
            return this.DestinationAddressPrefix() as string;
            }
        }
        /// <returns>the priority number of this rule based on which this rule will be applied relative to the priority numbers of any other rules specified</returns>
        /// <returns>for this network security group</returns>
        int Microsoft.Azure.Management.Network.Fluent.INetworkSecurityRule.Priority
        {
            get
            { 
            return this.Priority();
            }
        }
        /// <returns>the direction of the network traffic that the network security rule applies to.</returns>
        string Microsoft.Azure.Management.Network.Fluent.INetworkSecurityRule.Direction
        {
            get
            { 
            return this.Direction() as string;
            }
        }
        /// <returns>the name of this child object</returns>
        string Microsoft.Azure.Management.Resource.Fluent.Core.IHasName.Name
        {
            get
            { 
            return this.Name() as string;
            }
        }
        /// <summary>
        /// Specifies that the rule applies to any traffic source address.
        /// </summary>
        /// <returns>the next stage of the security rule definition</returns>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Definition.IWithSourcePort<Microsoft.Azure.Management.Network.Fluent.NetworkSecurityGroup.Definition.IWithCreate> Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Definition.IWithSourceAddress<Microsoft.Azure.Management.Network.Fluent.NetworkSecurityGroup.Definition.IWithCreate>.FromAnyAddress() { 
            return this.FromAnyAddress() as Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Definition.IWithSourcePort<Microsoft.Azure.Management.Network.Fluent.NetworkSecurityGroup.Definition.IWithCreate>;
        }

        /// <summary>
        /// Specifies the traffic source address prefix to which this rule applies.
        /// </summary>
        /// <param name="cidr">cidr an IP address prefix expressed in the CIDR notation</param>
        /// <returns>the next stage of the security rule definition</returns>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Definition.IWithSourcePort<Microsoft.Azure.Management.Network.Fluent.NetworkSecurityGroup.Definition.IWithCreate> Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Definition.IWithSourceAddress<Microsoft.Azure.Management.Network.Fluent.NetworkSecurityGroup.Definition.IWithCreate>.FromAddress(string cidr) { 
            return this.FromAddress( cidr) as Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Definition.IWithSourcePort<Microsoft.Azure.Management.Network.Fluent.NetworkSecurityGroup.Definition.IWithCreate>;
        }

        /// <summary>
        /// Specifies that the rule applies to any traffic source address.
        /// </summary>
        /// <returns>the next stage of the security rule definition</returns>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.UpdateDefinition.IWithSourcePort<Microsoft.Azure.Management.Network.Fluent.NetworkSecurityGroup.Update.IUpdate> Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.UpdateDefinition.IWithSourceAddress<Microsoft.Azure.Management.Network.Fluent.NetworkSecurityGroup.Update.IUpdate>.FromAnyAddress() { 
            return this.FromAnyAddress() as Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.UpdateDefinition.IWithSourcePort<Microsoft.Azure.Management.Network.Fluent.NetworkSecurityGroup.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies the traffic source address prefix to which this rule applies.
        /// </summary>
        /// <param name="cidr">cidr an IP address prefix expressed in the CIDR notation</param>
        /// <returns>the next stage of the security rule definition</returns>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.UpdateDefinition.IWithSourcePort<Microsoft.Azure.Management.Network.Fluent.NetworkSecurityGroup.Update.IUpdate> Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.UpdateDefinition.IWithSourceAddress<Microsoft.Azure.Management.Network.Fluent.NetworkSecurityGroup.Update.IUpdate>.FromAddress(string cidr) { 
            return this.FromAddress( cidr) as Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.UpdateDefinition.IWithSourcePort<Microsoft.Azure.Management.Network.Fluent.NetworkSecurityGroup.Update.IUpdate>;
        }

        /// <summary>
        /// Blocks outbound traffic.
        /// </summary>
        /// <returns>the next stage of the security rule definition</returns>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Update.IUpdate Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Update.IWithDirectionAccess.DenyOutbound() { 
            return this.DenyOutbound() as Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Update.IUpdate;
        }

        /// <summary>
        /// Allows inbound traffic.
        /// </summary>
        /// <returns>the next stage of the security rule definition</returns>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Update.IUpdate Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Update.IWithDirectionAccess.AllowInbound() { 
            return this.AllowInbound() as Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Update.IUpdate;
        }

        /// <summary>
        /// Allows outbound traffic.
        /// </summary>
        /// <returns>the next stage of the security rule definition</returns>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Update.IUpdate Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Update.IWithDirectionAccess.AllowOutbound() { 
            return this.AllowOutbound() as Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Update.IUpdate;
        }

        /// <summary>
        /// Blocks inbound traffic.
        /// </summary>
        /// <returns>the next stage of the security rule definition</returns>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Update.IUpdate Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Update.IWithDirectionAccess.DenyInbound() { 
            return this.DenyInbound() as Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the protocol that this rule applies to.
        /// </summary>
        /// <param name="protocol">protocol one of the supported protocols</param>
        /// <returns>the next stage of the security rule definition</returns>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Update.IUpdate Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Update.IWithProtocol.WithProtocol(string protocol) { 
            return this.WithProtocol( protocol) as Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Update.IUpdate;
        }

        /// <summary>
        /// Makes this rule apply to any supported protocol.
        /// </summary>
        /// <returns>the next stage of the security rule definition</returns>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Update.IUpdate Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Update.IWithProtocol.WithAnyProtocol() { 
            return this.WithAnyProtocol() as Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the priority to assign to this security rule.
        /// <p>
        /// Security rules are applied in the order of their assigned priority.
        /// </summary>
        /// <param name="priority">priority the priority number in the range 100 to 4096</param>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Update.IUpdate Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Update.IUpdate.WithPriority(int priority) { 
            return this.WithPriority( priority) as Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Update.IUpdate;
        }

        /// <summary>
        /// Specifies a description for this security rule.
        /// </summary>
        /// <param name="description">description a text description to associate with this security rule</param>
        /// <returns>the next stage</returns>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Update.IUpdate Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Update.IUpdate.WithDescription(string description) { 
            return this.WithDescription( description) as Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the traffic destination address range to which this rule applies.
        /// </summary>
        /// <param name="cidr">cidr an IP address range expressed in the CIDR notation</param>
        /// <returns>the next stage of the security rule definition</returns>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Update.IUpdate Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Update.IWithDestinationAddress.ToAddress(string cidr) { 
            return this.ToAddress( cidr) as Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Update.IUpdate;
        }

        /// <summary>
        /// Makes the rule apply to any traffic destination address.
        /// </summary>
        /// <returns>the next stage of the security rule definition</returns>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Update.IUpdate Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Update.IWithDestinationAddress.ToAnyAddress() { 
            return this.ToAnyAddress() as Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the source port to which this rule applies.
        /// </summary>
        /// <param name="port">port the source port number</param>
        /// <returns>the next stage of the security rule definition</returns>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Definition.IWithDestinationAddress<Microsoft.Azure.Management.Network.Fluent.NetworkSecurityGroup.Definition.IWithCreate> Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Definition.IWithSourcePort<Microsoft.Azure.Management.Network.Fluent.NetworkSecurityGroup.Definition.IWithCreate>.FromPort(int port) { 
            return this.FromPort( port) as Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Definition.IWithDestinationAddress<Microsoft.Azure.Management.Network.Fluent.NetworkSecurityGroup.Definition.IWithCreate>;
        }

        /// <summary>
        /// Specifies the source port range to which this rule applies.
        /// </summary>
        /// <param name="from">from the starting port number</param>
        /// <param name="to">to the ending port number</param>
        /// <returns>the next stage of the security rule definition</returns>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Definition.IWithDestinationAddress<Microsoft.Azure.Management.Network.Fluent.NetworkSecurityGroup.Definition.IWithCreate> Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Definition.IWithSourcePort<Microsoft.Azure.Management.Network.Fluent.NetworkSecurityGroup.Definition.IWithCreate>.FromPortRange(int from, int to) { 
            return this.FromPortRange( from,  to) as Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Definition.IWithDestinationAddress<Microsoft.Azure.Management.Network.Fluent.NetworkSecurityGroup.Definition.IWithCreate>;
        }

        /// <summary>
        /// Makes this rule apply to any source port.
        /// </summary>
        /// <returns>the next stage of the security rule definition</returns>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Definition.IWithDestinationAddress<Microsoft.Azure.Management.Network.Fluent.NetworkSecurityGroup.Definition.IWithCreate> Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Definition.IWithSourcePort<Microsoft.Azure.Management.Network.Fluent.NetworkSecurityGroup.Definition.IWithCreate>.FromAnyPort() { 
            return this.FromAnyPort() as Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Definition.IWithDestinationAddress<Microsoft.Azure.Management.Network.Fluent.NetworkSecurityGroup.Definition.IWithCreate>;
        }

        /// <summary>
        /// Specifies the source port to which this rule applies.
        /// </summary>
        /// <param name="port">port the source port number</param>
        /// <returns>the next stage of the security rule definition</returns>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.UpdateDefinition.IWithDestinationAddress<Microsoft.Azure.Management.Network.Fluent.NetworkSecurityGroup.Update.IUpdate> Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.UpdateDefinition.IWithSourcePort<Microsoft.Azure.Management.Network.Fluent.NetworkSecurityGroup.Update.IUpdate>.FromPort(int port) { 
            return this.FromPort( port) as Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.UpdateDefinition.IWithDestinationAddress<Microsoft.Azure.Management.Network.Fluent.NetworkSecurityGroup.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies the source port range to which this rule applies.
        /// </summary>
        /// <param name="from">from the starting port number</param>
        /// <param name="to">to the ending port number</param>
        /// <returns>the next stage of the security rule definition</returns>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.UpdateDefinition.IWithDestinationAddress<Microsoft.Azure.Management.Network.Fluent.NetworkSecurityGroup.Update.IUpdate> Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.UpdateDefinition.IWithSourcePort<Microsoft.Azure.Management.Network.Fluent.NetworkSecurityGroup.Update.IUpdate>.FromPortRange(int from, int to) { 
            return this.FromPortRange( from,  to) as Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.UpdateDefinition.IWithDestinationAddress<Microsoft.Azure.Management.Network.Fluent.NetworkSecurityGroup.Update.IUpdate>;
        }

        /// <summary>
        /// Makes this rule apply to any source port.
        /// </summary>
        /// <returns>the next stage of the security rule definition</returns>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.UpdateDefinition.IWithDestinationAddress<Microsoft.Azure.Management.Network.Fluent.NetworkSecurityGroup.Update.IUpdate> Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.UpdateDefinition.IWithSourcePort<Microsoft.Azure.Management.Network.Fluent.NetworkSecurityGroup.Update.IUpdate>.FromAnyPort() { 
            return this.FromAnyPort() as Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.UpdateDefinition.IWithDestinationAddress<Microsoft.Azure.Management.Network.Fluent.NetworkSecurityGroup.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies the traffic destination address range to which this rule applies.
        /// </summary>
        /// <param name="cidr">cidr an IP address range expressed in the CIDR notation</param>
        /// <returns>the next stage of the security rule definition</returns>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Definition.IWithDestinationPort<Microsoft.Azure.Management.Network.Fluent.NetworkSecurityGroup.Definition.IWithCreate> Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Definition.IWithDestinationAddress<Microsoft.Azure.Management.Network.Fluent.NetworkSecurityGroup.Definition.IWithCreate>.ToAddress(string cidr) { 
            return this.ToAddress( cidr) as Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Definition.IWithDestinationPort<Microsoft.Azure.Management.Network.Fluent.NetworkSecurityGroup.Definition.IWithCreate>;
        }

        /// <summary>
        /// Makes the rule apply to any traffic destination address.
        /// </summary>
        /// <returns>the next stage of the security rule definition</returns>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Definition.IWithDestinationPort<Microsoft.Azure.Management.Network.Fluent.NetworkSecurityGroup.Definition.IWithCreate> Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Definition.IWithDestinationAddress<Microsoft.Azure.Management.Network.Fluent.NetworkSecurityGroup.Definition.IWithCreate>.ToAnyAddress() { 
            return this.ToAnyAddress() as Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Definition.IWithDestinationPort<Microsoft.Azure.Management.Network.Fluent.NetworkSecurityGroup.Definition.IWithCreate>;
        }

        /// <summary>
        /// Specifies the traffic destination address range to which this rule applies.
        /// </summary>
        /// <param name="cidr">cidr an IP address range expressed in the CIDR notation</param>
        /// <returns>the next stage of the security rule definition</returns>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.UpdateDefinition.IWithDestinationPort<Microsoft.Azure.Management.Network.Fluent.NetworkSecurityGroup.Update.IUpdate> Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.UpdateDefinition.IWithDestinationAddress<Microsoft.Azure.Management.Network.Fluent.NetworkSecurityGroup.Update.IUpdate>.ToAddress(string cidr) { 
            return this.ToAddress( cidr) as Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.UpdateDefinition.IWithDestinationPort<Microsoft.Azure.Management.Network.Fluent.NetworkSecurityGroup.Update.IUpdate>;
        }

        /// <summary>
        /// Makes the rule apply to any traffic destination address.
        /// </summary>
        /// <returns>the next stage of the security rule definition</returns>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.UpdateDefinition.IWithDestinationPort<Microsoft.Azure.Management.Network.Fluent.NetworkSecurityGroup.Update.IUpdate> Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.UpdateDefinition.IWithDestinationAddress<Microsoft.Azure.Management.Network.Fluent.NetworkSecurityGroup.Update.IUpdate>.ToAnyAddress() { 
            return this.ToAnyAddress() as Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.UpdateDefinition.IWithDestinationPort<Microsoft.Azure.Management.Network.Fluent.NetworkSecurityGroup.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies the destination port range to which this rule applies.
        /// </summary>
        /// <param name="from">from the starting port number</param>
        /// <param name="to">to the ending port number</param>
        /// <returns>the next stage of the security rule definition</returns>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Definition.IWithProtocol<Microsoft.Azure.Management.Network.Fluent.NetworkSecurityGroup.Definition.IWithCreate> Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Definition.IWithDestinationPort<Microsoft.Azure.Management.Network.Fluent.NetworkSecurityGroup.Definition.IWithCreate>.ToPortRange(int from, int to) { 
            return this.ToPortRange( from,  to) as Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Definition.IWithProtocol<Microsoft.Azure.Management.Network.Fluent.NetworkSecurityGroup.Definition.IWithCreate>;
        }

        /// <summary>
        /// Specifies the destination port to which this rule applies.
        /// </summary>
        /// <param name="port">port the destination port number</param>
        /// <returns>the next stage of the security rule definition</returns>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Definition.IWithProtocol<Microsoft.Azure.Management.Network.Fluent.NetworkSecurityGroup.Definition.IWithCreate> Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Definition.IWithDestinationPort<Microsoft.Azure.Management.Network.Fluent.NetworkSecurityGroup.Definition.IWithCreate>.ToPort(int port) { 
            return this.ToPort( port) as Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Definition.IWithProtocol<Microsoft.Azure.Management.Network.Fluent.NetworkSecurityGroup.Definition.IWithCreate>;
        }

        /// <summary>
        /// Makes this rule apply to any destination port.
        /// </summary>
        /// <returns>the next stage of the security rule definition</returns>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Definition.IWithProtocol<Microsoft.Azure.Management.Network.Fluent.NetworkSecurityGroup.Definition.IWithCreate> Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Definition.IWithDestinationPort<Microsoft.Azure.Management.Network.Fluent.NetworkSecurityGroup.Definition.IWithCreate>.ToAnyPort() { 
            return this.ToAnyPort() as Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Definition.IWithProtocol<Microsoft.Azure.Management.Network.Fluent.NetworkSecurityGroup.Definition.IWithCreate>;
        }

        /// <summary>
        /// Specifies the destination port range to which this rule applies.
        /// </summary>
        /// <param name="from">from the starting port number</param>
        /// <param name="to">to the ending port number</param>
        /// <returns>the next stage of the security rule definition</returns>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.UpdateDefinition.IWithProtocol<Microsoft.Azure.Management.Network.Fluent.NetworkSecurityGroup.Update.IUpdate> Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.UpdateDefinition.IWithDestinationPort<Microsoft.Azure.Management.Network.Fluent.NetworkSecurityGroup.Update.IUpdate>.ToPortRange(int from, int to) { 
            return this.ToPortRange( from,  to) as Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.UpdateDefinition.IWithProtocol<Microsoft.Azure.Management.Network.Fluent.NetworkSecurityGroup.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies the destination port to which this rule applies.
        /// </summary>
        /// <param name="port">port the destination port number</param>
        /// <returns>the next stage of the security rule definition</returns>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.UpdateDefinition.IWithProtocol<Microsoft.Azure.Management.Network.Fluent.NetworkSecurityGroup.Update.IUpdate> Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.UpdateDefinition.IWithDestinationPort<Microsoft.Azure.Management.Network.Fluent.NetworkSecurityGroup.Update.IUpdate>.ToPort(int port) { 
            return this.ToPort( port) as Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.UpdateDefinition.IWithProtocol<Microsoft.Azure.Management.Network.Fluent.NetworkSecurityGroup.Update.IUpdate>;
        }

        /// <summary>
        /// Makes this rule apply to any destination port.
        /// </summary>
        /// <returns>the next stage of the security rule definition</returns>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.UpdateDefinition.IWithProtocol<Microsoft.Azure.Management.Network.Fluent.NetworkSecurityGroup.Update.IUpdate> Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.UpdateDefinition.IWithDestinationPort<Microsoft.Azure.Management.Network.Fluent.NetworkSecurityGroup.Update.IUpdate>.ToAnyPort() { 
            return this.ToAnyPort() as Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.UpdateDefinition.IWithProtocol<Microsoft.Azure.Management.Network.Fluent.NetworkSecurityGroup.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies the destination port range to which this rule applies.
        /// </summary>
        /// <param name="from">from the starting port number</param>
        /// <param name="to">to the ending port number</param>
        /// <returns>the next stage of the security rule definition</returns>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Update.IUpdate Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Update.IWithDestinationPort.ToPortRange(int from, int to) { 
            return this.ToPortRange( from,  to) as Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the destination port to which this rule applies.
        /// </summary>
        /// <param name="port">port the destination port number</param>
        /// <returns>the next stage of the security rule definition</returns>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Update.IUpdate Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Update.IWithDestinationPort.ToPort(int port) { 
            return this.ToPort( port) as Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Update.IUpdate;
        }

        /// <summary>
        /// Makes this rule apply to any destination port.
        /// </summary>
        /// <returns>the next stage of the security rule definition</returns>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Update.IUpdate Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Update.IWithDestinationPort.ToAnyPort() { 
            return this.ToAnyPort() as Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Update.IUpdate;
        }

    }
}