// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure.AI.TextAnalytics;
using Azure.AI.TextAnalytics.Models;

#nullable enable

namespace Azure.Core.Pipeline
{
    internal sealed class TextAnalyticsRequestFailedDetailsParser : RequestFailedDetailsParser
    {
        /// <summary>
        /// Customize the exception messages we throw from the protocol layer by
        /// attempting to parse them as <see cref="TextAnalyticsError"/>s.
        /// </summary>
        public override bool TryParse(Response response, out ResponseError? error, out IDictionary<string, string>? data)
        {
            error = null;
            data = null;
            if (response.ContentStream == null || !response.ContentStream.CanSeek)
            {
                return false;
            }

            try
            {
                string content = response.Content.ToString();
                // Try to parse the failure content and use that as the
                // default value for the message, error code, etc.
                using JsonDocument doc = JsonDocument.Parse(content);
                if (doc.RootElement.TryGetProperty("error", out JsonElement errorElement))
                {
                    TextAnalyticsError taError = Transforms.ConvertToError(Error.DeserializeError(errorElement));

                    error = new ResponseError(taError.ErrorCode.ToString(), taError.Message);
                    return true;
                }
            }
            catch (JsonException)
            {
                // Ignore any failures - unexpected content will be
                // included verbatim in the detailed error message
            }

            return false;
        }
    }
}
