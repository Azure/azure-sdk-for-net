// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.AI.FormRecognizer.Models;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.AI.FormRecognizer
{
    internal static class ClientCommon
    {
        /// <summary>
        /// Used as part of argument validation. Attempts to create a <see cref="Guid"/> from a <c>string</c> and
        /// throws an <see cref="ArgumentException"/> in case of failure.
        /// </summary>
        /// <param name="modelId">The model identifier to be parsed into a <see cref="Guid"/>.</param>
        /// <param name="paramName">The original parameter name of the <paramref name="modelId"/>. Used to create exceptions in case of failure.</param>
        /// <returns>The <see cref="Guid"/> instance created from the <paramref name="modelId"/>.</returns>
        /// <exception cref="ArgumentException">Thrown when parsing fails.</exception>
        public static Guid ValidateModelId(string modelId, string paramName)
        {
            Guid guid;

            try
            {
                guid = new Guid(modelId);
            }
            catch (Exception ex) when (ex is FormatException || ex is OverflowException)
            {
                throw new ArgumentException($"The {paramName} must be a valid GUID.", paramName, ex);
            }

            return guid;
        }

        public static string GetResponseHeader(ResponseHeaders responseHeaders, string headerName)
        {
            if (responseHeaders.TryGetValue(headerName, out var headerValue))
            {
                return headerValue;
            }
            else
            {
                throw new KeyNotFoundException($"Header '{headerName}' was not present in the response sent by the server.");
            }
        }

        public static async ValueTask<RequestFailedException> CreateExceptionForFailedOperationAsync(bool async, ClientDiagnostics diagnostics, Response response, IReadOnlyList<FormRecognizerError> errors, string errorMessage = default)
        {
            string errorCode = default;

            if (errors.Count > 0)
            {
                errorCode = errors[0].ErrorCode;
                errorMessage ??= errors[0].Message;
            }

            var errorInfo = new Dictionary<string, string>();
            int index = 0;
            foreach (var error in errors)
            {
                errorInfo.Add($"error-{index}", $"{error.ErrorCode}: {error.Message}");
                index++;
            }

            return async
                ? await diagnostics.CreateRequestFailedExceptionAsync(response, errorMessage, errorCode, errorInfo).ConfigureAwait(false)
                : diagnostics.CreateRequestFailedException(response, errorMessage, errorCode, errorInfo);
        }

        public static RecognizedFormCollection ConvertPrebuiltOutputToRecognizedForms(AnalyzeResult analyzeResult)
        {
            List<RecognizedForm> forms = new List<RecognizedForm>();
            for (int i = 0; i < analyzeResult.DocumentResults.Count; i++)
            {
                forms.Add(new RecognizedForm(analyzeResult.DocumentResults[i], analyzeResult.PageResults, analyzeResult.ReadResults, default));
            }
            return new RecognizedFormCollection(forms);
        }
    }
}
