// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Xml.Linq;

#nullable enable

namespace Azure.Core.Pipeline
{
    internal sealed class ServiceBusClientDiagnostics: ClientDiagnostics
    {
        public ServiceBusClientDiagnostics(ClientOptions options) : base(options)
        {
        }

        protected override ResponseError? ExtractFailureContent(
            string? content,
            ResponseHeaders responseHeaders,
            ref IDictionary<string, string>? additionalInfo)
        {
            if (string.IsNullOrWhiteSpace(content))
            {
                return null;
            }

            try
            {
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

                return new ResponseError(errorCode, message);
            }
            catch (Exception)
            {
                return new ResponseError(null, content);
            }
        }
    }
}
