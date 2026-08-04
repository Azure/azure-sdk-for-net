// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Responses.Models;

namespace Azure.AI.AgentServer.Responses.Tests.Internal;

public class ItemConversionTests
{
    private const string PartitionKeyHint = "resp_test";

    [Test]
    public void ToOutputItem_Message_ReturnsSameOpenAIItem()
    {
        var message = TestModels.ItemMessage(MessageRole.User, BinaryData.FromObjectAsJson("Hello"));

        var result = ItemConversion.ToOutputItem(message, PartitionKeyHint);

        Assert.That(result, Is.SameAs(message));
    }

    [Test]
    public void ToOutputItem_FunctionCall_ReturnsSameOpenAIItem()
    {
        var funcCall = new OutputItemFunctionToolCall("call_func", "get_weather", BinaryData.FromString("{\"city\":\"Seattle\"}"));

        var result = ItemConversion.ToOutputItem(funcCall, PartitionKeyHint);

        var converted = XAssert.IsType<OutputItemFunctionToolCall>(result);
        Assert.That(converted.CallId, Is.EqualTo("call_func"));
        Assert.That(converted.FunctionName, Is.EqualTo("get_weather"));
        Assert.That(converted.FunctionArguments.ToString(), Is.EqualTo("{\"city\":\"Seattle\"}"));
    }

    [Test]
    public void ToOutputItem_FunctionCallOutput_ReturnsSameOpenAIItem()
    {
        var output = new OutputItemFunctionToolCallOutput("call_123", "function result");

        var result = ItemConversion.ToOutputItem(output, PartitionKeyHint);

        var converted = XAssert.IsType<OutputItemFunctionToolCallOutput>(result);
        Assert.That(converted.CallId, Is.EqualTo("call_123"));
        Assert.That(converted.FunctionOutput.ToString(), Is.EqualTo("function result"));
    }

    [Test]
    public void ToOutputItem_McpToolCall_ReturnsSameOpenAIItem()
    {
        var mcpCall = new OutputItemMcpToolCall("server_2", "tool_name", BinaryData.FromString("{}"))
        {
            Id = "mcp_tc",
            ToolOutput = "result",
        };

        var result = ItemConversion.ToOutputItem(mcpCall, PartitionKeyHint);

        var converted = XAssert.IsType<OutputItemMcpToolCall>(result);
        Assert.That(converted.ServerLabel, Is.EqualTo("server_2"));
        Assert.That(converted.ToolName, Is.EqualTo("tool_name"));
        Assert.That(converted.ToolArguments.ToString(), Is.EqualTo("{}"));
        Assert.That(converted.ToolOutput, Is.EqualTo("result"));
    }

    [Test]
    public void ToOutputItems_MixedOpenAIItems_ReturnsAllItems()
    {
        var items = new List<Item>
        {
            TestModels.ItemMessage(MessageRole.User, BinaryData.FromObjectAsJson("Hello")),
            new OutputItemFunctionToolCall("call_f", "func", BinaryData.FromString("{}")),
            new OutputItemFunctionToolCallOutput("call_1", "result"),
        };

        var results = ItemConversion.ToOutputItems(items, PartitionKeyHint).ToList();

        Assert.That(results, Is.EqualTo(items));
    }

    [Test]
    public void ToItem_OutputItem_ReturnsSameOpenAIItem()
    {
        var output = new OutputItemFunctionToolCallOutput("call_1", "result");

        var result = ItemConversion.ToItem(output);

        Assert.That(result, Is.SameAs(output));
    }
}
