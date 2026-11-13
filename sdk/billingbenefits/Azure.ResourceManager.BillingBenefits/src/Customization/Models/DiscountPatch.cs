// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.BillingBenefits.Models
{
    // Customization: Renames the generator-produced DiscountPatchContent back to the shipped name DiscountPatch.
    // Reason: A csharp-scoped @@clientName override in the spec (DiscountPatchRequest -> "DiscountPatchContent")
    // conflicts with the mgmt generator's default {Resource}Patch auto-rename now that csharp-scoped overrides are honored.
    // The spec-side override has been removed (azure-rest-api-specs follow-up PR #43122); this customization can be deleted once
    // tsp-location.yaml is bumped to a commit that includes that spec fix.
    [CodeGenType("DiscountPatchContent")]
    public partial class DiscountPatch
    { }
}
