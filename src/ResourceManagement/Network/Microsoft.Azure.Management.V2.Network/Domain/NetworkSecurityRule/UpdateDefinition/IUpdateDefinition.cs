// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Fluent.Network.NetworkSecurityRule.UpdateDefinition
{

    using Microsoft.Azure.Management.Fluent.Resource.Core.ChildResource.Update;
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
        IWithSourcePort<ParentT> FromAddress (string cidr);

        /// <summary>
        /// Specifies that the rule applies to any traffic source address.
        /// </summary>
        /// <returns>the next stage of the security rule definition</returns>
        IWithSourcePort<ParentT> FromAnyAddress { get; }

    }
    /// <summary>
    /// The final stage of the security rule definition.
    /// <p>
    /// At this stage, any remaining optional settings can be specified, or the security rule definition
    /// can be attached to the parent network security group definition using {@link WithAttach#attach()}.
    /// @param <ParentT> the return type of {@link WithAttach#attach()}
    /// </summary>
    public interface IWithAttach<ParentT>  :
        IInUpdate<ParentT>
    {
        /// <summary>
        /// Specifies the priority to assign to this rule.
        /// <p>
        /// Security rules are applied in the order of their assigned priority.
        /// </summary>
        /// <param name="priority">priority the priority number in the range 100 to 4096</param>
        /// <returns>the next stage of the update</returns>
        IWithAttach<ParentT> WithPriority (int priority);

        /// <summary>
        /// Specifies a description for this security rule.
        /// </summary>
        /// <param name="descrtiption">descrtiption a text description to associate with the security rule</param>
        /// <returns>the next stage</returns>
        IWithAttach<ParentT> WithDescription (string descrtiption);

    }
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
        IWithDestinationAddress<ParentT> FromPort (int port);

        /// <summary>
        /// Makes this rule apply to any source port.
        /// </summary>
        /// <returns>the next stage of the security rule definition</returns>
        IWithDestinationAddress<ParentT> FromAnyPort { get; }

        /// <summary>
        /// Specifies the source port range to which this rule applies.
        /// </summary>
        /// <param name="from">from the starting port number</param>
        /// <param name="to">to the ending port number</param>
        /// <returns>the next stage of the security rule definition</returns>
        IWithDestinationAddress<ParentT> FromPortRange (int from, int to);

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
        IWithAttach<ParentT> WithProtocol (string protocol);

        /// <summary>
        /// Makes this rule apply to any supported protocol.
        /// </summary>
        /// <returns>the next stage of the security rule definition</returns>
        IWithAttach<ParentT> WithAnyProtocol ();

    }
    /// <summary>
    /// The first stage of a security rule description as part of an update of a networking security group.
    /// @param <ParentT> the return type of the final {@link Attachable#attach()}
    /// </summary>
    public interface IBlank<ParentT>  :
        IWithDirectionAccess<ParentT>
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
        IWithProtocol<ParentT> ToPort (int port);

        /// <summary>
        /// Makes this rule apply to any destination port.
        /// </summary>
        /// <returns>the next stage of the security rule definition</returns>
        IWithProtocol<ParentT> ToAnyPort { get; }

        /// <summary>
        /// Specifies the destination port range to which this rule applies.
        /// </summary>
        /// <param name="from">from the starting port number</param>
        /// <param name="to">to the ending port number</param>
        /// <returns>the next stage of the security rule definition</returns>
        IWithProtocol<ParentT> ToPortRange (int from, int to);

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
        IWithDestinationPort<ParentT> ToAddress (string cidr);

        /// <summary>
        /// Makes the rule apply to any traffic destination address.
        /// </summary>
        /// <returns>the next stage of the security rule definition</returns>
        IWithDestinationPort<ParentT> ToAnyAddress { get; }

    }
    /// <summary>
    /// The stage of the network rule description allowing the direction and the access type to be specified.
    /// @param <ParentT> the return type of the final {@link WithAttach#attach()}
    /// </summary>
    public interface IWithDirectionAccess<ParentT> 
    {
        /// <summary>
        /// Allows inbound traffic.
        /// </summary>
        /// <returns>the next stage of the security rule definition</returns>
        IWithSourceAddress<ParentT> AllowInbound { get; }

        /// <summary>
        /// Allows outbound traffic.
        /// </summary>
        /// <returns>the next stage of the security rule definition</returns>
        IWithSourceAddress<ParentT> AllowOutbound { get; }

        /// <summary>
        /// Blocks inbound traffic.
        /// </summary>
        /// <returns>the next stage of the security rule definition</returns>
        IWithSourceAddress<ParentT> DenyInbound { get; }

        /// <summary>
        /// Blocks outbound traffic.
        /// </summary>
        /// <returns>the next stage of the security rule definition</returns>
        IWithSourceAddress<ParentT> DenyOutbound { get; }

    }
    /// <summary>
    /// The entirety of a network security rule definition as part of a network security group update.
    /// @param <ParentT> the return type of the final {@link UpdateDefinitionStages.WithAttach#attach()}
    /// </summary>
    public interface IUpdateDefinition<ParentT>  :
        IBlank<ParentT>,
        IWithDirectionAccess<ParentT>,
        IWithSourceAddress<ParentT>,
        IWithSourcePort<ParentT>,
        IWithDestinationAddress<ParentT>,
        IWithDestinationPort<ParentT>,
        IWithProtocol<ParentT>,
        IWithAttach<ParentT>
    {
    }
}