// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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
            SandboxGroup sandboxGroup = CreateSandboxGroupClient();
            ContainerAppsSandbox sandbox = await CreateSandboxAsync(sandboxGroup);
            SandboxGroupSandboxFiles files = sandboxGroup
                .GetSandboxGroupSandboxClient(sandbox.Id)
                .GetSandboxGroupSandboxFilesClient();
            string directory = $"/tmp/{Recording.GenerateId("sdk-", 24)}";
            string path = $"{directory}/example.txt";

            Response<FileOpStatusResult> directoryResponse = await files.CreateSandboxDirectoryAsync(
                new MkDirContent(directory)
                {
                    CreateParents = true
                });
            Response<WriteFileResult> writeResponse = await files.UploadSandboxFileAsync(
                path,
                BinaryData.FromString("Hello from the .NET SDK"),
                createDirs: true);
            Response<Azure.Containers.Apps.Sandbox.FileInfo> metadataResponse =
                await files.GetSandboxFileMetadataAsync(path);
            Response<DirListingResult> listResponse = await files.GetSandboxFilesMetadataAsync(directory);
            Response<BinaryData> readResponse = await files.DownloadSandboxFileAsync(path);

            Assert.That(directoryResponse.Value, Is.Not.Null);
            Assert.That(writeResponse.Value, Is.Not.Null);
            Assert.That(metadataResponse.Value.Path, Is.EqualTo(path));
            Assert.That(listResponse.Value, Is.Not.Null);
            Assert.That(readResponse.Value.ToString(), Is.EqualTo("Hello from the .NET SDK"));

            await files.DeleteSandboxFileAsync(path);
            await files.DeleteSandboxFileAsync(directory, recursive: true);
        }
    }
}
