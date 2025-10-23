// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.TypeSpec.Generator.ClientModel;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.ClientModel.Snippets;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Snippets;
using Microsoft.TypeSpec.Generator.Statements;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;
using JsonConverter = System.Text.Json.Serialization.JsonConverter;

namespace Azure.Generator.Visitors
{
    internal class SystemTextJsonConverterVisitor : ScmLibraryVisitor
    {
        private const string SystemTextJsonConverterDecoratorName = "Azure.ClientGenerator.Core.@useSystemTextJsonConverter";
        private static readonly ValueExpression WireOptions = Static(new ModelSerializationExtensionsDefinition().Type).Property("WireOptions");

        protected override ModelProvider? PreVisitModel(InputModelType model, ModelProvider? type)
        {
            if (model.Decorators.Any(d => d.Name == SystemTextJsonConverterDecoratorName) && type?.SerializationProviders.Count > 0)
            {
                AzureClientGenerator.Instance.AddTypeToKeep(type);
                var serializationProvider = type.SerializationProviders[0];
                var converter = new ConverterTypeProvider(serializationProvider);
                serializationProvider.Update(
                    attributes: [..serializationProvider.Attributes, new AttributeStatement(typeof(JsonConverter), TypeOf(converter.Type))],
                    nestedTypes: [..serializationProvider.NestedTypes, converter]);
            }

            return type;
        }

        private class ConverterTypeProvider : TypeProvider
        {
            private readonly TypeProvider _serializationProvider;

            public ConverterTypeProvider(TypeProvider serializationProvider)
            {
                _serializationProvider = serializationProvider;
            }

            protected override string BuildRelativeFilePath() => _serializationProvider.RelativeFilePath;

            protected override string BuildName() => $"{_serializationProvider.Name}Converter";

            protected override string BuildNamespace() => _serializationProvider.Type.Namespace;

            protected override CSharpType BuildBaseType() => new CSharpType(typeof(JsonConverter<>), _serializationProvider.Type);

            protected override TypeProvider BuildDeclaringTypeProvider() => _serializationProvider;

            protected override TypeSignatureModifiers BuildDeclarationModifiers() => TypeSignatureModifiers.Internal | TypeSignatureModifiers.Partial;

            protected override MethodProvider[] BuildMethods() => [BuildWriteMethod(), BuildReadMethod()];

            private MethodProvider BuildWriteMethod()
            {
                var writerParameter = new ParameterProvider("writer", $"The writer.", typeof(Utf8JsonWriter));
                var modelParameter = new ParameterProvider("model", $"The model to write.", _serializationProvider.Type);
                return new MethodProvider(new MethodSignature(
                        "Write",
                        $"Writes the JSON representation of the model.",
                        MethodSignatureModifiers.Public | MethodSignatureModifiers.Override,
                        null,
                        null,
                        [
                            writerParameter,
                            modelParameter,
                            new ParameterProvider("options", $"The serialization options.",
                                typeof(JsonSerializerOptions))
                        ]),
                    bodyStatements:
                        writerParameter.As<Utf8JsonWriter>().WriteObjectValue(
                            modelParameter.As(new CSharpType(typeof(IJsonModel<>), _serializationProvider.Type)),
                            WireOptions),
                    this);
            }

            private MethodProvider BuildReadMethod()
            {
                var readerParameter = new ParameterProvider("reader", $"The reader.", typeof(Utf8JsonReader), isRef: true);
                return new MethodProvider(new MethodSignature(
                        "Read",
                        $"Reads the JSON representation and converts into the model.",
                        MethodSignatureModifiers.Public | MethodSignatureModifiers.Override,
                        _serializationProvider.Type,
                        null,
                        [
                            readerParameter,
                            new ParameterProvider("typeToConvert", $"The type to convert.", typeof(Type)),
                            new ParameterProvider("options", $"The serialization options.", typeof(JsonSerializerOptions))
                        ]),
                    bodyStatements:
                        new[]
                        {
                            UsingDeclare("document", typeof(JsonDocument), Static<JsonDocument>().Invoke(nameof(JsonDocument.ParseValue), readerParameter.AsArgument()), out var documentVariable),
                            Return(Static().Invoke(
                                $"Deserialize{_serializationProvider.Name}",
                                documentVariable.Property(nameof(JsonDocument.RootElement)),
                                WireOptions))
                        },
                    this);
            }
        }
    }
}