// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Cdn.Models
{
    public partial class UriSigningKeyProperties
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public UriSigningKeyProperties(string keyId, WritableSubResource secretSource)
        {
            Argument.AssertNotNull(keyId, nameof(keyId));
            Argument.AssertNotNull(secretSource, nameof(secretSource));

            KeyId = keyId;
            SecretSource = secretSource;
            SecretType = SecretType.UriSigningKey;
        }
    }
}