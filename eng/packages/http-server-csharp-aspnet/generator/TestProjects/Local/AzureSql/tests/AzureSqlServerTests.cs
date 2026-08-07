// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using NUnit.Framework;

namespace Azure.TypeSpec.Generator.AspNetServer.AzureSql.Tests
{
    [NonParallelizable]
    public class AzureSqlServerTests
    {
        private const string ApiVersion = "2026-02-01";
        private WebApplicationFactory<Program> _factory = null!;
        private HttpClient _client = null!;

        [SetUp]
        public void SetUp()
        {
            _factory = new WebApplicationFactory<Program>();
            _client = _factory.CreateClient();
        }

        [TearDown]
        public void TearDown()
        {
            _client.Dispose();
            _factory.Dispose();
        }

        [Test]
        public async Task GetDatabaseUsesGeneratedRouteAndReturnsResource()
        {
            using var response = await _client.GetAsync(WithApiVersion("/subscriptions/sub/resourceGroups/rg/providers/Microsoft.Sql/databases/db"));

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            using var payload = await JsonDocument.ParseAsync(await response.Content.ReadAsStreamAsync());
            var root = payload.RootElement;
            Assert.That(root.GetProperty("name").GetString(), Is.EqualTo("db"));
            Assert.That(root.GetProperty("type").GetString(), Is.EqualTo("Microsoft.Sql/databases"));
            Assert.That(root.GetProperty("tags").GetProperty("scenario").GetString(), Is.EqualTo("existing-project"));
            Assert.That(root.GetProperty("properties").GetProperty("status").GetString(), Is.EqualTo("Online"));
            Assert.That(root.GetProperty("properties").GetProperty("elasticPoolId").GetString(), Is.EqualTo("/subscriptions/sub/resourceGroups/rg/providers/Microsoft.Sql/elasticPools/pool1"));
        }

        [Test]
        public async Task ListDatabasesUsesGeneratedRouteAndReturnsPage()
        {
            using var response = await _client.GetAsync(WithApiVersion("/subscriptions/sub/resourceGroups/rg/providers/Microsoft.Sql/databases"));

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            using var payload = await JsonDocument.ParseAsync(await response.Content.ReadAsStreamAsync());
            var values = payload.RootElement.GetProperty("value");
            Assert.That(values.GetArrayLength(), Is.EqualTo(2));
            Assert.That(values[0].GetProperty("name").GetString(), Is.EqualTo("database1"));
            Assert.That(values[0].GetProperty("tags").GetProperty("scenario").GetString(), Is.EqualTo("existing-project"));
            Assert.That(values[1].GetProperty("name").GetString(), Is.EqualTo("database2"));
        }

        [Test]
        public async Task CreateOrUpdateDatabaseBindsBodyAndRouteValues()
        {
            var resource = new
            {
                location = "eastus",
                tags = new Dictionary<string, string>
                {
                    ["environment"] = "test"
                },
                properties = new
                {
                    collation = "Latin1_General_100_CI_AS",
                    maxSizeBytes = 1024
                }
            };

            using var response = await _client.PutAsJsonAsync(
                WithApiVersion("/subscriptions/sub/resourceGroups/rg/providers/Microsoft.Sql/databases/db"),
                resource);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            using var payload = await JsonDocument.ParseAsync(await response.Content.ReadAsStreamAsync());
            var root = payload.RootElement;
            Assert.That(root.GetProperty("id").GetString(), Is.EqualTo("/subscriptions/sub/resourceGroups/rg/providers/Microsoft.Sql/databases/db"));
            Assert.That(root.GetProperty("name").GetString(), Is.EqualTo("db"));
            Assert.That(root.GetProperty("tags").GetProperty("environment").GetString(), Is.EqualTo("test"));
            Assert.That(root.GetProperty("properties").GetProperty("collation").GetString(), Is.EqualTo("Latin1_General_100_CI_AS"));
        }

        [Test]
        public async Task UnsupportedApiVersionIsRejected()
        {
            using var response = await _client.GetAsync("/subscriptions/sub/resourceGroups/rg/providers/Microsoft.Sql/databases/db?api-version=2025-01-01");

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        }

        private static string WithApiVersion(string path, string apiVersion = ApiVersion) => $"{path}?api-version={apiVersion}";
    }
}
