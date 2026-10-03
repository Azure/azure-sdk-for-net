// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Azure;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Containers.Apps.Sandbox.Tests
{
    public abstract class SandboxClientTestBase : RecordedTestBase<SandboxTestEnvironment>
    {
        private readonly Stack<Func<Task>> _cleanupActions = new Stack<Func<Task>>();
        private readonly HashSet<string> _deletedContentPackageIds = new HashSet<string>();
        private readonly HashSet<string> _deletedDiskImageIds = new HashSet<string>();
        private readonly HashSet<string> _deletedSandboxIds = new HashSet<string>();
        private readonly HashSet<string> _deletedSnapshotIds = new HashSet<string>();

        protected SandboxClientTestBase(bool isAsync)
            : base(isAsync)
        {
        }

        [TearDown]
        public async Task CleanupResourcesAsync()
        {
            List<Exception> exceptions = new List<Exception>();

            while (_cleanupActions.Count > 0)
            {
                try
                {
                    await _cleanupActions.Pop()().ConfigureAwait(false);
                }
                catch (RequestFailedException exception) when (exception.Status == 404)
                {
                }
                catch (Exception exception)
                {
                    exceptions.Add(exception);
                }
            }

            if (exceptions.Count > 0)
            {
                throw new AggregateException("One or more Sandbox test resources could not be cleaned up.", exceptions);
            }
        }

        protected SandboxGroupClient CreateSandboxGroupClient()
        {
            SandboxGroupClientOptions options = InstrumentClientOptions(new SandboxGroupClientOptions());
            return InstrumentClient(new SandboxGroupClient(
                new Uri(TestEnvironment.Endpoint),
                TestEnvironment.SubscriptionId,
                TestEnvironment.ResourceGroup,
                TestEnvironment.SandboxGroupName,
                TestEnvironment.Credential,
                options));
        }

        protected async Task<SandboxProperties> CreateSandboxAsync(
            SandboxGroupClient sandboxGroup,
            string testId = null)
        {
            CreateSandboxContent content = CreateSandboxContent(testId ?? Recording.GenerateId("sandbox-test-", 40));
            Response<SandboxProperties> response = await sandboxGroup.GetSandboxesClient().CreateSandboxAsync(
                content).ConfigureAwait(false);

            RegisterCleanup(() => DeleteSandboxIfExistsAsync(sandboxGroup, response.Value.Id));
            return response.Value;
        }

        protected async Task<SandboxProperties> CreatePodSandboxAsync(SandboxGroupClient sandboxGroup)
        {
            ContainerSpec container = new ContainerSpec("default")
            {
                DiskImage = new SandboxSourceDiskImage
                {
                    Name = "ubuntu",
                    IsPublic = true
                },
                Resources = new ContainerResources
                {
                    Cpu = "1000m",
                    Memory = "2048Mi"
                }
            };
            SandboxSourcePod pod = new SandboxSourcePod(new[] { container });
            CreateSandboxContent content = new CreateSandboxContent
            {
                SourcesRef = new SandboxSource
                {
                    Pod = pod
                },
                Resources = new SandboxResources("1000m", "2048Mi")
            };
            content.Labels.Add("test-id", Recording.GenerateId("pod-test-", 40));

            Response<SandboxProperties> response = await sandboxGroup.GetSandboxesClient().CreateSandboxAsync(content).ConfigureAwait(false);
            RegisterCleanup(() => DeleteSandboxIfExistsAsync(sandboxGroup, response.Value.Id));
            return response.Value;
        }

        protected async Task<SandboxGroupVolume> CreateVolumeAsync(
            SandboxGroupClient sandboxGroup,
            bool dataDisk = false)
        {
            VolumesClient client = sandboxGroup.GetVolumesClient();
            string volumeName = Recording.GenerateId("volume-", 40);
            SandboxGroupVolume volume = dataDisk
                ? new DataDiskVolume("4Gi")
                : new ServiceManagedBlobVolume();
            volume.Labels.Add("test-id", Recording.GenerateId("volume-test-", 40));

            Response<SandboxGroupVolume> response = await client.CreateVolumeAsync(volumeName, volume).ConfigureAwait(false);
            RegisterCleanup(() => client.DeleteVolumeAsync(volumeName));
            return response.Value;
        }

        protected async Task<SandboxSnapshot> CreateSnapshotAsync(
            SandboxGroupClient sandboxGroup,
            string sandboxId)
        {
            CreateSnapshotContent content = new CreateSnapshotContent();
            content.Labels.Add("test-id", Recording.GenerateId("snapshot-test-", 40));

            Response<SandboxSnapshot> response = await sandboxGroup.GetSandboxesClient().CreateSnapshotAsync(sandboxId, content).ConfigureAwait(false);
            RegisterCleanup(() => DeleteSnapshotIfExistsAsync(sandboxGroup, response.Value.Id));
            return response.Value;
        }

        protected async Task<SandboxSecret> CreateSecretAsync(SandboxGroupClient sandboxGroup)
        {
            SecretsClient client = sandboxGroup.GetSecretsClient();
            string secretId = Recording.GenerateId("secret-", 40);
            Dictionary<string, string> values = new Dictionary<string, string>
            {
                ["username"] = "sandbox-user",
                ["password"] = "sandbox-password"
            };

            Response<SandboxSecret> response = await client.SetSecretAsync(
                secretId,
                new SetSecretContent(values)).ConfigureAwait(false);
            RegisterCleanup(() => client.DeleteSecretAsync(secretId));
            return response.Value;
        }

        protected async Task<NamedEgressPolicy> CreateEgressPolicyAsync(SandboxGroupClient sandboxGroup)
        {
            EgressPoliciesClient client = sandboxGroup.GetEgressPoliciesClient();
            string policyId = Recording.GenerateId("policy-", 40);
            NamedEgressPolicy policy = new NamedEgressPolicy(policyId, EgressPolicyAction.Allow)
            {
                Description = "Sandbox SDK test policy"
            };

            Response<NamedEgressPolicy> response = await client.SetEgressPolicyAsync(policyId, policy).ConfigureAwait(false);
            RegisterCleanup(() => client.DeleteEgressPolicyAsync(policyId));
            return response.Value;
        }

        protected async Task<ContentPackage> CreateContentPackageAsync(SandboxGroupClient sandboxGroup)
        {
            ContentPackagesClient client = sandboxGroup.GetContentPackagesClient();
            using MemoryStream content = new MemoryStream(Encoding.UTF8.GetBytes("sandbox test package"));
            Response<ContentPackage> response = await client.UploadContentPackageAsync(
                content,
                "application/octet-stream",
                $"test-id={Recording.GenerateId("package-", 30)}").ConfigureAwait(false);
            RegisterCleanup(() => DeleteContentPackageIfExistsAsync(sandboxGroup, response.Value.Id));
            return response.Value;
        }

        protected static async Task AddVolumeMountAsync(
            SandboxGroupClient sandboxGroup,
            string sandboxId,
            SandboxVolume mount)
        {
            try
            {
                await sandboxGroup.GetSandboxesClient()
                    .AddVolumeMountAsync(sandboxId, new SandboxVolumeMountContent(mount))
                    .ConfigureAwait(false);
            }
            catch (RequestFailedException exception) when (exception.Status == 200)
            {
                // The service currently returns 200 although the API contract specifies 204.
            }
        }

        protected void RegisterCleanup(Func<Task> cleanupAction)
        {
            _cleanupActions.Push(cleanupAction);
        }

        protected async Task DeleteSandboxIfExistsAsync(SandboxGroupClient sandboxGroup, string sandboxId)
        {
            if (_deletedSandboxIds.Contains(sandboxId))
            {
                return;
            }

            try
            {
                await sandboxGroup.GetSandboxesClient().DeleteAsync(sandboxId).ConfigureAwait(false);
                _deletedSandboxIds.Add(sandboxId);
            }
            catch (RequestFailedException exception) when (exception.Status == 200 || exception.Status == 404)
            {
                // The service currently returns 200 although the API contract specifies 204.
                _deletedSandboxIds.Add(sandboxId);
            }
        }

        protected async Task DeleteSnapshotIfExistsAsync(SandboxGroupClient sandboxGroup, string snapshotId)
        {
            if (_deletedSnapshotIds.Contains(snapshotId))
            {
                return;
            }

            try
            {
                await sandboxGroup.GetSnapshotsClient().DeleteSnapshotAsync(snapshotId).ConfigureAwait(false);
                _deletedSnapshotIds.Add(snapshotId);
            }
            catch (RequestFailedException exception) when (exception.Status == 202 || exception.Status == 404)
            {
                // The service currently returns 202 although the API contract specifies 204.
                _deletedSnapshotIds.Add(snapshotId);
            }
        }

        protected async Task DeleteContentPackageIfExistsAsync(SandboxGroupClient sandboxGroup, string contentPackageId)
        {
            if (_deletedContentPackageIds.Contains(contentPackageId))
            {
                return;
            }

            try
            {
                await sandboxGroup
                    .GetContentPackagesClient()
                    .DeleteContentPackageAsync(contentPackageId)
                    .ConfigureAwait(false);
                _deletedContentPackageIds.Add(contentPackageId);
            }
            catch (RequestFailedException exception) when (exception.Status == 202 || exception.Status == 404)
            {
                // The service currently returns 202 although the API contract specifies 204.
                _deletedContentPackageIds.Add(contentPackageId);
            }
        }

        protected async Task DeleteDiskImageIfExistsAsync(SandboxGroupClient sandboxGroup, string diskImageId)
        {
            if (_deletedDiskImageIds.Contains(diskImageId))
            {
                return;
            }

            try
            {
                await sandboxGroup
                    .GetDiskImagesClient()
                    .DeleteDiskImageAsync(diskImageId)
                    .ConfigureAwait(false);
                _deletedDiskImageIds.Add(diskImageId);
            }
            catch (RequestFailedException exception) when (exception.Status == 202 || exception.Status == 404)
            {
                // The service currently returns 202 although the API contract specifies 204.
                _deletedDiskImageIds.Add(diskImageId);
            }
        }

        internal static CreateSandboxContent CreateSandboxContent(string testId)
        {
            CreateSandboxContent content = new CreateSandboxContent
            {
                SourcesRef = new SandboxSource
                {
                    DiskImage = new SandboxSourceDiskImage
                    {
                        Name = "ubuntu",
                        IsPublic = true
                    }
                },
                Resources = new SandboxResources("1000m", "2048Mi")
            };
            content.Labels.Add("test-id", testId);
            return content;
        }
    }
}
