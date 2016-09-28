// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.V2.Network
{

    using Microsoft.Azure.Management.V2.Network.NetworkSecurityRule.Definition;
    using Microsoft.Azure.Management.V2.Network.NetworkSecurityRule.Update;
    using Microsoft.Azure.Management.V2.Network.NetworkSecurityRule.UpdateDefinition;
    using Microsoft.Azure.Management.V2.Network.NetworkSecurityGroup.Update;
    using Microsoft.Azure.Management.V2.Resource.Core;
    using Microsoft.Azure.Management.Network.Models;
    using Microsoft.Azure.Management.V2.Network.NetworkSecurityGroup.Definition;
    using Microsoft.Azure.Management.V2.Resource.Core.ChildResource.Definition;
    using Microsoft.Azure.Management.V2.Resource.Core.ChildResource.Update;
    using Resource.Core.ChildResourceActions;
    using System;

    /// <summary>
    /// Implementation for {@link NetworkSecurityRule} and its create and update interfaces.
    /// </summary>
    public partial class NetworkSecurityRuleImpl  :
        ChildResource<Microsoft.Azure.Management.Network.Models.SecurityRuleInner,Microsoft.Azure.Management.V2.Network.NetworkSecurityGroupImpl,Microsoft.Azure.Management.V2.Network.INetworkSecurityGroup>,
        INetworkSecurityRule,
        IDefinition<Microsoft.Azure.Management.V2.Network.NetworkSecurityGroup.Definition.IWithCreate>,
        IUpdateDefinition<Microsoft.Azure.Management.V2.Network.NetworkSecurityGroup.Update.IUpdate>,
        Microsoft.Azure.Management.V2.Network.NetworkSecurityRule.Update.IUpdate
    {
        protected  NetworkSecurityRuleImpl (SecurityRuleInner inner, NetworkSecurityGroupImpl parent) : base(inner.Name, inner, parent)
        {

            //$ super(inner, parent);
            //$ }

        }

        override public string Name
        {
            get
            {
            //$ return this.inner().name();


                return null;
            }
        }
        public string Direction
        {
            get
            {
            //$ return this.inner().direction();


                return null;
            }
        }
        public string Protocol
        {
            get
            {
            //$ return this.inner().protocol();


                return null;
            }
        }
        public string Access
        {
            get
            {
            //$ return this.inner().access();


                return null;
            }
        }
        public string SourceAddressPrefix
        {
            get
            {
            //$ return this.inner().sourceAddressPrefix();


                return null;
            }
        }
        public string SourcePortRange
        {
            get
            {
            //$ return this.inner().sourcePortRange();


                return null;
            }
        }
        public string DestinationAddressPrefix
        {
            get
            {
            //$ return this.inner().destinationAddressPrefix();


                return null;
            }
        }
        public string DestinationPortRange
        {
            get
            {
            //$ return this.inner().destinationPortRange();


                return null;
            }
        }
        public int? Priority
        {
            get
            {
            //$ return this.inner().priority();


                return null;
            }
        }
        public NetworkSecurityRuleImpl AllowInbound ()
        {

            //$ return this
            //$ .withDirection(SecurityRuleDirection.INBOUND)
            //$ .withAccess(SecurityRuleAccess.ALLOW);

            return this;
        }

        public NetworkSecurityRuleImpl AllowOutbound ()
        {

            //$ return this
            //$ .withDirection(SecurityRuleDirection.OUTBOUND)
            //$ .withAccess(SecurityRuleAccess.ALLOW);

            return this;
        }

        public NetworkSecurityRuleImpl DenyInbound ()
        {

            //$ return this
            //$ .withDirection(SecurityRuleDirection.INBOUND)
            //$ .withAccess(SecurityRuleAccess.DENY);

            return this;
        }

        public NetworkSecurityRuleImpl DenyOutbound ()
        {

            //$ return this
            //$ .withDirection(SecurityRuleDirection.OUTBOUND)
            //$ .withAccess(SecurityRuleAccess.DENY);

            return this;
        }

        public NetworkSecurityRuleImpl WithProtocol (string protocol)
        {

            //$ this.inner().withProtocol(protocol);
            //$ return this;

            return this;
        }

        public NetworkSecurityRuleImpl WithAnyProtocol ()
        {

            //$ return this.withProtocol(SecurityRuleProtocol.ASTERISK);

            return this;
        }

        public NetworkSecurityRuleImpl FromAddress (string cidr)
        {

            //$ this.inner().withSourceAddressPrefix(cidr);
            //$ return this;

            return this;
        }

        public NetworkSecurityRuleImpl FromAnyAddress ()
        {

            //$ this.inner().withSourceAddressPrefix("*");
            //$ return this;

            return this;
        }

        public NetworkSecurityRuleImpl FromPort (int port)
        {

            //$ this.inner().withSourcePortRange(String.valueOf(port));
            //$ return this;

            return this;
        }

        public NetworkSecurityRuleImpl FromAnyPort ()
        {

            //$ this.inner().withSourcePortRange("*");
            //$ return this;

            return this;
        }

        public NetworkSecurityRuleImpl FromPortRange (int from, int to)
        {

            //$ this.inner().withSourcePortRange(String.valueOf(from) + "-" + String.valueOf(to));
            //$ return this;

            return this;
        }

        public NetworkSecurityRuleImpl ToAddress (string cidr)
        {

            //$ this.inner().withDestinationAddressPrefix(cidr);
            //$ return this;

            return this;
        }

        public NetworkSecurityRuleImpl ToAnyAddress ()
        {

            //$ this.inner().withDestinationAddressPrefix("*");
            //$ return this;

            return this;
        }

        public NetworkSecurityRuleImpl ToPort (int port)
        {

            //$ this.inner().withDestinationPortRange(String.valueOf(port));
            //$ return this;

            return this;
        }

        public NetworkSecurityRuleImpl ToAnyPort ()
        {

            //$ this.inner().withDestinationPortRange("*");
            //$ return this;

            return this;
        }

        public NetworkSecurityRuleImpl ToPortRange (int from, int to)
        {

            //$ this.inner().withDestinationPortRange(String.valueOf(from) + "-" + String.valueOf(to));
            //$ return this;

            return this;
        }

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

        public NetworkSecurityRuleImpl WithDescription (string description)
        {

            //$ this.inner().withDescription(description);
            //$ return this;

            return this;
        }

        private NetworkSecurityRuleImpl WithDirection (string direction)
        {

            //$ this.inner().withDirection(direction);
            //$ return this;
            //$ }

            return this;
        }

        private NetworkSecurityRuleImpl WithAccess (string permission)
        {

            //$ this.inner().withAccess(permission);
            //$ return this;
            //$ }

            return this;
        }

        public NetworkSecurityGroupImpl Attach ()
        {

            //$ return this.parent().withRule(this);

            return null;
        }

        NetworkSecurityGroup.Update.IUpdate ISettable<NetworkSecurityGroup.Update.IUpdate>.Parent()
        {
            throw new NotImplementedException();
        }

        public string Description
        {
            get
            {
            //$ return this.inner().description();


                return null;
            }
        }
    }
}