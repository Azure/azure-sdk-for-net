// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using Azure.Storage.Files.DataLake;
using Azure.Storage.Files.DataLake.Models;
using NUnit.Framework;

namespace Azure.Storage.Files.DataLake.Samples
{
    /// <summary>
    /// Basic Azure DataLake Storage samples.
    /// </summary>
    public class Sample01a_HelloWorld : SampleTest
    {
        /// <summary>
        /// Create a DataLake File using a DataLake Filesystem.
        /// </summary>
        [Test]
        public void CreateFileClient_Filesystem()
        {
            // Make StorageSharedKeyCredential to pass to the serviceClient
            string storageAccountName = StorageAccountName;
            string storageAccountKey = StorageAccountKey;
            Uri serviceUri = StorageAccountBlobUri;

            #region Snippet:SampleSnippetDataLakeServiceClient_Create
            StorageSharedKeyCredential sharedKeyCredential = new StorageSharedKeyCredential(storageAccountName, storageAccountKey);

            // Create DataLakeServiceClient using StorageSharedKeyCredentials
            DataLakeServiceClient serviceClient = new DataLakeServiceClient(serviceUri, sharedKeyCredential);
            #endregion Snippet:SampleSnippetDataLakeServiceClient_Create

            #region Snippet:SampleSnippetDataLakeFileClient_Create
            // Create a DataLake Filesystem
            DataLakeFileSystemClient filesystem = serviceClient.GetFileSystemClient("sample-filesystem");
            filesystem.Create();

            // Create a DataLake file using a DataLake Filesystem
            DataLakeFileClient file = filesystem.GetFileClient("sample-file");
            file.Create();
            #endregion Snippet:SampleSnippetDataLakeFileClient_Create

            // Verify we created one file
            Assert.AreEqual(1, filesystem.GetPaths().Count());

            // Cleanup
            filesystem.Delete();
        }

        /// <summary>
        /// Create a DataLake File using a DataLake Directory.
        /// </summary>
        [Test]
        public void CreateFileClient_Directory()
        {
            // Make StorageSharedKeyCredential to pass to the serviceClient
            string storageAccountName = StorageAccountName;
            string storageAccountKey = StorageAccountKey;
            Uri serviceUri = StorageAccountBlobUri;

            #region Snippet:SampleSnippetDataLakeFileSystemClient_Create
            StorageSharedKeyCredential sharedKeyCredential = new StorageSharedKeyCredential(storageAccountName, storageAccountKey);

            // Create DataLakeServiceClient using StorageSharedKeyCredentials
            DataLakeServiceClient serviceClient = new DataLakeServiceClient(serviceUri, sharedKeyCredential);

            // Create a DataLake Filesystem
            DataLakeFileSystemClient filesystem = serviceClient.GetFileSystemClient("sample-filesystem");
            filesystem.Create();
            #endregion Snippet:SampleSnippetDataLakeFileSystemClient_Create
            #region Snippet:SampleSnippetDataLakeFileClient_Create_Directory
            // Create a DataLake Directory
            DataLakeDirectoryClient directory = filesystem.CreateDirectory("sample-directory");
            directory.Create();

            // Create a DataLake File using a DataLake Directory
            DataLakeFileClient file = directory.GetFileClient("sample-file");
            file.Create();
            #endregion Snippet:SampleSnippetDataLakeFileClient_Create_Directory

            // Verify we created one file
            Assert.AreEqual(1, filesystem.GetPaths().Count());

            // Cleanup
            filesystem.Delete();
        }

        /// <summary>
        /// Create a DataLake Directory.
        /// </summary>
        [Test]
        public void CreateDirectoryClient()
        {
            // Make StorageSharedKeyCredential to pass to the serviceClient
            string storageAccountName = StorageAccountName;
            string storageAccountKey = StorageAccountKey;
            Uri serviceUri = StorageAccountBlobUri;

            #region Snippet:SampleSnippetDataLakeDirectoryClient_Create
            StorageSharedKeyCredential sharedKeyCredential = new StorageSharedKeyCredential(storageAccountName, storageAccountKey);

            // Create DataLakeServiceClient using StorageSharedKeyCredentials
            DataLakeServiceClient serviceClient = new DataLakeServiceClient(serviceUri, sharedKeyCredential);

            // Get a reference to a filesystem named "sample-filesystem-append" and then create it
            DataLakeFileSystemClient filesystem = serviceClient.GetFileSystemClient("sample-filesystem-append");
            filesystem.Create();

            // Create
            DataLakeDirectoryClient directory = filesystem.GetDirectoryClient("sample-file");
            directory.Create();
            #endregion Snippet:SampleSnippetDataLakeDirectoryClient_Create

            // Verify we created one directory
            Assert.AreEqual(1, filesystem.GetPaths().Count());

            // Cleanup
            filesystem.Delete();
        }

