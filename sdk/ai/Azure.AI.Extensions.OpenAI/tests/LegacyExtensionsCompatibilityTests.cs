// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.ClientModel.TestFramework.Mocks;
using NUnit.Framework;
using OpenAI.Conversations;
using OpenAI.Responses;

#pragma warning disable AAIP001

namespace Azure.AI.Extensions.OpenAI.Tests;

[NUnit.Framework.Category("Smoke")]
public class LegacyExtensionsCompatibilityTests
{
    private static readonly string[] RemovedTypes =
    [
        "AgentResponseItem", "AgentResponseItemKind", "ContentFilterConfiguration",
        "MemorySearchToolCallResponseItem", "MemorySearchToolCallStatus", "MemoryToolSearchItem",
        "ProjectConversation", "ProjectConversationCreationOptions", "ProjectConversationUpdateOptions",
        "SharepointGroundingToolCall", "SharepointGroundingToolCallOutput"
    ];

    private static readonly (string Kind, Type Type)[] BridgedItems =
    [
        ("a2a_preview_call", typeof(A2AToolCall)),
        ("a2a_preview_call_output", typeof(A2AToolCallOutput)),
        ("structured_outputs", typeof(AgentStructuredOutputsResponseItem)),
        ("workflow_action", typeof(AgentWorkflowPreviewActionResponseItem)),
        ("azure_ai_search_call", typeof(AzureAISearchToolCall)),
        ("azure_ai_search_call_output", typeof(AzureAISearchToolCallOutput)),
        ("azure_function_call", typeof(AzureFunctionToolCall)),
        ("azure_function_call_output", typeof(AzureFunctionToolCallOutput)),
        ("bing_custom_search_preview_call", typeof(BingCustomSearchToolCall)),
        ("bing_custom_search_preview_call_output", typeof(BingCustomSearchToolCallOutput)),
        ("bing_grounding_call", typeof(BingGroundingToolCall)),
        ("bing_grounding_call_output", typeof(BingGroundingToolCallOutput)),
        ("browser_automation_preview_call", typeof(BrowserAutomationToolCall)),
        ("browser_automation_preview_call_output", typeof(BrowserAutomationToolCallOutput)),
        ("fabric_dataagent_preview_call", typeof(FabricDataAgentToolCall)),
        ("fabric_dataagent_preview_call_output", typeof(FabricDataAgentToolCallOutput)),
        ("oauth_consent_request", typeof(OAuthConsentRequestResponseItem)),
        ("openapi_call", typeof(OpenApiToolCall)),
        ("openapi_call_output", typeof(OpenApiToolCallOutput))
    ];

    public static IEnumerable<TestCaseData> LegacyTypes => RemovedTypes.Select(name => new TestCaseData(name));

    public static IEnumerable<TestCaseData> ItemCases =>
        from item in BridgedItems
        from format in new[] { "J", "W" }
        select new TestCaseData(item.Kind, item.Type, format);

    private static string ItemJson(string kind, string id = "item_1") => $$"""
        {
          "type":"{{kind}}","id":"{{id}}","agent_reference":{"name":"agent","version":"2"},"response_id":"resp_1",
          "call_id":"call_1","name":"function","arguments":"{}","status":"completed","output":{"answer":42},
          "kind":"invoke","action_id":"action_1","consent_link":"https://example.com/consent","server_label":"server"
        }
        """;

    private static string ConversationJson(string id = "conv_1") =>
        $$$"""{"id":"{{{id}}}","object":"conversation","created_at":123,"metadata":{"key":"value"}}""";

    [TestCaseSource(nameof(LegacyTypes))]
    public void RemovedTypesExistAndAreHidden(string name)
    {
        Type type = typeof(ProjectOpenAIClient).Assembly.GetType($"Azure.AI.Extensions.OpenAI.{name}", throwOnError: true);
        Assert.That(type.IsPublic, Is.True);
        Assert.That(type.GetCustomAttribute<EditorBrowsableAttribute>()?.State, Is.EqualTo(EditorBrowsableState.Never));
    }

