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
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task PropertyGet() => Test(async (host) =>
        {
            var response = await new JsonClient(host, null).GetPropertyClient().GetAsync();

            Assert.That(response.GetRawResponse().Status, Is.EqualTo(200));
            Assert.That(response.Value.DefaultName, Is.True);
        });
    }
}
