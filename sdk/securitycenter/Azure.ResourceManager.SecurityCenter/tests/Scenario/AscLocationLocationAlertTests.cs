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
    internal class AscLocationLocationAlertTests : SecurityCenterManagementTestBase
    {
        private SecurityCenterLocationResource _ascLocationResource;
        private SubscriptionSecurityAlertCollection _subscriptionSecurityAlertCollection;
        private const string _existAlertName = "2517370881989999999_7d56ae12-07f3-4f0a-8406-97650a437505";

        public AscLocationLocationAlertTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public async Task TestSetUp()
        {
            _ascLocationResource = await DefaultSubscription.GetSecurityCenterLocations().GetAsync("centralus");
            _subscriptionSecurityAlertCollection = _ascLocationResource.GetSubscriptionSecurityAlerts();
        }

        [RecordedTest]
        public async Task Exist()
        {
            bool flag = await _subscriptionSecurityAlertCollection.ExistsAsync(_existAlertName);
            Assert.That(flag, Is.True);
        }

        [RecordedTest]
        public async Task Get()
        {
            var alert = await _subscriptionSecurityAlertCollection.GetAsync(_existAlertName);
            ValidateAscLocationLocationAlert(alert);
        }

        [RecordedTest]
        public async Task GetAll()
        {
            var list = await _subscriptionSecurityAlertCollection.GetAllAsync().ToEnumerableAsync();
            Assert.That(list, Is.Not.Empty);
            ValidateAscLocationLocationAlert(list.First(item => item.Data.Name == _existAlertName));
        }

        private void ValidateAscLocationLocationAlert(SubscriptionSecurityAlertResource alert)
        {
            Assert.That(alert, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(alert.Data.Id, Is.Not.Null);
                Assert.That(alert.Data.AlertDisplayName, Is.Not.Null);
                Assert.That(alert.Data.AlertType, Is.Not.Null);
                Assert.That(alert.Data.AlertUri, Is.Not.Null);
                Assert.That(alert.Data.Name, Is.EqualTo(_existAlertName));
                Assert.That(alert.Data.ResourceType.ToString(), Is.EqualTo("Microsoft.Security/Locations/alerts"));
            });
        }
    }
}
