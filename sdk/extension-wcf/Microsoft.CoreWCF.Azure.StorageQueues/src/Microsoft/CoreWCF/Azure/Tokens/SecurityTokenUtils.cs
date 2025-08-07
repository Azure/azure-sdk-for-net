// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.ObjectModel;
using System.Threading;

namespace Microsoft.CoreWCF.Azure.Tokens
{
    internal static class SecurityTokenUtils
    {
        private static long s_nextId = 0;
        private static string s_commonPrefix = "uuid-" + Guid.NewGuid().ToString() + "-";

        internal static string CreateUniqueId() => s_commonPrefix + Interlocked.Increment(ref s_nextId);

        public static DateTime MaxUtcDateTime
        {
            get
            {
                // + and -  TimeSpan.TicksPerDay is to compensate the DateTime.ParseExact (to localtime) overflow.
                return new DateTime(DateTime.MaxValue.Ticks - TimeSpan.TicksPerDay, DateTimeKind.Utc);
            }
        }

        internal static class EmptyReadOnlyCollection<T>
        {
            public static ReadOnlyCollection<T> Instance = new ReadOnlyCollection<T>(Array.Empty<T>());
        }
    }
}
