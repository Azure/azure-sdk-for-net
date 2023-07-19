// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Azure.Core;

namespace Azure.Storage
{
    /// <summary>
    /// Provide helpful information about errors calling Azure Storage endpoints.
    /// </summary>
    internal static class StorageExceptionExtensions
    {
        /// <summary>
        /// Attempt to get the error code from a response if it's not provided.
        /// </summary>
        /// <param name="response">The response.</param>
        /// <param name="errorCode">An optional error code.</param>
        /// <returns>The response's error code.</returns>
        public static string GetErrorCode(this Response response, string errorCode)
        {
            if (string.IsNullOrEmpty(errorCode))
            {
                response.Headers.TryGetValue(Constants.HeaderNames.ErrorCode, out errorCode);
            }
            return errorCode;
        }

        /// <summary>
        /// Check if a Response will throw an exception if you try to access
        /// its Value property.
        /// </summary>
        /// <typeparam name="T">Type of the Response Value.</typeparam>
        /// <param name="response">The response to check.</param>
        /// <returns>True if the response will throw.</returns>
        public static bool IsUnavailable<T>(this Response<T> response) =>
            (response?.GetRawResponse().Status ?? 0) == 304;

        /// <summary>
        /// Create a response that will throw an exception if you try to access
        /// its Value property.
        /// </summary>
        /// <typeparam name="T">Type of the Response Value.</typeparam>
        /// <param name="rawResponse">The raw response.</param>
        /// <returns>A response that will throw if accessed.</returns>
        public static Response<T> AsNoBodyResponse<T>(this Response rawResponse) =>
            new NoBodyResponse<T>(rawResponse);
    }
}
