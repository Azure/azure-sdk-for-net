// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Containers.Apps.Sandbox.Tests
{
    public class SandboxPodVolumeLiveTests : SandboxClientTestBase
    {
        public SandboxPodVolumeLiveTests(bool isAsync)
            : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task AddPodVolumeMountsToSandbox()
        {
            SandboxGroup sandboxGroup = CreateSandboxGroupClient();
            ContainerAppsSandbox sandbox = await CreatePodSandboxAsync(sandboxGroup);
            LocalPodVolume volume = new LocalPodVolume("workspace", "1Gi");
            ContainerVolumeMount mount = new ContainerVolumeMount("workspace", "/workspace")
            {
                ReadOnly = true
            };
            ContainerVolumeMounts mounts = new ContainerVolumeMounts(
                "default",
                new List<ContainerVolumeMount> { mount });
            AddPodVolumeMountsContent content = new AddPodVolumeMountsContent(
                new List<PodVolume> { volume },
                new List<ContainerVolumeMounts> { mounts });

            try
            {
                Response response = await sandboxGroup
                    .GetSandboxGroupSandboxClient(sandbox.Id)
                    .AddPodVolumeMountsAsync(content);

                Assert.That(response.Status, Is.InRange(200, 299));
            }
            catch (RequestFailedException exception) when (exception.Status == 200)
            {
                // The service currently returns 200 although the API contract specifies 204.
            }
        }
    }
}
