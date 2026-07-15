// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.AgentServer.Core.Storage;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Core.Tests.Storage;

[TestFixture]
public class FoundryStateStoreTests
{
    private const string BaseUrl = "https://foundry.example.com/storage/";
    private const string DefaultName = "langGraphCheckpoints/thread-abc";

    private static string Enc(string value)
    {
        string encoded = Convert.ToBase64String(Encoding.UTF8.GetBytes(value));
        return encoded.TrimEnd('=').Replace('+', '-').Replace('/', '_');
    }

    private static FoundryStateStore MakeStore(
        MockTransport transport,
        string name = DefaultName,
        bool userIsolation = false,
        int itemTtlSeconds = 2592000,
        string? description = null,
        IReadOnlyDictionary<string, string>? tags = null,
        string? userId = null)
    {
        var options = new FoundryStorageClientOptions { Transport = transport };
        var endpoint = new FoundryStorageEndpoint(BaseUrl);
        return new FoundryStateStore(
            name, new MockCredential(), endpoint, userIsolation, itemTtlSeconds, description, tags, userId, options);
    }

    private static MockResponse Json(int status, string json, params (string Name, string Value)[] headers)
    {
        var response = new MockResponse(status);
        response.SetContent(json);
        foreach ((string name, string value) in headers)
        {
            response.AddHeader(name, value);
        }

        return response;
    }

    private static string BodyOf(MockRequest request)
    {
        using var stream = new MemoryStream();
        request.Content!.WriteTo(stream, CancellationToken.None);
        return Encoding.UTF8.GetString(stream.ToArray());
    }

    private static JsonElement BodyJson(MockRequest request) => JsonDocument.Parse(BodyOf(request)).RootElement;

    private static string StoreBody(
        string name = "checkpoints",
        bool userIsolation = false,
        int itemTtlSeconds = 2592000,
        string? description = null,
        string tags = "{}",
        int createdAt = 1,
        int updatedAt = 1)
    {
        string desc = description is null ? "null" : $"\"{description}\"";
        return $$"""
            {"id":"ss_1","object":"state_store","name":"{{name}}","user_isolation":{{(userIsolation ? "true" : "false")}},"item_ttl_seconds":{{itemTtlSeconds}},"description":{{desc}},"tags":{{tags}},"created_at":{{createdAt}},"updated_at":{{updatedAt}}}
            """;
    }

    // -- get_or_create orchestration -----------------------------------------

    [Test]
    public async Task GetOrCreate_ReturnsExistingStore_WhenPresent()
    {
        var transport = new MockTransport(Json(200, StoreBody()));

        FoundryStateStore store = await FoundryStateStore.GetOrCreateAsync(
            "checkpoints", new MockCredential(), new Uri("https://foundry.example.com/"), false, 2592000,
            null, null, null, "v1", new FoundryStorageClientOptions { Transport = transport }, CancellationToken.None);

        Assert.That(transport.Requests, Has.Count.EqualTo(1));
        Assert.That(transport.Requests[0].Method, Is.EqualTo(RequestMethod.Get));
        Assert.That(store.Name, Is.EqualTo("checkpoints"));
    }

    [Test]
    public async Task GetOrCreate_CreatesStore_WhenAbsent()
    {
        var transport = new MockTransport(
            Json(404, """{"error":{"message":"not found"}}"""),
            Json(201, StoreBody()));

        FoundryStateStore store = await FoundryStateStore.GetOrCreateAsync(
            "checkpoints", new MockCredential(), new Uri("https://foundry.example.com/"), false, 2592000,
            null, null, null, "v1", new FoundryStorageClientOptions { Transport = transport }, CancellationToken.None);

        Assert.That(transport.Requests, Has.Count.EqualTo(2));
        Assert.That(transport.Requests[0].Method, Is.EqualTo(RequestMethod.Get));
        Assert.That(transport.Requests[1].Method, Is.EqualTo(RequestMethod.Post));
        Assert.That(transport.Requests[1].Uri.ToString(), Is.EqualTo($"{BaseUrl}state_stores?api-version=v1"));
        Assert.That(store.Name, Is.EqualTo("checkpoints"));
    }

