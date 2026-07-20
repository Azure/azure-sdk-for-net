// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using NUnit.Framework;
using Specs.Azure.ClientGenerator.Core.ExactName;
using Specs.Azure.ClientGenerator.Core.ExactName._EnumValue;
using Specs.Azure.ClientGenerator.Core.ExactName._Model;
using Specs.Azure.ClientGenerator.Core.ExactName._Property;

namespace TestProjects.Spector.Tests.Http.Azure.ClientGeneratorCore.ExactName
{
    public class ExactNameTests : SpectorTestBase
    {
        [SpectorTest]
        public Task Azure_ClientGenerator_Core_ExactName_Model() => Test(async (host) =>
        {
            var response = await new ExactNameClient(host, null).GetModelClient().SendAsync(new my_model("test"));

            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual("test", response.Value.Name);
        });

        [SpectorTest]
        public Task Azure_ClientGenerator_Core_ExactName_Property() => Test(async (host) =>
        {
            var response = await new ExactNameClient(host, null).GetPropertyClient().SendAsync(new ScopedModel("test"));

            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual("test", response.Value._MyName);
        });

        [SpectorTest]
        public Task Azure_ClientGenerator_Core_ExactName_EnumValue() => Test(async (host) =>
        {
            var response = await new ExactNameClient(host, null).GetEnumValueClient().SendAsync(
                new EndpointConfig(AgentEndpointProtocol.A2A));

            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual(AgentEndpointProtocol.A2A, response.Value.Protocol);
        });

        [SpectorTest]
        public Task Azure_ClientGenerator_Core_ExactName_Operation() => Test(async (host) =>
        {
            var response = await new ExactNameClient(host, null).GetOperationClient().myOpAsync();

            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task Azure_ClientGenerator_Core_ExactName_Parameter() => Test(async (host) =>
        {
            var response = await new ExactNameClient(host, null).GetParameterClient().SendAsync(myParam: "hello");

            Assert.AreEqual(204, response.Status);
        });
    }
}
