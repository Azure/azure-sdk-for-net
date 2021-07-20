// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Files.DataLake.Models;

namespace Azure.Storage.Files.DataLake
{
    internal class DataLakeDownloadScheduler : DataLakePathClient
    {
        internal DataLakeDownloadScheduler(
            Uri baseUri,
            DataLakeClientConfiguration clientConfiguration)
            : base(
                  baseUri,
                  clientConfiguration)
        {
        }

        // TODO: Add options object usage and remove pragma
        public async Task<IEnumerable<Response>> StartTransfer(
            string targetPath,
            DataLakeRequestConditions conditions,
            StorageTransferOptions transferOptions,
            bool async,
            CancellationToken cancellationToken = default)
        {
            string fullPath = System.IO.Path.GetFullPath(targetPath);

            DataLakeUriBuilder dataLakeUriBuilder = new DataLakeUriBuilder(Uri);
            string directoryName = dataLakeUriBuilder.DirectoryOrFilePath;

            DataLakeDirectoryClient directoryClient = new DataLakeDirectoryClient(Uri, ClientConfiguration);

            Pageable<PathItem> paths = directoryClient.GetPaths(recursive: true, cancellationToken: cancellationToken);

            int concurrency = (int)(transferOptions.MaximumConcurrency.HasValue && transferOptions.MaximumConcurrency > 0 ? transferOptions.MaximumConcurrency : 1);
            TaskThrottler throttler = new TaskThrottler(concurrency);

            List<Response> responses = new List<Response>();

            foreach (PathItem path in paths)
            {
                if (!(bool)path.IsDirectory)
                {
                    string resolvedName = path.Name.Substring(directoryName != null ? directoryName.Length + 1 : 0);

                    DataLakeFileClient client = directoryClient.GetFileClient(resolvedName);
                    string downloadPath = System.IO.Path.Combine(fullPath, resolvedName);

                    throttler.AddTask(async () =>
                    {
                        Directory.CreateDirectory(System.IO.Path.GetDirectoryName(downloadPath));
                        using (Stream destination = File.Create(downloadPath))
                        {
                            responses.Add(await client.ReadToAsync(
                                destination,
                                conditions,
                                transferOptions,
                                cancellationToken)
                                .ConfigureAwait(false));
                        }
                    });
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

            return responses;
        }
    }
}
