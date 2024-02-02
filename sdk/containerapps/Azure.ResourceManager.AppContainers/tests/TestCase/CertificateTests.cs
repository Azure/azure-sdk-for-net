﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Core;
using Azure.ResourceManager.Resources;
using NUnit.Framework;
using Azure.ResourceManager.AppContainers.Models;
using Azure.ResourceManager.AppContainers.Tests.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Azure.ResourceManager.AppContainers.Tests
{
    public class CertificateTests : AppContainersManagementTestBase
    {
        public CertificateTests(bool isAsync)
            : base(isAsync, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        [Ignore("Custom Domian peermisssion missing")]
        public async Task CreateOrUpdate()
        {
            string envName = Recording.GenerateAssetName("env");
            string name = Recording.GenerateAssetName("certificate");
            string name2 = Recording.GenerateAssetName("certificate");
            string name3 = Recording.GenerateAssetName("certificate");
            ResourceGroupResource rg = await CreateResourceGroupAsync();
            var envdata = ResourceDataHelpers.GetManagedEnvironmentData();

            var containerAppManagedEnvironmentCollection = rg.GetContainerAppManagedEnvironments();
            var envResource_lro = await containerAppManagedEnvironmentCollection.CreateOrUpdateAsync(WaitUntil.Completed, envName, envdata);
            var envResource = envResource_lro.Value;

            //1.Create
            var data = ResourceDataHelpers.GetManagedCertificateData();
            var collection = envResource.GetContainerAppManagedCertificates();
            var resource_lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, data);
            var resource = resource_lro.Value;
            Assert.AreEqual(name, resource.Data.Name);
            //2.Get
            var resource2 = await resource.GetAsync();
            ResourceDataHelpers.AssertCertificateData(resource.Data, resource2.Value.Data);
            //3.GetAll
            _ = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, data);
            _ = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name2, data);
            _ = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name3, data);
            int count = 0;
            await foreach (var num in collection.GetAllAsync())
            {
                count++;
            }
            Assert.GreaterOrEqual(count, 3);
            //4.Exists
            Assert.IsTrue(await collection.ExistsAsync(name));
            Assert.IsFalse(await collection.ExistsAsync(name + "1"));

            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await collection.ExistsAsync(null));
            //Resource
            //5.Get
            var resource3 = await resource.GetAsync();
            ResourceDataHelpers.AssertCertificateData(resource.Data, resource3.Value.Data);
            //6.Delete
            await resource.DeleteAsync(WaitUntil.Completed);
        }
    }
}
