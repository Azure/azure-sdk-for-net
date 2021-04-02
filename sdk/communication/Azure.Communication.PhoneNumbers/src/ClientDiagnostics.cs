// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using Azure.Communication.PhoneNumbers;
using Azure.Core;

namespace Azure.Core.Pipeline
{
    internal partial class ClientDiagnostics
    {
        /// <summary>
        /// Partial method that can optionally be defined to extract the error
        /// message, code, and details in a service specific manner.
        /// </summary>
        /// <param name="content">The error content.</param>
        /// <param name="responseHeaders">The response headers.</param>
        /// <param name="message">The error message.</param>
        /// <param name="errorCode">The error code.</param>
        /// <param name="additionalInfo">Additional error details.</param>
#pragma warning disable CA1822 // Mark members as static
        partial void ExtractFailureContent(
#pragma warning restore CA1822 // Mark members as static
            string content,
#pragma warning disable CA1801 // Review unused parameters
            ResponseHeaders responseHeaders,
            ref string message,
            ref string errorCode,
            ref IDictionary<string, string> additionalInfo
#pragma warning restore CA1801 // Review unused parameters
            )
        {
            if (string.IsNullOrEmpty(content))
            {
                return;
            }

            try
            {
                using var document = JsonDocument.Parse(content);

                foreach (var property in document.RootElement.EnumerateObject())
                {
                    if (property.NameEquals("error"))
                    {
                        var communicationError = CommunicationError.DeserializeCommunicationError(property.Value);
                        errorCode = communicationError.Code;
                        message = communicationError.Message;
                        additionalInfo = new Dictionary<string, string>() { ["target"] = communicationError.Target };
                        break;
                    }
                }
            }
            catch
            { }
        }
    }
}
