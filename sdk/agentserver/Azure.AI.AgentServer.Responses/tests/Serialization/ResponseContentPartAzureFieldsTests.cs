// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Text.Json;
using OpenAI.Responses;

namespace Azure.AI.AgentServer.Responses.Tests.Serialization;

/// <summary>
/// Azure-only content part data that OpenAI's <see cref="ResponseContentPart"/> does not model.
/// </summary>
public class ResponseContentPartAzureFieldsTests
{
    [Test]
    public void PromptCacheBreakpoint_Read_ReturnsRawJson()
    {
        var part = Read("""{"type":"input_text","text":"hi","prompt_cache_breakpoint":{"mode":"explicit"}}""");

        using var breakpoint = JsonDocument.Parse(part.PromptCacheBreakpoint!.ToString());
        Assert.That(breakpoint.RootElement.GetProperty("mode").GetString(), Is.EqualTo("explicit"));
    }

    [Test]
    public void PromptCacheBreakpoint_Absent_ReturnsNull()
    {
        var part = Read("""{"type":"input_text","text":"hi"}""");

        Assert.That(part.PromptCacheBreakpoint, Is.Null);
    }

    [Test]
    public void PromptCacheBreakpoint_Set_IsWrittenAndCanBeCleared()
    {
        var part = ResponseContentPart.CreateInputTextPart("hi");
        part.PromptCacheBreakpoint = BinaryData.FromString("""{"mode":"explicit"}""");

        using (var written = Write(part))
        {
            Assert.That(written.RootElement.GetProperty("prompt_cache_breakpoint").GetProperty("mode").GetString(), Is.EqualTo("explicit"));
        }

        part.PromptCacheBreakpoint = null;

        using var cleared = Write(part);
        Assert.That(cleared.RootElement.TryGetProperty("prompt_cache_breakpoint", out _), Is.False);
    }

    [Test]
    public void ImageDetail_Original_RoundTripsThroughOpenAIDetailLevel()
    {
        var read = Read("""{"type":"input_image","image_url":"https://example.com/a.png","detail":"original"}""");
        Assert.That(read.InputImageDetailLevel?.ToString(), Is.EqualTo("original"));

        var created = ResponseContentPart.CreateInputImagePart(new Uri("https://example.com/a.png"), new ResponseImageDetailLevel("original"));
        using var written = Write(created);
        Assert.That(written.RootElement.GetProperty("detail").GetString(), Is.EqualTo("original"));
    }

    private static ResponseContentPart Read(string json)
        => ModelReaderWriter.Read<ResponseContentPart>(BinaryData.FromString(json), ModelReaderWriterOptions.Json)!;

    private static JsonDocument Write(ResponseContentPart part)
        => JsonDocument.Parse(ModelReaderWriter.Write(part, ModelReaderWriterOptions.Json).ToString());
}
