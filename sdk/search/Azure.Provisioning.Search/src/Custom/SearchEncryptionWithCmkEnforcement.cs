// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.Search
{
    // Preserve enum ordinals until the generator can customize compatibility ordering.
    // Tracking issue: https://github.com/Azure/azure-sdk-for-net/issues/60442
    [CodeGenType("SearchEncryptionWithCmkEnforcement")]
    public enum SearchEncryptionWithCmkEnforcement
    {
        Unspecified,
        Disabled,
        Enabled,
    }
}
