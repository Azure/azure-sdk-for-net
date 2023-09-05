// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System.Collections.Generic;
using System.Linq;

namespace Azure.Core
{
    internal static class Page
    {
        public static Page<T> FromValues<T>(IEnumerable<T> values, string continuationToken, Response response) =>
            Page<T>.FromValues(values.ToList(), continuationToken, response);
    }
}
