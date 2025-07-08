// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Snippets;
using System;
using System.Diagnostics;

namespace Azure.Generator.Management.Models
{
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
        {
            return _valueExpressionBuilder(id);
        }
    }
}
