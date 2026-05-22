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
    internal class SecureScoreTests : SecurityCenterManagementTestBase
    {
        private SecureScoreCollection _secureScoreItemCollection => DefaultSubscription.GetSecureScores();
        private const string _existSecureScoreItemName = "ascScore";

        public SecureScoreTests(bool isAsync) : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public void TestSetUp()
        {
        }

        [RecordedTest]
        public async Task Exist()
        {
            bool flag = await _secureScoreItemCollection.ExistsAsync(_existSecureScoreItemName);
            Assert.IsTrue(flag);
        }

        [RecordedTest]
        public async Task Get()
        {
            var secureScoreItem = await _secureScoreItemCollection.GetAsync(_existSecureScoreItemName);
            ValidateSecureScoreItem(secureScoreItem);
        }

        [RecordedTest]
        public async Task GetAll()
        {
            var list = await _secureScoreItemCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            ValidateSecureScoreItem(list.First(item => item.Data.Name == _existSecureScoreItemName));
        }

        private void ValidateSecureScoreItem(SecureScoreResource secureScoreItem)
        {
            Assert.IsNotNull(secureScoreItem);
            Assert.IsNotNull(secureScoreItem.Data.Id);
            Assert.AreEqual(_existSecureScoreItemName, secureScoreItem.Data.Name);
            Assert.AreEqual("ASC score", secureScoreItem.Data.DisplayName);
            Assert.AreEqual("Microsoft.Security/secureScores", secureScoreItem.Data.ResourceType.ToString());
        }
    }
}
