// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Microsoft.Azure.Management.Resource.Fluent.Core.IndependentChild.Definition;
    using Models;
    using SqlFirewallRule.Definition;
    using SqlFirewallRule.Update;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Implementation for SqlFirewallRule and its parent interfaces.
    /// </summary>
    internal partial class SqlFirewallRuleImpl :
        IndependentChildImpl<ISqlFirewallRule, ISqlServer, ServerFirewallRuleInner, SqlFirewallRuleImpl, IHasId, IUpdate>,
        ISqlFirewallRule,
        IDefinition,
        IUpdate,
        IWithParentResource<ISqlFirewallRule, ISqlServer>
    {
        private IServersOperations innerCollection;

        public SqlFirewallRuleImpl WithIpAddressRange(string startIpAddress, string endIpAddress)
        {
            this.Inner.StartIpAddress = startIpAddress;
            this.Inner.EndIpAddress = endIpAddress;

            return this;
        }

        internal SqlFirewallRuleImpl(string name, ServerFirewallRuleInner innerObject, IServersOperations innerCollection)
            : base(name, innerObject)
        {
            this.innerCollection = innerCollection;
        }

        public string SqlServerName()
        {
            return this.parentName;
        }

        public string Kind()
        {
            return this.Inner.Kind;
        }

        protected override async Task<Microsoft.Azure.Management.Sql.Fluent.ISqlFirewallRule> CreateChildResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var firewallRuleInner = await this.innerCollection.CreateOrUpdateFirewallRuleAsync(this.ResourceGroupName, this.SqlServerName(), this.Name, this.Inner);
            SetInner(firewallRuleInner);

            return this;
        }

        public override ISqlFirewallRule Refresh()
        {
            this.innerCollection.GetFirewallRule(this.ResourceGroupName, this.SqlServerName(), this.Name);
            return this;
        }

        public SqlFirewallRuleImpl WithEndIpAddress(string endIpAddress)
        {
            this.Inner.EndIpAddress = endIpAddress;

            return this;
        }

        public string StartIpAddress()
        {
            return this.Inner.StartIpAddress;
        }

        public void Delete()
        {
            this.innerCollection.DeleteFirewallRule(this.ResourceGroupName, this.SqlServerName(), this.Name);
        }

        public string EndIpAddress()
        {
            return this.Inner.EndIpAddress;
        }

        public SqlFirewallRuleImpl WithStartIpAddress(string startIpAddress)
        {
            this.Inner.StartIpAddress = startIpAddress;

            return this;
        }

        public SqlFirewallRuleImpl WithIpAddress(string ipAddress)
        {
            this.WithStartIpAddress(ipAddress).WithEndIpAddress(ipAddress);

            return this;
        }

        /// <return>The resource ID string.</return>
        public override string Id
        {
            get
            {
                if (this.Inner != null)
                {
                    return this.Inner.Id;
                }

                return null;
            }
        }

        public Region Region()
        {
            return EnumNameAttribute.FromName<Region>(this.Inner.Location);
        }
    }
}