﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.IO;
using System.Threading.Tasks;
using Azure.Storage.Files;
using Azure.Storage.Files.Models;
using Azure.Storage.Test;
using Microsoft.VisualStudio.TestTools.UnitTesting;

#pragma warning disable CA2007
#pragma warning disable IDE0007
#pragma warning disable IDE0059 // Value assigned to symbol is never used.  Keeping all these for the sake of the sample.

namespace Azure.Storage.Samples
{

    [TestClass]
    public partial class FileSamples
    {
        [TestMethod]
        [TestCategory("Live")]
        public async Task ShareSample()
        {
            // Instantiate a new FileServiceClient using a connection string.
            FileServiceClient fileServiceClient = new FileServiceClient(TestConfigurations.DefaultTargetTenant.ConnectionString);

            // Instantiate new ShareClient
            ShareClient shareClient = fileServiceClient.GetShareClient("myshare");
            try
            {
                // Create Share in the Service
                await shareClient.CreateAsync();

                // List Shares
                Response<SharesSegment> listResponse = await fileServiceClient.ListSharesSegmentAsync();
            }
            finally
            { 
                // Delete Share in the service
                await shareClient.DeleteAsync();
            }
        }

        [TestMethod]
        [TestCategory("Live")]
        public async Task DirectorySample()
        {
            // Instantiate a new FileServiceClient using a connection string.
            FileServiceClient fileServiceClient = new FileServiceClient(TestConfigurations.DefaultTargetTenant.ConnectionString);

            // Instantiate new ShareClient
            ShareClient shareClient = fileServiceClient.GetShareClient("myshare2");
            try
            {
                // Create Share in the Service
                await shareClient.CreateAsync();

                // Instantiate new DirectoryClient
                DirectoryClient directoryClient = shareClient.GetDirectoryClient("mydirectory");

                // Create Directory in the Service
                await directoryClient.CreateAsync();

                // Instantiate new DirectoryClient
                DirectoryClient subDirectoryClient = directoryClient.GetDirectoryClient("mysubdirectory");

                // Create sub directory
                await subDirectoryClient.CreateAsync();

                // List Files and Directories
                Response<FilesAndDirectoriesSegment> listResponse = await directoryClient.ListFilesAndDirectoriesSegmentAsync();

                // Delete sub directory in the Service
                await subDirectoryClient.DeleteAsync();

                // Delete Directory in the Service
                await directoryClient.DeleteAsync();
            }
            finally
            {
                // Delete Share in the service
                await shareClient.DeleteAsync();
            }
        }

        [TestMethod]
        [TestCategory("Live")]
        public async Task FileSample()
        {
            // Instantiate a new FileServiceClient using a connection string.
            FileServiceClient fileServiceClient = new FileServiceClient(TestConfigurations.DefaultTargetTenant.ConnectionString);

            // Instantiate new ShareClient
            ShareClient shareClient = fileServiceClient.GetShareClient("myshare3");
            try
            {
                // Create Share in the Service
                await shareClient.CreateAsync();

                // Instantiate new DirectoryClient
                DirectoryClient directoryClient = shareClient.GetDirectoryClient("mydirectory");

                // Create Directory in the Service
                await directoryClient.CreateAsync();

                // Instantiate new FileClient
                FileClient fileClient = directoryClient.GetFileClient("myfile");

                // Create File in the Service
                await fileClient.CreateAsync(maxSize: 1024);

                // Upload data to File
                using (FileStream fileStream = File.OpenRead("Samples/SampleSource.txt"))
                {
                    await fileClient.UploadRangeAsync(
                        writeType: FileRangeWriteType.Update,
                        range: new HttpRange(0, 1024),
                        content: fileStream);
                }

                // Download file
                using (FileStream fileStream = File.Create("SampleDestination.txt"))
                {
                    Response<StorageFileDownloadInfo> downloadResponse = await fileClient.DownloadAsync();
                    await downloadResponse.Value.Content.CopyToAsync(fileStream);
                }

                // Delete File in the Service
                await fileClient.DeleteAsync();

                // Delete Directory in the Service
                await directoryClient.DeleteAsync();
            }
            finally
            { 
                // Delete Share in the service
                await shareClient.DeleteAsync();
            }
        }
    }
}

#pragma warning restore CA2007
#pragma warning restore IDE0007
#pragma warning restore IDE0059
