// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.FrontDoor.Models;
using Azure.ResourceManager.FrontDoor.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.FrontDoor.Tests.TestCase
{
    public class FrontDoorResourceTests : FrontDoorManagementTestBase
    {
        public FrontDoorResourceTests(bool isAsync)
            : base(isAsync, RecordedTestMode.Record)
        {
        }

        private async Task<FrontDoorResource> CreateAccountResourceAsync(string doorName)
        {
            var collection = (await CreateResourceGroupAsync()).GetFrontDoors();
            var input = ResourceDataHelpers.GetFrontDoorData(DefaultLocation);
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, doorName, input);
            return lro.Value;
        }

        [TestCase]
        public async Task FrontDoorResourceApiTests()
        {
            //1.Get
            var doorName = Recording.GenerateAssetName("testaccount");
            var door1 = await CreateAccountResourceAsync(doorName);
            FrontDoorResource door2 = await door1.GetAsync();

            ResourceDataHelpers.AssertFrontDoor(door1.Data, door2.Data);
            //2.Delete
            await door1.DeleteAsync(WaitUntil.Completed);
        }
    }
}
