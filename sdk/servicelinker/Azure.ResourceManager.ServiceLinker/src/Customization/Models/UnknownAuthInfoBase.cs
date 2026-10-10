// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.ServiceLinker.Models
{
    // Renaming AuthInfoBase changes the generated discriminator fallback to UnknownAuthBaseInfo;
    // map it back so PersistableModelProxyAttribute retains the GA metadata contract.
    [CodeGenType("UnknownAuthBaseInfo")]
    internal partial class UnknownAuthInfoBase
    {
    }
}
