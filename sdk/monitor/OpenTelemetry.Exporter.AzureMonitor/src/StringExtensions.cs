// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace OpenTelemetry.Exporter.AzureMonitor
{
    internal static class StringExtensions
    {
        public static string Trim(this string message, int lastIndex)
        {
            return message.Substring(0, lastIndex);
        }
    }
}
