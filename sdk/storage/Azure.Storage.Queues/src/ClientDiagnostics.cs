// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace Azure.Core.Pipeline
{
    internal sealed partial class ClientDiagnostics : DiagnosticScopeFactory
    {
        /// <summary>
        /// Partial method that can optionally be defined to extract the error
        /// message, code, and details in a service specific manner.
        /// </summary>
        /// <param name="content">The error content.</param>
        /// <param name="message">The error message.</param>
        /// <param name="errorCode">The error code.</param>
        /// <param name="additionalInfo">Additional error details.</param>
#pragma warning disable CA1822 // Member can be static
#pragma warning disable CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
        partial void ExtractFailureContent(
            string? content,
            ref string? message,
            ref string? errorCode,
#pragma warning disable CA1801 // Review unused parameters
            ref IDictionary<string, string>? additionalInfo
#pragma warning restore CA1801 // Review unused parameters
#pragma warning restore CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
#pragma warning restore CA1822
            )
        {
            XDocument xml = XDocument.Parse(content);
            errorCode = xml.Root.Element("Code").Value;
            message = xml.Root.Element("Message").Value;
        }
    }
}
