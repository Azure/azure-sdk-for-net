// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;

namespace Microsoft.Azure.WebJobs.Host.Executors
{
    internal static class FunctionParameterLogIntervals
    {
        public static readonly TimeSpan InitialDelay = new TimeSpan(0, 0, 3); // Wait before first Log, small for initial quick log
        public static readonly TimeSpan RefreshRate = new TimeSpan(0, 0, 10); // Between log calls
    }
}
