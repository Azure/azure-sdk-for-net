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

        // [TestCase, Order(1)]
        // [RecordedTest]
        // public async Task Get()
        // {
        //     var iscsiPathResource = await getIscsiPathResource();
        //     Assert.AreEqual(iscsiPathResource.Data.Name, ISCSI_PATH_NAME);
        // }

        // [TestCase, Order(2)]
        // [RecordedTest]
        // public async Task Update()
        // {
        //     var newNetwork = "192.168.0.0/24";
        //     var iscsiPathResource = await getIscsiPathResource();
        //       IscsiPathData data = new IscsiPathData()
        //     {
        //         NetworkBlock = newNetwork
        //     };
        //     ArmOperation<IscsiPathResource> lro = await iscsiPathResource.CreateOrUpdateAsync(WaitUntil.Completed, data);
        //     Assert.AreEqual( lro.Value.Data.NetworkBlock, newNetwork);
        // }

        // [TestCase, Order(3)]
        // [RecordedTest]
        // public async Task Delete()
        // {
        //     var iscsiPathResource = await getIscsiPathResource();
        //     ArmOperation lro =  await iscsiPathResource.DeleteAsync(WaitUntil.Started);
        // }
    }
}
