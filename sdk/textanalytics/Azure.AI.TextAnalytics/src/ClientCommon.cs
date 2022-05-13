// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.AI.TextAnalytics.Models;
using Azure.Core.Pipeline;

namespace Azure.AI.TextAnalytics
{
    internal static class ClientCommon
    {
        public static async ValueTask<RequestFailedException> CreateExceptionForFailedOperationAsync(bool async, ClientDiagnostics diagnostics, Response response, IReadOnlyList<Error> errors, string errorMessage = default)
        {
            string errorCode = default;

            if (errors.Count > 0)
            {
                errorCode = errors[0].Code.ToString();
                errorMessage ??= errors[0].Message;
            }

            var errorInfo = new Dictionary<string, string>();
            int index = 0;
            foreach (var error in errors)
            {
                errorInfo.Add($"error-{index}", $"{error.Code}: {error.Message}");
                index++;
            }

            return async
                ? await diagnostics.CreateRequestFailedExceptionAsync(response, new ResponseError(errorCode, errorMessage), errorInfo).ConfigureAwait(false)
                : diagnostics.CreateRequestFailedException(response, new ResponseError(errorCode, errorMessage), errorInfo);
        }
    }
}
