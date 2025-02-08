// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Xml.Linq;

#nullable enable

namespace Azure.Core.Pipeline
{
    internal sealed class ServiceBusRequestFailedDetailsParser : RequestFailedDetailsParser
    {
        public override bool TryParse(Response response, out ResponseError? error, out IDictionary<string, string>? data)
        {
            data = default;
            if (response.ContentStream is { CanSeek: true, Length: > 0})
            {
                var position = response.ContentStream.Position;
                try
                {
                    response.ContentStream.Position = 0;
                    var errorContentXml = XElement.Load(response.ContentStream);
                    XElement? detail = errorContentXml.Element("Detail");

                    var message = detail?.Value ?? response.Content.ToString();
                    Match? match = Regex.Match(message, "SubCode=(\\d+)\\.");

                    string? errorCode = null;
                    if (match.Success)
                    {
                        errorCode = match.Groups[1].Value;
                    }

                    error = new ResponseError(errorCode, message);
                }
                catch
                {
                    error = new ResponseError(null, response.Content.ToString());
                }
                finally
                {
                    response.ContentStream.Position = position;
                }

                return true;
            }

            error = default;
            return false;
        }
    }
}
