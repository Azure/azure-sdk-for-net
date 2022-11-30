// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using System.Net.Http;
using Azure.Core.Pipeline;
using System.Net;
using NUnit.Framework;

namespace Azure.IoT.DeviceUpdate.Tests
{
    public class DeviceManagementClientTest: RecordedTestBase<DeviceUpdateClientTestEnvironment>
    {
        public DeviceManagementClientTest(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task GetDevices()
        {
            DeviceManagementClient client = CreateClient();
            AsyncPageable<BinaryData> response = client.GetDevicesAsync();
            int counter = 0;
            await foreach (var item in response)
            {
                Assert.IsNotNull(item);
                counter++;
            }

            Assert.IsTrue(counter > 0);
        }

        [RecordedTest]
        public async Task GetDevice_NotFound()
        {
            DeviceManagementClient client = CreateClient();
            try
            {
                await client.GetDeviceAsync("foo");
            }
            catch (RequestFailedException e)
            {
                Assert.AreEqual((int)HttpStatusCode.NotFound, e.Status);
            }
        }

        [RecordedTest]
        public async Task GetGroups()
        {
            DeviceManagementClient client = CreateClient();
            AsyncPageable<BinaryData> response = client.GetGroupsAsync();
            int counter = 0;
            await foreach (var item in response)
            {
                System.Diagnostics.Debug.WriteLine(item);
                Assert.IsNotNull(item);
                counter++;
            }

            Assert.IsTrue(counter > 0);
        }

        [RecordedTest]
        public async Task GetGroup()
        {
            DeviceManagementClient client = CreateClient();
            Response response = await client.GetGroupAsync(TestEnvironment.DeviceGroup);
            Assert.IsNotNull(response.Content);
        }

        [RecordedTest]
        public async Task GetGroup_NotFound()
        {
            DeviceManagementClient client = CreateClient();
            try
            {
                await client.GetGroupAsync("foo-bar-dpokluda-completely-fake");
                Assert.Fail("NotFound response expected");
            }
            catch (RequestFailedException e)
            {
                Assert.AreEqual((int)HttpStatusCode.NotFound, e.Status);
            }
        }

        [RecordedTest]
        public async Task GetDeviceClasses()
        {
            DeviceManagementClient client = CreateClient();
            AsyncPageable<BinaryData> response = client.GetDeviceClassesAsync();
            int counter = 0;
            await foreach (var item in response)
            {
                Assert.IsNotNull(item);
                counter++;
            }

            Assert.IsTrue(counter > 0);
        }

        [RecordedTest]
        public async Task GetDeviceClass_NotFound()
        {
            DeviceManagementClient client = CreateClient();
            try
            {
                await client.GetDeviceClassAsync("foo");
                Assert.Fail("NotFound response expected");
            }
            catch (RequestFailedException e)
            {
                Assert.AreEqual((int)HttpStatusCode.NotFound, e.Status);
            }
        }

        [RecordedTest]
        public async Task GetBestUpdatesForGroups()
        {
            DeviceManagementClient client = CreateClient();
            AsyncPageable<BinaryData> response = client.GetBestUpdatesForGroupsAsync(TestEnvironment.DeviceGroup);
            int counter = 0;
            await foreach (var item in response)
            {
                Assert.IsNotNull(item);
                counter++;
            }

            Assert.IsTrue(counter > 0);
        }

        [RecordedTest]
        public async Task GetBestUpdatesForGroups_NotFound()
        {
            DeviceManagementClient client = CreateClient();
            try
            {
                AsyncPageable<BinaryData> response = client.GetBestUpdatesForGroupsAsync("foo");
                await foreach (var _ in response)
                {
                    Assert.Fail("NotFound response expected");
                }
            }
            catch (RequestFailedException e)
            {
                Assert.AreEqual((int)HttpStatusCode.NotFound, e.Status);
            }
        }

        //  Temporary disabled because the service doesn't properly handle this method yet
        [RecordedTest]
        public async Task GetDeploymentsForGroups()
        {
            DeviceManagementClient client = CreateClient();
            AsyncPageable<BinaryData> response = client.GetDeploymentsForGroupsAsync(TestEnvironment.DeviceGroup);
            int counter = 0;
            await foreach (var item in response)
            {
                Assert.IsNotNull(item);
                counter++;
            }

            Assert.IsTrue(counter > 0);
        }

        [RecordedTest]
        public async Task GetDeploymentsForGroups_NotFound()
        {
            DeviceManagementClient client = CreateClient();
            try
            {
                AsyncPageable<BinaryData> response = client.GetDeploymentsForGroupsAsync("foo");
                await foreach (var item in response)
                {
                    Assert.Fail("NotFound response expected");
                }
            }
            catch (RequestFailedException e)
            {
                Assert.AreEqual((int)HttpStatusCode.NotFound, e.Status);
            }
        }

        private DeviceManagementClient CreateClient()
        {
            var httpHandler = new HttpClientHandler();
            httpHandler.ServerCertificateCustomValidationCallback = (_, _, _, _) =>
            {
                return true;
            };

            var client = InstrumentClient(
                new DeviceManagementClient(
                    TestEnvironment.AccountEndPoint,
                    TestEnvironment.InstanceId,
                    TestEnvironment.Credential,
                    InstrumentClientOptions(new DeviceUpdateClientOptions
                    {
                        Transport = new HttpClientTransport(httpHandler)
                    })));

            return client;
        }
    }
}
