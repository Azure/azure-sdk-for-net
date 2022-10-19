// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.DataProtectionBackup
{
    // having this customization to anchor the base type to ResourceData since the generator now has issues on that
    public partial class DppBaseResourceData : ResourceData
    {
    }
}
