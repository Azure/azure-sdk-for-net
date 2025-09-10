﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using FluentAssertions;
using NUnit.Framework;
using Azure.ResourceManager.IotFirmwareDefense.Models;

namespace Azure.ResourceManager.IotFirmwareDefense.Tests
{
    public class PasswordHashTest : IotFirmwareDefenseManagementTestBase
    {
        private static SubscriptionResource testSubscription;

        public PasswordHashTest(bool isAsync)
            : base(isAsync)
        {
        }

        [SetUp]
        public void setup()
        {
            var _ = SubscriptionResource.CreateResourceIdentifier(subscriptionId);
            testSubscription = Client.GetSubscriptionResource(_);
        }

        [TestCase]
        [RecordedTest]
        public async Task TestGetPasswordHashes()
        {
            ResourceGroupResource testRg = await testSubscription.GetResourceGroupAsync(rgName);
            FirmwareAnalysisWorkspaceResource testWorkspace = await testRg.GetFirmwareAnalysisWorkspaceAsync(workspaceName);
            IotFirmwareResource testFirmware = await testWorkspace.GetIotFirmwareAsync(firmwareId);

            var results = testFirmware.GetPasswordHashesAsync();
            await foreach ( PasswordHashResult result in results ) {
                Console.WriteLine($"Fetched: {result}");
            }
            Assert.NotNull(results);
        }
    }
}
