// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.ResourceManager.SelfHelp.Tests
{
    using Azure.Core.TestFramework;
    using Azure.Core;
    using System.Threading.Tasks;
    using NUnit.Framework;
    using System;
    using Azure.ResourceManager.SelfHelp.Models;
    using System.Collections.Generic;

    public class TroubleshooterTests : SelfHelpManagementTestBase
    {
        private bool isAsync = true;
        public TroubleshooterTests(bool isAsync) : base(isAsync) //, RecordedTestMode.Record)
        {
            this.isAsync = isAsync;
        }

        [Test]
        public async Task CreateAndGetTroubleshooterTest()
        {
            var subId = "6bded6d5-a6af-43e1-96d3-bf71f6f5f8ba";
            var resourceGroupName = "DiagnosticsRp-Gateway-Public-Dev-Global";
            var resourceName = "DiagRpGwPubDev";
            var troubleshooterResourceName = string.Empty;

            //We have hard-coded the troubleshooterResourceName since Recording.GenerateAssetName(Guid.NewGuid().ToString()) does not generate
            //a GUID. If we just use Guid.NewGuid().ToString() it will create new GUID everytime but it wont be able to match the
            //test recordings
            //If you need to update the tests
            //1.Generate new guid and update the troubleshooterResourceName
            //2.Run the test in record mode to record the tests with new troubleshooterResourceName
            //3.Push the recordings to the assets-sdk
            if (isAsync)
            {
                troubleshooterResourceName = "0c16f71c-e791-4da2-80d7-f93ddfa2c226";
            }
            else
            {
                troubleshooterResourceName = "cc5feaab-3b50-40b9-aaa4-754b6b5e3826";
            }

            ResourceIdentifier scope = new ResourceIdentifier($"/subscriptions/{subId}/resourceGroups/{resourceGroupName}/providers/Microsoft.KeyVault/vaults/{resourceName}");
            SelfHelpTroubleshooterData resourceData = CreateSelfHelpTroubleshooterData(scope);

            var createTroubleshooterData = await Client.GetSelfHelpTroubleshooters(scope).CreateOrUpdateAsync(WaitUntil.Started, troubleshooterResourceName, resourceData);
            Assert.NotNull(createTroubleshooterData);

            var readTroubleshooterData = await Client.GetSelfHelpTroubleshooterAsync(scope, troubleshooterResourceName);
            Assert.NotNull(readTroubleshooterData);
        }

        private SelfHelpTroubleshooterData CreateSelfHelpTroubleshooterData(ResourceIdentifier scope)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>()
            {
                { "ResourceUri","/subscriptions/02d59989-f8a9-4b69-9919-1ef51df4eff6/resourceGroups/AcisValidation/providers/Microsoft.Compute/virtualMachines/vm-for-validation-port-80"},
                { "PuID", "100320019A2D7EB8"},
                { "SubscriptionId", "02d59989-f8a9-4b69-9919-1ef51df4eff6"},
                { "SapId", "1c2f964e-9219-e8fe-f027-95330b445941" },
                { "language", "en-us" },
                { "SessionId", "63e88074-1ac0-475a-8aee-e33f8477a4b3" },
                { "TimeZone", "GMT-0800 (Pacific Standard Time)" },
                { "TimeZoneOffset", "480" },
                { "TenantId", "72f988bf-86f1-41af-91ab-2d7cd011db47" },
                { "ProductId", "15571" },
                { "UserIPAddress", "174.164.29.4" }
            };

            List<SelfHelpSection> sections = new List< SelfHelpSection>();
            ResourceType resourceType = new ResourceType("Microsoft.KeyVault/vaults");
            var data = new SelfHelpTroubleshooterData(scope, null, resourceType, null, "e104dbdf-9e14-4c9f-bc78-21ac90382231", parameters, null, null, null);

            return data;
        }
    }
}
