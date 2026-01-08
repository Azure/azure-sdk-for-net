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
            Assert.That(flag, Is.True);
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
            Assert.That(list, Is.Not.Empty);
            ValidateAscLocationLocationTaskResource(list.First(item=>item.Data.Name == _existTaskName));
        }

        private void ValidateAscLocationLocationTaskResource(SubscriptionSecurityTaskResource task)
        {
            Assert.That(task, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(task.Data.Name, Is.EqualTo(_existTaskName));
                Assert.That(task.Data.State, Is.EqualTo("Active"));
                Assert.That(task.Data.SubState, Is.EqualTo("NA"));
                Assert.That(task.Data.ResourceType.ToString(), Is.EqualTo("Microsoft.Security/locations/centralus/tasks"));
            });
        }
    }
}
