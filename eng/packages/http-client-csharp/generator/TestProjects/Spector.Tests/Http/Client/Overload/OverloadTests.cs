// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Client.Overload;
using NUnit.Framework;

namespace TestProjects.Spector.Tests.Http.Client.Overload
{
    public class OverloadTests : SpectorTestBase
    {
        [SpectorTest]
        public Task Client_Overload_list() => Test(async (host) =>
        {
            var response = await new OverloadClient(host, null).GetAllAsync();
            Assert.That(response.GetRawResponse().Status, Is.EqualTo(200));

            var results = response.Value;
            Assert.That(results.Count, Is.EqualTo(2));
            Assert.Multiple(() =>
            {
                Assert.That(results[0].Name, Is.EqualTo("foo"));
                Assert.That(results[0].Scope, Is.EqualTo("car"));
                Assert.That(results[1].Name, Is.EqualTo("bar"));
                Assert.That(results[1].Scope, Is.EqualTo("bike"));
            });
        });

        [SpectorTest]
        public Task Client_Overload_listByScope() => Test(async (host) =>
        {
            var response = await new OverloadClient(host, null).GetAllAsync(scope: "car");
            Assert.That(response.GetRawResponse().Status, Is.EqualTo(200));

            var results = response.Value;
            Assert.That(results.Count, Is.EqualTo(1));
            Assert.Multiple(() =>
            {
                Assert.That(results[0].Name, Is.EqualTo("foo"));
                Assert.That(results[0].Scope, Is.EqualTo("car"));
            });
        });
    }
}