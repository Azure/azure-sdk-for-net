// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.Cdn.Models
{
    public partial class UriSigningKeyProperties
    {
        // Backward compatibility: old API used WritableSubResource secretSource parameter
        [EditorBrowsable(EditorBrowsableState.Never)]
        public UriSigningKeyProperties(string keyId, Azure.ResourceManager.Resources.Models.WritableSubResource secretSource) : base(SecretType.UriSigningKey)
        {
            Argument.AssertNotNull(keyId, nameof(keyId));
            Argument.AssertNotNull(secretSource, nameof(secretSource));

            KeyId = keyId;
            SecretSource = new ResourceReference { Id = secretSource.Id };
        }
    }
}
