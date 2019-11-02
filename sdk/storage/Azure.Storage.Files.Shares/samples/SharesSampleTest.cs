// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using NUnit.Framework;

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Azure.Storage.Files.Shares.Models;
using Azure.Storage.Files.Samples;

namespace Azure.Storage.Files.Shares.Samples.Tests
{
    /// <summary>
    /// Turn the simple Shares samples into tests.
    /// </summary>
    public class SharesSampleTest : SampleTest
    {
        [Test]
        public void Sample01a_HelloWorld_Upload()
        {
            // Create a temporary Lorem Ipsum file on disk that we can upload
            string localFilePath = CreateTempFile(SampleFileContent);

            string shareName = Randomize("sample-share");
            ShareClient share = new ShareClient(ConnectionString, shareName);
            try
            {
                Sample01a_HelloWorld.Upload(ConnectionString, shareName, localFilePath);
            }
            finally
            {
                share.Delete();
                File.Delete(localFilePath);
            }
        }

        [Test]
        public async Task Sample01b_HelloWorldAsync_UploadAsync()
        {
            // Create a temporary Lorem Ipsum file on disk that we can upload
            string localFilePath = CreateTempFile(SampleFileContent);

            string shareName = Randomize("sample-share");
            ShareClient share = new ShareClient(ConnectionString, shareName);
            try
            {
                await Sample01b_HelloWorldAsync.UploadAsync(ConnectionString, shareName, localFilePath);
            }
            finally
            {
                await share.DeleteAsync();
                File.Delete(localFilePath);
            }
        }

        [Test]
        public void Sample01a_HelloWorld_Download()
        {
            string originalPath = CreateTempFile(SampleFileContent);
            string localFilePath = CreateTempPath();
            string shareName = Randomize("sample-share");
            ShareClient share = new ShareClient(ConnectionString, shareName);
            try
            {
                share.Create();

                // Get a reference to a directory named "sample-dir" and then create it
                ShareDirectoryClient directory = share.GetDirectoryClient("sample-dir");
                directory.Create();

                // Get a reference to a file named "sample-file" in directory "sample-dir"
                ShareFileClient file = directory.GetFileClient("sample-file");

                // Upload the file
                using (FileStream stream = File.OpenRead(originalPath))
                {
                    file.Create(stream.Length);
                    file.UploadRange(
                        ShareFileRangeWriteType.Update,
                        new HttpRange(0, stream.Length),
                        stream);
                }

                Sample01a_HelloWorld.Download(ConnectionString, shareName, localFilePath);

                // Verify the contents
                Assert.AreEqual(SampleFileContent, File.ReadAllText(localFilePath));
            }
            finally
            {
                share.Delete();
                File.Delete(originalPath);
                File.Delete(localFilePath);
            }
        }

        [Test]
        public async Task Sample01b_HelloWorldAsync_Download()
        {
            string originalPath = CreateTempFile(SampleFileContent);
            string localFilePath = CreateTempPath();
            string shareName = Randomize("sample-share");
            ShareClient share = new ShareClient(ConnectionString, shareName);
            try
            {
                await share.CreateAsync();

                ShareDirectoryClient directory = share.GetDirectoryClient("sample-dir");
                await directory.CreateAsync();

                ShareFileClient file = directory.GetFileClient("sample-file");

                // Upload the file
                using (FileStream stream = File.OpenRead(originalPath))
                {
                    await file.CreateAsync(stream.Length);
                    await file.UploadRangeAsync(
                        ShareFileRangeWriteType.Update,
                        new HttpRange(0, stream.Length),
                        stream);
                }

                await Sample01b_HelloWorldAsync.DownloadAsync(ConnectionString, shareName, localFilePath);

                // Verify the contents
                Assert.AreEqual(SampleFileContent, File.ReadAllText(localFilePath));
            }
            finally
            {
                await share.DeleteAsync();
                File.Delete(originalPath);
                File.Delete(localFilePath);
            }
        }

