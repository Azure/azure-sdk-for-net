// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Threading;
using Microsoft.CodeAnalysis;
using Microsoft.TypeSpec.Generator;
using Microsoft.TypeSpec.Generator.ClientModel;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Snippets;
using Microsoft.TypeSpec.Generator.Statements;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Extensions.Plugin.Visitors;

/// <summary> Emits Foundry Live model and REST integration without runtime customization partials. </summary>
public class VoiceAgentLiveVisitor : ScmLibraryVisitor
{
    private const string LiveClientName = "BetaVoiceAgentsLiveConversations";
    private const string CursorMethodName = "GetLiveContinuationCursor";
    private static readonly string[] RealtimeFactoryParameters =
    [
        "contentFilterConfiguration", "modelType", "model", "conversationEngine", "instructions", "greeting", "audio",
        "outputModalities", "internalMaxOutputTokens", "include", "interimResponse", "avatar", "tools", "internalToolChoice",
        "parallelToolCalls", "structuredInputs", "subagentConfig", "store"
    ];
    private readonly Dictionary<string, ModelProvider> _models = new(StringComparer.Ordinal);
    private ClientProvider _liveClient;
    private CSharpType _responseItemType;
    private CSharpType _realtimeStatusType;
    private CSharpType _realtimeModalityType;

    protected internal static void Configure(InputNamespace input)
    {
        foreach (InputClient client in input.Clients.Where(client => client.Name == "AgentEndpointLiveConversations"))
        {
            client.Update(name: LiveClientName);
        }
    }

    protected override ModelProvider PreVisitModel(InputModelType model, ModelProvider type)
    {
        if (type == null || type.Type.Namespace != "Azure.AI.Projects.Agents")
        {
            return type;
        }

        _models[type.Name] = type;
        if (IsNativeEvent(model))
        {
            MarkExperimental(type);
            ScmCodeModelGenerator.Instance.AddTypeToKeep(type);
        }
        return type;
    }

    protected override PropertyProvider PreVisitProperty(InputProperty property, PropertyProvider provider)
    {
        if (provider?.EnclosingType.Name == "VoiceAgentLiveConversation" && provider.Name == "LastError")
        {
            provider.Update(modifiers: (provider.Modifiers & ~MethodSignatureModifiers.Public) | MethodSignatureModifiers.Internal);
        }
        if (provider?.EnclosingType.Name == "LiveClientEventLiveResponseItemCreateParam" && provider.Name == "Item")
        {
            provider.Update(type: ResponseItemType);
        }
        return provider;
    }

    protected override ClientProvider Visit(InputClient client, ClientProvider provider)
    {
        if (provider != null && client.Name == LiveClientName)
        {
            MarkExperimental(provider);
            _liveClient = provider;
        }
        return provider;
    }

    protected override TypeProvider VisitType(TypeProvider type)
    {
        if (type is not MrwSerializationTypeDefinition && (type.Name is "UnknownLiveClientEvent" or "UnknownLiveServerEvent"))
        {
            MarkExperimental(type);
        }
        if (IsLivePager(type))
        {
            MarkExperimental(type);
            type.Update(methods: [.. type.Methods, BuildCursorMethod(type)]);
        }
        if (type is ClientProvider && type.Name == "AgentAdministrationClient" && _liveClient != null)
        {
            AddLiveClientAccessor(type);
        }
        if (type is ModelFactoryProvider)
        {
            RemoveSupersededVoiceFactories(type);
        }
        return base.VisitType(type);
    }

    protected override MethodProvider VisitMethod(MethodProvider method)
    {
        if (method.Signature.Name == "DeserializeVoiceAgentBaseDefinition")
        {
            method.Update(bodyStatements: BuildVoiceDefinitionDispatch(method));
        }
        if (method.EnclosingType is ModelFactoryProvider && method.Signature.ReturnType?.Name is
            "VoiceAgentDefinition" or "VoiceAgentLiveDefinition" or "VoiceAgentBaseDefinition")
        {
            UpdateVoiceFactory(method);
        }
        return base.VisitMethod(method);
    }

