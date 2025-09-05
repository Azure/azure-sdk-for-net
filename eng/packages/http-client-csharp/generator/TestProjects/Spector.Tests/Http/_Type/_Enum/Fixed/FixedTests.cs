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
            Assert.AreEqual(DaysOfWeekEnum.Monday, response.Value);
        });

        [SpectorTest]
        public Task PutKnownValue() => Test(async (host) =>
        {
            var response = await new FixedClient(host, null).GetStringClient().PutKnownValueAsync(DaysOfWeekEnum.Monday);
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task PutUnknownValue() => Test((host) =>
        {
            var exception = Assert.ThrowsAsync<RequestFailedException>(() => new FixedClient(host, null).GetStringClient().PutUnknownValueAsync(RequestContent.Create(BinaryData.FromObjectAsJson("Weekend")), null));
            Assert.IsNotNull(exception?.GetRawResponse());
            Assert.AreEqual(500, exception?.GetRawResponse()?.Status);
            return Task.CompletedTask;
        });
    }
}