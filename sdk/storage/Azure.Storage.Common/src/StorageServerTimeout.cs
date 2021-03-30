// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core.Pipeline;

namespace Azure.Storage
{
    /// <summary>
    /// Factory for scopes that apply server timeout to Azure Storage calls.
    ///
    /// For more information, see
    /// <see href="https://docs.microsoft.com/rest/api/storageservices/setting-timeouts-for-blob-service-operations">
    /// Setting timeouts for Blob service operations</see>,
    /// <see href="https://docs.microsoft.com/rest/api/storageservices/setting-timeouts-for-file-service-operations">
    /// Setting timeouts for File service operations</see>,
    /// <see href="https://docs.microsoft.com/rest/api/storageservices/setting-timeouts-for-queue-service-operations">
    /// Setting timeouts for Queue service operations</see>.
    /// </summary>
    public static class StorageServerTimeout
    {
        /// <summary>
        /// Creates a scope in which all REST requests to Azure Storage would have provided a server timeout.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/setting-timeouts-for-blob-service-operations">
        /// Setting timeouts for Blob service operations</see>,
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/setting-timeouts-for-file-service-operations">
        /// Setting timeouts for File service operations</see>,
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/setting-timeouts-for-queue-service-operations">
        /// Setting timeouts for Queue service operations</see>.
        /// </summary>
        /// <param name="timeoutInSeconds">The server timeout in seconds for each HTTP request.</param>
        /// <returns>The <see cref="IDisposable"/> instance that needs to be disposed when server timeout shouldn't be used anymore.</returns>
        /// <example>
        /// Sample usage:
        /// <code snippet="Snippet:Sample_StorageServerTimeout">
        /// BlobServiceClient client = new BlobServiceClient(connectionString, options);
        /// using (StorageServerTimeout.CreateScope(10))
        /// {
        ///     client.GetProperties();
        /// }
        /// </code>
        /// </example>
        /// <remarks>
        /// The server timeout is sent to the Azure Storage service for each REST request made within the scope.
        /// This value is not tracked or validated on the client, it is only passed to the Storage service.
        /// </remarks>
        public static IDisposable CreateScope(int? timeoutInSeconds)
        {
            return HttpPipeline.CreateHttpMessagePropertiesScope(new Dictionary<string, object> { { Constants.ServerTimeout.HttpMessagePropertyKey, timeoutInSeconds } });
        }
    }
}
