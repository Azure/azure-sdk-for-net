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
    internal class AscLocationTests : SecurityCenterManagementTestBase
    {
        private SecurityCenterLocationCollection _ascLocationCollection => DefaultSubscription.GetSecurityCenterLocations();
        private const string _existAscLocationName = "centralus";

        public AscLocationTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public void TestSetUp()
        {
        }

        [RecordedTest]
        public async Task Exist()
        {
            bool flag = await _ascLocationCollection.ExistsAsync(_existAscLocationName);
            Assert.That(flag, Is.True);
        }

        [RecordedTest]
        public async Task Get()
        {
            var ascLocation = await _ascLocationCollection.GetAsync(_existAscLocationName);
            ValidateAscLocation(ascLocation, _existAscLocationName);
        }

        [RecordedTest]
        public async Task GetAll()
        {
            var list = await _ascLocationCollection.GetAllAsync().ToEnumerableAsync();
            Assert.That(list, Is.Not.Empty);
            ValidateAscLocation(list.First(item => item.Data.Name == _existAscLocationName), _existAscLocationName);
        }

        private void ValidateAscLocation(SecurityCenterLocationResource ascLocation, string ascLocationName)
        {
            Assert.That(ascLocation, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(ascLocation.Data.Id, Is.Not.Null);
                Assert.That(ascLocation.Data.Name, Is.EqualTo(ascLocationName));
                Assert.That(ascLocation.Data.ResourceType.ToString(), Is.EqualTo("Microsoft.Security/locations"));
            });
        }
    }
}
