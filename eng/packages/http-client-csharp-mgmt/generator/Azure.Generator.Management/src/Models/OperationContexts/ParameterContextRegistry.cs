// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Generator.Management.Utilities;
using Azure.Generator.Management.Visitors;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Snippets;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;
using TernaryConditionalExpression = Microsoft.TypeSpec.Generator.Expressions.TernaryConditionalExpression;

namespace Azure.Generator.Management.Models;

/// <summary>
/// Represents a registry that maps parameter names to their contextual information for a given operation.
/// <para>
/// The <see cref="ParameterContextRegistry"/> is used to associate operation parameters with their corresponding
/// <see cref="ContextualParameter"/> (if available), which describes how a parameter value can be derived from the
/// resource identifier (Id) of the enclosing resource or resource collection. This mapping enables the generator
/// to determine which parameters are contextually available and which are pass-through (must be supplied by the caller).
/// </para>
/// <para>
/// The registry provides lookup and enumeration capabilities for parameter mappings, and supports argument population
/// for method invocations by resolving contextual values or falling back to method parameters as needed.
/// </para>
/// </summary>
internal class ParameterContextRegistry : IReadOnlyDictionary<string, ParameterContextMapping>
{
    private readonly IReadOnlyDictionary<string, ParameterContextMapping> _parameters;
    public ParameterContextRegistry(IReadOnlyList<ParameterContextMapping> parameters)
    {
        _parameters = parameters.ToDictionary(p => p.ParameterName);
    }

    public ParameterContextMapping this[string key] => _parameters[key];

    public IEnumerable<string> Keys => _parameters.Keys;

    public IEnumerable<ParameterContextMapping> Values => _parameters.Values;

    public int Count => _parameters.Count;

    public bool ContainsKey(string key)
    {
        return _parameters.ContainsKey(key);
    }

    public IEnumerator<KeyValuePair<string, ParameterContextMapping>> GetEnumerator()
    {
        return _parameters.GetEnumerator();
    }

    public bool TryGetValue(string key, [MaybeNullWhen(false)] out ParameterContextMapping value)
    {
        return _parameters.TryGetValue(key, out value);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public IReadOnlyList<ValueExpression> PopulateArguments(
        ScopedApi<ResourceIdentifier> idProperty,
        IReadOnlyList<ParameterProvider> requestParameters,
        VariableExpression requestContext,
        IReadOnlyList<ParameterProvider> methodParameters)
    {
        var arguments = new List<ValueExpression>();
        // here we always assume that the parameter name matches the parameter name in the request path.
        foreach (var parameter in requestParameters)
        {
            // find the corresponding parameter in the parameter mapping
            if (TryGetValue(parameter.WireInfo.SerializedName, out var mapping))
            {
                // check if this is a contextual parameter
                if (mapping.ContextualParameter is not null)
                {
                    arguments.Add(Convert(mapping.ContextualParameter.BuildValueExpression(idProperty), typeof(string), parameter.Type));
                }
                else
                {
                    // contextual is null then this is a pass through parameter
                    arguments.Add(FindParameter(methodParameters, parameter));
                }
            }
            else if (parameter.Type.Equals(typeof(RequestContent)))
            {
                // find the body parameter
                var bodyParameter = methodParameters.SingleOrDefault(p => p.Location == ParameterLocation.Body);
                if (bodyParameter is not null)
                {
                    if (bodyParameter.Type.CanCreateRequestContent())
                    {
                        // For primitive types (string, BinaryData, Stream, byte[]) that have a direct
                        // RequestContent.Create overload, use it instead of ToRequestContent.
                        var createContent = Static(typeof(RequestContent)).Invoke(
                            nameof(RequestContent.Create),
                            [bodyParameter]);
                        if (bodyParameter.Type.IsNullable)
                        {
                            arguments.Add(new TernaryConditionalExpression(bodyParameter.NotEqual(Null), createContent, Null));
                        }
                        else
                        {
                            arguments.Add(createContent);
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
            else if (IsMatchConditionType(parameter.Type))
            {
                // Find the corresponding MatchConditions/RequestConditions parameter in the method parameters.
                // This handles the case where the MatchConditionsHeadersVisitor has merged separate
                // conditional header parameters into a single MatchConditions/RequestConditions parameter.
                var matchConditionsParam = methodParameters.FirstOrDefault(p => IsMatchConditionType(p.Type));
                arguments.Add(matchConditionsParam ?? (ValueExpression)Default);
            }
            else
            {
                // we did not find it and this parameter does not fall into any known conversion case, so we just pass it through.
                arguments.Add(FindParameter(methodParameters, parameter));
            }
        }

        return arguments;

        static ValueExpression FindParameter(IReadOnlyList<ParameterProvider> parameters, ParameterProvider parameterToFind)
        {
            var methodParam = parameters.SingleOrDefault(p => p.WireInfo.SerializedName == parameterToFind.WireInfo.SerializedName);
            if (methodParam != null)
            {
                return Convert(methodParam, methodParam.Type, parameterToFind.Type);
            }

            return Default;
        }

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
                return fromType.IsNullable ? expression.NullConditional().InvokeToString() : expression.InvokeToString();
            }

            // Convert ResourceIdentifier to string by calling ToString()
            if (fromType.Equals(typeof(ResourceIdentifier)) && toType.IsFrameworkType && toType.FrameworkType == typeof(string))
            {
                return fromType.IsNullable ? expression.NullConditional().InvokeToString() : expression.InvokeToString();
            }

            // other unhandled cases, we will add when we need them in the future.
            return expression;
        }
    }

    private static bool IsMatchConditionType(CSharpType type)
    {
        return type.Equals(typeof(MatchConditions)) || type.Equals(typeof(RequestConditions));
    }
}