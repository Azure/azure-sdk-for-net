// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Cdn.Models
{
    public partial class ValidateSecretContent
    {
        // Backward compatibility: old API used ctor(SecretType, WritableSubResource)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ValidateSecretContent(SecretType secretType, WritableSubResource secretSource) : this(secretType)
        {
            if (secretSource != null)
            {
                SecretSource = new ResourceReference { Id = secretSource.Id };
            }
        }
    }
}
