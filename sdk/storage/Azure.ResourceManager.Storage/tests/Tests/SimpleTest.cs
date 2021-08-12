// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;
using Azure.ResourceManager.Storage.Tests.Tests.Helpers;
namespace Azure.ResourceManager.Storage.Tests
{
    [TestFixture(true)]
    public class SimpleTest:StorageTestBase
    {
        public SimpleTest(bool async) : base(async)
        {
        }

        [Test]
        [RecordedTest]
        public async Task simpletest(){
            int a = 0;
            var b=TestEnvironment;
            List<ResourceGroup> re= await getAllResourceGroupAsync();
            foreach (ResourceGroup group in re)
            {
                List<StorageAccount> accounts=await group.GetStorageAccounts().GetAllAsync().ToEnumerableAsync();
                foreach (StorageAccount account in accounts)
                {
                    Console.WriteLine("account name: "+group.Id.Name+"   "+account.Id.Name);
                }
            }
            a++;
        }
    }
}
