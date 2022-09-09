// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.LoadTestService.Tests.Helpers;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.LoadTestService.Tests
{
    public class LoadTestResourceOperations : LoadTestServiceManagementTestBase
    {
        private LoadTestResourceCollection _loadTestResourceCollection { get; set; }
        private LoadTestResource _loadTestResource { get; set; }
        private LoadTestResourceData _loadTestResourceData { get; set; }

        public LoadTestResourceOperations(bool isAsync) : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public async Task ClearAndInitialize()
        {
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                await CreateCommonClient();
            }
            var resourceGroupName = Recording.GenerateAssetName("SdkRg");
            await LoadTestResourceHelper.TryRegisterResourceGroupAsync(ResourceGroupsOperations, LoadTestResourceHelper.DefaultResourceLocation, resourceGroupName);
            var loadTestResourceName = Recording.GenerateAssetName("SdkLoadTestService");
            _loadTestResourceCollection = (await GetResourceGroupAsync(resourceGroupName)).GetLoadTestResources();
            _loadTestResourceData = new LoadTestResourceData(LoadTestResourceHelper.DefaultResourceLocation);
        }

        [OneTimeTearDown]
        public void Cleanup()
        {
            CleanupResourceGroups();
        }

        [RecordedTest]
        [AsyncOnly]
        public async Task LoadTestResourceOperationTests()
        {
            var loadTestResourceName = Recording.GenerateAssetName("SdkLoadTestService");

            //// Create
            ArmOperation<LoadTestResource> loadTestCreateResponse = await _loadTestResourceCollection.CreateOrUpdateAsync(WaitUntil.Completed, loadTestResourceName, _loadTestResourceData);
            await loadTestCreateResponse.WaitForCompletionAsync();
            Assert.IsTrue(loadTestCreateResponse.HasCompleted);
            Assert.IsTrue(loadTestCreateResponse.HasValue);

            //// Get
            Response<LoadTestResource> loadTestGetResponse = await _loadTestResourceCollection.GetAsync(loadTestResourceName);
            LoadTestResource loadTestGetResponseValue = loadTestGetResponse.Value;
            Assert.IsNotNull(loadTestGetResponseValue);
            Assert.AreEqual(loadTestResourceName, loadTestGetResponseValue.Data.Name);

            //// Delete
            var loadTestDeleteResponse = await loadTestGetResponseValue.DeleteAsync(WaitUntil.Completed);
            await loadTestDeleteResponse.WaitForCompletionResponseAsync();
            Assert.IsTrue(loadTestDeleteResponse.HasCompleted);
        }
    }
}
