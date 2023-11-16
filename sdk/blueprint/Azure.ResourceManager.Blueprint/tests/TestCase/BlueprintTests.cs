// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Blueprint;
using Azure.ResourceManager.Blueprint.Models;
using NUnit.Framework;
using Azure.ResourceManager.Blueprint.Tests.Helpers;

namespace Azure.ResourceManager.Blueprint.Tests
{
    public class BlueprintTests : BlueprintManagementTestBase
    {
        public BlueprintTests(bool isAsync) :
            base(isAsync, RecordedTestMode.Record)
        {
        }

        [Test]
        public async Task BlueprintTest()
        {
            //prepare
            string printName = Recording.GenerateAssetName("blueprint-");
            string resourceScope = "providers/Microsoft.Management/managementGroups/ContosoOnlineGroup";
            ResourceIdentifier scopeId = new ResourceIdentifier(string.Format("/{0}", resourceScope));
            BlueprintCollection collection = Client.GetBlueprints(scopeId);
            var input = ResourceDataHelpers.GetBlueprintData();
            var blueprintResource =(await collection.CreateOrUpdateAsync(WaitUntil.Completed, printName, input)).Value;
            Assert.AreEqual(printName, blueprintResource.Data.Name);
        }
    }
}
