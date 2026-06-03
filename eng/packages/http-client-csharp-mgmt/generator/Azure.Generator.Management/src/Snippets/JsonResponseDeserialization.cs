// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Snippets;
using Microsoft.TypeSpec.Generator.Statements;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Azure.Generator.Management.Snippets
{
    /// <summary>
    /// Builds AOT-safe inline JSON deserialization for framework collection response types
    /// (e.g. <c>IDictionary&lt;string, BinaryData&gt;</c> produced from a TypeSpec <c>Record&lt;unknown&gt;</c>).
    /// These types do not implement <see cref="System.ClientModel.Primitives.IPersistableModel{T}"/>, so
    /// <c>ModelReaderWriter.Read&lt;T&gt;</c> cannot be used; instead the JSON payload is parsed and the
    /// collection is constructed with explicit <c>foreach</c> loops.
    /// </summary>
    internal static class JsonResponseDeserialization
    {
        /// <summary>
        /// Returns <c>true</c> when <paramref name="type"/> is a framework collection (dictionary or list)
        /// that must be deserialized with inline JSON rather than <c>ModelReaderWriter.Read&lt;T&gt;</c>.
        /// </summary>
        public static bool IsInlineJsonDeserializable(CSharpType type)
            => type.IsFrameworkType && (type.IsDictionary || type.IsList);

        /// <summary>
        /// Builds statements that parse <paramref name="content"/> (a <see cref="BinaryData"/> such as
        /// <c>result.Content</c>) into a value of <paramref name="type"/>, exposing the result via
        /// <paramref name="valueVariable"/>.
        /// </summary>
        public static IReadOnlyList<MethodBodyStatement> BuildDeserializeFromContent(
            CSharpType type,
            ValueExpression content,
            string valueName,
            out ValueExpression valueVariable)
        {
            var statements = new List<MethodBodyStatement>
            {
                // using var document = JsonDocument.Parse(content, ModelSerializationExtensions.JsonDocumentOptions);
                UsingDeclare(
                    "document",
                    typeof(JsonDocument),
                    Static(typeof(JsonDocument)).Invoke(
                        nameof(JsonDocument.Parse),
                        [content, Static<ModelSerializationExtensionsDefinition>().Property("JsonDocumentOptions")]),
                    out var documentVariable),
            };

            statements.AddRange(BuildDeserializeFromRootElement(
                type,
                documentVariable.Property(nameof(JsonDocument.RootElement)),
                valueName,
                out valueVariable));

            return statements;
        }

        /// <summary>
        /// Builds statements that deserialize <paramref name="rootElement"/> (a <see cref="JsonElement"/>)
        /// into a value of <paramref name="type"/>, guarding against a top-level JSON <c>null</c> body.
        /// </summary>
        public static IReadOnlyList<MethodBodyStatement> BuildDeserializeFromRootElement(
            CSharpType type,
            ValueExpression rootElement,
            string valueName,
            out ValueExpression valueVariable)
        {
            var statements = new List<MethodBodyStatement>();

            // T value = default;
            statements.Add(Declare(valueName, type, Default, out var declaredVariable));
            valueVariable = declaredVariable;

            // if (rootElement.ValueKind != JsonValueKind.Null) { ...build...; value = built; }
            var ifBody = new List<MethodBodyStatement>();
            ifBody.AddRange(BuildCollection(type, rootElement, valueName + "Result", out var built));
            ifBody.Add(declaredVariable.Assign(built).Terminate());

            var ifStatement = new IfStatement(
                rootElement.Property(nameof(JsonElement.ValueKind))
                    .NotEqual(Static(typeof(JsonValueKind)).Property(nameof(JsonValueKind.Null))));
            foreach (var statement in ifBody)
            {
                ifStatement.Add(statement);
            }
            statements.Add(ifStatement);

            return statements;
        }

        // Builds the foreach-based construction of a dictionary or list collection from a JsonElement.
        private static IReadOnlyList<MethodBodyStatement> BuildCollection(
            CSharpType type,
            ValueExpression element,
            string prefix,
            out ValueExpression result)
        {
            var statements = new List<MethodBodyStatement>();

            if (type.IsDictionary)
            {
                var keyType = type.Arguments[0];
                var valueType = type.Arguments[1];
                var concreteType = new CSharpType(typeof(Dictionary<,>), keyType, valueType);

                // var {prefix} = new Dictionary<TKey, TValue>();
                statements.Add(Declare(prefix, concreteType, New.Instance(concreteType), out var dictionaryVariable));

                // foreach (var {prefix}Property in element.EnumerateObject()) { ... }
                var foreachStatement = new ForEachStatement(
                    typeof(JsonProperty),
                    prefix + "Property",
                    element.Invoke(nameof(JsonElement.EnumerateObject)),
                    isAsync: false,
                    out var propertyVariable);

                var body = new List<MethodBodyStatement>();
                var valueExpression = BuildElementValue(
                    valueType,
                    propertyVariable.Property(nameof(JsonProperty.Value)),
                    prefix + "Value",
                    body);
                body.Add(dictionaryVariable.Invoke(
                    "Add",
                    propertyVariable.Property(nameof(JsonProperty.Name)),
                    valueExpression).Terminate());
                foreach (var statement in body)
                {
                    foreachStatement.Add(statement);
                }
                statements.Add(foreachStatement);

                result = dictionaryVariable;
                return statements;
            }

            // List / array-like collection.
            var itemType = type.Arguments[0];
            var concreteListType = new CSharpType(typeof(List<>), itemType);

            // var {prefix} = new List<TItem>();
            statements.Add(Declare(prefix, concreteListType, New.Instance(concreteListType), out var listVariable));

            // foreach (var {prefix}Element in element.EnumerateArray()) { ... }
            var listForeach = new ForEachStatement(
                typeof(JsonElement),
                prefix + "Element",
                element.Invoke(nameof(JsonElement.EnumerateArray)),
                isAsync: false,
                out var itemVariable);

            var listBody = new List<MethodBodyStatement>();
            var itemExpression = BuildElementValue(itemType, itemVariable, prefix + "Item", listBody);
            listBody.Add(listVariable.Invoke("Add", itemExpression).Terminate());
            foreach (var statement in listBody)
            {
                listForeach.Add(statement);
            }
            statements.Add(listForeach);

            result = listVariable;
            return statements;
        }

        // Produces the expression for a single dictionary value or list item, appending any prerequisite
        // statements (used for nested collections) to <paramref name="body"/>.
        private static ValueExpression BuildElementValue(
            CSharpType type,
            ValueExpression element,
            string prefix,
            List<MethodBodyStatement> body)
        {
            if (IsInlineJsonDeserializable(type))
            {
                body.AddRange(BuildCollection(type, element, prefix, out var nested));
                return nested;
            }

            if (type.IsFrameworkType && type.FrameworkType == typeof(BinaryData))
            {
                // This is hit for Record<unknown> values: the Record itself is a dictionary, while each
                // dictionary value is represented as BinaryData.
                return Static(typeof(BinaryData)).Invoke(
                    nameof(BinaryData.FromString),
                    element.Invoke(nameof(JsonElement.GetRawText)));
            }

            // Scalar or model leaf: delegate to the AOT-safe per-value deserialization (JsonElement.GetXxx for
            // scalars, ModelReaderWriter.Read with a generated context for models).
            return ManagementClientGenerator.Instance.TypeFactory.DeserializeJsonValue(
                type,
                element.As<JsonElement>(),
                Static(typeof(BinaryData)).Invoke(
                    nameof(BinaryData.FromString),
                    element.Invoke(nameof(JsonElement.GetRawText))).As<BinaryData>(),
                ModelSerializationExtensionsSnippets.Wire,
                SerializationFormat.Default);
        }
    }
}
