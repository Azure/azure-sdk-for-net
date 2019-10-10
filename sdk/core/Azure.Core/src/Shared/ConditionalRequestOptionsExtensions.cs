// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Globalization;
using Azure;

namespace Azure.Core.Http
{
    internal static class ConditionalRequestOptionsExtensions
    {
        public static void ApplyHeaders(Request request, ConditionalRequestOptions options)
        {
            if (options.IfMatch.HasValue)
            {
                string value = options.IfMatch.Value == ETag.All ?
                    options.IfMatch.Value.ToString() : $"\"{options.IfMatch.Value.ToString()}\"";
                request.Headers.Add(HttpHeader.Names.IfMatch, value);
            }

            if (options.IfNoneMatch.HasValue)
            {
                string value = options.IfNoneMatch.Value == ETag.All ?
                    options.IfNoneMatch.Value.ToString() : $"\"{options.IfNoneMatch.Value.ToString()}\"";
                request.Headers.Add(HttpHeader.Names.IfNoneMatch, value);
            }

            if (options is DateConditionalRequestOptions dateOptions)
            {
                if (dateOptions.IfModifiedSince.HasValue)
                {
                    request.Headers.Add(HttpHeader.Names.IfModifiedSince, dateOptions.IfModifiedSince.Value.UtcDateTime.ToString("R", CultureInfo.InvariantCulture));
                }

                if (dateOptions.IfUnmodifiedSince.HasValue)
                {
                    request.Headers.Add(HttpHeader.Names.IfUnmodifiedSince, dateOptions.IfUnmodifiedSince.Value.UtcDateTime.ToString("R", CultureInfo.InvariantCulture));
                }
            }
        }
    }
}
