// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Xml.Linq;

#nullable enable

namespace Azure.Core.Pipeline
{
    internal sealed class ServiceBusAdministrationRequestFailedDetailsParser : RequestFailedDetailsParser
    {
        public override bool TryParse(Response response, out ResponseError? error, out IDictionary<string, string>? data)
        {
            error = null;
            data = null;
            string content = string.Empty;

            if (response.ContentStream == null || !response.ContentStream.CanSeek)
            {
                return false;
            }
            try
            {
                content = response.Content.ToString();

                if (string.IsNullOrWhiteSpace(content))
                {
                    return false;
                }

                var errorContentXml = XElement.Parse(content);
                XElement detail = errorContentXml.Element("Detail");

                var message = detail?.Value ?? content;
                Match? match = Regex.Match(
                    detail?.Value,
                    "SubCode=(\\d+)\\.");

                string? errorCode = null;
                if (match.Success)
                {
                    errorCode = match.Groups[1].Value;
                }

                error = new ResponseError(errorCode, message);
                return true;
            }
            catch (Exception)
            {
                error = new ResponseError(null, content);
                return true;
            }
        }
    }
}
