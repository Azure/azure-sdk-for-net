//Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Test.Perf;

namespace Azure.Storage.Files.Shares.Perf.Scenarios
{
    internal sealed class ShareClientManager : IAsyncDisposable
    {
        /// <summary>
        /// The client to interact with the Azure storage share.
        /// </summary>
        internal ShareClient FilesShareClient { get; private set; }

        /// <summary>
        /// The client to interact with the Azure storage directory inside the share.
        /// </summary>
        internal ShareDirectoryClient DirectoryClient { get; private set; }

        internal ShareClientManager()
        {
            // See https://docs.microsoft.com/en-us/rest/api/storageservices/naming-and-referencing-shares--directories--files--and-metadata for
            // restrictions on file share naming.
            FilesShareClient = new ShareClient(PerfTestEnvironment.Instance.FileSharesConnectionString, Guid.NewGuid().ToString());
        }

        /// <summary>
        /// Instantiates and creates a <see cref="ShareClient"/> and a <see cref="ShareDirectoryClient"/> for the test.
        /// </summary>
        /// <returns></returns>
        internal async Task CreateShareClientAsync()
        {
            await FilesShareClient.CreateAsync();

            DirectoryClient = FilesShareClient.GetDirectoryClient(Path.GetRandomFileName());
            await DirectoryClient.CreateAsync();
        }

        /// <summary>
        /// Creates a temporary file and fills it with random characters.
        /// </summary>
        /// <param name="size">Size of the file to be created.</param>
        internal static async Task<string> CreateRandomFileAsync(long size)
        {
            string filePath = Path.GetTempFileName();

            using FileStream fileStream = File.OpenWrite(filePath);
            using Stream randomStream = RandomStream.Create(size);

            await randomStream.CopyToAsync(fileStream);

#if DEBUG
            Console.WriteLine($"Created local file {filePath}. Length: {fileStream.Length}");
#endif

            return filePath;
        }

        public async ValueTask DisposeAsync()
        {
            await FilesShareClient.DeleteAsync();
        }

        /// <summary>
        /// Uploads a file to Azure Shares files storage by calling <see cref="ShareFileClient.UploadAsync(Stream, IProgress{long}, CancellationToken)"/>.
        /// </summary>
        /// <param name="filePath">Path of the file to be uploaded.</param>
        /// <param name="cancellationToken">The token used to signal cancellation request.</param>
        /// <returns></returns>
        internal async Task<string> UploadFileAsync(string filePath, CancellationToken cancellationToken)
        {
            ShareFileClient fileClient = DirectoryClient.GetFileClient(Path.GetRandomFileName());

            using (FileStream stream = File.OpenRead(filePath))
            {
                await fileClient.CreateAsync(stream.Length, cancellationToken: cancellationToken);

                Models.ShareFileUploadInfo fileUploadInfo = await fileClient.UploadAsync(stream, cancellationToken: cancellationToken);

#if DEBUG
                Console.WriteLine($"Uploaded file to {fileClient.Path}. Hash: {fileUploadInfo.ContentHash.Length}");
#endif
            }

            return fileClient.Name;
        }
    }
}