    [TestCaseSource(nameof(ItemCases))]
    public void BothModelInterfacesPreserveHierarchyKindAndAttribution(string kind, Type expectedType, string format)
    {
        var options = new ModelReaderWriterOptions(format);
        BinaryData json = BinaryData.FromString(ItemJson(kind));
        AgentResponseItem legacy = ModelReaderWriter.Read<AgentResponseItem>(json, options, AzureAIExtensionsOpenAIContext.Default);
        ResponseItem native = ModelReaderWriter.Read<ResponseItem>(json, options, AzureAIExtensionsOpenAIContext.Default);
        Assert.That(legacy, Is.TypeOf(expectedType));
        Assert.That(native, Is.TypeOf(expectedType));
        Assert.That(typeof(AgentResponseItem).IsAssignableFrom(expectedType), Is.True);
        Assert.That(typeof(ResponseItem).IsAssignableFrom(expectedType), Is.True);
        Assert.That(legacy.Id, Is.EqualTo("item_1"));
        Assert.That(((ResponseItem)legacy).Kind.ToString(), Is.EqualTo(kind));
        Assert.That(legacy.AgentReference.Name, Is.EqualTo("agent"));
        Assert.That(legacy.ResponseId, Is.EqualTo("resp_1"));

        legacy.AgentReference.Name = "changed-agent";
        legacy.ResponseId = "changed-response";
        foreach (BinaryData serialized in new[]
        {
            ModelReaderWriter.Write<AgentResponseItem>(legacy, options, AzureAIExtensionsOpenAIContext.Default),
            ModelReaderWriter.Write<ResponseItem>(legacy, options, AzureAIExtensionsOpenAIContext.Default)
        })
        {
            using JsonDocument document = JsonDocument.Parse(serialized);
            JsonElement root = document.RootElement;
            Assert.That(root.GetProperty("id").GetString(), Is.EqualTo("item_1"));
            Assert.That(root.GetProperty("type").GetString(), Is.EqualTo(kind));
            Assert.That(root.GetProperty("agent_reference").GetProperty("name").GetString(), Is.EqualTo("changed-agent"));
            Assert.That(root.GetProperty("response_id").GetString(), Is.EqualTo("changed-response"));
            Assert.That(root.EnumerateObject().Select(property => property.Name), Is.Unique);
            Assert.That(ModelReaderWriter.Read<AgentResponseItem>(serialized, options, AzureAIExtensionsOpenAIContext.Default), Is.TypeOf(expectedType));
        }
    }

    [TestCase("J")]
    [TestCase("W")]
    public void UnknownNativeItemsRetainTheirPayload(string format)
    {
        var options = new ModelReaderWriterOptions(format);
        BinaryData json = BinaryData.FromString("""{"type":"future_item","id":"item","payload":{"value":1},"flags":[true,false]}""");
        AgentResponseItem legacy = ModelReaderWriter.Read<AgentResponseItem>(json, options, AzureAIExtensionsOpenAIContext.Default);
        AssertJsonEqual(json, ModelReaderWriter.Write(legacy, options, AzureAIExtensionsOpenAIContext.Default));
        AgentResponseItem converted = legacy.AsResponseResultItem().AsAgentResponseItem();
        AssertJsonEqual(json, ModelReaderWriter.Write(converted, options, AzureAIExtensionsOpenAIContext.Default));
    }

    [TestCase("sharepoint_grounding_preview_call", typeof(SharepointGroundingToolCall))]
    [TestCase("sharepoint_grounding_preview_call_output", typeof(SharepointGroundingToolCallOutput))]
    [TestCase("memory_search_call", typeof(MemorySearchToolCallResponseItem))]
    public void RemovedConcreteItemsRetainTheirLegacyRepresentation(string kind, Type expectedType)
    {
        AgentResponseItem item = ModelReaderWriter.Read<AgentResponseItem>(
            BinaryData.FromString(ItemJson(kind)), ModelReaderWriterOptions.Json, AzureAIExtensionsOpenAIContext.Default);
        Assert.That(item, Is.TypeOf(expectedType));
        BinaryData serialized = ModelReaderWriter.Write(item, ModelReaderWriterOptions.Json, AzureAIExtensionsOpenAIContext.Default);
        AgentResponseItem restored = ModelReaderWriter.Read<AgentResponseItem>(serialized, ModelReaderWriterOptions.Json, AzureAIExtensionsOpenAIContext.Default);
        Assert.That(restored, Is.TypeOf(expectedType));
        Assert.That(restored.Id, Is.EqualTo("item_1"));
        Assert.That(restored.AgentReference.Name, Is.EqualTo("agent"));
    }

