// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.ServiceLinker.Models
{
    // Renaming SecretInfoBase changes the generated discriminator fallback to UnknownSecretBaseInfo;
    // map it back so PersistableModelProxyAttribute retains the GA metadata contract.
    [CodeGenType("UnknownSecretBaseInfo")]
    internal partial class UnknownSecretInfoBase
    {
    }
}
