// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Globalization;

namespace Azure.Storage.Common
{
    internal static class StringExtensions
    {
        public static string Invariant(FormattableString formattable)
            => formattable.ToString(CultureInfo.InvariantCulture);
    }
}
