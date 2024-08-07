// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Monitor.OpenTelemetry.AspNetCore.LiveMetrics.Filtering
{
    internal enum Predicate
    {
        Equal = 0,

        NotEqual = 1,

        LessThan = 2,

        GreaterThan = 3,

        LessThanOrEqual = 4,

        GreaterThanOrEqual = 5,

        Contains = 6,

        DoesNotContain = 7,
    }
}
