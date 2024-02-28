// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.ResourceManager.Sql;
using Azure.ResourceManager.Sql.Models;

namespace Azure.Provisioning.Sql
{
    /// <summary>
    /// Represents a SQL firewall rule.
    /// </summary>
    public class SqlFirewallRule : Resource<SqlFirewallRuleData>
    {
        private const string ResourceTypeName = "Microsoft.Sql/servers/firewallRules";

        /// <summary>
        /// Initializes a new instance of the <see cref="SqlFirewallRule"/>.
        /// </summary>
        /// <param name="scope">The scope.</param>
        /// <param name="name">The name.</param>
        /// <param name="version">The version.</param>
        public SqlFirewallRule(IConstruct scope, string name = "fw", string version = "2020-11-01-preview")
            : base(scope, null, name, ResourceTypeName, version, (name) => ArmSqlModelFactory.SqlFirewallRuleData(
                name: name,
                resourceType: ResourceTypeName,
                startIPAddress: "0.0.0.1",
                endIPAddress: "255.255.255.254"
                ),
                null)
        {
        }

        /// <inheritdoc/>
        protected override Resource? FindParentInScope(IConstruct scope)
        {
            var result = base.FindParentInScope(scope);
            if (result is null)
            {
                result = scope.GetSingleResource<SqlServer>() ?? new SqlServer(scope, "sql");
            }
            return result;
        }
    }
}
