// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Containers.Apps.Sandbox.Tests
{
    public class SandboxClientLiveTests : SandboxClientTestBase
    {
        public SandboxClientLiveTests(bool isAsync)
            : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task CreateAndDeleteSandbox()
        {
            SandboxGroupClient sandboxGroup = CreateSandboxGroupClient();
            SandboxesClient sandboxes = sandboxGroup.GetSandboxesClient();
            Response<SandboxProperties> createResponse = await sandboxes.CreateSandboxAsync(
                CreateSandboxContent(Recording.GenerateId()));

            Response<SandboxProperties> getResponse = await sandboxes.GetPropertiesAsync(createResponse.Value.Id);

            Assert.That(createResponse.Value.Id, Is.Not.Null.And.Not.Empty);
            Assert.That(getResponse.Value.Id, Is.EqualTo(createResponse.Value.Id));

            await DeleteSandboxIfExistsAsync(sandboxGroup, createResponse.Value.Id);
        }
    }
}
