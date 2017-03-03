// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using SqlFirewallRule.Definition;
    using SqlFirewallRules.SqlFirewallRulesCreatable;
    using SqlServer.FirewallRules;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Implementation of SqlServer.FirewallRules, which enables the creating the firewall rules from the SQLServer directly.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnNxbC5pbXBsZW1lbnRhdGlvbi5GaXJld2FsbFJ1bGVzSW1wbA==
    internal partial class FirewallRulesImpl :
        IFirewallRules
    {
        private string resourceGroupName;
        private string sqlServerName;
        private ISqlFirewallRulesCreatable sqlFirewallRules;

        ///GENMHASH:C774FCAB1B37C63FDEE465624B3F445E:D7E297FABE48282CD8383D54EA2F45BB
        internal FirewallRulesImpl(ISqlManager manager, string resourceGroupName, string sqlServerName)
        {
            this.resourceGroupName = resourceGroupName;
            this.sqlServerName = sqlServerName;
            sqlFirewallRules = new SqlFirewallRulesImpl(manager);
        }

        ///GENMHASH:EE286EB18723A14498FD299F1FDB7FE2:C5BF961B57B444CF6E570183CC87564C
        internal ISqlFirewallRules SqlFirewallRules()
        {
            return this.sqlFirewallRules;
        }

        ///GENMHASH:206E829E50B031B66F6EA9C7402231F9:FAE24897C34CEA085E67FE4A51B20EC0
        public ISqlFirewallRule Get(string firewallRuleName)
        {
            return this.sqlFirewallRules.GetBySqlServer(this.resourceGroupName, this.sqlServerName, firewallRuleName);
        }

        ///GENMHASH:8ACFB0E23F5F24AD384313679B65F404:9B3DE2DFA4C36A057FB7B794CDEF88B9
        public IBlank Define(string firewallRuleName)
        {
            return this.sqlFirewallRules.DefinedWithSqlServer(this.resourceGroupName, this.sqlServerName, firewallRuleName);
        }

        ///GENMHASH:BEDEF34E57C25BFA34A4AB1C8430428E:0804A2E88BF723C7F9FC0AA079AD97F6
        public async Task DeleteAsync(string firewallRuleName, CancellationToken cancellationToken = default(CancellationToken))
        {
            await this.sqlFirewallRules.DeleteByParentAsync(this.resourceGroupName, this.sqlServerName, firewallRuleName, cancellationToken);
        }

        ///GENMHASH:7D6013E8B95E991005ED921F493EFCE4:56EA228A05D500A0D3F52C7711ECC751
        public IList<ISqlFirewallRule> List()
        {
            return this.sqlFirewallRules.ListBySqlServer(this.resourceGroupName, this.sqlServerName);
        }

        ///GENMHASH:184FEA122A400D19B34517FEF358ED78:B2677A44CA28AAD61DEC2FD85C36916D
        public void Delete(string firewallRuleName)
        {
            this.sqlFirewallRules.DeleteByParent(this.resourceGroupName, this.sqlServerName, firewallRuleName);
        }
    }
}
