// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Avs.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Avs.Tests.Scenario
{
    public class AvsHostTest : AvsManagementTestBase
    {
        public AvsHostTest(bool isAsync) : base(isAsync)
        {
        }

        [TestCase, Order(1)]
        [RecordedTest]
        public async Task Get_AvsHostsResource()
        {
            AvsHostResource avsHost = await getAvsHostResource().GetAsync();
            Assert.That(avsHost.Data.Name, Is.EqualTo(HOST_ID));
        }
        [TestCase, Order(2)]
        [RecordedTest]
        public async Task Get_AvsHostsCollection()
        {
            AvsHostResource result = await getAvsHostCollection().GetAsync(HOST_ID);
            Assert.That(result.Data.Name, Is.EqualTo(HOST_ID));
        }

        [TestCase, Order(3)]
        [RecordedTest]
        public async Task List()
        {
            AvsHostCollection avsHostCollection = getAvsHostCollection();
            var hosts = new List<AvsHostResource>();

            await foreach (AvsHostResource item in avsHostCollection.GetAllAsync())
            {
                AvsHostData resourceData = item.Data;
                hosts.Add(item);
            }

            Assert.Multiple(() =>
            {
                Assert.That(hosts.Any(), Is.True);
                Assert.That(hosts.Any(h => h.Data.Name == HOST_ID), Is.True);
                Assert.That(hosts, Has.Count.EqualTo(3));
            });
        }

        [TestCase, Order(4)]
        [RecordedTest]
        public async Task GetIfExists_Hosts()
        {
            bool exists = await getAvsHostCollection().ExistsAsync(HOST_ID);
            Assert.That(exists, Is.True);
        }
    }
}
