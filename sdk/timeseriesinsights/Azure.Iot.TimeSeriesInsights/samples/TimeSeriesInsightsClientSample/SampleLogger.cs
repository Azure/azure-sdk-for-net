// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Iot.TimeSeriesInsights.Samples
{
    internal static class SampleLogger
    {
        internal static void FatalError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
            Environment.Exit(0);
        }
    }
}
