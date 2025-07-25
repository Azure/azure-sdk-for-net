// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using _Specs_.Azure.Encode.Duration;
using NUnit.Framework;

namespace TestProjects.Spector.Tests.Http.Azure.Encode.Duration
{
    public class AzureEncodeDurationTests : SpectorTestBase
    {
        [SpectorTest]
        public Task Azure_Encode_Duration() => Test(async (host) =>
        {
            var request = new DurationModel(new TimeSpan(1, 2, 59, 59, 500));
            var response = await new DurationClient(host, null).DurationConstantAsync(request);
            Assert.AreEqual(204, response.Status);
        });
    }
}