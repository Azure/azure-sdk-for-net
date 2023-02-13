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
            Assert.IsTrue(flag);
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
            Assert.IsNotEmpty(list);
            ValidateAscLocation(list.First(item => item.Data.Name == _existAscLocationName), _existAscLocationName);
        }

        private void ValidateAscLocation(SecurityCenterLocationResource ascLocation, string ascLocationName)
        {
            Assert.IsNotNull(ascLocation);
            Assert.IsNotNull(ascLocation.Data.Id);
            Assert.AreEqual(ascLocationName, ascLocation.Data.Name);
            Assert.AreEqual("Microsoft.Security/locations", ascLocation.Data.ResourceType.ToString());
        }
    }
}
