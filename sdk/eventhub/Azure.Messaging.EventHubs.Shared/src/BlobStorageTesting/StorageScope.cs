// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Azure.Storage.Blobs;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///  Provides a dynamically created Azure blob container instance which exists only in the context
    ///  of the scope; disposal removes the instance.
    /// </summary>
    ///
    /// <seealso cref="System.IAsyncDisposable" />
    ///
    public sealed class StorageScope : IAsyncDisposable
    {
        /// <summary>The set of characters considered invalid in a blob container name.</summary>
        private static readonly Regex InvalidContainerCharactersExpression = new Regex("[^a-z0-9]", RegexOptions.IgnoreCase | RegexOptions.Compiled);

        /// <summary>Serves as a sentinel flag to denote when the instance has been disposed.</summary>
        private volatile bool _disposed = false;

        /// <summary>
        ///  The name of the blob storage container that was created.
        /// </summary>
        ///
        public string ContainerName { get; }

        /// <summary>
        ///   Initializes a new instance of the <see cref="StorageScope"/> class.
        /// </summary>
        ///
        /// <param name="containerName">The name of the blob container that was created.</param>
        ///
        private StorageScope(string containerName)
        {
            ContainerName = containerName;
        }

        /// <summary>
        ///   Performs the tasks needed to remove the dynamically created blob container.
        /// </summary>
        ///
        public async ValueTask DisposeAsync()
        {
            if (_disposed)
            {
                return;
            }

            try
            {
                var options = new BlobClientOptions();
                options.Retry.MaxRetries = LiveResourceManager.RetryMaximumAttempts;

                var containerClient = new BlobContainerClient(StorageTestEnvironment.Instance.StorageConnectionString, ContainerName, options);
                await containerClient.DeleteIfExistsAsync().ConfigureAwait(false);
            }
            catch
            {
                // This should not be considered a critical failure that results in a test failure.  Due
                // to ARM being temperamental, some management operations may be rejected.  Throwing here
                // does not help to ensure resource cleanup only flags the test itself as a failure.
                //
                // If a blob container fails to be deleted, removing of the associated storage account at the end
                // of the test run will also remove the orphan.
            }

            _disposed = true;
        }

        /// <summary>
        ///   Performs the tasks needed to create a new blob container instance with a dynamically assigned unique name.
        /// </summary>
        ///
        /// <param name="caller">The name of the calling method; this is intended to be populated by the runtime.</param>
        ///
        /// <returns>The <see cref="StorageScope" /> in which the test should be executed.</returns>
        ///
        public static async Task<StorageScope> CreateAsync([CallerMemberName] string caller = "")
        {
            caller = InvalidContainerCharactersExpression.Replace(caller.ToLowerInvariant(), string.Empty);
            caller = (caller.Length < 16) ? caller : caller.Substring(0, 15);

            string CreateName() => $"{ Guid.NewGuid().ToString("D").Substring(0, 13) }-{ caller }";

            var attempts = 0;
            var capturedException = default(Exception);

            // There is an unlikely possibility of a name collision for tests with longer names; allow retrying
            // with a new name after the client has applied its default policy.

            while (++attempts < LiveResourceManager.RetryMaximumAttempts)
            {
                try
                {
                    var containerClient = new BlobContainerClient(StorageTestEnvironment.Instance.StorageConnectionString, CreateName());
                    await containerClient.CreateAsync().ConfigureAwait(false);

                    return new StorageScope(containerClient.Name);
                }
                catch (Exception ex)
                {
                    // Ignore and allow the loop to retry with a new name, but capture
                    // for bubbling in case the scope could not be created after retries.

                    capturedException = ex;
                }
            }

            // If this code path is taken, there was an exception captured that
            // should be surfaced.

            ExceptionDispatchInfo.Capture(capturedException).Throw();
            return default;
        }
    }
}
