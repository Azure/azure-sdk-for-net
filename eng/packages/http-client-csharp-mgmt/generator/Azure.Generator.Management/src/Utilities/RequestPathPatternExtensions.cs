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
            var paramVariable = new VariableExpression(arrayParameter.Type, arrayParameter.Name);

            var serializationStatements = new List<MethodBodyStatement>();

            // Create Utf8JsonRequestContent
            var jsonContentVariable = Declare(
                "jsonContent",
                typeof(Utf8JsonRequestContent),
                New.Instance(typeof(Utf8JsonRequestContent)),
                out var jsonContent);
            serializationStatements.Add(jsonContentVariable);

            // Write array start
            serializationStatements.Add(
                new InvokeInstanceMethodStatement(
                    new MemberExpression(jsonContent, "JsonWriter"),
                    "WriteStartArray",
                    [],
                    false));

            // Foreach loop to write array elements
            var itemVar = new VariableExpression(elementType, "item");
            var foreachBody = new List<MethodBodyStatement>
            {
                new InvokeInstanceMethodStatement(
                    new MemberExpression(jsonContent, "JsonWriter"),
                    "WriteStringValue",
                    [new InvokeInstanceMethodExpression(itemVar, "ToString", [], null, false)],
                    false)
            };

            serializationStatements.Add(
                new ForeachStatement(itemVar, paramVariable, foreachBody, false));

            // Write array end
            serializationStatements.Add(
                new InvokeInstanceMethodStatement(
                    new MemberExpression(jsonContent, "JsonWriter"),
                    "WriteEndArray",
                    [],
                    false));

            // Set content = jsonContent
            serializationStatements.Add(
                contentVariable.Assign(jsonContent).Terminate());

            // Wrap in if statement
            statements.Add(new IfStatement(NotEqual(paramVariable, Null), serializationStatements));

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
                            // For collection types, use the pre-serialized content variable if provided
                            if (arrayBodyContent != null)
                            {
                                arguments.Add(arrayBodyContent);
                            }
                            else
                            {
                                // This should not happen - array body content should be provided
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
