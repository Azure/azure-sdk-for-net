// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Messaging.EventGrid.SystemEvents
{
    internal static partial class MediaJobErrorCodeExtensions
    {
        public static MediaJobErrorCode ToMediaJobErrorCode(this string value)
        {
            if (string.Equals(value, "ServiceError", StringComparison.InvariantCultureIgnoreCase)) return MediaJobErrorCode.ServiceError;
            if (string.Equals(value, "ServiceTransientError", StringComparison.InvariantCultureIgnoreCase)) return MediaJobErrorCode.ServiceTransientError;
            if (string.Equals(value, "DownloadNotAccessible", StringComparison.InvariantCultureIgnoreCase)) return MediaJobErrorCode.DownloadNotAccessible;
            if (string.Equals(value, "DownloadTransientError", StringComparison.InvariantCultureIgnoreCase)) return MediaJobErrorCode.DownloadTransientError;
            if (string.Equals(value, "UploadNotAccessible", StringComparison.InvariantCultureIgnoreCase)) return MediaJobErrorCode.UploadNotAccessible;
            if (string.Equals(value, "UploadTransientError", StringComparison.InvariantCultureIgnoreCase)) return MediaJobErrorCode.UploadTransientError;
            if (string.Equals(value, "ConfigurationUnsupported", StringComparison.InvariantCultureIgnoreCase)) return MediaJobErrorCode.ConfigurationUnsupported;
            if (string.Equals(value, "ContentMalformed", StringComparison.InvariantCultureIgnoreCase)) return MediaJobErrorCode.ContentMalformed;
            if (string.Equals(value, "ContentUnsupported", StringComparison.InvariantCultureIgnoreCase)) return MediaJobErrorCode.ContentUnsupported;
            if (string.Equals(value, "IdentityUnsupported", StringComparison.InvariantCultureIgnoreCase)) return MediaJobErrorCode.IdentityUnsupported;
            // use Max Int for unknown values
            return (MediaJobErrorCode)int.MaxValue;
        }
    }
}
