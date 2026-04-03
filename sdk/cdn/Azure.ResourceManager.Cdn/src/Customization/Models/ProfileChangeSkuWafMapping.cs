// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Cdn.Models
{
    public partial class ProfileChangeSkuWafMapping
    {
        // Backward compatibility: old API used ctor(string, WritableSubResource)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ProfileChangeSkuWafMapping(string securityPolicyName, WritableSubResource changeToWafPolicy) : this(securityPolicyName)
        {
            if (changeToWafPolicy != null)
            {
                ChangeToWafPolicy = new ResourceReference { Id = changeToWafPolicy.Id };
            }
        }
    }
}
