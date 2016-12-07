// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent.SqlFirewallRules.SqlFirewallRulesCreatable
{
    using Microsoft.Azure.Management.Sql.Fluent;
    using Microsoft.Azure.Management.Sql.Fluent.SqlFirewallRule.Definition;

    /// <summary>
    /// Entry point to SQL FirewallRule management API, which already have the SQLServer specified.
    /// </summary>
    public interface ISqlFirewallRulesCreatable  :
        ISqlFirewallRules
    {
        Microsoft.Azure.Management.Sql.Fluent.SqlFirewallRule.Definition.IBlank DefinedWithSqlServer(string resourceGroupName, string sqlServerName, string firewallRuleName);
    }
}