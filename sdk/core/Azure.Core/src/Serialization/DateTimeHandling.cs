// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Core.Serialization
{
    /// <summary>
    /// Determines how DynamicData handles DateTime and DateTimeOffset when serializing and deserializing.
    /// </summary>
    public enum DateTimeHandling
    {
        /// <summary>
        /// DateTime and DateTimeOffset values will be serialized and deserialized using
        /// System.Text.Json defaults, i.e. without adding JsonConverters for these types
        /// to JsonSerializationOptions.  The effect will be that these values are serialized
        /// using the ISO 8601-1:2019 format, as described in
        /// https://learn.microsoft.com/en-us/dotnet/standard/datetime/system-text-json-support#support-for-the-iso-8601-12019-format
        /// </summary>
        Iso8601,

        /// <summary>
        /// DateTime and DateTimeOffset values will be serialized, and conversions to
        /// DateTime and DateTimeOffset will be deserialized, as JSON strings, according to
        /// the Azure API Guidelines:
        /// https://github.com/microsoft/api-guidelines/blob/vNext/azure/Guidelines.md#json-date-time-is-rfc3339
        ///
        /// DateTime values must have DateTimeKind.Utc, and DateTimeOffset are converted to UTC.
        /// </summary>
        Rfc3339,

        /// <summary>
        /// DateTime and DateTimeOffset values will be serialized, and conversions to
        /// DateTime and DateTimeOffset will be deserialized, as JSON numbers.
        ///
        /// DateTime values must have DateTimeKind.Utc, and DateTimeOffset are converted to UTC.
        /// </summary>
        UnixTime,
    }
}