        /// <summary>
        /// Upload a file to a DataLake File.
        /// </summary>
        [Test]
        public void Append_Simple()
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
            DataLakeFileSystemClient filesystem = serviceClient.GetFileSystemClient("sample-filesystem-append");
            filesystem.Create();
            try
            {
                #region Snippet:SampleSnippetDataLakeFileClient_Append
                // Create a file
                DataLakeFileClient file = filesystem.GetFileClient("sample-file");
                file.Create();

                // Append data to the DataLake File
                file.Append(File.OpenRead(sampleFilePath), 0);
                file.Flush(SampleFileContent.Length);
                #endregion Snippet:SampleSnippetDataLakeFileClient_Append

                // Verify the contents of the file
                PathProperties properties = file.GetProperties();
                Assert.AreEqual(SampleFileContent.Length, properties.ContentLength);
            }
            finally
            {
                // Clean up after the test when we're finished
                filesystem.Delete();
            }
        }

        /// <summary>
        /// Upload file by created a file, and then appending each part to a DataLake File.
        /// </summary>
        [Test]
        public void Append()
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

            // Create DataLakeServiceClient using StorageSharedKeyCredentials
            DataLakeServiceClient serviceClient = new DataLakeServiceClient(serviceUri, sharedKeyCredential);

            // Get a reference to a filesystem named "sample-filesystem-append" and then create it
            DataLakeFileSystemClient filesystem = serviceClient.GetFileSystemClient("sample-filesystem-append");
            filesystem.Create();
            try
            {
                // Get a reference to a file named "sample-file" in a filesystem
                DataLakeFileClient file = filesystem.GetFileClient("sample-file");

                // Create the file
                file.Create();

                // Verify we created one file
                Assert.AreEqual(1, filesystem.GetPaths().Count());

                // Append data to an existing DataLake File.  Append is currently limited to 4000 MB per call.
                // To upload a large file all at once, consider using Upload() instead.
                file.Append(File.OpenRead(sampleFileContentPart1), 0);
                file.Append(File.OpenRead(sampleFileContentPart2), contentLength);
                file.Append(File.OpenRead(sampleFileContentPart3), contentLength * 2);
                file.Flush(contentLength * 3);

                // Verify the contents of the file
                PathProperties properties = file.GetProperties();
                Assert.AreEqual(contentLength * 3, properties.ContentLength);
            }
            finally
            {
                // Clean up after the test when we're finished
                filesystem.Delete();
            }
        }

        /// <summary>
        /// Upload file by appending each part to a DataLake File.
        /// </summary>
        [Test]
        public void Upload()
        {
            // Create three temporary Lorem Ipsum files on disk that we can upload
            int contentLength = 10;
            string sampleFileContent = CreateTempFile(SampleFileContent.Substring(0, contentLength));

            // Make StorageSharedKeyCredential to pass to the serviceClient
            string storageAccountName = StorageAccountName;
            string storageAccountKey = StorageAccountKey;
            Uri serviceUri = StorageAccountBlobUri;

            StorageSharedKeyCredential sharedKeyCredential = new StorageSharedKeyCredential(storageAccountName, storageAccountKey);

            // Create DataLakeServiceClient using StorageSharedKeyCredentials
            DataLakeServiceClient serviceClient = new DataLakeServiceClient(serviceUri, sharedKeyCredential);

            // Get a reference to a filesystem named "sample-filesystem-append" and then create it
            DataLakeFileSystemClient filesystem = serviceClient.GetFileSystemClient("sample-filesystem-append");
            filesystem.Create();
            try
            {
                // Get a reference to a file named "sample-file" in a filesystem
                DataLakeFileClient file = filesystem.GetFileClient("sample-file");

                // Create the file
                file.Create();

                // Verify we created one file
                Assert.AreEqual(1, filesystem.GetPaths().Count());

                // Upload content to the file.  When using the Upload API, you don't need to create the file first.
                // If the file already exists, it will be overwritten.
                // For larger files, Upload() will upload the file in multiple sequential requests.
                file.Upload(File.OpenRead(sampleFileContent),true);

                // Verify the contents of the file
                PathProperties properties = file.GetProperties();
                Assert.AreEqual(contentLength, properties.ContentLength);
            }
            finally
            {
                // Clean up after the test when we're finished
                filesystem.Delete();
            }
        }

        /// <summary>
        /// Download a DataLake File to a file.
        /// </summary>
        [Test]
        public void Read()
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

            // Get a reference to a filesystem named "sample-filesystem-read" and then create it
            DataLakeFileSystemClient filesystem = serviceClient.GetFileSystemClient("sample-filesystem-read");
            filesystem.Create();
            try
            {
                // Get a reference to a file named "sample-file" in a filesystem
                DataLakeFileClient file = filesystem.GetFileClient("sample-file");

                // First upload something the DataLake file so we have something to download
                file.Upload(File.OpenRead(originalPath));

                // Download the DataLake file's contents and save it to a file
                // The ReadAsync() API downloads a file in a single requests.
                // For large files, it may be faster to call ReadTo()
                #region Snippet:SampleSnippetDataLakeFileClient_Read
                Response<FileDownloadInfo> fileContents = file.Read();
                #endregion Snippet:SampleSnippetDataLakeFileClient_Read
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
                filesystem.Delete();
            }
        }

        /// <summary>
        /// Download a DataLake File's streaming data to a file.
        /// </summary>
        [Test]
        public void ReadStreaming()
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

            // Get a reference to a filesystem named "sample-filesystem-read" and then create it
            DataLakeFileSystemClient filesystem = serviceClient.GetFileSystemClient("sample-filesystem-read");
            filesystem.Create();
            try
            {
                // Get a reference to a file named "sample-file" in a filesystem
                DataLakeFileClient file = filesystem.GetFileClient("sample-file");

                // First upload something the DataLake file so we have something to download
                file.Upload(File.OpenRead(originalPath));

                // Download the DataLake file's contents and save it to a file
                // The ReadStreamingAsync() API downloads a file in a single requests.
                // For large files, it may be faster to call ReadTo()
                #region Snippet:SampleSnippetDataLakeFileClient_ReadStreaming
                Response<DataLakeFileReadStreamingResult> fileContents = file.ReadStreaming();
                Stream readStream = fileContents.Value.Content;
                #endregion Snippet:SampleSnippetDataLakeFileClient_ReadStreaming
                using (FileStream stream = File.OpenWrite(downloadPath))
                {
                    readStream.CopyTo(stream);
                }

                // Verify the contents
                Assert.AreEqual(SampleFileContent, File.ReadAllText(downloadPath));
            }
            finally
            {
                // Clean up after the test when we're finished
                filesystem.Delete();
            }
        }

        /// <summary>
        /// Download a DataLake File's content data to a file.
        /// </summary>
        [Test]
        public void ReadContent()
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

            // Get a reference to a filesystem named "sample-filesystem-read" and then create it
            DataLakeFileSystemClient filesystem = serviceClient.GetFileSystemClient("sample-filesystem-read");
            filesystem.Create();
            try
            {
                // Get a reference to a file named "sample-file" in a filesystem
                DataLakeFileClient file = filesystem.GetFileClient("sample-file");

                // First upload something the DataLake file so we have something to download
                file.Upload(File.OpenRead(originalPath));

                // Download the DataLake file's contents and save it to a file
                // The ReadContentAsync() API downloads a file in a single requests.
                // For large files, it may be faster to call ReadTo()
                #region Snippet:SampleSnippetDataLakeFileClient_ReadContent
                Response<DataLakeFileReadResult> fileContents = file.ReadContent();
                BinaryData readData = fileContents.Value.Content;
                #endregion Snippet:SampleSnippetDataLakeFileClient_ReadContent
                byte[] data = readData.ToArray();
                using (FileStream stream = File.OpenWrite(downloadPath))
                {
                    stream.Write(data, 0, data.Length);
                }

               // Verify the contents
                Assert.AreEqual(SampleFileContent, File.ReadAllText(downloadPath));
            }
            finally
            {
                // Clean up after the test when we're finished
                filesystem.Delete();
            }
        }

        /// <summary>
        /// Download a DataLake File to a file.
        /// </summary>
        [Test]
        public void ReadTo()
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

            // Get a reference to a filesystem named "sample-filesystem-read" and then create it
            DataLakeFileSystemClient filesystem = serviceClient.GetFileSystemClient("sample-filesystem-read");
            filesystem.Create();
            try
            {
                // Get a reference to a file named "sample-file" in a filesystem
                DataLakeFileClient file = filesystem.GetFileClient("sample-file");

                // First upload something the DataLake file so we have something to download
                file.Upload(File.OpenRead(originalPath));

                // Download the DataLake file's directly to a file.
                // For larger files, ReadTo() will download the file in multiple sequential requests.
                file.ReadTo(downloadPath);

                // Verify the contents
                Assert.AreEqual(SampleFileContent, File.ReadAllText(downloadPath));
            }
            finally
            {
                // Clean up after the test when we're finished
                filesystem.Delete();
            }
        }

        /// <summary>
        /// List all the DataLake directories in a filesystem.
        /// </summary>
        [Test]
        public void List()
        {
            // Make StorageSharedKeyCredential to pass to the serviceClient
            string storageAccountName = StorageAccountName;
            string storageAccountKey = StorageAccountKey;
            Uri serviceUri = StorageAccountBlobUri;
            StorageSharedKeyCredential sharedKeyCredential = new StorageSharedKeyCredential(storageAccountName, storageAccountKey);

            // Create DataLakeServiceClient using StorageSharedKeyCredentials
            DataLakeServiceClient serviceClient = new DataLakeServiceClient(serviceUri, sharedKeyCredential);

            // Get a reference to a filesystem named "sample-filesystem-list" and then create it
            DataLakeFileSystemClient filesystem = serviceClient.GetFileSystemClient("sample-filesystem-list");
            filesystem.Create();
            try
            {
                // Upload a couple of directories so we have something to list
                filesystem.CreateDirectory("sample-directory1");
                filesystem.CreateDirectory("sample-directory2");
                filesystem.CreateDirectory("sample-directory3");

                // List all the directories
                List<string> names = new List<string>();
                #region Snippet:SampleSnippetDataLakeFileClient_List
                foreach (PathItem pathItem in filesystem.GetPaths())
                {
                    names.Add(pathItem.Name);
                }
                #endregion Snippet:SampleSnippetDataLakeFileClient_List
                Assert.AreEqual(3, names.Count);
                Assert.Contains("sample-directory1", names);
                Assert.Contains("sample-directory2", names);
                Assert.Contains("sample-directory3", names);
            }
            finally
            {
                // Clean up after the test when we're finished
                filesystem.Delete();
            }
        }

        /// <summary>
        /// Traverse the DataLake Files and DataLake Directories in a DataLake filesystem.
        /// </summary>
        [Test]
        public void Traverse()
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

            // Get a reference to a filesystem named "sample-filesystem-traverse" and then create it
            DataLakeFileSystemClient filesystem = serviceClient.GetFileSystemClient("sample-filesystem-traverse");

            filesystem.Create();
            try
            {
                // Create a bunch of directories and files within the directories
                DataLakeDirectoryClient first = filesystem.CreateDirectory("first");
                first.CreateSubDirectory("a");
                first.CreateSubDirectory("b");
                DataLakeDirectoryClient second = filesystem.CreateDirectory("second");
                second.CreateSubDirectory("c");
                second.CreateSubDirectory("d");
                filesystem.CreateDirectory("third");
                DataLakeDirectoryClient fourth = filesystem.CreateDirectory("fourth");
                DataLakeDirectoryClient deepest = fourth.CreateSubDirectory("e");

                // Upload a DataLake file named "file"
                DataLakeFileClient file = deepest.GetFileClient("file");
                file.Create();
                using (FileStream stream = File.OpenRead(originalPath))
                {
                    file.Append(stream, 0);
                }

                // Keep track of all the names we encounter
                List<string> names = new List<string>();

                DataLakeGetPathsOptions options = new DataLakeGetPathsOptions
                {
                    Recursive = true
                };

                foreach (PathItem pathItem in filesystem.GetPaths(options))
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
                filesystem.Delete();
            }
        }

        /// <summary>
        /// Trigger a recoverable error.
        /// </summary>
        [Test]
        public void Errors()
        {
            // Make StorageSharedKeyCredential to pass to the serviceClient
            string storageAccountName = StorageAccountName;
            string storageAccountKey = StorageAccountKey;
            Uri serviceUri = StorageAccountBlobUri;
            StorageSharedKeyCredential sharedKeyCredential = new StorageSharedKeyCredential(storageAccountName, storageAccountKey);

            // Create DataLakeServiceClient using StorageSharedKeyCredentials
            DataLakeServiceClient serviceClient = new DataLakeServiceClient(serviceUri, sharedKeyCredential);

            // Get a reference to a filesystem named "sample-filesystem-errors" and then create it
            DataLakeFileSystemClient filesystem = serviceClient.GetFileSystemClient("sample-filesystem-errors");
            filesystem.Create();
            try
            {
                // Try to create the filesystem again
                filesystem.Create();
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
            filesystem.Delete();
        }

        /// <summary>
        /// Set permissions in the access control list and gets access control list on a DataLake File
        /// </summary>
        [Test]
        public void SetPermissions()
        {
            // Make StorageSharedKeyCredential to pass to the serviceClient
            string storageAccountName = NamespaceStorageAccountName;
            string storageAccountKey = NamespaceStorageAccountKey;
            Uri serviceUri = NamespaceBlobUri;
            StorageSharedKeyCredential sharedKeyCredential = new StorageSharedKeyCredential(storageAccountName, storageAccountKey);

            // Create DataLakeServiceClient using StorageSharedKeyCredentials
            DataLakeServiceClient serviceClient = new DataLakeServiceClient(serviceUri, sharedKeyCredential);

            // Get a reference to a filesystem named "sample-filesystem-acl" and then create it
            DataLakeFileSystemClient filesystem = serviceClient.GetFileSystemClient("sample-filesystem-per");
            filesystem.Create();
            try
            {
                #region Snippet:SampleSnippetDataLakeFileClient_SetPermissions
                // Create a DataLake file so we can set the Access Controls on the files
                DataLakeFileClient fileClient = filesystem.GetFileClient("sample-file");
                fileClient.Create();

                // Set the Permissions of the file
                PathPermissions pathPermissions = PathPermissions.ParseSymbolicPermissions("rwxrwxrwx");
                fileClient.SetPermissions(permissions: pathPermissions);
                #endregion Snippet:SampleSnippetDataLakeFileClient_SetPermissions

                // Get Access Control List
                PathAccessControl accessControlResponse = fileClient.GetAccessControl();

                // Check Access Control permissions
                Assert.AreEqual(pathPermissions.ToSymbolicPermissions(), accessControlResponse.Permissions.ToSymbolicPermissions());
                Assert.AreEqual(pathPermissions.ToOctalPermissions(), accessControlResponse.Permissions.ToOctalPermissions());
            }
            finally
            {
                // Clean up after the test when we're finished
                filesystem.Delete();
            }
        }

        /// <summary>
        /// Set and gets access control list on a DataLake File
        /// </summary>
        [Test]
        public void SetGetAcls()
        {
            // Make StorageSharedKeyCredential to pass to the serviceClient
            string storageAccountName = NamespaceStorageAccountName;
            string storageAccountKey = NamespaceStorageAccountKey;
            Uri serviceUri = NamespaceBlobUri;
            StorageSharedKeyCredential sharedKeyCredential = new StorageSharedKeyCredential(storageAccountName, storageAccountKey);

            // Create DataLakeServiceClient using StorageSharedKeyCredentials
            DataLakeServiceClient serviceClient = new DataLakeServiceClient(serviceUri, sharedKeyCredential);

            // Get a reference to a filesystem named "sample-filesystem-acl" and then create it
            DataLakeFileSystemClient filesystem = serviceClient.GetFileSystemClient("sample-filesystem-acl");
            filesystem.Create();
            try
            {
                #region Snippet:SampleSnippetDataLakeFileClient_SetAcls
                // Create a DataLake file so we can set the Access Controls on the files
                DataLakeFileClient fileClient = filesystem.GetFileClient("sample-file");
                fileClient.Create();

                // Set Access Control List
                IList<PathAccessControlItem> accessControlList
                    = PathAccessControlExtensions.ParseAccessControlList("user::rwx,group::r--,mask::rwx,other::---");
                fileClient.SetAccessControlList(accessControlList);
                #endregion Snippet:SampleSnippetDataLakeFileClient_SetAcls
                #region Snippet:SampleSnippetDataLakeFileClient_GetAcls
                // Get Access Control List
                PathAccessControl accessControlResponse = fileClient.GetAccessControl();
                #endregion Snippet:SampleSnippetDataLakeFileClient_GetAcls

                // Check Access Control permissions
                Assert.AreEqual(
                    PathAccessControlExtensions.ToAccessControlListString(accessControlList),
                    PathAccessControlExtensions.ToAccessControlListString(accessControlResponse.AccessControlList.ToList()));
            }
            finally
            {
                // Clean up after the test when we're finished
                filesystem.Delete();
            }
        }

        /// <summary>
        /// Rename a DataLake file and a DataLake directory in a DataLake Filesystem.
        /// </summary>
        [Test]
        public void Rename()
        {
            // Make StorageSharedKeyCredential to pass to the serviceClient
            string storageAccountName = StorageAccountName;
            string storageAccountKey = StorageAccountKey;
            Uri serviceUri = StorageAccountBlobUri;
            StorageSharedKeyCredential sharedKeyCredential = new StorageSharedKeyCredential(storageAccountName, storageAccountKey);

            // Create DataLakeServiceClient using StorageSharedKeyCredentials
            DataLakeServiceClient serviceClient = new DataLakeServiceClient(serviceUri, sharedKeyCredential);

            // Get a reference to a filesystem named "sample-filesystem-rename" and then create it
            DataLakeFileSystemClient filesystem = serviceClient.GetFileSystemClient("sample-filesystem-rename");
            filesystem.Create();
            try
            {
                // Create a DataLake Directory to rename it later
                DataLakeDirectoryClient directoryClient = filesystem.GetDirectoryClient("sample-directory");
                directoryClient.Create();

                // Rename directory with new path/name and verify by making a service call (e.g. GetProperties)
                #region Snippet:SampleSnippetDataLakeFileClient_RenameDirectory
                DataLakeDirectoryClient renamedDirectoryClient = directoryClient.Rename("sample-directory2");
                #endregion Snippet:SampleSnippetDataLakeFileClient_RenameDirectory
                PathProperties directoryPathProperties = renamedDirectoryClient.GetProperties();

                // Delete the sample directory using the new path/name
                filesystem.DeleteDirectory("sample-directory2");

                // Create a DataLake file.
                DataLakeFileClient fileClient = filesystem.GetFileClient("sample-file");
                fileClient.Create();

                // Rename file with new path/name and verify by making a service call (e.g. GetProperties)
                #region Snippet:SampleSnippetDataLakeFileClient_RenameFile
                DataLakeFileClient renamedFileClient = fileClient.Rename("sample-file2");
                #endregion Snippet:SampleSnippetDataLakeFileClient_RenameFile
                PathProperties filePathProperties = renamedFileClient.GetProperties();

                // Delete the sample directory using the new path/name
                filesystem.DeleteFile("sample-file2");
            }
            finally
            {
                // Clean up after the test when we're finished
                filesystem.Delete();
            }
        }

        /// <summary>
        /// Get Properties on a DataLake File and a Directory
        /// </summary>
        [Test]
        public void GetProperties()
        {
            // Make StorageSharedKeyCredential to pass to the serviceClient
            string storageAccountName = StorageAccountName;
            string storageAccountKey = StorageAccountKey;
            Uri serviceUri = StorageAccountBlobUri;
            StorageSharedKeyCredential sharedKeyCredential = new StorageSharedKeyCredential(storageAccountName, storageAccountKey);

            // Create DataLakeServiceClient using StorageSharedKeyCredentials
            DataLakeServiceClient serviceClient = new DataLakeServiceClient(serviceUri, sharedKeyCredential);

            // Get a reference to a filesystem named "sample-filesystem-rename" and then create it
            DataLakeFileSystemClient filesystem = serviceClient.GetFileSystemClient("sample-filesystem");
            filesystem.Create();
            try
            {
                // Create a DataLake Directory to rename it later
                DataLakeDirectoryClient directoryClient = filesystem.GetDirectoryClient("sample-directory");
                directoryClient.Create();

                #region Snippet:SampleSnippetDataLakeDirectoryClient_GetProperties
                // Get Properties on a Directory
                PathProperties directoryPathProperties = directoryClient.GetProperties();
                #endregion Snippet:SampleSnippetDataLakeDirectoryClient_GetProperties

                // Create a DataLake file
                DataLakeFileClient fileClient = filesystem.GetFileClient("sample-file");
                fileClient.Create();

                #region Snippet:SampleSnippetDataLakeFileClient_GetProperties
                // Get Properties on a File
                PathProperties filePathProperties = fileClient.GetProperties();
                #endregion Snippet:SampleSnippetDataLakeFileClient_GetProperties
            }
            finally
            {
                // Clean up after the test when we're finished
                filesystem.Delete();
            }
        }
    }
}
