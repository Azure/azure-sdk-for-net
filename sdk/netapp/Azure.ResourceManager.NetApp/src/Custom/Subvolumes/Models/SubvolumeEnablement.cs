// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.ResourceManager.NetApp.Models
{
    // A present value with a null string represents the default legacy enum, not an omitted field.
    internal readonly struct SubvolumeEnablement
    {
        internal SubvolumeEnablement(string value) => Value = value;

        internal string Value { get; }

        [Obsolete("This method is only for the obsolete subvolume APIs.")]
        internal static SubvolumeEnablement? FromLegacy(EnableNetAppSubvolume? value)
            => value.HasValue ? new SubvolumeEnablement(value.Value.ToString()) : null;

        [Obsolete("This method is only for the obsolete subvolume APIs.")]
        internal static EnableNetAppSubvolume? ToLegacy(SubvolumeEnablement? value)
            => value.HasValue
                ? value.Value.Value is string text ? new EnableNetAppSubvolume(text) : default(EnableNetAppSubvolume)
                : default(EnableNetAppSubvolume?);
    }
}
