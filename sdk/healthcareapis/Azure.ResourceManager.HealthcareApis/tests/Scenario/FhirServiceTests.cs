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
        public async Task CreateOrUpdateExistGetGetAllDelete()
        {
            // CreateOrUpdate
            string fhirServiceName = Recording.GenerateAssetName(fhirServicePrefixName);
            var fhirService = await CreateFhirService(_workspace, fhirServiceName);
            ValidateFhirService(fhirService.Data, fhirServiceName);

            // Exist
            var flag = await _fhirServiceCollection.ExistsAsync(fhirServiceName);
            Assert.That((bool)flag, Is.True);

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
            Assert.That((bool)flag, Is.False);
        }

        [TestCase(null)]
        [TestCase(false)]
        [TestCase(true)]
        public async Task AddRemoveTag(bool? useTagResource)
        {
            SetTagResourceUsage(Client, useTagResource);
            string fhirServiceName = Recording.GenerateAssetName(fhirServicePrefixName);
            var fhirService = await CreateFhirService(_workspace, fhirServiceName);

            // AddTag
            await fhirService.AddTagAsync("addtagkey", "addtagvalue");
            fhirService = await _fhirServiceCollection.GetAsync(fhirServiceName);
            Assert.That(fhirService.Data.Tags.Count, Is.EqualTo(1));
            KeyValuePair<string, string> tag = fhirService.Data.Tags.Where(tag => tag.Key == "addtagkey").FirstOrDefault();
            Assert.That(tag.Key, Is.EqualTo("addtagkey"));
            Assert.That(tag.Value, Is.EqualTo("addtagvalue"));

            // RemoveTag
            await fhirService.RemoveTagAsync("addtagkey");
            fhirService = await _fhirServiceCollection.GetAsync(fhirServiceName);
            Assert.That(fhirService.Data.Tags.Count, Is.EqualTo(0));
        }

        private void ValidateFhirService(FhirServiceData fhirService, string fhirServiceName)
        {
            Assert.IsNotNull(fhirService);
            Assert.IsNotNull(fhirService.ETag);
            Assert.That(fhirService.Id.Name, Is.EqualTo(fhirServiceName));
            Assert.That(fhirService.Kind.ToString(), Is.EqualTo("fhir-R4"));
            Assert.That(fhirService.Location, Is.EqualTo(DefaultLocation));
            Assert.That(fhirService.ProvisioningState.ToString(), Is.EqualTo("Succeeded"));
            Assert.That(fhirService.PublicNetworkAccess.ToString(), Is.EqualTo("Enabled"));
            Assert.That(fhirService.ResourceType.ToString(), Is.EqualTo("Microsoft.HealthcareApis/workspaces/fhirservices"));
            Assert.That(fhirService.ResourceVersionPolicyConfiguration.Default.ToString(), Is.EqualTo("no-version"));
        }
    }
}
