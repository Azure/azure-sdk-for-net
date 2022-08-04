// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.ServiceLinker.Models
{
    /// <summary>
    /// The secret info
    /// Please note <see cref="SecretBaseInfo"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
    /// The available derived classes include <see cref="KeyVaultSecretReferenceSecretInfo"/>, <see cref="KeyVaultSecretUriSecretInfo"/> and <see cref="RawValueSecretInfo"/>.
    /// </summary>
    public abstract partial class SecretBaseInfo
    {
    }
}
