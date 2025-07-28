// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure;
using NUnit.Framework;
using SpecialHeaders.ConditionalRequest;

namespace TestProjects.Spector.Tests.Http.SpecialHeaders.ConditionalRequest
{
    public class ConditionalRequestHeaderTests : SpectorTestBase
    {
        [SpectorTest]
        public Task Special_Headers_Conditional_Request_PostIfMatch() => Test(async (host) =>
        {
            ETag ifMatch = new ETag("valid");
            Response response = await new ConditionalRequestClient(host, null).PostIfMatchAsync(ifMatch);
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task Special_Headers_Conditional_Request_PostIfNoneMatch() => Test(async (host) =>
        {
            ETag ifNoneMatch = new ETag("invalid");
            Response response = await new ConditionalRequestClient(host, null).PostIfNoneMatchAsync(ifNoneMatch);
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task Special_Headers_Conditional_Request_HeadIfModifiedSince() => Test(async (host) =>
        {
            DateTimeOffset ifModifiedSince = DateTimeOffset.Parse("Fri, 26 Aug 2022 14:38:00 GMT");
            Response response = await new ConditionalRequestClient(host, null).HeadIfModifiedSinceAsync(new RequestConditions()
            {
                IfModifiedSince = ifModifiedSince
            });
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task Special_Headers_Conditional_Request_PostIfUnmodifiedSince() => Test(async (host) =>
        {
            DateTimeOffset ifUnmodifiedSince = DateTimeOffset.Parse("Fri, 26 Aug 2022 14:38:00 GMT");
            Response response = await new ConditionalRequestClient(host, null).PostIfUnmodifiedSinceAsync(new RequestConditions()
            {
                IfUnmodifiedSince = ifUnmodifiedSince
            });
            Assert.AreEqual(204, response.Status);
        });
    }
}
