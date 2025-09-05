// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using _Type.Model.Inheritance.NotDiscriminated;
using NUnit.Framework;

namespace TestProjects.Spector.Tests.Http._Type.Model.Inheritance.NotDiscriminated
{
    public class NotDiscriminatedTests : SpectorTestBase
    {
        [SpectorTest]
        public Task PostValid() => Test(async (host) =>
        {
            var response = await new NotDiscriminatedClient(host, null).PostValidAsync(new Siamese("abc", 32, true));
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task GetValid() => Test(async (host) =>
        {
            var response = await new NotDiscriminatedClient(host, null).GetValidAsync();
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual("abc", response.Value.Name);
            Assert.AreEqual(32, response.Value.Age);
            Assert.True(response.Value.Smart);
        });

        [SpectorTest]
        public Task PutValid() => Test(async (host) =>
        {
            var response = await new NotDiscriminatedClient(host, null).PutValidAsync(new Siamese("abc", 32, true));
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual("abc", response.Value.Name);
            Assert.AreEqual(32, response.Value.Age);
            Assert.IsTrue(response.Value.Smart);
        });
    }
}