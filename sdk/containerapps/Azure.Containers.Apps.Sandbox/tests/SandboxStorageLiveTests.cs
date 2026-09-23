// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Containers.Apps.Sandbox.Tests
{
    public class SandboxStorageLiveTests : SandboxClientTestBase
    {
        public SandboxStorageLiveTests(bool isAsync)
            : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task CreateGetListCountAndDeleteVolume()
        {
            SandboxGroup sandboxGroup = CreateSandboxGroupClient();
            SandboxGroupVolumes client = sandboxGroup.GetSandboxGroupVolumesClient();
            SandboxGroupVolume volume = await CreateVolumeAsync(sandboxGroup);
            bool found = false;

            Response<SandboxGroupVolume> getResponse = await client.GetVolumeAsync(volume.VolumeName);
            Response<VolumeCountResult> countResponse = await client.GetVolumeCountsAsync();
            await foreach (SandboxGroupVolume item in client.GetVolumesAsync())
            {
                if (item.VolumeName == volume.VolumeName)
                {
                    found = true;
                    break;
                }
            }

            Assert.That(getResponse.Value.VolumeName, Is.EqualTo(volume.VolumeName));
            Assert.That(countResponse.Value, Is.Not.Null);
            Assert.That(found, Is.True);

            await client.DeleteVolumeAsync(volume.VolumeName);
        }

        [RecordedTest]
        public async Task ManageVolumeDirectoryAndFile()
        {
            SandboxGroup sandboxGroup = CreateSandboxGroupClient();
            SandboxGroupVolumes client = sandboxGroup.GetSandboxGroupVolumesClient();
            SandboxGroupVolume volume = await CreateVolumeAsync(sandboxGroup);
            string directory = "workspace";
            string path = $"{directory}/example.txt";
            BinaryData content = BinaryData.FromString("Hello");

            Response<VolumePathItem> directoryResponse = await client.CreateVolumeDirectoryAsync(volume.VolumeName, directory);
            RequestContext context = new RequestContext
            {
                ErrorOptions = ErrorOptions.NoThrow
            };
            Response uploadResponse = await client.UploadVolumeFileAsync(
                volume.VolumeName,
                path,
                RequestContent.Create(content),
                overwrite: true,
                matchConditions: default,
                context);
            VolumePathItem uploadedItem = (VolumePathItem)uploadResponse;
            Response<VolumeListDirectoryResult> listResponse = await client.GetVolumeFilesMetadataAsync(
                volume.VolumeName,
                directory);
            Response<BinaryData> downloadResponse = await client.DownloadVolumeFileAsync(volume.VolumeName, path);

            Assert.That(directoryResponse.Value.IsDirectory, Is.True);
            Assert.That(uploadResponse.Status, Is.EqualTo(200));
            Assert.That(uploadedItem.Path, Is.EqualTo(path));
            Assert.That(listResponse.Value, Is.Not.Null);
            Assert.That(downloadResponse.Value.ToString(), Is.EqualTo("Hello"));

            await DeleteVolumePathAsync(client, volume.VolumeName, path);
            await DeleteVolumePathAsync(client, volume.VolumeName, directory, recursive: true);
        }

        [RecordedTest]
        [Ignore("Forking requires a populated data disk, but the current service cannot mount a data disk with the public Ubuntu image because that image consumes the full disk budget, and data-disk file upload is unsupported.")]
        public async Task ForkDataDiskVolume()
        {
            SandboxGroup sandboxGroup = CreateSandboxGroupClient();
            SandboxGroupVolumes client = sandboxGroup.GetSandboxGroupVolumesClient();
            SandboxGroupVolume source = await CreateVolumeAsync(sandboxGroup, dataDisk: true);

            string destinationName = Recording.GenerateId("fork-", 40);
            ForkDataDiskVolumeContent content = new ForkDataDiskVolumeContent(destinationName);

            Response<SandboxGroupVolume> response = await client.ForkVolumeAsync(source.VolumeName, content);
            RegisterCleanup(() => client.DeleteVolumeAsync(destinationName));

            Assert.That(response.Value.VolumeName, Is.EqualTo(destinationName));
        }

        [RecordedTest]
        public async Task AddVolumeMountToSandbox()
        {
            SandboxGroup sandboxGroup = CreateSandboxGroupClient();
            SandboxGroupVolume volume = await CreateVolumeAsync(sandboxGroup);
            ContainerAppsSandbox sandbox = await CreateSandboxAsync(sandboxGroup);
            SandboxVolume mount = new SandboxVolume(volume.VolumeName, "/mnt/data")
            {
                ReadOnly = true
            };

            await AddVolumeMountAsync(sandboxGroup, sandbox.Id, mount);
        }

        private static async Task DeleteVolumePathAsync(
            SandboxGroupVolumes client,
            string volumeName,
            string path,
            bool? recursive = default)
        {
            try
            {
                await client.DeleteVolumeFileAsync(volumeName, path, recursive);
            }
            catch (RequestFailedException exception) when (exception.Status == 200)
            {
                // The service currently returns 200 although the API contract specifies 204.
            }
        }
    }
}
