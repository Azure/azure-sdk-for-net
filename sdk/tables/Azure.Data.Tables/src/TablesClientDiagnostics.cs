// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Globalization;
using System.Text.Json;
using Azure.Data.Tables;
using Azure.Data.Tables.Models;

namespace Azure.Core.Pipeline
{
    internal class TablesClientDiagnostics : ClientDiagnostics
    {
        public TablesClientDiagnostics(ClientOptions options) : base(options)
        {
        }

        /// <summary>
        /// Partial method that can optionally be defined to extract the error
        /// message, code, and details in a service specific manner.
        /// </summary>
        /// <param name="content">The error content.</param>
        /// <param name="responseHeaders">The response headers.</param>
        /// <param name="message">The error message.</param>
        /// <param name="errorCode">The error code.</param>
        /// <param name="additionalInfo">Additional error details.</param>
        protected override void ExtractFailureContent(
            string content,
            ResponseHeaders responseHeaders,
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
                                        message += $"\n The index of the entity that caused the error can be found in {nameof(TableTransactionFailedException.FailedTransactionActionIndex)}.";
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
