// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Containers.Apps.Sandbox.Tests
{
    public class SandboxErrorLiveTests : SandboxClientTestBase
    {
        public SandboxErrorLiveTests(bool isAsync)
            : base(isAsync)
        {
        }

        [RecordedTest]
        public void UnauthorizedRequestReturnsStructuredError()
        {
            SandboxGroupDiskImages client = CreateSandboxGroupClient(
                new MockCredential(),
                TestEnvironment.SubscriptionId,
                TestEnvironment.ResourceGroup,
                TestEnvironment.SandboxGroupName,
                disableRetries: true)
                .GetSandboxGroupDiskImagesClient();

            RequestFailedException exception = Assert.ThrowsAsync<RequestFailedException>(
                async () => await client.GetPublicDiskImageAsync("ubuntu"));

            Assert.That(exception.Status, Is.EqualTo(401));
            Assert.That(exception.ErrorCode, Is.EqualTo("Unauthorized"));
            Assert.That(exception.Message, Does.Contain("Authentication is required to access this resource."));
        }

        [RecordedTest]
        public void ForbiddenRequestReturnsStructuredError()
        {
            SandboxGroupSandbox client = CreateSandboxGroupClient(
                TestEnvironment.Credential,
                Guid.Empty.ToString(),
                "unauthorized",
                "unauthorized",
                disableRetries: true)
                .GetSandboxGroupSandboxClient("does-not-exist");

            RequestFailedException exception = Assert.ThrowsAsync<RequestFailedException>(
                async () => await client.GetPropertiesAsync());

            Assert.That(exception.Status, Is.EqualTo(403));
            Assert.That(exception.ErrorCode, Is.EqualTo("Forbidden"));
            Assert.That(exception.Message, Does.Contain("The caller is not authorized to perform this operation."));
        }
    }
}
