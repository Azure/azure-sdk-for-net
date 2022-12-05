// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using Azure.Core;

namespace Azure.Communication.JobRouter
{
    internal static class Utf8JsonWriterExtensions
    {
        public static void WriteStringValue(this Utf8JsonWriter writer, TimeSpan value) =>
            writer.WriteStringValue(TypeFormatters.ToString(value, "c"));
    }
}
