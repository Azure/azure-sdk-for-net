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
        override public string Name
        {
            get
            {
                return Inner.Name;
            }
        }

        public string Direction
        {
            get
            {
                return Inner.Direction;
            }
        }

        public string Protocol
        {
            get
            {
                return Inner.Protocol;
            }
        }
        public string Access
        {
            get
            {
                return Inner.Access;
            }
        }
        public string SourceAddressPrefix
        {
            get
            {
                return Inner.SourceAddressPrefix;
            }
        }

        public string SourcePortRange
        {
            get
            {
                return Inner.SourcePortRange;
            }
        }

        public string DestinationAddressPrefix
        {
            get
            {
                return Inner.DestinationAddressPrefix;
            }
        }

        public string DestinationPortRange
        {
            get
            {
                return Inner.DestinationPortRange;
            }
        }

        public int Priority
        {
            get
            {
                return (Inner.Priority.HasValue) ? Inner.Priority.Value : 0;
            }
        }

        NetworkSecurityGroup.Update.IUpdate ISettable<NetworkSecurityGroup.Update.IUpdate>.Parent()
        {
            return Parent;
        }

        public string Description
        {
            get
            {
                return Inner.Description;
            }
        }
        #endregion

        #region Public Withers
        #region Direction and Access
        public NetworkSecurityRuleImpl AllowInbound ()
        {
            return WithDirection(SecurityRuleDirection.Inbound)
                .WithAccess(SecurityRuleAccess.Allow);
        }

        public NetworkSecurityRuleImpl AllowOutbound ()
        {
            return WithDirection(SecurityRuleDirection.Outbound)
                .WithAccess(SecurityRuleAccess.Allow);
        }

        public NetworkSecurityRuleImpl DenyInbound ()
        {
            return WithDirection(SecurityRuleDirection.Inbound)
                .WithAccess(SecurityRuleAccess.Deny);
        }

        public NetworkSecurityRuleImpl DenyOutbound ()
        {
            return WithDirection(SecurityRuleDirection.Outbound)
                .WithAccess(SecurityRuleAccess.Deny);
        }
        #endregion

        #region Protocol
        public NetworkSecurityRuleImpl WithProtocol (string protocol)
        {
            Inner.Protocol = protocol;
            return this;
        }

        public NetworkSecurityRuleImpl WithAnyProtocol ()
        {
            return WithProtocol(SecurityRuleProtocol.Asterisk);
        }
        #endregion

        #region Source Address
        public NetworkSecurityRuleImpl FromAddress (string cidr)
        {
            Inner.SourceAddressPrefix = cidr;
            return this;
        }

        public NetworkSecurityRuleImpl FromAnyAddress ()
        {
            Inner.SourceAddressPrefix = "*";
            return this;
        }
        #endregion

        #region Source Port
        public NetworkSecurityRuleImpl FromPort (int port)
        {
            Inner.SourcePortRange = port.ToString();
            return this;
        }

        public NetworkSecurityRuleImpl FromAnyPort ()
        {
            Inner.SourcePortRange = "*";
            return this;
        }

        public NetworkSecurityRuleImpl FromPortRange (int from, int to)
        {
            Inner.SourcePortRange = from.ToString() + "-" + to.ToString();
            return this;
        }
        #endregion

        #region Destination Address
        public NetworkSecurityRuleImpl ToAddress (string cidr)
        {
            Inner.DestinationAddressPrefix = cidr;
            return this;
        }

        public NetworkSecurityRuleImpl ToAnyAddress ()
        {
            Inner.DestinationAddressPrefix = "*";
            return this;
        }
        #endregion

        #region Destination Port
        public NetworkSecurityRuleImpl ToPort (int port)
        {
            Inner.DestinationPortRange = port.ToString();
            return this;
        }

        public NetworkSecurityRuleImpl ToAnyPort ()
        {
            Inner.DestinationPortRange = "*";
            return this;
        }

        public NetworkSecurityRuleImpl ToPortRange (int from, int to)
        {
            Inner.DestinationPortRange = from.ToString() + "-" + to.ToString();
            return this;
        }
        #endregion

        #region Priority
        public NetworkSecurityRuleImpl WithPriority (int priority)
        {

            //$ if (priority < 100 || priority > 4096) {
            //$ throw new IllegalArgumentException("The priority number of a network security rule must be between 100 and 4096.");
            //$ }
            //$ 
            //$ this.inner().withPriority(priority);
            //$ return this;

            return this;
        }
        #endregion

        #region Description
        public NetworkSecurityRuleImpl WithDescription (string description)
        {

            //$ this.inner().withDescription(description);
            //$ return this;

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
        public NetworkSecurityGroupImpl Attach ()
        {
            return Parent.WithRule(this);
        }
        #endregion
    }
}