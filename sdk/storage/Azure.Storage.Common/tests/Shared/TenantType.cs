// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Storage.Test
{
    [Flags]
    public enum TenantType
    {
        None = 0x0,
        DevStore = 0x1,
        DevFabric = 0x2,
        Cloud = 0x4,
        All = 0x7
    }
}