    [Test]
    public async Task GetOrCreate_Refetches_WhenCreateRaces()
    {
        var transport = new MockTransport(
            Json(404, """{"error":{"message":"not found"}}"""),
            Json(409, """{"error":{"message":"duplicate store"}}"""),
            Json(200, StoreBody()));

        FoundryStateStore store = await FoundryStateStore.GetOrCreateAsync(
            "checkpoints", new MockCredential(), new Uri("https://foundry.example.com/"), false, 2592000,
            null, null, null, "v1", new FoundryStorageClientOptions { Transport = transport }, CancellationToken.None);

        Assert.That(transport.Requests, Has.Count.EqualTo(3));
        Assert.That(store.Name, Is.EqualTo("checkpoints"));
    }

    [Test]
    public async Task GetOrCreate_ForwardsCreationOptions()
    {
        var transport = new MockTransport(
            Json(404, """{"error":{"message":"not found"}}"""),
            Json(201, StoreBody("checkpoints", true, 600, "checkpoint store", """{"team":"agents"}""")));

        await FoundryStateStore.GetOrCreateAsync(
            "checkpoints", new MockCredential(), new Uri("https://foundry.example.com/"), true, 600,
            "checkpoint store", new Dictionary<string, string> { ["team"] = "agents" }, null, "v1",
            new FoundryStorageClientOptions { Transport = transport }, CancellationToken.None);

        JsonElement body = BodyJson(transport.Requests[1]);
        Assert.That(body.GetProperty("name").GetString(), Is.EqualTo("checkpoints"));
        Assert.That(body.GetProperty("user_isolation").GetBoolean(), Is.True);
        Assert.That(body.GetProperty("item_ttl_seconds").GetInt32(), Is.EqualTo(600));
        Assert.That(body.GetProperty("description").GetString(), Is.EqualTo("checkpoint store"));
        Assert.That(body.GetProperty("tags").GetProperty("team").GetString(), Is.EqualTo("agents"));
    }

    // -- get / get_item ------------------------------------------------------

    [Test]
    public async Task Get_ReturnsStoreDescriptor()
    {
        var transport = new MockTransport(Json(200, StoreBody(DefaultName, updatedAt: 2)));
        FoundryStateStore store = MakeStore(transport, name: DefaultName);

        StateStore? result = await store.GetAsync();

        MockRequest request = transport.SingleRequest;
        Assert.That(request.Method, Is.EqualTo(RequestMethod.Get));
        Assert.That(request.Uri.ToString(), Is.EqualTo($"{BaseUrl}state_stores/{Enc(DefaultName)}?api-version=v1"));
        Assert.That(request.Headers.TryGetValue("x-ms-user-id", out _), Is.False);
        Assert.That(result, Is.Not.Null);
        Assert.That(result!.Name, Is.EqualTo(DefaultName));
        Assert.That(result.Id, Is.EqualTo("ss_1"));
    }

    [Test]
    public async Task Get_ReturnsNull_WhenStoreAbsent()
    {
        var transport = new MockTransport(Json(404, """{"error":{"message":"not found"}}"""));
        FoundryStateStore store = MakeStore(transport, name: "checkpoints");

        Assert.That(await store.GetAsync(), Is.Null);
    }

