// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Provisioning.Generator.Model;
using Azure.ResourceManager.RedisEnterprise;

namespace Azure.Provisioning.Generator.Specifications;

public class RedisEnterpriseSpecification() :
    Specification("RedisEnterprise", typeof(RedisEnterpriseExtensions))
{
    protected override void Customize()
    {
        // Naming requirements
        AddNameRequirements<RedisEnterpriseClusterResource>(min: 1, max: 60, lower: true, upper: true, digits: true, hyphen: true);
        AddNameRequirements<RedisEnterpriseDatabaseResource>(min: 1, max: 60, lower: true, upper: true, digits: true, hyphen: true);
        AddNameRequirements<AccessPolicyAssignmentResource>(min: 1, max: 60, lower: true, upper: true, digits: true);
    }
}
