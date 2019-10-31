// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using Azure.Storage;
using Azure.Storage.Files.Shares;
using Azure.Storage.Files.Shares.Models;
using NUnit.Framework;

namespace Azure.Storage.Files.Shares.Samples
{
    /// <summary>
    /// Basic Azure File Storage samples
    /// </summary>
    public class Sample01a_HelloWorld : SampleTest
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
        public static void Upload(string connectionString, string shareName, string localFilePath)
        {
            #region Snippet:Azure_Storage_Files_Shares_Samples_Sample01a_HelloWorld_Upload
            // Get a connection string to our Azure Storage account.  You can
            // obtain your connection string from the Azure Portal (click
            // Access Keys under Settings in the Portal Storage account blade)
            // or using the Azure CLI with:
            //
            //     az storage account show-connection-string --name <account_name> --resource-group <resource_group>
            //
            // And you can provide the connection string to your application
            // using an environment variable.
            //@@ string connectionString = "<connection_string>";

            // Name of the share, directory, and file we'll create
            //@@ string shareName = "sample-share";
            string dirName = "sample-dir";
            string fileName = "sample-file";

            // Path to the local file to upload
            //@@ string localFilePath = @"<path_to_local_file>";

            // Get a reference to a share and then create it
            ShareClient share = new ShareClient(connectionString, shareName);
            share.Create();

            // Get a reference to a directory and create it
            ShareDirectoryClient directory = share.GetDirectoryClient(dirName);
            directory.Create();

            // Get a reference to a file and upload it
            ShareFileClient file = directory.GetFileClient(fileName);
            using (FileStream stream = File.OpenRead(localFilePath))
            {
                file.Create(stream.Length);
                file.UploadRange(
                    ShareFileRangeWriteType.Update,
                    new HttpRange(0, stream.Length),
                    stream);
            }
            #endregion Snippet:Azure_Storage_Files_Shares_Samples_Sample01a_HelloWorld_Upload
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
        public static void Download(string connectionString, string shareName, string localFilePath)
        {
            #region Snippet:Azure_Storage_Files_Shares_Samples_Sample01a_HelloWorld_Download
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
            ShareFileDownloadInfo download = file.Download();
            using (FileStream stream = File.OpenWrite(localFilePath))
            {
                download.Content.CopyTo(stream);
            }
            #endregion Snippet:Azure_Storage_Files_Shares_Samples_Sample01a_HelloWorld_Download
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
        public static void Traverse(string connectionString, string shareName)
        {
            #region Snippet:Azure_Storage_Files_Shares_Samples_Sample01a_HelloWorld_Traverse
            // Connect to the share
            //@@ string connectionString = "<connection_string>";
            //@@ string shareName = "sample-share";
            ShareClient share = new ShareClient(connectionString, shareName);

            // Track the remaining directories to walk, starting from the root
            var remaining = new Queue<ShareDirectoryClient>();
            remaining.Enqueue(share.GetRootDirectoryClient());
            while (remaining.Count > 0)
            {
                // Get all of the next directory's files and subdirectories
                ShareDirectoryClient dir = remaining.Dequeue();
                foreach (ShareFileItem item in dir.GetFilesAndDirectories())
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
            #endregion Snippet:Azure_Storage_Files_Shares_Samples_Sample01a_HelloWorld_Traverse
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
        public static void Errors(string connectionString, string shareName)
        {
            #region Snippet:Azure_Storage_Files_Shares_Samples_Sample01a_HelloWorld_Errors
            // Connect to the existing share
            //@@ string connectionString = "<connection_string>";
            //@@ string shareName = "sample-share";
            ShareClient share = new ShareClient(connectionString, shareName);

            try
            {
                // Try to create the share again
                share.Create();
            }
            catch (RequestFailedException ex)
                when (ex.ErrorCode == ShareErrorCode.ShareAlreadyExists)
            {
                // Ignore any errors if the share already exists
            }
            #endregion Snippet:Azure_Storage_Files_Shares_Samples_Sample01a_HelloWorld_Errors
        }
    }
}