    [Test]
    public async Task GetItem_ReturnsItemWithValueAndMetadata()
    {
        var transport = new MockTransport(Json(
            200,
            """{"id":"it_1","object":"state_store.item","key":"step/1","value":{"done":true},"tags":{"kind":"checkpoint"},"etag":"\"0x8DD\"","created_at":10,"updated_at":20}"""));
        FoundryStateStore store = MakeStore(transport, name: "checkpoints", userId: "user-42");

        StateStoreItem? result = await store.GetItemAsync("step/1");

        MockRequest request = transport.SingleRequest;
        Assert.That(request.Method, Is.EqualTo(RequestMethod.Get));
        Assert.That(request.Headers.TryGetValue("x-ms-user-id", out string? uid), Is.True);
        Assert.That(uid, Is.EqualTo("user-42"));
        Assert.That(
            request.Uri.ToString(),
            Is.EqualTo($"{BaseUrl}state_stores/{Enc("checkpoints")}/items/{Enc("step/1")}?api-version=v1"));
        Assert.That(result, Is.Not.Null);
        Assert.That(result!.Key, Is.EqualTo("step/1"));
        Assert.That(result.Value["done"].ToString(), Is.EqualTo("true"));
        Assert.That(result.Tags["kind"], Is.EqualTo("checkpoint"));
    }

    [Test]
    public async Task GetItem_ReturnsNull_WhenItemAbsent()
    {
        var transport = new MockTransport(Json(404, """{"error":{"message":"not found"}}"""));
        FoundryStateStore store = MakeStore(transport, name: "checkpoints");

        Assert.That(await store.GetItemAsync("missing"), Is.Null);
    }

    // -- update --------------------------------------------------------------

    [Test]
    public async Task Update_SendsOnlyPresentFields()
    {
        var transport = new MockTransport(Json(
            200, StoreBody("prefs", description: "updated", tags: """{"env":"prod"}""", updatedAt: 3)));
        FoundryStateStore store = MakeStore(transport, name: "prefs");

        StateStore result = await store.UpdateAsync(new StateStoreUpdateOptions
        {
            Description = "updated",
            Tags = new Dictionary<string, string> { ["env"] = "prod" },
        });

        MockRequest request = transport.SingleRequest;
        Assert.That(request.Method, Is.EqualTo(RequestMethod.Patch));
        Assert.That(request.Uri.ToString(), Is.EqualTo($"{BaseUrl}state_stores/{Enc("prefs")}?api-version=v1"));
        JsonElement body = BodyJson(request);
        Assert.That(body.GetProperty("description").GetString(), Is.EqualTo("updated"));
        Assert.That(body.GetProperty("tags").GetProperty("env").GetString(), Is.EqualTo("prod"));
        Assert.That(result.UpdatedAt, Is.EqualTo(3));
    }

    // -- delete / delete_item ------------------------------------------------

    [Test]
    public async Task Delete_DeletesStore()
    {
        var transport = new MockTransport(Json(
            200, """{"id":"ss_1","object":"state_store","name":"prefs","deleted":true}"""));
        FoundryStateStore store = MakeStore(transport, name: "prefs");

        DeletedStateStore result = await store.DeleteAsync();

        MockRequest request = transport.SingleRequest;
        Assert.That(request.Method, Is.EqualTo(RequestMethod.Delete));
        Assert.That(request.Uri.ToString(), Is.EqualTo($"{BaseUrl}state_stores/{Enc("prefs")}?api-version=v1"));
        Assert.That(request.Headers.TryGetValue("x-ms-user-id", out _), Is.False);
        Assert.That(result.Deleted, Is.True);
    }

    [Test]
    public async Task DeleteItem_ReturnsMarkerAndSendsHeaders()
    {
        var transport = new MockTransport(Json(
            200, """{"id":"it_1","object":"state_store.item","key":"step/1","deleted":true}"""));
        FoundryStateStore store = MakeStore(transport, name: "checkpoints", userId: "user-42");

        DeletedStateStoreItem result = await store.DeleteItemAsync("step/1", ifMatch: "\"0x8DD\"");

        MockRequest request = transport.SingleRequest;
        Assert.That(request.Method, Is.EqualTo(RequestMethod.Delete));
        Assert.That(request.Headers.TryGetValue("If-Match", out string? ifMatch), Is.True);
        Assert.That(ifMatch, Is.EqualTo("\"0x8DD\""));
        Assert.That(request.Headers.TryGetValue("x-ms-user-id", out string? uid), Is.True);
        Assert.That(uid, Is.EqualTo("user-42"));
        Assert.That(result.Deleted, Is.True);
    }

