// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.Json;
using System.Xml.Linq;
using Azure.Core.Pipeline;
using Azure.Storage.Files.DataLake.Models;

namespace Azure.Storage.Files.DataLake
{
    internal static class ErrorExtensions
    {
// clientDiagnostics parameter is a pattern expected by the codegenerator
#pragma warning disable CA1801
        internal static Exception CreateException(this string body, ClientDiagnostics clientDiagnostics, Response response)
#pragma warning restore CA1801
        {
            // xml
            if (response.Headers.ContentType != null
                && response.Headers.ContentType.Contains("application/xml"))
            {
                XElement error = XDocument.Parse(body).Element("Error");
                string code = error.Element("Code").Value.ToString(CultureInfo.InvariantCulture);
                string message = error.Element("Message").Value.ToString(CultureInfo.InvariantCulture);
                return clientDiagnostics.CreateRequestFailedExceptionWithContent(
                    response: response,
                    message: message,
                    errorCode: code);
            }
            // json
            else if (response.Headers.ContentType != null
                && response.Headers.ContentType.Contains("application/json"))
            {
                JsonDocument json = JsonDocument.Parse(body);
                JsonElement error = json.RootElement.GetProperty("error");

                IDictionary<string, string> details = default;
                if (error.TryGetProperty("detail", out JsonElement detail))
                {
                    details = new Dictionary<string, string>();
                    foreach (JsonProperty property in detail.EnumerateObject())
                    {
                        details[property.Name] = property.Value.GetString();
                    }
                }

                return clientDiagnostics.CreateRequestFailedExceptionWithContent(
                    response: response,
                    message: error.GetProperty("message").GetString(),
                    errorCode: error.GetProperty("code").GetString(),
                    additionalInfo: details);
            }
            else
            {
                return new RequestFailedException(
                    status: response.Status,
                    errorCode: response.Status.ToString(CultureInfo.InvariantCulture),
                    message: response.ReasonPhrase,
                    innerException: new Exception());
            }
        }
    }
}