    protected override ValueExpression VisitMemberExpression(MemberExpression expression, MethodProvider method)
    {
        if (IsLivePager(method.EnclosingType) && method.Signature.Name != CursorMethodName &&
            expression.MemberName == "LastId" && expression.Inner != null)
        {
            return Static().Invoke(CursorMethodName, expression.Inner);
        }
        return base.VisitMemberExpression(expression, method);
    }

    protected override ValueExpression VisitInvokeMethodExpression(InvokeMethodExpression expression, MethodProvider method)
    {
        string invocation = expression.MethodSignature?.Name ?? expression.MethodName;
        ValueExpression argument = expression.Arguments.Count > 0 ? expression.Arguments[0] : null;
        while (argument is ScopedApi scoped)
        {
            argument = scoped.Original;
        }
        if (method.Signature.Name == "DeserializeVoiceResult" && invocation == "Read" &&
            expression.TypeArguments?.Count == 1 && expression.TypeArguments[0].Name == "RealtimeOutputModality" &&
            argument is InvokeMethodExpression bytes && bytes.InstanceReference != null)
        {
            _realtimeModalityType ??= ResolveOpenAIType("OpenAI.Realtime.RealtimeOutputModality");
            return New.Instance(_realtimeModalityType, bytes.InstanceReference.Invoke(nameof(JsonElement.GetString)));
        }
        if (method.EnclosingType.Name == "VoiceResult" && method.Signature.Name == "JsonModelWriteCore" &&
            invocation == "WriteObjectValue" &&
            ((expression.TypeArguments?.Count == 1 && expression.TypeArguments[0].Name == "RealtimeResponseStatus") ||
             argument is VariableExpression { Type.Name: "RealtimeOutputModality" }))
        {
            return expression.InstanceReference.Invoke(nameof(Utf8JsonWriter.WriteStringValue),
                expression.Arguments[0].Invoke(nameof(ToString)));
        }
        return base.VisitInvokeMethodExpression(expression, method);
    }

    protected override ValueExpression VisitAssignmentExpression(AssignmentExpression expression, MethodProvider method)
    {
        if (method.Signature.Name == "DeserializeVoiceResult" &&
            expression.Variable is VariableExpression status && status.Declaration.RequestedName == "status")
        {
            ValueExpression element = method.Signature.Parameters[0].AsVariable();
            _realtimeStatusType ??= ResolveOpenAIType("OpenAI.Realtime.RealtimeResponseStatus");
            return new AssignmentExpression(expression.Variable,
                New.Instance(_realtimeStatusType, element.Invoke(nameof(JsonElement.GetProperty), Literal("status")).Invoke(nameof(JsonElement.GetString))));
        }
        if (method.Signature.Name == "DeserializeLiveClientEventLiveResponseItemCreateParam" &&
            expression.Variable is VariableExpression variable && variable.Declaration.RequestedName == "item")
        {
            ValueExpression element = method.Signature.Parameters[0].AsVariable();
            ValueExpression options = method.Signature.Parameters[1].AsVariable();
            return new AssignmentExpression(expression.Variable,
                Static().Invoke("CustomSerializationHelpers.DeserializeProjectOpenAIType",
                    [element.Invoke(nameof(JsonElement.GetProperty), Literal("item")), options], [ResponseItemType]));
        }
        return base.VisitAssignmentExpression(expression, method);
    }

    private CSharpType ResponseItemType
    {
        get
        {
            if (_responseItemType == null)
            {
                _responseItemType = ResolveOpenAIType("OpenAI.Responses.ResponseItem");
            }
            return _responseItemType;
        }
    }

    private static CSharpType ResolveOpenAIType(string name)
    {
        PortableExecutableReference reference = CodeModelGenerator.Instance.AdditionalMetadataReferences
            .OfType<PortableExecutableReference>()
            .Single(candidate => string.Equals(Path.GetFileName(candidate.FilePath), "OpenAI.dll", StringComparison.OrdinalIgnoreCase));
        return new CSharpType(Assembly.LoadFrom(reference.FilePath).GetType(name, throwOnError: true));
    }

