// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using Azure.AI.Extensions.OpenAI;
using NUnit.Framework;
using OpenAI.Responses;

#pragma warning disable AAIP001
#pragma warning disable AAIP002

namespace Azure.AI.Projects.Agents.Tests;

public class LegacyModelCompatibilityTests
{
    private static readonly string[] LegacyTypeNames =
    [
        "A2APreviewTool", "AzureAISearchTool", "AzureAISearchToolIndex", "AzureAISearchToolOptions",
        "AzureFunctionBinding", "AzureFunctionDefinition", "AzureFunctionStorageQueue", "AzureFunctionTool",
        "BingCustomSearchConfiguration", "BingCustomSearchPreviewTool", "BingCustomSearchToolOptions",
        "BingGroundingSearchConfiguration", "BingGroundingSearchToolOptions", "BingGroundingTool",
        "BrowserAutomationPreviewTool", "BrowserAutomationToolConnectionParameters", "BrowserAutomationToolOptions",
        "CaptureStructuredOutputsTool", "FabricDataAgentToolOptions", "MemorySearchPreviewTool", "MemorySearchToolOptions",
        "MicrosoftFabricPreviewTool", "OpenAPIAnonymousAuthenticationDetails", "OpenApiAuthenticationDetails",
        "OpenApiFunctionDefinition", "OpenAPIFunctionEntry", "OpenAPIManagedAuthenticationDetails",
        "OpenAPIManagedSecurityScheme", "OpenApiProjectConnectionAuthenticationDetails",
        "OpenApiProjectConnectionSecurityScheme", "OpenAPITool", "ProjectsAgentTool",
        "ProjectWebSearchConfiguration", "ResponseToolExtensions", "SharePointGroundingToolOptions",
        "SharepointPreviewTool", "StructuredOutputDefinition", "ToolProjectConnection"
    ];

    public static IEnumerable<TestCaseData> LegacyTypes =>
        LegacyTypeNames.Select(name => new TestCaseData(name));

    public static IEnumerable<TestCaseData> Tools()
    {
        yield return new TestCaseData(ProjectsAgentTool.CreateAzureAISearchTool(new AzureAISearchToolOptions(
            [new AzureAISearchToolIndex { IndexName = "index", ProjectConnectionId = "connection", QueryType = AzureAISearchQueryType.Simple }])))
            .SetName("LegacyAzureSearchRoundTrip");
        yield return new TestCaseData(ProjectsAgentTool.CreateBingGroundingTool(new BingGroundingSearchToolOptions(
            [new BingGroundingSearchConfiguration("connection")]))).SetName("LegacyBingRoundTrip");
        yield return new TestCaseData(ProjectsAgentTool.CreateBingCustomSearchTool(new BingCustomSearchToolOptions(
            [new BingCustomSearchConfiguration("connection", "instance")]))).SetName("LegacyBingCustomRoundTrip");
        yield return new TestCaseData(ProjectsAgentTool.CreateMicrosoftFabricTool(new FabricDataAgentToolOptions
        {
            ProjectConnections = { new ToolProjectConnection("connection") }
        })).SetName("LegacyFabricRoundTrip");
        yield return new TestCaseData(ProjectsAgentTool.CreateSharepointTool(new SharePointGroundingToolOptions
        {
            ProjectConnections = { new ToolProjectConnection("connection") }
        })).SetName("LegacySharePointRoundTrip");
        yield return new TestCaseData(ProjectsAgentTool.CreateBrowserAutomationTool(new BrowserAutomationToolOptions(
            new BrowserAutomationToolConnectionParameters("connection")))).SetName("LegacyBrowserRoundTrip");
        yield return new TestCaseData(new A2APreviewTool(new Uri("https://example.com"))
        {
            AgentCardPath = "/agent.json"
        }).SetName("LegacyA2ARoundTrip");
        yield return new TestCaseData(new MemorySearchPreviewTool("store", "scope")
        {
            SearchOptions = new MemorySearchToolOptions { MaxMemories = 3 }
        }).SetName("LegacyMemoryRoundTrip");
        yield return new TestCaseData(ProjectsAgentTool.CreateStructuredOutputsTool(new StructuredOutputDefinition(
            "result", "result schema", new Dictionary<string, BinaryData> { ["type"] = BinaryData.FromObjectAsJson("object") }, true)))
            .SetName("LegacyStructuredOutputRoundTrip");
        yield return new TestCaseData(ProjectsAgentTool.CreateOpenApiTool(new OpenApiFunctionDefinition(
            "weather", BinaryData.FromString("""{"openapi":"3.0.0","paths":{}}"""), new OpenAPIAnonymousAuthenticationDetails())))
            .SetName("LegacyOpenApiRoundTrip");
        var binding = new AzureFunctionBinding(new AzureFunctionStorageQueue("https://example.com", "queue"));
        yield return new TestCaseData(new AzureFunctionTool(new AzureFunctionDefinition(
            new AzureFunctionDefinitionFunction("function", BinaryData.FromString("""{"type":"object"}""")), binding, binding)))
            .SetName("LegacyFunctionRoundTrip");
    }

