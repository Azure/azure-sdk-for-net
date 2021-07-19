// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Files.Shares;
using Azure.Storage.Files.Shares.Models;

namespace Azure.Storage.Files.Shares
{
    internal class ShareUploadScheduler
    {
        /// <summary>
        /// The directory's primary <see cref="Uri"/> endpoint.
        /// </summary>
        private readonly Uri _uri;

        /// <summary>
        /// Gets the directory's primary <see cref="Uri"/> endpoint.
        /// </summary>
        public virtual Uri Uri => _uri;

        /// <summary>
        /// <see cref="ShareClientConfiguration"/>.
        /// </summary>
        private readonly ShareClientConfiguration _clientConfiguration;

        /// <summary>
        /// <see cref="ShareClientConfiguration"/>.
        /// </summary>
        internal virtual ShareClientConfiguration ClientConfiguration => _clientConfiguration;

        internal ShareUploadScheduler(
            Uri baseUri,
            ShareClientConfiguration clientConfiguration)
        {
            _uri = baseUri;
            _clientConfiguration = clientConfiguration;
        }

        /// <summary>
        /// Creates a new <see cref="ShareFileClient"/> object by appending
        /// <paramref name="fileName"/> to the end of <see cref="Uri"/>.  The
        /// new <see cref="ShareFileClient"/> uses the same request policy
        /// pipeline as the <see cref="ShareDirectoryClient"/>.
        /// </summary>
        /// <param name="fileName">The name of the file.</param>
        /// <returns>A new <see cref="ShareFileClient"/> instance.</returns>
        public virtual ShareFileClient GetFileClient(string fileName)
        {
            ShareUriBuilder shareUriBuilder = new ShareUriBuilder(Uri);
            shareUriBuilder.DirectoryOrFilePath += $"/{fileName}";
            return new ShareFileClient(
                shareUriBuilder.ToUri(),
                ClientConfiguration);
        }

        public virtual ShareDirectoryClient GetDirectoryClient(string directoryName)
        {
            ShareUriBuilder shareUriBuilder = new ShareUriBuilder(Uri);
            shareUriBuilder.DirectoryOrFilePath += $"/{directoryName}";
            return new ShareDirectoryClient(
                shareUriBuilder.ToUri(),
                ClientConfiguration);
        }

        // TODO: Implement options object usage and remove warning pragma
        public async Task<IEnumerable<Response<ShareFileUploadInfo>>> StartTransfer(
            string localPath,
            StorageTransferOptions transferOptions,
#pragma warning disable CA1801 // Review unused parameters
            ShareDirectoryUploadOptions options,
#pragma warning restore CA1801 // Review unused parameters
            bool async,
            CancellationToken cancellationToken = default)
        {
            string fullPath = Path.GetFullPath(localPath);

            PathScannerFactory scannerFactory = new PathScannerFactory(localPath);
            PathScanner scanner = scannerFactory.BuildPathScanner();
            IEnumerable<FileSystemInfo> fileList = scanner.Scan();

            int concurrency = (int)(transferOptions.MaximumConcurrency.HasValue && transferOptions.MaximumConcurrency > 0 ? transferOptions.MaximumConcurrency : 1);
            TaskThrottler throttler = new TaskThrottler(concurrency);

            List<Response<ShareFileUploadInfo>> responses = new List<Response<ShareFileUploadInfo>>();

            Queue<FileSystemInfo> files = new();

            foreach (FileSystemInfo file in fileList)
            {
                if (file.FullName == fullPath)
                    continue;

                if (file.GetType() == typeof(DirectoryInfo))
                {
                    throttler.AddTask(async () =>
                    {
                        await GetDirectoryClient(file.FullName.Substring(fullPath.Length + 1))
                            .CreateIfNotExistsAsync(cancellationToken: cancellationToken)
                            .ConfigureAwait(false);
                    });
                }
                else
                {
                    files.Enqueue(file);
                }
            }

            if (async)
            {
                await throttler.WaitAsync().ConfigureAwait(false);
            }
            else
            {
                throttler.Wait();
            }

            while (files.Count > 0)
            {
                FileSystemInfo file = files.Dequeue();

                throttler.AddTask(async () =>
                {
                    using (FileStream stream = new FileStream(file.FullName, FileMode.Open, FileAccess.Read))
                    {
                        ShareFileClient client = GetFileClient(file.FullName.Substring(fullPath.Length + 1));
                        await client.CreateAsync(stream.Length).ConfigureAwait(false);
                        responses.Add(await client.UploadAsync(stream).ConfigureAwait(false));
                    }
                });
            }

            if (async)
            {
                await throttler.WaitAsync().ConfigureAwait(false);
            }
            else
            {
                throttler.Wait();
            }

            return responses;
        }
    }
}
