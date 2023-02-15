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
        public async Task CreateUpdateExistGetDelete()
        {
            // CreateOrUpdate
            string dicomServiceName = Recording.GenerateAssetName("dicom");
            var dicomService = await CreateDicomService(dicomServiceName);
            ValidateDicomService(dicomService.Data, dicomServiceName);

            // Exist
            var flag = await _dicomServiceCollection.ExistsAsync(dicomServiceName);
            Assert.IsTrue(flag);

            // Get
            var getDicomService = await _dicomServiceCollection.GetAsync(dicomServiceName);
            ValidateDicomService(getDicomService.Value.Data, dicomServiceName);

            // GetAll
            var list = await _dicomServiceCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            ValidateDicomService(list.FirstOrDefault().Data, dicomServiceName);

            // Delete
            await dicomService.DeleteAsync(WaitUntil.Completed);
            flag = await _dicomServiceCollection.ExistsAsync(dicomServiceName);
            Assert.IsFalse(flag);
        }

        [TestCase(null)]
        [TestCase(false)]
        [TestCase(true)]
        public async Task AddRemoveTag(bool? useTagResource)
        {
            SetTagResourceUsage(Client, useTagResource);
            string dicomServiceName = Recording.GenerateAssetName("dicom");
            var dicomService = await CreateDicomService(dicomServiceName);

            // AddTag
            await dicomService.AddTagAsync("addtagkey", "addtagvalue");
            dicomService = await _dicomServiceCollection.GetAsync(dicomServiceName);
            Assert.AreEqual(1, dicomService.Data.Tags.Count);
            KeyValuePair<string, string> tag = dicomService.Data.Tags.Where(tag => tag.Key == "addtagkey").FirstOrDefault();
            Assert.AreEqual("addtagkey", tag.Key);
            Assert.AreEqual("addtagvalue", tag.Value);

            // RemoveTag
            await dicomService.RemoveTagAsync("addtagkey");
            dicomService = await _dicomServiceCollection.GetAsync(dicomServiceName);
            Assert.AreEqual(0, dicomService.Data.Tags.Count);
        }

        private async Task<DicomServiceResource> CreateDicomService(string dicomServiceName)
        {
            DicomServiceData data = new DicomServiceData(DefaultLocation);
            var lro = await _dicomServiceCollection.CreateOrUpdateAsync(WaitUntil.Completed, dicomServiceName, data);
            return lro.Value;
        }

        private void ValidateDicomService(DicomServiceData dicomService, string dicomServiceName)
        {
            Assert.IsNotNull(dicomService);
            Assert.AreEqual(dicomServiceName, dicomService.Id.Name);
            Assert.AreEqual(DefaultLocation, dicomService.Location);
            Assert.AreEqual("Succeeded", dicomService.ProvisioningState.ToString());
            Assert.AreEqual("Microsoft.HealthcareApis/workspaces/dicomservices", dicomService.ResourceType.ToString());
        }
    }
}
