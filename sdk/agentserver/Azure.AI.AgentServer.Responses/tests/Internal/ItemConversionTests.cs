// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Nodes;
using Azure.AI.AgentServer.Responses.Internal.Resilience;
using Azure.AI.AgentServer.Responses.Models;
using Azure.AI.AgentServer.Responses.Tests.Helpers;
using OpenAI.Responses;

namespace Azure.AI.AgentServer.Responses.Tests.Internal;

/// <summary>
/// Input items and output items are the same type (<c>OpenAI.Responses.ResponseItem</c>),
/// so <see cref="ItemConversion"/> no longer maps between two parallel hierarchies. What it
/// still does — and what these tests cover — is assign a type-prefixed ID, leave the caller's
/// instance untouched, drop non-convertible references, and strip server-internal metadata on
/// the way back out.
/// </summary>
public class ItemConversionTests
{
    private const string PartitionKeyHint = "resp_test";

    private static IEnumerable<TestCaseData> IdPrefixCases()
    {
        yield return new TestCaseData(MessageItemFactory.Message(MessageRole.User, "hi"), "msg_")
            .SetName("Message");
        yield return new TestCaseData(
            new FunctionCallResponseItem("call_1", "fn", BinaryData.FromString("{}")), "fc_")
            .SetName("FunctionCall");
        yield return new TestCaseData(new WebSearchCallResponseItem(), "ws_")
            .SetName("WebSearchCall");
        yield return new TestCaseData(new ReasoningResponseItem("thinking"), "rs_")
            .SetName("Reasoning");
        yield return new TestCaseData(
            new McpToolCallItem("server", "tool", BinaryData.FromString("{}")), "mcp_")
            .SetName("McpToolCall");
    }

    [TestCaseSource(nameof(IdPrefixCases))]
    public void ToOutputItem_AssignsTypePrefixedId(Item item, string expectedPrefix)
    {
        var result = ItemConversion.ToOutputItem(item, PartitionKeyHint);

        Assert.That(result, Is.Not.Null);
        XAssert.StartsWith(expectedPrefix, result!.Id);
    }

    [Test]
    public void ToOutputItem_DoesNotMutateTheSourceItem()
    {
        var message = MessageItemFactory.Message(MessageRole.User, "hello");
        message.Id = "original_id";

        var result = ItemConversion.ToOutputItem(message, PartitionKeyHint);

        Assert.That(message.Id, Is.EqualTo("original_id"));
        Assert.That(result!.Id, Is.Not.EqualTo("original_id"));
    }

    [Test]
    public void ToOutputItem_PreservesContent()
    {
        var message = MessageItemFactory.Message(MessageRole.User, "Hello, world!");

        var result = ItemConversion.ToOutputItem(message, PartitionKeyHint);

        var converted = XAssert.IsType<MessageResponseItem>(result);
        Assert.That(converted.Role, Is.EqualTo(MessageRole.User));
        Assert.That(converted.Content, Is.Not.Empty);
    }

    [Test]
    public void ToOutputItem_ItemReference_ReturnsNull()
    {
        var reference = ResponseItem.CreateReferenceItem("msg_abc");

        Assert.That(ItemConversion.ToOutputItem(reference, PartitionKeyHint), Is.Null);
    }

    [Test]
    public void ToOutputItems_SkipsReferences()
    {
        var items = new List<Item>
        {
            MessageItemFactory.Message(MessageRole.User, "one"),
            ResponseItem.CreateReferenceItem("msg_abc"),
            MessageItemFactory.Message(MessageRole.Assistant, "two"),
        };

        var results = ItemConversion.ToOutputItems(items, PartitionKeyHint).ToList();

        Assert.That(results, Has.Count.EqualTo(2));
        // Input messages get the "msg" prefix; assistant messages get the output-message prefix.
        Assert.That(results[0].Id, Does.StartWith("msg_"));
        Assert.That(results[1].Id, Does.StartWith("om_"));
    }

    [Test]
    public void ToOutputItem_PropagatesThePartitionKey()
    {
        var message = MessageItemFactory.Message(MessageRole.User, "hi");
        var responseId = IdGenerator.NewResponseId();
        var partitionKey = IdGenerator.ExtractPartitionKey(responseId);

        var result = ItemConversion.ToOutputItem(message, responseId);

        Assert.That(result!.Id, Does.Contain(partitionKey));
    }