    [Test]
    public void LegacyReaderRejectsUnsupportedFormats()
    {
        Assert.Throws<FormatException>(() => ModelReaderWriter.Read<AgentResponseItem>(
            BinaryData.FromString(ItemJson("bing_grounding_call")), new ModelReaderWriterOptions("unsupported"),
            AzureAIExtensionsOpenAIContext.Default));
    }

    [Test]
    public void LegacyConversionEntryPointsRemainCallableAndSnapshotTheirInput()
    {
        var item = ExtensionsOpenAIModelFactory.BingGroundingToolCall(id: "item", callId: "call", arguments: "{}");
        MethodInfo toNative = typeof(AgentResponseItem).GetMethods(BindingFlags.Public | BindingFlags.Static)
            .Single(method => method.Name == "op_Implicit" && method.ReturnType == typeof(ResponseItem));
        MethodInfo toLegacy = typeof(AgentResponseItem).GetMethods(BindingFlags.Public | BindingFlags.Static)
            .Single(method => method.Name == "op_Implicit" && method.ReturnType == typeof(AgentResponseItem));
        Assert.That(toNative.IsSpecialName, Is.True);
        Assert.That(toLegacy.IsSpecialName, Is.True);
        ResponseItem snapshot = (ResponseItem)toNative.Invoke(null, [item]);
        Assert.That(snapshot, Is.Not.SameAs(item));
        AgentResponseItem restored = (AgentResponseItem)toLegacy.Invoke(null, [snapshot]);
        Assert.That(restored, Is.TypeOf<BingGroundingToolCall>());
        Assert.That(restored.Id, Is.EqualTo("item"));
        AgentResponseItem sourceConversion = snapshot;
        Assert.That(sourceConversion, Is.TypeOf<BingGroundingToolCall>());
        ResponseItem upcast = item;
        Assert.That(upcast, Is.SameAs(item), "Newly compiled upcasts use the CLR inheritance conversion rather than the old snapshot operator.");
    }

    [Test]
    public void LegacySerializationOverridesStillDispatch()
    {
        AgentResponseItem item = new DerivedBingCall();
        BinaryData json = ModelReaderWriter.Write<ResponseItem>(item, ModelReaderWriterOptions.Json, AzureAIExtensionsOpenAIContext.Default);
        using JsonDocument document = JsonDocument.Parse(json);
        Assert.That(document.RootElement.GetProperty("custom").GetString(), Is.EqualTo("value"));
        var derived = (DerivedBingCall)item;
        Assert.That(derived.ReadLegacy(json), Is.TypeOf<BingGroundingToolCall>());
    }

    [Test]
    public void LegacyFactoryOverloadsRetainMetadataAndAreHidden()
    {
        MethodInfo[] factories = typeof(ExtensionsOpenAIModelFactory).GetMethods(BindingFlags.Public | BindingFlags.Static)
            .Where(method => method.GetCustomAttribute<EditorBrowsableAttribute>()?.State == EditorBrowsableState.Never)
            .ToArray();
        Assert.That(factories, Has.Length.EqualTo(28));
        foreach (MethodInfo factory in factories)
        {
            object[] arguments = factory.GetParameters().Select(parameter => parameter.Name switch
            {
                "id" => (object)"factory_id",
                "agentReference" => new AgentReference("factory_agent"),
                "responseId" => "factory_response",
                "type" => "future_item",
                "kind" => "custom",
                "internalConsentLink" => "https://example.com/consent",
                _ => Type.Missing
            }).ToArray();
            object model = factory.Invoke(null, arguments);
            Assert.That(model, Is.Not.Null, factory.Name);
            if (model is AgentResponseItem item)
            {
                Assert.That(item.Id, Is.EqualTo("factory_id"), factory.Name);
                Assert.That(item.AgentReference.Name, Is.EqualTo("factory_agent"), factory.Name);
                Assert.That(item.ResponseId, Is.EqualTo("factory_response"), factory.Name);
            }
        }
    }

    [Test]
    public void NativeConstructionInitializesKnownDiscriminators()
    {
        ResponseItem[] items =
        [
            new BingGroundingToolCall("call", "{}", ToolCallStatus.Completed),
            new BingGroundingToolCall("call", "{}", ToolCallStatus.Completed, additionalBinaryDataProperties: null)
        ];
        foreach (ResponseItem item in items)
        {
            Assert.That(item.Kind, Is.EqualTo(ResponseItemKind.BingGroundingCall));
            Assert.That(ModelReaderWriter.Read<ResponseItem>(
                ModelReaderWriter.Write(item, ModelReaderWriterOptions.Json, AzureAIExtensionsOpenAIContext.Default),
                ModelReaderWriterOptions.Json, AzureAIExtensionsOpenAIContext.Default), Is.TypeOf<BingGroundingToolCall>());
        }
    }

