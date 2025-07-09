// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using NUnit.Framework;
using Serialization.EncodedName.Json;
using Serialization.EncodedName.Json._Property;

namespace TestProjects.Spector.Tests.Http.Serialization.EncodedName.Json
{
    public class EncodedNameJsonTests : SpectorTestBase
    {
        [SpectorTest]
        public Task PropertySend() => Test(async (host) =>
        {
            var response = await new JsonClient(host, null).GetPropertyClient().SendAsync(new JsonEncodedNameModel(true));
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task PropertyGet() => Test(async (host) =>
        {
            var response = await new JsonClient(host, null).GetPropertyClient().GetAsync();

            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.IsTrue(response.Value.DefaultName);
        });
    }
}
