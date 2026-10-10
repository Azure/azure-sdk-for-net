// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Azure;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Containers.Apps.Sandbox.Tests
{
    public class SandboxFilesLiveTests : SandboxClientTestBase
    {
        public SandboxFilesLiveTests(bool isAsync)
            : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task CreateListReadWriteAndDeleteSandboxFiles()
        {
            SandboxGroupClient sandboxGroup = CreateSandboxGroupClient();
            SandboxProperties sandbox = await CreateSandboxAsync(sandboxGroup);
            SandboxesClient files = sandboxGroup.GetSandboxesClient();
            string directory = $"/tmp/{Recording.GenerateId("sdk-", 24)}";
            string path = $"{directory}/example.txt";
            const string fileContent = "Hello from the .NET SDK";

            Response<SandboxFileOperationResult> directoryResponse = await files.CreateSandboxDirectoryAsync(
                sandbox.Id,
                new SandboxDirectoryContent(directory)
                {
                    CreateParents = true
                });
            using MemoryStream uploadContent = new MemoryStream(Encoding.UTF8.GetBytes(fileContent));
            Response<WriteFileResult> writeResponse = await files.UploadSandboxFileAsync(
                sandbox.Id,
                path,
                uploadContent,
                createDirs: true);
            Response<SandboxFileInfo> metadataResponse =
                await files.GetSandboxFileMetadataAsync(sandbox.Id, path);
            Response<SandboxDirectoryListingResult> listResponse =
                await files.GetSandboxFilesMetadataAsync(sandbox.Id, directory);
            Response<Stream> readResponse = await files.DownloadSandboxFileAsync(sandbox.Id, path);
            using StreamReader reader = new StreamReader(readResponse.Value);
            string downloadedContent = await reader.ReadToEndAsync();

            Assert.That(directoryResponse.Value, Is.Not.Null);
            Assert.That(writeResponse.Value, Is.Not.Null);
            Assert.That(metadataResponse.Value.Path, Is.EqualTo(path));
            Assert.That(listResponse.Value, Is.Not.Null);
            Assert.That(downloadedContent, Is.EqualTo(fileContent));

            await files.DeleteSandboxFileAsync(sandbox.Id, path);
            await files.DeleteSandboxFileAsync(sandbox.Id, directory, recursive: true);
        }
    }
}
