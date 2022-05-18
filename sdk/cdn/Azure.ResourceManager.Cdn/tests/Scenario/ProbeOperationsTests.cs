// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Cdn.Models;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Cdn.Tests
{
    public class ProbeOperationsTests : CdnManagementTestBase
    {
        public ProbeOperationsTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task Validate()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            Uri probeURL = new Uri("https://azurecdn-files.azureedge.net/dsa-test/probe-v.txt");
            ValidateProbeContent validateProbeInput2 = new ValidateProbeContent(probeURL);
            ValidateProbeResult validateProbeResult = await subscription.ValidateProbeAsync(validateProbeInput2);
            Assert.True(validateProbeResult.IsValid);
            probeURL = new Uri("https://www.notexist.com/notexist/notexist.txt");
            ValidateProbeContent validateProbeInput3 = new ValidateProbeContent(probeURL);
            validateProbeResult = await subscription.ValidateProbeAsync(validateProbeInput3);
            Assert.False(validateProbeResult.IsValid);
        }
    }
}
