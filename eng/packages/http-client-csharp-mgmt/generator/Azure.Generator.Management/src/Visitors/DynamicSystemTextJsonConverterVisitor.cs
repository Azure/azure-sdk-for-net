// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.ClientModel;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Providers;
using System.Linq;
using System.Text.Json;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Azure.Generator.Management.Visitors;

internal class DynamicSystemTextJsonConverterVisitor : ScmLibraryVisitor
{
    private const string SystemTextJsonConverterDecoratorName = "Azure.ClientGenerator.Core.@useSystemTextJsonConverter";

    protected override ModelProvider? PreVisitModel(InputModelType model, ModelProvider? type)
    {
        if (!model.IsDynamicModel
            || !model.Decorators.Any(d => d.Name == SystemTextJsonConverterDecoratorName)
            || type?.SerializationProviders.Count is not > 0)
        {
            return type;
        }

        var serializationProvider = type.SerializationProviders[0];
        var converter = serializationProvider.NestedTypes.FirstOrDefault(t => t.Name == $"{serializationProvider.Name}Converter");
        var readMethod = converter?.Methods.FirstOrDefault(m => m.Signature.Name == "Read");
        if (readMethod is null)
        {
            return type;
        }

        var readerParameter = readMethod.Signature.Parameters[0];
        var body = new[]
        {
            UsingDeclare(
                "document",
                typeof(JsonDocument),
                Static<JsonDocument>().Invoke(nameof(JsonDocument.ParseValue), readerParameter.AsArgument()),
                out var documentVariable),
            Return(Static(serializationProvider.Type).Invoke(
                $"Deserialize{serializationProvider.Name}",
                [
                    documentVariable.Property(nameof(JsonDocument.RootElement)),
                    documentVariable.Property(nameof(JsonDocument.RootElement)).Invoke("GetUtf8Bytes"),
                    Static<ModelSerializationExtensionsDefinition>().Property("WireOptions")
                ]))
        };
        readMethod.Update(signature: readMethod.Signature, bodyStatements: body);

        return type;
    }
}
