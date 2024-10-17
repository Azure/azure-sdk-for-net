// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;
using Azure.ResourceManager.IoTOperations;

namespace Azure.ResourceManager.IotOperations.Tests
{
    public class IoTOperationsManagementTests : IoTOperationsManagementTestBase
    {
        public IoTOperationsManagementTests(bool isAsync)
            : base(isAsync)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task GetInstanceNameTest()
        {
            // FILL IN CLUSTER VARIABLES HERES
            // CLUSTER MUST BE ARC ENABLED, WITH AIO DEPLOYED
            var subId = "d4ccd08b-0809-446d-a8b7-7af8a90109cd";
            var rg = "mitch-bb-2-103545027";
            var instanceName = "aio-zk3mr";
            Console.WriteLine("Starting the instance name test");

            // Call the Get method on InstanceResource using generated MGMT API
            var instanceResourceId = InstanceResource.CreateResourceIdentifier(subId, rg, instanceName);
            var instanceResource = Client.GetInstanceResource(instanceResourceId);

            // Retrieve the instance resource
            Response<InstanceResource> response = await instanceResource.GetAsync();
            InstanceResource instance = response.Value;

            // Use the instance resource as needed
            Console.WriteLine($"Instance Name: {instance.Data.Name}");
            Console.WriteLine($"Expected Instance Name: {instanceName}");
            Assert.AreEqual(instanceName, instance.Data.Name);
        }
    }
}
