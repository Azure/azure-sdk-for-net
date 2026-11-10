// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.CosmosDB.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.CosmosDB.Tests
{
    public class RestorableAccountLookupTests
    {
        [Test]
        public async Task StopsAfterFindingAccount()
        {
            var expected = new TestAccount("target");

            IEnumerable<Page<RestorableCosmosDBAccountResource>> Pages()
            {
                yield return Page<RestorableCosmosDBAccountResource>.FromValues(
                    new[] { expected }, "next-page", new MockResponse(200));
                throw new InvalidOperationException("The next page should not be requested.");
            }

            var result = await CosmosDBManagementClientBase.FindRestorableDatabaseAccountAsync(
                AsyncPageable<RestorableCosmosDBAccountResource>.FromPages(Pages()), "target");

            Assert.That(result, Is.SameAs(expected));
        }

        [Test]
        public async Task FindsAccountOnLaterPage()
        {
            var expected = new TestAccount("target");
            var pages = new[]
            {
                Page<RestorableCosmosDBAccountResource>.FromValues(
                    new[] { new TestAccount("other") }, "next-page", new MockResponse(200)),
                Page<RestorableCosmosDBAccountResource>.FromValues(
                    new[] { expected }, null, new MockResponse(200))
            };

            var result = await CosmosDBManagementClientBase.FindRestorableDatabaseAccountAsync(
                AsyncPageable<RestorableCosmosDBAccountResource>.FromPages(pages), "target");

            Assert.That(result, Is.SameAs(expected));
        }

        [Test]
        public void FailsWhenAccountIsMissing()
        {
            var page = Page<RestorableCosmosDBAccountResource>.FromValues(
                new[] { new TestAccount("other") }, null, new MockResponse(200));

            var exception = Assert.ThrowsAsync<AssertionException>(async () =>
                await CosmosDBManagementClientBase.FindRestorableDatabaseAccountAsync(
                    AsyncPageable<RestorableCosmosDBAccountResource>.FromPages(new[] { page }), "target"));

            Assert.That(exception.Message, Does.Contain("target"));
        }

        private class TestAccount : RestorableCosmosDBAccountResource
        {
            public TestAccount(string accountName)
            {
                Data = ArmCosmosDBModelFactory.RestorableCosmosDBAccountData(accountName: accountName);
            }

            public override RestorableCosmosDBAccountData Data { get; }
        }
    }
}