    [Test]
    public void LegacyConversationAndMemoryAliasesRemainFunctional()
    {
        ProjectConversation conversation = ModelReaderWriter.Read<ProjectConversation>(
            BinaryData.FromString(ConversationJson()), ModelReaderWriterOptions.Json, AzureAIExtensionsOpenAIContext.Default);
        string id = conversation;
        Assert.That(id, Is.EqualTo("conv_1"));
        Assert.That(conversation.Metadata["key"], Is.EqualTo("value"));
        Assert.That(conversation.CreatedAt, Is.EqualTo(DateTimeOffset.FromUnixTimeSeconds(123)));
        var action = new AgentWorkflowPreviewActionResponseItem("invoke", "action", null);
        action.Kind = "updated";
        Assert.That(action.CSDLActionKind, Is.EqualTo("updated"));
        Assert.That(((ResponseItem)action).Kind, Is.EqualTo(ResponseItemKind.WorkflowAction));
        var memory = new ChatSummaryMemoryItem("memory", updatedAt: DateTimeOffset.FromUnixTimeSeconds(0), "scope", "content");
        memory.UpdatedAt = DateTimeOffset.FromUnixTimeSeconds(0).AddDays(1);
        Assert.That(memory.UpdatedOn, Is.EqualTo(memory.UpdatedAt));
    }

    [TestCase("conv_2")]
    [TestCase("conv_\"quoted\"\\path")]
    [TestCase("conv_\nnext")]
    public void BothExtensionAccessorContainersKeepWorking(string conversationId)
    {
        var options = new CreateResponseOptions();
        options.Agent = new AgentReference("legacy-container");
        options.AgentConversationId = "conv_1";
        Type preview = typeof(CreateResponseOptionsExtensions);
        Assert.That(((AgentReference)preview.GetMethod("get_Agent").Invoke(null, [options])).Name, Is.EqualTo("legacy-container"));
        Assert.That(preview.GetMethod("get_AgentConversationId").Invoke(null, [options]), Is.EqualTo("conv_1"));
        preview.GetMethod("set_Agent").Invoke(null, [options, new AgentReference("preview-container")]);
        preview.GetMethod("set_AgentConversationId").Invoke(null, [options, conversationId]);
        Assert.That(options.Agent.Name, Is.EqualTo("preview-container"));
        Assert.That(options.AgentConversationId, Is.EqualTo(conversationId));
        options.AgentConversationId = null;
        Assert.That(preview.GetMethod("get_AgentConversationId").Invoke(null, [options]), Is.Null);

        ResponseResult result = ModelReaderWriter.Read<ResponseResult>(BinaryData.FromString(
            """{"id":"resp","object":"response","created_at":0,"status":"completed","model":"model","output":[],"agent_reference":{"name":"agent"},"conversation":{"id":"conv_3"}}"""));
        Assert.That(((AgentReference)typeof(ResponseResultExtensions).GetMethod("get_Agent").Invoke(null, [result])).Name, Is.EqualTo(result.Agent.Name));
        Assert.That(typeof(ResponseResultExtensions).GetMethod("get_AgentConversationId").Invoke(null, [result]), Is.EqualTo(result.AgentConversationId));
    }

