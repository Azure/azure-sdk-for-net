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
    public class EnvironmentCreateTests : RecordedTestBase<DevCenterClientTestEnvironment>
    {
        public EnvironmentCreateTests(bool isAsync) : base(isAsync)
        {
        }

        private EnvironmentsClient GetEnvironmentsClient() =>
            InstrumentClient(new EnvironmentsClient(
                TestEnvironment.Endpoint,
                TestEnvironment.ProjectName,
                TestEnvironment.Credential,
                InstrumentClientOptions(new DevCenterClientOptions())));

        [RecordedTest]
        [PlaybackOnly("Environment creation is unstable due to service issues currently under investigation")]
        public async Task EnvironmentCreationSucceeds()
        {
            EnvironmentsClient environmentsClient = GetEnvironmentsClient();
            string catalogItemName = null;

            await foreach (BinaryData catalogItemData in environmentsClient.GetCatalogItemsAsync())
            {
                JsonElement catalogItem = JsonDocument.Parse(catalogItemData.ToStream()).RootElement;
                catalogItemName = catalogItem.GetProperty("name").ToString();
            }

            var content = new
            {
                catalogItemName = catalogItemName,
                catalogName = TestEnvironment.CatalogName,
                environmentType = TestEnvironment.EnvironmentTypeName,
            };

            Operation<BinaryData> environmentCreateOperation = await environmentsClient.CreateOrUpdateEnvironmentAsync(WaitUntil.Completed, "DevTestEnv", RequestContent.Create(content));
            BinaryData environmentData = await environmentCreateOperation.WaitForCompletionAsync();
            JsonElement environment = JsonDocument.Parse(environmentData.ToStream()).RootElement;
            Console.WriteLine($"Started provisioning for environment with status {environment.GetProperty("provisioningState")}.");
            Console.WriteLine($"Completed provisioning for environment with status {environment.GetProperty("provisioningState")}.");

            Assert.IsTrue(environment.GetProperty("provisioningState").ToString().Equals("Succeeded", StringComparison.OrdinalIgnoreCase));

            // Delete the dev box
            Operation environmentDeleteOperation = await environmentsClient.DeleteEnvironmentAsync(WaitUntil.Started, "DevTestEnv");
            await environmentDeleteOperation.WaitForCompletionResponseAsync();
            Console.WriteLine($"Completed environment deletion.");
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
