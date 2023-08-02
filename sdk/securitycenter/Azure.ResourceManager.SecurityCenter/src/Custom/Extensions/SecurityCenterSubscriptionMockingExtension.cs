// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.SecurityCenter.Mocking
{
    /// <summary> A class to add extension methods to SubscriptionResource. </summary>
    public partial class SecurityCenterSubscriptionMockingExtension : ArmResource
    {
        /// <summary> Gets a collection of SubscriptionGovernanceRuleResources in the SubscriptionResource. </summary>
        /// <returns> An object representing collection of SubscriptionGovernanceRuleResources and their operations over a SubscriptionGovernanceRuleResource. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete and will be removed in a future release.", false)]
        public virtual SubscriptionGovernanceRuleCollection GetSubscriptionGovernanceRules()
        {
            return GetCachedClient(Client => new SubscriptionGovernanceRuleCollection(Client, Id));
        }
    }
}
