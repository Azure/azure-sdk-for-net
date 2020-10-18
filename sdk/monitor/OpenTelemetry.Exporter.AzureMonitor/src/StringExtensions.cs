// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace OpenTelemetry.Exporter.AzureMonitor
{
    internal static class StringExtensions
    {
        public static string TrimEnd(this string message, string suffixToRemove)
        {
            return message.Substring(0, message.Length - suffixToRemove.Length);
        }
    }
}
