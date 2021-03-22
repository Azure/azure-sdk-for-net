// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.ResourceManager.Core;

#nullable enable

namespace Azure.Core.Pipeline
{
    internal sealed partial class ClientDiagnostics : DiagnosticScopeFactory
    {
        internal ArmException CreateArmExceptionWithContent(Response response)
        {
            string? content = ReadContentAsync(response, false).EnsureCompleted();

            string message = string.Empty;
            string errorCode = string.Empty;
            IDictionary<string, string>? additionalInfo = new Dictionary<string, string>();

#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            ExtractFailureContent(content, response.Headers, ref message, ref errorCode, ref additionalInfo);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

            var exception = new ArmException(response.Status, message??string.Empty, null);

            if (additionalInfo != null)
            {
                foreach (KeyValuePair<string, string> keyValuePair in additionalInfo)
                {
                    exception.Data.Add(keyValuePair.Key, keyValuePair.Value);
                }
            }

            return exception;
        }

#pragma warning disable CA1822 // Member can be static
        partial void ExtractFailureContent(
#pragma warning disable CA1801 // Review unused parameters
            string? content,
#pragma warning restore CA1801 // Review unused parameters
#pragma warning disable CA1801 // Review unused parameters
            ResponseHeaders responseHeaders,
#pragma warning restore CA1801 // Review unused parameters
            ref string? message,
            ref string? errorCode,
            ref IDictionary<string, string>? additionalInfo)
        {
            message = "hello";
            errorCode = "yes";

            additionalInfo?.Add("Yes", "sir");
        }
#pragma warning restore CA1822
    }
}
