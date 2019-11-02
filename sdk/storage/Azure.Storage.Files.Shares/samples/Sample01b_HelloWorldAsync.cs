// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Azure.Storage;
using Azure.Storage.Files.Shares;
using Azure.Storage.Files.Shares.Models;
using NUnit.Framework;

namespace Azure.Storage.Files.Samples
{
    /// <summary>
    /// Basic Azure File Storage samples
    /// </summary>
    public class Sample01b_HelloWorldAsync : SampleTest
    {
        /// <summary>
        /// Create a share and upload a file.
        /// </summary>
        /// <param name="connectionString">
        /// A connection string to your Azure Storage account.
        /// </param>
        /// <param name="shareName">
        /// The name of the share to create and upload to.
        /// </param>
        /// <param name="localFilePath">
        /// Path of the file to upload.
        /// </param>
        public static async Task UploadAsync(string connectionString, string shareName, string localFilePath)
        {
            // Get a connection string to our Azure Storage account.  You can
            // obtain your connection string from the Azure Portal (click
            // Access Keys under Settings in the Portal Storage account blade)
            // or using the Azure CLI with:
            //
            //     az storage account show-connection-string --name <account_name> --resource-group <resource_group>
            //
            // And you can provide the connection string to your application
            // using an environment variable.

            // Name of the directory and file we'll create
            string dirName = "sample-dir";
            string fileName = "sample-file";

            // Get a reference to a share and then create it
            ShareClient share = new ShareClient(connectionString, shareName);
            await share.CreateAsync();

            // Get a reference to a directory and create it
            ShareDirectoryClient directory = share.GetDirectoryClient(dirName);
            await directory.CreateAsync();

            // Get a reference to a file and upload it
            ShareFileClient file = directory.GetFileClient(fileName);
            using (FileStream stream = File.OpenRead(localFilePath))
            {
                await file.CreateAsync(stream.Length);
                await file.UploadRangeAsync(
                    ShareFileRangeWriteType.Update,
                    new HttpRange(0, stream.Length),
                    stream);
            }
        }

        /// <summary>
        /// Download a file.
        /// </summary>
        /// <param name="connectionString">
        /// A connection string to your Azure Storage account.
        /// </param>
        /// <param name="shareName">
        /// The name of the share to download from.
        /// </param>
        /// <param name="localFilePath">
        /// Path to download the local file.
        /// </param>
        public static async Task DownloadAsync(string connectionString, string shareName, string localFilePath)
        {
            #region Snippet:Azure_Storage_Files_Shares_Samples_Sample01b_HelloWorldAsync_DownloadAsync
            //@@ string connectionString = "<connection_string>";

            // Name of the share, directory, and file we'll download from
            //@@ string shareName = "sample-share";
            string dirName = "sample-dir";
            string fileName = "sample-file";

            // Path to the save the downloaded file
            //@@ string localFilePath = @"<path_to_local_file>";

            // Get a reference to the file
            ShareClient share = new ShareClient(connectionString, shareName);
            ShareDirectoryClient directory = share.GetDirectoryClient(dirName);
            ShareFileClient file = directory.GetFileClient(fileName);

            // Download the file
            ShareFileDownloadInfo download = await file.DownloadAsync();
            using (FileStream stream = File.OpenWrite(localFilePath))
            {
                await download.Content.CopyToAsync(stream);
            }
            #endregion Snippet:Azure_Storage_Files_Shares_Samples_Sample01b_HelloWorldAsync_DownloadAsync
        }

        /// <summary>
        /// Traverse the files and directories in a share.
        /// </summary>
        /// <param name="connectionString">
        /// A connection string to your Azure Storage account.
        /// </param>
        /// <param name="shareName">
        /// The name of the share to traverse.
        /// </param>
        public static async Task TraverseAsync(string connectionString, string shareName)
        {
            ShareClient share = new ShareClient(connectionString, shareName);

            // Track the remaining directories to walk, starting from the root
            var remaining = new Queue<ShareDirectoryClient>();
            remaining.Enqueue(share.GetRootDirectoryClient());
            while (remaining.Count > 0)
            {
                // Get all of the next directory's files and subdirectories
                ShareDirectoryClient dir = remaining.Dequeue();
                await foreach (ShareFileItem item in dir.GetFilesAndDirectoriesAsync())
                {
                    // Print the name of the item
                    Console.WriteLine(item.Name);

                    // Keep walking down directories
                    if (item.IsDirectory)
                    {
                        remaining.Enqueue(dir.GetSubdirectoryClient(item.Name));
                    }
                }
            }
        }

        /// <summary>
        /// Trigger a recoverable error.
        /// </summary>
        /// <param name="connectionString">
        /// A connection string to your Azure Storage account.
        /// </param>
        /// <param name="shareName">
        /// The name of an existing share
        /// </param>
        public static async Task ErrorsAsync(string connectionString, string shareName)
        {
            ShareClient share = new ShareClient(connectionString, shareName);
            try
            {
                // Try to create the share again
                await share.CreateAsync();
            }
            catch (RequestFailedException ex)
                when (ex.ErrorCode == ShareErrorCode.ShareAlreadyExists)
            {
                // Ignore any errors if the share already exists
            }
        }
    }
}
