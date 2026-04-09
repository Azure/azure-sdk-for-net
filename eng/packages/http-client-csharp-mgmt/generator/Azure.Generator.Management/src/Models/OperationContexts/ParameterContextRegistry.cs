// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Generator.Management.Snippets;
using Azure.Generator.Management.Utilities;
using Azure.Generator.Management.Visitors;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Snippets;
using Microsoft.TypeSpec.Generator.Statements;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Text.Json;
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
        IReadOnlyList<ParameterProvider> methodParameters,
        List<MethodBodyStatement>? preparationStatements = null)
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
                    bool isCollection = bodyParameter.Type.IsCollection;
                    // For collections, check if element type is primitive; for single types, use CanCreateRequestContent.
                    bool isPrimitive = isCollection
                        ? bodyParameter.Type.Arguments.Count == 0 || bodyParameter.Type.Arguments[0].IsFrameworkType
                        : bodyParameter.Type.CanCreateRequestContent();

                    if (isPrimitive)
                    {
                        // Primitive types or primitive collections → RequestContent.Create(param)
                        AddRequestContentCreateArgument(arguments, bodyParameter);
                    }
                    else if (isCollection)
                    {
                        // Model collection → use Utf8JsonWriter with WriteObjectValue for proper
                        // IJsonModel<T> serialization (correct wire names, custom logic, discriminators).
                        if (preparationStatements is not null)
                        {
                            arguments.Add(BuildModelCollectionRequestContent(bodyParameter, preparationStatements));
                        }
                        else
                        {
                            // No preparation statements list provided: fall back to RequestContent.Create(object).
                            AddRequestContentCreateArgument(arguments, bodyParameter);
                        }
                    }
                    else
                    {
                        // Single model type → ToRequestContent
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
                if (!fromType.IsStruct)
                {
                    // Fixed enums (IsStruct=false) have a ToSerialString() extension method
                    return fromType.IsNullable ? expression.NullConditional().Invoke("ToSerialString") : expression.Invoke("ToSerialString");
                }
                // Extensible enums (IsStruct=true, readonly structs) use ToString()
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

    /// <summary>
    /// Adds a <c>RequestContent.Create(bodyParameter)</c> argument, with a null-check ternary if the type is nullable.
    /// </summary>
    private static void AddRequestContentCreateArgument(List<ValueExpression> arguments, ParameterProvider bodyParameter)
    {
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

    /// <summary>
    /// Builds preparation statements and a RequestContent argument expression for a collection
    /// of model types. Uses Utf8JsonWriter with WriteObjectValue to ensure proper IJsonModel&lt;T&gt;
    /// serialization (correct wire property names, custom serialization logic, discriminators, etc.).
    /// </summary>
    /// <remarks>
    /// Generates the following code:
    /// <code>
    /// MemoryStream collectionBodyStream = new MemoryStream();
    /// Utf8JsonWriter collectionBodyWriter = new Utf8JsonWriter(collectionBodyStream);
    /// collectionBodyWriter.WriteStartArray();
    /// foreach (var item in body) { collectionBodyWriter.WriteObjectValue(item, ModelSerializationExtensions.WireOptions); }
    /// collectionBodyWriter.WriteEndArray();
    /// collectionBodyWriter.Flush();
    /// collectionBodyStream.Position = 0;
    /// // argument: RequestContent.Create(collectionBodyStream)
    /// </code>
    /// </remarks>
    private static ValueExpression BuildModelCollectionRequestContent(
        ParameterProvider bodyParameter,
        List<MethodBodyStatement> preparationStatements)
    {
        // var collectionBodyStream = new MemoryStream();
        preparationStatements.Add(
            Declare("collectionBodyStream", typeof(MemoryStream), New.Instance(typeof(MemoryStream)), out var streamVar));

        // var collectionBodyWriter = new Utf8JsonWriter(collectionBodyStream);
        preparationStatements.Add(
            Declare("collectionBodyWriter", typeof(Utf8JsonWriter), New.Instance(typeof(Utf8JsonWriter), new ValueExpression[] { streamVar }), out var writerVar));

        // collectionBodyWriter.WriteStartArray();
        preparationStatements.Add(
            writerVar.Invoke(nameof(Utf8JsonWriter.WriteStartArray)).Terminate());

        // foreach (var item in body) { collectionBodyWriter.WriteObjectValue(item, ModelSerializationExtensions.WireOptions); }
        var foreachStatement = new ForEachStatement("item", bodyParameter.As(bodyParameter.Type), out var itemVar)
        {
            writerVar.Invoke("WriteObjectValue", new ValueExpression[] { itemVar, ModelSerializationExtensionsSnippets.Wire }).Terminate()
        };
        preparationStatements.Add(foreachStatement);

        // collectionBodyWriter.WriteEndArray();
        preparationStatements.Add(
            writerVar.Invoke(nameof(Utf8JsonWriter.WriteEndArray)).Terminate());

        // collectionBodyWriter.Flush();
        preparationStatements.Add(
            writerVar.Invoke(nameof(Utf8JsonWriter.Flush)).Terminate());

        // collectionBodyStream.Position = 0;
        preparationStatements.Add(
            streamVar.Property(nameof(MemoryStream.Position)).Assign(Literal(0L)).Terminate());

        // Argument: RequestContent.Create(collectionBodyStream)
        var createContent = Static(typeof(RequestContent)).Invoke(
            nameof(RequestContent.Create),
            [streamVar]);

        if (bodyParameter.Type.IsNullable)
        {
            return new TernaryConditionalExpression(bodyParameter.NotEqual(Null), createContent, Null);
        }

        return createContent;
    }
}