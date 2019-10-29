// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Azure.Storage;
using Azure.Storage.Files.DataLake;
using Azure.Storage.Files.DataLake.Models;
using NUnit.Framework;

namespace Azure.Storage.Files.DataLake.Samples
{
    /// <summary>
    /// Basic Azure DataLake Storage samples.
    /// </summary>
    public class Sample01b_HelloWorldAsync : SampleTest
    {
        /// <summary>
        /// Upload a file to a DataLake File.
        /// </summary>
        [Test]
        public async Task AppendAsync()
        {
            // Create three temporary Lorem Ipsum files on disk that we can upload
            int oneThirdPosition = SampleFileContent.Length / 3;
            string sampleFileContentPart1 = CreateTempFile(SampleFileContent.Substring(0, oneThirdPosition));
            string sampleFileContentPart2 = CreateTempFile(SampleFileContent.Substring(oneThirdPosition, oneThirdPosition + 1));
            string sampleFileContentPart3 = CreateTempFile(SampleFileContent.Substring((oneThirdPosition * 2 + 1), oneThirdPosition + 1));

            // Make StorageSharedKeyCredential to pass to the serviceClient
            string storageAccountName = StorageAccountName;
            string storageAccountKey = StorageAccountKey;
            Uri serviceUri = StorageAccountBlobUri;

            StorageSharedKeyCredential sharedKeyCredential = new StorageSharedKeyCredential(storageAccountName, storageAccountKey);

            // Get a reference to a FileSystemClient
            DataLakeServiceClient serviceClient = new DataLakeServiceClient(serviceUri, sharedKeyCredential);

            // Get a reference to a filesystem named "sample-filesystem-appendasync" and then create it
            DataLakeFileSystemClient filesystem = serviceClient.GetFileSystemClient("sample-filesystem-appendasync");
            await filesystem.CreateAsync();
            try
            {
                // Get a reference to a file named "sample-file" in a filesystem
                DataLakeFileClient file = filesystem.GetFileClient(Randomize("sample-file"));

                // Open the file and upload its data
                await file.CreateAsync();

                await file.AppendAsync(File.OpenRead(sampleFileContentPart1), 0);
                await file.AppendAsync(File.OpenRead(sampleFileContentPart2), oneThirdPosition);
                await file.AppendAsync(File.OpenRead(sampleFileContentPart3), oneThirdPosition * 2 + 1);
                await file.FlushAsync(SampleFileContent.Length);

                // Verify we uploaded one file with some content
                AsyncPageable<PathItem> response = filesystem.ListPathsAsync();
                IList<PathItem> paths = await response.ToListAsync();
                Assert.AreEqual(1, paths.Count);
                PathProperties properties = await file.GetPropertiesAsync();
                Assert.AreEqual(SampleFileContent.Length, properties.ContentLength);
            }
            finally
            {
                // Clean up after the test when we're finished
                await filesystem.DeleteAsync();
            }
        }

        /// <summary>
        /// Download a DataLake File to a file.
        /// </summary>
        [Test]
        public async Task ReadAsync()
        {
            // Create a temporary Lorem Ipsum file on disk that we can upload
            string originalPath = CreateTempFile(SampleFileContent);

            // Get a temporary path on disk where we can download the file
            string downloadPath = CreateTempPath();

            // Make StorageSharedKeyCredential to pass to the serviceClient
            string storageAccountName = StorageAccountName;
            string storageAccountKey = StorageAccountKey;
            Uri serviceUri = StorageAccountBlobUri;
            StorageSharedKeyCredential sharedKeyCredential = new StorageSharedKeyCredential(storageAccountName, storageAccountKey);

            // Create DataLakeServiceClient using StorageSharedKeyCredentials
            DataLakeServiceClient serviceClient = new DataLakeServiceClient(serviceUri, sharedKeyCredential);

            // Get a reference to a filesystem named "sample-filesystem-readasync" and then create it
            DataLakeFileSystemClient filesystem = serviceClient.GetFileSystemClient("sample-filesystem-readasync");
            await filesystem.CreateAsync();
            try
            {
                // Get a reference to a file named "sample-file" in a filesystem named "sample-filesystem"
                DataLakeFileClient file = filesystem.GetFileClient(Randomize("sample-file"));

                // First upload something the DataLake file so we have something to download
                await file.CreateAsync();
                await file.AppendAsync(File.OpenRead(originalPath), 0);
                await file.FlushAsync(SampleFileContent.Length);

                // Download the DataLake file's contents and save it to a file
                Response<FileDownloadInfo> fileContents = await file.ReadAsync();
                using (FileStream stream = File.OpenWrite(downloadPath))
                {
                    fileContents.Value.Content.CopyTo(stream);
                }

                // Verify the contents
                Assert.AreEqual(SampleFileContent, File.ReadAllText(downloadPath));

                await file.DeleteAsync();
            }
            finally
            {
                // Clean up after the test when we're finished
                await filesystem.DeleteAsync();
            }
        }

