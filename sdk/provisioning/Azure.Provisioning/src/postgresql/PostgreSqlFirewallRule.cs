// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net;
using Azure.ResourceManager.PostgreSql;
using Azure.ResourceManager.PostgreSql.Models;

namespace Azure.Provisioning.PostgreSql
{
    /// <summary>
    /// Represents a SQL firewall rule.
    /// </summary>
    public class PostgreSqlFirewallRule : Resource<PostgreSqlFirewallRuleData>
    {
        private const string ResourceTypeName = "Microsoft.DBforPostgreSQL/flexibleServers/firewallRules";
        private static PostgreSqlFirewallRuleData Empty(string name) => ArmPostgreSqlModelFactory.PostgreSqlFirewallRuleData();

        /// <summary>
        /// Initializes a new instance of the <see cref="PostgreSqlFirewallRule"/>.
        /// </summary>
        /// <param name="scope">The scope.</param>
        /// <param name="startIpAddress">The start IP address.</param>
        /// <param name="endIpAddress">The end IP address.</param>
        /// <param name="parent">The parent.</param>
        /// <param name="name">The name.</param>
        /// <param name="version">The version.</param>
        public PostgreSqlFirewallRule(
            IConstruct scope,
            string? startIpAddress = default,
            string? endIpAddress = default,
            PostgreSqlFlexibleServer? parent = default,
            string name = "fw",
            string version = PostgreSqlFlexibleServer.DefaultVersion)
            : this(scope, parent, name, version, false, (name) => ArmPostgreSqlModelFactory.PostgreSqlFirewallRuleData(
                name: name,
                resourceType: ResourceTypeName,
                startIPAddress: startIpAddress != null ? IPAddress.Parse(startIpAddress) : IPAddress.Parse("0.0.0.1"),
                endIPAddress: endIpAddress != null ? IPAddress.Parse(endIpAddress) : IPAddress.Parse("255.255.255.254")))
        {
        }

        private PostgreSqlFirewallRule(
            IConstruct scope,
            PostgreSqlFlexibleServer? parent,
            string name,
            string version = PostgreSqlFlexibleServer.DefaultVersion,
            bool isExisting = false,
            Func<string, PostgreSqlFirewallRuleData>? creator = null)
            : base(scope, parent, name, ResourceTypeName, version, creator ?? Empty, isExisting)
        {
        }

        /// <summary>
        /// Creates a new instance of the <see cref="PostgreSqlFirewallRule"/> class referencing an existing instance.
        /// </summary>
        /// <param name="scope">The scope.</param>
        /// <param name="name">The resource name.</param>
        /// <param name="parent">The resource group.</param>
        /// <returns>The KeyVault instance.</returns>
        public static PostgreSqlFirewallRule FromExisting(IConstruct scope, string name, PostgreSqlFlexibleServer parent)
            => new PostgreSqlFirewallRule(scope, parent: parent, name: name, isExisting: true);

        /// <inheritdoc/>
        protected override Resource? FindParentInScope(IConstruct scope)
        {
            return scope.GetSingleResource<PostgreSqlFlexibleServer>() ?? new PostgreSqlFlexibleServer(
                scope,
                new Parameter("administratorLogin"),
                new Parameter("administratorPassword", isSecure: true));
        }
    }
}
