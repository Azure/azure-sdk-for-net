// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.IoT.DeviceUpdate.Tests
{
    public class DeviceUpdateClientTest : RecordedTestBase<DeviceUpdateClientTestEnvironment>
    {
        public DeviceUpdateClientTest(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        public async Task GetUpdateProviders()
        {
            DeviceUpdateClient client = CreateClient();
            AsyncPageable<BinaryData> response = client.GetProvidersAsync();
            int counter = 0;
            await foreach (var item in response)
            {
                Assert.IsNotNull(item);
                counter++;
            }

            Assert.IsTrue(counter > 0);
        }

        [RecordedTest]
        public async Task GetUpdateNames()
        {
            DeviceUpdateClient client = CreateClient();
            AsyncPageable<BinaryData> response = client.GetNamesAsync(TestEnvironment.UpdateProvider);
            int counter = 0;
            await foreach (var item in response)
            {
                Assert.IsNotNull(item);
                counter++;
            }

            Assert.IsTrue(counter > 0);
        }

        [RecordedTest]
        public async Task GetUpdateNames_NotFound()
        {
            DeviceUpdateClient client = CreateClient();
            try
            {
                AsyncPageable<BinaryData> response = client.GetNamesAsync("foo");
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

        [RecordedTest]
        public async Task GetUpdateVersions()
        {
            DeviceUpdateClient client = CreateClient();
            AsyncPageable<BinaryData> response = client.GetVersionsAsync(TestEnvironment.UpdateProvider, TestEnvironment.UpdateName);
            int counter = 0;
            await foreach (var item in response)
            {
                Assert.IsNotNull(item);
                counter++;
            }

            Assert.IsTrue(counter > 0);
        }

        [RecordedTest]
        public async Task GetUpdateVersions_NotFound()
        {
            DeviceUpdateClient client = CreateClient();
            try
            {
                AsyncPageable<BinaryData> response = client.GetVersionsAsync("foo", "bar");
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

        [RecordedTest]
        public async Task GetUpdate()
        {
            DeviceUpdateClient client = CreateClient();
            Response response = await client.GetUpdateAsync(TestEnvironment.UpdateProvider, TestEnvironment.UpdateName, TestEnvironment.UpdateVersion);
            Assert.IsNotNull(response.Content);
        }

        [RecordedTest]
        public async Task GetUpdate_NotFound()
        {
            DeviceUpdateClient client = CreateClient();
            try
            {
                await client.GetUpdateAsync("foo", "bar", "1.2");
                Assert.Fail("NotFound response expected");
            }
            catch (RequestFailedException e)
            {
                Assert.AreEqual((int)HttpStatusCode.NotFound, e.Status);
            }
        }

        [RecordedTest]
        public async Task GetUpdateFiles()
        {
            DeviceUpdateClient client = CreateClient();
            AsyncPageable<BinaryData> response = client.GetFilesAsync(TestEnvironment.UpdateProvider, TestEnvironment.UpdateName, TestEnvironment.UpdateVersion);
            int counter = 0;
            await foreach (var item in response)
            {
                Assert.IsNotNull(item);
                counter++;
            }

            Assert.IsTrue(counter > 0);
        }

        [RecordedTest]
        public async Task GetUpdateFiles_NotFound()
        {
            DeviceUpdateClient client = CreateClient();
            try
            {
                AsyncPageable<BinaryData> response = client.GetFilesAsync("foo", "bar", "1.2");
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

        private DeviceUpdateClient CreateClient()
        {
            var httpHandler = new HttpClientHandler();
            httpHandler.ServerCertificateCustomValidationCallback = (_, _, _, _) =>
            {
                return true;
            };

            var client = InstrumentClient(
                new DeviceUpdateClient(
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
