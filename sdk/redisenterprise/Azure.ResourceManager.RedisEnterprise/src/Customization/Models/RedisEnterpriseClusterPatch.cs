// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.RedisEnterprise.Models
{
    // Customization: Renames the generator-produced RedisEnterpriseClusterUpdate back to the shipped name RedisEnterpriseClusterPatch.
    // Reason: A csharp-scoped @@clientName override in the spec renames the cluster update request model, which now conflicts with
    // the mgmt generator's default {Resource}Patch auto-rename since csharp-scoped overrides are honored.
    // This customization can be deleted once tsp-location.yaml is bumped to a commit that includes the spec-side fix.
    [CodeGenType("RedisEnterpriseClusterUpdate")]
    public partial class RedisEnterpriseClusterPatch
    { }
}
