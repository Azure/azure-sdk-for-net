// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Core
{
    /// <summary>
    /// </summary>
    public static class HttpMessageExtensions
    {
        /// <summary>
        /// Stand-in for Response.IsError during experimentation
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static bool ResponseIsError(this HttpMessage message)
        {
            if (message.TryGetProperty("ResponseIsError", out object? isError))
            {
                return (bool)isError!;
            }

            throw new InvalidOperationException("ResponseIsError is not set on message.");
        }

        internal static void EvaluateError(this HttpMessage message)
        {
            bool isError = message.ResponseClassifier.IsErrorResponse(message);
            message.SetProperty("ResponseIsError", isError);
        }
    }
}