    [TestCaseSource(nameof(LegacyTypes))]
    public void RestoredTypesKeepTheirOriginalIdentityAndAreHidden(string name)
    {
        Type type = typeof(AgentAdministrationClient).Assembly.GetType($"Azure.AI.Projects.Agents.{name}", throwOnError: true);
        Assert.That(type.IsPublic, Is.True);
        Assert.That(type.GetCustomAttribute<EditorBrowsableAttribute>()?.State, Is.EqualTo(EditorBrowsableState.Never));
    }

    [TestCaseSource(nameof(Tools))]
    public void LegacyToolsRoundTripThroughSharedModels(ProjectsAgentTool legacy)
    {
        BinaryData original = ModelReaderWriter.Write(legacy, ModelReaderWriterOptions.Json, AzureAIProjectsAgentsContext.Default);
        ProjectsAgentTool restored = ModelReaderWriter.Read<ProjectsAgentTool>(original, ModelReaderWriterOptions.Json, AzureAIProjectsAgentsContext.Default);
        Assert.That(restored.GetType(), Is.EqualTo(legacy.GetType()));

        ResponseTool shared = legacy;
        Assert.That(shared.GetType().Namespace, Is.EqualTo("Azure.AI.Extensions.OpenAI"));
        ProjectsAgentTool roundTrip = shared.AsAgentTool();
        Assert.That(roundTrip.GetType(), Is.EqualTo(legacy.GetType()));
        AssertJsonEqual(original, ModelReaderWriter.Write(roundTrip, ModelReaderWriterOptions.Json, AzureAIProjectsAgentsContext.Default));

        var definition = new DeclarativeAgentDefinition("model") { Tools = { legacy } };
        BinaryData definitionJson = ModelReaderWriter.Write(definition, ModelReaderWriterOptions.Json, AzureAIProjectsAgentsContext.Default);
        DeclarativeAgentDefinition readDefinition = ModelReaderWriter.Read<DeclarativeAgentDefinition>(
            definitionJson, ModelReaderWriterOptions.Json, AzureAIProjectsAgentsContext.Default);
        Assert.That(readDefinition.Tools[0].GetType(), Is.EqualTo(shared.GetType()));
    }

    [TestCase("J")]
    [TestCase("W")]
    public void NativeOpenAIToolsRetainTheirPayloadThroughLegacyConversion(string format)
    {
        var options = new ModelReaderWriterOptions(format);
        BinaryData json = BinaryData.FromString(
            """{"type":"function","name":"weather","description":"Gets weather","parameters":{"type":"object","properties":{"city":{"type":"string"}}},"strict":false}""");
        ResponseTool shared = ModelReaderWriter.Read<ResponseTool>(json, options, AzureAIExtensionsOpenAIContext.Default);
        ProjectsAgentTool legacy = shared.AsAgentTool();
        BinaryData legacyJson = ModelReaderWriter.Write(legacy, options, AzureAIProjectsAgentsContext.Default);
        using JsonDocument document = JsonDocument.Parse(legacyJson);
        Assert.That(document.RootElement.GetProperty("name").GetString(), Is.EqualTo("weather"));
        Assert.That(document.RootElement.GetProperty("parameters").GetProperty("properties").TryGetProperty("city", out _), Is.True);
        ResponseTool restored = legacy;
        Assert.That(restored.GetType(), Is.EqualTo(shared.GetType()));
    }

