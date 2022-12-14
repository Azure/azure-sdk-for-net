// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Text.Json;
using Azure.AI.TextAnalytics;
using Azure.AI.TextAnalytics.Legacy;
using Azure.AI.TextAnalytics.Models;

#nullable enable

namespace Azure.Core.Pipeline
{
    /// <summary>
    /// RequestFailedDetailsParser to customize the exceptions thrown by the generated code.
    /// </summary>
    internal sealed class TextAnalyticsFailedDetailsParser : RequestFailedDetailsParser
    {
        public override bool TryParse(Response response, out ResponseError? error, out IDictionary<string, string>? data)
        {
            data = default;
            error = default;

            if (response.ContentStream is { CanSeek: true })
            {
                var position = response.ContentStream.Position;
                try
                {
                    // Try to parse the failure content and use that as the
                    // default value for the message, error code, etc.

                    response.ContentStream.Position = 0;
                    using JsonDocument doc = JsonDocument.Parse(response.ContentStream);
                    if (doc.RootElement.TryGetProperty("error", out JsonElement errorElement))
                    {
                        var textAnalyticsError = Transforms.ConvertToError(Error.DeserializeError(errorElement));
                        error = new ResponseError(textAnalyticsError.ErrorCode.ToString(), textAnalyticsError.Message);
                        return true;
                    }

                    if (doc.RootElement.TryGetProperty("errors", out JsonElement errorElements))
                    {
                        var errors = new List<Error>();
                        foreach (var item in errorElements.EnumerateArray())
                        {
                            errors.Add(Error.DeserializeError(item));
                        }

                        GetResponseError(errors, out error, out data);
                        return true;
                    }

                    if (doc.RootElement.TryGetProperty("results", out JsonElement results) && results.TryGetProperty("errors", out errorElements))
                    {
                        var errors = new List<Error>();
                        foreach (var item in errorElements.EnumerateArray())
                        {
                            errors.Add(InputError.DeserializeInputError(item).Error);
                        }

                        GetResponseError(errors, out error, out data);
                        return true;
                    }
                }
                catch (JsonException)
                {
                    // Ignore any failures - unexpected content will be
                    // included verbatim in the detailed error message
                }
                finally
                {
                    response.ContentStream.Position = position;
                }
            }

            return false;
        }

        private static void GetResponseError(List<Error> errors, out ResponseError? responseError, out IDictionary<string, string> data)
        {
            data = new Dictionary<string, string>();
            if (errors.Count > 0)
            {
                var textAnalyticsError = Transforms.ConvertToError(errors[0]);
                responseError = new ResponseError(textAnalyticsError.ErrorCode.ToString(), textAnalyticsError.Message);
                if (!string.IsNullOrEmpty(textAnalyticsError.Target))
                {
                    data.Add("Target", textAnalyticsError.Target);
                }
            }
            else
            {
                responseError = default;
            }

            int index = 0;
            foreach (var error in errors)
            {
                data.Add($"error-{index}", $"{error.Code}: {error.Message}");
                index++;
            }
        }
    }
}
