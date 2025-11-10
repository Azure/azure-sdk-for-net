// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net;
using System.Threading.Tasks;
using Specs.Azure.Core.Lro.Standard;
using Azure;
using NUnit.Framework;

namespace TestProjects.Spector.Tests.Http.Azure.Core.Lro.Standard
{
    public class LroStandardTests : SpectorTestBase
    {
        [SpectorTest]
        public Task CreateOrReplace() => Test(async (host) =>
        {
            var operation = await new StandardClient(host, null).CreateOrReplaceAsync(
                WaitUntil.Completed,
                "madge",
                new User("contributor"));
            var user = operation.Value;

            Assert.AreEqual("madge", user.Name);
            Assert.AreEqual("contributor", user.Role);
        });

        [SpectorTest]
        public Task Delete() => Test(async (host) =>
        {
            var operation = await new StandardClient(host, null).DeleteAsync(WaitUntil.Completed, "madge");

            Assert.IsTrue(operation.HasCompleted);
            Assert.AreEqual(((int)HttpStatusCode.OK), operation.GetRawResponse().Status);
        });

        [SpectorTest]
        public Task Action() => Test(async (host) =>
        {
            var operation = await new StandardClient(host, null).ExportAsync(WaitUntil.Completed, "madge", "json");
            Assert.IsTrue(operation.HasCompleted);

            var exportedUser = operation.Value;
            Assert.AreEqual("madge", exportedUser.Name);
            Assert.AreEqual("/users/madge", exportedUser.ResourceUri);
        });
    }
}