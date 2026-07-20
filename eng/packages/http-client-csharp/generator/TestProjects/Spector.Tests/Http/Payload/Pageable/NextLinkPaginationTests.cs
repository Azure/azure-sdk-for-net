// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using Azure;
using NUnit.Framework;
using Payload.Pageable;

namespace TestProjects.Spector.Tests.Http.Payload.Pageable
{
    public class NextLinkPaginationTests : SpectorTestBase
    {
        [SpectorTest]
        public Task ConvenienceMethod() => Test(async (host) =>
        {
            var client = new PageableClient(host, null);
            var result = client.GetServerDrivenPaginationClient().LinkAsync();
            int count = 0;
            var expectedPets = new Dictionary<string, string>()
            {
                { "1", "dog" },
                { "2", "cat" },
                { "3", "bird" },
                { "4", "fish" },
            };
            await foreach (var pet in result)
            {
                Assert.IsNotNull(pet);
                Assert.AreEqual((++count).ToString(), pet.Id);
                Assert.AreEqual(expectedPets[pet.Id], pet.Name);
            }
        });

        [SpectorTest]
        public Task ConvenienceMethodSync() => Test((host) =>
        {
            var client = new PageableClient(host, null);
            var result = client.GetServerDrivenPaginationClient().Link();
            int count = 0;
            var expectedPets = new Dictionary<string, string>()
            {
                { "1", "dog" },
                { "2", "cat" },
                { "3", "bird" },
                { "4", "fish" },
            };
            foreach (var pet in result)
            {
                Assert.IsNotNull(pet);
                Assert.AreEqual((++count).ToString(), pet.Id);
                Assert.AreEqual(expectedPets[pet.Id], pet.Name);
            }
            return Task.CompletedTask;
        });

        [SpectorTest]
        public Task ProtocolMethod() => Test(async (host) =>
        {
            var client = new PageableClient(host, null);
            var result = client.GetServerDrivenPaginationClient().LinkAsync(new RequestContext());
            int count = 0;
            var expectedPets = new Dictionary<string, string>()
            {
                { "1", "dog" },
                { "2", "cat" },
                { "3", "bird" },
                { "4", "fish" },
            };
            await foreach (var page in result.AsPages())
            {
                Assert.IsNotNull(page);
                var pageResult = JsonNode.Parse(page.GetRawResponse().Content.ToString())!;
                foreach (var pet in (pageResult["pets"] as JsonArray)!)
                {
                    Assert.IsNotNull(pet);
                    Assert.IsNotNull(pet);
                    Assert.AreEqual((++count).ToString(), pet!["id"]!.ToString());
                    Assert.AreEqual(expectedPets[pet["id"]!.ToString()], pet["name"]!.ToString());
                }
            }
        });

        [SpectorTest]
        public Task ProtocolMethodSync() => Test((host) =>
        {
            var client = new PageableClient(host, null);
            var result = client.GetServerDrivenPaginationClient().Link(new RequestContext());
            int count = 0;
            var expectedPets = new Dictionary<string, string>()
            {
                { "1", "dog" },
                { "2", "cat" },
                { "3", "bird" },
                { "4", "fish" },
            };
            foreach (var page in result.AsPages())
            {
                Assert.IsNotNull(page);
                var pageResult = JsonNode.Parse(page.GetRawResponse().Content.ToString())!;
                foreach (var pet in (pageResult["pets"] as JsonArray)!)
                {
                    Assert.IsNotNull(pet);
                    Assert.IsNotNull(pet);
                    Assert.AreEqual((++count).ToString(), pet!["id"]!.ToString());
                    Assert.AreEqual(expectedPets[pet["id"]!.ToString()], pet["name"]!.ToString());
                }
            }
            return Task.CompletedTask;
        });

