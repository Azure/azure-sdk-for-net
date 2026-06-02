// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Cdn.Models
{
    // Customization: This file adds the old constructor to ProfileChangeSkuWafMapping for backward API compatibility with the previous SDK.
    // Reason: The old SDK constructor accepted a WritableSubResource-typed changeToWafPolicy parameter,
    // but after the TypeSpec migration it was changed to CdnResourceReference. The old constructor is preserved here,
    // internally converting the type, and marked as EditorBrowsable.Never.
    public partial class ProfileChangeSkuWafMapping
    {
        // Backward compatibility: old API used ctor(string, WritableSubResource)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ProfileChangeSkuWafMapping(string securityPolicyName, WritableSubResource changeToWafPolicy) : this(securityPolicyName)
        {
            if (changeToWafPolicy != null)
            {
                ChangeToWafPolicy = new CdnResourceReference { Id = changeToWafPolicy.Id };
            }
        }
    }
}
