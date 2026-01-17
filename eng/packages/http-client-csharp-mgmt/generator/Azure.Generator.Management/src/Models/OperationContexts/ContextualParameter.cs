// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Snippets;
using System;

namespace Azure.Generator.Management.Models;

/// <summary>
/// Represents a parameter whose value can be derived contextually from the resource identifier (Id) of its enclosing resource or resource collection.
/// <para>
/// A <see cref="ContextualParameter"/> is used in Azure management SDK code generation to model parameters that do not need to be explicitly provided by the caller,
/// because their values can be computed from the resource's <see cref="ResourceIdentifier"/>. For example, parameters such as "subscriptionId", "resourceGroupName",
/// or the name of a parent resource can often be extracted from the Id property of the resource or its parent.
/// </para>
/// <para>
/// Each contextual parameter is associated with a <c>Key</c> (the constant segment preceding the parameter in the request path),
/// a <c>VariableName</c> (the name of the parameter in the path), and a function that builds the value expression from a given `Id` instance.
/// </para>
/// <para>
/// The <see cref="BuildValueExpression"/> method is used to generate the code expression that retrieves the parameter value from the Id property,
/// enabling the SDK to automatically supply these values in generated client methods.
/// </para>
/// </summary>
internal class ContextualParameter
{
    private readonly Func<ScopedApi<ResourceIdentifier>, ValueExpression> _valueExpressionBuilder;
    public ContextualParameter(string key, string variableName, Func<ScopedApi<ResourceIdentifier>, ValueExpression> valueExpressionBuilder)
    {
        Key = key;
        VariableName = variableName;
        _valueExpressionBuilder = valueExpressionBuilder;
    }

    public string Key { get; }

    public string VariableName { get; }

    public ValueExpression BuildValueExpression(ScopedApi<ResourceIdentifier> id)
        => _valueExpressionBuilder(id);
}
