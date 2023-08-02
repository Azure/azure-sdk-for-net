// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.AppService.Tests.Helpers;
using Azure.ResourceManager.Resources;
using NUnit.Framework;
namespace Azure.ResourceManager.AppService.Tests.TestsCase
{
    public class LogsSiteConfigResourceTests : AppServiceTestBase
    {
        public LogsSiteConfigResourceTests(bool isAsync)
           : base(isAsync, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            var webSiteConfigId = LogsSiteConfigResource.CreateResourceIdentifier(DefaultSubscription.Data.Id.ToString(), "deleteme0802", "issuefixtests");
            var webSiteConfigResource = await Client.GetLogsSiteConfigResource(webSiteConfigId).GetAsync();
        }
    }
}
