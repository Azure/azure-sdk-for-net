// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;

namespace Azure.Storage
{
    internal static class StringExtensions
    {
        public static string Invariant(FormattableString formattable)
            => formattable.ToString(CultureInfo.InvariantCulture);
    }
}
