// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using Azure.Core.Json;

namespace Azure.Core.Dynamic
{
    /// <summary>
    /// Determines how DynamicData handles DateTime and DateTimeOffset when serializing and deserializing.
    /// </summary>
    public enum DynamicDateTimeHandling
    {
        /// <summary>
        /// DateTime and DateTimeOffset values assigned to <see cref="DynamicData"/> will be
        /// serialized, and conversions to DateTime and DateTimeOffset will be deserialized,
        /// as JSON strings, according to the Azure API Guidelines:
        /// https://github.com/microsoft/api-guidelines/blob/vNext/azure/Guidelines.md#json-date-time-is-rfc3339
        ///
        /// DateTime values must have DateTimeKind.Utc, and DateTimeOffset are converted to UTC.
        /// </summary>
        Rfc3339,

        /// <summary>
        /// DateTime and DateTimeOffset values assigned to <see cref="DynamicData"/> will be
        /// serialized, and conversions to DateTime and DateTimeOffset will be deserialized,
        /// as JSON numbers.
        ///
        /// DateTime values must have DateTimeKind.Utc, and DateTimeOffset are converted to UTC.
        /// </summary>
        UnixTime,
    }
}
