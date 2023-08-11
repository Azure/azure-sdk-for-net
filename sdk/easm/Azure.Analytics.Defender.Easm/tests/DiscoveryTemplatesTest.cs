// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Analytics.Defender.Easm.Models;
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
            PartialName = "ku";
        }

        [RecordedTest]
        public async Task DiscoveryTemplatesListTest()
        {
            Response<DiscoTemplatePageResult> response = await client.GetDiscoTemplatesAsync(PartialName);
            DiscoTemplate discoTemplateResponse = response.Value.Value[0];
            Assert.IsTrue(discoTemplateResponse.Name.ToLower().Contains(PartialName));
            Assert.IsNotNull(discoTemplateResponse.Id);
        }

        [RecordedTest]
        public async Task DiscoveryTemplatesGetTest()
        {
            Response<DiscoTemplate> response = await client.GetDiscoTemplateAsync(TemplateId);
            DiscoTemplate discoTemplateResponse = response.Value;
            Assert.IsNotNull(discoTemplateResponse.Name);
            Assert.IsNotNull(discoTemplateResponse.Id);
        }
    }
}