        /// <summary>
        /// Download our sample image.
        /// </summary>
        [Test]
        public async Task ReadImageAsync()
        {
            // Get a temporary path on disk where we can download the file
            string downloadPath = CreateTempPath();

            // Download the public file at https://aka.ms/bloburl
            Response<FileDownloadInfo> fileDownload = await new DataLakeFileClient(new Uri("https://aka.ms/bloburl")).ReadAsync();
            using (FileStream stream = File.OpenWrite(downloadPath))
            {
                fileDownload.Value.Content.CopyTo(stream);
            }
        }

        /// <summary>
        /// List all the DataLake directories in a filesystem.
        /// </summary>
        [Test]
        public async Task ListAsync()
        {
            // Make StorageSharedKeyCredential to pass to the serviceClient
            string storageAccountName = StorageAccountName;
            string storageAccountKey = StorageAccountKey;
            Uri serviceUri = StorageAccountBlobUri;
            StorageSharedKeyCredential sharedKeyCredential = new StorageSharedKeyCredential(storageAccountName, storageAccountKey);

            // Create DataLakeServiceClient using StorageSharedKeyCredentials
            DataLakeServiceClient serviceClient = new DataLakeServiceClient(serviceUri, sharedKeyCredential);

            // Get a reference to a filesystem named "sample-filesystem-listasync" and then create it
            DataLakeFileSystemClient filesystem = serviceClient.GetFileSystemClient("sample-filesystem-listasync");
            await filesystem.CreateAsync();
            try
            {
                // Upload a couple of directories so we have something to list
                await filesystem.CreateDirectoryAsync("sample-directory1");
                await filesystem.CreateDirectoryAsync("sample-directory2");
                await filesystem.CreateDirectoryAsync("sample-directory3");

                // List all the directories
                List<string> names = new List<string>();
                AsyncPageable<PathItem> response = filesystem.ListPathsAsync();
                IList<PathItem> paths = await response.ToListAsync();
                foreach (PathItem pathItem in paths)
                {
                    names.Add(pathItem.Name);
                }
                Assert.AreEqual(3, paths.Count);
                Assert.Contains("sample-directory1", names);
                Assert.Contains("sample-directory2", names);
                Assert.Contains("sample-directory3", names);
            }
            finally
            {
                // Clean up after the test when we're finished
                await filesystem.DeleteAsync();
            }
        }

