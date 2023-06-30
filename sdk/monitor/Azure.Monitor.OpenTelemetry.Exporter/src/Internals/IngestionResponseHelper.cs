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

                var responseObj = JsonSerializer.Deserialize<ResponseObject>(responseContent);

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

        private class ResponseObject
        {
            [JsonPropertyName("itemsReceived")]
            public int ItemsReceived { get; set; }

            [JsonPropertyName("itemsAccepted")]
            public int ItemsAccepted { get; set; }

            [JsonPropertyName("errors")]
            public List<ErrorObject>? Errors { get; set; }
        }

        private class ErrorObject
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
