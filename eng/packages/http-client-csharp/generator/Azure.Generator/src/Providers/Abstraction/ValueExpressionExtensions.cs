// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Snippets;
using System;

namespace Azure.Generator.Providers.Abstraction
{
    internal static class ValueExpressionExtensions
    {
        public static T ToApi<T>(this VariableExpression valueExpression) where T : ScopedApi
        {
            switch (typeof(T).Name)
            {
                case nameof(AzureResponseWIthTypeApi):
                    return (T)(object)AzureClientGenerator.Instance.TypeFactory.AzureResponseWithTypeApi.FromExpression(valueExpression);
                default:
                    throw new InvalidOperationException($"Unsupported API type: {typeof(T).Name}");
            }
        }
    }
}
