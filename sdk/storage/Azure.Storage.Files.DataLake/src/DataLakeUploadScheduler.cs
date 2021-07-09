// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Files.DataLake.Models;

namespace Azure.Storage.Files.DataLake
{
    internal class DataLakeUploadScheduler : DataLakePathClient
    {

        internal DataLakeUploadScheduler(
            Uri baseUri,
            DataLakeClientConfiguration clientConfiguration)
            : base(
                  baseUri,
                  clientConfiguration)
        {
        }

        /// <summary>
        /// Creates a new <see cref="DataLakeFileClient"/> object by appending
        /// <paramref name="fileName"/> to the end of <see cref="Uri"/>.  The
        /// new <see cref="DataLakeFileClient"/> uses the same request policy
        /// pipeline as the <see cref="DataLakeDirectoryClient"/>.
        /// </summary>
        /// <param name="fileName">The name of the file.</param>
        /// <returns>A new <see cref="DataLakeFileClient"/> instance.</returns>
        public virtual DataLakeFileClient GetFileClient(string fileName)
            => new DataLakeFileClient(
                Uri,
                $"{Path}/{fileName}",
                ClientConfiguration);

        public async Task<IEnumerable<Response<PathInfo>>> StartTransfer(
            string localPath,
            StorageTransferOptions transferOptions,
            DataLakeDirectoryUploadOptions options,
            bool async,
            CancellationToken cancellationToken = default)
        {
            PathScannerFactory scannerFactory = new PathScannerFactory(localPath);
            PathScanner scanner = scannerFactory.BuildPathScanner();
            IEnumerable<string> fileList = scanner.Scan();

            TransferScheduler fileScheduler = new TransferScheduler((int)(transferOptions.MaximumConcurrency.HasValue && transferOptions.MaximumConcurrency > 0 ? transferOptions.MaximumConcurrency : 1));
            List<Task> tasks = new List<Task>();
            List<Response<PathInfo>> responses = new List<Response<PathInfo>>();

            string fullPath = System.IO.Path.GetFullPath(localPath);

            foreach (string file in fileList)
            {
                if (file == fullPath)
                {
                    continue;
                }

                Task task = Task.Factory.StartNew(() =>
                {
                    responses.Add(GetFileClient(file.Substring(fullPath.Length + 1))
                       .Upload(
                           file,
                           overwrite: false,
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
