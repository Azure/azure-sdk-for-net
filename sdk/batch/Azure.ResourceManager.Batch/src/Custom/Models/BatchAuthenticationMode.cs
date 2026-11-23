// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Batch.Models
{
    // Older API versions can still return TaskAuthenticationToken.
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