    [TestCase(false)]
    [TestCase(true)]
    public async Task LegacyConversationMethodsPreserveResponsesAndMetadata(bool isAsync)
    {
        var bodies = new List<JsonElement>();
        var transport = new MockPipelineTransport(message =>
        {
            if (message.Request.Content != null)
            {
                using var stream = new MemoryStream();
                message.Request.Content.WriteTo(stream, CancellationToken.None);
                using JsonDocument document = JsonDocument.Parse(stream.ToArray());
                bodies.Add(document.RootElement.Clone());
            }
            return new MockPipelineResponse(200).WithContent(ConversationJson());
        })
        {
            ExpectSyncPipeline = !isAsync
        };
        ProjectConversationsClient client = CreateClient(transport).GetProjectConversationsClient();
        var creation = new ProjectConversationCreationOptions { Metadata = { ["created"] = "yes" } };
        creation.Items.Add(ResponseItem.CreateUserMessageItem("hello"));
        var update = new ProjectConversationUpdateOptions { Metadata = { ["updated"] = "yes" } };
        ClientResult<ProjectConversation> created = isAsync
            ? await client.CreateProjectConversationAsync(creation)
            : client.CreateProjectConversation(creation);
        ClientResult<ProjectConversation> retrieved = isAsync
            ? await client.GetProjectConversationAsync("conv_1")
            : client.GetProjectConversation("conv_1");
        ClientResult<ProjectConversation> updated = isAsync
            ? await client.UpdateProjectConversationAsync("conv_1", update)
            : client.UpdateProjectConversation("conv_1", update);
        foreach (ClientResult<ProjectConversation> result in new[] { created, retrieved, updated })
        {
            Assert.That(result.Value.Id, Is.EqualTo("conv_1"));
            Assert.That(result.Value.Metadata["key"], Is.EqualTo("value"));
            Assert.That(result.GetRawResponse().Status, Is.EqualTo(200));
        }
        Assert.That(transport.Requests, Has.Count.EqualTo(3));
        Assert.That(bodies, Has.Count.EqualTo(2));
        Assert.That(bodies[0].GetProperty("metadata").GetProperty("created").GetString(), Is.EqualTo("yes"));
        Assert.That(bodies[0].GetProperty("items").GetArrayLength(), Is.EqualTo(1));
        Assert.That(bodies[1].GetProperty("metadata").GetProperty("updated").GetString(), Is.EqualTo("yes"));
    }

    [TestCase(false)]
    [TestCase(true)]
    public async Task LegacyConversationItemMethodsPreserveTypedItems(bool isAsync)
    {
        var transport = new MockPipelineTransport(_ => new MockPipelineResponse(200).WithContent(ItemJson("bing_grounding_call")))
        {
            ExpectSyncPipeline = !isAsync
        };
        ProjectConversationsClient client = CreateClient(transport).GetProjectConversationsClient();
        ClientResult<AgentResponseItem> result = isAsync
            ? await client.GetProjectConversationItemAsync("conv", "item")
            : client.GetProjectConversationItem("conv", "item");
        Assert.That(result.Value, Is.TypeOf<BingGroundingToolCall>());
        Assert.That(result.Value.Id, Is.EqualTo("item_1"));
    }

    [TestCase(false, false)]
    [TestCase(true, false)]
    [TestCase(false, true)]
    [TestCase(true, true)]
    public async Task LegacyListsRemainLazyAndFollowContinuation(bool isAsync, bool items)
    {
        int pages = 0;
        var transport = new MockPipelineTransport(_ =>
        {
            int page = ++pages;
            string payload = items ? ItemJson("bing_grounding_call", $"item_{page}") : ConversationJson($"conv_{page}");
            return new MockPipelineResponse(200).WithContent(
                $$"""{"data":[{{payload}}],"has_more":{{(page == 1 ? "true" : "false")}},"first_id":"id_{{page}}","last_id":"id_{{page}}"}""");
        })
        { ExpectSyncPipeline = !isAsync };
        ProjectConversationsClient client = CreateClient(transport).GetProjectConversationsClient();
        var ids = new List<string>();
        if (items && isAsync)
        {
            AsyncCollectionResult<AgentResponseItem> result = client.GetProjectConversationItemsAsync("conv", AgentResponseItemKind.BingGroundingCall);
            Assert.That(pages, Is.Zero);
            await foreach (AgentResponseItem item in result)
            { ids.Add(item.Id); }
        }
        else if (items)
        {
            CollectionResult<AgentResponseItem> result = client.GetProjectConversationItems("conv", AgentResponseItemKind.BingGroundingCall);
            Assert.That(pages, Is.Zero);
            ids.AddRange(result.Select(item => item.Id));
        }
        else if (isAsync)
        {
            AsyncCollectionResult<ProjectConversation> result = client.GetProjectConversationsAsync();
            Assert.That(pages, Is.Zero);
            await foreach (ProjectConversation conversation in result)
            { ids.Add(conversation.Id); }
        }
        else
        {
            CollectionResult<ProjectConversation> result = client.GetProjectConversations();
            Assert.That(pages, Is.Zero);
            ids.AddRange(result.Select(conversation => conversation.Id));
        }
        Assert.That(ids, Is.EqualTo(items ? new[] { "item_1", "item_2" } : new[] { "conv_1", "conv_2" }));
        Assert.That(pages, Is.EqualTo(2));
        Assert.That(transport.Requests[1].Uri.Query, Does.Contain("after=id_1"));
    }

