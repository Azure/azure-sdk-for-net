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
using System;
using System.Collections.Generic;
using System.Linq;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Azure.Generator.Management.Utilities
{
    internal static class RequestPathPatternExtensions
    {
        public static IReadOnlyList<ValueExpression> PopulateArguments(
            this RequestPathPattern contextualPath,
            ScopedApi<ResourceIdentifier> idProperty,
            IReadOnlyList<ParameterProvider> requestParameters,
            VariableExpression requestContext,
            IReadOnlyList<ParameterProvider> methodParameters,
            TypeProvider? enclosingType = null)
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
                        arguments.Add(Static(bodyParameter.Type).Invoke(SerializationVisitor.ToRequestContentMethodName, [bodyParameter]));
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

                // other unhandled cases, we will add when we need them in the future.
                return expression;
            }
        }
    }
}