        /// <summary>
        /// Traverse the DataLake Files and DataLake Directories in a DataLake filesystem.
        /// </summary>
        [Test]
        public async Task TraverseAsync()
        {
            // Create a temporary Lorem Ipsum file on disk that we can upload
            string originalPath = CreateTempFile(SampleFileContent);

            // Make StorageSharedKeyCredential to pass to the serviceClient
            string storageAccountName = StorageAccountName;
            string storageAccountKey = StorageAccountKey;
            Uri serviceUri = StorageAccountBlobUri;
            StorageSharedKeyCredential sharedKeyCredential = new StorageSharedKeyCredential(storageAccountName, storageAccountKey);

            // Create DataLakeServiceClient using StorageSharedKeyCredentials

            DataLakeServiceClient serviceClient = new DataLakeServiceClient(serviceUri, sharedKeyCredential);

            // Get a reference to a filesystem named "sample-filesystem-traverseasync" and then create it
            DataLakeFileSystemClient filesystem = serviceClient.GetFileSystemClient("sample-filesystem-traverseasync");

            await filesystem.CreateAsync();
            try
            {
                // Create a bunch of directories and files within the directories
                DataLakeDirectoryClient first = await filesystem.CreateDirectoryAsync("first");
                await first.CreateSubDirectoryAsync("a");
                await first.CreateSubDirectoryAsync("b");
                DataLakeDirectoryClient second = await filesystem.CreateDirectoryAsync("second");
                await second.CreateSubDirectoryAsync("c");
                await second.CreateSubDirectoryAsync("d");
                await filesystem.CreateDirectoryAsync("third");
                DataLakeDirectoryClient fourth = await filesystem.CreateDirectoryAsync("fourth");
                DataLakeDirectoryClient deepest = await fourth.CreateSubDirectoryAsync("e");

                // Upload a DataLake file named "file"
                DataLakeFileClient file = deepest.GetFileClient("file");
                await file.CreateAsync();
                using (FileStream stream = File.OpenRead(originalPath))
                {
                    await file.AppendAsync(stream, 0);
                }

                // Keep track of all the names we encounter
                List<string> names = new List<string>();
                AsyncPageable<PathItem> response = filesystem.ListPathsAsync(recursive: true);
                IList<PathItem> paths = await response.ToListAsync();
                foreach (PathItem pathItem in paths)
                {
                    names.Add(pathItem.Name);
                }

                // Verify we've seen everything
                Assert.AreEqual(10, paths.Count);
                Assert.Contains("first", names);
                Assert.Contains("second", names);
                Assert.Contains("third", names);
                Assert.Contains("fourth", names);
                Assert.Contains("first/a", names);
                Assert.Contains("first/b", names);
                Assert.Contains("second/c", names);
                Assert.Contains("second/d", names);
                Assert.Contains("fourth/e", names);
                Assert.Contains("fourth/e/file", names);
            }
            finally
            {
                // Clean up after the test when we're finished
                await filesystem.DeleteAsync();
            }
        }

        /// <summary>
        /// Trigger a recoverable error.
        /// </summary>
        [Test]
        public async Task ErrorsAsync()
        {
            // Make StorageSharedKeyCredential to pass to the serviceClient
            string storageAccountName = StorageAccountName;
            string storageAccountKey = StorageAccountKey;
            Uri serviceUri = StorageAccountBlobUri;
            StorageSharedKeyCredential sharedKeyCredential = new StorageSharedKeyCredential(storageAccountName, storageAccountKey);

            // Create DataLakeServiceClient using StorageSharedKeyCredentials
            DataLakeServiceClient serviceClient = new DataLakeServiceClient(serviceUri, sharedKeyCredential);

            // Get a reference to a container named "sample-filesystem-errorsasync" and then create it
            DataLakeFileSystemClient filesystem = serviceClient.GetFileSystemClient("sample-filesystem-errorsasync");
            await filesystem.CreateAsync();
            try
            {
                // Try to create the filesystem again
                await filesystem.CreateAsync();
            }
            catch (RequestFailedException ex)
                when (ex.ErrorCode == Constants.Blob.Container.AlreadyExists)
            {
                // Ignore any errors if the filesystem already exists
            }
            catch (RequestFailedException ex)
            {
                Assert.Fail($"Unexpected error: {ex}");
            }

            // Clean up after the test when we're finished
            await filesystem.DeleteAsync();
        }

        /// <summary>
        /// Set permissions in the access control list and gets access control list on a DataLake File
        /// </summary>
        [Test]
        public async Task SetPermissionsAsync()
        {
            // Make StorageSharedKeyCredential to pass to the serviceClient
            string storageAccountName = NamespaceStorageAccountName;
            string storageAccountKey = NamespaceStorageAccountKey;
            Uri serviceUri = StorageAccountNamespaceUri;
            StorageSharedKeyCredential sharedKeyCredential = new StorageSharedKeyCredential(storageAccountName, storageAccountKey);

            // Create DataLakeServiceClient using StorageSharedKeyCredentials
            DataLakeServiceClient serviceClient = new DataLakeServiceClient(serviceUri, sharedKeyCredential);

            // Get a reference to a filesystem named "sample-filesystem-aclasync" and then create it
            DataLakeFileSystemClient filesystem = serviceClient.GetFileSystemClient("sample-filesystem-perasync");
            await filesystem.CreateAsync();
            try
            {
                // Create a DataLake file so we can set the Access Controls on the files
                DataLakeFileClient fileClient = filesystem.GetFileClient("sample-file");
                await fileClient.CreateAsync();

                // Make Access Control List and Set Access Control List
                await fileClient.SetPermissionsAsync(permissions: "0777");

                // Get Access Control List
                PathAccessControl accessControlreturn = await fileClient.GetAccessControlAsync();

                //Check Access Control permissions
                Assert.AreEqual("rwxrwxrwx", accessControlreturn.Permissions);
            }
            finally
            {
                // Clean up after the test when we're finished
                await filesystem.DeleteAsync();
            }
        }

