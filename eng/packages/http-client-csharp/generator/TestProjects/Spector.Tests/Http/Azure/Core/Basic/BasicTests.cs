// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Nodes;
using System.Threading;
using System.Threading.Tasks;
using Specs.Azure.Core.Basic;
using Azure;
using Azure.Core;
using NUnit.Framework;

namespace TestProjects.Spector.Tests.Http.Azure.Core.Basic
{
    public class AzureCoreBasicTests : SpectorTestBase
    {
        [SpectorTest]
        public Task Azure_Core_Basic_createOrUpdate() => Test(async (host) =>
        {
            var value = new
            {
                name = "Madge"
            };
            var response = await new BasicClient(host, null).CreateOrUpdateAsync(1, RequestContent.Create(value));
            Assert.AreEqual(200, response.Status);
            JsonNode responseBody = JsonNode.Parse(response.Content!)!;
            Assert.AreEqual(1, (int)responseBody["id"]!);
            Assert.AreEqual("Madge", (string)responseBody["name"]!);
            Assert.AreEqual("11bdc430-65e8-45ad-81d9-8ffa60d55b59", (string)responseBody["etag"]!);
        });

        [SpectorTest]
        public Task Azure_Core_Basic_createOrReplace() => Test(async (host) =>
        {
            User response = await new BasicClient(host, null).CreateOrReplaceAsync(1, new User("Madge"));
            Assert.AreEqual("Madge", response.Name);
        });

        [SpectorTest]
        public Task Azure_Core_Basic_get() => Test(async (host) =>
        {
            User response = await new BasicClient(host, null).GetAsync(1);
            Assert.AreEqual("Madge", response.Name);
        });

        [SpectorTest]
        public Task Azure_Core_Basic_list() => Test(async (host) =>
        {
            AsyncPageable<User> allPages = new BasicClient(host, null).GetAllAsync(5, 10, null, new[] {"id"}, "id lt 10", new[] {"id", "orders", "etag"}, new[] {"orders"});
            await foreach (Page<User> page in allPages.AsPages())
            {
                User firstUser = page.Values.First();
                Assert.AreEqual(1, firstUser.Id);
                Assert.AreEqual("Madge", firstUser.Name);
                Assert.AreEqual("11bdc430-65e8-45ad-81d9-8ffa60d55b59", firstUser.Etag.ToString());
                Assert.AreEqual(1, firstUser.Orders.First().Id);
                Assert.AreEqual(1, firstUser.Orders.First().UserId);
                Assert.AreEqual("a recorder", firstUser.Orders.First().Detail);

                User secondUser = page.Values.Last();
                Assert.AreEqual(2, secondUser.Id);
                Assert.AreEqual("John", secondUser.Name);
                Assert.AreEqual("11bdc430-65e8-45ad-81d9-8ffa60d55b5a", secondUser.Etag.ToString());
                Assert.AreEqual(2, secondUser.Orders.First().Id);
                Assert.AreEqual(2, secondUser.Orders.First().UserId);
                Assert.AreEqual("a TV", secondUser.Orders.First().Detail);
            }
        });

        [SpectorTest]
        public Task Azure_Core_Basic_delete() => Test(async (host) =>
        {
            var response = await new BasicClient(host, null).DeleteAsync(1);
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task Azure_Core_Basic_export() => Test(async (host) =>
        {
            User response = await new BasicClient(host, null).ExportAsync(1, "json");
            Assert.AreEqual("Madge", response.Name);
        });

        [SpectorTest]
        public Task Azure_Core_Basic_exportAllUsers() => Test(async (host) =>
        {
            var response = await new BasicClient(host, null).ExportAllUsersAsync("json");
            Assert.AreEqual(1, response.Value.Users.First().Id);
            Assert.AreEqual("Madge", response.Value.Users.First().Name);
            Assert.AreEqual(2, response.Value.Users.Last().Id);
            Assert.AreEqual("John", response.Value.Users.Last().Name);
            Assert.AreEqual(2, response.Value.Users.Count());
        });

        [SpectorTest]
        public void Azure_Core_basic_RenameListMethod()
        {
            var getUsersMethod = typeof(BasicClient).GetMethod("GetAllAsync", new[] { typeof(int?), typeof(int?), typeof(int?), typeof(IEnumerable<string>), typeof(string), typeof(IEnumerable<string>), typeof(IEnumerable<string>), typeof(CancellationToken) });
            var listMethod = typeof(BasicClient).GetMethod("List", new[] { typeof(int?), typeof(int?), typeof(int?), typeof(IEnumerable<string>), typeof(string), typeof(IEnumerable<string>), typeof(IEnumerable<string>), typeof(CancellationToken) });
            Assert.IsNull(listMethod);
            Assert.IsNotNull(getUsersMethod);
        }
    }
}