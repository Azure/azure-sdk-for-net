// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Storage
{
    /// <summary>
    /// Extensions and utilities for Azure Storage clients.
    /// </summary>
    public static class StorageExtensions
    {
        /// <summary>
        /// Allows you to specify a server timeout for any Storage operations executing on this thread for the duration of the scope.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/setting-timeouts-for-blob-service-operations">
        /// Setting timeouts for Blob service operations</see>,
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/setting-timeouts-for-file-service-operations">
        /// Setting timeouts for File service operations</see>,
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/setting-timeouts-for-queue-service-operations">
        /// Setting timeouts for Queue service operations</see>.
        /// </summary>
        /// <param name="timeout">The server timeout for each HTTP request.</param>
        /// <returns>The <see cref="IDisposable"/> instance that needs to be disposed when server timeout shouldn't be used anymore.</returns>
        /// <example>
        /// Sample usage:
        /// <code snippet="Snippet:Sample_StorageServerTimeout">
        /// BlobServiceClient client = new BlobServiceClient(connectionString, options);
        /// using (StorageExtensions.CreateServiceTimeoutScope(TimeSpan.FromSeconds(10)))
        /// {
        ///     client.GetProperties();
        /// }
        /// </code>
        /// </example>
        /// <remarks>
        /// The server timeout is sent to the Azure Storage service for each REST request made within the scope.
        /// This value is not tracked or validated on the client, it is only passed to the Storage service.
        ///
        /// Consider passing a <see cref="CancellationToken"/> to client methods
        /// and properly sizing <see cref="RetryOptions.NetworkTimeout"/> when configuring storage clients
        /// as prefered way of enforcing upper boundary of execution time.
        /// </remarks>
        public static IDisposable CreateServiceTimeoutScope(TimeSpan? timeout)
        {
            return HttpPipeline.CreateHttpMessagePropertiesScope(new Dictionary<string, object> { { Constants.ServerTimeout.HttpMessagePropertyKey, timeout } });
        }
    }
}
