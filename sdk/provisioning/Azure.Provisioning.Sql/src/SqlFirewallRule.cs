// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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
        private static SqlFirewallRuleData Empty(string name) => ArmSqlModelFactory.SqlFirewallRuleData();

        /// <summary>
        /// Initializes a new instance of the <see cref="SqlFirewallRule"/>.
        /// </summary>
        /// <param name="scope">The scope.</param>
        /// <param name="parent">The parent.</param>
        /// <param name="name">The name.</param>
        /// <param name="version">The version.</param>
        public SqlFirewallRule(IConstruct scope, SqlServer? parent = default, string name = "fw", string version = SqlServer.DefaultVersion)
            : this(scope, parent, name, version, (name) => ArmSqlModelFactory.SqlFirewallRuleData(
                name: name,
                resourceType: ResourceTypeName,
                startIPAddress: "0.0.0.1",
                endIPAddress: "255.255.255.254"
                ))
        {
        }

        private SqlFirewallRule(IConstruct scope,
            SqlServer? parent,
            string name,
            string version = SqlServer.DefaultVersion,
            Func<string, SqlFirewallRuleData>? creator = null,
            bool isExisting = false)
            : base(scope, parent, name, ResourceTypeName, version, creator ?? Empty, isExisting)
        {
        }

        /// <summary>
        /// Creates a new instance of the <see cref="SqlFirewallRule"/> class referencing an existing instance.
        /// </summary>
        /// <param name="scope">The scope.</param>
        /// <param name="name">The resource name.</param>
        /// <param name="parent">The resource group.</param>
        /// <returns>The KeyVault instance.</returns>
        public static SqlFirewallRule FromExisting(IConstruct scope, string name, SqlServer parent)
            => new SqlFirewallRule(scope, parent: parent, name: name, isExisting: true);

        /// <inheritdoc/>
        protected override Resource? FindParentInScope(IConstruct scope)
        {
            return scope.GetSingleResource<SqlServer>() ?? new SqlServer(scope, "sql");
        }
    }
}
