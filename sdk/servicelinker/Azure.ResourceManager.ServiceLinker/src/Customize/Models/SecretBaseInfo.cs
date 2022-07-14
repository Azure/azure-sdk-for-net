// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace Azure.ResourceManager.ServiceLinker.Models
{
    /// <summary>
    /// The secret info
    /// Please note <see cref="SecretBaseInfo"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
    /// The available derived classes include <see cref="KeyVaultSecretReferenceSecretInfo"/>, <see cref="KeyVaultSecretUriSecretInfo"/> and <see cref="RawValueSecretInfo"/>.
    /// </summary>
    [CodeGenSuppress("SecretBaseInfo")]
    [CodeGenSuppress("SecretBaseInfo", typeof(LinkerSecretType))]
    public partial class SecretBaseInfo
    {
        /// <summary> The secret type. </summary>
        internal LinkerSecretType SecretType { get; set; }
    }
}
