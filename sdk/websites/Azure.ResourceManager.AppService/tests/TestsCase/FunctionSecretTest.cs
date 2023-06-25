// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task TestCreateOrUpdateFunctionSecret()
        {
            // Make sure the function app exists before recording
            ResourceIdentifier siteFunctionResourceId = SiteFunctionResource.CreateResourceIdentifier(
                DefaultSubscription.Id.SubscriptionId,
                @"testRG-333",
                @"testfunc-2",
                @"HttpTrigger1");
            SiteFunctionResource siteFunction = Client.GetSiteFunctionResource(siteFunctionResourceId);

            string keyNameVar = @"my-key";
            WebAppKeyInfo infoVar = new WebAppKeyInfo()
            {
                KeyName = @"key-name-to-be-ignored",
                KeyValue = @"key-value"
            };
            CancellationToken cancellationTokenVar = default;
            WebAppKeyInfo result = await siteFunction.CreateOrUpdateFunctionSecretAsync(
                keyName: keyNameVar,
                info: infoVar,
                cancellationToken: cancellationTokenVar);
            Assert.AreEqual(keyNameVar, result.KeyName);
            Assert.AreEqual(infoVar.KeyValue, result.KeyValue);
        }
    }
}
