// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Cdn.Models
{
    // Customization: This file adds the old constructor to ValidateSecretContent for backward API compatibility with the previous SDK.
    // Reason: The old SDK constructor accepted (SecretType, WritableSubResource) parameters,
    // but after the TypeSpec migration, the secretSource parameter type was changed to CdnResourceReference.
    // The old constructor is preserved here, internally converting WritableSubResource to CdnResourceReference,
    // and marked as EditorBrowsable.Never.
    public partial class ValidateSecretContent
    {
        // Backward compatibility: old API used ctor(SecretType, WritableSubResource)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ValidateSecretContent(SecretType secretType, WritableSubResource secretSource) : this(secretType)
        {
            if (secretSource != null)
            {
                SecretSource = new CdnResourceReference { Id = secretSource.Id };
            }
        }
    }
}
