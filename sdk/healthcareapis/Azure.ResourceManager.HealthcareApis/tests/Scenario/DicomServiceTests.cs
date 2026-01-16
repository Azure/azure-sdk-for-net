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
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.HealthcareApis.Tests
{
    internal class DicomServiceTests : HealthcareApisManagementTestBase
    {
        private DicomServiceCollection _dicomServiceCollection;
        private const string _dicomServiceNamePrefix = "dicom";

        public DicomServiceTests(bool isAsync) : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public async Task SetUp()
        {
            var resourceGroup = await CreateResourceGroup();
            var workspace = await CreateHealthcareApisWorkspace(resourceGroup, Recording.GenerateAssetName("workspace"));
            _dicomServiceCollection = workspace.GetDicomServices();
        }

        [RecordedTest]
        public async Task CreateOrUpdateExistGetGetAllDelete()
        {
            // CreateOrUpdate
            string dicomServiceName = Recording.GenerateAssetName(_dicomServiceNamePrefix);
            var dicomService = await CreateDicomService(dicomServiceName);
            ValidateDicomService(dicomService.Data, dicomServiceName);

            // Exist
            var flag = await _dicomServiceCollection.ExistsAsync(dicomServiceName);
            Assert.That((bool)flag, Is.True);

            // Get
            var getDicomService = await _dicomServiceCollection.GetAsync(dicomServiceName);
            ValidateDicomService(getDicomService.Value.Data, dicomServiceName);

            // GetAll
            var list = await _dicomServiceCollection.GetAllAsync().ToEnumerableAsync();
            Assert.That(list, Is.Not.Empty);
            ValidateDicomService(list.FirstOrDefault().Data, dicomServiceName);

            // Delete
            await dicomService.DeleteAsync(WaitUntil.Completed);
            flag = await _dicomServiceCollection.ExistsAsync(dicomServiceName);
            Assert.That((bool)flag, Is.False);
        }

        [TestCase(null)]
        [TestCase(false)]
        [TestCase(true)]
        public async Task AddRemoveTag(bool? useTagResource)
        {
            SetTagResourceUsage(Client, useTagResource);
            string dicomServiceName = Recording.GenerateAssetName(_dicomServiceNamePrefix);
            var dicomService = await CreateDicomService(dicomServiceName);

            // AddTag
            await dicomService.AddTagAsync("addtagkey", "addtagvalue");
            dicomService = await _dicomServiceCollection.GetAsync(dicomServiceName);
            Assert.That(dicomService.Data.Tags.Count, Is.EqualTo(1));
            KeyValuePair<string, string> tag = dicomService.Data.Tags.Where(tag => tag.Key == "addtagkey").FirstOrDefault();
            Assert.That(tag.Key, Is.EqualTo("addtagkey"));
            Assert.That(tag.Value, Is.EqualTo("addtagvalue"));

            // RemoveTag
            await dicomService.RemoveTagAsync("addtagkey");
            dicomService = await _dicomServiceCollection.GetAsync(dicomServiceName);
            Assert.That(dicomService.Data.Tags.Count, Is.EqualTo(0));
        }

        private async Task<DicomServiceResource> CreateDicomService(string dicomServiceName)
        {
            DicomServiceData data = new DicomServiceData(DefaultLocation);
            var lro = await _dicomServiceCollection.CreateOrUpdateAsync(WaitUntil.Completed, dicomServiceName, data);
            return lro.Value;
        }

        private void ValidateDicomService(DicomServiceData dicomService, string dicomServiceName)
        {
            Assert.That(dicomService, Is.Not.Null);
            Assert.That(dicomService.Id.Name, Is.EqualTo(dicomServiceName));
            Assert.That(dicomService.Location, Is.EqualTo(DefaultLocation));
            Assert.That(dicomService.ProvisioningState.ToString(), Is.EqualTo("Succeeded"));
            Assert.That(dicomService.ResourceType.ToString(), Is.EqualTo("Microsoft.HealthcareApis/workspaces/dicomservices"));
        }
    }
}
