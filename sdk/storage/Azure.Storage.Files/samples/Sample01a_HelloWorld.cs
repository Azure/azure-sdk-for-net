// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using Azure.Core.Http;
using Azure.Storage;
using Azure.Storage.Files;
using Azure.Storage.Files.Models;
using NUnit.Framework;

namespace Azure.Storage.Files.Samples
{
    /// <summary>
    /// Basic Azure File Storage samples
    /// </summary>
    public class Sample01a_HelloWorld : SampleTest
    {
        /// <summary>
        /// Create a share and upload a file.
        /// </summary>
        [Test]
        public void Upload()
        {
            // Create a temporary Lorem Ipsum file on disk that we can upload
            string path = CreateTempFile(SampleFileContent);

            // Get a connection string to our Azure Storage account.  You can
            // obtain your connection string from the Azure Portal (click
            // Access Keys under Settings in the Portal Storage account blade)
            // or using the Azure CLI with:
            //
            //     az storage account show-connection-string --name <account_name> --resource-group <resource_group>
            //
            // And you can provide the connection string to your application
            // using an environment variable.
            string connectionString = ConnectionString;

            // Get a reference to a share named "sample-share" and then create it
            ShareClient share = new ShareClient(connectionString, Randomize("sample-share"));
            share.Create();
            try
            {
                // Get a reference to a directory named "sample-dir" and then create it
                DirectoryClient directory = share.GetDirectoryClient(Randomize("sample-dir"));
                directory.Create();

                // Get a reference to a file named "sample-file" in directory "sample-dir"
                FileClient file = directory.GetFileClient(Randomize("sample-file"));

                // Upload the file
                using (FileStream stream = File.OpenRead(path))
                {
                    file.Create(stream.Length);
                    file.UploadRange(
                        FileRangeWriteType.Update,
                        new HttpRange(0, stream.Length),
                        stream);
                }

                // Verify the file exists
                StorageFileProperties properties = file.GetProperties();
                Assert.AreEqual(SampleFileContent.Length, properties.ContentLength);
            }
            finally
            {
                // Clean up after the test when we're finished
                share.Delete();
            }
        }

        /// <summary>
        /// Download a file.
        /// </summary>
        /// <returns></returns>
        [Test]
        public void Download()
        {
            // Create a temporary Lorem Ipsum file on disk that we can upload
            string originalPath = CreateTempFile(SampleFileContent);

            // Get a temporary path on disk where we can download the file
            string downloadPath = CreateTempPath();

            // Get a connection string to our Azure Storage account.
            string connectionString = ConnectionString;

            // Get a reference to a share named "sample-share" and then create it
            ShareClient share = new ShareClient(connectionString, Randomize("sample-share"));
            share.Create();
            try
            {
                // Get a reference to a directory named "sample-dir" and then create it
                DirectoryClient directory = share.GetDirectoryClient(Randomize("sample-dir"));
                directory.Create();

                // Get a reference to a file named "sample-file" in directory "sample-dir"
                FileClient file = directory.GetFileClient(Randomize("sample-file"));

                // Upload the file
                using (FileStream stream = File.OpenRead(originalPath))
                {
                    file.Create(stream.Length);
                    file.UploadRange(
                        FileRangeWriteType.Update,
                        new HttpRange(0, stream.Length),
                        stream);
                }

                // Download the file
                StorageFileDownloadInfo download = file.Download();
                using (FileStream stream = File.OpenWrite(downloadPath))
                {
                    download.Content.CopyTo(stream);
                }

                // Verify the contents
                Assert.AreEqual(SampleFileContent, File.ReadAllText(downloadPath));
            }
            finally
            {
                // Clean up after the test when we're finished
                share.Delete();
            }
        }

        /// <summary>
        /// Traverse the files and directories in a share.
        /// </summary>
        [Test]
        public void Traverse()
        {
            // Create a temporary Lorem Ipsum file on disk that we can upload
            string originalPath = CreateTempFile(SampleFileContent);

            // Get a connection string to our Azure Storage account.
            string connectionString = ConnectionString;

            // Get a reference to a share named "sample-share" and then create it
            ShareClient share = new ShareClient(connectionString, Randomize("sample-share"));
            share.Create();
            try
            {
                // Create a bunch of directories
                DirectoryClient first = share.CreateDirectory("first");
                first.CreateSubdirectory("a");
                first.CreateSubdirectory("b");
                DirectoryClient second = share.CreateDirectory("second");
                second.CreateSubdirectory("c");
                second.CreateSubdirectory("d");
                share.CreateDirectory("third");
                DirectoryClient fourth = share.CreateDirectory("fourth");
                DirectoryClient deepest = fourth.CreateSubdirectory("e");

                // Upload a file named "file"
                FileClient file = deepest.GetFileClient("file");
                using (FileStream stream = File.OpenRead(originalPath))
                {
                    file.Create(stream.Length);
                    file.UploadRange(
                        FileRangeWriteType.Update,
                        new HttpRange(0, stream.Length),
                        stream);
                }

                // Keep track of all the names we encounter
                List<string> names = new List<string>();

                // Track the remaining directories to walk, starting from the root
                Queue<DirectoryClient> remaining = new Queue<DirectoryClient>();
                remaining.Enqueue(share.GetRootDirectoryClient());
                while (remaining.Count > 0)
                {
                    // Get all of the next directory's files and subdirectories
                    DirectoryClient dir = remaining.Dequeue();
                    foreach (StorageFileItem item in dir.GetFilesAndDirectories())
                    {
                        // Track the name of the item
                        names.Add(item.Name);

                        // Keep walking down directories
                        if (item.IsDirectory)
                        {
                            remaining.Enqueue(dir.GetSubdirectoryClient(item.Name));
                        }
                    }
                }

                // Verify we've seen everything
                Assert.AreEqual(10, names.Count);
                Assert.Contains("first", names);
                Assert.Contains("second", names);
                Assert.Contains("third", names);
                Assert.Contains("fourth", names);
                Assert.Contains("a", names);
                Assert.Contains("b", names);
                Assert.Contains("c", names);
                Assert.Contains("d", names);
                Assert.Contains("e", names);
                Assert.Contains("file", names);
            }
            finally
            {
                // Clean up after the test when we're finished
                share.Delete();
            }
        }

        /// <summary>
        /// Trigger a recoverable error.
        /// </summary>
        [Test]
        public void Errors()
        {
            // Get a connection string to our Azure Storage account.
            string connectionString = ConnectionString;

            // Get a reference to a share named "sample-share" and then create it
            ShareClient share = new ShareClient(connectionString, Randomize("sample-share"));
            share.Create();

            try
            {
                // Try to create the share again
                share.Create();
            }
            catch (StorageRequestFailedException ex)
                when (ex.ErrorCode == FileErrorCode.ShareAlreadyExists)
            {
                // Ignore any errors if the share already exists
            }
            catch (StorageRequestFailedException ex)
            {
                Assert.Fail($"Unexpected error: {ex}");
            }

            // Clean up after the test when we're finished
            share.Delete();
        }
    }
}
