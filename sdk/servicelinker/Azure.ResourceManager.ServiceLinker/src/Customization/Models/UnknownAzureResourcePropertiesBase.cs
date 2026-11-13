// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.ServiceLinker.Models
{
    // Renaming AzureResourcePropertiesBase changes the generated discriminator fallback name;
    // map it back so PersistableModelProxyAttribute retains the GA metadata contract.
    [CodeGenType("UnknownAzureResourceBaseProperties")]
    internal partial class UnknownAzureResourcePropertiesBase
    {
    }
}
