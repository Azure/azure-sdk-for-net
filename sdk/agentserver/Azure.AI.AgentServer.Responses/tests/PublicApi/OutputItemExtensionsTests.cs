// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Responses.Models;

namespace Azure.AI.AgentServer.Responses.Tests.PublicApi;

public class OutputItemExtensionsTests
{
    [Test]
    public void GetId_OutputItemMessage_ReturnsId()
    {
        var item = TestModels.OutputItemMessage("msg_abc123", MessageStatus.Completed, MessageRole.Assistant, Array.Empty<MessageContent>());

        Assert.That(item.GetId(), Is.EqualTo("msg_abc123"));
    }

    [Test]
    public void GetId_FunctionToolCall_ReturnsId()
    {
        var item = new OutputItemFunctionToolCall("call_1", "fn", BinaryData.FromString("{}")) { Id = "fc_001" };

        Assert.That(item.GetId(), Is.EqualTo("fc_001"));
    }

    [Test]
    public void GetId_McpToolCall_ReturnsId()
    {
        var item = new OutputItemMcpToolCall("server", "tool", BinaryData.FromString("{}")) { Id = "mcp_001" };

        Assert.That(item.GetId(), Is.EqualTo("mcp_001"));
    }

    [Test]
    public void GetId_NullId_ThrowsInvalidOperationException()
    {
        var item = new OutputItemFunctionToolCall("call_1", "fn", BinaryData.FromString("{}"));

        var ex = Assert.Throws<InvalidOperationException>(() => item.GetId());
        Assert.That(ex!.Message, Does.Contain("does not have a valid Id"));
    }

    [Test]
    public void GetId_NullItem_ThrowsArgumentNullException()
    {
        OutputItem? item = null;
        Assert.Throws<ArgumentNullException>(() => item!.GetId());
    }
}
