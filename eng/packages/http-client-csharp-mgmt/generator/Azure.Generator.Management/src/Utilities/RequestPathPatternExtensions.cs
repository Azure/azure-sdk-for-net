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
        private const string IfMatch = "If-Match";
        private const string IfNoneMatch = "If-None-Match";
        private const string IfModifiedSince = "If-Modified-Since";
        private const string IfUnmodifiedSince = "If-Unmodified-Since";

        private static readonly Dictionary<string, string> _conditionalHeaderToPropertyName = new(StringComparer.OrdinalIgnoreCase)
        {
            { IfMatch, nameof(MatchConditions.IfMatch) },
            { IfNoneMatch, nameof(MatchConditions.IfNoneMatch) },
            { IfModifiedSince, nameof(RequestConditions.IfModifiedSince) },
            { IfUnmodifiedSince, nameof(RequestConditions.IfUnmodifiedSince) },
            { "ifMatch", nameof(MatchConditions.IfMatch) },
            { "ifNoneMatch", nameof(MatchConditions.IfNoneMatch) },
            { "ifModifiedSince", nameof(RequestConditions.IfModifiedSince) },
            { "ifUnmodifiedSince", nameof(RequestConditions.IfUnmodifiedSince) }
        };

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
                    else if (TryGetMatchConditionsArgument(parameter, methodParameters, out var matchConditionsArgument))
                    {
                        // Handle unwrapping MatchConditions/RequestConditions to individual header parameters
                        arguments.Add(matchConditionsArgument);
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

        /// <summary>
        /// Tries to get an argument expression for a conditional header parameter from a MatchConditions/RequestConditions parameter.
        /// </summary>
        /// <param name="requestParameter">The request parameter (e.g., ifMatch, ifNoneMatch).</param>
        /// <param name="methodParameters">The method parameters to search for MatchConditions/RequestConditions.</param>
        /// <param name="argument">The output argument expression.</param>
        /// <returns>True if the parameter was found and unwrapped; otherwise, false.</returns>
        private static bool TryGetMatchConditionsArgument(
            ParameterProvider requestParameter,
            IReadOnlyList<ParameterProvider> methodParameters,
            out ValueExpression argument)
        {
            argument = Null;

            // Check if the request parameter is a conditional header
            var serializedName = requestParameter.WireInfo.SerializedName;
            if (!_conditionalHeaderToPropertyName.TryGetValue(serializedName, out var propertyName))
            {
                return false;
            }

            // Find MatchConditions or RequestConditions parameter in method parameters
            var matchConditionsParam = methodParameters.FirstOrDefault(p =>
                p.Type.Equals(typeof(MatchConditions)) ||
                p.Type.Equals(new CSharpType(typeof(MatchConditions), true)) ||
                p.Type.Equals(typeof(RequestConditions)) ||
                p.Type.Equals(new CSharpType(typeof(RequestConditions), true)));

            if (matchConditionsParam == null)
            {
                return false;
            }

            // Generate: matchConditions?.IfMatch or matchConditions?.IfNoneMatch, etc.
            argument = Snippet.NullConditional(matchConditionsParam).Property(propertyName);
            return true;
        }
    }
}
