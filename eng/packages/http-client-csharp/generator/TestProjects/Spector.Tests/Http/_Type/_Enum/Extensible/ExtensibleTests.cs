// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using _Type._Enum.Extensible;
using NUnit.Framework;

namespace TestProjects.Spector.Tests.Http._Type._Enum.Extensible
{
    internal class ExtensibleTests : SpectorTestBase
    {
        [SpectorTest]
        public Task GetKnownValue() => Test(async (host) =>
        {
            var response = await new ExtensibleClient(host, null).GetStringClient().GetKnownValueAsync();
            Assert.That((DaysOfWeekExtensibleEnum)response, Is.EqualTo(DaysOfWeekExtensibleEnum.Monday));
        });

        [SpectorTest]
        public Task GetUnknownValue() => Test(async (host) =>
        {
            var response = await new ExtensibleClient(host, null).GetStringClient().GetUnknownValueAsync();
            Assert.That((DaysOfWeekExtensibleEnum)response, Is.EqualTo(new DaysOfWeekExtensibleEnum("Weekend")));
        });

        [SpectorTest]
        public Task PutKnownValue() => Test(async (host) =>
        {
            var response = await new ExtensibleClient(host, null).GetStringClient().PutKnownValueAsync(DaysOfWeekExtensibleEnum.Monday);
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task PutUnknownValue() => Test(async (host) =>
        {
            var response = await new ExtensibleClient(host, null).GetStringClient().PutUnknownValueAsync(new DaysOfWeekExtensibleEnum("Weekend"));
            Assert.That(response.Status, Is.EqualTo(204));
        });
    }
}