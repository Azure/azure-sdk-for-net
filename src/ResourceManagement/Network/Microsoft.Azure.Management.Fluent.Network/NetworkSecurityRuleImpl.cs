// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Fluent.Network
{
    using Resource.Core;
    using Management.Network.Models;
    using Resource.Core.ChildResourceActions;

    /// <summary>
    /// Implementation for NetworkSecurityRule and its create and update interfaces.
    /// </summary>
    public partial class NetworkSecurityRuleImpl  :
        ChildResource<SecurityRuleInner, NetworkSecurityGroupImpl, INetworkSecurityGroup>,
        INetworkSecurityRule,
        NetworkSecurityRule.Definition.IDefinition<NetworkSecurityGroup.Definition.IWithCreate>,
        NetworkSecurityRule.UpdateDefinition.IUpdateDefinition<NetworkSecurityGroup.Update.IUpdate>,
        NetworkSecurityRule.Update.IUpdate
    {
        internal NetworkSecurityRuleImpl (SecurityRuleInner inner, NetworkSecurityGroupImpl parent) : base(inner.Name, inner, parent)
        {
        }

        #region Accessors
        override public string Name()
        {
            return Inner.Name;
        }

        internal string Direction()
        {
            return Inner.Direction;
        }

        internal string Protocol()
        {
            return Inner.Protocol;
        }

        internal string Access()
        {
            return Inner.Access;
        }

        internal string SourceAddressPrefix()
        {
            return Inner.SourceAddressPrefix;
        }

        internal string SourcePortRange()
        {
            return Inner.SourcePortRange;
        }

        internal string DestinationAddressPrefix()
        {
            return Inner.DestinationAddressPrefix;
        }

        internal string DestinationPortRange()
        {
            return Inner.DestinationPortRange;
        }

        internal int Priority()
        {
            return (Inner.Priority.HasValue) ? Inner.Priority.Value : 0;
        }

        NetworkSecurityGroup.Update.IUpdate ISettable<NetworkSecurityGroup.Update.IUpdate>.Parent()
        {
            return Parent;
        }

        internal string Description()
        {
            return Inner.Description;
        }
        #endregion

        #region Public Withers
        #region Direction and Access
        internal NetworkSecurityRuleImpl AllowInbound ()
        {
            return WithDirection(SecurityRuleDirection.Inbound)
                .WithAccess(SecurityRuleAccess.Allow);
        }

        internal NetworkSecurityRuleImpl AllowOutbound ()
        {
            return WithDirection(SecurityRuleDirection.Outbound)
                .WithAccess(SecurityRuleAccess.Allow);
        }

        internal NetworkSecurityRuleImpl DenyInbound ()
        {
            return WithDirection(SecurityRuleDirection.Inbound)
                .WithAccess(SecurityRuleAccess.Deny);
        }

        internal NetworkSecurityRuleImpl DenyOutbound ()
        {
            return WithDirection(SecurityRuleDirection.Outbound)
                .WithAccess(SecurityRuleAccess.Deny);
        }
        #endregion

        #region Protocol
        internal NetworkSecurityRuleImpl WithProtocol (string protocol)
        {
            Inner.Protocol = protocol;
            return this;
        }

        internal NetworkSecurityRuleImpl WithAnyProtocol ()
        {
            return WithProtocol(SecurityRuleProtocol.Asterisk);
        }
        #endregion

        #region Source Address
        internal NetworkSecurityRuleImpl FromAddress (string cidr)
        {
            Inner.SourceAddressPrefix = cidr;
            return this;
        }

        internal NetworkSecurityRuleImpl FromAnyAddress ()
        {
            Inner.SourceAddressPrefix = "*";
            return this;
        }
        #endregion

        #region Source Port
        internal NetworkSecurityRuleImpl FromPort (int port)
        {
            Inner.SourcePortRange = port.ToString();
            return this;
        }

        internal NetworkSecurityRuleImpl FromAnyPort ()
        {
            Inner.SourcePortRange = "*";
            return this;
        }

        internal NetworkSecurityRuleImpl FromPortRange (int from, int to)
        {
            Inner.SourcePortRange = from.ToString() + "-" + to.ToString();
            return this;
        }
        #endregion

        #region Destination Address
        internal NetworkSecurityRuleImpl ToAddress (string cidr)
        {
            Inner.DestinationAddressPrefix = cidr;
            return this;
        }

        internal NetworkSecurityRuleImpl ToAnyAddress ()
        {
            Inner.DestinationAddressPrefix = "*";
            return this;
        }
        #endregion

        #region Destination Port
        internal NetworkSecurityRuleImpl ToPort (int port)
        {
            Inner.DestinationPortRange = port.ToString();
            return this;
        }

        internal NetworkSecurityRuleImpl ToAnyPort ()
        {
            Inner.DestinationPortRange = "*";
            return this;
        }

        internal NetworkSecurityRuleImpl ToPortRange (int from, int to)
        {
            Inner.DestinationPortRange = from.ToString() + "-" + to.ToString();
            return this;
        }
        #endregion

        #region Priority
        internal NetworkSecurityRuleImpl WithPriority (int priority)
        {
            Inner.Priority = priority;
            return this;
        }
        #endregion

        #region Description
        internal NetworkSecurityRuleImpl WithDescription (string description)
        {
            Inner.Description = description;
            return this;
        }
        #endregion
        #endregion

        #region Helpers
        private NetworkSecurityRuleImpl WithDirection (string direction)
        {
            Inner.Direction = direction;
            return this;
        }

        private NetworkSecurityRuleImpl WithAccess (string permission)
        {
            Inner.Access = permission;
            return this;
        }
        #endregion

        #region Actions
        internal NetworkSecurityGroupImpl Attach ()
        {
            return Parent.WithRule(this);
        }
        #endregion
    }
}