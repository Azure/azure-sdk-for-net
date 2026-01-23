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
using Microsoft.TypeSpec.Generator.Statements;
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
            return new[] { BuildAppendQueryDelimitedMethod(), BuildUpdateQueryMethod() };
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

        private MethodProvider BuildUpdateQueryMethod()
        {
            var uriBuilder = new ParameterProvider("builder", $"The request URI builder instance.", typeof(RawRequestUriBuilder));
            var nameParameter = new ParameterProvider("name", $"The name of the query parameter.", typeof(string));
            var valueParameter = new ParameterProvider("value", $"The value of the query parameter.", typeof(string));

            var parameters = new[] { uriBuilder, nameParameter, valueParameter };
            var modifiers = MethodSignatureModifiers.Public | MethodSignatureModifiers.Static | MethodSignatureModifiers.Extension;

            var signature = new MethodSignature(
                Name: "UpdateQuery",
                Modifiers: modifiers,
                Parameters: parameters,
                ReturnType: null,
                Description: $"Updates an existing query parameter or adds a new one if it doesn't exist.",
                ReturnDescription: null);

            var body = new[]
            {
                MethodBodyStatement.Empty,
                // Get the current query string
                Declare("currentQuery", typeof(string), uriBuilder.Property("Query"), out var currentQueryVar),

                // Create search pattern "name="
                Declare("searchPattern", typeof(string), new BinaryOperatorExpression("+", nameParameter, Literal("=")), out var searchPattern),

                // Check if parameter exists in query string (at start or after &)
                Declare("paramStartIndex", typeof(int), Literal(-1), out var paramStartIndex),

                // Check if parameter is at the beginning of the query
                new IfStatement(currentQueryVar.Invoke("StartsWith", searchPattern))
                {
                    paramStartIndex.Assign(Int(0)).Terminate()
                },

                // Check if parameter is in the middle/end (preceded by &)
                new IfStatement(paramStartIndex.Equal(Int(-1)))
                {
                    Declare("prefixedPattern", typeof(string), new BinaryOperatorExpression("+", Literal("&"), searchPattern), out var prefixedPattern),
                    Declare("prefixedIndex", typeof(int), currentQueryVar.Invoke("IndexOf", prefixedPattern), out var prefixedIndex),
                    new IfStatement(prefixedIndex.GreaterThanOrEqual(Int(0)))
                    {
                        paramStartIndex.Assign(new BinaryOperatorExpression("+", prefixedIndex, Int(1))).Terminate()
                    }
                },

                new IfElseStatement(
                    paramStartIndex.GreaterThanOrEqual(Int(0)),
                    // Parameter exists - replace its value
                    new MethodBodyStatement[]
                    {
                        Declare("valueStartIndex", typeof(int), new BinaryOperatorExpression("+", paramStartIndex, searchPattern.Property("Length")), out var valueStartIndex),
                        Declare("valueEndIndex", typeof(int), currentQueryVar.Invoke("IndexOf", [Literal('&'), valueStartIndex]), out var valueEndIndex),

                        // If no & found after parameter, it goes to end of query
                        new IfStatement(valueEndIndex.Equal(Int(-1)))
                        {
                            valueEndIndex.Assign(currentQueryVar.Property("Length")).Terminate()
                        },

                        // Build new query: before + newValue + after
                        Declare("beforeParam", typeof(string), currentQueryVar.Invoke("Substring", [Int(0), valueStartIndex]), out var beforeParam),
                        Declare("afterParam", typeof(string), currentQueryVar.Invoke("Substring", valueEndIndex), out var afterParam),
                        Declare("newQuery", typeof(string), new BinaryOperatorExpression("+", new BinaryOperatorExpression("+", beforeParam, valueParameter), afterParam), out var newQuery),

                        // Set the new query
                        uriBuilder.Property("Query").Assign(newQuery).Terminate()
                    },
                    // Parameter doesn't exist - append it using existing method
                    new InvokeMethodExpression(
                        uriBuilder,
                        nameof(RawRequestUriBuilder.AppendQuery),
                        [nameParameter, valueParameter, Bool(true)]
                    ).Terminate()
                )
            };

            return new MethodProvider(signature, body, this, XmlDocProvider.Empty);
        }
    }
}