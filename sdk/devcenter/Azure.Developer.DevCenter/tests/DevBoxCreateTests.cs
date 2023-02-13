// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Developer.DevCenter.Tests
{
    public class DevBoxCreateTests: RecordedTestBase<DevCenterClientTestEnvironment>
    {
        public DevBoxCreateTests(bool isAsync) : base(isAsync)
        {
        }

        private DevBoxesClient GetDevBoxesClient() =>
            InstrumentClient(new DevBoxesClient(
                TestEnvironment.Endpoint,
                TestEnvironment.ProjectName,
                TestEnvironment.Credential,
                InstrumentClientOptions(new DevCenterClientOptions())));

        [RecordedTest]
        [PlaybackOnly("Dev box creation time takes several hours which is blocking for live integration tests")]
        public async Task DevBoxCreationSucceeds()
        {
            DevBoxesClient devBoxesClient = GetDevBoxesClient();
            var content = new
            {
                poolName = TestEnvironment.PoolName,
            };

            Operation<BinaryData> devBoxCreateOperation = await devBoxesClient.CreateDevBoxAsync(WaitUntil.Completed, "MyDevBox", RequestContent.Create(content), userId: TestEnvironment.UserId);
            BinaryData devBoxData = await devBoxCreateOperation.WaitForCompletionAsync();
            JsonElement devBox = JsonDocument.Parse(devBoxData.ToStream()).RootElement;
            Console.WriteLine($"Completed provisioning for dev box with status {devBox.GetProperty("provisioningState")}.");

            string devBoxProvisioningState = devBox.GetProperty("provisioningState").ToString();

            // Both states indicate successful provisioning
            bool devBoxProvisionSucceeded = devBoxProvisioningState.Equals("Succeeded", StringComparison.OrdinalIgnoreCase) || devBoxProvisioningState.Equals("ProvisionedWithWarning", StringComparison.OrdinalIgnoreCase);
            Assert.IsTrue(devBoxProvisionSucceeded);

            // Start the dev box
            Response remoteConnectionResponse = await devBoxesClient.GetRemoteConnectionAsync("MyDevBox", userId: TestEnvironment.UserId);
            JsonElement remoteConnectionData = JsonDocument.Parse(remoteConnectionResponse.ContentStream).RootElement;
            Console.WriteLine($"Connect using web URL {remoteConnectionData.GetProperty("webUrl")}.");

            // Delete the dev box
            Operation devBoxDeleteOperation = await devBoxesClient.DeleteDevBoxAsync(WaitUntil.Completed, "MyDevBox", userId: TestEnvironment.UserId);
            await devBoxDeleteOperation.WaitForCompletionResponseAsync();
            Console.WriteLine($"Completed dev box deletion.");
        }

        #region Helpers

        private static BinaryData GetContentFromResponse(Response r)
        {
            // Workaround azure/azure-sdk-for-net#21048, which prevents .Content from working when dealing with responses
            // from the playback system.

            MemoryStream ms = new MemoryStream();
            r.ContentStream.CopyTo(ms);
            return new BinaryData(ms.ToArray());
        }
        #endregion
    }
}