    // -- create_item / set_item ----------------------------------------------

    [Test]
    public async Task CreateItem_PostsKeyValueAndTags()
    {
        var transport = new MockTransport(Json(
            201, """{"id":"it_1","object":"state_store.item","key":"step/1","etag":"\"0x8DC\"","created_at":10,"updated_at":10}"""));
        FoundryStateStore store = MakeStore(transport, name: "checkpoints");

        StateStoreItemRef result = await store.CreateItemAsync(
            "step/1",
            new Dictionary<string, BinaryData> { ["done"] = BinaryData.FromObjectAsJson(false) },
            new Dictionary<string, string> { ["kind"] = "checkpoint" });

        MockRequest request = transport.SingleRequest;
        Assert.That(request.Method, Is.EqualTo(RequestMethod.Post));
        Assert.That(request.Uri.ToString(), Is.EqualTo($"{BaseUrl}state_stores/{Enc("checkpoints")}/items?api-version=v1"));
        Assert.That(request.Headers.TryGetValue("If-Match", out _), Is.False);
        JsonElement body = BodyJson(request);
        Assert.That(body.GetProperty("key").GetString(), Is.EqualTo("step/1"));
        Assert.That(body.GetProperty("value").GetProperty("done").GetBoolean(), Is.False);
        Assert.That(body.GetProperty("tags").GetProperty("kind").GetString(), Is.EqualTo("checkpoint"));
        Assert.That(result.Etag, Is.EqualTo("\"0x8DC\""));
    }

    [Test]
    public async Task SetItem_PutsValueAndIfMatchHeader()
    {
        var transport = new MockTransport(Json(
            200,
            """{"id":"it_1","object":"state_store.item","key":"step/1","etag":"\"0x8DD\"","created_at":10,"updated_at":20}""",
            ("ETag", "\"0x8DD\"")));
        FoundryStateStore store = MakeStore(transport, name: "checkpoints");

        StateStoreItemRef result = await store.SetItemAsync(
            "step/1",
            new Dictionary<string, BinaryData> { ["done"] = BinaryData.FromObjectAsJson(true) },
            new Dictionary<string, string> { ["kind"] = "checkpoint" },
            ifMatch: "\"0x8DC\"");

        MockRequest request = transport.SingleRequest;
        Assert.That(request.Method, Is.EqualTo(RequestMethod.Put));
        Assert.That(
            request.Uri.ToString(),
            Is.EqualTo($"{BaseUrl}state_stores/{Enc("checkpoints")}/items/{Enc("step/1")}?api-version=v1"));
        Assert.That(request.Headers.TryGetValue("If-Match", out string? ifMatch), Is.True);
        Assert.That(ifMatch, Is.EqualTo("\"0x8DC\""));
        JsonElement body = BodyJson(request);
        Assert.That(body.GetProperty("value").GetProperty("done").GetBoolean(), Is.True);
        Assert.That(body.GetProperty("tags").GetProperty("kind").GetString(), Is.EqualTo("checkpoint"));
        Assert.That(result.Etag, Is.EqualTo("\"0x8DD\""));
    }

    [Test]
    public async Task SetItem_RequireExists_UsesWildcardIfMatch()
    {
        var transport = new MockTransport(Json(
            200, """{"id":"it_1","object":"state_store.item","key":"step/1","etag":"\"0x8DD\"","created_at":10,"updated_at":20}"""));
        FoundryStateStore store = MakeStore(transport, name: "checkpoints");

        await store.SetItemAsync(
            "step/1",
            new Dictionary<string, BinaryData> { ["done"] = BinaryData.FromObjectAsJson(true) },
            requireExists: true);

        Assert.That(transport.SingleRequest.Headers.TryGetValue("If-Match", out string? ifMatch), Is.True);
        Assert.That(ifMatch, Is.EqualTo("*"));
    }

