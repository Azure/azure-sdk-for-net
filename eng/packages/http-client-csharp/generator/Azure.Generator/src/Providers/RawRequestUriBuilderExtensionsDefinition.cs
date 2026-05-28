// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.IO;
using Azure.Core;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.ClientModel.Snippets;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Snippets;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Azure.Generator.Providers
{
    internal class RawRequestUriBuilderExtensionsDefinition : TypeProvider
    {
        protected override string BuildRelativeFilePath() => Path.Combine("src", "Generated", "Internal", $"{Name}.cs");

        protected override string BuildName() => "RawRequestUriBuilderExtensions";

        protected override TypeSignatureModifiers BuildDeclarationModifiers() =>
            TypeSignatureModifiers.Internal | TypeSignatureModifiers.Static | TypeSignatureModifiers.Class;

        protected override MethodProvider[] BuildMethods()
        {
            return [BuildAppendQueryDelimitedMethod()];
        }

        private MethodProvider BuildAppendQueryDelimitedMethod()
        {
            var genericArg = typeof(IEnumerable<>).GetGenericArguments()[0];
            var nameParameter = new ParameterProvider("name", $"The name.", typeof(string));
            var valueParameter =
                new ParameterProvider("value", $"The value.", new CSharpType(typeof(IEnumerable<>), genericArg));
            var delimiterParameter = new ParameterProvider("delimiter", $"The delimiter.", typeof(string));
            var serializationFormatType = new SerializationFormatDefinition().Type;

            var formatParameter = new ParameterProvider(
                "format",
                $"The format.",
                serializationFormatType,
                new MemberExpression(serializationFormatType, SerializationFormatDefinition.Default));
            var escapeParameter = new ParameterProvider("escape", $"Whether to escape the value.", typeof(bool), Bool(true));

            var uriBuilder = new ParameterProvider("builder", $"The request URI builder instance.", typeof(RawRequestUriBuilder));

            var parameters = new[]
                { uriBuilder, nameParameter, valueParameter, delimiterParameter, formatParameter, escapeParameter };

            var modifiers = MethodSignatureModifiers.Public | MethodSignatureModifiers.Static | MethodSignatureModifiers.Extension;

            var signature = new MethodSignature(
                Name: "AppendQueryDelimited",
                Modifiers: modifiers,
                Parameters: parameters,
                ReturnType: null,
                GenericArguments: [genericArg],
                Description: null,
                ReturnDescription: null);

            var value = valueParameter.As(genericArg);

            var v = new VariableExpression(genericArg, "v");
            var convertToStringExpression = v.ConvertToString(formatParameter);
            var selector = new FuncExpression([v.Declaration], convertToStringExpression).As<string>();
            var body = new[]
            {
                delimiterParameter.Assign(Literal(","), true).Terminate(),
                Declare("stringValues", value.Select(selector), out var stringValues),
                new InvokeMethodExpression(
                        uriBuilder, nameof(RawRequestUriBuilder.AppendQuery),
                        [nameParameter, StringSnippets.Join(delimiterParameter, stringValues), escapeParameter])
                        .Terminate()
            };
            return new(signature, body, this, XmlDocProvider.Empty);
        }
    }
}