    private MethodProvider BuildCursorMethod(TypeProvider pager)
    {
        string responseName = pager.Name.Contains("ConversationItems", StringComparison.Ordinal)
            ? "AgentsPagedResultVoiceAgentLiveConversationItem"
            : "AgentsPagedResultVoiceAgentLiveConversation";
        ParameterProvider page = new("page", $"The current Live history page.", _models[responseName].Type);
        ValueExpression value = page.AsVariable();
        return new MethodProvider(
            new MethodSignature(CursorMethodName, $"Gets the next cursor only when more results exist.",
                MethodSignatureModifiers.Private | MethodSignatureModifiers.Static, typeof(string), null, [page]),
            new MethodBodyStatement[]
            {
                new IfStatement(Not(value.Property("HasMore"))) { Return(Null) },
                new IfStatement(Static<string>().Invoke(nameof(string.IsNullOrEmpty), value.Property("LastId")))
                {
                    Throw(New.Instance<JsonException>(Literal("A Live conversation page with has_more=true must include a non-empty last_id.")))
                },
                Return(value.Property("LastId"))
            }, pager);
    }

    private MethodBodyStatement[] BuildVoiceDefinitionDispatch(MethodProvider method)
    {
        ValueExpression element = method.Signature.Parameters[0].AsVariable();
        ValueExpression options = method.Signature.Parameters[1].AsVariable();
        DeclarationExpression protocol = new(typeof(JsonElement), "protocol", out var protocolValue, isOut: true);
        ValueExpression realtime = Static(_models["VoiceAgentDefinition"].Type)
            .Invoke("DeserializeVoiceAgentDefinition", element, options);
        ValueExpression live = Static(_models["VoiceAgentLiveDefinition"].Type)
            .Invoke("DeserializeVoiceAgentLiveDefinition", element, options);
        return
        [
            new IfStatement(element.Property(nameof(JsonElement.ValueKind)).Equal(FrameworkEnumValue(JsonValueKind.Null)))
            {
                Return(Null)
            },
            new IfStatement(Not(element.Invoke(nameof(JsonElement.TryGetProperty), Literal("sub_protocol"), protocol)))
            {
                Return(realtime)
            },
            new IfStatement(protocolValue.Property(nameof(JsonElement.ValueKind)).NotEqual(FrameworkEnumValue(JsonValueKind.String)))
            {
                Throw(New.Instance<JsonException>(Literal("A voice agent sub_protocol must be 'realtime' or 'live'.")))
            },
            new IfStatement(protocolValue.Invoke(nameof(JsonElement.GetString)).Equal(Literal("realtime")))
            {
                Return(realtime)
            },
            new IfStatement(protocolValue.Invoke(nameof(JsonElement.GetString)).Equal(Literal("live")))
            {
                Return(live)
            },
            Throw(New.Instance<JsonException>(Literal("Unsupported voice agent sub_protocol.")))
        ];
    }

    private void AddLiveClientAccessor(TypeProvider administration)
    {
        FieldProvider cache = new(FieldModifiers.Private, _liveClient.Type, "_cachedAgentEndpointLiveConversations", administration);
        cache.Update(attributes: [ExperimentalAttribute()]);
        ValueExpression cached = cache.AsValueExpression;
        ValueExpression result = Static(typeof(Volatile)).Invoke(nameof(Volatile.Read), new ArgumentExpression(cached, IsRef: true))
            .NullCoalesce(Static(typeof(Interlocked)).Invoke(nameof(Interlocked.CompareExchange),
                [new ArgumentExpression(cached, IsRef: true),
                New.Instance(_liveClient.Type, This.Property("ClientDiagnostics"), This.Property("Pipeline"),
                    This.Property("_endpoint"), This.Property("_apiVersion")), Null]))
            .NullCoalesce(cached);
        MethodProvider accessor = new(
            new MethodSignature("GetBetaVoiceAgentEndpointLiveConversations",
                $"Gets the client for stored native Live conversations.",
                MethodSignatureModifiers.Public | MethodSignatureModifiers.Virtual, _liveClient.Type, null, [],
                Attributes: [ExperimentalAttribute()]),
            Return(result), administration);
        administration.Update(fields: [.. administration.Fields, cache], methods: [.. administration.Methods, accessor]);
    }

