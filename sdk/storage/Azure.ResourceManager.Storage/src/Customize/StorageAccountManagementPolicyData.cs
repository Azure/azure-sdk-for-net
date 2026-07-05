// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Storage.Models;

namespace Azure.ResourceManager.Storage
{
    public partial class StorageAccountManagementPolicyData : ResourceData
    {
        // Backward-compat: prior GA exposed Rules with a setter to allow replacing the entire list.

        /// <summary> The Storage Account ManagementPolicies Rules. See more details in: https://learn.microsoft.com/azure/storage/blobs/lifecycle-management-overview. </summary>
        [WirePath("properties.policy.rules")]
        public IList<ManagementPolicyRule> Rules
        {
            get
            {
                if (Properties is null)
                {
                    Properties = new ManagementPolicyProperties();
                }
                return Properties.Rules;
            }
            set
            {
                if (Properties is null)
                {
                    Properties = new ManagementPolicyProperties();
                }
                var rules = Properties.Rules;
                rules.Clear();
                if (value != null)
                {
                    foreach (var item in value)
                    {
                        rules.Add(item);
                    }
                }
            }
        }
    }
}
