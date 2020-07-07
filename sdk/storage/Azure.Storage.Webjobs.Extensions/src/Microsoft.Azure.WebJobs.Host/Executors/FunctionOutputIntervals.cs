// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;

namespace Microsoft.Azure.WebJobs.Host.Executors
{
    internal static class FunctionOutputIntervals
    {
        public static readonly TimeSpan InitialDelay = TimeSpan.Zero;
        public static readonly TimeSpan RefreshRate = new TimeSpan(0, 1, 0);
    }
}
