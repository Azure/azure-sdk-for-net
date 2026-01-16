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

            Assert.That(user.Name, Is.EqualTo("madge"));
            Assert.That(user.Role, Is.EqualTo("contributor"));
        });

        [SpectorTest]
        public Task Delete() => Test(async (host) =>
        {
            var operation = await new StandardClient(host, null).DeleteAsync(WaitUntil.Completed, "madge");

            Assert.That(operation.HasCompleted, Is.True);
            Assert.That(operation.GetRawResponse().Status, Is.EqualTo(((int)HttpStatusCode.OK)));
        });

        [SpectorTest]
        public Task Action() => Test(async (host) =>
        {
            var operation = await new StandardClient(host, null).ExportAsync(WaitUntil.Completed, "madge", "json");
            Assert.That(operation.HasCompleted, Is.True);

            var exportedUser = operation.Value;
            Assert.That(exportedUser.Name, Is.EqualTo("madge"));
            Assert.That(exportedUser.ResourceUri, Is.EqualTo("/users/madge"));
        });
    }
}