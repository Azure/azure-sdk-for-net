// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Nodes;
using Azure.AI.AgentServer.Responses.Models;
using OpenAI.Responses;

namespace Azure.AI.AgentServer.Responses.Tests.Internal;

/// <summary>
/// <see cref="FunctionCallOutputResponseItem"/> models <c>output</c> only as a string, so
/// <see cref="FunctionCallOutputParts"/> keeps the array form intact across every read path:
/// the handler sees the joined text, while serialization emits the original parts.
/// </summary>
public class FunctionCallOutputPartsTests
{
    private const string Parts = """
        [
          { "type": "input_text", "text": "first" },
          { "type": "input_image", "image_url": "https://example.com/a.png" },
          { "type": "input_text", "text": "second" },
          { "type": "input_file", "file_id": "file_1" }
        ]
        """;

    private static readonly string Item =
        $$"""{ "type": "function_call_output", "call_id": "call_1", "output": {{Parts}} }""";

    private static void AssertPreserved(ResponseItem? item)
    {
        var fco = XAssert.IsType<FunctionCallOutputResponseItem>(item);
        var wire = JsonNode.Parse(ModelReaderWriter.Write(fco).ToString())!;
        Assert.Multiple(() =>
        {
            Assert.That(fco.FunctionOutput, Is.EqualTo("first\nsecond"));
            Assert.That(JsonNode.DeepEquals(wire["output"], JsonNode.Parse(Parts)), Is.True, wire.ToJsonString());
        });
    }

    [Test]
    public void Item_ArrayOutput_IsPreserved()
        => AssertPreserved(ModelJson.Read<ResponseItem>(BinaryData.FromString(Item)));

    [Test]
    public void Item_StringOutput_IsUnchanged()
    {
        var item = ModelJson.Read<ResponseItem>(BinaryData.FromString(
            """{ "type": "function_call_output", "call_id": "call_1", "output": "done" }"""));

        var fco = XAssert.IsType<FunctionCallOutputResponseItem>(item);
        var wire = JsonNode.Parse(ModelReaderWriter.Write(fco).ToString())!;
        Assert.That((string?)wire["output"], Is.EqualTo("done"));
    }

    [Test]
    public void Item_SerializationRoundTrip_IsStable()
    {
        var first = ModelJson.Read<ResponseItem>(BinaryData.FromString(Item))!;
        var second = ModelJson.Read<ResponseItem>(ModelReaderWriter.Write(first));

        AssertPreserved(second);
    }

    [Test]
    public void CreateRequest_ReadByEndpointConverter_PreservesParts()
    {
        var body = $$"""{ "model": "m", "input": [ {{Item}} ] }""";

        var request = JsonSerializer.Deserialize<CreateResponse>(body, SharedJsonOptions.Instance)!;

        AssertPreserved(request.InputItems.Single());
    }

    [Test]
    public void ItemConversion_ToOutputItem_PreservesParts()
    {
        var item = ModelJson.Read<ResponseItem>(BinaryData.FromString(Item))!;

        var output = ItemConversion.ToOutputItem(item, "resp_test");

        AssertPreserved(output);
    }

    [Test]
    public void StorageItemsArray_PreservesParts()
    {
        var items = StorageEnvelopeSerializer.DeserializeItemsArray($"[ {Item}, null ]").ToList();

        Assert.That(items, Has.Count.EqualTo(2));
        AssertPreserved(items[0]);
    }

    [Test]
    public void StorageResponse_PreservesPartsInOutput()
    {
        var json = $$"""
            {
              "id": "resp_1", "object": "response", "created_at": 1, "status": "completed",
              "model": "m", "output": [ {{Item}} ]
            }
            """;

        var response = StorageEnvelopeSerializer.DeserializeResponse(json);

        AssertPreserved(response.OutputItems.Single());
    }

    [Test]
    public void StreamingOutputItemDone_PreservesParts()
    {
        var json = $$"""
            { "type": "response.output_item.done", "sequence_number": 1, "output_index": 0, "item": {{Item}} }
            """;

        var update = ModelJson.Read<StreamingResponseUpdate>(BinaryData.FromString(json));

        AssertPreserved(XAssert.IsType<StreamingResponseOutputItemDoneUpdate>(update).Item);
    }

    [Test]
    public void WireFormatTranslation_PreservesParts()
    {
        var item = ModelJson.Read<ResponseItem>(BinaryData.FromString(Item))!;

        AssertPreserved(item.Translate().To<ResponseItem>());
    }

    [Test]
    public void Flatten_WithoutFunctionCallOutput_ReturnsNullAndKeepsPayload()
    {
        var data = BinaryData.FromString("""{ "type": "message", "output": [ 1 ] }""");
        var original = data;

        Assert.Multiple(() =>
        {
            Assert.That(FunctionCallOutputParts.Flatten(ref data), Is.Null);
            Assert.That(data, Is.SameAs(original));
        });
    }
}
