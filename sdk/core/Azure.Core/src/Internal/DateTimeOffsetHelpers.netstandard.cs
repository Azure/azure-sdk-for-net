// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure
{
    internal static partial class DateTimeOffsetHelpers
    {
        private static DateTimeOffset GetUtcNowImplementation() => DateTimeOffset.UtcNow;
    }
}
