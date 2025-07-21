// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Text.Json;
using System.Xml.Linq;
using Azure.Storage;

#nullable enable

namespace Azure.Core.Pipeline
{
    internal sealed class StorageRequestFailedDetailsParser : RequestFailedDetailsParser
    {
        public override bool TryParse(Response response, out ResponseError? error, out IDictionary<string, string>? data)
        {
            if (response.ContentStream is { } contentStream && response.Headers.ContentType is not null)
            {
                var position = contentStream.CanSeek ? contentStream.Position : 0;
                try
                {
                    if (contentStream.CanSeek)
                    {
                        contentStream.Position = 0;
                    }
                    // XML body
                    if (response.Headers.ContentType.Contains(Constants.ContentTypeApplicationXml))
                    {
                        XDocument xml = XDocument.Load(contentStream);
                        var errorCode = xml.Root!.Element(Constants.ErrorCode)?.Value ??
                            xml.Root.Element(Constants.ErrorCodeLower)?.Value;
                        var message = xml.Root.Element(Constants.ErrorMessage)?.Value ??
                            xml.Root.Element(Constants.ErrorMessageLower)?.Value;
                        var headerName = xml.Root!.Element(Constants.HeaderName)?.Value;

                        data = new Dictionary<string, string>();
                        foreach (XElement element in xml.Root.Elements())
                        {
                            switch (element.Name.LocalName)
                            {
                                case Constants.ErrorCode:
                                case Constants.ErrorMessage:
                                    continue;
                                default:
                                    data[element.Name.LocalName] = element.Value;
                                    break;
                            }
                        }

                        // Clarify exception message if customer has send an x-ms-vesion not enabled on their storage account.
                        if (errorCode == Constants.ErrorCodes.InvalidHeaderValue
                            && headerName != null
                            && headerName == Constants.HeaderNames.Version)
                        {
                            error = new ResponseError(errorCode, Constants.Errors.InvalidVersionHeaderMessage);
                        }
                        else
                        {
                            error = new ResponseError(errorCode, message);
                        }

                        return true;
                    }

                    // Json body
                    if (response.Headers.ContentType.Contains(Constants.ContentTypeApplicationJson))
                    {
                        using JsonDocument json = JsonDocument.Parse(contentStream);
                        JsonElement errorElement = json.RootElement.GetProperty(Constants.ErrorPropertyKey);

                        if (errorElement.TryGetProperty(Constants.DetailPropertyKey, out JsonElement detail)
                            && detail.ValueKind == JsonValueKind.Object)
                        {
                            data = new Dictionary<string, string>();
                            foreach (JsonProperty property in detail.EnumerateObject())
                            {
                                data[property.Name] = property.Value.GetString()!;
                            }
                        }
                        else
                        {
                            data = default;
                        }

                        var message = errorElement.GetProperty(Constants.MessagePropertyKey).GetString();
                        var errorCode = errorElement.GetProperty(Constants.CodePropertyKey).GetString();
                        error = new ResponseError(errorCode, message);
                        return true;
                    }
                }
                finally
                {
                    if (contentStream.CanSeek)
                    {
                        contentStream.Position = position;
                    }
                }
            }
            // No response body.
            // The other headers will appear in the "Headers" section of the Exception message.
            else if (response.Headers.TryGetValue(Constants.HeaderNames.ErrorCode, out string? value))
            {
                data = default;
                error = new ResponseError(value, null);
                return true;
            }

            error = default;
            data = default;
            return false;
        }
    }
}
