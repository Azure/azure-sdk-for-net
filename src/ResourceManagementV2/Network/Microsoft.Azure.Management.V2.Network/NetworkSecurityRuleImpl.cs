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
    public partial class NetworkSecurityRuleImpl  :
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
            return this
                .WithDirection(SecurityRuleDirection.Outbound)
                .WithAccess(SecurityRuleAccess.Allow);
        }

        public NetworkSecurityRuleImpl DenyInbound ()
        {
            return this
                .WithDirection(SecurityRuleDirection.Inbound)
                .WithAccess(SecurityRuleAccess.Deny);
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

        NetworkSecurityGroup.Update.IUpdate ISettable<NetworkSecurityGroup.Update.IUpdate>.Parent()
        {
            return base.Parent;
        }

        public string Description
        {
            get
            {
                return this.Inner.Description;
            }
        }
    }
}