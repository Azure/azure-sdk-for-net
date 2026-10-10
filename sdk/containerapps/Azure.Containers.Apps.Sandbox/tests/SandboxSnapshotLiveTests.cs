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
            SandboxGroupClient sandboxGroup = CreateSandboxGroupClient();
            SandboxProperties sandbox = await CreateSandboxAsync(sandboxGroup);
            SandboxSnapshot snapshot = await CreateSnapshotAsync(sandboxGroup, sandbox.Id);
            SnapshotsClient client = sandboxGroup.GetSnapshotsClient();
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
            SandboxGroupClient sandboxGroup = CreateSandboxGroupClient();
            SandboxProperties sandbox = await CreateSandboxAsync(sandboxGroup);
            SandboxesClient sandboxClient = sandboxGroup.GetSandboxesClient();

            Response<SandboxSnapshot> stopResponse = await sandboxClient.StopAsync(sandbox.Id);
            RegisterCleanup(() => DeleteSnapshotIfExistsAsync(sandboxGroup, stopResponse.Value.Id));
            Response<SandboxProperties> resumeResponse = await sandboxClient.ResumeAsync(sandbox.Id);

            Assert.That(stopResponse.Value.SandboxId, Is.EqualTo(sandbox.Id));
            Assert.That(resumeResponse.Value.Id, Is.EqualTo(sandbox.Id));
        }
    }
}
