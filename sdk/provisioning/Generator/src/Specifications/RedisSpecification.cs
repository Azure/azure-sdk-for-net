// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Provisioning.Generator.Model;
using Azure.ResourceManager.Redis;
using Azure.ResourceManager.Redis.Models;

namespace Azure.Provisioning.Generator.Specifications;

public class RedisSpecification() :
    Specification("Redis", typeof(RedisExtensions))
{
    protected override void Customize()
    {
        // Remove misfires
        RemoveProperty<RedisPatchScheduleResource>("DefaultName");
        RemoveProperty<RedisPrivateEndpointConnectionData>("ResourceType");

        // Patch models
        CustomizeModel<RedisResource>(m => m.Name = "RedisResource");
        CustomizeProperty<RedisAccessKeys>("PrimaryKey", p => p.IsSecure = true);
        CustomizeProperty<RedisAccessKeys>("SecondaryKey", p => p.IsSecure = true);
        CustomizePropertyIsoDuration<RedisPatchScheduleSetting>("MaintenanceWindow");

        // Naming requirements
        AddNameRequirements<RedisResource>(min: 1, max: 63, lower: true, upper: true, digits: true, hyphen: true);
        AddNameRequirements<RedisFirewallRuleResource>(min: 1, max: 256, lower: true, upper: true, digits: true);

        // Roles
        Roles.Add(new Role("RedisCacheContributor", "e0f68234-74aa-48ed-b826-c38b57376e17", "Lets you manage Redis caches, but not access to them."));

        // Assign Roles
        CustomizeResource<RedisResource>(r => r.GenerateRoleAssignment = true);
    }
}