        /// <summary>
        /// Set and gets access control list on a DataLake File.
        /// </summary>
        [Test]
        public async Task SetGetAclsAsync()
        {
            // Make StorageSharedKeyCredential to pass to the serviceClient
            string storageAccountName = NamespaceStorageAccountName;
            string storageAccountKey = NamespaceStorageAccountKey;
            Uri serviceUri = StorageAccountNamespaceUri;
            StorageSharedKeyCredential sharedKeyCredential = new StorageSharedKeyCredential(storageAccountName, storageAccountKey);

            // Create DataLakeServiceClient using StorageSharedKeyCredentials
            DataLakeServiceClient serviceClient = new DataLakeServiceClient(serviceUri, sharedKeyCredential);

            // Get a reference to a filesystem named "sample-filesystem-aclasync" and then create it
            DataLakeFileSystemClient filesystem = serviceClient.GetFileSystemClient("sample-filesystem-aclasync");
            await filesystem.CreateAsync();
            try
            {
                // Create a DataLake file so we can set the Access Controls on the files
                DataLakeFileClient fileClient = filesystem.GetFileClient("sample-file");
                await fileClient.CreateAsync();

                // Make Access Control List and Set Access Control List
                await fileClient.SetAccessControlAsync("user::rwx,group::r--,mask::rwx,other::---");

                // Get Access Control List
                PathAccessControl accessControlreturn = await fileClient.GetAccessControlAsync();

                //Check accessControl permissions
                Assert.AreEqual("user::rwx,group::r--,mask::rwx,other::---", accessControlreturn.Acl);
            }
            finally
            {
                // Clean up after the test when we're finished
                await filesystem.DeleteAsync();
            }
        }

        /// <summary>
        /// Rename a DataLake file and a DatLake directories in a DataLake Filesystem.
        /// </summary>
        [Test]
        public async Task Rename()
        {
            // Make StorageSharedKeyCredential to pass to the serviceClient
            string storageAccountName = StorageAccountName;
            string storageAccountKey = StorageAccountKey;
            Uri serviceUri = StorageAccountBlobUri;
            StorageSharedKeyCredential sharedKeyCredential = new StorageSharedKeyCredential(storageAccountName, storageAccountKey);

            // Create DataLakeServiceClient using StorageSharedKeyCredentials
            DataLakeServiceClient serviceClient = new DataLakeServiceClient(serviceUri, sharedKeyCredential);

            // Get a reference to a filesystem named "sample-filesystem-rename" and then create it
            DataLakeFileSystemClient filesystem = serviceClient.GetFileSystemClient("sample-filesystem-renameasync");
            await filesystem.CreateAsync();
            try
            {
                // Create a DataLake Directory to rename it later
                DataLakeDirectoryClient directoryClient = filesystem.GetDirectoryClient("sample-directory");
                await directoryClient.CreateAsync();

                // Rename the sample directory
                await directoryClient.RenameAsync("sample-directory2");

                // Delete the sample directory using the new path/name
                await filesystem.DeleteDirectoryAsync("sample-directory2");

                // Create a DataLake file.
                DataLakeFileClient fileClient = filesystem.GetFileClient("sample-file");
                await fileClient.CreateAsync();

                // Rename the sample file
                await fileClient.RenameAsync("sample-file2");

                // Delete the sample directory using the new path/name
                await filesystem.DeleteFileAsync("sample-file2");
            }
            finally
            {
                // Clean up after the test when we're finished
                await filesystem.DeleteAsync();
            }
        }
    }
}
