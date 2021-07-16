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
            StorageTransferOptions transferOptions,
#pragma warning disable CA1801 // Review unused parameters
            BlobDirectoryUploadOptions options,
#pragma warning restore CA1801 // Review unused parameters
            bool async,
            CancellationToken cancellationToken = default)
        {
            PathScannerFactory scannerFactory = new PathScannerFactory(localPath);
            PathScanner scanner = scannerFactory.BuildPathScanner();
            IEnumerable<FileSystemInfo> fileList = scanner.Scan();

            TransferScheduler fileScheduler = new TransferScheduler((int)(transferOptions.MaximumConcurrency.HasValue && transferOptions.MaximumConcurrency > 0 ? transferOptions.MaximumConcurrency : 1));
            List<Task> tasks = new List<Task>();
            List<Response<BlobContentInfo>> responses = new List<Response<BlobContentInfo>>();

            string fullPath = Path.GetFullPath(localPath);

            foreach (FileSystemInfo file in fileList)
            {
                if (file.GetType() == typeof(DirectoryInfo))
                {
                    continue;
                }

                Task task = Task.Factory.StartNew(() =>
                {
                    responses.Add(GetBlobClient(file.FullName.Substring(fullPath.Length + 1))
                       .Upload(
                           file.FullName,
                           cancellationToken));
                }, cancellationToken, default, fileScheduler);

                tasks.Add(task);
            }

            if (async)
            {
                await Task.WhenAll(tasks).ConfigureAwait(false);
            }
            else
            {
                Task.WaitAll(tasks.ToArray(), cancellationToken);
            }

            return responses;
        }
    }
}
