﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Drawing;
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

        public static RequestFailedException CreateExceptionForFailedOperation(Response response, IReadOnlyList<FormRecognizerError> errors, string errorMessage = default)
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

            var responseError = new ResponseError(errorCode, errorMessage);
            return new RequestFailedException(response, null, new FormRecognizerRequestFailedDetailsParser(responseError, errorInfo));
        }

        public static RequestFailedException CreateExceptionForFailedOperation(Response response, ResponseError error)
        {
            var additionalInfo = new Dictionary<string, string>(1) { { "AdditionInformation", error.ToString() } };
            return new RequestFailedException(response, null, new FormRecognizerRequestFailedDetailsParser(error, additionalInfo));
        }

        public static RecognizedFormCollection ConvertPrebuiltOutputToRecognizedForms(V2AnalyzeResult analyzeResult)
        {
            List<RecognizedForm> forms = new List<RecognizedForm>();
            for (int i = 0; i < analyzeResult.DocumentResults.Count; i++)
            {
                forms.Add(new RecognizedForm(analyzeResult.DocumentResults[i], analyzeResult.PageResults, analyzeResult.ReadResults, default));
            }
            return new RecognizedFormCollection(forms);
        }

        public static IReadOnlyList<PointF> ConvertToListOfPointF(IReadOnlyList<float> coordinates)
        {
            if (coordinates == null || coordinates.Count == 0)
            {
                return Array.Empty<PointF>();
            }

            List<PointF> points = new List<PointF>();

            for (int i = 0; i < coordinates.Count; i += 2)
            {
                points.Add(new PointF(coordinates[i], coordinates[i + 1]));
            }

            return points;
        }

        private class FormRecognizerRequestFailedDetailsParser : RequestFailedDetailsParser
        {
            private readonly ResponseError _error;
            private readonly IDictionary<string, string> _additionalInfo;

            public FormRecognizerRequestFailedDetailsParser(ResponseError error, IDictionary<string, string> additionalInfo)
            {
                _error = error;
                _additionalInfo = additionalInfo;
            }

            public override bool TryParse(Response response, out ResponseError error, out IDictionary<string, string> data)
            {
                error = _error;
                data = _additionalInfo;
                return true;
            }
        }
    }
}
