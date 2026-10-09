// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using Azure.AI.AgentServer.Core;
using Azure.AI.AgentServer.Responses.Internal;
using Azure.AI.AgentServer.Responses.Internal.Resilience;
using Azure.AI.AgentServer.Responses.Models;
using Microsoft.Extensions.Options;

namespace Azure.AI.AgentServer.Responses.Tests.Provider;

[TestFixture(false)]
[TestFixture(true)]
public class ResponseStoreIsolationTests
{
    private readonly bool _fileBacked;
    private string _directory = null!;
    private ResponsesProvider _provider = null!;

    public ResponseStoreIsolationTests(bool fileBacked) => _fileBacked = fileBacked;

    [SetUp]
    public void SetUp()
    {
        _directory = Path.Combine(TestContext.CurrentContext.WorkDirectory, "response-store-" + Guid.NewGuid().ToString("N"));
        _provider = NewProvider();
    }

    [TearDown]
    public void TearDown()
    {
        (_provider as IDisposable)?.Dispose();
        if (Directory.Exists(_directory))
        {
            Directory.Delete(_directory, recursive: true);
        }
    }

    private ResponsesProvider NewProvider() => _fileBacked
        ? new FileResponsesProvider(_directory)
        : new InMemoryResponsesProvider(Options.Create(new InMemoryProviderOptions()), TimeProvider.System);

    private ResponsesProvider RestartIfDurable() => _fileBacked ? NewProvider() : _provider;

    private static ResponseObject Response(string id, string label)
    {
        var response = new ResponseObject(id, label)
        {
            Status = ResponseStatus.Completed,
            Conversation = new ConversationReference("conv_shared"),
        };
        response.Output.Add(new OutputItemMessage("msg_output", MessageStatus.Completed, MessageRole.Assistant,
            new MessageContent[] { new MessageContentOutputTextContent(label, Array.Empty<Annotation>(), Array.Empty<LogProb>()) }));
        return response;
    }

    private static Task CreateAsync(ResponsesProvider provider, PlatformContext context, string label, string id = "resp_shared") =>
        provider.CreateResponseAsync(new CreateResponseRequest(Response(id, label),
            new OutputItem[] { new OutputItemMessage("msg_input", MessageStatus.Completed, MessageRole.User, Array.Empty<MessageContent>()) },
            null), context);

    [TestCase("user-a", "user-b")]
    [TestCase(null, "user-b")]
    [TestCase("user-a", null)]
    [TestCase(null, "anonymous")]
    [TestCase(null, "")]
    [TestCase("User", "user")]
    public async Task All_Lookups_Are_Scoped_To_The_User(string? ownerId, string? otherId)
    {
        var owner = new PlatformContext(ownerId, "call-a");
        var other = new PlatformContext(otherId, "call-a");
        await CreateAsync(_provider, owner, "owner");
        var reader = RestartIfDurable();

        Assert.ThrowsAsync<ResourceNotFoundException>(() => reader.GetResponseAsync("resp_shared", other));
        Assert.ThrowsAsync<ResourceNotFoundException>(() => reader.GetInputItemsAsync("resp_shared", other));
        Assert.ThrowsAsync<ResourceNotFoundException>(() => reader.DeleteResponseAsync("resp_shared", other));
        Assert.ThrowsAsync<ResourceNotFoundException>(() => reader.UpdateResponseAsync(Response("resp_shared", "other"), other));
        Assert.That(await reader.GetItemsAsync(new[] { "msg_input", "msg_output", "missing" }, other), Is.All.Null);
        Assert.That(await reader.GetHistoryItemIdsAsync("resp_shared", null, 100, other), Is.Empty);
        Assert.That(await reader.GetHistoryItemIdsAsync(null, "conv_shared", 100, other), Is.Empty);

        var sameUserNewCall = new PlatformContext(ownerId, "call-b");
        Assert.That((await reader.GetResponseAsync("resp_shared", sameUserNewCall)).Model, Is.EqualTo("owner"));
        Assert.That(await reader.GetHistoryItemIdsAsync("resp_shared", null, 100, sameUserNewCall),
            Is.EqualTo(new[] { "msg_input", "msg_output" }));
        Assert.That(await reader.GetItemsAsync(new[] { "msg_output" }, sameUserNewCall), Is.All.Not.Null);
    }

    [Test]
    public async Task Identical_Ids_Have_Independent_Lifecycles_And_Retained_History()
    {
        var first = new PlatformContext("user-a", null);
        var second = new PlatformContext("user-b", null);
        await Task.WhenAll(
            Task.Run(() => CreateAsync(_provider, first, "first")),
            Task.Run(() => CreateAsync(_provider, second, "second")));

        await _provider.UpdateResponseAsync(Response("resp_shared", "updated"), first);
        Assert.That((await _provider.GetResponseAsync("resp_shared", second)).Model, Is.EqualTo("second"));
        await _provider.DeleteResponseAsync("resp_shared", first);
        var reader = RestartIfDurable();

        Assert.ThrowsAsync<ResourceNotFoundException>(() => reader.GetResponseAsync("resp_shared", first));
        Assert.ThrowsAsync<ResourceNotFoundException>(() => reader.GetInputItemsAsync("resp_shared", first));
        Assert.ThrowsAsync<ResourceNotFoundException>(() => reader.UpdateResponseAsync(Response("resp_shared", "resurrected"), first));
        Assert.ThrowsAsync<InvalidOperationException>(() => CreateAsync(reader, first, "duplicate"));
        Assert.That((await reader.GetResponseAsync("resp_shared", second)).Model, Is.EqualTo("second"));
        foreach (var context in new[] { first, second })
        {
            Assert.That(await reader.GetHistoryItemIdsAsync(null, "conv_shared", 100, context),
                Is.EqualTo(new[] { "msg_input", "msg_output" }));
            var output = (OutputItemMessage)(await reader.GetItemsAsync(new[] { "msg_output" }, context)).Single()!;
            Assert.That(((MessageContentOutputTextContent)output.Content.Single()).Text,
                Is.EqualTo(context == first ? "updated" : "second"));
        }
    }

