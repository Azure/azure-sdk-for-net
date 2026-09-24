// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Containers.Apps.Sandbox.Tests
{
    public class SandboxSnapshotLiveTests : SandboxClientTestBase
    {
        public SandboxSnapshotLiveTests(bool isAsync)
            : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task CreateGetListCountAndDeleteSnapshot()
        {
            SandboxGroup sandboxGroup = CreateSandboxGroupClient();
            ContainerAppsSandbox sandbox = await CreateSandboxAsync(sandboxGroup);
            SandboxSnapshot snapshot = await CreateSnapshotAsync(sandboxGroup, sandbox.Id);
            SandboxGroupSnapshots client = sandboxGroup.GetSandboxGroupSnapshotsClient();
            bool found = false;

            Response<SandboxSnapshot> getResponse = await client.GetSnapshotAsync(snapshot.Id);
            Response<SnapshotCountResult> countResponse = await client.GetSnapshotCountAsync();
            await foreach (SandboxSnapshot item in client.GetSnapshotsAsync())
            {
                if (item.Id == snapshot.Id)
                {
                    found = true;
                    break;
                }
            }

            Assert.That(getResponse.Value.Id, Is.EqualTo(snapshot.Id));
            Assert.That(countResponse.Value.Count, Is.GreaterThanOrEqualTo(1));
            Assert.That(found, Is.True);

            await DeleteSnapshotIfExistsAsync(sandboxGroup, snapshot.Id);
        }

        [RecordedTest]
        public async Task StopAndResumeSandbox()
        {
            SandboxGroup sandboxGroup = CreateSandboxGroupClient();
            ContainerAppsSandbox sandbox = await CreateSandboxAsync(sandboxGroup);
            SandboxGroupSandbox sandboxClient = sandboxGroup.GetSandboxGroupSandboxClient(sandbox.Id);

            Response<SandboxSnapshot> stopResponse = await sandboxClient.StopAsync();
            RegisterCleanup(() => DeleteSnapshotIfExistsAsync(sandboxGroup, stopResponse.Value.Id));
            Response<ContainerAppsSandbox> resumeResponse = await sandboxClient.ResumeAsync();

            Assert.That(stopResponse.Value.SandboxId, Is.EqualTo(sandbox.Id));
            Assert.That(resumeResponse.Value.Id, Is.EqualTo(sandbox.Id));
        }
    }
}
