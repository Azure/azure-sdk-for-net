// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.ResourceManager.Storage.Models
{
    internal partial class ManagementPolicyProperties
    {
        /// <summary> The Storage Account ManagementPolicies Rules. See more details in: https://learn.microsoft.com/azure/storage/blobs/lifecycle-management-overview. </summary>
        [WirePath("policy.rules")]
        public IList<ManagementPolicyRule> Rules
        {
            get
            {
                if (Policy is null)
                {
                    // Workaround: parameterless ctor doesn't initialize Rules.
                    // https://github.com/Azure/azure-sdk-for-net/issues/57449
                    Policy = new ManagementPolicySchema(new ChangeTrackingList<ManagementPolicyRule>());
                }
                return Policy.Rules;
            }
        }
    }
}