    [TestCase(false)]
    [TestCase(true)]
    public async Task LegacyResponseOptionsKeepTheirPipelinePolicies(bool isAsync)
    {
        const string response = """{"id":"resp","object":"response","created_at":0,"status":"completed","model":"model","output":[]}""";
        var transport = new MockPipelineTransport(_ => new MockPipelineResponse(200).WithContent(response))
        {
            ExpectSyncPipeline = !isAsync
        };
        var options = new ProjectResponsesClientOptions { Transport = transport };
        ProjectOpenAIClientOptions originalBase = options;
        var policy = new MarkerPolicy();
        originalBase.AddPolicy(policy, PipelinePosition.PerCall);
        var client = new ProjectResponsesClient(new Uri("https://example.test/api/projects/p"), new FakeTokenProvider(), options);
        if (isAsync)
        { await client.CreateResponseAsync("model", "hello"); }
        else
        { client.CreateResponse("model", "hello"); }
        Assert.That(policy.Invocations, Is.EqualTo(1));
        Assert.That(transport.Requests[0].Headers.TryGetValue("x-legacy-policy", out string value), Is.True);
        Assert.That(value, Is.EqualTo("present"));
        Assert.That(options.IsReadOnly, Is.True);
    }

    [TestCase(false)]
    [TestCase(true)]
    public void LegacyConversationMethodsPropagateServiceErrors(bool isAsync)
    {
        var transport = new MockPipelineTransport(_ => new MockPipelineResponse(400)
            .WithContent("""{"error":{"code":"invalid_request","message":"bad request"}}"""))
        {
            ExpectSyncPipeline = !isAsync
        };
        ProjectConversationsClient client = CreateClient(transport).GetProjectConversationsClient();
        ClientResultException exception = isAsync
            ? Assert.ThrowsAsync<ClientResultException>(async () => await client.GetProjectConversationAsync("conv"))
            : Assert.Throws<ClientResultException>(() => client.GetProjectConversation("conv"));
        Assert.That(exception.Status, Is.EqualTo(400));
    }

    private static ProjectOpenAIClient CreateClient(MockPipelineTransport transport) =>
        new(new Uri("https://example.test/api/projects/p"), new FakeTokenProvider(), new ProjectOpenAIClientOptions { Transport = transport });

    private static void AssertJsonEqual(BinaryData expected, BinaryData actual)
    {
        using JsonDocument left = JsonDocument.Parse(expected);
        using JsonDocument right = JsonDocument.Parse(actual);
        Assert.That(JsonElement.DeepEquals(left.RootElement, right.RootElement), Is.True, $"{expected}\n{actual}");
    }

    private sealed class DerivedBingCall : BingGroundingToolCall
    {
        public DerivedBingCall() : base("call", "{}", ToolCallStatus.Completed) { }

        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            base.JsonModelWriteCore(writer, options);
            writer.WriteString("custom", "value");
        }

        public AgentResponseItem ReadLegacy(BinaryData data) => PersistableModelCreateCore(data, ModelReaderWriterOptions.Json);
    }

    private sealed class MarkerPolicy : PipelinePolicy
    {
        public int Invocations { get; private set; }
        public override void Process(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
        {
            Invocations++;
            message.Request.Headers.Set("x-legacy-policy", "present");
            ProcessNext(message, pipeline, currentIndex);
        }
        public override ValueTask ProcessAsync(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
        {
            Invocations++;
            message.Request.Headers.Set("x-legacy-policy", "present");
            return ProcessNextAsync(message, pipeline, currentIndex);
        }
    }

    private sealed class FakeTokenProvider : AuthenticationTokenProvider
    {
        public override GetTokenOptions CreateTokenOptions(IReadOnlyDictionary<string, object> properties) => new(properties);
        public override AuthenticationToken GetToken(GetTokenOptions options, CancellationToken cancellationToken)
            => new("test-token", "Bearer", DateTimeOffset.UtcNow.AddHours(1), null);
        public override ValueTask<AuthenticationToken> GetTokenAsync(GetTokenOptions options, CancellationToken cancellationToken)
            => new(GetToken(options, cancellationToken));
    }
}
