// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.SecurityCenter.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.SecurityCenter.Tests
{
    internal class AscLocationLocationTaskTests : SecurityCenterManagementTestBase
    {
        private SecurityCenterLocationResource _ascLocationResource;
        private SubscriptionSecurityTaskCollection _subscriptionSecurityTaskCollection;
        private const string _existTaskName = "ee6dbac7-d03a-c7e6-35c6-f7de83f868d2";

        public AscLocationLocationTaskTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public async Task TestSetUp()
        {
            _ascLocationResource = await DefaultSubscription.GetSecurityCenterLocations().GetAsync("centralus");
            _subscriptionSecurityTaskCollection = _ascLocationResource.GetSubscriptionSecurityTasks();
        }

        [RecordedTest]
        public async Task Exist()
        {
            bool flag  = await _subscriptionSecurityTaskCollection.ExistsAsync(_existTaskName);
            Assert.IsTrue(flag);
        }

        [RecordedTest]
        public async Task Get()
        {
            var task = await _subscriptionSecurityTaskCollection.GetAsync(_existTaskName);
            ValidateAscLocationLocationTaskResource(task);
        }

        [RecordedTest]
        public async Task GetAll()
        {
            var list = await _subscriptionSecurityTaskCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            ValidateAscLocationLocationTaskResource(list.First(item=>item.Data.Name == _existTaskName));
        }

        private void ValidateAscLocationLocationTaskResource(SubscriptionSecurityTaskResource task)
        {
            Assert.IsNotNull(task);
            Assert.AreEqual(_existTaskName, task.Data.Name);
            Assert.AreEqual("Active", task.Data.State);
            Assert.AreEqual("NA", task.Data.SubState);
            Assert.AreEqual("Microsoft.Security/locations/centralus/tasks", task.Data.ResourceType.ToString());
        }
    }
}