    private static void RemoveSupersededVoiceFactories(TypeProvider factory)
    {
        List<MethodProvider> methods = [.. factory.Methods];
        foreach (string name in new[] { "VoiceAgentDefinition", "VoiceAgentLiveDefinition", "VoiceAgentBaseDefinition" })
        {
            MethodProvider primary = methods.Where(method => method.Signature.Name == name)
                .OrderByDescending(method => method.Signature.Parameters.Count).FirstOrDefault();
            if (primary?.Signature.Parameters.Any(parameter => parameter.Name == "kind") == true)
            {
                methods.RemoveAll(method => method.Signature.Name == name && !ReferenceEquals(method, primary));
            }
        }
        factory.Update(methods: methods);
    }

    private void UpdateVoiceFactory(MethodProvider method)
    {
        if (!method.Signature.Parameters.Any(parameter => parameter.Name == "kind") || method.BodyStatements == null)
        {
            return;
        }
        string name = method.Signature.ReturnType.Name;
        ParameterProvider[] parameters = name == "VoiceAgentDefinition"
            ? RealtimeFactoryParameters.Select(parameterName => method.Signature.Parameters.Single(parameter => parameter.Name == parameterName)).ToArray()
            : method.Signature.Parameters.Where(parameter => parameter.Name != "kind").ToArray();
        IReadOnlyList<ParameterProvider> constructor = _models[name].FullConstructor.Signature.Parameters;
        List<MethodBodyStatement> body = [];
        foreach (MethodBodyStatement statement in method.BodyStatements)
        {
            if (statement is ExpressionStatement
                {
                    Expression: KeywordExpression { Expression: NewInstanceExpression instance }
                })
            {
                if (instance.Parameters.Count != constructor.Count)
                {
                    throw new InvalidOperationException($"Unexpected factory constructor shape for {name}.");
                }
                ValueExpression[] arguments = instance.Parameters.Select((argument, index) =>
                    constructor[index].Name switch
                    {
                        "kind" => Literal("voice"),
                        "subProtocol" when name == "VoiceAgentDefinition" => Default,
                        "subProtocol" when name == "VoiceAgentLiveDefinition" => Literal("live"),
                        "modelType" when name == "VoiceAgentLiveDefinition" => Literal("self_deployed"),
                        _ => argument
                    }).ToArray();
                body.Add(Return(New.Instance(instance.Type, arguments)));
            }
            else
            {
                body.Add(statement);
            }
        }
        XmlDocProvider docs = new(method.XmlDocs.Summary,
            parameters.Select(parameter => new XmlDocParamStatement(parameter)).ToArray(),
            returns: new XmlDocReturnsStatement($"A new {method.Signature.ReturnType:C} instance for mocking."));
        method.Signature.Update(parameters: parameters);
        method.Update(signature: method.Signature, bodyStatements: body, xmlDocProvider: docs);
    }

    protected internal static bool IsNativeEvent(InputModelType model)
    {
        for (InputModelType current = model; current != null; current = current.BaseModel)
        {
            if (current.Name is "LiveClientEvent" or "LiveServerEvent")
            {
                return true;
            }
        }
        return false;
    }

    private static bool IsLivePager(TypeProvider type)
        => type is CollectionResultDefinition && type.Name.StartsWith(LiveClientName, StringComparison.Ordinal);

    private static AttributeStatement ExperimentalAttribute()
        => new(typeof(ExperimentalAttribute), Literal("AAIP001"));

    private static void MarkExperimental(TypeProvider type)
    {
        if (!type.Attributes.Any(attribute => attribute.Type.Equals(typeof(ExperimentalAttribute))))
        {
            type.Update(attributes: [.. type.Attributes, ExperimentalAttribute()]);
        }
    }
}
