// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.Core.Pipeline
{
    /// <summary>
    /// The default <see cref="RequestFailedDetailsParser"/>.
    /// </summary>
    internal class DefaultRequestFailedDetailsParser : RequestFailedDetailsParser
    {
        public override bool TryParse(Response response, out ResponseError? error, out IDictionary<string, string>? data)
            => TryParseDetails(response, out error, out data);

        public static bool TryParseDetails(Response response, out ResponseError? error, out IDictionary<string, string>? data)
        {
            error = null;
            data = null;

            try
            {
                // The response content is buffered at this point.
                string? content = response.Content.ToString();

                // Optimistic check for JSON object we expect
                if (content == null || !content.StartsWith("{", StringComparison.OrdinalIgnoreCase))
                {
                    return false;
                }
                // Try the ErrorResponse format and fallback to the ResponseError format.

#if NET6_0_OR_GREATER
                error = System.Text.Json.JsonSerializer.Deserialize<RequestFailedException.ErrorResponse>(content, ResponseErrorSourceGenerationContext.Default.ErrorResponse)?.Error;
                error ??= System.Text.Json.JsonSerializer.Deserialize<ResponseError>(content, ResponseErrorSourceGenerationContext.Default.ResponseError);
#else
                error = System.Text.Json.JsonSerializer.Deserialize<RequestFailedException.ErrorResponse>(content)?.Error;
                error ??= System.Text.Json.JsonSerializer.Deserialize<ResponseError>(content);
#endif
            }
            catch (Exception)
            {
                // Ignore any failures - unexpected content will be
                // included verbatim in the detailed error message
            }

            return error != null;
        }
    }
}
