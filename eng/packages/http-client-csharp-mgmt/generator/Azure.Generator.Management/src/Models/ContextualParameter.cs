// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Snippets;
using System;

namespace Azure.Generator.Management.Models
{
    /// <summary>
    /// A <see cref="ContextualParameter"/> represents a parameter which could be determined contextually from the Id property of its enclosing resource or resource collection class.
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
}
