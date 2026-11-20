// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Snippets;
using Microsoft.TypeSpec.Generator.Statements;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Azure.Generator.Providers
{
    /// <summary>
    /// Internal-by-default operation for an LRO with <c>@lroStatusMetadata</c>. It delegates to the standard operation and
    /// exposes each selected status-monitor property directly. Libraries can rename it and make it public with a custom partial class.
    /// </summary>
    internal sealed class LroOperationProvider : TypeProvider
    {
        private static readonly HashSet<string> ReservedMemberNames = ["Id", "HasCompleted", "Value", "HasValue"];

        private readonly InputLongRunningServiceMethod _method;
        private readonly ClientProvider _client;
        private readonly string _name;
        private readonly FieldProvider _operation;
        private readonly FieldProvider _getResponse;
        private readonly ModelProvider? _monitorModel;
        private readonly FieldProvider? _monitorCache;
        private readonly List<(InputLroStatusMetadata Metadata, PropertyProvider[] Path, int PresenceIndex)> _selected = [];
        private int _presenceCount;

        internal LroOperationProvider(InputLongRunningServiceMethod method, ClientProvider client, string name, CSharpType? resultType)
        {
            _method = method;
            _client = client;
            _name = name;
            ResultType = resultType;
            _operation = new FieldProvider(FieldModifiers.Private | FieldModifiers.ReadOnly,
                resultType is null ? typeof(Operation) : new CSharpType(typeof(Operation<>), resultType), "_operation", this);
            _getResponse = new FieldProvider(FieldModifiers.Private | FieldModifiers.ReadOnly,
                typeof(Func<Response>), "_getStatusMonitorResponse", this);

            var pollingModel = method.LongRunningServiceMetadata.PollingResponseModel;
            _monitorModel = pollingModel is null ? null : AzureClientGenerator.Instance.TypeFactory.CreateModel(pollingModel);
            var names = new HashSet<string>(ReservedMemberNames);
            foreach (var metadata in method.LongRunningServiceMetadata.StatusMetadata)
            {
                var path = _monitorModel is null ? null : ResolvePropertyPath(_monitorModel, metadata.PropertySegments);
                if (path is null || !names.Add(path[^1].Name))
                {
                    AzureClientGenerator.Instance.Emitter.ReportDiagnostic(
                        "AZLRO002",
                        $"Status metadata '{metadata.Property.Name}' of operation '{method.Name}' is not generated because it cannot be read from the status-monitor model or its name conflicts with another operation member.",
                        method.CrossLanguageDefinitionId);
                    continue;
                }
                // The deserializer leaves an absent required value type at its default, so its presence is recorded separately.
                var leafType = path[^1].Type;
                _selected.Add((metadata, path, leafType.IsValueType && !leafType.IsNullable ? _presenceCount++ : -1));
            }
            if (_selected.Count > 0)
            {
                _monitorCache = new FieldProvider(FieldModifiers.Private,
                    _presenceCount > 0
                        ? new CSharpType(typeof(Tuple<,,>), typeof(Response), _monitorModel!.Type, typeof(bool[]))
                        : new CSharpType(typeof(Tuple<,>), typeof(Response), _monitorModel!.Type),
                    "_monitorCache", this);
            }
        }

        internal CSharpType? ResultType { get; }

        protected override string BuildName() => _name;
        protected override string BuildNamespace() => _client.Type.Namespace;
        protected override string BuildRelativeFilePath() => Path.Combine("src", "Generated", "LongRunningOperation", $"{Name}.cs");
        protected override FormattableString BuildDescription() => $"Tracks the long-running {_method.Name} operation and its status-monitor metadata.";
        protected override TypeSignatureModifiers BuildDeclarationModifiers() => TypeSignatureModifiers.Internal | TypeSignatureModifiers.Partial;
        protected override CSharpType BuildBaseType() => _operation.Type;
        protected override FieldProvider[] BuildFields() => _monitorCache is null ? [_operation, _getResponse] : [_operation, _getResponse, _monitorCache];

        protected override ConstructorProvider[] BuildConstructors()
        {
            var operation = new ParameterProvider("operation", $"The underlying operation.", _operation.Type);
            var getResponse = new ParameterProvider("getStatusMonitorResponse", $"Gets the latest status-monitor response.", typeof(Func<Response>));
            return
            [
                new ConstructorProvider(
                    new ConstructorSignature(Type, $"Initializes a new instance for mocking.", MethodSignatureModifiers.Protected, []),
                    Array.Empty<MethodBodyStatement>(), this),
                new ConstructorProvider(
                    new ConstructorSignature(Type, null, MethodSignatureModifiers.Internal, [operation, getResponse]),
                    new MethodBodyStatement[]
                    {
                        _operation.Assign(operation).Terminate(),
                        _getResponse.Assign(getResponse).Terminate()
                    }, this)
            ];
        }

        protected override PropertyProvider[] BuildProperties()
        {
            var properties = new List<PropertyProvider>
            {
                DelegatedProperty("Id", typeof(string)),
                DelegatedProperty("HasCompleted", typeof(bool))
            };
            if (ResultType is not null)
            {
                properties.Add(DelegatedProperty("Value", ResultType));
                properties.Add(DelegatedProperty("HasValue", typeof(bool)));
            }
            properties.AddRange(_selected.Select(s => BuildMetadataProperty(s.Path, s.PresenceIndex)));
            return properties.ToArray();
        }

        private PropertyProvider DelegatedProperty(string name, CSharpType type) =>
            new(null, MethodSignatureModifiers.Public | MethodSignatureModifiers.Override, type, name,
                new ExpressionPropertyBody(_operation.Property(name)), this);

        // Each property reads the latest status-monitor model; it never parses JSON itself.
        private PropertyProvider BuildMetadataProperty(PropertyProvider[] path, int presenceIndex)
        {
            var leaf = path[^1];
            var type = leaf.Type.WithNullable(true);
            var monitor = new VariableExpression(_monitorCache!.Type, "monitor");
            ValueExpression value = presenceIndex >= 0 ? monitor.Property("Item2") : This.Invoke(GetMonitorMethodName).NullConditional().Property("Item2");
            foreach (var segment in path)
            {
                value = value.NullConditional().Property(segment.Name);
            }
            MethodBodyStatement[] body;
            if (presenceIndex >= 0)
            {
                body =
                [
                    Declare(monitor, This.Invoke(GetMonitorMethodName)),
                    Return(new TernaryConditionalExpression(
                        monitor.NotEqual(Null).And(new IndexerExpression(monitor.Property("Item3"), Int(presenceIndex)).As<bool>()), value, Null))
                ];
            }
            else if (leaf.Type.IsCollection)
            {
                // Absent collections deserialize as undefined change-tracking collections; expose them as null.
                var collection = new VariableExpression(type, "value");
                body =
                [
                    Declare(collection, value),
                    Return(new TernaryConditionalExpression(
                        collection.NotEqual(Null).And(Static<OptionalDefinition>().Invoke("IsCollectionDefined", collection).As<bool>()), collection, Null))
                ];
            }
            else
            {
                body = [Return(value)];
            }
            var isPublic = path.All(p => p.Modifiers.HasFlag(MethodSignatureModifiers.Public)) && leaf.Type.GetNestedElementType().IsPublic;
            return new PropertyProvider(leaf.Description,
                (isPublic ? MethodSignatureModifiers.Public : MethodSignatureModifiers.Internal) | MethodSignatureModifiers.Virtual,
                type, leaf.Name, new MethodPropertyBody(body), this);
        }

        private const string GetMonitorMethodName = "GetStatusMonitor";

        // Deserializes the status-monitor response once with the model's generated deserializer and caches the result with the
        // response it came from. A single tuple field keeps the response and model consistent when read concurrently.
        private MethodProvider BuildGetMonitorMethod()
        {
            var modelType = _monitorModel!.Type;
            var cacheType = _monitorCache!.Type;
            var serializationExtensions = Static(new ModelSerializationExtensionsDefinition().Type);
            var body = new List<MethodBodyStatement>
            {
                Declare("response", typeof(Response), _getResponse.AsValueExpression.NullConditional().Invoke("Invoke"), out var response),
                new IfStatement(response.Equal(Null)) { Return(Null) },
                Declare("cache", cacheType, _monitorCache, out var cached),
                new IfStatement(cached.NotEqual(Null).And(Static<object>().Invoke(nameof(ReferenceEquals), cached.Property("Item1"), response)))
                {
                    Return(cached)
                },
                Declare("model", modelType, Default, out var model)
            };
            var cacheArguments = new List<ValueExpression> { response, model };
            var parse = new List<MethodBodyStatement>
            {
                UsingDeclare("document", typeof(JsonDocument), Static<JsonDocument>().Invoke(nameof(JsonDocument.Parse),
                    [response.Property(nameof(Response.Content)), serializationExtensions.Property("JsonDocumentOptions")]), out var document),
                model.Assign(Static(modelType).Invoke($"Deserialize{modelType.Name}",
                    [document.Property(nameof(JsonDocument.RootElement)), serializationExtensions.Property("WireOptions")])).Terminate()
            };
            if (_presenceCount > 0)
            {
                body.Add(Declare("present", typeof(bool[]), New.Array(typeof(bool), Int(_presenceCount)), out var present));
                cacheArguments.Add(present);
                foreach (var (_, path, presenceIndex) in _selected.Where(s => s.PresenceIndex >= 0))
                {
                    parse.Add(new IndexerExpression(present, Int(presenceIndex))
                        .Assign(BuildIsPresent(document.Property(nameof(JsonDocument.RootElement)), path)).Terminate());
                }
            }
            body.Add(new TryCatchFinallyStatement(
                new TryExpression(parse.ToArray()),
                // Malformed or unexpected monitor payloads expose absent metadata instead of throwing from a property getter.
                [new CatchExpression(Static(typeof(Exception)))],
                null));
            body.Add(cached.Assign(New.Instance(cacheType, cacheArguments.ToArray())).Terminate());
            body.Add(_monitorCache.Assign(cached).Terminate());
            body.Add(Return(cached));
            return new MethodProvider(
                new MethodSignature(GetMonitorMethodName, null, MethodSignatureModifiers.Private, cacheType, null, []), body.ToArray(), this);
        }

        // Matches the JSON property path of a required value type, which the generated deserializer cannot report as absent.
        private static ValueExpression BuildIsPresent(ValueExpression root, PropertyProvider[] path)
        {
            ValueExpression element = root;
            ValueExpression? condition = null;
            foreach (var segment in path)
            {
                var next = new DeclarationExpression(typeof(JsonElement), "element", out var nextElement, isOut: true);
                var step = element.Property(nameof(JsonElement.ValueKind)).Equal(FrameworkEnumValue(JsonValueKind.Object))
                    .And(element.Invoke(nameof(JsonElement.TryGetProperty), [LiteralU8(segment.WireInfo!.SerializedName), next]).As<bool>());
                condition = condition is null ? step : condition.As<bool>().And(step);
                element = nextElement;
            }
            return condition!.As<bool>().And(element.Property(nameof(JsonElement.ValueKind)).NotEqual(FrameworkEnumValue(JsonValueKind.Null)));
        }

        private static PropertyProvider[]? ResolvePropertyPath(ModelProvider model, IReadOnlyList<InputModelProperty> segments)
        {
            var path = new PropertyProvider[segments.Count];
            ModelProvider? current = model;
            for (int i = 0; i < segments.Count; i++)
            {
                if (current is null)
                {
                    return null;
                }
                var serializedName = segments[i].SerializedName;
                PropertyProvider? property = null;
                for (var declaring = current; declaring is not null && property is null; declaring = declaring.BaseModelProvider)
                {
                    property = declaring.Properties.FirstOrDefault(p => p.WireInfo?.SerializedName == serializedName);
                }
                if (property is null || (i + 1 < segments.Count && property.Type.IsCollection))
                {
                    return null;
                }
                path[i] = property;
                current = i + 1 < segments.Count && segments[i].Type is InputModelType next
                    ? AzureClientGenerator.Instance.TypeFactory.CreateModel(next)
                    : null;
            }
            return path;
        }

        protected override MethodProvider[] BuildMethods()
        {
            var cancellationToken = new ParameterProvider("cancellationToken", $"The cancellation token.", typeof(CancellationToken));
            var pollingInterval = new ParameterProvider("pollingInterval", $"The polling interval.", typeof(TimeSpan));
            var delayStrategy = new ParameterProvider("delayStrategy", $"The polling delay strategy.", typeof(DelayStrategy));
            var methods = new List<MethodProvider>
            {
                Delegate("GetRawResponse", typeof(Response), []),
                Delegate("GetRehydrationToken", typeof(RehydrationToken?), []),
                Delegate("UpdateStatus", typeof(Response), [cancellationToken]),
                Delegate("UpdateStatusAsync", typeof(ValueTask<Response>), [cancellationToken])
            };
            foreach (var parameters in new ParameterProvider[][] { [cancellationToken], [pollingInterval, cancellationToken], [delayStrategy, cancellationToken] })
            {
                methods.Add(Delegate("WaitForCompletionResponse", typeof(Response), parameters));
                methods.Add(Delegate("WaitForCompletionResponseAsync", typeof(ValueTask<Response>), parameters));
                if (ResultType is not null)
                {
                    var responseType = new CSharpType(typeof(Response<>), ResultType);
                    methods.Add(Delegate("WaitForCompletion", responseType, parameters));
                    methods.Add(Delegate("WaitForCompletionAsync", new CSharpType(typeof(ValueTask<>), responseType), parameters));
                }
            }
            if (_monitorCache is not null)
            {
                methods.Add(BuildGetMonitorMethod());
            }
            return methods.ToArray();
        }

        private MethodProvider Delegate(string name, CSharpType returnType, ParameterProvider[] parameters) =>
            new(new MethodSignature(name, null, MethodSignatureModifiers.Public | MethodSignatureModifiers.Override, returnType, null, parameters),
                _operation.AsValueExpression.Invoke(name, parameters.Select(p => (ValueExpression)p).ToArray()), this);

        internal FuncExpression CreateFactory()
        {
            var operation = new VariableExpression(_operation.Type, "operation");
            var getResponse = new VariableExpression(typeof(Func<Response>), "getStatusMonitorResponse");
            return new FuncExpression([operation.Declaration, getResponse.Declaration], New.Instance(Type, operation, getResponse));
        }
    }
}
