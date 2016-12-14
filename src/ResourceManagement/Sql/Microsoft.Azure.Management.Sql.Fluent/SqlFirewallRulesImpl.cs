// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnNxbC5pbXBsZW1lbnRhdGlvbi5TcWxGaXJld2FsbFJ1bGVzSW1wbA==
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Microsoft.Azure.Management.Resource.Fluent.Core.CollectionActions;
    using Models;
    using Resource.Fluent.Core.ResourceActions;
    using SqlFirewallRules.SqlFirewallRulesCreatable;
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Implementation for SQLElasticPools and its parent interfaces.
    /// </summary>
    internal partial class SqlFirewallRulesImpl :
        IndependentChildrenImpl<ISqlFirewallRule, SqlFirewallRuleImpl, ServerFirewallRuleInner, IServersOperations, SqlManager>,
        ISqlFirewallRules,
        ISupportsGettingByParent<Microsoft.Azure.Management.Sql.Fluent.ISqlFirewallRule>,
        ISupportsListingByParent<Microsoft.Azure.Management.Sql.Fluent.ISqlFirewallRule>,
        ISqlFirewallRulesCreatable
    {
        internal SqlFirewallRulesImpl(IServersOperations innerCollection, SqlManager manager)
            : base(innerCollection, manager)
        {
        }

        ///GENMHASH:16CEA22B57032A6757D8EFC1BF423794:F46E4D0A3CDB6C5AE412BF5B7FB52B09
        public IList<Microsoft.Azure.Management.Sql.Fluent.ISqlFirewallRule> ListBySqlServer(string resourceGroupName, string sqlServerName)
        {
            return new List<ISqlFirewallRule>(this.ListByParent(resourceGroupName, sqlServerName));
        }

        ///GENMHASH:CD989F8A79EC70D56C4F5154E2B8BE11:57462F0C7FF757AFBBFD3B3561C9F9ED
        public IList<Microsoft.Azure.Management.Sql.Fluent.ISqlFirewallRule> ListBySqlServer(IGroupableResource sqlServer)
        {
            return new List<ISqlFirewallRule>(this.ListByParent(sqlServer));
        }

        ///GENMHASH:21EB605E5FAA6C13D208A1A4CE8C136D:67032F38ECA8CBB405D18A2581390A32
        public override async Task<PagedList<ISqlFirewallRule>> ListByParentAsync(string resourceGroupName, string parentName, CancellationToken cancellationToken = default(CancellationToken))
        {
            return WrapList(new PagedList<ServerFirewallRuleInner>(await this.innerCollection.ListFirewallRulesAsync(resourceGroupName, parentName, cancellationToken)));
        }

        ///GENMHASH:03C6F391A16F96A5127D98827B5423FA:877F7B73190881879934925547D57EAF
        public ISqlFirewallRule GetBySqlServer(string resourceGroup, string sqlServerName, string name)
        {
            return this.GetByParent(resourceGroup, sqlServerName, name);
        }

        ///GENMHASH:6B5394D9B9C62E3B4A3B037DD27B7A20:466DF29CB4850E0593B3C691F625BC2C
        public ISqlFirewallRule GetBySqlServer(IGroupableResource sqlServer, string name)
        {
            return this.GetByParent(sqlServer, name);
        }

        ///GENMHASH:1F414E796475F1DA7286F29E3E27589D:9E40C7C36CC9390C7C5D4EB7F13D8D4A
        public override async Task DeleteByParentAsync(string groupName, string parentName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            await this.innerCollection.DeleteFirewallRuleAsync(groupName, parentName, name, cancellationToken);
        }

        ///GENMHASH:E153333077E8B838087B8132AAA900EF:3E07C2B5BD84D8C41CD65F3910EFB3A1
        public ICreatable<ISqlFirewallRule> DefinedWithSqlServer(string resourceGroupName, string sqlServerName, string firewallRuleName)
        {
            ServerFirewallRuleInner inner = new ServerFirewallRuleInner();

            return new SqlFirewallRuleImpl(
                firewallRuleName,
                inner,
                this.innerCollection).WithExistingParentResource(resourceGroupName, sqlServerName);
        }

        ///GENMHASH:C32C5A59EBD92E91959156A49A8C1A95:D9AFFE54BAA276E6A6DADDEBF326C548
        public override async Task<ISqlFirewallRule> GetByParentAsync(string resourceGroup, string parentName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            return WrapModel(await this.innerCollection.GetFirewallRuleAsync(resourceGroup, parentName, name, cancellationToken));
        }

        ///GENMHASH:2FE8C4C2D5EAD7E37787838DE0B47D92:09C3921CF8225D39924E9982602EA792
        protected override SqlFirewallRuleImpl WrapModel(string name)
        {
            throw new NotImplementedException("Should never hit this code, currently not exposed");
        }

        ///GENMHASH:D734C3213E38BC205A408E11AFDDF7CF:033629455E4435C44D01E364E80E84CE
        protected override ISqlFirewallRule WrapModel(ServerFirewallRuleInner inner)
        {
            if (inner == null)
            {
                return null;
            }
            return new SqlFirewallRuleImpl(inner.Name, inner, this.innerCollection);
        }
    }
}
