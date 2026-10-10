// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Containers.Apps.Sandbox.Tests
{
    public class SandboxGroupResourceLiveTests : SandboxClientTestBase
    {
        public SandboxGroupResourceLiveTests(bool isAsync)
            : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task UpsertListGetKeysPeekAndDeleteSecret()
        {
            SandboxGroupClient sandboxGroup = CreateSandboxGroupClient();
            SandboxSecret secret = await CreateSecretAsync(sandboxGroup);
            SecretsClient client = sandboxGroup.GetSecretsClient();
            bool found = false;

            Response<SecretKeysResult> keysResponse = await client.GetSecretKeysAsync(secret.Id);
            Response<SecretPeekResult> peekResponse = await client.PeekSecretAsync(secret.Id);
            await foreach (SandboxSecret item in client.GetSecretsAsync())
            {
                if (item.Id == secret.Id)
                {
                    found = true;
                    break;
                }
            }

            Assert.That(keysResponse.Value, Is.Not.Null);
            Assert.That(peekResponse.Value, Is.Not.Null);
            Assert.That(found, Is.True);

            await client.DeleteSecretAsync(secret.Id);
        }

        [RecordedTest]
        public async Task CreateGetListAndDeleteNamedEgressPolicy()
        {
            SandboxGroupClient sandboxGroup = CreateSandboxGroupClient();
            NamedEgressPolicy policy = await CreateEgressPolicyAsync(sandboxGroup);
            EgressPoliciesClient client = sandboxGroup.GetEgressPoliciesClient();
            bool found = false;

            Response<NamedEgressPolicy> getResponse = await client.GetEgressPolicyAsync(policy.Name);
            await foreach (NamedEgressPolicy item in client.GetEgressPoliciesAsync())
            {
                if (item.Name == policy.Name)
                {
                    found = true;
                    break;
                }
            }

            Assert.That(getResponse.Value.Name, Is.EqualTo(policy.Name));
            Assert.That(found, Is.True);

            await client.DeleteEgressPolicyAsync(policy.Name);
        }

        [RecordedTest]
        public async Task UploadGetListDownloadAndDeleteContentPackage()
        {
            SandboxGroupClient sandboxGroup = CreateSandboxGroupClient();
            ContentPackage package = await CreateContentPackageAsync(sandboxGroup);
            ContentPackagesClient client = sandboxGroup.GetContentPackagesClient();
            bool found = false;

            Response<ContentPackage> getResponse = await client.GetContentPackageAsync(package.Id);
            await foreach (ContentPackage item in client.GetContentPackagesAsync())
            {
                if (item.Id == package.Id)
                {
                    found = true;
                    break;
                }
            }

            Assert.That(getResponse.Value.Id, Is.EqualTo(package.Id));
            Assert.That(found, Is.True);

            SandboxProperties sandbox = await CreateSandboxAsync(sandboxGroup);
            DownloadContentPackageToSandboxContent download = new DownloadContentPackageToSandboxContent(
                package.Id,
                "/tmp/package.bin");
            Response downloadResponse = await sandboxGroup
                .GetSandboxesClient()
                .DownloadContentPackageAsync(sandbox.Id, download);

            Assert.That(downloadResponse.Status, Is.InRange(200, 299));
            await DeleteContentPackageIfExistsAsync(sandboxGroup, package.Id);
        }
    }
}
