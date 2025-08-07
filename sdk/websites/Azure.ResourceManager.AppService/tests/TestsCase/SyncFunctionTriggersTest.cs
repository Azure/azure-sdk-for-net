// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core.TestFramework;
using System.Threading.Tasks;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.AppService.Models;
using NUnit.Framework;
using Azure.Core;

namespace Azure.ResourceManager.AppService.Tests.TestsCase
{
    public class SyncFunctionTriggersTest: AppServiceTestBase
    {
        public SyncFunctionTriggersTest(bool isAsync) : base(isAsync)//, RecordedTestMode.Record)
        { }

        [Test]
        public async Task FunctionTriggers()
        {
            var rg = await CreateResourceGroupAsync();
            var appName = Recording.GenerateAssetName("functest-");
            var appData = new WebSiteData(AzureLocation.EastUS)
            {
                ContainerSize = 1536,
                ClientCertMode = ClientCertMode.Required,
                Kind = "functionapp",
                IsEnabled = true,
                KeyVaultReferenceIdentity = "SystemAssigned"
            };
            var app = (await rg.GetWebSites().CreateOrUpdateAsync(WaitUntil.Completed, appName, appData)).Value;
            var getApp = (await app.GetAsync()).Value;
            var result = await getApp.SyncFunctionTriggersAsync();
            Assert.IsNotNull(result);
        }
    }
}
