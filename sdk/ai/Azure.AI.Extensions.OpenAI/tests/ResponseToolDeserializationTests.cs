// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using NUnit.Framework;
using OpenAI.Responses;

namespace Azure.AI.Extensions.OpenAI.Tests;

[Category("Smoke")]
[Parallelizable(ParallelScope.All)]
public class ResponseToolDeserializationTests
{
    // Maps each Azure-specific ResponseTool discriminator ("type") to the concrete subtype that
    // deserialization should materialize. Tool definitions echoed back on a response flow through
    // OpenAI's closed DeserializeResponseTool switch, which buckets Azure kinds into an opaque
    // unknown-tool fallback. Base-class dispatch through ModelReaderWriter.Read<ResponseTool> with
    // the Azure context must instead resolve these strongly-typed subtypes; otherwise the typed
    // tool surface (e.g. BingGroundingTool) is silently lost.
    private static IEnumerable<TestCaseData> AzureResponseToolKinds()
    {
        yield return Case(ResponseToolKind.A2APreview, typeof(A2APreviewTool));
        yield return Case(ResponseToolKind.AzureAISearch, typeof(AzureAISearchTool));
        yield return Case(ResponseToolKind.AzureFunction, typeof(AzureFunctionTool));
        yield return Case(ResponseToolKind.BingCustomSearchPreview, typeof(BingCustomSearchPreviewTool));
        yield return Case(ResponseToolKind.BingGrounding, typeof(BingGroundingTool));
        yield return Case(ResponseToolKind.BrowserAutomationPreview, typeof(BrowserAutomationPreviewTool));
        yield return Case(ResponseToolKind.CaptureStructuredOutputs, typeof(CaptureStructuredOutputsTool));
        yield return Case(ResponseToolKind.FabricIQPreview, typeof(FabricIQPreviewTool));
        yield return Case(ResponseToolKind.MemorySearchPreview, typeof(MemorySearchPreviewTool));
        yield return Case(ResponseToolKind.FabricDataAgentPreview, typeof(MicrosoftFabricPreviewTool));
        yield return Case(ResponseToolKind.OpenAPI, typeof(OpenAPITool));
        yield return Case(ResponseToolKind.SharePointGroundingPreview, typeof(SharepointPreviewTool));
        yield return Case(ResponseToolKind.WorkIQPreview, typeof(WorkIQPreviewTool));

        static TestCaseData Case(ResponseToolKind discriminator, Type expectedType)
            => new TestCaseData(discriminator, expectedType).SetName($"{{m}}({discriminator} => {expectedType.Name})");
    }

    [TestCaseSource(nameof(AzureResponseToolKinds))]
    public void ReadResponseToolMaterializesAzureSubtype(ResponseToolKind discriminator, Type expectedType)
    {
        string json = $$"""{ "type": "{{discriminator.ToString()}}" }""";

        ResponseTool tool = ModelReaderWriter.Read<ResponseTool>(
            BinaryData.FromString(json),
            ModelReaderWriterOptions.Json,
            AzureAIExtensionsOpenAIContext.Default);

        Assert.That(tool, Is.InstanceOf(expectedType), $"'{discriminator}' should deserialize to {expectedType.Name} but was {tool?.GetType().Name}.");
    }
}
