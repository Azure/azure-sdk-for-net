// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Monitor.OpenTelemetry.Exporter
{
    internal static class StringExtensions
    {
        public static string Trim(this string message, int lastIndex)
        {
            return message.Substring(0, lastIndex);
        }
    }
}
