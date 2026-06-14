// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS0618 // Legacy governance rule collection is intentionally exposed for ApiCompat.
#pragma warning disable CS1591 // Hidden compatibility shims do not need public docs.

namespace Azure.ResourceManager.SecurityCenter.Mocking
{
    public partial class MockableSecurityCenterSubscriptionResource
    {
        // Backward compatibility for the previous GA subscription-scoped governance rule collection.
        internal SubscriptionGovernanceRuleCollection GetSubscriptionGovernanceRules()
            => new SubscriptionGovernanceRuleCollection(Client, Id);
    }
}
