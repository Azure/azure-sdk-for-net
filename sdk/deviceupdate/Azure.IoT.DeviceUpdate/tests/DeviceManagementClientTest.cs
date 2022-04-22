// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using System.Net.Http;
using Azure.Core.Pipeline;
using System.Text.Json;
using System.IO;
using NUnit.Framework;
using Azure.Core;

namespace Azure.IoT.DeviceUpdate.Tests
{
    public class DeviceManagementClientTest: RecordedTestBase<DeviceUpdateClientTestEnvironment>
    {
        public DeviceManagementClientTest(bool isAsync) : base(isAsync)
        {
        }

        private DeviceManagementClient CreateClient()
        {
            var httpHandler = new HttpClientHandler();
            httpHandler.ServerCertificateCustomValidationCallback = (_, _, _, _) =>
            {
                return true;
            };
            var options = new DeviceUpdateClientOptions { Transport = new HttpClientTransport(httpHandler) };
            var client = InstrumentClient(
                new DeviceManagementClient(TestEnvironment.AccountEndPoint, TestEnvironment.InstanceId, TestEnvironment.Credential, InstrumentClientOptions(options)));
            return client;
        }

        [RecordedTest]
        public async Task GetDevices()
        {
            DeviceManagementClient client = CreateClient();
            AsyncPageable<BinaryData> fetchResponse = client.GetDevicesAsync();
            int counter = 0;
            await foreach (var item in fetchResponse)
            {
                Assert.IsNotNull(item);
                counter++;
            }

            Assert.IsTrue(counter > 0);
        }

        [RecordedTest]
        public async Task GetDeviceTags()
        {
            DeviceManagementClient client = CreateClient();
            AsyncPageable<BinaryData> fetchResponse = client.GetDeviceTagsAsync();
            int counter = 0;
            await foreach (var item in fetchResponse)
            {
                Assert.IsNotNull(item);
                counter++;
            }

            Assert.IsTrue(counter > 0);
        }

        [RecordedTest]
        public async Task GetGroups()
        {
            DeviceManagementClient client = CreateClient();
            AsyncPageable<BinaryData> fetchResponse = client.GetGroupsAsync(new RequestContext());
            int counter = 0;
            await foreach (var item in fetchResponse)
            {
                Assert.IsNotNull(item);
                counter++;
            }

            Assert.IsTrue(counter > 0);
        }

        [RecordedTest]
        public async Task GroupAndDeployment()
        {
            DeviceManagementClient client = CreateClient();
            string groupid = "joegroup";

            /* list groups. */
            AsyncPageable<BinaryData> fetchResponse = client.GetGroupsAsync(new RequestContext());
            int counter = 0;
            await foreach (var item in fetchResponse)
            {
                Assert.IsNotNull(item);
                counter++;
            }

            Assert.IsTrue(counter > 0);

            /* create a group. */
            var body = new
            {
                groupId = groupid,
                tags = new string[] { groupid },
                createdDateTime = "2021-11-17T16:29:56.5770502+00:00",
                groupType = "DeviceClassIdAndIoTHubTag",
                deviceClassId = "0919e3ae422a2bfa8c84ff905813e60351e456d1"
            };
            Response createResponse = await client.CreateOrUpdateGroupAsync(groupid, RequestContent.Create(body), new RequestContext());
            Assert.IsTrue(createResponse.Status == 200);

            /* get a group. */
            Response getResponse = await client.GetGroupAsync(groupid, new RequestContext());
            Assert.IsTrue(getResponse.Status == 200);

            /* create a deployment. */
            string deploymentid = "testdeployment1";
            var deploymentBody = new
            {
                deploymentId = deploymentid,
                startDateTime = "2021-09-02T16:29:56.5770502Z",
                groupId = groupid,
                updateId = new
                {
                    provider = "fabrikam",
                    name = "vacuum",
                    version = "2021.1117.1036.48"
                }
            };
            Response createDeploymentResponse = await client.CreateOrUpdateDeploymentAsync(groupid, deploymentid, RequestContent.Create(deploymentBody), new RequestContext());
            Assert.IsTrue(createDeploymentResponse.Status == 200);
            /* get deployment. */
            Response getDepoloymentResponse = await client.GetDeploymentAsync(groupid, deploymentid, new RequestContext());
            Assert.IsTrue(getDepoloymentResponse.Status == 200);

            /* delete deployment. */
            Response deleteDeploymentResponse = await client.DeleteDeploymentAsync(groupid, deploymentid, new RequestContext());
            Assert.IsTrue(deleteDeploymentResponse.Status == 204);

            /* delete group. */
            Response deleteGroupResponse = await client.DeleteGroupAsync(groupid, new RequestContext());
            Assert.IsTrue(deleteGroupResponse.Status == 204);
        }

        private static BinaryData GetContentFromResponse(Response r)
        {
            // Workaround azure/azure-sdk-for-net#21048, which prevents .Content from working when dealing with responses
            // from the playback system.

            MemoryStream ms = new MemoryStream();
            r.ContentStream.CopyTo(ms);
            return new BinaryData(ms.ToArray());
        }
    }
}
