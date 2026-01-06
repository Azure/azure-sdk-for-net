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
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task GetValid() => Test(async (host) =>
        {
            var response = await new NotDiscriminatedClient(host, null).GetValidAsync();
            Assert.Multiple(() =>
            {
                Assert.That(response.GetRawResponse().Status, Is.EqualTo(200));
                Assert.That(response.Value.Name, Is.EqualTo("abc"));
                Assert.That(response.Value.Age, Is.EqualTo(32));
                Assert.That(response.Value.Smart, Is.True);
            });
        });

        [SpectorTest]
        public Task PutValid() => Test(async (host) =>
        {
            var response = await new NotDiscriminatedClient(host, null).PutValidAsync(new Siamese("abc", 32, true));
            Assert.Multiple(() =>
            {
                Assert.That(response.GetRawResponse().Status, Is.EqualTo(200));
                Assert.That(response.Value.Name, Is.EqualTo("abc"));
                Assert.That(response.Value.Age, Is.EqualTo(32));
                Assert.That(response.Value.Smart, Is.True);
            });
        });
    }
}