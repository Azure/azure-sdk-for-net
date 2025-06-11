// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Messaging.EventGrid.SystemEvents
{
    internal static partial class MediaJobErrorCategoryExtensions
    {
        public static MediaJobErrorCategory ToMediaJobErrorCategory(this string value)
        {
            if (string.Equals(value, "Service", StringComparison.InvariantCultureIgnoreCase)) return MediaJobErrorCategory.Service;
            if (string.Equals(value, "Download", StringComparison.InvariantCultureIgnoreCase)) return MediaJobErrorCategory.Download;
            if (string.Equals(value, "Upload", StringComparison.InvariantCultureIgnoreCase)) return MediaJobErrorCategory.Upload;
            if (string.Equals(value, "Configuration", StringComparison.InvariantCultureIgnoreCase)) return MediaJobErrorCategory.Configuration;
            if (string.Equals(value, "Content", StringComparison.InvariantCultureIgnoreCase)) return MediaJobErrorCategory.Content;
            if (string.Equals(value, "Account", StringComparison.InvariantCultureIgnoreCase)) return MediaJobErrorCategory.Account;
            // use Max Int for unknown values
            return (MediaJobErrorCategory)int.MaxValue;
        }
    }
}