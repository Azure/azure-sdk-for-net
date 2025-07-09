// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Reflection.Metadata;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.TypeSpec.Generator.ClientModel;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Statements;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Azure.Generator.Visitors
{
    internal class SystemTextJsonConverterVisitor : ScmLibraryVisitor
    {
        protected override ModelProvider? PreVisitModel(InputModelType model, ModelProvider? type)
        {
            if (model.Decorators.Any(d => d.Name == "Azure.ClientGenerator.Core.@useSystemTextJsonConverter"))
            {
                var converter
                type!.Update(attributes: [..type!.Attributes, new AttributeStatement(typeof(JsonConverter), TypeOf(typeof(int)))]);
            }

            return type;
        }

        private class ConverterTypeProvider : TypeProvider
        {
            private readonly ModelProvider _modelProvider;

            public ConverterTypeProvider(ModelProvider modelProvider)
            {
                _modelProvider = modelProvider;
            }

            protected override string BuildRelativeFilePath() => _modelProvider.RelativeFilePath;

            protected override string BuildName() => $"{_modelProvider.Name}Converter";

            protected override CSharpType GetBaseType() => new CSharpType(typeof(JsonConverter<>), _modelProvider.Type);

            protected override MethodProvider[] BuildMethods()
            {
                return new[]
                {
                    new MethodProvider(new MethodSignature(
                            "Write",
                            $"Writes the JSON representation of the model.",
                            MethodSignatureModifiers.Public | MethodSignatureModifiers.Override,
                            null,
                                    null,
                            [
                                new ParameterProvider("writer",$"The writer.", typeof(Utf8JsonWriter)),
                                new ParameterProvider("model", $"The model to write.", _modelProvider.Type),
                                new ParameterProvider("options", $"The serialization options.", typeof(JsonSerializerOptions))
                            ]),
                        bodyStatements:

                    new MethodProvider("Write", new[] { new ParameterProvider("writer", typeof(JsonWriter)), new ParameterProvider("value", _modelProvider.Type) })
                    {
                        Body = new MethodBodyStatement(
                            Return())
                    }
                };
            }

            private void BuildWriteMethod()
            {
                var writerParameter = new ParameterProvider("writer", $"The writer.", typeof(Utf8JsonWriter));
                var modelParameter = new ParameterProvider("model", $"The model to write.", _modelProvider.Type);

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
                    bodyStatements: [writerParameter.As<Utf8JsonWriter>()(),]);
                        modelParameter.As(_modelProvider.Type).Invoke("WriteTo", writerParameter),
                        writerParameter.As<Utf8JsonWriter>().WriteEndObject(),
                        Return()]);
            }
        }
    }
}