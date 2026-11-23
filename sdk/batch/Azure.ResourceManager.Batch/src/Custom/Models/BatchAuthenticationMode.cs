// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Batch.Models
{
    // Batch API version 2026-10-01 removed TaskAuthenticationToken from AuthenticationMode.
    // Restore the member here so regeneration does not remove a public enum value shipped in SDK 1.7.0.
    /// <summary> The authentication mode for the Batch account. </summary>
    [CodeGenType("BatchAuthenticationMode")]
    public enum BatchAuthenticationMode
    {
        /// <summary> The authentication mode using shared keys. </summary>
        SharedKey,
        /// <summary> The authentication mode using Microsoft Entra ID. </summary>
        Aad,
        /// <summary> The authentication mode using task authentication tokens. </summary>
        TaskAuthenticationToken
    }
}
