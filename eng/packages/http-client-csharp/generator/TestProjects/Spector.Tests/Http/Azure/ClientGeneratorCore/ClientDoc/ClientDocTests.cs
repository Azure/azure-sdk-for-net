// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using NUnit.Framework;
using Specs.Azure.ClientGenerator.Core.ClientDoc;
using Specs.Azure.ClientGenerator.Core.ClientDoc._Documentation;

namespace TestProjects.Spector.Tests.Http.Azure.ClientGeneratorCore.ClientDoc
{
    public class ClientDocTests : SpectorTestBase
    {
        [SpectorTest]
        public Task Azure_ClientGenerator_Core_ClientDoc_Documentation() => Test(async (host) =>
        {
            var response = await new ClientDocClient(host, null)
                .GetDocumentationClient().HarvestAsync(new Plant("Rose", "Rosa"));

            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual("Rose", response.Value.Name);
            Assert.AreEqual("Rosa", response.Value.Species);
        });
    }
}
