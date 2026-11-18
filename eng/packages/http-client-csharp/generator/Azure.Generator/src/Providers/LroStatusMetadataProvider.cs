// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.ClientModel.Primitives;
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
    internal sealed class LroStatusMetadataProvider : TypeProvider
    {
        private readonly string _name;
        private readonly string _namespace;
        private readonly IReadOnlyList<InputLroStatusMetadata> _metadata;
        private readonly FieldProvider _getResponse;
        private readonly TypeSignatureModifiers _modifiers;
        private readonly ModelProvider? _monitorModel;
        private readonly FieldProvider? _monitorCache;
        private MethodProvider? _getMonitorModel;

        internal LroStatusMetadataProvider(string name, string @namespace, IReadOnlyList<InputLroStatusMetadata> metadata, TypeSignatureModifiers modifiers,
            InputModelType? pollingResponseModel = null)
        {
            _name = name;
            _namespace = @namespace;
            _metadata = metadata;
            _modifiers = modifiers;
            _getResponse = new FieldProvider(FieldModifiers.Private | FieldModifiers.ReadOnly,
                typeof(Func<Response>), "_getResponse", this);
            if (pollingResponseModel is not null &&
                AzureClientGenerator.Instance.TypeFactory.CreateModel(pollingResponseModel) is { } monitorModel &&
                metadata.Any(m => ResolvePropertyPath(monitorModel, m.PropertySegments) is not null))
            {
                _monitorModel = monitorModel;
                _monitorCache = new FieldProvider(FieldModifiers.Private,
                    new CSharpType(typeof(Tuple<,>), typeof(Response), monitorModel.Type), "_monitorCache", this);
            }
        }

        protected override string BuildName() => _name;
        protected override string BuildNamespace() => _namespace;
        protected override string BuildRelativeFilePath() => Path.Combine("src", "Generated", "LongRunningOperation", $"{Name}.cs");
        protected override FormattableString BuildDescription() =>
            $"Auxiliary metadata from the latest status-monitor response. Values can change or become absent after each poll.";
        protected override TypeSignatureModifiers BuildDeclarationModifiers() => _modifiers;
        protected override FieldProvider[] BuildFields() => _monitorCache is null ? [_getResponse] : [_getResponse, _monitorCache];

        protected override MethodProvider[] BuildMethods() => _monitorModel is null ? [] : [GetMonitorModelMethod()];

        // Deserializes the polling response model once per monitor response; every metadata property then reads the cached
        // instance. A single tuple field keeps the response and its model consistent when read concurrently.
        private MethodProvider GetMonitorModelMethod()
        {
            if (_getMonitorModel is not null)
            {
                return _getMonitorModel;
            }
            var modelType = _monitorModel!.Type;
            var signature = new MethodSignature("GetMonitorModel", null, MethodSignatureModifiers.Private, modelType, null, []);
            var cacheType = _monitorCache!.Type;
            var options = Static(new ModelSerializationExtensionsDefinition().Type).Property("WireOptions");
            var body = new MethodBodyStatement[]
            {
                Declare("response", typeof(Response), _getResponse.AsValueExpression.Invoke("Invoke"), out var response),
                new IfStatement(response.Equal(Null)) { Return(Null) },
                Declare("cache", cacheType, _monitorCache.AsValueExpression, out var cached),
                new IfStatement(cached.NotEqual(Null).And(Static<object>().Invoke(nameof(ReferenceEquals), cached.Property("Item1"), response)))
                {
                    Return(cached.Property("Item2"))
                },
                Declare("model", modelType, Default, out var model),
                new TryCatchFinallyStatement(
                    new TryExpression(model.Assign(Static(typeof(ModelReaderWriter)).Invoke(nameof(ModelReaderWriter.Read),
                        [response.Property(nameof(Response.Content)), options, ModelReaderWriterContextSnippets.Default], [modelType])).Terminate()),
                    [MalformedCatch(typeof(JsonException)), MalformedCatch(typeof(InvalidOperationException)), MalformedCatch(typeof(FormatException))],
                    null),
                _monitorCache.Assign(New.Instance(cacheType, response, model)).Terminate(),
                Return(model)
            };
            return _getMonitorModel = new MethodProvider(signature, body, this);
        }

        // Malformed or unexpected monitor payloads expose absent metadata instead of failing the operation.
        private static CatchExpression MalformedCatch(Type exceptionType) => new(Static(exceptionType));

        // Reads the value through the cached monitor model when its property type can be exposed as the metadata type;
        // returns null so the caller falls back to reading the selected JSON path otherwise.
        private PropertyBody? ReadFromMonitorModel(PropertyProvider[] path, CSharpType type)
        {
            ValueExpression value = This.Invoke(GetMonitorModelMethod().Signature);
            foreach (var segment in path)
            {
                value = value.NullConditional().Property(segment.Name);
            }
            var leaf = path[^1].Type;
            var sameType = leaf.WithNullable(false).Equals(type.WithNullable(false));
            if (!leaf.IsCollection)
            {
                return sameType ? new ExpressionPropertyBody(value) : null;
            }
            if (!sameType && !(leaf.IsList && type.IsList && leaf.ElementType.Equals(type.ElementType)))
            {
                return null;
            }
            // Absent collections deserialize as undefined change-tracking collections; expose them as absent (null).
            var collection = new VariableExpression(leaf, "value");
            return new MethodPropertyBody(new MethodBodyStatement[]
            {
                Declare(collection, value),
                Return(new TernaryConditionalExpression(
                    collection.NotEqual(Null).And(Static<OptionalDefinition>().Invoke("IsCollectionDefined", collection).As<bool>()),
                    sameType ? collection : collection.ToList(),
                    Null))
            });
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
                if (property is null)
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

        protected override ConstructorProvider[] BuildConstructors()
        {
            var getResponse = new ParameterProvider("getResponse", $"Gets the latest status-monitor response.", typeof(Func<Response>));
            return
            [
                new ConstructorProvider(
                    new ConstructorSignature(Type, $"Initializes a new instance for mocking.", MethodSignatureModifiers.Protected, []),
                    Array.Empty<MethodBodyStatement>(), this),
                new ConstructorProvider(
                    new ConstructorSignature(Type, null, MethodSignatureModifiers.Internal, [getResponse]),
                    _getResponse.Assign(getResponse).Terminate(), this)
            ];
        }

        protected override PropertyProvider[] BuildProperties() => _metadata.Select(BuildProperty).ToArray();

        private PropertyProvider BuildProperty(InputLroStatusMetadata metadata)
        {
            var property = new PropertyProvider(metadata.Property, this);
            var type = property.Type.OutputType.WithNullable(true);
            if (_monitorModel is not null && ResolvePropertyPath(_monitorModel, metadata.PropertySegments) is { } path &&
                ReadFromMonitorModel(path, type) is { } typedBody)
            {
                property.Update(type: type, modifiers: property.Modifiers | MethodSignatureModifiers.Virtual, body: typedBody);
                return property;
            }
            var statements = new List<MethodBodyStatement>
            {
                Declare("element", typeof(JsonElement?),
                    Static(typeof(ProtocolOperationHelpers)).Invoke("GetStatusMetadata",
                    [
                        _getResponse.AsValueExpression.Invoke("Invoke"),
                        New.Array(typeof(string), metadata.PropertySegments.Select(p => Literal(p.SerializationOptions?.Json?.Name ?? p.SerializedName)).ToArray())
                    ]), out var element),
                new IfStatement(element.Property("HasValue").Equal(False)) { Return(Default) },
                Return(Deserialize(type, element.Property("Value").As<JsonElement>(), property.SerializationFormat))
            };
            property.Update(type: type, modifiers: property.Modifiers | MethodSignatureModifiers.Virtual,
                body: new MethodPropertyBody(statements));
            return property;
        }

        private static ValueExpression Deserialize(CSharpType type, ScopedApi<JsonElement> element, SerializationFormat format)
        {
            ValueExpression value;
            if ((type.IsList || type.IsArray) && !type.WithNullable(false).Equals(typeof(byte[])))
            {
                var item = new VariableExpression(typeof(JsonElement), "item");
                var values = Static(typeof(Enumerable)).Invoke("Select",
                [
                    element.Invoke("EnumerateArray"),
                    new FuncExpression([item.Declaration], Deserialize(type.ElementType, item.As<JsonElement>(), format))
                ]);
                value = Static(typeof(Enumerable)).Invoke(type.IsArray ? "ToArray" : "ToList", values);
            }
            else if (type.IsDictionary)
            {
                var item = new VariableExpression(typeof(JsonProperty), "item");
                value = Static(typeof(Enumerable)).Invoke("ToDictionary",
                [
                    element.Invoke("EnumerateObject"),
                    new FuncExpression([item.Declaration], item.Property("Name")),
                    new FuncExpression([item.Declaration], Deserialize(type.Arguments[1], item.Property("Value").As<JsonElement>(), format))
                ]);
            }
            else
            {
                var options = Static(new ModelSerializationExtensionsDefinition().Type).Property("WireOptions").As<ModelReaderWriterOptions>();
                value = AzureClientGenerator.Instance.TypeFactory.DeserializeJsonValue(
                    type.WithNullable(false), element,
                    Static<BinaryData>().Invoke(nameof(BinaryData.FromString), element.Invoke("GetRawText")).As<BinaryData>(),
                    options, format);
            }
            return type.IsNullable
                ? new TernaryConditionalExpression(
                    element.Property("ValueKind").Equal(FrameworkEnumValue(JsonValueKind.Null)),
                    DefaultOf(type), value)
                : value;
        }
    }
}
