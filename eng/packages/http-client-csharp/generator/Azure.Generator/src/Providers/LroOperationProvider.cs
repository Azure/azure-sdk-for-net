// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.ClientModel.Snippets;
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
        private readonly List<(InputLroStatusMetadata Metadata, PropertyProvider[] Path)> _selected = [];

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
                _selected.Add((metadata, path));
            }
            if (_selected.Count > 0)
            {
                _monitorCache = new FieldProvider(FieldModifiers.Private,
                    new CSharpType(typeof(Tuple<,>), typeof(Response), _monitorModel!.Type), "_monitorCache", this);
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
            properties.AddRange(_selected.Select(s => BuildMetadataProperty(s.Path)));
            return properties.ToArray();
        }

        private PropertyProvider DelegatedProperty(string name, CSharpType type) =>
            new(null, MethodSignatureModifiers.Public | MethodSignatureModifiers.Override, type, name,
                new ExpressionPropertyBody(_operation.Property(name)), this);

        // Each property reads the latest status-monitor model; it never parses JSON itself.
        private PropertyProvider BuildMetadataProperty(PropertyProvider[] path)
        {
            var leaf = path[^1];
            var type = leaf.Type.WithNullable(true);
            ValueExpression value = This.Invoke(GetMonitorModelMethodName);
            foreach (var segment in path)
            {
                value = value.NullConditional().Property(segment.Name);
            }
            MethodBodyStatement[] body;
            if (leaf.Type.IsCollection)
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

        private const string GetMonitorModelMethodName = "GetStatusMonitorModel";

        // Deserializes the status-monitor response once with the model's generated deserializer and caches the result with the
        // response it came from. A single tuple field keeps the response and model consistent when read concurrently.
        private MethodProvider BuildGetMonitorModelMethod()
        {
            var modelType = _monitorModel!.Type;
            var cacheType = _monitorCache!.Type;
            var body = new MethodBodyStatement[]
            {
                Declare("response", typeof(Response), _getResponse.AsValueExpression.NullConditional().Invoke("Invoke"), out var response),
                new IfStatement(response.Equal(Null)) { Return(Null) },
                Declare("cache", cacheType, _monitorCache, out var cached),
                new IfStatement(cached.NotEqual(Null).And(Static<object>().Invoke(nameof(ReferenceEquals), cached.Property("Item1"), response)))
                {
                    Return(cached.Property("Item2"))
                },
                Declare("model", modelType, Default, out var model),
                new TryCatchFinallyStatement(
                    new TryExpression(model.Assign(Static(typeof(ModelReaderWriter)).Invoke(nameof(ModelReaderWriter.Read),
                        [
                            response.Property(nameof(Response.Content)),
                            Static(new ModelSerializationExtensionsDefinition().Type).Property("WireOptions"),
                            ModelReaderWriterContextSnippets.Default
                        ], [modelType])).Terminate()),
                    // Malformed or unexpected monitor payloads expose absent metadata instead of throwing from a property getter.
                    [new CatchExpression(Static(typeof(Exception)))],
                    null),
                _monitorCache.Assign(New.Instance(cacheType, response, model)).Terminate(),
                Return(model)
            };
            return new MethodProvider(
                new MethodSignature(GetMonitorModelMethodName, null, MethodSignatureModifiers.Private, modelType, null, []), body, this);
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
                methods.Add(BuildGetMonitorModelMethod());
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