    [TestCase("J")]
    [TestCase("W")]
    public void UnknownToolsPreservePayload(string format)
    {
        BinaryData json = BinaryData.FromString("""{"type":"future_tool","settings":{"enabled":true},"values":[1,2]}""");
        var options = new ModelReaderWriterOptions(format);
        ProjectsAgentTool legacy = ModelReaderWriter.Read<ProjectsAgentTool>(json, options, AzureAIProjectsAgentsContext.Default);
        AssertJsonEqual(json, ModelReaderWriter.Write(legacy, options, AzureAIProjectsAgentsContext.Default));
        ResponseTool shared = legacy;
        AssertJsonEqual(json, ModelReaderWriter.Write(shared.AsAgentTool(), ModelReaderWriterOptions.Json, AzureAIProjectsAgentsContext.Default));
    }

    [Test]
    public void KnownToolPreservesUnknownPropertiesInPersistedJson()
    {
        BinaryData json = BinaryData.FromString(
            """{"type":"azure_ai_search","azure_ai_search":{"indexes":[],"future_option":true},"future_property":42}""");
        ProjectsAgentTool legacy = ModelReaderWriter.Read<ProjectsAgentTool>(json, ModelReaderWriterOptions.Json, AzureAIProjectsAgentsContext.Default);
        ResponseTool shared = legacy;
        BinaryData roundTrip = ModelReaderWriter.Write(shared.AsAgentTool(), ModelReaderWriterOptions.Json, AzureAIProjectsAgentsContext.Default);
        AssertJsonEqual(json, roundTrip);
    }

    [Test]
    public void LegacyMutationsAreObservedAtConversionTime()
    {
        var options = new AzureAISearchToolOptions([]);
        var legacy = new AzureAISearchTool(options);
        options.Indexes.Add(new AzureAISearchToolIndex { IndexName = "before", ProjectConnectionId = "connection" });
        options.Indexes[0].IndexName = "after";
        ResponseTool shared = legacy;
        var search = (Azure.AI.Extensions.OpenAI.AzureAISearchTool)shared;
        Assert.That(search.AzureAISearch.Indexes.Single().IndexName, Is.EqualTo("after"));
        Assert.That(((AzureAISearchTool)shared.AsAgentTool()).Options.Indexes.Single().IndexName, Is.EqualTo("after"));
    }

    [Test]
    public void AllLegacyModelFactoriesRemainAvailableAndHidden()
    {
        MethodInfo[] factories = typeof(ProjectsAgentsModelFactory).GetMethods(BindingFlags.Public | BindingFlags.Static);
        foreach (string name in LegacyTypeNames.Where(name => name != nameof(ResponseToolExtensions)))
        {
            MethodInfo factory = factories.Single(method => method.Name == name);
            Assert.That(factory.GetCustomAttribute<EditorBrowsableAttribute>()?.State, Is.EqualTo(EditorBrowsableState.Never), name);
            object model = factory.Invoke(null, factory.GetParameters().Select(parameter =>
                parameter.Name == "type" ? (object)"unknown" : Type.Missing).ToArray());
            Assert.That(model, Is.Not.Null, name);
        }
    }

    [Test]
    public void LegacyFunctionRemainsConstructibleMutableAndSerializable()
    {
        var function = new AzureFunctionDefinitionFunction("original", BinaryData.FromString("{}"))
        {
            Name = "updated",
            Description = "description",
            Parameters = BinaryData.FromString("""{"type":"object"}""")
        };
        BinaryData json = ModelReaderWriter.Write(function, ModelReaderWriterOptions.Json, AzureAIProjectsAgentsContext.Default);
        AzureFunctionDefinitionFunction restored = ModelReaderWriter.Read<AzureFunctionDefinitionFunction>(json, ModelReaderWriterOptions.Json, AzureAIProjectsAgentsContext.Default);
        Assert.That(restored.Name, Is.EqualTo("updated"));
        Assert.That(restored.Description, Is.EqualTo("description"));
        Assert.That(restored.Parameters.ToString(), Is.EqualTo("""{"type":"object"}"""));
    }

