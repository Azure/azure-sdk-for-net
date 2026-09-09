// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.AppService.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.AppService.Tests.TestsCase
{
    public class FunctionSecretTest : AppServiceTestBase
    {
        public FunctionSecretTest(bool isAsync)
            : base(isAsync) //, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task TestCreateOrUpdateFunctionSecret()
        {
            // Make sure the function app exists before recording
            ResourceIdentifier siteFunctionResourceId = SiteFunctionResource.CreateResourceIdentifier(
                this.DefaultSubscription.Id.SubscriptionId,
                @"testrg",
                @"testfunc--1",
                @"HttpTrigger1");
            SiteFunctionResource siteFunctionResourceVar = Client.GetSiteFunctionResource(siteFunctionResourceId);
            string keyNameVar = @"my-key";
            WebAppKeyInfo infoVar = new WebAppKeyInfo()
            {
                Properties = new WebAppKeyInfoProperties()
                {
                    Name = @"key-name-to-be-ignored",
                    Value = @"key-value"
                }
            };
            CancellationToken cancellationTokenVar = default;
            WebAppKeyInfo result = await siteFunctionResourceVar.CreateOrUpdateFunctionSecretAsync(
                keyName: keyNameVar,
                info: infoVar,
                cancellationToken: cancellationTokenVar);
            Assert.AreEqual(keyNameVar, result.Properties.Name);
            Assert.AreEqual(infoVar.Properties.Value, result.Properties.Value);
        }
    }
}
