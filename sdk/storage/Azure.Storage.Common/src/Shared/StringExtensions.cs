// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;

#if CommonSDK
using Internals = Azure.Storage.Shared.Common;
namespace Azure.Storage.Shared.Common
#else
using Internals = Azure.Storage.Shared;
namespace Azure.Storage.Shared
#endif
{
internal static class StringExtensions
    {
        public static string Invariant(FormattableString formattable)
            => formattable.ToString(CultureInfo.InvariantCulture);
    }
}
