// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;
using System.Threading;

namespace OpenTelemetry.Exporter.AzureMonitor
{
    internal static class ExceptionExtensions
    {
        internal static string ToInvariantString(this Exception exception)
        {
            var originalUICulture = Thread.CurrentThread.CurrentUICulture;

            try
            {
                Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;
                return exception.ToString();
            }
            finally
            {
                Thread.CurrentThread.CurrentUICulture = originalUICulture;
            }
        }
    }
}