    // The shell, compaction and output message items have no typed model in
    // OpenAI.Responses.ResponseItem, so they reach ItemConversion as opaque items and are
    // recognized by their wire type. The custom tool items are typed OpenAI items. None of them
    // may be dropped from the persisted input items.
    private static IEnumerable<TestCaseData> PersistedItemCases()
    {
        yield return new TestCaseData(
            """{"type":"output_message","id":"client_id","role":"assistant","status":"completed","content":[{"type":"output_text","text":"hi","annotations":[]}]}""",
            "om_").SetName("OutputMessage");
        yield return new TestCaseData(
            """{"type":"shell_call","id":"client_id","call_id":"call_1","action":{"commands":["ls"]},"status":"completed"}""",
            "lsh_").SetName("ShellCall");
        yield return new TestCaseData(
            """{"type":"shell_call_output","id":"client_id","call_id":"call_1","output":[],"status":"completed"}""",
            "lsho_").SetName("ShellCallOutput");
        yield return new TestCaseData(
            """{"type":"local_shell_call","id":"client_id","call_id":"call_1","action":{"type":"exec","command":["ls"],"env":{}},"status":"completed"}""",
            "lsh_").SetName("LocalShellCall");
        yield return new TestCaseData(
            """{"type":"local_shell_call_output","id":"client_id","output":"done","status":"completed"}""",
            "lsho_").SetName("LocalShellCallOutput");
        yield return new TestCaseData(
            """{"type":"compaction","id":"client_id","encrypted_content":"opaque"}""",
            "cmp_").SetName("Compaction");
        yield return new TestCaseData(
            """{"type":"custom_tool_call","id":"client_id","call_id":"call_1","name":"lookup","input":"query"}""",
            "ctc_").SetName("CustomToolCall");
        yield return new TestCaseData(
            """{"type":"custom_tool_call_output","id":"client_id","call_id":"call_1","output":[{"type":"input_text","text":"result"},{"type":"input_image","image_url":"https://example.com/a.png","detail":"auto"}]}""",
            "ctco_").SetName("CustomToolCallOutputWithContentParts");
    }

    [TestCaseSource(nameof(PersistedItemCases))]
    public void ToOutputItem_PersistedItemKinds_AreKeptWithTheirPayload(string json, string expectedPrefix)
    {
        var item = ModelJson.Read<Item>(BinaryData.FromString(json), ModelReaderWriterOptions.Json)!;

        var result = ItemConversion.ToOutputItem(item, PartitionKeyHint);

        Assert.That(result, Is.Not.Null);
        XAssert.StartsWith(expectedPrefix, result!.Id);
        Assert.That(item.Id, Is.EqualTo("client_id"), "The source item must not be mutated.");

        var expected = JsonNode.Parse(json)!;
        expected["id"] = result.Id;
        var actual = JsonNode.Parse(ModelJson.Write(result, ModelReaderWriterOptions.Json).ToString())!;
        Assert.That(JsonNode.DeepEquals(actual, expected), Is.True, actual.ToJsonString());
    }

    // OpenAI's CustomToolCallOutputItem writes a plain string output back as a single input_text
    // part, so the text is compared instead of the whole payload.
    [Test]
    public void ToOutputItem_CustomToolCallOutputWithStringOutput_KeepsTheText()
    {
        var item = ModelJson.Read<Item>(
            BinaryData.FromString("""{"type":"custom_tool_call_output","id":"client_id","call_id":"call_1","output":"result"}"""),
            ModelReaderWriterOptions.Json)!;

        var result = ItemConversion.ToOutputItem(item, PartitionKeyHint);

        Assert.That(result, Is.Not.Null);
        XAssert.StartsWith("ctco_", result!.Id);
        Assert.That(ModelJson.Write(result, ModelReaderWriterOptions.Json).ToString(), Does.Contain("result"));
    }

    [Test]
    public void ToOutputItem_UnrecognizedItemType_ReturnsNull()
    {
        var item = ModelJson.Read<Item>(
            BinaryData.FromString("""{"type":"not_a_real_item_type","id":"x_1"}"""),
            ModelReaderWriterOptions.Json)!;

        Assert.That(ItemConversion.ToOutputItem(item, PartitionKeyHint), Is.Null);
    }

    [Test]
    public void ToItem_StripsInternalMetadata()
    {
        var message = MessageItemFactory.Message(MessageRole.Assistant, "hi");
        message.Id = "msg_1";
        // ResponseItem.Patch is the only way to write/read raw JSON paths on the OpenAI model and is tagged experimental by System.ClientModel.
#pragma warning disable SCME0001
        message.Patch.Set(
            "$.metadata"u8,
            BinaryData.FromString($$"""{"{{InternalMetadataEgress.ResponseInternalMetadataKey}}":"secret"}""").ToArray());

        var result = ItemConversion.ToItem(message);

        Assert.That(result, Is.Not.Null);
        Assert.That(
            result!.Patch.GetJson("$.metadata"u8)?.ToString() ?? string.Empty,
            Does.Not.Contain("secret"));
#pragma warning restore SCME0001
    }
}
