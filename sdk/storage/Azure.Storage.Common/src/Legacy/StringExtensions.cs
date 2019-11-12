// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;

namespace Azure.Storage
{
    [Obsolete("This type is only available for backwards compatibility with the 12.0.0 version of Storage libraries. It should not be used for new development.", true)]
    internal static class StringExtensions
    {
        public static string Invariant(FormattableString formattable)
            => formattable.ToString(CultureInfo.InvariantCulture);
    }
}
