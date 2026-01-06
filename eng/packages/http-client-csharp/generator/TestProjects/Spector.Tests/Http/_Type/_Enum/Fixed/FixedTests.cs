// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using _Type._Enum.Fixed;
using Azure;
using Azure.Core;
using NUnit.Framework;

namespace TestProjects.Spector.Tests.Http._Type._Enum.Fixed
{
    internal class FixedTests : SpectorTestBase
    {
        [SpectorTest]
        public Task GetKnownValue() => Test(async (host) =>
        {
            var response = await new FixedClient(host, null).GetStringClient().GetKnownValueAsync();
            Assert.That(response.Value, Is.EqualTo(DaysOfWeekEnum.Monday));
        });

        [SpectorTest]
        public Task PutKnownValue() => Test(async (host) =>
        {
            var response = await new FixedClient(host, null).GetStringClient().PutKnownValueAsync(DaysOfWeekEnum.Monday);
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task PutUnknownValue() => Test((host) =>
        {
            var exception = Assert.ThrowsAsync<RequestFailedException>(() => new FixedClient(host, null).GetStringClient().PutUnknownValueAsync(RequestContent.Create(BinaryData.FromObjectAsJson("Weekend")), null));
            Assert.That(exception?.GetRawResponse(), Is.Not.Null);
            Assert.That(exception?.GetRawResponse()?.Status, Is.EqualTo(500));
            return Task.CompletedTask;
        });
    }
}