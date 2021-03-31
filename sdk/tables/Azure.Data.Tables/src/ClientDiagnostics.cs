// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.Json;
using Azure.Core;
using Azure.Data.Tables;

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
#pragma warning restore CA1801 // Review unused parameters
            ref string message,
            ref string errorCode,
            ref IDictionary<string, string> additionalInfo
            )
        {
            if (string.IsNullOrEmpty(content))
            {
                return;
            }

            try
            {
                using var document = JsonDocument.Parse(content);
                var odataError = document.RootElement.EnumerateObject();
                odataError.MoveNext();
                if (odataError.Current.Name == "odata.error")
                {
                    foreach (var odataErrorProp in odataError.Current.Value.EnumerateObject())
                    {
                        if (odataErrorProp.NameEquals("code"))
                        {
                            errorCode = odataErrorProp.Value.GetString();
                            continue;
                        }
                        if (odataErrorProp.NameEquals("message"))
                        {
                            foreach (var msgProperty in odataErrorProp.Value.EnumerateObject())
                            {
                                if (msgProperty.NameEquals("value"))
                                {
                                    message = msgProperty.Value.GetString();
                                    if (TryParseBatchIndex(message, out int failedEntityIndex))
                                    {
                                        additionalInfo ??= new Dictionary<string, string>();
                                        additionalInfo[TableConstants.ExceptionData.FailedEntityIndex] = failedEntityIndex.ToString(CultureInfo.InvariantCulture);
                                        message += $"\nYou can retrieve the entity that caused the error by calling {nameof(TableTransactionalBatch.TryGetFailedEntityFromException)} and passing this exception instance to the method.";
                                    }
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            catch { }
        }

        private static bool TryParseBatchIndex(string message, out int index)
        {
            int colonIndex = message.IndexOf(':');
            if (colonIndex > 0)
            {
                return int.TryParse(message.Substring(0, colonIndex), out index);
            }
            else
            {
                index = -1;
                return false;
            }
        }
    }
}