        [Test]
        public void Sample01a_HelloWorld_Traverse()
        {
            // Create a temporary Lorem Ipsum file on disk that we can upload
            string originalPath = CreateTempFile(SampleFileContent);

            // Get a reference to a share named "sample-share" and then create it
            string shareName = Randomize("sample-share");
            ShareClient share = new ShareClient(ConnectionString, shareName);
            share.Create();
            try
            {
                // Create a bunch of directories
                ShareDirectoryClient first = share.CreateDirectory("first");
                first.CreateSubdirectory("a");
                first.CreateSubdirectory("b");
                ShareDirectoryClient second = share.CreateDirectory("second");
                second.CreateSubdirectory("c");
                second.CreateSubdirectory("d");
                share.CreateDirectory("third");
                ShareDirectoryClient fourth = share.CreateDirectory("fourth");
                ShareDirectoryClient deepest = fourth.CreateSubdirectory("e");

                // Upload a file named "file"
                ShareFileClient file = deepest.GetFileClient("file");
                using (FileStream stream = File.OpenRead(originalPath))
                {
                    file.Create(stream.Length);
                    file.UploadRange(
                        ShareFileRangeWriteType.Update,
                        new HttpRange(0, stream.Length),
                        stream);
                }

                Sample01a_HelloWorld.Traverse(ConnectionString, shareName);
            }
            finally
            {
                share.Delete();
            }
        }

        [Test]
        public async Task Sample01b_HelloWorldAsync_TraverseAsync()
        {
            // Create a temporary Lorem Ipsum file on disk that we can upload
            string originalPath = CreateTempFile(SampleFileContent);

            // Get a reference to a share named "sample-share" and then create it
            string shareName = Randomize("sample-share");
            ShareClient share = new ShareClient(ConnectionString, shareName);
            await share.CreateAsync();
            try
            {
                // Create a bunch of directories
                ShareDirectoryClient first = await share.CreateDirectoryAsync("first");
                await first.CreateSubdirectoryAsync("a");
                await first.CreateSubdirectoryAsync("b");
                ShareDirectoryClient second = await share.CreateDirectoryAsync("second");
                await second.CreateSubdirectoryAsync("c");
                await second.CreateSubdirectoryAsync("d");
                await share.CreateDirectoryAsync("third");
                ShareDirectoryClient fourth = await share.CreateDirectoryAsync("fourth");
                ShareDirectoryClient deepest = await fourth.CreateSubdirectoryAsync("e");

                // Upload a file named "file"
                ShareFileClient file = deepest.GetFileClient("file");
                using (FileStream stream = File.OpenRead(originalPath))
                {
                    await file.CreateAsync(stream.Length);
                    await file.UploadRangeAsync(
                        ShareFileRangeWriteType.Update,
                        new HttpRange(0, stream.Length),
                        stream);
                }

                await Sample01b_HelloWorldAsync.TraverseAsync(ConnectionString, shareName);
            }
            finally
            {
                await share.DeleteAsync();
            }
        }

        [Test]
        public void Sample01a_HelloWorld_Errors()
        {
            // Get a reference to a share named "sample-share" and then create it
            string shareName = Randomize("sample-share");
            ShareClient share = new ShareClient(ConnectionString, shareName);

            try
            {
                share.Create();
                Sample01a_HelloWorld.Errors(ConnectionString, shareName);
            }
            finally
            {
                share.Delete();
            }
        }

        [Test]
        public async Task Sample01b_HelloWorldAsync_ErrorsAsync()
        {
            // Get a reference to a share named "sample-share" and then create it
            string shareName = Randomize("sample-share");
            ShareClient share = new ShareClient(ConnectionString, shareName);

            try
            {
                await share.CreateAsync();
                await Sample01b_HelloWorldAsync.ErrorsAsync(ConnectionString, shareName);
            }
            finally
            {
                await share.DeleteAsync();
            }
        }
    }
}
