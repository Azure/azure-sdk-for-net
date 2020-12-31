// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Xml.Linq;

#nullable enable

namespace Azure.Core.Pipeline
{
    internal sealed partial class ClientDiagnostics
    {
#pragma warning disable CA1822 // Member can be static
        partial void ExtractFailureContent(
            string? content,
            ref string? message,
            ref string? errorCode,
#pragma warning disable CA1801 // Remove unused parameter
            ref IDictionary<string, string>? additionalInfo)
#pragma warning restore CA1801 // Remove unused parameter
#pragma warning restore CA1822 // Member can be static
        {
            if (string.IsNullOrWhiteSpace(content))
            {
                return;
            }

            try
            {
                var errorContentXml = XElement.Parse(content);
                XElement detail = errorContentXml.Element("Detail");

                message = detail?.Value ?? content;
                Match? match = Regex.Match(
                    detail?.Value,
                    "SubCode=(\\d+)\\.");
                if (match.Success)
                {
                    errorCode = match.Groups[1].Value;
                }
            }
            catch (Exception)
            {
                message = content;
            }
        }
    }
}