    [Test]
    public void LegacyHostedFactoryRetainsOriginalSignatureAndValues()
    {
        ProjectsAgentTool tool = ProjectsAgentTool.CreateAzureAISearchTool();
        HostedAgentDefinition hosted = ProjectsAgentsModelFactory.HostedAgentDefinition(
            null, [tool], [], "1", "2Gi", new Dictionary<string, string> { ["key"] = "value" }, "image");
        Assert.That(hosted.Tools.Single(), Is.SameAs(tool));
        Assert.That(hosted.Image, Is.EqualTo("image"));
        Assert.That(hosted.ContainerConfiguration.Image, Is.EqualTo("image"));
        Assert.That(hosted.EnvironmentVariables["key"], Is.EqualTo("value"));
        Assert.That(new HostedAgentDefinition("1", "2Gi").Tools, Is.Not.Null);
    }

    [Test]
    public void LegacyAndSharedWebSearchConfigurationUseTheSamePayload()
    {
        var tool = (WebSearchTool)ResponseTool.CreateWebSearchTool();
        tool.CustomSearchConfiguration = new ProjectWebSearchConfiguration("legacy-connection", "legacy-instance");
        Assert.That(tool.SearchConfiguration.ProjectConnectionId, Is.EqualTo("legacy-connection"));
        tool.SearchConfiguration = new WebSearchConfiguration("shared-connection", "shared-instance");
        Assert.That(tool.CustomSearchConfiguration.ProjectConnectionId, Is.EqualTo("shared-connection"));
        tool.CustomSearchConfiguration = null;
        Assert.That(tool.SearchConfiguration, Is.Null);
    }

    [Test]
    public void NullConversionArgumentsAreRejected()
    {
        Assert.That(typeof(ResponseToolExtensions).GetMethod(nameof(ResponseToolExtensions.AsAgentTool))
            .GetCustomAttribute<EditorBrowsableAttribute>()?.State, Is.EqualTo(EditorBrowsableState.Never));
        Assert.Throws<ArgumentNullException>(() => ResponseToolExtensions.AsAgentTool(null));
        Assert.Throws<ArgumentNullException>(() => { ResponseTool tool = (ProjectsAgentTool)null; });
    }

    [Test]
    public void NewToolboxApisStillUseTheSharedModels()
    {
        Assert.That(typeof(AzureAISearchToolboxTool).GetProperty(nameof(AzureAISearchToolboxTool.AzureAiSearch)).PropertyType,
            Is.EqualTo(typeof(Azure.AI.Extensions.OpenAI.AzureAISearchToolOptions)));
        Assert.That(typeof(BrowserAutomationPreviewToolboxTool).GetProperty(nameof(BrowserAutomationPreviewToolboxTool.ToolParameters)).PropertyType,
            Is.EqualTo(typeof(Azure.AI.Extensions.OpenAI.BrowserAutomationToolOptions)));
        Assert.That(typeof(OpenApiToolboxTool).GetProperty(nameof(OpenApiToolboxTool.FunctionDefinition)).PropertyType,
            Is.EqualTo(typeof(Azure.AI.Extensions.OpenAI.OpenApiFunctionDefinition)));
    }

    [Test]
    public void LegacySubclassSerializationOverrideIsUsed()
    {
        ResponseTool shared = new CustomSearchTool();
        ProjectsAgentTool restored = shared.AsAgentTool();
        BinaryData json = ModelReaderWriter.Write(restored, ModelReaderWriterOptions.Json, AzureAIProjectsAgentsContext.Default);
        using JsonDocument document = JsonDocument.Parse(json);
        Assert.That(document.RootElement.GetProperty("custom_property").GetString(), Is.EqualTo("custom_value"));
    }

    private sealed class CustomSearchTool : AzureAISearchTool
    {
        public CustomSearchTool() : base(new AzureAISearchToolOptions([]))
        {
        }

        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            base.JsonModelWriteCore(writer, options);
            writer.WriteString("custom_property", "custom_value");
        }
    }

    private static void AssertJsonEqual(BinaryData expected, BinaryData actual)
    {
        using JsonDocument left = JsonDocument.Parse(expected);
        using JsonDocument right = JsonDocument.Parse(actual);
        Assert.That(JsonElement.DeepEquals(left.RootElement, right.RootElement), Is.True, $"{expected}\n{actual}");
    }
}
