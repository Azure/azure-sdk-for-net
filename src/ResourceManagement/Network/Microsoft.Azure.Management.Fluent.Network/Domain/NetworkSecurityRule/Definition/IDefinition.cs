// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Fluent.Network.NetworkSecurityRule.Definition
{

    using Microsoft.Azure.Management.Fluent.Resource.Core.ChildResource.Definition;
    /// <summary>
    /// The stage of the network rule definition allowing the source port(s) to be specified.
    /// @param <ParentT> the return type of the final {@link WithAttach#attach()}
    /// </summary>
    public interface IWithSourcePort<ParentT> 
    {
        /// <summary>
        /// Specifies the source port to which this rule applies.
        /// </summary>
        /// <param name="port">port the source port number</param>
        /// <returns>the next stage of the security rule definition</returns>
        Microsoft.Azure.Management.Fluent.Network.NetworkSecurityRule.Definition.IWithDestinationAddress<ParentT> FromPort(int port);

        /// <summary>
        /// Makes this rule apply to any source port.
        /// </summary>
        /// <returns>the next stage of the security rule definition</returns>
        Microsoft.Azure.Management.Fluent.Network.NetworkSecurityRule.Definition.IWithDestinationAddress<ParentT> FromAnyPort();

        /// <summary>
        /// Specifies the source port range to which this rule applies.
        /// </summary>
        /// <param name="from">from the starting port number</param>
        /// <param name="to">to the ending port number</param>
        /// <returns>the next stage of the security rule definition</returns>
        Microsoft.Azure.Management.Fluent.Network.NetworkSecurityRule.Definition.IWithDestinationAddress<ParentT> FromPortRange(int from, int to);

    }
    /// <summary>
    /// The final stage of the security rule definition.
    /// <p>
    /// At this stage, any remaining optional settings can be specified, or the security rule definition
    /// can be attached to the parent network security group definition using {@link WithAttach#attach()}.
    /// @param <ParentT> the return type of {@link WithAttach#attach()}
    /// </summary>
    public interface IWithAttach<ParentT>  :
        IInDefinition<ParentT>,
        IWithPriority<ParentT>,
        IWithDescription<ParentT>
    {
    }
    /// <summary>
    /// The stage of the network rule definition allowing the description to be specified.
    /// @param <ParentT> the return type of the final {@link WithAttach#attach()}
    /// </summary>
    public interface IWithDescription<ParentT> 
    {
        /// <summary>
        /// Specifies a description for this security rule.
        /// </summary>
        /// <param name="description">description the text description to associate with this security rule</param>
        /// <returns>the next stage</returns>
        Microsoft.Azure.Management.Fluent.Network.NetworkSecurityRule.Definition.IWithAttach<ParentT> WithDescription(string description);

    }
    /// <summary>
    /// The stage of the network rule definition allowing the source address to be specified.
    /// @param <ParentT> the return type of the final {@link WithAttach#attach()}
    /// </summary>
    public interface IWithSourceAddress<ParentT> 
    {
        /// <summary>
        /// Specifies the traffic source address prefix to which this rule applies.
        /// </summary>
        /// <param name="cidr">cidr an IP address prefix expressed in the CIDR notation</param>
        /// <returns>the next stage of the security rule definition</returns>
        Microsoft.Azure.Management.Fluent.Network.NetworkSecurityRule.Definition.IWithSourcePort<ParentT> FromAddress(string cidr);

        /// <summary>
        /// Specifies that the rule applies to any traffic source address.
        /// </summary>
        /// <returns>the next stage of the security rule definition</returns>
        Microsoft.Azure.Management.Fluent.Network.NetworkSecurityRule.Definition.IWithSourcePort<ParentT> FromAnyAddress();

    }
    /// <summary>
    /// The entirety of a network security rule definition.
    /// @param <ParentT> the return type of the final {@link Attachable#attach()}
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
    /// The stage of the network rule definition allowing the destination port(s) to be specified.
    /// @param <ParentT> the return type of the final {@link WithAttach#attach()}
    /// </summary>
    public interface IWithDestinationPort<ParentT> 
    {
        /// <summary>
        /// Specifies the destination port to which this rule applies.
        /// </summary>
        /// <param name="port">port the destination port number</param>
        /// <returns>the next stage of the security rule definition</returns>
        Microsoft.Azure.Management.Fluent.Network.NetworkSecurityRule.Definition.IWithProtocol<ParentT> ToPort(int port);

        /// <summary>
        /// Makes this rule apply to any destination port.
        /// </summary>
        /// <returns>the next stage of the security rule definition</returns>
        Microsoft.Azure.Management.Fluent.Network.NetworkSecurityRule.Definition.IWithProtocol<ParentT> ToAnyPort();

        /// <summary>
        /// Specifies the destination port range to which this rule applies.
        /// </summary>
        /// <param name="from">from the starting port number</param>
        /// <param name="to">to the ending port number</param>
        /// <returns>the next stage of the security rule definition</returns>
        Microsoft.Azure.Management.Fluent.Network.NetworkSecurityRule.Definition.IWithProtocol<ParentT> ToPortRange(int from, int to);

    }
    /// <summary>
    /// The first stage of a security rule definition.
    /// @param <ParentT> the return type of the final {@link WithAttach#attach()}
    /// </summary>
    public interface IBlank<ParentT>  :
        IWithDirectionAccess<ParentT>
    {
    }
    /// <summary>
    /// The stage of the network rule definition allowing the priority to be specified.
    /// @param <ParentT> the return type of the final {@link WithAttach#attach()}
    /// </summary>
    public interface IWithPriority<ParentT> 
    {
        /// <summary>
        /// Specifies the priority to assign to this rule.
        /// <p>
        /// Security rules are applied in the order of their assigned priority.
        /// </summary>
        /// <param name="priority">priority the priority number in the range 100 to 4096</param>
        /// <returns>the next stage</returns>
        Microsoft.Azure.Management.Fluent.Network.NetworkSecurityRule.Definition.IWithAttach<ParentT> WithPriority(int priority);

    }
    /// <summary>
    /// The stage of the security rule definition allowing the protocol that the rule applies to to be specified.
    /// @param <ParentT> the return type of the final {@link WithAttach#attach()}
    /// </summary>
    public interface IWithProtocol<ParentT> 
    {
        /// <summary>
        /// Specifies the protocol that this rule applies to.
        /// </summary>
        /// <param name="protocol">protocol one of the supported protocols</param>
        /// <returns>the next stage of the security rule definition</returns>
        Microsoft.Azure.Management.Fluent.Network.NetworkSecurityRule.Definition.IWithAttach<ParentT> WithProtocol(string protocol);

        /// <summary>
        /// Makes this rule apply to any supported protocol.
        /// </summary>
        /// <returns>the next stage of the security rule definition</returns>
        Microsoft.Azure.Management.Fluent.Network.NetworkSecurityRule.Definition.IWithAttach<ParentT> WithAnyProtocol();

    }
    /// <summary>
    /// The stage of the network rule definition allowing the direction and the access type to be specified.
    /// @param <ParentT> the return type of the final {@link WithAttach#attach()}
    /// </summary>
    public interface IWithDirectionAccess<ParentT> 
    {
        /// <summary>
        /// Allows inbound traffic.
        /// </summary>
        /// <returns>the next stage of the security rule definition</returns>
        Microsoft.Azure.Management.Fluent.Network.NetworkSecurityRule.Definition.IWithSourceAddress<ParentT> AllowInbound();

        /// <summary>
        /// Allows outbound traffic.
        /// </summary>
        /// <returns>the next stage of the security rule definition</returns>
        Microsoft.Azure.Management.Fluent.Network.NetworkSecurityRule.Definition.IWithSourceAddress<ParentT> AllowOutbound();

        /// <summary>
        /// Blocks inbound traffic.
        /// </summary>
        /// <returns>the next stage of the security rule definition</returns>
        Microsoft.Azure.Management.Fluent.Network.NetworkSecurityRule.Definition.IWithSourceAddress<ParentT> DenyInbound();

        /// <summary>
        /// Blocks outbound traffic.
        /// </summary>
        /// <returns>the next stage of the security rule definition</returns>
        Microsoft.Azure.Management.Fluent.Network.NetworkSecurityRule.Definition.IWithSourceAddress<ParentT> DenyOutbound();

    }
    /// <summary>
    /// The stage of the network rule definition allowing the destination address to be specified.
    /// @param <ParentT> the return type of the final {@link WithAttach#attach()}
    /// </summary>
    public interface IWithDestinationAddress<ParentT> 
    {
        /// <summary>
        /// Specifies the traffic destination address range to which this rule applies.
        /// </summary>
        /// <param name="cidr">cidr an IP address range expressed in the CIDR notation</param>
        /// <returns>the next stage of the security rule definition</returns>
        Microsoft.Azure.Management.Fluent.Network.NetworkSecurityRule.Definition.IWithDestinationPort<ParentT> ToAddress(string cidr);

        /// <summary>
        /// Makes the rule apply to any traffic destination address.
        /// </summary>
        /// <returns>the next stage of the security rule definition</returns>
        Microsoft.Azure.Management.Fluent.Network.NetworkSecurityRule.Definition.IWithDestinationPort<ParentT> ToAnyAddress();

    }
}