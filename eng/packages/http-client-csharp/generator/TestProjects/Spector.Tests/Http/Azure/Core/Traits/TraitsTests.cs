// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using _Specs_.Azure.Core.Traits;
using Azure;
using NUnit.Framework;

namespace TestProjects.Spector.Tests.Http.Azure.Core.Traits
{
    public class AzureCoreTraitsTests : SpectorTestBase
    {
        [SpectorTest]
        public Task Azure_Core_Traits_smokeTest() => Test(async (host) =>
        {
            User response = await new TraitsClient(host, null).SmokeTestAsync(1, "123", new RequestConditions() { IfMatch = new ETag("valid"), IfNoneMatch = new ETag("invalid"), IfUnmodifiedSince = DateTimeOffset.Parse("Fri, 26 Aug 2022 14:38:00 GMT"), IfModifiedSince = DateTimeOffset.Parse("Thu, 26 Aug 2021 14:38:00 GMT") });
            Assert.AreEqual("Madge", response.Name);
        });

        [SpectorTest]
        public Task Azure_Core_Traits_repeatableAction() => Test(async (host) =>
        {
            UserActionResponse response = await new TraitsClient(host, null).RepeatableActionAsync(1, new UserActionParam("test"), CancellationToken.None);
            Assert.AreEqual("test", response.UserActionResult);
        });
    }
}