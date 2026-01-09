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
            Assert.That(response.Status, Is.EqualTo(200));
            JsonNode responseBody = JsonNode.Parse(response.Content!)!;
            Assert.Multiple(() =>
            {
                Assert.That((int)responseBody["id"]!, Is.EqualTo(1));
                Assert.That((string)responseBody["name"]!, Is.EqualTo("Madge"));
                Assert.That((string)responseBody["etag"]!, Is.EqualTo("11bdc430-65e8-45ad-81d9-8ffa60d55b59"));
            });
        });

        [SpectorTest]
        public Task Azure_Core_Basic_createOrReplace() => Test(async (host) =>
        {
            User response = await new BasicClient(host, null).CreateOrReplaceAsync(1, new User("Madge"));
            Assert.That(response.Name, Is.EqualTo("Madge"));
        });

        [SpectorTest]
        public Task Azure_Core_Basic_get() => Test(async (host) =>
        {
            User response = await new BasicClient(host, null).GetAsync(1);
            Assert.That(response.Name, Is.EqualTo("Madge"));
        });

        [SpectorTest]
        public Task Azure_Core_Basic_list() => Test(async (host) =>
        {
            AsyncPageable<User> allPages = new BasicClient(host, null).GetAllAsync(5, 10, null, new[] {"id"}, "id lt 10", new[] {"id", "orders", "etag"}, new[] {"orders"});
            await foreach (Page<User> page in allPages.AsPages())
            {
                User firstUser = page.Values.First();
                Assert.Multiple(() =>
                {
                    Assert.That(firstUser.Id, Is.EqualTo(1));
                    Assert.That(firstUser.Name, Is.EqualTo("Madge"));
                    Assert.That(firstUser.Etag.ToString(), Is.EqualTo("11bdc430-65e8-45ad-81d9-8ffa60d55b59"));
                    Assert.That(firstUser.Orders.First().Id, Is.EqualTo(1));
                    Assert.That(firstUser.Orders.First().UserId, Is.EqualTo(1));
                    Assert.That(firstUser.Orders.First().Detail, Is.EqualTo("a recorder"));
                });

                User secondUser = page.Values.Last();
                Assert.Multiple(() =>
                {
                    Assert.That(secondUser.Id, Is.EqualTo(2));
                    Assert.That(secondUser.Name, Is.EqualTo("John"));
                    Assert.That(secondUser.Etag.ToString(), Is.EqualTo("11bdc430-65e8-45ad-81d9-8ffa60d55b5a"));
                    Assert.That(secondUser.Orders.First().Id, Is.EqualTo(2));
                    Assert.That(secondUser.Orders.First().UserId, Is.EqualTo(2));
                    Assert.That(secondUser.Orders.First().Detail, Is.EqualTo("a TV"));
                });
            }
        });

        [SpectorTest]
        public Task Azure_Core_Basic_delete() => Test(async (host) =>
        {
            var response = await new BasicClient(host, null).DeleteAsync(1);
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task Azure_Core_Basic_export() => Test(async (host) =>
        {
            User response = await new BasicClient(host, null).ExportAsync(1, "json");
            Assert.That(response.Name, Is.EqualTo("Madge"));
        });

        [SpectorTest]
        public Task Azure_Core_Basic_exportAllUsers() => Test(async (host) =>
        {
            var response = await new BasicClient(host, null).ExportAllUsersAsync("json");
            Assert.Multiple(() =>
            {
                Assert.That(response.Value.Users.First().Id, Is.EqualTo(1));
                Assert.That(response.Value.Users.First().Name, Is.EqualTo("Madge"));
                Assert.That(response.Value.Users.Last().Id, Is.EqualTo(2));
                Assert.That(response.Value.Users.Last().Name, Is.EqualTo("John"));
                Assert.That(response.Value.Users.Count(), Is.EqualTo(2));
            });
        });

        [SpectorTest]
        public void Azure_Core_basic_RenameListMethod()
        {
            var getUsersMethod = typeof(BasicClient).GetMethod("GetAllAsync", new[] { typeof(int?), typeof(int?), typeof(int?), typeof(IEnumerable<string>), typeof(string), typeof(IEnumerable<string>), typeof(IEnumerable<string>), typeof(CancellationToken) });
            var listMethod = typeof(BasicClient).GetMethod("List", new[] { typeof(int?), typeof(int?), typeof(int?), typeof(IEnumerable<string>), typeof(string), typeof(IEnumerable<string>), typeof(IEnumerable<string>), typeof(CancellationToken) });
            Assert.Multiple(() =>
            {
                Assert.That(listMethod, Is.Null);
                Assert.That(getUsersMethod, Is.Not.Null);
            });
        }
    }
}