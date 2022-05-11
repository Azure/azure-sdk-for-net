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
#pragma warning disable CA1801 // Review unused parameters
        public static async ValueTask<RequestFailedException> CreateExceptionForFailedOperationAsync(bool async, ClientDiagnostics diagnostics, Response response, IReadOnlyList<TextAnalyticsErrorInternal> errors, string errorMessage = default)
#pragma warning restore CA1801 // Review unused parameters
        {
            //string errorCode = default;

            //if (errors.Count > 0)
            //{
            //    errorCode = errors[0].Code;
            //    errorMessage ??= errors[0].Message;
            //}

            //var errorInfo = new Dictionary<string, string>();
            //int index = 0;
            //foreach (var error in errors)
            //{
            //    errorInfo.Add($"error-{index}", $"{error.Code}: {error.Message}");
            //    index++;
            //}

            //return async
            //    ? await diagnostics.CreateRequestFailedExceptionAsync(response, new ResponseError(errorCode, errorMessage), errorInfo).ConfigureAwait(false)
            //    : diagnostics.CreateRequestFailedException(response, new ResponseError(errorCode, errorMessage), errorInfo);
#pragma warning disable AZC0110 // DO NOT use await keyword in possibly synchronous scope.
            await Task.Yield();
#pragma warning restore AZC0110 // DO NOT use await keyword in possibly synchronous scope.
            throw new NotImplementedException();
        }
    }
}
