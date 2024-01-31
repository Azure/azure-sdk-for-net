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
                long position = response.ContentStream.Position;

                try
                {
                    // Try to extract the standard Azure Error object from the response so that we can use it as the
                    // default value for the message, error code, etc.

                    response.ContentStream.Position = 0;
                    using JsonDocument doc = JsonDocument.Parse(response.ContentStream);
                    if (doc.RootElement.TryGetProperty("error", out JsonElement errorElement))
                    {
                        TextAnalyticsError textAnalyticsError = Transforms.ConvertToError(Error.DeserializeError(errorElement));
                        error = new ResponseError(textAnalyticsError.ErrorCode.ToString(), textAnalyticsError.Message);
                        return true;
                    }

                    // If the response does not straight up correspond to the standard Azure Error object that we are
                    // looking for, the Error object must actually be nested somewhere in there instead. For example,
                    // this can happen in the case of the convenience methods that receive a single input document as a
                    // parameter instead of a list of input documents. Here, rather than returning the typical
                    // successful response that includes a list of errors that the user needs to look through, we
                    // want to grab the first error in that list (which inevitably corresponds to a problem with the
                    // single input document), and use that error to throw a useful RequestFailedException. Now,
                    // depending on the circumstances, that standard Azure Error could be inside an InputError
                    // object, a DocumentError object, etc., so we need to look for it among a handful of well-known
                    // cases like those.

                    if (doc.RootElement.TryGetProperty("errors", out JsonElement errorsElement))
                    {
                        List<Error> errors = new();

                        foreach (JsonElement item in errorsElement.EnumerateArray())
                        {
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
                        List<Error> errors = new();

                        foreach (JsonElement item in errorsElement.EnumerateArray())
                        {
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
