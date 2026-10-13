// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.Search.Documents.Utilities
{
    internal static class PageableExtensions
    {
        public static Response<IReadOnlyList<T>> ToBufferedList<T>(this Pageable<T> source)
        {
            Argument.AssertNotNull(source, nameof(source));

            List<T> values = new List<T>();
            Response response = null;
            foreach (Page<T> page in source.AsPages())
            {
                response ??= page.GetRawResponse();
                values.AddRange(page.Values);
            }
            return Response.FromValue<IReadOnlyList<T>>(values, response);
        }

        public static async Task<Response<IReadOnlyList<T>>> ToBufferedListAsync<T>(this AsyncPageable<T> source)
        {
            Argument.AssertNotNull(source, nameof(source));

            List<T> values = new List<T>();
            Response response = null;
            await foreach (Page<T> page in source.AsPages().ConfigureAwait(false))
            {
                response ??= page.GetRawResponse();
                values.AddRange(page.Values);
            }
            return Response.FromValue<IReadOnlyList<T>>(values, response);
        }
    }
}
