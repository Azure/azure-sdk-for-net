// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Resources.Models;
using ErrorResponse = Azure.ResourceManager.Core.Resources.ErrorResponse;

#nullable enable

namespace Azure.Core.Pipeline
{
    internal sealed partial class ClientDiagnostics : DiagnosticScopeFactory
    {
        private const string V2Wrapper = "error";

#pragma warning disable CA1822 // Mark members as static
        internal ArmException CreateArmExceptionWithContent(Response response)
#pragma warning restore CA1822 // Mark members as static
        {
            // TODO. 1. Should we append Http ReasonPhrase to Message?
            string? content = ReadContentAsync(response, false).EnsureCompleted();

            // Check for v1 or v2 exception
            var jsonDoc = JsonDocument.Parse(content);
            if (!jsonDoc.RootElement.TryGetProperty(V2Wrapper, out JsonElement rootJson))
            {
                rootJson = jsonDoc.RootElement;
            }

            var error = ErrorResponse.DeserializeErrorResponse(rootJson);
            var exception = CreateArmException(error, response.Status);

            // TODO: Set other properties on the top exception
            return exception;
        }

        private ArmException CreateArmException(ErrorResponse error, int httpStatus=0)
        {
            var exception = new ArmException(httpStatus, error.Message, null)
            {
                Code = error.Code,
                Target = error.Target
            };

            // Populate Details property
            var details = new List<ArmException>();
            foreach (var errorItem in error.Details)
            {
                details.Add(CreateArmException(errorItem));
            }
            exception.Details = details.ToArray();

            // Populate AdditionalInfo via Data
            if (error.AdditionalInfo != null)
            {
                foreach (var item in error.AdditionalInfo)
                {
                    exception.Data.Add(item.Type, item.Info);
                }
            }

            return exception;
        }
    }
}
