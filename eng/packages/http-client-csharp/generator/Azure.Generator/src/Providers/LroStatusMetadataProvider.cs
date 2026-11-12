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

        internal LroStatusMetadataProvider(string name, string @namespace, IReadOnlyList<InputLroStatusMetadata> metadata, TypeSignatureModifiers modifiers)
        {
            _name = name;
            _namespace = @namespace;
            _metadata = metadata;
            _modifiers = modifiers;
            _getResponse = new FieldProvider(FieldModifiers.Private | FieldModifiers.ReadOnly,
                typeof(Func<Response>), "_getResponse", this);
        }

        protected override string BuildName() => _name;
        protected override string BuildNamespace() => _namespace;
        protected override string BuildRelativeFilePath() => Path.Combine("src", "Generated", "LongRunningOperation", $"{Name}.cs");
        protected override FormattableString BuildDescription() =>
            $"Auxiliary metadata from the latest status-monitor response. Values can change or become absent after each poll.";
        protected override TypeSignatureModifiers BuildDeclarationModifiers() => _modifiers;
        protected override FieldProvider[] BuildFields() => [_getResponse];

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
