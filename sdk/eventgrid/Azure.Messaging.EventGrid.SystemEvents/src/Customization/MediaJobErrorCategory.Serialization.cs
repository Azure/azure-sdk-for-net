// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Messaging.EventGrid.SystemEvents
{
    internal static partial class MediaJobErrorCategoryExtensions
    {
        public static string ToSerialString(this MediaJobErrorCategory value) => value switch
        {
            MediaJobErrorCategory.Service => "Service",
            MediaJobErrorCategory.Download => "Download",
            MediaJobErrorCategory.Upload => "Upload",
            MediaJobErrorCategory.Configuration => "Configuration",
            MediaJobErrorCategory.Content => "Content",
            MediaJobErrorCategory.Account => "Account",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown MediaJobErrorCategory value.")
        };
    }
}
