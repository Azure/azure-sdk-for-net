// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Quota
{
    // Preserve the shipped resource name when the generated resource name changes.
    [CodeGenType("ManagementGroupGroupQuotaSubscriptionIdResource")]
    public partial class GroupQuotaSubscriptionResource
    {
    }
}
