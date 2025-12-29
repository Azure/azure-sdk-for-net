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
            var addedMatchConditions = false;

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
                // Check if the REST method itself takes MatchConditions/RequestConditions
                else if (parameter.Type.Name == nameof(MatchConditions) || parameter.Type.Name == nameof(RequestConditions))
                {
                    // Find the matching MatchConditions/RequestConditions parameter in method parameters
                    var matchConditionsMethodParam = methodParameters.FirstOrDefault(p =>
                        p.Type.Name == nameof(MatchConditions) || p.Type.Name == nameof(RequestConditions));
                    if (matchConditionsMethodParam != null)
                    {
                        arguments.Add(matchConditionsMethodParam);
                    }
                    else
                    {
                        arguments.Add(Null);
                    }
                }
                else
                {
                    var methodParam = methodParameters.SingleOrDefault(p => p.WireInfo?.SerializedName == parameter.WireInfo?.SerializedName);
                    if (methodParam != null)
                    {
                        arguments.Add(Convert(methodParam, methodParam.Type, parameter.Type));
                    }
                    else if (TryGetMatchConditionsArgument(parameter, methodParameters, addedMatchConditions, out var matchConditionsArgument, out var didAddMatchConditions))
                    {
                        // Handle unwrapping MatchConditions/RequestConditions to individual header parameters
                        // Only add the argument if we haven't already added MatchConditions for this group
                        if (matchConditionsArgument != null)
                        {
                            arguments.Add(matchConditionsArgument);
                        }
                        addedMatchConditions = didAddMatchConditions;
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
        /// When the REST method has individual header params but the method signature has MatchConditions,
        /// we need to pass the MatchConditions parameter directly (not unwrapped properties) because
        /// the REST client method has been transformed by the MatchConditionsHeadersVisitor.
        /// </summary>
        /// <param name="requestParameter">The request parameter (e.g., ifMatch, ifNoneMatch).</param>
        /// <param name="methodParameters">The method parameters to search for MatchConditions/RequestConditions.</param>
        /// <param name="alreadyAddedMatchConditions">Whether we've already added the MatchConditions argument.</param>
        /// <param name="argument">The output argument expression (null if this is a subsequent conditional header).</param>
        /// <param name="didAddMatchConditions">Whether this call added the MatchConditions argument.</param>
        /// <returns>True if the parameter is a conditional header; otherwise, false.</returns>
        private static bool TryGetMatchConditionsArgument(
            ParameterProvider requestParameter,
            IReadOnlyList<ParameterProvider> methodParameters,
            bool alreadyAddedMatchConditions,
            out ValueExpression? argument,
            out bool didAddMatchConditions)
        {
            argument = null;
            didAddMatchConditions = false;

            // Check if the request parameter is a conditional header
            // Try both SerializedName and Name as the key
            var serializedName = requestParameter.WireInfo?.SerializedName ?? requestParameter.Name;
            if (!_conditionalHeaderToPropertyName.TryGetValue(serializedName, out _))
            {
                // Also try the parameter name directly
                if (!_conditionalHeaderToPropertyName.TryGetValue(requestParameter.Name, out _))
                {
                    return false;
                }
            }

            // This is a conditional header parameter
            // If we haven't added MatchConditions yet, add it now
            if (!alreadyAddedMatchConditions)
            {
                // Find MatchConditions or RequestConditions parameter in method parameters
                var matchConditionsParam = methodParameters.FirstOrDefault(p =>
                    p.Type.Name == nameof(MatchConditions) || p.Type.Name == nameof(RequestConditions));

                if (matchConditionsParam != null)
                {
                    // Pass the MatchConditions parameter directly (not unwrapped)
                    // because the REST client method expects MatchConditions, not individual headers
                    argument = matchConditionsParam;
                    didAddMatchConditions = true;
                }
                else
                {
                    argument = Null;
                }
            }
            // If we've already added MatchConditions, skip this parameter (return true to indicate we handled it)
            return true;
        }
    }
}
