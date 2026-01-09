// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using _Type.Model.Empty;
using NUnit.Framework;

namespace TestProjects.Spector.Tests.Http._Type.Model.Empty
{
    internal class EmptyTests : SpectorTestBase
    {
        [SpectorTest]
        public Task PutEmpty() => Test(async (host) =>
        {
            var response = await new EmptyClient(host, null).PutEmptyAsync(new EmptyInput());
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task GetEmpty() => Test(async (host) =>
        {
            var response = await new EmptyClient(host, null).GetEmptyAsync();
            Assert.That(response.GetRawResponse().Status, Is.EqualTo(200));
        });

        [SpectorTest]
        public Task PostRoundTripEmpty() => Test(async (host) =>
        {
            var response = await new EmptyClient(host, null).PostRoundTripEmptyAsync(new EmptyInputOutput());
            Assert.That(response.GetRawResponse().Status, Is.EqualTo(200));
        });
    }
}