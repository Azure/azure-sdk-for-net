// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Text.Json;
using Azure.AI.TextAnalytics;
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

                    if (doc.RootElement.TryGetProperty("errors", out JsonElement errorsElement))
                    {
                        var errors = new List<Error>();
                        foreach (JsonElement item in errorsElement.EnumerateArray())
                        {
                            // This element could be the Error object that we are looking for, but it could also be an
                            // InputError or a DocumentError object that is wrapping it instead. Therefore, we must
                            // first check if the element has a property called "error". If it does, the value would
                            // correspond to the actual Error object.
                            if (item.TryGetProperty("error", out errorElement))
                            {
                                errors.Add(Error.DeserializeError(errorElement));
                            }
                            else
                            {
                                errors.Add(Error.DeserializeError(item));
                            }
                        }

                        GetResponseError(errors, out error, out data);
                        return true;
                    }

                    if (doc.RootElement.TryGetProperty("results", out JsonElement results) && results.TryGetProperty("errors", out errorsElement))
                    {
                        var errors = new List<Error>();
                        foreach (JsonElement item in errorsElement.EnumerateArray())
                        {
                            // This element could be the Error object that we are looking for, but it could also be an
                            // InputError or a DocumentError object that is wrapping it instead. Therefore, we must
                            // first check if the element has a property called "error". If it does, the value would
                            // correspond to the actual Error object.
                            if (item.TryGetProperty("error", out errorElement))
                            {
                                errors.Add(Error.DeserializeError(errorElement));
                            }
                            else
                            {
                                errors.Add(Error.DeserializeError(item));
                            }
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
                TextAnalyticsError textAnalyticsError = Transforms.ConvertToError(errors[0]);
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
            foreach (Error error in errors)
            {
                data.Add($"error-{index}", $"{error.Code}: {error.Message}");
                index++;
            }
        }
    }
}
