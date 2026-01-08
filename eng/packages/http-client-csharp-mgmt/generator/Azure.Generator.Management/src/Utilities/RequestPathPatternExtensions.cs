// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Generator.Management.Models;
using Azure.Generator.Management.Providers;
using Azure.Generator.Management.Visitors;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Snippets;
using Microsoft.TypeSpec.Generator.Statements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Azure.Generator.Management.Utilities
{
    internal static class RequestPathPatternExtensions
    {
        private static bool IsCollectionType(CSharpType type, out CSharpType? elementType)
        {
            elementType = null;
            // Check if it's IList<T>, IEnumerable<T>, IReadOnlyList<T>, etc.
            if (type.IsGenericType && type.Arguments.Count == 1)
            {
                var frameworkType = type.FrameworkType;
                if (frameworkType != null)
                {
                    var typeName = frameworkType.Name;
                    if (typeName.StartsWith("IList") ||
                        typeName.StartsWith("IEnumerable") ||
                        typeName.StartsWith("IReadOnlyList") ||
                        typeName.StartsWith("ICollection"))
                    {
                        elementType = type.Arguments[0];
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Checks if the given method parameters contain an array body parameter.
        /// </summary>
        public static bool HasArrayBodyParameter(IReadOnlyList<ParameterProvider> methodParameters, out ParameterProvider? arrayParameter, out CSharpType? elementType)
        {
            arrayParameter = null;
            elementType = null;

            var bodyParam = methodParameters.FirstOrDefault(p => p.Location == ParameterLocation.Body);
            if (bodyParam == null)
            {
                return false;
            }

            if (IsCollectionType(bodyParam.Type, out elementType))
            {
                arrayParameter = bodyParam;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Generates statements to serialize an array parameter to RequestContent.
        /// </summary>
        public static IReadOnlyList<MethodBodyStatement> GenerateArraySerializationStatements(
            ParameterProvider arrayParameter,
            CSharpType elementType,
            out VariableExpression contentVariable)
        {
            var statements = new List<MethodBodyStatement>();

            // Declare: RequestContent content = null;
            var contentDeclaration = Declare(
                "content",
                typeof(RequestContent),
                Null,
                out contentVariable);
            statements.Add(contentDeclaration);

            // Generate: if (arrayParameter != null) { ... }
            var paramRef = (ValueExpression)arrayParameter;

            var serializationStatements = new List<MethodBodyStatement>();

            // Create a type reference to Utf8JsonRequestContent which is generated
            // We'll use RequestContent as the base and cast it
            var utf8Type = typeof(Azure.Core.RequestContent);

            // var jsonContent = new Utf8JsonRequestContent();
            // Since we can't reference the generated type directly, we use dynamic typing
            serializationStatements.Add(
                Declare("jsonContent", utf8Type, New.Instance(utf8Type), out var jsonContent));

            // jsonContent.JsonWriter.WriteStartArray();
            serializationStatements.Add(
                jsonContent.Property("JsonWriter").Invoke("WriteStartArray").Terminate());

            // foreach (var item in arrayParameter)
            var foreachStatement = new ForEachStatement(
                elementType,
                "item",
                paramRef,
                false,
                out var itemVar);
            var foreachBody = new List<MethodBodyStatement>
            {
                // jsonContent.JsonWriter.WriteStringValue(item.ToString());
                jsonContent.Property("JsonWriter").Invoke("WriteStringValue", [itemVar.InvokeToString()]).Terminate()
            };
            foreach (var stmt in foreachBody)
            {
                foreachStatement.Add(stmt);
            }

            serializationStatements.Add(foreachStatement);

            // jsonContent.JsonWriter.WriteEndArray();
            serializationStatements.Add(
                jsonContent.Property("JsonWriter").Invoke("WriteEndArray").Terminate());

            // content = jsonContent;
            serializationStatements.Add(
                contentVariable.Assign(jsonContent).Terminate());

            // Wrap in if statement: if (arrayParameter != null) { ... }
            var ifStatement = new IfStatement(paramRef.NotEqual(Null));
            foreach (var stmt in serializationStatements)
            {
                ifStatement.Add(stmt);
            }
            statements.Add(ifStatement);

            return statements;
        }

        public static IReadOnlyList<ValueExpression> PopulateArguments(
            this RequestPathPattern contextualPath,
            ScopedApi<ResourceIdentifier> idProperty,
            IReadOnlyList<ParameterProvider> requestParameters,
            VariableExpression requestContext,
            IReadOnlyList<ParameterProvider> methodParameters,
            TypeProvider? enclosingType = null,
            VariableExpression? arrayBodyContent = null)
        {
            var arguments = new List<ValueExpression>();
            // here we always assume that the parameter name matches the parameter name in the request path.
            foreach (var parameter in requestParameters)
            {
                // find the corresponding contextual parameter in the contextual parameter list
                if (contextualPath.TryGetContextualParameter(parameter, out var contextualParameter))
                {
                    arguments.Add(Convert(contextualParameter.BuildValueExpression(idProperty), typeof(string), parameter.Type));
                }
                //Find matching parameter from pathFieldsParameters if enclosing type is ResourceCollectionClientProvider
                else if (enclosingType is ResourceCollectionClientProvider collectionProvider && collectionProvider.TryGetPrivateFieldParameter(parameter, out var matchingField) && matchingField != null)
                {
                    arguments.Add(Convert(matchingField, matchingField.Type, parameter.Type));
                }
                else if (parameter.Type.Equals(typeof(RequestContent)))
                {
                    // find the body parameter
                    var bodyParameter = methodParameters.SingleOrDefault(p => p.Location == ParameterLocation.Body);
                    if (bodyParameter is not null)
                    {
                        // Check if the body parameter is a collection type
                        if (IsCollectionType(bodyParameter.Type, out var elementType))
                        {
                            // Use the pre-serialized array content if provided
                            if (arrayBodyContent != null)
                            {
                                arguments.Add(arrayBodyContent);
                            }
                            else
                            {
                                // This shouldn't happen if GenerateArraySerializationStatements was called
                                arguments.Add(Null);
                            }
                        }
                        else
                        {
                            arguments.Add(Static(bodyParameter.Type).Invoke(SerializationVisitor.ToRequestContentMethodName, [bodyParameter]));
                        }
                    }
                    else
                    {
                        arguments.Add(Null);
                    }
                }
                else if (parameter.Type.Equals(typeof(RequestContext)))
                {
                    arguments.Add(requestContext);
                }
                else
                {
                    var methodParam = methodParameters.SingleOrDefault(p => p.WireInfo.SerializedName == parameter.WireInfo.SerializedName);
                    if (methodParam != null)
                    {
                        arguments.Add(Convert(methodParam, methodParam.Type, parameter.Type));
                    }
                    else
                    {
                        arguments.Add(Null);
                    }
                }
            }

            return arguments;

            static ValueExpression Convert(ValueExpression expression, CSharpType fromType, CSharpType toType)
            {
                if (fromType.Equals(toType))
                {
                    return expression; // No conversion needed
                }

                if (toType.IsFrameworkType && toType.FrameworkType == typeof(Guid))
                {
                    return Static<Guid>().Invoke(nameof(Guid.Parse), expression);
                }

                if (fromType.IsEnum && toType.FrameworkType == typeof(string))
                {
                    return expression.InvokeToString();
                }

                // Convert ResourceIdentifier to string by calling ToString()
                if (fromType.Equals(typeof(ResourceIdentifier)) && toType.IsFrameworkType && toType.FrameworkType == typeof(string))
                {
                    return expression.InvokeToString();
                }

                // other unhandled cases, we will add when we need them in the future.
                return expression;
            }
        }
    }
}
