// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Diagnostics;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals
{
    internal static class IngestionResponseHelper
    {
        public static string?[] GetErrorsFromResponse(Response? response)
        {
            try
            {
                if (response == null)
                {
                    return Array.Empty<string>();
                }

                var responseContent = response.Content.ToString();

                ResponseObject? responseObj;

#if NET6_0_OR_GREATER
                responseObj = JsonSerializer.Deserialize<ResponseObject>(responseContent, SourceGenerationContext.Default.ResponseObject);
#else
                responseObj = JsonSerializer.Deserialize<ResponseObject>(responseContent);
#endif

                if (responseObj == null || responseObj.Errors == null)
                {
                    return Array.Empty<string>();
                }

                return responseObj.Errors.Select(x => x.Message).ToArray();
            }
            catch (Exception ex)
            {
                AzureMonitorExporterEventSource.Log.FailedToDeserializeIngestionResponse(ex);
                return Array.Empty<string>();
            }
        }

        // This class needs to be internal rather than private so that it can be used by the System.Text.Json source generator
        internal class ResponseObject
        {
            [JsonPropertyName("itemsReceived")]
            public int ItemsReceived { get; set; }

            [JsonPropertyName("itemsAccepted")]
            public int ItemsAccepted { get; set; }

            [JsonPropertyName("errors")]
            public List<ErrorObject>? Errors { get; set; }
        }

        // This class needs to be internal rather than private so that it can be used by the System.Text.Json source generator
        internal class ErrorObject
        {
            [JsonPropertyName("index")]
            public int Index { get; set; }

            [JsonPropertyName("statusCode")]
            public int StatusCode { get; set; }

            [JsonPropertyName("message")]
            public string? Message { get; set; }
        }
    }
}
