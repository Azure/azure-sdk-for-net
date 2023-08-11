// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Analytics.Defender.Easm.Models;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Analytics.Defender.Easm.Tests
{
    internal class SavedFiltersTest : EasmClientTest
    {
        private string DeleteSavedFilterName;
        private string PutSavedFilterName;
        private string KnownExistingFilter;
        private string Filter;

        public SavedFiltersTest(bool isAsync) : base(isAsync)
        {
            DeleteSavedFilterName = "put_filter";
            PutSavedFilterName = "put_filter";
            KnownExistingFilter = "new_put_filter";
            Filter = $"name = \"{PutSavedFilterName}\"";
        }

        [RecordedTest]
        public async Task SavedFiltersListTest()
        {
            Response<SavedFilterPageResult> response = await client.GetSavedFiltersAsync();
            SavedFilter savedFilterResponse = response.Value.Value[0];
            Assert.IsNotNull(savedFilterResponse.Id);
            Assert.IsNotNull(savedFilterResponse.Description);
        }

        [RecordedTest]
        public async Task SavedFiltersGetTest()
        {
            Response<SavedFilter> response = await client.GetSavedFilterAsync(KnownExistingFilter);
            SavedFilter savedFilter = response.Value;
            Assert.IsNotNull(savedFilter.Name);
        }

        [RecordedTest]
        public async Task SavedFiltersPutTest()
        {
            SavedFilterData savedFilterRequest = new SavedFilterData(Filter, "Sample description");
            Response<SavedFilter> response = await client.PutSavedFilterAsync(PutSavedFilterName, savedFilterRequest);
            SavedFilter savedFilterResponse = response.Value;
            Assert.AreEqual(PutSavedFilterName, savedFilterResponse.Name);
            Assert.AreEqual(PutSavedFilterName, savedFilterResponse.Id);
            Assert.AreEqual(PutSavedFilterName, savedFilterResponse.DisplayName);
            Assert.AreEqual(savedFilterRequest.Description, savedFilterResponse.Description);
        }

        [RecordedTest]
        public async Task SavedFiltersDeleteTest()
        {
            Response response = await client.DeleteSavedFilterAsync(DeleteSavedFilterName);
            Assert.AreEqual(204, response.Status);
        }
    }
}
