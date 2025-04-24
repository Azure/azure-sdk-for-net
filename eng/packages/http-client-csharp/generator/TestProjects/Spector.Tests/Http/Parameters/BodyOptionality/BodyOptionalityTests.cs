// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure;
using NUnit.Framework;
using Parameters.BodyOptionality;

namespace TestProjects.Spector.Tests.Http.Parameters.BodyOptionality
{
    public class BodyOptionalityTests : SpectorTestBase
    {
        [SpectorTest]
        public Task Parameters_BodyOptionality_requiredExplicit() => Test(async (host) =>
        {
            Response response = await new BodyOptionalityClient(host, null).RequiredExplicitAsync(new BodyModel("foo"));
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task Parameters_BodyOptionality_OptionalExplicit() => Test(async (host) =>
        {
            var client = new BodyOptionalityClient(host, null).GetOptionalExplicitClient();
            Response response = await client.SetAsync(new BodyModel("foo"));
            Assert.AreEqual(204, response.Status);

            response = await client.OmitAsync();
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task Parameters_BodyOptionality_requiredImplicit() => Test(async (host) =>
        {
            Response response = await new BodyOptionalityClient(host, null).RequiredImplicitAsync("foo");
            Assert.AreEqual(204, response.Status);
        });
    }
}