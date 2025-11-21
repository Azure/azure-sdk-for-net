// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable
using System;
using Azure;
using Azure.Core;

namespace Azure.AI.ContentUnderstanding
{
    /// <summary>
    /// Extension methods for <see cref="Operation{T}"/> to provide convenience APIs.
    /// </summary>
    public static class OperationExtensions
    {
        /// <summary>
        /// Gets the operation ID from the Operation-Location header of the operation response.
        /// </summary>
        /// <typeparam name="T">The type of the operation result.</typeparam>
        /// <param name="operation">The operation instance.</param>
        /// <returns>The operation ID extracted from the Operation-Location header, or null if not found.</returns>
        /// <exception cref="ArgumentNullException"> <paramref name="operation"/> is null. </exception>
        public static string? GetOperationId<T>(this Operation<T> operation) where T : notnull
        {
            Argument.AssertNotNull(operation, nameof(operation));

            var rawResponse = operation.GetRawResponse();
            if (rawResponse.Headers.TryGetValue("Operation-Location", out var operationLocation))
            {
                // Extract operation ID from the URL: .../analyzerResults/{operationId}
                if (Uri.TryCreate(operationLocation, UriKind.Absolute, out var uri))
                {
                    var segments = uri.Segments;
                    if (segments.Length > 0)
                    {
                        return segments[segments.Length - 1].TrimEnd('/');
                    }
                }
            }

            return null;
        }
    }
}