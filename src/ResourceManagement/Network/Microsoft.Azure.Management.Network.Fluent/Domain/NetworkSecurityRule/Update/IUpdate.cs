// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Update
{
    using Microsoft.Azure.Management.Network.Fluent.NetworkSecurityGroup.Update;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ChildResourceActions;

    /// <summary>
    /// The stage of the network rule description allowing the direction and the access type to be specified.
    /// </summary>
    public interface IWithDirectionAccess 
    {
        /// <summary>
        /// Allows outbound traffic.
        /// </summary>
        /// <return>The next stage of the security rule definition.</return>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Update.IUpdate AllowOutbound();

        /// <summary>
        /// Allows inbound traffic.
        /// </summary>
        /// <return>The next stage of the security rule definition.</return>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Update.IUpdate AllowInbound();

        /// <summary>
        /// Blocks inbound traffic.
        /// </summary>
        /// <return>The next stage of the security rule definition.</return>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Update.IUpdate DenyInbound();

        /// <summary>
        /// Blocks outbound traffic.
        /// </summary>
        /// <return>The next stage of the security rule definition.</return>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Update.IUpdate DenyOutbound();
    }

    /// <summary>
    /// The entirety of a security rule update as part of a network security group update.
    /// </summary>
    public interface IUpdate  :
        IWithDirectionAccess,
        IWithSourceAddress,
        IWithSourcePort,
        IWithDestinationAddress,
        IWithDestinationPort,
        IWithProtocol,
        ISettable<Microsoft.Azure.Management.Network.Fluent.NetworkSecurityGroup.Update.IUpdate>
    {
        /// <summary>
        /// Specifies the priority to assign to this security rule.
        /// Security rules are applied in the order of their assigned priority.
        /// </summary>
        /// <param name="priority">The priority number in the range 100 to 4096.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Update.IUpdate WithPriority(int priority);

        /// <summary>
        /// Specifies a description for this security rule.
        /// </summary>
        /// <param name="description">A text description to associate with this security rule.</param>
        /// <return>The next stage.</return>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Update.IUpdate WithDescription(string description);
    }

    /// <summary>
    /// The stage of the network rule description allowing the destination port(s) to be specified.
    /// </summary>
    public interface IWithDestinationPort 
    {
        /// <summary>
        /// Specifies the destination port to which this rule applies.
        /// </summary>
        /// <param name="port">The destination port number.</param>
        /// <return>The next stage of the security rule definition.</return>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Update.IUpdate ToPort(int port);

        /// <summary>
        /// Specifies the destination port range to which this rule applies.
        /// </summary>
        /// <param name="from">The starting port number.</param>
        /// <param name="to">The ending port number.</param>
        /// <return>The next stage of the security rule definition.</return>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Update.IUpdate ToPortRange(int from, int to);

        /// <summary>
        /// Makes this rule apply to any destination port.
        /// </summary>
        /// <return>The next stage of the security rule definition.</return>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Update.IUpdate ToAnyPort();
    }

    /// <summary>
    /// The stage of the security rule description allowing the protocol that the rule applies to to be specified.
    /// </summary>
    public interface IWithProtocol 
    {
        /// <summary>
        /// Makes this rule apply to any supported protocol.
        /// </summary>
        /// <return>The next stage of the security rule definition.</return>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Update.IUpdate WithAnyProtocol();

        /// <summary>
        /// Specifies the protocol that this rule applies to.
        /// </summary>
        /// <param name="protocol">One of the supported protocols.</param>
        /// <return>The next stage of the security rule definition.</return>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Update.IUpdate WithProtocol(string protocol);
    }

    /// <summary>
    /// The stage of the network rule description allowing the destination address to be specified.
    /// </summary>
    public interface IWithDestinationAddress 
    {
        /// <summary>
        /// Makes the rule apply to any traffic destination address.
        /// </summary>
        /// <return>The next stage of the security rule definition.</return>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Update.IUpdate ToAnyAddress();

        /// <summary>
        /// Specifies the traffic destination address range to which this rule applies.
        /// </summary>
        /// <param name="cidr">An IP address range expressed in the CIDR notation.</param>
        /// <return>The next stage of the security rule definition.</return>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Update.IUpdate ToAddress(string cidr);
    }

    /// <summary>
    /// The stage of the network rule description allowing the source address to be specified.
    /// </summary>
    public interface IWithSourceAddress 
    {
        /// <summary>
        /// Specifies the traffic source address prefix to which this rule applies.
        /// </summary>
        /// <param name="cidr">An IP address prefix expressed in the CIDR notation.</param>
        /// <return>The next stage of the security rule definition.</return>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Update.IUpdate FromAddress(string cidr);

        /// <summary>
        /// Specifies that the rule applies to any traffic source address.
        /// </summary>
        /// <return>The next stage of the security rule definition.</return>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Update.IUpdate FromAnyAddress();
    }

    /// <summary>
    /// The stage of the network rule description allowing the source port(s) to be specified.
    /// </summary>
    public interface IWithSourcePort 
    {
        /// <summary>
        /// Specifies the source port to which this rule applies.
        /// </summary>
        /// <param name="port">The source port number.</param>
        /// <return>The next stage of the security rule definition.</return>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Update.IUpdate FromPort(int port);

        /// <summary>
        /// Makes this rule apply to any source port.
        /// </summary>
        /// <return>The next stage of the security rule definition.</return>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Update.IUpdate FromAnyPort();

        /// <summary>
        /// Specifies the source port range to which this rule applies.
        /// </summary>
        /// <param name="from">The starting port number.</param>
        /// <param name="to">The ending port number.</param>
        /// <return>The next stage of the security rule definition.</return>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Update.IUpdate FromPortRange(int from, int to);
    }
}