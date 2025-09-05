// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Messaging.EventGrid.SystemEvents
{
    internal static partial class MediaJobErrorCodeExtensions
    {
        public static string ToSerialString(this MediaJobErrorCode value) => value switch
        {
            MediaJobErrorCode.ServiceError => "ServiceError",
            MediaJobErrorCode.ServiceTransientError => "ServiceTransientError",
            MediaJobErrorCode.DownloadNotAccessible => "DownloadNotAccessible",
            MediaJobErrorCode.DownloadTransientError => "DownloadTransientError",
            MediaJobErrorCode.UploadNotAccessible => "UploadNotAccessible",
            MediaJobErrorCode.UploadTransientError => "UploadTransientError",
            MediaJobErrorCode.ConfigurationUnsupported => "ConfigurationUnsupported",
            MediaJobErrorCode.ContentMalformed => "ContentMalformed",
            MediaJobErrorCode.ContentUnsupported => "ContentUnsupported",
            MediaJobErrorCode.IdentityUnsupported => "IdentityUnsupported",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown MediaJobErrorCode value.")
        };
    }
}
