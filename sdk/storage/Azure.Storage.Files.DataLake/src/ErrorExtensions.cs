// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.Json;
using Azure.Core.Pipeline;
using Azure.Storage.Files.DataLake.Models;

namespace Azure.Storage.Files.DataLake
{
    internal static class ErrorExtensions
    {
// clientDiagnostics parameter is a pattern expected by the codegenerator
#pragma warning disable CA1801
        internal static Exception CreateException(this string jsonMessage, ClientDiagnostics clientDiagnostics, Response response)
#pragma warning restore CA1801
        {
            if (string.IsNullOrWhiteSpace(jsonMessage))
            {
                return new RequestFailedException(
                    status: response.Status,
                    errorCode: response.Status.ToString(CultureInfo.InvariantCulture),
                    message: response.ReasonPhrase,
                    innerException: new Exception());
            }
            else
            {
                JsonDocument json = JsonDocument.Parse(jsonMessage);
                JsonElement error = json.RootElement.GetProperty("error");

                // Populate message
                StringBuilder sb = new StringBuilder(error.GetProperty("message").GetString());
                if (error.TryGetProperty("detail", out JsonElement detail))
                {
                    foreach (JsonProperty property in detail.EnumerateObject())
                    {
                        sb.Append($"{property.Name} = {property.Value.ToString()}{Environment.NewLine}");
                    }
                }

                return new RequestFailedException(
                    status: response.Status,
                    errorCode: error.GetProperty("code").GetString(),
                    message: sb.ToString(),
                    innerException: new Exception());
            }
        }

    }
}
