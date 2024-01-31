// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Subscription.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Subscription.Tests
{
    internal class SubscriptionExtensionTests : SubscriptionManagementTestBase
    {
        private SubscriptionResource _subscription;

        public SubscriptionExtensionTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public async Task TestSetUp()
        {
            _subscription = await Client.GetDefaultSubscriptionAsync();
        }

        [RecordedTest]
        public async Task GetLocationsSubscriptions()
        {
            var list = await _subscription.GetLocationsAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            Assert.IsNotNull(list.First(item => item.Name == "eastus"));
        }

        [RecordedTest]
        public async Task PredefinedTagOperations()
        {
            // CreateOrUpdate
            string tagName = "testEmptyTag";
            var predefinedTag = await _subscription.CreateOrUpdatePredefinedTagAsync(tagName);
            Assert.IsNotNull(predefinedTag);
            Assert.AreEqual(tagName, predefinedTag.Value.TagName);

            // GetAll
            var list = await _subscription.GetAllPredefinedTagsAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            Assert.IsNotNull(list.First(item => item.TagName == tagName));

            // Delete
            var deleteResponse = await _subscription.DeletePredefinedTagAsync(tagName);
            Assert.AreEqual(200, deleteResponse.Status);
        }

        [RecordedTest]
        public async Task PredefinedTagValueOperations()
        {
            string tagName = "testTag";
            await _subscription.CreateOrUpdatePredefinedTagAsync(tagName);

            // Add a TagValue
            string tagValue = "preTestValue";
            var predefinedTagValue = await _subscription.CreateOrUpdatePredefinedTagValueAsync(tagName, tagValue);
            Assert.IsNotNull(predefinedTagValue);
            Assert.AreEqual(tagValue, predefinedTagValue.Value.TagValue);

            // Delete a TagValue
            var deleteResponse1 = await _subscription.CreateOrUpdatePredefinedTagValueAsync(tagName, tagValue);
            Assert.AreEqual(200, deleteResponse1.GetRawResponse().Status);

            // Delete--409 Please delete all the associated tag values before deleting the tag name.
            //var deleteResponse = await _subscription.DeletePredefinedTagAsync(tagName);
            //Assert.AreEqual(200, deleteResponse.Status);
        }

        [RecordedTest]
        public async Task GetFeatures()
        {
            var list  = await _subscription.GetFeaturesAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
        }

        [RecordedTest]
        [PlaybackOnly("Dangerous operations")]
        public async Task CancelSubscription()
        {
            var response = await _subscription.CancelSubscriptionAsync();
            Assert.AreEqual(200,response.GetRawResponse().Status);
        }

        [RecordedTest]
        [PlaybackOnly("Dangerous operations")]
        public async Task RenameSubscription()
        {
            SubscriptionName data = new SubscriptionName()
            {
                SubscriptionNameValue = "azSubscriptionTestName"
            };
            var response = await _subscription.RenameSubscriptionAsync(data);
            Assert.AreEqual(200,response.GetRawResponse().Status);
        }

        [RecordedTest]
        [Ignore("400. NotAllowed. Reactivation is not supported for subscription")]
        public async Task EnableSubscription()
        {
            var response = await _subscription.EnableSubscriptionAsync();
            Assert.AreEqual(200,response.GetRawResponse().Status);
        }
    }
}
