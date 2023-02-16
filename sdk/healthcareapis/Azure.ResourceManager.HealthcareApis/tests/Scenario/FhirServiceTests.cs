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
        private string _workspaceName;
        private const string fhirServicePrefixName = "fhir";
        private FhirServiceCollection _fhirServiceCollection;

        public FhirServiceTests(bool isAsync) : base(isAsync, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public async Task SetUp()
        {
            var resourceGroup = await CreateResourceGroup();
            _workspaceName = Recording.GenerateAssetName("workspace");
            var workspace = await CreateHealthcareApisWorkspace(resourceGroup, _workspaceName);
            _fhirServiceCollection = workspace.GetFhirServices();
        }

        [RecordedTest]
        public async Task CreateUpdateExistGetDelete()
        {
            // Create
            string fhirServiceName = Recording.GenerateAssetName(fhirServicePrefixName);
            var fhirService = await CreateFhirService(fhirServiceName);
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
        public async Task AddRemoveTag(bool? useTagResource)
        {
            SetTagResourceUsage(Client, useTagResource);
            string fhirServiceName = Recording.GenerateAssetName(fhirServicePrefixName);
            var fhirService = await CreateFhirService(fhirServiceName);

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

        private async Task<FhirServiceResource> CreateFhirService(string fhirServiceName)
        {
            FhirServiceData data = new FhirServiceData(DefaultLocation)
            {
                Kind = "fhir-R4",
                AuthenticationConfiguration = new FhirServiceAuthenticationConfiguration()
                {
                    Authority = $"https://login.microsoftonline.com/{Environment.GetEnvironmentVariable("TENANT_ID")}",
                    Audience = $"https://{_workspaceName}-{fhirServiceName}.fhir.azurehealthcareapis.com"
                },
                ImportConfiguration = new FhirServiceImportConfiguration()
                {
                    IsEnabled = false,
                    IsInitialImportMode = false,
                },
                ResourceVersionPolicyConfiguration = new FhirServiceResourceVersionPolicyConfiguration()
                {
                    Default = "no-version",
                }
            };
            var lro = await _fhirServiceCollection.CreateOrUpdateAsync(WaitUntil.Completed, fhirServiceName, data);
            return lro.Value;
        }

        private void ValidateFhirService(FhirServiceData fhirService, string fhirServiceName)
        {
            Assert.IsNotNull(fhirService);
        }
    }
}
