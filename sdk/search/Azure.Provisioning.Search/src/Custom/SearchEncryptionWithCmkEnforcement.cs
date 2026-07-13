// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.Search
{
    // Preserve enum ordinals until the generator can customize compatibility ordering.
    // Tracking issue: https://github.com/Azure/azure-sdk-for-net/issues/60442
    /// <summary> Describes how a search service enforces customer-managed key encryption compliance. </summary>
    [CodeGenType("SearchEncryptionWithCmkEnforcement")]
    public enum SearchEncryptionWithCmkEnforcement
    {
        /// <summary> Enforcement policy is not explicitly specified. </summary>
        Unspecified,
        /// <summary> Customer-managed key encryption enforcement is disabled. </summary>
        Disabled,
        /// <summary> Customer-managed key encryption enforcement is enabled. </summary>
        Enabled,
    }
}