    [Test]
    public async Task Foreign_History_Ids_Do_Not_Resolve_In_New_Response()
    {
        var first = new PlatformContext("user-a", null);
        var second = new PlatformContext("user-b", null);
        await CreateAsync(_provider, first, "first");
        await _provider.CreateResponseAsync(new CreateResponseRequest(
            new ResponseObject("resp_other", "test"), null, new[] { "msg_input", "msg_output" }), second);
        Assert.That((await RestartIfDurable().GetInputItemsAsync("resp_other", second)).Data, Is.Empty);
    }

    [Test]
    public async Task Cancelled_Operations_Do_Not_Change_Stored_State()
    {
        var context = new PlatformContext("user-a", null);
        await CreateAsync(_provider, context, "original");
        var cancelled = new CancellationToken(canceled: true);
        Assert.ThrowsAsync<OperationCanceledException>(() => _provider.CreateResponseAsync(
            new CreateResponseRequest(Response("resp_new", "new"), null, null), context, cancelled));
        Assert.ThrowsAsync<OperationCanceledException>(() => _provider.UpdateResponseAsync(Response("resp_shared", "changed"), context, cancelled));
        Assert.ThrowsAsync<OperationCanceledException>(() => _provider.DeleteResponseAsync("resp_shared", context, cancelled));
        Assert.ThrowsAsync<OperationCanceledException>(() => _provider.GetResponseAsync("resp_shared", context, cancelled));
        Assert.ThrowsAsync<OperationCanceledException>(() => _provider.GetInputItemsAsync("resp_shared", context, cancellationToken: cancelled));
        Assert.ThrowsAsync<OperationCanceledException>(() => _provider.GetItemsAsync(new[] { "msg_output" }, context, cancelled));
        Assert.ThrowsAsync<OperationCanceledException>(() => _provider.GetHistoryItemIdsAsync("resp_shared", null, 100, context, cancelled));
        Assert.That((await RestartIfDurable().GetResponseAsync("resp_shared", context)).Model, Is.EqualTo("original"));
    }

    [Test]
    public async Task Concurrent_Create_Has_One_Winner_Per_User()
    {
        var context = new PlatformContext("user-a", null);
        var results = await Task.WhenAll(Enumerable.Range(0, 16).Select(i => Task.Run(async () =>
        {
            try
            {
                await CreateAsync(_provider, context, i.ToString());
                return true;
            }
            catch (InvalidOperationException)
            {
                return false;
            }
        })));
        Assert.That(results.Count(won => won), Is.EqualTo(1));
        var reader = RestartIfDurable();
        var response = await reader.GetResponseAsync("resp_shared", context);
        var item = (OutputItemMessage)(await reader.GetItemsAsync(new[] { "msg_output" }, context)).Single()!;
        Assert.That(((MessageContentOutputTextContent)item.Content.Single()).Text, Is.EqualTo(response.Model));
    }

    [Test]
    public async Task Concurrent_Update_And_Delete_Cannot_Resurrect_Response()
    {
        var owner = new PlatformContext("user-a", null);
        var other = new PlatformContext("user-b", null);
        await CreateAsync(_provider, owner, "owner");
        await CreateAsync(_provider, other, "other");
        await Task.WhenAll(
            Task.Run(() => _provider.DeleteResponseAsync("resp_shared", owner)),
            Task.Run(async () =>
            {
                try
                {
                    await _provider.UpdateResponseAsync(Response("resp_shared", "updated"), owner);
                }
                catch (ResourceNotFoundException)
                {
                    // The delete won the race.
                }
            }));
        var reader = RestartIfDurable();
        Assert.ThrowsAsync<ResourceNotFoundException>(() => reader.GetResponseAsync("resp_shared", owner));
        Assert.That((await reader.GetResponseAsync("resp_shared", other)).Model, Is.EqualTo("other"));
    }

    [Test]
    public async Task File_Keys_Are_Stable_And_Cannot_Escape_The_Partition()
    {
        var context = new PlatformContext(@"..\user/one", null);
        const string responseId = @"..\..\outside/response";
        await CreateAsync(_provider, context, "owner", responseId);
        Assert.That((await RestartIfDurable().GetResponseAsync(responseId, context)).Model, Is.EqualTo("owner"));
        if (_fileBacked)
        {
            var partitions = Directory.GetDirectories(Path.Combine(_directory, "partitions-v1"));
            Assert.That(partitions.Select(Path.GetFileName), Is.EqualTo(new[]
            {
                ResponseStorePartition.FromContext(context).DirectoryName,
            }));
            Assert.That(Directory.GetFiles(_directory, "*.json", SearchOption.AllDirectories)
                .Select(Path.GetFileNameWithoutExtension), Is.All.Matches<string>(name => name.Length == 64 && name.All(Uri.IsHexDigit)));
        }
    }
}
