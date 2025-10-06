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
    public class IscsiPathResourceTest : AvsManagementTestBase
    {
        public IscsiPathResourceTest(bool isAsync) : base(isAsync)
        {
        }

        [TestCase, Order(1)]
        [RecordedTest]
        public async Task Create()
        {
            IscsiPathData data = new IscsiPathData()
            {
                NetworkBlock = "192.168.100.0/24",
            };
            ArmOperation<IscsiPathResource> lro = await getIscsiPathResource().CreateOrUpdateAsync(WaitUntil.Completed, data);
            IscsiPathResource result = lro.Value;
            Assert.AreEqual(result.Data.Name, ISCSI_PATH_NAME);
        }

        [TestCase, Order(2)]
        [RecordedTest]
        public async Task Get()
        {
            IscsiPathResource iscsiPath = await getIscsiPathResource().GetAsync();
            Assert.AreEqual(iscsiPath.Data.Name, ISCSI_PATH_NAME);
        }

        [TestCase, Order(3)]
        [RecordedTest]
        public async Task Delete()
        {
            ArmOperation lro =  await getIscsiPathResource().DeleteAsync(WaitUntil.Started);
        }
    }
}