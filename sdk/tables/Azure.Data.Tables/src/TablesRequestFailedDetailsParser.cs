// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text.Json;
using Azure.Core;

namespace Azure.Data.Tables
{
    internal class TablesRequestFailedDetailsParser : RequestFailedDetailsParser
    {
        public override bool TryParse(Response response, out ResponseError error, out IDictionary<string, string> data)
        {
            error = null;
            data = null;
            if (response.ContentStream == null)
            {
                return false;
            }

            try
            {
                string content = response.Content.ToString();

                if (content.Length == 0)
                {
                    return false;
                }
                data = new Dictionary<string, string>();
                using var document = JsonDocument.Parse(content);
                var odataError = document.RootElement.EnumerateObject();
                odataError.MoveNext();
                if (odataError.Current.Name == "odata.error")
                {
                    string errorCode = null;
                    string message = null;
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
                                        data[TableConstants.ExceptionData.FailedEntityIndex] = failedEntityIndex.ToString(CultureInfo.InvariantCulture);
                                        message += $"\n The index of the entity that caused the error can be found in {nameof(TableTransactionFailedException.FailedTransactionActionIndex)}.";
                                    }
                                    break;
                                }
                            }
                        }
                    }

                    error = new ResponseError(errorCode, message);
                    return true;
                }
            }
            catch { }

            return false;
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
