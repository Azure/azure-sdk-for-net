// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json.Nodes;

namespace Azure.AI.AgentServer.Responses.Tests.Internal;

public class WireShorthandNormalizerTests
{
    private static JsonNode Normalize(string json)
    {
        var node = JsonNode.Parse(json)!;
        WireShorthandNormalizer.Normalize(node);
        return node;
    }

    [Test]
    public void FunctionCallOutput_StringOutput_IsLeftAlone()
    {
        var node = Normalize("""
        { "input": [ { "type": "function_call_output", "call_id": "call_1", "output": "done" } ] }
        """);

        Assert.That((string?)node["input"]![0]!["output"], Is.EqualTo("done"));
    }

    // Array outputs are left as sent. The OpenAI models read most of them natively, and
    // ModelJson reads the function_call_output array without losing its non-text parts.
    [TestCase("""{"type":"function_call_output","call_id":"call_1","output":[{"type":"input_text","text":"first"},{"type":"input_image","image_url":"https://example.com/a.png"}]}""")]
    [TestCase("""{"type":"shell_call_output","call_id":"call_1","output":[{"stdout":"a\n","stderr":"","outcome":{"type":"exit","exit_code":0}}]}""")]
    [TestCase("""{"type":"custom_tool_call_output","call_id":"call_1","output":[{"type":"input_text","text":"result"},{"type":"input_image","image_url":"https://example.com/a.png"}]}""")]
    [TestCase("""{"call_id":"call_1","output":[{"type":"input_text","text":"result"}]}""")]
    public void OutputArrayOfOtherItems_IsLeftAlone(string item)
    {
        var node = Normalize($$"""{ "input": [ {{item}} ] }""");

        Assert.That(
            JsonNode.DeepEquals(node["input"]![0], JsonNode.Parse(item)),
            Is.True,
            node.ToJsonString());
    }

    [Test]
    public void InputString_ExpandsToASingleUserMessage()
    {
        var node = Normalize("""{ "input": "hello" }""");

        var message = node["input"]![0]!;
        Assert.Multiple(() =>
        {
            Assert.That((string?)message["type"], Is.EqualTo("message"));
            Assert.That((string?)message["role"], Is.EqualTo("user"));
            Assert.That((string?)message["content"]![0]!["type"], Is.EqualTo("input_text"));
            Assert.That((string?)message["content"]![0]!["text"], Is.EqualTo("hello"));
        });
    }

    [Test]
    public void MessageWithoutType_IsInferredFromItsRole()
    {
        var node = Normalize("""
        { "input": [ { "role": "assistant", "content": "hi" } ] }
        """);

        var message = node["input"]![0]!;
        Assert.Multiple(() =>
        {
            Assert.That((string?)message["type"], Is.EqualTo("message"));
            Assert.That((string?)message["content"]![0]!["type"], Is.EqualTo("output_text"));
            Assert.That((string?)message["content"]![0]!["text"], Is.EqualTo("hi"));
        });
    }

    [Test]
    public void ConversationString_ExpandsToAnIdObject()
    {
        var node = Normalize("""{ "conversation": "conv_1" }""");

        Assert.That((string?)node["conversation"]!["id"], Is.EqualTo("conv_1"));
    }

    [Test]
    public void InstructionsItemArray_FlattensToItsTextParts()
    {
        var node = Normalize("""
        {
          "instructions": [
            { "role": "developer", "content": [ { "type": "input_text", "text": "be brief" } ] },
            { "role": "developer", "content": "be kind" }
          ]
        }
        """);

        Assert.That((string?)node["instructions"], Is.EqualTo("be brief\nbe kind"));
    }
}
