// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Identity
{
    internal static partial class DateTimeHelpers
    {
        private static DateTime GetUtcNowImplementation() => DateTime.UtcNow;
    }
}
