// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.EdgeActions.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.EdgeActions.Tests
{
    public class EdgeActionLifecycleTests : EdgeActionsManagementTestBase
    {
        private const string Handler = "function handler(event) { return event; }";
        private static readonly AzureLocation EdgeLocation = new AzureLocation("global");

        public EdgeActionLifecycleTests(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task EdgeActionTags()
        {
            EdgeActionResource action = await CreateEdgeAction();
            EdgeActionCollection actions = Client.GetResourceGroupResource(action.Id.Parent).GetEdgeActions();
            Assert.That((await actions.ExistsAsync(action.Id.Name, TestCancellationToken)).Value, Is.True);
            Assert.That((await actions.GetIfExistsAsync(action.Id.Name, TestCancellationToken)).HasValue, Is.True);
            Assert.That((await actions.GetAsync(action.Id.Name, TestCancellationToken)).Value.Data.Tags["purpose"], Is.EqualTo("initial"));

            var names = new List<string>();
            await foreach (EdgeActionResource item in actions.GetAllAsync(cancellationToken: TestCancellationToken))
            {
                names.Add(item.Id.Name);
            }
            Assert.That(names, Does.Contain(action.Id.Name));

            var patch = new EdgeActionPatch();
            patch.Tags.Add("purpose", "updated");
            EdgeActionResource updated = (await action.UpdateAsync(WaitUntil.Completed, patch, TestCancellationToken)).Value;
            Assert.That(updated.Data.Tags.Count, Is.EqualTo(1));
            Assert.That(updated.Data.Tags["purpose"], Is.EqualTo("updated"));
            Assert.That(updated.Data.Sku.Name, Is.EqualTo("Standard"));
            Assert.That(updated.Data.Sku.Tier, Is.EqualTo("Standard"));
            Assert.That(updated.Data.Location, Is.EqualTo(EdgeLocation));
            Assert.That((await action.GetAsync(TestCancellationToken)).Value.Data.Tags, Is.EquivalentTo(updated.Data.Tags));

            patch.Tags.Clear();
            updated = (await action.UpdateAsync(WaitUntil.Completed, patch, TestCancellationToken)).Value;
            Assert.That(updated.Data.Tags, Is.Empty);
            Assert.That((await action.GetAsync(TestCancellationToken)).Value.Data.Tags, Is.Empty);
            RequestFailedException error = Assert.ThrowsAsync<RequestFailedException>(
                async () => await action.UpdateAsync(WaitUntil.Completed, new EdgeActionPatch(), TestCancellationToken));
            Assert.That(error.Status, Is.EqualTo(400));

            await action.DeleteAsync(WaitUntil.Completed, TestCancellationToken);
            Assert.That((await actions.ExistsAsync(action.Id.Name, TestCancellationToken)).Value, Is.False);
        }

        [RecordedTest]
        [TestCase("file")]
        [TestCase("zip")]
        public async Task VersionMetadata(string deploymentType)
        {
            EdgeActionResource action = await CreateEdgeAction();
            EdgeActionVersionCollection versions = action.GetEdgeActionVersions();
            var data = new EdgeActionVersionData(EdgeLocation)
            {
                Properties = new EdgeActionVersionProperties(new EdgeActionVersionDeploymentType(deploymentType), EdgeActionIsDefaultVersion.False)
            };
            EdgeActionVersionResource version = (await versions.CreateOrUpdateAsync(WaitUntil.Completed, "v1", data, TestCancellationToken)).Value;
            AssertVersion(version, action, "v1", deploymentType);
            Assert.That(version.Data.Properties.IsDefaultVersion, Is.EqualTo(EdgeActionIsDefaultVersion.True));
            Assert.That((await versions.ExistsAsync("v1", TestCancellationToken)).Value, Is.True);
            Assert.That((await versions.GetIfExistsAsync("missing", TestCancellationToken)).HasValue, Is.False);
            AssertVersion((await versions.GetAsync("v1", TestCancellationToken)).Value, action, "v1", deploymentType);
            var names = new List<string>();
            await foreach (EdgeActionVersionResource item in versions.GetAllAsync(cancellationToken: TestCancellationToken))
            {
                names.Add(item.Id.Name);
            }
            Assert.That(names, Is.EquivalentTo(new[] { "v1" }));

            var patch = new EdgeActionVersionPatch();
            patch.Tags.Add("purpose", "updated");
            EdgeActionVersionResource updated = (await version.UpdateAsync(WaitUntil.Completed, patch, TestCancellationToken)).Value;
            AssertVersion(updated, action, "v1", deploymentType);
            Assert.That(updated.Data.Tags["purpose"], Is.EqualTo("updated"));
            Assert.That(updated.Data.Properties.IsDefaultVersion, Is.EqualTo(EdgeActionIsDefaultVersion.True));
            Assert.That((await version.GetAsync(TestCancellationToken)).Value.Data.Tags, Is.EquivalentTo(updated.Data.Tags));
            patch.Tags.Clear();
            Assert.That((await version.UpdateAsync(WaitUntil.Completed, patch, TestCancellationToken)).Value.Data.Tags, Is.Empty);
            await version.DeleteAsync(WaitUntil.Completed, TestCancellationToken);
            Assert.That((await versions.ExistsAsync("v1", TestCancellationToken)).Value, Is.False);
            await action.DeleteAsync(WaitUntil.Completed, TestCancellationToken);
        }

        [RecordedTest]
        [Property(DeploymentCountProperty, 2)]
        public async Task ExecutionFilterLifecycle()
        {
            EdgeActionResource action = await CreateEdgeAction();
            EdgeActionVersionCollection versions = action.GetEdgeActionVersions();
            var data = new EdgeActionVersionData(EdgeLocation)
            {
                Properties = new EdgeActionVersionProperties(EdgeActionVersionDeploymentType.File, EdgeActionIsDefaultVersion.False)
            };
            EdgeActionVersionResource first = (await versions.CreateOrUpdateAsync(WaitUntil.Completed, "v1", data, TestCancellationToken)).Value;
            EdgeActionVersionResource second = (await versions.CreateOrUpdateAsync(WaitUntil.Completed, "v2", data, TestCancellationToken)).Value;

            await ExerciseExecutionFilter(action, first, second);

            await second.DeleteAsync(WaitUntil.Completed, TestCancellationToken);
            await first.DeleteAsync(WaitUntil.Completed, TestCancellationToken);
            await action.DeleteAsync(WaitUntil.Completed, TestCancellationToken);
        }

        [RecordedTest]
        [TestCase("file")]
        [TestCase("zip")]
        [Property(DeploymentCountProperty, 3)]
        public async Task VersionsAndExecutionFilters(string deploymentType)
        {
            EdgeActionResource action = await CreateEdgeAction();
            EdgeActionVersionCollection versions = action.GetEdgeActionVersions();
            var createdVersions = new List<EdgeActionVersionResource>();
            foreach (string name in new[] { "v1", "v2" })
            {
                var data = new EdgeActionVersionData(EdgeLocation)
                {
                    Properties = new EdgeActionVersionProperties(new EdgeActionVersionDeploymentType(deploymentType), EdgeActionIsDefaultVersion.False)
                };
                EdgeActionVersionResource version = (await versions.CreateOrUpdateAsync(WaitUntil.Completed, name, data, TestCancellationToken)).Value;
                AssertVersion(version, action, name, deploymentType);
                Assert.That(version.Data.Properties.IsDefaultVersion, Is.EqualTo(name == "v1" ? EdgeActionIsDefaultVersion.True : EdgeActionIsDefaultVersion.False));

                var code = new EdgeActionVersionCode(CreateCode(deploymentType), name);
                EdgeActionVersionResource deployed = (await version.DeployVersionCodeAsync(WaitUntil.Completed, code, TestCancellationToken)).Value;
                AssertVersion(deployed, action, name, deploymentType);
                Assert.That(deployed.Data.Properties.ValidationStatus, Is.EqualTo(EdgeActionVersionValidationStatus.Succeeded));
                Assert.That(deployed.Data.Properties.IsDefaultVersion, Is.EqualTo(version.Data.Properties.IsDefaultVersion));
                createdVersions.Add(deployed);
            }

            var names = new List<string>();
            await foreach (EdgeActionVersionResource item in versions.GetAllAsync(cancellationToken: TestCancellationToken))
            {
                names.Add(item.Id.Name);
            }
            Assert.That(names, Is.EquivalentTo(new[] { "v1", "v2" }));
            Assert.That((await versions.ExistsAsync("v1", TestCancellationToken)).Value, Is.True);
            Assert.That((await versions.GetIfExistsAsync("missing", TestCancellationToken)).HasValue, Is.False);

            EdgeActionVersionResource first = createdVersions[0];
            EdgeActionVersionResource second = createdVersions[1];
            EdgeActionVersionCode downloaded = (await first.GetVersionCodeAsync(WaitUntil.Completed, TestCancellationToken)).Value;
            Assert.That(downloaded.Name, Is.Not.Null.And.Not.Empty);
            AssertCode(downloaded.Content);

            var patch = new EdgeActionVersionPatch();
            patch.Tags.Add("purpose", "updated");
            EdgeActionVersionResource updated = (await first.UpdateAsync(WaitUntil.Completed, patch, TestCancellationToken)).Value;
            AssertVersion(updated, action, "v1", deploymentType);
            Assert.That(updated.Data.Tags["purpose"], Is.EqualTo("updated"));
            Assert.That(updated.Data.Properties.IsDefaultVersion, Is.EqualTo(EdgeActionIsDefaultVersion.True));
            Assert.That((await first.GetAsync(TestCancellationToken)).Value.Data.Tags, Is.EquivalentTo(updated.Data.Tags));
            RequestFailedException error = Assert.ThrowsAsync<RequestFailedException>(async () => await first.UpdateAsync(
                WaitUntil.Completed, new EdgeActionVersionPatch
                {
                    Properties = new EdgeActionVersionUpdateProperties { IsDefaultVersion = EdgeActionIsDefaultVersion.False }
                }, TestCancellationToken));
            Assert.That(error.Status, Is.EqualTo(400));

            ArmOperation swap = await second.SwapDefaultAsync(WaitUntil.Completed, TestCancellationToken);
            Assert.That(swap.HasCompleted, Is.True);
            Assert.That((await first.GetAsync(TestCancellationToken)).Value.Data.Properties.IsDefaultVersion, Is.EqualTo(EdgeActionIsDefaultVersion.False));
            Assert.That((await second.GetAsync(TestCancellationToken)).Value.Data.Properties.IsDefaultVersion, Is.EqualTo(EdgeActionIsDefaultVersion.True));

            await ExerciseExecutionFilter(action, first, second);

            // The service requires non-default versions to be deleted before the default version.
            await first.DeleteAsync(WaitUntil.Completed, TestCancellationToken);
            await second.DeleteAsync(WaitUntil.Completed, TestCancellationToken);
            Assert.That((await versions.ExistsAsync("v1", TestCancellationToken)).Value, Is.False);
            Assert.That((await versions.ExistsAsync("v2", TestCancellationToken)).Value, Is.False);
            await action.DeleteAsync(WaitUntil.Completed, TestCancellationToken);
        }

        private async Task ExerciseExecutionFilter(EdgeActionResource action, EdgeActionVersionResource first, EdgeActionVersionResource second)
        {
            EdgeActionExecutionFilterCollection filters = action.GetEdgeActionExecutionFilters();
            const string filterName = "sdkfilter";
            var filterData = new EdgeActionExecutionFilterData(EdgeLocation)
            {
                Properties = new EdgeActionExecutionFilterProperties(first.Id, "x-sdk-test", "initial")
            };
            EdgeActionExecutionFilterResource filter = (await filters.CreateOrUpdateAsync(WaitUntil.Completed, filterName, filterData, TestCancellationToken)).Value;
            Assert.That(filter.Id, Is.EqualTo(EdgeActionExecutionFilterResource.CreateResourceIdentifier(action.Id.SubscriptionId, action.Id.ResourceGroupName, action.Id.Name, filterName)));
            Assert.That(filter.Data.Properties.VersionId, Is.EqualTo(first.Id));
            Assert.That(filter.Data.Properties.ExecutionFilterIdentifierHeaderName, Is.EqualTo("x-sdk-test"));
            Assert.That(filter.Data.Properties.ExecutionFilterIdentifierHeaderValue, Is.EqualTo("initial"));
            Assert.That((await filters.ExistsAsync(filterName, TestCancellationToken)).Value, Is.True);
            Assert.That((await filters.GetAsync(filterName, TestCancellationToken)).Value.Data.Properties.VersionId, Is.EqualTo(first.Id));
            var names = new List<string>();
            await foreach (EdgeActionExecutionFilterResource item in filters.GetAllAsync(cancellationToken: TestCancellationToken))
            {
                names.Add(item.Id.Name);
            }
            Assert.That(names, Is.EquivalentTo(new[] { filterName }));

            var filterPatch = new EdgeActionExecutionFilterPatch
            {
                Properties = new EdgeActionExecutionFilterUpdateProperties
                {
                    VersionId = second.Id,
                    ExecutionFilterIdentifierHeaderName = "x-sdk-test-updated",
                    ExecutionFilterIdentifierHeaderValue = "updated"
                }
            };
            filterPatch.Tags.Add("purpose", "updated");
            filter = (await filter.UpdateAsync(WaitUntil.Completed, filterPatch, TestCancellationToken)).Value;
            Assert.That(filter.Data.Properties.VersionId, Is.EqualTo(second.Id));
            Assert.That(filter.Data.Properties.ExecutionFilterIdentifierHeaderName, Is.EqualTo("x-sdk-test-updated"));
            Assert.That(filter.Data.Properties.ExecutionFilterIdentifierHeaderValue, Is.EqualTo("updated"));
            Assert.That(filter.Data.Tags["purpose"], Is.EqualTo("updated"));
            Assert.That((await filter.GetAsync(TestCancellationToken)).Value.Data.Properties.VersionId, Is.EqualTo(second.Id));

            await filter.DeleteAsync(WaitUntil.Completed, TestCancellationToken);
            Assert.That((await filters.ExistsAsync(filterName, TestCancellationToken)).Value, Is.False);
        }

        private async Task<EdgeActionResource> CreateEdgeAction()
        {
            SubscriptionResource subscription = Client.GetSubscriptionResource(new ResourceIdentifier($"/subscriptions/{TestEnvironment.SubscriptionId}"));
            ResourceGroupResource group = await CreateResourceGroup(subscription, "dotnetsdk-edgeaction-test-");
            string name = Recording.GenerateAssetName("eadotnet");
            EdgeActionCollection actions = group.GetEdgeActions();
            Assert.That((await actions.ExistsAsync(name, TestCancellationToken)).Value, Is.False, "Refusing to overwrite an existing Edge Action.");
            var data = new EdgeActionData(EdgeLocation, new EdgeActionSkuType("Standard", "Standard"));
            data.Tags.Add("purpose", "initial");
            data.Tags.Add("remove-me", "initial");
            EdgeActionResource action = (await actions.CreateOrUpdateAsync(WaitUntil.Completed, name, data, TestCancellationToken)).Value;
            Assert.That(action.Id.Name, Is.EqualTo(name));
            Assert.That(action.Data.Location, Is.EqualTo(EdgeLocation));
            Assert.That(action.Data.Properties.ProvisioningState, Is.EqualTo(EdgeActionProvisioningState.Succeeded));
            Assert.That(action.Data.Tags, Is.EquivalentTo(data.Tags));
            return action;
        }

        private static void AssertVersion(EdgeActionVersionResource version, EdgeActionResource action, string name, string deploymentType)
        {
            Assert.That(version.HasData, Is.True);
            Assert.That(version.Id, Is.EqualTo(EdgeActionVersionResource.CreateResourceIdentifier(action.Id.SubscriptionId, action.Id.ResourceGroupName, action.Id.Name, name)));
            Assert.That(version.Data.Name, Is.EqualTo(name));
            Assert.That(version.Data.ResourceType, Is.EqualTo(EdgeActionVersionResource.ResourceType));
            Assert.That(version.Data.Location, Is.EqualTo(EdgeLocation));
            Assert.That(version.Data.Properties.DeploymentType.ToString(), Is.EqualTo(deploymentType));
            Assert.That(version.Data.Properties.ProvisioningState, Is.EqualTo(EdgeActionProvisioningState.Succeeded));
        }

        private static string CreateCode(string deploymentType)
        {
            byte[] content = Encoding.UTF8.GetBytes(Handler);
            if (deploymentType == "file")
            {
                return Convert.ToBase64String(content);
            }
            using var stream = new MemoryStream();
            using (var archive = new ZipArchive(stream, ZipArchiveMode.Create, leaveOpen: true))
            {
                ZipArchiveEntry entry = archive.CreateEntry("handler.js");
                entry.LastWriteTime = new DateTimeOffset(1980, 1, 1, 0, 0, 0, TimeSpan.Zero);
                using Stream entryStream = entry.Open();
                entryStream.Write(content, 0, content.Length);
            }
            return Convert.ToBase64String(stream.ToArray());
        }

        private static void AssertCode(string content)
        {
            byte[] bytes = Convert.FromBase64String(content);
            if (bytes.Length >= 4 && bytes[0] == 'P' && bytes[1] == 'K')
            {
                using var stream = new MemoryStream(bytes);
                using var archive = new ZipArchive(stream, ZipArchiveMode.Read);
                var contents = new List<string>();
                foreach (ZipArchiveEntry entry in archive.Entries)
                {
                    using var reader = new StreamReader(entry.Open());
                    contents.Add(reader.ReadToEnd());
                }
                Assert.That(contents, Does.Contain(Handler));
            }
            else
            {
                Assert.That(Encoding.UTF8.GetString(bytes), Is.EqualTo(Handler));
            }
        }
    }
}
