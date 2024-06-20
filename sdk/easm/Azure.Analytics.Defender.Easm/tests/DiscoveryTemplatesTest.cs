// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Analytics.Defender.Easm;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Analytics.Defender.Easm.Tests
{
    internal class DiscoveryTemplatesTest : EasmClientTest
    {
        private string TemplateId;
        private string PartialName;

        public DiscoveryTemplatesTest(bool isAsync) : base(isAsync)
        {
            TemplateId = "43488";
            PartialName = "sample";
        }
        [RecordedTest]
        public async System.Threading.Tasks.Task DiscoveryTemplatesListTest()
        {
            var response = client.GetDiscoveryTemplatesAsync(PartialName);
            await foreach (var template in response)
            {
                Assert.IsTrue(template.Name.ToLower().Contains(PartialName));
            }
        }
        [RecordedTest]
        public async System.Threading.Tasks.Task DiscoveryTemplatesGetTest()
        {
            var response =  await client.GetDiscoveryTemplateAsync(TemplateId);
            DiscoveryTemplate discoTemplate = response.Value;
            Assert.IsNotNull(discoTemplate.Name);
            Assert.IsNotNull(discoTemplate.Id);
        }
    }
}
