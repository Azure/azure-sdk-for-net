// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.HealthcareApis.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.HealthcareApis.Tests
{
    internal class FhirServiceTests : HealthcareApisManagementTestBase
    {
        private const string fhirServicePrefixName = "fhir";
        private HealthcareApisWorkspaceResource _workspace;
        private FhirServiceCollection _fhirServiceCollection;

        public FhirServiceTests(bool isAsync) : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public async Task SetUp()
        {
            var resourceGroup = await CreateResourceGroup();
            _workspace = await CreateHealthcareApisWorkspace(resourceGroup, Recording.GenerateAssetName("workspace"));
            _fhirServiceCollection = _workspace.GetFhirServices();
        }

        [RecordedTest]
        [Ignore("Pipeline playback error")]
        public async Task CreateOrUpdateExistGetGetAllDelete()
        {
            // CreateOrUpdate
            string fhirServiceName = Recording.GenerateAssetName(fhirServicePrefixName);
            var fhirService = await CreateFhirService(_workspace, fhirServiceName);
            ValidateFhirService(fhirService.Data, fhirServiceName);

            // Exist
            var flag = await _fhirServiceCollection.ExistsAsync(fhirServiceName);
            Assert.IsTrue(flag);

            // Get
            var getFhirService = await _fhirServiceCollection.GetAsync(fhirServiceName);
            ValidateFhirService(getFhirService.Value.Data, fhirServiceName);

            // GetAll
            var list = await _fhirServiceCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            ValidateFhirService(list.FirstOrDefault().Data, fhirServiceName);

            // Delete
            await fhirService.DeleteAsync(WaitUntil.Completed);
            flag = await _fhirServiceCollection.ExistsAsync(fhirServiceName);
            Assert.IsFalse(flag);
        }

        [TestCase(null)]
        [TestCase(false)]
        [TestCase(true)]
        [Ignore("Pipeline playback error")]
        public async Task AddRemoveTag(bool? useTagResource)
        {
            SetTagResourceUsage(Client, useTagResource);
            string fhirServiceName = Recording.GenerateAssetName(fhirServicePrefixName);
            var fhirService = await CreateFhirService(_workspace, fhirServiceName);

            // AddTag
            await fhirService.AddTagAsync("addtagkey", "addtagvalue");
            fhirService = await _fhirServiceCollection.GetAsync(fhirServiceName);
            Assert.AreEqual(1, fhirService.Data.Tags.Count);
            KeyValuePair<string, string> tag = fhirService.Data.Tags.Where(tag => tag.Key == "addtagkey").FirstOrDefault();
            Assert.AreEqual("addtagkey", tag.Key);
            Assert.AreEqual("addtagvalue", tag.Value);

            // RemoveTag
            await fhirService.RemoveTagAsync("addtagkey");
            fhirService = await _fhirServiceCollection.GetAsync(fhirServiceName);
            Assert.AreEqual(0, fhirService.Data.Tags.Count);
        }

        private void ValidateFhirService(FhirServiceData fhirService, string fhirServiceName)
        {
            Assert.IsNotNull(fhirService);
            Assert.IsNotNull(fhirService.ETag);
            Assert.AreEqual(fhirServiceName, fhirService.Id.Name);
            Assert.AreEqual("fhir-R4", fhirService.Kind.ToString());
            Assert.AreEqual(DefaultLocation, fhirService.Location);
            Assert.AreEqual("Succeeded", fhirService.ProvisioningState.ToString());
            Assert.AreEqual("Enabled", fhirService.PublicNetworkAccess.ToString());
            Assert.AreEqual("Microsoft.HealthcareApis/workspaces/fhirservices", fhirService.ResourceType.ToString());
            Assert.AreEqual("no-version", fhirService.ResourceVersionPolicyConfiguration.Default.ToString());
        }
    }
}
