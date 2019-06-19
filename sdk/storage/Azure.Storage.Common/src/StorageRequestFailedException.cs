// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.Storage
{
    /// <summary>
    /// Provide helpful information about errors calling Azure Storage endpoints.
    /// </summary>
#pragma warning disable CA1032 // Implement standard exception constructors
    public partial class StorageRequestFailedException : RequestFailedException
#pragma warning restore CA1032 // Implement standard exception constructors
    {
        /// <summary>
        /// Well known error codes for common failure conditions
        /// </summary>
        public string ErrorCode { get; set; }

        /// <summary>
        /// Additional information helpful in debugging errors.
        /// </summary>
        public IDictionary<string, string> AdditionalInformation { get; internal set; } = new Dictionary<string, string>();

        /// <summary>
        /// Gets the x-ms-request-id header that uniquely identifies the
        /// request that was made and can be used for troubleshooting.
        /// </summary>
        public string RequestId { get; private set; }

        /// <summary>
        /// Create a new StorageRequestFailedException.
        /// </summary>
        /// <param name="response">Response of the failed request.</param>
        /// <param name="message">Summary of the failure.</param>
        public StorageRequestFailedException(Response response, string message = null)
            : this(response, message, null)
        {
        }

        /// <summary>
        /// Create a new StorageRequestFailedException.
        /// </summary>
        /// <param name="response">Response of the failed request.</param>
        /// <param name="message">Summary of the failure.</param>
        /// <param name="innerException">Inner exception.</param>
        public StorageRequestFailedException(Response response, string message, Exception innerException)
            : base(response.Status, CreateMessage(response, message), innerException)
            => this.RequestId = GetRequestId(response);

        /// <summary>
        /// Create a new StorageRequestFailedException.
        /// </summary>
        /// <param name="response">Response of the failed request.</param>
        /// <param name="message">Summary of the failure.</param>
        /// <param name="innerException">Inner exception.</param>
        private StorageRequestFailedException(int status, string message, string requestId)
            : base(status, message)
            => this.RequestId = requestId;

        /// <summary>
        /// Create a new StorageRequestFailedException.
        /// </summary>
        /// <param name="response">Response of the failed request.</param>
        /// <param name="message">Summary of the failure.</param>
        /// <returns>A new StorageRequestFailedException.</returns>
        public static async Task<StorageRequestFailedException> CreateAsync(Response response, string message)
        {
            message = await ResponseExceptionExtensionsExtensions.CreateRequestFailedMessageAsync(message, response, true).ConfigureAwait(false);
            return new StorageRequestFailedException(response.Status, message, GetRequestId(response));
        }

        /// <summary>
        /// Builds a request failure message, synchronously.
        /// </summary>
        /// <param name="response">Response of the failed request.</param>
        /// <param name="message">Summary of the failure.</param>
        /// <returns>The request failure message.</returns>
        private static string CreateMessage(Response response, string message)
            => ResponseExceptionExtensionsExtensions.CreateRequestFailedMessageAsync(message, response, false).GetAwaiter().GetResult();

        /// <summary>
        /// Gets the x-ms-request-id header that uniquely identifies the
        /// request that was made and can be used for troubleshooting.
        /// </summary>
        /// <param name="response">Response of the failed request.</param>
        /// <returns>
        /// The x-ms-request-id header that uniquely identifies the request
        /// that was made and can be used for troubleshooting.
        /// </returns>
        private static string GetRequestId(Response response)
            => response.Headers.TryGetValue("x-ms-request-id", out var value) ? value : null;
    }
}
