// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.UpdateDefinition
{
    using Microsoft.Azure.Management.Resource.Fluent.Core.ChildResource.Update;

    /// <summary>
    /// The stage of the network rule definition allowing the destination address to be specified.
    /// </summary>
    /// <typeparam name="Parent">The return type of the final WithAttach.attach().</typeparam>
    public interface IWithDestinationAddress<ParentT> 
    {
        /// <summary>
        /// Makes the rule apply to any traffic destination address.
        /// </summary>
        /// <return>The next stage of the security rule definition.</return>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.UpdateDefinition.IWithDestinationPort<ParentT> ToAnyAddress();

        /// <summary>
        /// Specifies the traffic destination address range to which this rule applies.
        /// </summary>
        /// <param name="cidr">An IP address range expressed in the CIDR notation.</param>
        /// <return>The next stage of the security rule definition.</return>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.UpdateDefinition.IWithDestinationPort<ParentT> ToAddress(string cidr);
    }

    /// <summary>
    /// The final stage of the security rule definition.
    /// At this stage, any remaining optional settings can be specified, or the security rule definition
    /// can be attached to the parent network security group definition using WithAttach.attach().
    /// </summary>
    /// <typeparam name="Parent">The return type of WithAttach.attach().</typeparam>
    public interface IWithAttach<ParentT>  :
        IInUpdate<ParentT>
    {
        /// <summary>
        /// Specifies the priority to assign to this rule.
        /// Security rules are applied in the order of their assigned priority.
        /// </summary>
        /// <param name="priority">The priority number in the range 100 to 4096.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.UpdateDefinition.IWithAttach<ParentT> WithPriority(int priority);

        /// <summary>
        /// Specifies a description for this security rule.
        /// </summary>
        /// <param name="descrtiption">A text description to associate with the security rule.</param>
        /// <return>The next stage.</return>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.UpdateDefinition.IWithAttach<ParentT> WithDescription(string descrtiption);
    }

    /// <summary>
    /// The stage of the network rule definition allowing the source address to be specified.
    /// </summary>
    /// <typeparam name="Parent">The return type of the final WithAttach.attach().</typeparam>
    public interface IWithSourceAddress<ParentT> 
    {
        /// <summary>
        /// Specifies the traffic source address prefix to which this rule applies.
        /// </summary>
        /// <param name="cidr">An IP address prefix expressed in the CIDR notation.</param>
        /// <return>The next stage of the security rule definition.</return>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.UpdateDefinition.IWithSourcePort<ParentT> FromAddress(string cidr);

        /// <summary>
        /// Specifies that the rule applies to any traffic source address.
        /// </summary>
        /// <return>The next stage of the security rule definition.</return>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.UpdateDefinition.IWithSourcePort<ParentT> FromAnyAddress();
    }

    /// <summary>
    /// The stage of the network rule description allowing the direction and the access type to be specified.
    /// </summary>
    /// <typeparam name="Parent">The return type of the final WithAttach.attach().</typeparam>
    public interface IWithDirectionAccess<ParentT> 
    {
        /// <summary>
        /// Allows outbound traffic.
        /// </summary>
        /// <return>The next stage of the security rule definition.</return>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.UpdateDefinition.IWithSourceAddress<ParentT> AllowOutbound();

        /// <summary>
        /// Allows inbound traffic.
        /// </summary>
        /// <return>The next stage of the security rule definition.</return>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.UpdateDefinition.IWithSourceAddress<ParentT> AllowInbound();

        /// <summary>
        /// Blocks inbound traffic.
        /// </summary>
        /// <return>The next stage of the security rule definition.</return>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.UpdateDefinition.IWithSourceAddress<ParentT> DenyInbound();

        /// <summary>
        /// Blocks outbound traffic.
        /// </summary>
        /// <return>The next stage of the security rule definition.</return>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.UpdateDefinition.IWithSourceAddress<ParentT> DenyOutbound();
    }

    /// <summary>
    /// The entirety of a network security rule definition as part of a network security group update.
    /// </summary>
    /// <typeparam name="Parent">The return type of the final UpdateDefinitionStages.WithAttach.attach().</typeparam>
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

    /// <summary>
    /// The stage of the security rule definition allowing the protocol that the rule applies to to be specified.
    /// </summary>
    /// <typeparam name="Parent">The return type of the final WithAttach.attach().</typeparam>
    public interface IWithProtocol<ParentT> 
    {
        /// <summary>
        /// Makes this rule apply to any supported protocol.
        /// </summary>
        /// <return>The next stage of the security rule definition.</return>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.UpdateDefinition.IWithAttach<ParentT> WithAnyProtocol();

        /// <summary>
        /// Specifies the protocol that this rule applies to.
        /// </summary>
        /// <param name="protocol">One of the supported protocols.</param>
        /// <return>The next stage of the security rule definition.</return>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.UpdateDefinition.IWithAttach<ParentT> WithProtocol(string protocol);
    }

    /// <summary>
    /// The stage of the network rule definition allowing the destination port(s) to be specified.
    /// </summary>
    /// <typeparam name="Parent">The return type of the final WithAttach.attach().</typeparam>
    public interface IWithDestinationPort<ParentT> 
    {
        /// <summary>
        /// Specifies the destination port to which this rule applies.
        /// </summary>
        /// <param name="port">The destination port number.</param>
        /// <return>The next stage of the security rule definition.</return>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.UpdateDefinition.IWithProtocol<ParentT> ToPort(int port);

        /// <summary>
        /// Specifies the destination port range to which this rule applies.
        /// </summary>
        /// <param name="from">The starting port number.</param>
        /// <param name="to">The ending port number.</param>
        /// <return>The next stage of the security rule definition.</return>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.UpdateDefinition.IWithProtocol<ParentT> ToPortRange(int from, int to);

        /// <summary>
        /// Makes this rule apply to any destination port.
        /// </summary>
        /// <return>The next stage of the security rule definition.</return>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.UpdateDefinition.IWithProtocol<ParentT> ToAnyPort();
    }

    /// <summary>
    /// The stage of the network rule definition allowing the source port(s) to be specified.
    /// </summary>
    /// <typeparam name="Parent">The return type of the final WithAttach.attach().</typeparam>
    public interface IWithSourcePort<ParentT> 
    {
        /// <summary>
        /// Specifies the source port to which this rule applies.
        /// </summary>
        /// <param name="port">The source port number.</param>
        /// <return>The next stage of the security rule definition.</return>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.UpdateDefinition.IWithDestinationAddress<ParentT> FromPort(int port);

        /// <summary>
        /// Makes this rule apply to any source port.
        /// </summary>
        /// <return>The next stage of the security rule definition.</return>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.UpdateDefinition.IWithDestinationAddress<ParentT> FromAnyPort();

        /// <summary>
        /// Specifies the source port range to which this rule applies.
        /// </summary>
        /// <param name="from">The starting port number.</param>
        /// <param name="to">The ending port number.</param>
        /// <return>The next stage of the security rule definition.</return>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.UpdateDefinition.IWithDestinationAddress<ParentT> FromPortRange(int from, int to);
    }

    /// <summary>
    /// The first stage of a security rule description as part of an update of a networking security group.
    /// </summary>
    /// <typeparam name="Parent">The return type of the final Attachable.attach().</typeparam>
    public interface IBlank<ParentT>  :
        IWithDirectionAccess<ParentT>
    {
    }
}