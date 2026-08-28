// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.DataMigration.Models
{
    // The new generator creates "UnknownServerConnectionInfo" but
    // the old GA API exposed [PersistableModelProxy(typeof(UnknownConnectionInfo))].
    [CodeGenType("UnknownServerConnectionInfo")]
    internal partial class UnknownConnectionInfo : ServerConnectionInfo
    {
    }
}
