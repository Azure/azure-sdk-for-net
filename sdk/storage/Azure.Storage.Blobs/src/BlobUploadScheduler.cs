// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Storage.Blobs.Models;

namespace Azure.Storage.Blobs
{
    internal class BlobUploadScheduler
    {
        private readonly Uri _uri;

        /// <summary>
        /// Gets the blob's primary <see cref="Uri"/> endpoint.
        /// </summary>
        public virtual Uri Uri => _uri;

        /// <summary>
        /// <see cref="BlobClientConfiguration"/>.
        /// </summary>
        internal readonly BlobClientConfiguration _clientConfiguration;

        /// <summary>
        /// <see cref="BlobClientConfiguration"/>.
        /// </summary>
        internal virtual BlobClientConfiguration ClientConfiguration => _clientConfiguration;

        /// <summary>
        /// The <see cref="ClientSideEncryptionOptions"/> to be used when sending/receiving requests.
        /// </summary>
        private readonly ClientSideEncryptionOptions _clientSideEncryption;

        /// <summary>
        /// The <see cref="ClientSideEncryptionOptions"/> to be used when sending/receiving requests.
        /// </summary>
        internal virtual ClientSideEncryptionOptions ClientSideEncryption => _clientSideEncryption;

        internal BlobUploadScheduler(Uri baseUri, BlobClientConfiguration clientConfiguration, ClientSideEncryptionOptions clientSideEncryption)
        {
            _uri = baseUri;
            _clientConfiguration = clientConfiguration;
            _clientSideEncryption = clientSideEncryption;
        }

        public virtual BlobClient GetBlobClient(string blobName)
        {
            return new BlobClient(
                Uri.AppendToPath(blobName),
                ClientConfiguration,
                ClientSideEncryption);
        }

        // TODO: Add options object usage and remove pragma
        public async Task<IEnumerable<Response<BlobContentInfo>>> StartTransfer(
            string localPath,
#pragma warning disable CA1801 // Review unused parameters
            StorageTransferOptions transferOptions,
#pragma warning restore CA1801 // Review unused parameters
            BlobDirectoryUploadOptions options,
            bool async,
            CancellationToken cancellationToken = default)
        {
            string fullPath = Path.GetFullPath(localPath);

            PathScannerFactory scannerFactory = new PathScannerFactory(fullPath);
            PathScanner scanner = scannerFactory.BuildPathScanner();
            IEnumerable<FileSystemInfo> fileList = scanner.Scan();

            int concurrency = (int)(options.TransferOptions.MaximumConcurrency.HasValue && options.TransferOptions.MaximumConcurrency > 0 ? options.TransferOptions.MaximumConcurrency : 1);
            TaskThrottler throttler = new TaskThrottler(concurrency);

            List<Response<BlobContentInfo>> responses = new List<Response<BlobContentInfo>>();

            foreach (FileSystemInfo file in fileList)
            {
                if (file.GetType() == typeof(DirectoryInfo))
                {
                    continue;
                }

                throttler.AddTask(async () =>
                {
                    responses.Add(await GetBlobClient(file.FullName.Substring(fullPath.Length + 1))
                       .UploadAsync(
                           file.FullName,
                           cancellationToken)
                       .ConfigureAwait(false));
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