        [SpectorTest]
        public Task ContinuationTokenResumesFromNextPage() => Test(async (host) =>
        {
            var client = new PageableClient(host, null);

            // Capture the continuation token exposed by the first page.
            string? firstPageToken = null;
            await foreach (var page in client.GetServerDrivenPaginationClient().LinkAsync(new RequestContext()).AsPages())
            {
                firstPageToken = page.ContinuationToken;
                break;
            }

            // The first page must expose the token needed to fetch the NEXT page. Regression test for
            // https://github.com/Azure/azure-sdk-for-net/issues/60274, where the token pointed at the
            // current page (or was null) rather than the next one.
            Assert.IsNotNull(firstPageToken);

            // Resuming from the captured token should return the remaining pages only (pets 3 and 4).
            var resumedIds = new List<string>();
            string? lastPageToken = "unset";
            await foreach (var page in client.GetServerDrivenPaginationClient().LinkAsync(new RequestContext()).AsPages(firstPageToken))
            {
                lastPageToken = page.ContinuationToken;
                var pageResult = JsonNode.Parse(page.GetRawResponse().Content.ToString())!;
                foreach (var pet in (pageResult["pets"] as JsonArray)!)
                {
                    resumedIds.Add(pet!["id"]!.ToString());
                }
            }
            CollectionAssert.AreEqual(new[] { "3", "4" }, resumedIds);

            // The final page must expose a null continuation token to signal the end of the collection.
            Assert.IsNull(lastPageToken);
        });

        [SpectorTest]
        public Task ConvenienceMethodNested() => Test(async (host) =>
        {
            var client = new PageableClient(host, null);
            var result = client.GetServerDrivenPaginationClient().NestedLinkAsync();
            int count = 0;
            var expectedPets = new Dictionary<string, string>()
            {
                { "1", "dog" },
                { "2", "cat" },
                { "3", "bird" },
                { "4", "fish" },
            };
            await foreach (var pet in result)
            {
                Assert.IsNotNull(pet);
                Assert.AreEqual((++count).ToString(), pet.Id);
                Assert.AreEqual(expectedPets[pet.Id], pet.Name);
            }
        });

        [SpectorTest]
        public Task ConvenienceMethodNestedSync() => Test((host) =>
        {
            var client = new PageableClient(host, null);
            var result = client.GetServerDrivenPaginationClient().NestedLink();
            int count = 0;
            var expectedPets = new Dictionary<string, string>()
            {
                { "1", "dog" },
                { "2", "cat" },
                { "3", "bird" },
                { "4", "fish" },
            };
            foreach (var pet in result)
            {
                Assert.IsNotNull(pet);
                Assert.AreEqual((++count).ToString(), pet.Id);
                Assert.AreEqual(expectedPets[pet.Id], pet.Name);
            }
            return Task.CompletedTask;
        });

        [SpectorTest]
        public Task ProtocolMethodNested() => Test(async (host) =>
        {
            var client = new PageableClient(host, null);
            var result = client.GetServerDrivenPaginationClient().NestedLinkAsync(new RequestContext());
            int count = 0;
            var expectedPets = new Dictionary<string, string>()
            {
                { "1", "dog" },
                { "2", "cat" },
                { "3", "bird" },
                { "4", "fish" },
            };
            await foreach (var page in result.AsPages())
            {
                Assert.IsNotNull(page);
                var pageResult = JsonNode.Parse(page.GetRawResponse().Content.ToString())!;
                foreach (var pet in (pageResult["nestedItems"]!["pets"] as JsonArray)!)
                {
                    Assert.IsNotNull(pet);
                    Assert.IsNotNull(pet);
                    Assert.AreEqual((++count).ToString(), pet!["id"]!.ToString());
                    Assert.AreEqual(expectedPets[pet["id"]!.ToString()], pet["name"]!.ToString());
                }
            }
        });

        [SpectorTest]
        public Task ProtocolMethodNestedSync() => Test((host) =>
        {
            var client = new PageableClient(host, null);
            var result = client.GetServerDrivenPaginationClient().NestedLink(new RequestContext());
            int count = 0;
            var expectedPets = new Dictionary<string, string>()
            {
                { "1", "dog" },
                { "2", "cat" },
                { "3", "bird" },
                { "4", "fish" },
            };
            foreach (var page in result.AsPages())
            {
                Assert.IsNotNull(page);
                var pageResult = JsonNode.Parse(page.GetRawResponse().Content.ToString())!;
                foreach (var pet in (pageResult["nestedItems"]!["pets"] as JsonArray)!)
                {
                    Assert.IsNotNull(pet);
                    Assert.IsNotNull(pet);
                    Assert.AreEqual((++count).ToString(), pet!["id"]!.ToString());
                    Assert.AreEqual(expectedPets[pet["id"]!.ToString()], pet["name"]!.ToString());
                }
            }
            return Task.CompletedTask;
        });
    }
}
