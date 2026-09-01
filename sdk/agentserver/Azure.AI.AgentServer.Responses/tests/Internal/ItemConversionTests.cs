// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
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
        Assert.That(results.All(item => item.Id!.StartsWith("msg_")), Is.True);
    }

    [Test]
    public void ToOutputItem_PropagatesThePartitionKey()
    {
        var message = MessageItemFactory.Message(MessageRole.User, "hi");

        var result = ItemConversion.ToOutputItem(message, "resp_abc123");

        Assert.That(result!.Id, Does.Contain("abc123"));
    }

    [Test]
    public void ToItem_StripsInternalMetadata()
    {
        var message = MessageItemFactory.Message(MessageRole.Assistant, "hi");
        message.Id = "msg_1";
        message.Patch.Set(
            "$.metadata"u8,
            BinaryData.FromString($$"""{"{{InternalMetadataEgress.ResponseInternalMetadataKey}}":"secret"}""").ToArray());

        var result = ItemConversion.ToItem(message);

        Assert.That(result, Is.Not.Null);
        Assert.That(
            result!.Patch.GetJson("$.metadata"u8)?.ToString() ?? string.Empty,
            Does.Not.Contain("secret"));
    }
}