    [Test]
    public void SetItem_IfMatchAndRequireExists_AreMutuallyExclusive()
    {
        FoundryStateStore store = MakeStore(new MockTransport(Json(200, "{}")), name: "checkpoints");

        Assert.That(
            async () => await store.SetItemAsync(
                "step/1",
                new Dictionary<string, BinaryData> { ["done"] = BinaryData.FromObjectAsJson(true) },
                ifMatch: "\"0x8DC\"",
                requireExists: true),
            Throws.InstanceOf<ArgumentException>());
    }

    // -- list_keys -----------------------------------------------------------

    [Test]
    public async Task ListKeys_UsesQueryParametersAndReturnsPage()
    {
        var transport = new MockTransport(Json(
            200,
            """{"object":"list","data":[{"id":"it_1","object":"state_store.item","key":"step/1","tags":{"kind":"checkpoint"},"etag":"\"0x8DD\"","created_at":10,"updated_at":20}],"first_id":"it_1","last_id":"it_1","has_more":false}"""));
        FoundryStateStore store = MakeStore(transport, name: "checkpoints", userId: "user-42");

        StateStoreItemKeyPage page = await store.ListKeysAsync(
            tags: new Dictionary<string, string> { ["kind"] = "checkpoint" },
            limit: 10,
            after: "it_0",
            order: ListRequestOrder.Asc);

        MockRequest request = transport.SingleRequest;
        Assert.That(request.Method, Is.EqualTo(RequestMethod.Get));
        Assert.That(request.Headers.TryGetValue("x-ms-user-id", out string? uid), Is.True);
        Assert.That(uid, Is.EqualTo("user-42"));
        string url = request.Uri.ToString();
        Assert.That(url, Does.StartWith($"{BaseUrl}state_stores/{Enc("checkpoints")}/items:keys?api-version=v1"));
        Assert.That(url, Does.Contain("tags.kind=checkpoint"));
        Assert.That(url, Does.Contain("limit=10"));
        Assert.That(url, Does.Contain("after=it_0"));
        Assert.That(url, Does.Contain("order=asc"));
        Assert.That(page.Keys, Has.Count.EqualTo(1));
        Assert.That(page.Keys[0].Key, Is.EqualTo("step/1"));
        Assert.That(page.FirstId, Is.EqualTo("it_1"));
        Assert.That(page.LastId, Is.EqualTo("it_1"));
        Assert.That(page.HasMore, Is.False);
    }

    [Test]
    public async Task ListKeys_DefaultsToDescendingOrder()
    {
        var transport = new MockTransport(Json(200, """{"object":"list","data":[],"has_more":false}"""));
        FoundryStateStore store = MakeStore(transport, name: "checkpoints");

        await store.ListKeysAsync();

        Assert.That(
            transport.SingleRequest.Uri.ToString(),
            Is.EqualTo($"{BaseUrl}state_stores/{Enc("checkpoints")}/items:keys?api-version=v1&order=desc"));
    }

    [Test]
    public void ListKeys_AfterAndBefore_AreMutuallyExclusive()
    {
        FoundryStateStore store = MakeStore(new MockTransport(Json(200, "{}")), name: "checkpoints");

        Assert.That(
            async () => await store.ListKeysAsync(after: "it_0", before: "it_9"),
            Throws.InstanceOf<ArgumentException>());
    }

    [Test]
    public void EmptyItemKey_IsRejected()
    {
        FoundryStateStore store = MakeStore(new MockTransport(Json(200, "{}")), name: "checkpoints");

        Assert.That(
            async () => await store.GetItemAsync(string.Empty),
            Throws.InstanceOf<ArgumentException>());
    }
}
