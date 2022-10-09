// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.SecurityCenter.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.SecurityCenter.Tests
{
    internal class AdaptiveNetworkHardening : SecurityCenterManagementTestBase
    {
        private ResourceGroupResource _resourceGroup;
        //private AdaptiveNetworkHardeningCollection _adaptiveNetworkHardeningCollection;

        public AdaptiveNetworkHardening(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public async Task TestSetUp()
        {
            _resourceGroup = await CreateResourceGroup();
            var network = await CreateDefaultNetwork(_resourceGroup,Recording.GenerateAssetName("vnet"));
            _adaptiveNetworkHardeningCollection = _resourceGroup.GetAdaptiveNetworkHardenings();
        }

        [RecordedTest]
        public void GetAll()
        {
        }
    }
}
