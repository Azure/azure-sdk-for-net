// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.SecurityCenter.Models;

namespace Azure.ResourceManager.SecurityCenter
{
    /// <summary> A class to add extension methods to SubscriptionResource. </summary>
    internal partial class SubscriptionResourceExtensionClient : ArmResource
    {
        /// <summary> Gets a collection of SubscriptionGovernanceRuleResources in the SubscriptionResource. </summary>
        /// <returns> An object representing collection of SubscriptionGovernanceRuleResources and their operations over a SubscriptionGovernanceRuleResource. </returns>
        [Obsolete("This method is obsolete and will be removed in a future release.", false)]
        public virtual SubscriptionGovernanceRuleCollection GetSubscriptionGovernanceRules()
        {
            return GetCachedClient(Client => new SubscriptionGovernanceRuleCollection(Client, Id));
        }
    }
}
