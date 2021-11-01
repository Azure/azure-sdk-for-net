// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
            string probeURL = "www.withoutHttp.com";
            ValidateProbeInput validateProbeInput1 = new ValidateProbeInput(probeURL);
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            Assert.ThrowsAsync<RequestFailedException>(async () => await subscription.ValidateProbeAsync(validateProbeInput1));
            probeURL = "https://azurecdn-files.azureedge.net/dsa-test/probe-v.txt";
            ValidateProbeInput validateProbeInput2 = new ValidateProbeInput(probeURL);
            ValidateProbeOutput ValidateProbeOutput = await subscription.ValidateProbeAsync(validateProbeInput2);
            Assert.True(ValidateProbeOutput.IsValid);
            probeURL = "https://www.notexist.com/notexist/notexist.txt";
            ValidateProbeInput validateProbeInput3 = new ValidateProbeInput(probeURL);
            ValidateProbeOutput = await subscription.ValidateProbeAsync(validateProbeInput3);
            Assert.False(ValidateProbeOutput.IsValid);
        }
    }
}
