// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
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

        // TODO: Implement options object usage and remove warning pragma
        public async Task<IEnumerable<Response<PathInfo>>> StartTransfer(
            string localPath,
            StorageTransferOptions transferOptions,
#pragma warning disable CA1801 // Review unused parameters
            DataLakeDirectoryUploadOptions options,
            bool async,
            CancellationToken cancellationToken = default)
#pragma warning restore CA1801 // Review unused parameters
        {
            string fullPath = System.IO.Path.GetFullPath(localPath);

            PathScannerFactory scannerFactory = new PathScannerFactory(fullPath);
            PathScanner scanner = scannerFactory.BuildPathScanner();
            IEnumerable<System.IO.FileSystemInfo> fileList = scanner.Scan();

            int concurrency = (int)(transferOptions.MaximumConcurrency.HasValue && transferOptions.MaximumConcurrency > 0 ? transferOptions.MaximumConcurrency : 1);
            TaskThrottler throttler = new TaskThrottler(concurrency);

            List<Response<PathInfo>> responses = new List<Response<PathInfo>>();

            foreach (System.IO.FileSystemInfo file in fileList)
            {
                if (file.GetType() == typeof(DirectoryInfo))
                {
                    continue;
                }

                throttler.AddTask(async () =>
                {
                    responses.Add(await GetFileClient(file.FullName.Substring(fullPath.Length + 1))
                        .UploadAsync(file.FullName)
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
