// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Containers.Apps.Sandbox.Tests
{
    public class SandboxDiskImageLiveTests : SandboxClientTestBase
    {
        public SandboxDiskImageLiveTests(bool isAsync)
            : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task GetAndListPublicDiskImages()
        {
            SandboxGroupDiskImages client = CreateSandboxGroupClient().GetSandboxGroupDiskImagesClient();
            Response<PublicDiskImage> getResponse = await client.GetPublicDiskImageAsync("ubuntu");
            bool found = false;

            await foreach (PublicDiskImage image in client.GetPublicDiskImagesAsync())
            {
                if (image.Name == "ubuntu")
                {
                    found = true;
                    break;
                }
            }

            Assert.That(getResponse.Value.Name, Is.EqualTo("ubuntu"));
            Assert.That(found, Is.True);
        }

        [RecordedTest]
        [LiveOnly(Reason = "Creating an OCI-backed disk image is long-running and should not run in the default test suite.")]
        public async Task CreateGetListAndDeleteDiskImageFromOciReference()
        {
            SandboxGroup sandboxGroup = CreateSandboxGroupClient();
            SandboxGroupDiskImages client = sandboxGroup.GetSandboxGroupDiskImagesClient();
            CreateDiskImageContent content = new CreateDiskImageContent(
                new CreateDiskImageSourceRegistrySource("mcr.microsoft.com/azurelinux/base/core:3.0"))
            {
                Name = Recording.GenerateId("image-", 40)
            };
            content.Labels.Add("test-id", Recording.GenerateId("image-test-", 40));

            Response<DiskImage> createResponse = await client.CreateDiskImageAsync(content);
            RegisterCleanup(() => DeleteDiskImageIfExistsAsync(sandboxGroup, createResponse.Value.Id));
            Response<DiskImage> getResponse = await client.GetDiskImageAsync(createResponse.Value.Id);
            bool found = false;

            await foreach (DiskImage image in client.GetDiskImagesAsync())
            {
                if (image.Id == createResponse.Value.Id)
                {
                    found = true;
                    break;
                }
            }

            Assert.That(getResponse.Value.Id, Is.EqualTo(createResponse.Value.Id));
            Assert.That(found, Is.True);

            await DeleteDiskImageIfExistsAsync(sandboxGroup, createResponse.Value.Id);
        }

        [RecordedTest]
        [LiveOnly(Reason = "Committing a sandbox to a disk image is long-running and should not run in the default test suite.")]
        public async Task CommitRunningSandboxAsDiskImage()
        {
            SandboxGroup sandboxGroup = CreateSandboxGroupClient();
            ContainerAppsSandbox sandbox = await CreateSandboxAsync(sandboxGroup);
            CommitSandboxContent content = new CommitSandboxContent();
            content.Labels.Add("test-id", Recording.GenerateId("commit-test-", 40));

            Response<CommitSandboxResult> response = await sandboxGroup
                .GetSandboxGroupSandboxClient(sandbox.Id)
                .CommitAsync(content);
            RegisterCleanup(() => DeleteDiskImageIfExistsAsync(sandboxGroup, response.Value.DiskImage.Id));

            Assert.That(response.Value.DiskImage.Id, Is.Not.Null.And.Not.Empty);
        }
    }
}
