// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Preserves the released SDK contract after this API was removed from the specification.

#nullable disable

namespace Azure.ResourceManager.ProviderHub.Models
{
    /// <summary> The resource access policy. </summary>
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenType("ResourceAccessPolicy")]
    public enum ResourceAccessPolicy
    {
        /// <summary> NotSpecified. </summary>
        NotSpecified,
        /// <summary> AcisReadAllowed. </summary>
        AcisReadAllowed,
        /// <summary> AcisActionAllowed. </summary>
        AcisActionAllowed
    }
}
