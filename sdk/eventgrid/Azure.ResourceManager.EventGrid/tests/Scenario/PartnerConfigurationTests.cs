// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.EventGrid.Tests.Scenario
{
    internal class PartnerConfigurationTests : EventGridManagementTestBase
    {
        private ResourceGroupResource _resourceGroup;
        private PartnerConfigurationResource _partnerConfigurationResource;

        public PartnerConfigurationTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public async Task TestSetUp()
        {
            _resourceGroup = await CreateResourceGroupAsync();
            _partnerConfigurationResource = _resourceGroup.GetPartnerConfiguration();
        }
    }
}
