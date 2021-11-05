// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
        /// Create a DataLake File using a DataLakeSystem
        /// </summary>
        [Test]
        public async Task CreateFileClientAsync_Filesystem()
        {
            // Make StorageSharedKeyCredential to pass to the serviceClient
            string storageAccountName = StorageAccountName;
            string storageAccountKey = StorageAccountKey;
            Uri serviceUri = StorageAccountBlobUri;

            StorageSharedKeyCredential sharedKeyCredential = new StorageSharedKeyCredential(storageAccountName, storageAccountKey);

            // Create DataLakeServiceClient using StorageSharedKeyCredentials
            DataLakeServiceClient serviceClient = new DataLakeServiceClient(serviceUri, sharedKeyCredential);

            // Get a reference to a filesystem named "sample-filesystem-append" and then create it
            DataLakeFileSystemClient filesystem = serviceClient.GetFileSystemClient(Randomize("sample-filesystem-append"));
            filesystem.Create();

            // Create
            DataLakeFileClient file = filesystem.GetFileClient(Randomize("sample-file"));
            await file.CreateAsync();

            // Verify we created one file
            AsyncPageable<PathItem> response = filesystem.GetPathsAsync();
            IList<PathItem> paths = await response.ToListAsync();
            Assert.AreEqual(1, paths.Count);

            // Cleanup
            await filesystem.DeleteAsync();
        }

        /// <summary>
        /// Create a DataLake File using a DataLake Directory.
        /// </summary>
        [Test]
        public async Task CreateFileClientAsync_Directory()
        {
            // Make StorageSharedKeyCredential to pass to the serviceClient
            string storageAccountName = StorageAccountName;
            string storageAccountKey = StorageAccountKey;
            Uri serviceUri = StorageAccountBlobUri;

            StorageSharedKeyCredential sharedKeyCredential = new StorageSharedKeyCredential(storageAccountName, storageAccountKey);

            // Create DataLakeServiceClient using StorageSharedKeyCredentials
            DataLakeServiceClient serviceClient = new DataLakeServiceClient(serviceUri, sharedKeyCredential);

            // Create a DataLake Filesystem
            DataLakeFileSystemClient filesystem = serviceClient.GetFileSystemClient(Randomize("sample-filesystem"));
            await filesystem.CreateAsync();

            //Create a DataLake Directory
            DataLakeDirectoryClient directory = filesystem.CreateDirectory(Randomize("sample-directory"));
            await directory.CreateAsync();

            // Create a DataLake File using a DataLake Directory
            DataLakeFileClient file = directory.GetFileClient(Randomize("sample-file"));
            await file.CreateAsync();

            // Verify we created one file
            AsyncPageable<PathItem> response = filesystem.GetPathsAsync();
            IList<PathItem> paths = await response.ToListAsync();
            Assert.AreEqual(1, paths.Count);

            // Cleanup
            await filesystem.DeleteAsync();
        }

        /// <summary>
        /// Create a DataLake Directory.
        /// </summary>
        [Test]
        public async Task CreateDirectoryClientAsync()
        {
            // Make StorageSharedKeyCredential to pass to the serviceClient
            string storageAccountName = StorageAccountName;
            string storageAccountKey = StorageAccountKey;
            Uri serviceUri = StorageAccountBlobUri;

            StorageSharedKeyCredential sharedKeyCredential = new StorageSharedKeyCredential(storageAccountName, storageAccountKey);

            // Create DataLakeServiceClient using StorageSharedKeyCredentials
            DataLakeServiceClient serviceClient = new DataLakeServiceClient(serviceUri, sharedKeyCredential);

            // Get a reference to a filesystem named "sample-filesystem-append" and then create it
            DataLakeFileSystemClient filesystem = serviceClient.GetFileSystemClient(Randomize("sample-filesystem-append"));
            filesystem.Create();

            // Create
            DataLakeDirectoryClient directory = filesystem.GetDirectoryClient(Randomize("sample-file"));
            await directory.CreateAsync();

            // Verify we created one directory
            AsyncPageable<PathItem> response = filesystem.GetPathsAsync();
            IList<PathItem> paths = await response.ToListAsync();
            Assert.AreEqual(1, paths.Count);

            // Cleanup
            await filesystem.DeleteAsync();
        }

        /// <summary>
        /// Upload a file to a DataLake File.
        /// </summary>
        [Test]
        public async Task AppendAsync_Simple()
        {
            // Create Sample File to read content from
            string sampleFilePath = CreateTempFile(SampleFileContent);

            // Make StorageSharedKeyCredential to pass to the serviceClient
            string storageAccountName = StorageAccountName;
            string storageAccountKey = StorageAccountKey;
            Uri serviceUri = StorageAccountBlobUri;

            StorageSharedKeyCredential sharedKeyCredential = new StorageSharedKeyCredential(storageAccountName, storageAccountKey);

            // Create DataLakeServiceClient using StorageSharedKeyCredentials
            DataLakeServiceClient serviceClient = new DataLakeServiceClient(serviceUri, sharedKeyCredential);

            // Get a reference to a filesystem named "sample-filesystem-append" and then create it
            DataLakeFileSystemClient filesystem = serviceClient.GetFileSystemClient(Randomize("sample-filesystem-append"));
            await filesystem.CreateAsync();
            try
            {
                // Create a file
                DataLakeFileClient file = filesystem.GetFileClient(Randomize("sample-file"));
                await file.CreateAsync();

                // Append data to the DataLake File
                await file.AppendAsync(File.OpenRead(sampleFilePath), 0);
                await file.FlushAsync(SampleFileContent.Length);

                // Verify the contents of the file
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
        /// Upload file by created a file, and then appending each part to a DataLake File.
        /// </summary>
        [Test]
        public async Task AppendAsync()
        {
            // Create three temporary Lorem Ipsum files on disk that we can upload
            int contentLength = 10;
            string sampleFileContentPart1 = CreateTempFile(SampleFileContent.Substring(0, contentLength));
            string sampleFileContentPart2 = CreateTempFile(SampleFileContent.Substring(contentLength, contentLength));
            string sampleFileContentPart3 = CreateTempFile(SampleFileContent.Substring(contentLength * 2, contentLength));

            // Make StorageSharedKeyCredential to pass to the serviceClient
            string storageAccountName = StorageAccountName;
            string storageAccountKey = StorageAccountKey;
            Uri serviceUri = StorageAccountBlobUri;

            StorageSharedKeyCredential sharedKeyCredential = new StorageSharedKeyCredential(storageAccountName, storageAccountKey);

            // Get a reference to a FileSystemClient
            DataLakeServiceClient serviceClient = new DataLakeServiceClient(serviceUri, sharedKeyCredential);

            // Get a reference to a filesystem named "sample-filesystem-appendasync" and then create it
            DataLakeFileSystemClient filesystem = serviceClient.GetFileSystemClient(Randomize("sample-filesystem-append"));
            await filesystem.CreateAsync();
            try
            {
                // Get a reference to a file named "sample-file" in a filesystem
                DataLakeFileClient file = filesystem.GetFileClient(Randomize("sample-file"));

                // Create the file
                await file.CreateAsync();

                // Verify we created one file
                AsyncPageable<PathItem> response = filesystem.GetPathsAsync();
                IList<PathItem> paths = await response.ToListAsync();
                Assert.AreEqual(1, paths.Count);

                // Append data to an existing DataLake File.  Append is currently limited to 4000 MB per call.
                // To upload a large file all at once, consider using UploadAsync() instead.
                await file.AppendAsync(File.OpenRead(sampleFileContentPart1), 0);
                await file.AppendAsync(File.OpenRead(sampleFileContentPart2), contentLength);
                await file.AppendAsync(File.OpenRead(sampleFileContentPart3), contentLength * 2);
                await file.FlushAsync(contentLength * 3);

                // Verify the contents of the file
                PathProperties properties = await file.GetPropertiesAsync();
                Assert.AreEqual(contentLength * 3, properties.ContentLength);
            }
            finally
            {
                // Clean up after the test when we're finished
                await filesystem.DeleteAsync();
            }
        }

        /// <summary>
        /// Upload file by calling the UploadAsync API.
        /// </summary>
        [Test]
        public async Task UploadAsync()
        {
            // Create three temporary Lorem Ipsum files on disk that we can upload
            int contentLength = 10;
            string sampleFileContent = CreateTempFile(SampleFileContent.Substring(0, contentLength));

            // Make StorageSharedKeyCredential to pass to the serviceClient
            string storageAccountName = StorageAccountName;
            string storageAccountKey = StorageAccountKey;
            Uri serviceUri = StorageAccountBlobUri;

            StorageSharedKeyCredential sharedKeyCredential = new StorageSharedKeyCredential(storageAccountName, storageAccountKey);

            // Get a reference to a FileSystemClient
            DataLakeServiceClient serviceClient = new DataLakeServiceClient(serviceUri, sharedKeyCredential);

            // Get a reference to a filesystem named "sample-filesystem-appendasync" and then create it
            DataLakeFileSystemClient filesystem = serviceClient.GetFileSystemClient(Randomize("sample-filesystem-append"));
            await filesystem.CreateAsync();
            try
            {
                // Get a reference to a file named "sample-file" in a filesystem
                DataLakeFileClient file = filesystem.GetFileClient(Randomize("sample-file"));

                // Upload content to the file.  When using the Upload API, you don't need to create the file first.
                // If the file already exists, it will be overwritten.
                // For larger files, Upload() will upload the file in multiple parallel requests.
                await file.UploadAsync(File.OpenRead(sampleFileContent));

                // Verify the contents of the file
                PathProperties properties = await file.GetPropertiesAsync();
                Assert.AreEqual(contentLength, properties.ContentLength);
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
            DataLakeFileSystemClient filesystem = serviceClient.GetFileSystemClient(Randomize("sample-filesystem-read"));
            await filesystem.CreateAsync();
            try
            {
                // Get a reference to a file named "sample-file" in a filesystem
                DataLakeFileClient file = filesystem.GetFileClient(Randomize("sample-file"));

                // First upload something the DataLake file so we have something to download
                await file.UploadAsync(File.OpenRead(originalPath));

                // Download the DataLake file's contents and save it to a file
                // The ReadAsync() API downloads a file in a single requests.
                // For large files, it may be faster to call ReadToAsync()
                Response<FileDownloadInfo> fileContents = await file.ReadAsync();
                using (FileStream stream = File.OpenWrite(downloadPath))
                {
                    fileContents.Value.Content.CopyTo(stream);
                }

                // Verify the contents
                Assert.AreEqual(SampleFileContent, File.ReadAllText(downloadPath));
            }
            finally
            {
                // Clean up after the test when we're finished
                await filesystem.DeleteAsync();
            }
        }

        /// <summary>
        /// Download a DataLake File directly to file.
        /// </summary>
        [Test]
        public async Task ReadToAsync()
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
            DataLakeFileSystemClient filesystem = serviceClient.GetFileSystemClient(Randomize("sample-filesystem-read"));
            await filesystem.CreateAsync();
            try
            {
                // Get a reference to a file named "sample-file" in a filesystem
                DataLakeFileClient file = filesystem.GetFileClient(Randomize("sample-file"));

                // First upload something the DataLake file so we have something to download
                await file.UploadAsync(File.OpenRead(originalPath));

                // Download the DataLake file's contents directly to a file.
                // For larger files, ReadToAsync() will download the file in multiple parallel requests.
                await file.ReadToAsync(downloadPath);

                // Verify the contents
                Assert.AreEqual(SampleFileContent, File.ReadAllText(downloadPath));
            }
            finally
            {
                // Clean up after the test when we're finished
                await filesystem.DeleteAsync();
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
            DataLakeFileSystemClient filesystem = serviceClient.GetFileSystemClient(Randomize("sample-filesystem-list"));
            await filesystem.CreateAsync();
            try
            {
                // Upload a couple of directories so we have something to list
                await filesystem.CreateDirectoryAsync("sample-directory1");
                await filesystem.CreateDirectoryAsync("sample-directory2");
                await filesystem.CreateDirectoryAsync("sample-directory3");

                // List all the directories
                List<string> names = new List<string>();
                await foreach (PathItem pathItem in filesystem.GetPathsAsync())
                {
                    names.Add(pathItem.Name);
                }
                Assert.AreEqual(3, names.Count);
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
            DataLakeFileSystemClient filesystem = serviceClient.GetFileSystemClient(Randomize("sample-filesystem-traverse"));

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
                await foreach (PathItem pathItem in filesystem.GetPathsAsync(recursive: true))
                {
                    names.Add(pathItem.Name);
                }

                // Verify we've seen everything
                Assert.AreEqual(10, names.Count);
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
            DataLakeFileSystemClient filesystem = serviceClient.GetFileSystemClient(Randomize("sample-filesystem-errors"));
            await filesystem.CreateAsync();
            try
            {
                // Try to create the filesystem again
                await filesystem.CreateAsync();
            }
            catch (RequestFailedException ex)
                when (ex.ErrorCode == "ContainerAlreadyExists")
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
            Uri serviceUri = NamespaceBlobUri;
            StorageSharedKeyCredential sharedKeyCredential = new StorageSharedKeyCredential(storageAccountName, storageAccountKey);

            // Create DataLakeServiceClient using StorageSharedKeyCredentials
            DataLakeServiceClient serviceClient = new DataLakeServiceClient(serviceUri, sharedKeyCredential);

            // Get a reference to a filesystem named "sample-filesystem-aclasync" and then create it
            DataLakeFileSystemClient filesystem = serviceClient.GetFileSystemClient(Randomize("sample-filesystem-perasync"));
            await filesystem.CreateAsync();
            try
            {
                // Create a DataLake file so we can set the Access Controls on the files
                DataLakeFileClient fileClient = filesystem.GetFileClient(Randomize("sample-file"));
                await fileClient.CreateAsync();

                // Set the Permissions of the file
                PathPermissions pathPermissions = PathPermissions.ParseSymbolicPermissions("rwxrwxrwx");
                await fileClient.SetPermissionsAsync(permissions: pathPermissions);

                // Get Access Control List
                PathAccessControl accessControlResponse = await fileClient.GetAccessControlAsync();

                // Check Access Control permissions
                Assert.AreEqual(pathPermissions.ToSymbolicPermissions(), accessControlResponse.Permissions.ToSymbolicPermissions());
                Assert.AreEqual(pathPermissions.ToOctalPermissions(), accessControlResponse.Permissions.ToOctalPermissions());
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
            Uri serviceUri = NamespaceBlobUri;
            StorageSharedKeyCredential sharedKeyCredential = new StorageSharedKeyCredential(storageAccountName, storageAccountKey);

            // Create DataLakeServiceClient using StorageSharedKeyCredentials
            DataLakeServiceClient serviceClient = new DataLakeServiceClient(serviceUri, sharedKeyCredential);

            // Get a reference to a filesystem named "sample-filesystem-aclasync" and then create it
            DataLakeFileSystemClient filesystem = serviceClient.GetFileSystemClient(Randomize("sample-filesystem-acl"));
            await filesystem.CreateAsync();
            try
            {
                // Create a DataLake file so we can set the Access Controls on the files
                DataLakeFileClient fileClient = filesystem.GetFileClient(Randomize("sample-file"));
                await fileClient.CreateAsync();
                IList<PathAccessControlItem> accessControlList = PathAccessControlExtensions.ParseAccessControlList("user::rwx,group::r--,mask::rwx,other::---");

                // Set Access Control List
                await fileClient.SetAccessControlListAsync(accessControlList);

                // Get Access Control List
                PathAccessControl accessControlResponse = await fileClient.GetAccessControlAsync();

                // Check Access Control permissions
                Assert.AreEqual(
                    PathAccessControlExtensions.ToAccessControlListString(accessControlList),
                    PathAccessControlExtensions.ToAccessControlListString(accessControlResponse.AccessControlList.ToList()));
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
        public async Task RenameAsync()
        {
            // Make StorageSharedKeyCredential to pass to the serviceClient
            string storageAccountName = StorageAccountName;
            string storageAccountKey = StorageAccountKey;
            Uri serviceUri = StorageAccountBlobUri;
            StorageSharedKeyCredential sharedKeyCredential = new StorageSharedKeyCredential(storageAccountName, storageAccountKey);

            // Create DataLakeServiceClient using StorageSharedKeyCredentials
            DataLakeServiceClient serviceClient = new DataLakeServiceClient(serviceUri, sharedKeyCredential);

            // Get a reference to a filesystem named "sample-filesystem-rename" and then create it
            DataLakeFileSystemClient filesystem = serviceClient.GetFileSystemClient(Randomize("sample-filesystem-rename"));
            await filesystem.CreateAsync();
            try
            {
                // Create a DataLake Directory to rename it later
                DataLakeDirectoryClient directoryClient = filesystem.GetDirectoryClient(Randomize("sample-directory"));
                await directoryClient.CreateAsync();

                // Rename directory with new path/name and verify by making a service call (e.g. GetProperties)
                DataLakeDirectoryClient renamedDirectoryClient = await directoryClient.RenameAsync("sample-directory2");
                PathProperties directoryPathProperties = await renamedDirectoryClient.GetPropertiesAsync();

                // Delete the sample directory using the new path/name
                await filesystem.DeleteDirectoryAsync("sample-directory2");

                // Create a DataLake file.
                DataLakeFileClient fileClient = filesystem.GetFileClient(Randomize("sample-file"));
                await fileClient.CreateAsync();

                // Rename file with new path/name and verify by making a service call (e.g. GetProperties)
                DataLakeFileClient renamedFileClient = await fileClient.RenameAsync("sample-file2");
                PathProperties pathProperties = await renamedFileClient.GetPropertiesAsync();

                // Delete the sample directory using the new path/name
                await filesystem.DeleteFileAsync("sample-file2");
            }
            finally
            {
                // Clean up after the test when we're finished
                await filesystem.DeleteAsync();
            }
        }

        /// <summary>
        /// Get Properties on a DataLake File and a Directory
        /// </summary>
        [Test]
        public async Task GetPropertiesAsync()
        {
            // Make StorageSharedKeyCredential to pass to the serviceClient
            string storageAccountName = StorageAccountName;
            string storageAccountKey = StorageAccountKey;
            Uri serviceUri = StorageAccountBlobUri;
            StorageSharedKeyCredential sharedKeyCredential = new StorageSharedKeyCredential(storageAccountName, storageAccountKey);

            // Create DataLakeServiceClient using StorageSharedKeyCredentials
            DataLakeServiceClient serviceClient = new DataLakeServiceClient(serviceUri, sharedKeyCredential);

            // Get a reference to a filesystem named "sample-filesystem-rename" and then create it
            DataLakeFileSystemClient filesystem = serviceClient.GetFileSystemClient(Randomize("sample-filesystem"));
            await filesystem.CreateAsync();
            try
            {
                // Create a DataLake Directory to rename it later
                DataLakeDirectoryClient directoryClient = filesystem.GetDirectoryClient(Randomize("sample-directory"));
                await directoryClient.CreateAsync();

                // Get Properties on a Directory
                PathProperties directoryPathProperties = await directoryClient.GetPropertiesAsync();

                // Create a DataLake file
                DataLakeFileClient fileClient = filesystem.GetFileClient(Randomize("sample-file"));
                await fileClient.CreateAsync();

                // Get Properties on a File
                PathProperties filePathProperties = await fileClient.GetPropertiesAsync();
            }
            finally
            {
                // Clean up after the test when we're finished
                await filesystem.DeleteAsync();
            }
        }
    }
}
