// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net;
using Azure.ResourceManager.Redis;
using Azure.ResourceManager.Redis.Models;

namespace Azure.Provisioning.Redis
{
    /// <summary>
    /// Represents a Redis firewall rule.
    /// </summary>
    public class RedisFirewallRule : Resource<RedisFirewallRuleData>
    {
        private const string ResourceTypeName = "Microsoft.Cache/redis/firewallRules";
        private static RedisFirewallRuleData Empty(string name) => ArmRedisModelFactory.RedisFirewallRuleData();

        /// <summary>
        /// Initializes a new instance of the <see cref="RedisFirewallRule"/>.
        /// </summary>
        /// <param name="scope">The scope.</param>
        /// <param name="startIpAddress">The start IP address.</param>
        /// <param name="endIpAddress">The end IP address.</param>
        /// <param name="parent">The parent.</param>
        /// <param name="name">The name.</param>
        /// <param name="version">The version.</param>
        public RedisFirewallRule(
            IConstruct scope,
            string? startIpAddress = default,
            string? endIpAddress = default,
            RedisCache? parent = default,
            string name = "fw",
            string version = RedisCache.DefaultVersion)
            : this(scope, parent, name, version, false, (name) => ArmRedisModelFactory.RedisFirewallRuleData(
                name: name,
                resourceType: ResourceTypeName,
                startIP: startIpAddress != null ? IPAddress.Parse(startIpAddress) : IPAddress.Parse("0.0.0.1"),
                endIP: endIpAddress != null ? IPAddress.Parse(endIpAddress) : IPAddress.Parse("255.255.255.254")))
        {
        }

        private RedisFirewallRule(
            IConstruct scope,
            RedisCache? parent,
            string name,
            string version = RedisCache.DefaultVersion,
            bool isExisting = false,
            Func<string, RedisFirewallRuleData>? creator = null)
            : base(scope, parent, name, ResourceTypeName, version, creator ?? Empty, isExisting)
        {
        }

        /// <summary>
        /// Creates a new instance of the <see cref="RedisFirewallRule"/> class referencing an existing instance.
        /// </summary>
        /// <param name="scope">The scope.</param>
        /// <param name="name">The resource name.</param>
        /// <param name="parent">The resource group.</param>
        /// <returns>The KeyVault instance.</returns>
        public static RedisFirewallRule FromExisting(IConstruct scope, string name, RedisCache parent)
            => new RedisFirewallRule(scope, parent: parent, name: name, isExisting: true);

        /// <inheritdoc/>
        protected override Resource? FindParentInScope(IConstruct scope)
        {
            return scope.GetSingleResource<RedisCache>() ?? new RedisCache(scope);
        }
    }
}
