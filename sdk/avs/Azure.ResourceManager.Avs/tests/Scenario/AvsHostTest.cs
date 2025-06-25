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
        public async Task Get_AvsHost()
        {
            AvsHostResource avsHost = await getAvsHostResource().GetAsync();
            Assert.AreEqual(avsHost.Data.Name, HOST_ID);
        }

        [TestCase, Order(2)]
        [RecordedTest]
        public async Task Get_List()
        {
            AvsHostCollection avsHostCollection = await getAvsHostCollection().GetAsync();
            var hosts = new List<AvsHostResource>();

            await foreach (AvsHostResource item in avsHostCollection.GetAllAsync())
            {
                AvsHostData resourceData = item.Data;
                hosts.Add(item);
            }
            Assert.IsTrue(hosts.Any());
            Assert.IsTrue(hosts.Any(h => h.Data.Name == HOST_ID));
            Assert.AreEqual(hosts.Count, 3);
        }

        [TestCase, Order(3)]
        [RecordedTest]
        public async Task GetIfExists_HostsGet()
        {
            AvsHostCollection avsHostCollection = await getAvsHostCollection().ExistsAsync(HOST_ID);
            Assert.IsTrue(avsHostCollection);
        }
    }
}