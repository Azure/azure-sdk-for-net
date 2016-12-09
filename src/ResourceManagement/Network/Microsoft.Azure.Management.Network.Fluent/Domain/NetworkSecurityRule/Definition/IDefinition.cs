// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Definition
{
    using Microsoft.Azure.Management.Resource.Fluent.Core.ChildResource.Definition;

    /// <summary>
    /// The first stage of a security rule definition.
    /// </summary>
    public interface IBlank<ParentT>  :
        IWithDirectionAccess<ParentT>
    {
    }

    /// <summary>
    /// The stage of the network rule definition allowing the priority to be specified.
    /// </summary>
    public interface IWithPriority<ParentT> 
    {
        /// <summary>
        /// Specifies the priority to assign to this rule.
        /// <p>
        /// Security rules are applied in the order of their assigned priority.
        /// </summary>
        /// <param name="priority">The priority number in the range 100 to 4096.</param>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Definition.IWithAttach<ParentT> WithPriority(int priority);
    }

    /// <summary>
    /// The stage of the network rule definition allowing the destination port(s) to be specified.
    /// </summary>
    public interface IWithDestinationPort<ParentT> 
    {
        /// <summary>
        /// Specifies the destination port to which this rule applies.
        /// </summary>
        /// <param name="port">The destination port number.</param>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Definition.IWithProtocol<ParentT> ToPort(int port);

        /// <summary>
        /// Specifies the destination port range to which this rule applies.
        /// </summary>
        /// <param name="from">The starting port number.</param>
        /// <param name="to">The ending port number.</param>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Definition.IWithProtocol<ParentT> ToPortRange(int from, int to);

        /// <summary>
        /// Makes this rule apply to any destination port.
        /// </summary>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Definition.IWithProtocol<ParentT> ToAnyPort();
    }

    /// <summary>
    /// The final stage of the security rule definition.
    /// <p>
    /// At this stage, any remaining optional settings can be specified, or the security rule definition
    /// can be attached to the parent network security group definition using WithAttach.attach().
    /// </summary>
    public interface IWithAttach<ParentT>  :
        IInDefinition<ParentT>,
        IWithPriority<ParentT>,
        IWithDescription<ParentT>
    {
    }

    /// <summary>
    /// The stage of the security rule definition allowing the protocol that the rule applies to to be specified.
    /// </summary>
    public interface IWithProtocol<ParentT> 
    {
        /// <summary>
        /// Makes this rule apply to any supported protocol.
        /// </summary>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Definition.IWithAttach<ParentT> WithAnyProtocol();

        /// <summary>
        /// Specifies the protocol that this rule applies to.
        /// </summary>
        /// <param name="protocol">One of the supported protocols.</param>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Definition.IWithAttach<ParentT> WithProtocol(string protocol);
    }

    /// <summary>
    /// The stage of the network rule definition allowing the source port(s) to be specified.
    /// </summary>
    public interface IWithSourcePort<ParentT> 
    {
        /// <summary>
        /// Specifies the source port to which this rule applies.
        /// </summary>
        /// <param name="port">The source port number.</param>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Definition.IWithDestinationAddress<ParentT> FromPort(int port);

        /// <summary>
        /// Makes this rule apply to any source port.
        /// </summary>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Definition.IWithDestinationAddress<ParentT> FromAnyPort();

        /// <summary>
        /// Specifies the source port range to which this rule applies.
        /// </summary>
        /// <param name="from">The starting port number.</param>
        /// <param name="to">The ending port number.</param>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Definition.IWithDestinationAddress<ParentT> FromPortRange(int from, int to);
    }

    /// <summary>
    /// The stage of the network rule definition allowing the description to be specified.
    /// </summary>
    public interface IWithDescription<ParentT> 
    {
        /// <summary>
        /// Specifies a description for this security rule.
        /// </summary>
        /// <param name="description">The text description to associate with this security rule.</param>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Definition.IWithAttach<ParentT> WithDescription(string description);
    }

    /// <summary>
    /// The entirety of a network security rule definition.
    /// </summary>
    public interface IDefinition<ParentT>  :
        IBlank<ParentT>,
        IWithAttach<ParentT>,
        IWithDirectionAccess<ParentT>,
        IWithSourceAddress<ParentT>,
        IWithSourcePort<ParentT>,
        IWithDestinationAddress<ParentT>,
        IWithDestinationPort<ParentT>,
        IWithProtocol<ParentT>
    {
    }

    /// <summary>
    /// The stage of the network rule definition allowing the source address to be specified.
    /// </summary>
    public interface IWithSourceAddress<ParentT> 
    {
        /// <summary>
        /// Specifies the traffic source address prefix to which this rule applies.
        /// </summary>
        /// <param name="cidr">An IP address prefix expressed in the CIDR notation.</param>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Definition.IWithSourcePort<ParentT> FromAddress(string cidr);

        /// <summary>
        /// Specifies that the rule applies to any traffic source address.
        /// </summary>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Definition.IWithSourcePort<ParentT> FromAnyAddress();
    }

    /// <summary>
    /// The stage of the network rule definition allowing the direction and the access type to be specified.
    /// </summary>
    public interface IWithDirectionAccess<ParentT> 
    {
        /// <summary>
        /// Allows outbound traffic.
        /// </summary>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Definition.IWithSourceAddress<ParentT> AllowOutbound();

        /// <summary>
        /// Allows inbound traffic.
        /// </summary>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Definition.IWithSourceAddress<ParentT> AllowInbound();

        /// <summary>
        /// Blocks inbound traffic.
        /// </summary>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Definition.IWithSourceAddress<ParentT> DenyInbound();

        /// <summary>
        /// Blocks outbound traffic.
        /// </summary>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Definition.IWithSourceAddress<ParentT> DenyOutbound();
    }

    /// <summary>
    /// The stage of the network rule definition allowing the destination address to be specified.
    /// </summary>
    public interface IWithDestinationAddress<ParentT> 
    {
        /// <summary>
        /// Makes the rule apply to any traffic destination address.
        /// </summary>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Definition.IWithDestinationPort<ParentT> ToAnyAddress();

        /// <summary>
        /// Specifies the traffic destination address range to which this rule applies.
        /// </summary>
        /// <param name="cidr">An IP address range expressed in the CIDR notation.</param>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Definition.IWithDestinationPort<ParentT> ToAddress(string cidr);
    }
}