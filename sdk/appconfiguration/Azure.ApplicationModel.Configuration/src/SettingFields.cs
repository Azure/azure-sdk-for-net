// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;

namespace Azure.ApplicationModel.Configuration
{
    /// <summary>
    /// Fields to retrieve from a configuration setting.
    /// </summary>
    [Flags]
    public enum SettingFields : uint
    {
        Key = 0x0001,
        Label = 0x0002,
        Value = 0x0004,
        ContentType = 0x0008,
        ETag = 0x0010,
        LastModified = 0x0020,
        Locked = 0x0040,
        Tags = 0x0080,

        All = uint.MaxValue
    }
}
