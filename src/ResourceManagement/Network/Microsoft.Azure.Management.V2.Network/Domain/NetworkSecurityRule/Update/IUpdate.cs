/**
* Copyright (c) Microsoft Corporation. All rights reserved.
* Licensed under the MIT License. See License.txt in the project root for
* license information.
*/ 

namespace Microsoft.Azure.Management.V2.Network.NetworkSecurityRule.Update
{

    using Microsoft.Azure.Management.V2.Network.NetworkSecurityGroup.Update;
    using Microsoft.Azure.Management.V2.Resource.Core.ChildResourceActions;
    /// <summary>
    /// The stage of the network rule description allowing the destination port(s) to be specified.
    /// </summary>
    public interface IWithDestinationPort 
    {
        /// <summary>
        /// Specifies the destination port to which this rule applies.
        /// </summary>
        /// <param name="port">port the destination port number</param>
        /// <returns>the next stage of the security rule definition</returns>
        Microsoft.Azure.Management.V2.Network.NetworkSecurityRule.Update.IUpdate ToPort (int port);

        /// <summary>
        /// Makes this rule apply to any destination port.
        /// </summary>
        /// <returns>the next stage of the security rule definition</returns>
        Microsoft.Azure.Management.V2.Network.NetworkSecurityRule.Update.IUpdate ToAnyPort ();

        /// <summary>
        /// Specifies the destination port range to which this rule applies.
        /// </summary>
        /// <param name="from">from the starting port number</param>
        /// <param name="to">to the ending port number</param>
        /// <returns>the next stage of the security rule definition</returns>
        Microsoft.Azure.Management.V2.Network.NetworkSecurityRule.Update.IUpdate ToPortRange (int from, int to);

    }
    /// <summary>
    /// The stage of the network rule description allowing the direction and the access type to be specified.
    /// </summary>
    public interface IWithDirectionAccess 
    {
        /// <summary>
        /// Allows inbound traffic.
        /// </summary>
        /// <returns>the next stage of the security rule definition</returns>
        Microsoft.Azure.Management.V2.Network.NetworkSecurityRule.Update.IUpdate AllowInbound ();

        /// <summary>
        /// Allows outbound traffic.
        /// </summary>
        /// <returns>the next stage of the security rule definition</returns>
        Microsoft.Azure.Management.V2.Network.NetworkSecurityRule.Update.IUpdate AllowOutbound ();

        /// <summary>
        /// Blocks inbound traffic.
        /// </summary>
        /// <returns>the next stage of the security rule definition</returns>
        Microsoft.Azure.Management.V2.Network.NetworkSecurityRule.Update.IUpdate DenyInbound ();

        /// <summary>
        /// Blocks outbound traffic.
        /// </summary>
        /// <returns>the next stage of the security rule definition</returns>
        Microsoft.Azure.Management.V2.Network.NetworkSecurityRule.Update.IUpdate DenyOutbound ();

    }
    /// <summary>
    /// The stage of the network rule description allowing the source address to be specified.
    /// </summary>
    public interface IWithSourceAddress 
    {
        /// <summary>
        /// Specifies the traffic source address prefix to which this rule applies.
        /// </summary>
        /// <param name="cidr">cidr an IP address prefix expressed in the CIDR notation</param>
        /// <returns>the next stage of the security rule definition</returns>
        Microsoft.Azure.Management.V2.Network.NetworkSecurityRule.Update.IUpdate FromAddress (string cidr);

        /// <summary>
        /// Specifies that the rule applies to any traffic source address.
        /// </summary>
        /// <returns>the next stage of the security rule definition</returns>
        Microsoft.Azure.Management.V2.Network.NetworkSecurityRule.Update.IUpdate FromAnyAddress ();

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
        ISettable<Microsoft.Azure.Management.V2.Network.NetworkSecurityGroup.Update.IUpdate>
    {
        /// <summary>
        /// Specifies the priority to assign to this security rule.
        /// <p>
        /// Security rules are applied in the order of their assigned priority.
        /// </summary>
        /// <param name="priority">priority the priority number in the range 100 to 4096</param>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.V2.Network.NetworkSecurityRule.Update.IUpdate WithPriority (int priority);

        /// <summary>
        /// Specifies a description for this security rule.
        /// </summary>
        /// <param name="description">description a text description to associate with this security rule</param>
        /// <returns>the next stage</returns>
        Microsoft.Azure.Management.V2.Network.NetworkSecurityRule.Update.IUpdate WithDescription (string description);

    }
    /// <summary>
    /// The stage of the network rule description allowing the source port(s) to be specified.
    /// </summary>
    public interface IWithSourcePort 
    {
        /// <summary>
        /// Specifies the source port to which this rule applies.
        /// </summary>
        /// <param name="port">port the source port number</param>
        /// <returns>the next stage of the security rule definition</returns>
        Microsoft.Azure.Management.V2.Network.NetworkSecurityRule.Update.IUpdate FromPort (int port);

        /// <summary>
        /// Makes this rule apply to any source port.
        /// </summary>
        /// <returns>the next stage of the security rule definition</returns>
        Microsoft.Azure.Management.V2.Network.NetworkSecurityRule.Update.IUpdate FromAnyPort ();

        /// <summary>
        /// Specifies the source port range to which this rule applies.
        /// </summary>
        /// <param name="from">from the starting port number</param>
        /// <param name="to">to the ending port number</param>
        /// <returns>the next stage of the security rule definition</returns>
        Microsoft.Azure.Management.V2.Network.NetworkSecurityRule.Update.IUpdate FromPortRange (int from, int to);

    }
    /// <summary>
    /// The stage of the security rule description allowing the protocol that the rule applies to to be specified.
    /// </summary>
    public interface IWithProtocol 
    {
        /// <summary>
        /// Specifies the protocol that this rule applies to.
        /// </summary>
        /// <param name="protocol">protocol one of the supported protocols</param>
        /// <returns>the next stage of the security rule definition</returns>
        Microsoft.Azure.Management.V2.Network.NetworkSecurityRule.Update.IUpdate WithProtocol (string protocol);

        /// <summary>
        /// Makes this rule apply to any supported protocol.
        /// </summary>
        /// <returns>the next stage of the security rule definition</returns>
        Microsoft.Azure.Management.V2.Network.NetworkSecurityRule.Update.IUpdate WithAnyProtocol ();

    }
    /// <summary>
    /// The stage of the network rule description allowing the destination address to be specified.
    /// </summary>
    public interface IWithDestinationAddress 
    {
        /// <summary>
        /// Specifies the traffic destination address range to which this rule applies.
        /// </summary>
        /// <param name="cidr">cidr an IP address range expressed in the CIDR notation</param>
        /// <returns>the next stage of the security rule definition</returns>
        Microsoft.Azure.Management.V2.Network.NetworkSecurityRule.Update.IUpdate ToAddress (string cidr);

        /// <summary>
        /// Makes the rule apply to any traffic destination address.
        /// </summary>
        /// <returns>the next stage of the security rule definition</returns>
        Microsoft.Azure.Management.V2.Network.NetworkSecurityRule.Update.IUpdate ToAnyAddress ();

    }
}