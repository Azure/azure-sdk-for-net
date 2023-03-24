// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.AI.OpenAI
{
    internal class TimeConverters
    {
        private static readonly DateTime s_epochStartUtc = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        internal static DateTime DateTimeFromUnixEpoch(long secondsAfterUnixEpoch)
            => s_epochStartUtc.AddSeconds(secondsAfterUnixEpoch);
    }
}
