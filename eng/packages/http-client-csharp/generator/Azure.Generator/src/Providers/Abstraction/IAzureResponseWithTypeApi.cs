// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Primitives;

namespace Azure.Generator.Providers.Abstraction
{
    /// <summary>
    /// Represents an API for working with Azure response expressions.
    /// </summary>
    /// <remarks>This interface extends <see cref="IExpressionApi{T}"/> with a specific focus on handling
    /// Azure response-related expressions. It provides functionality for defining and manipulating expressions that
    /// operate on <see cref="AzureResponseWIthTypeApi"/> objects.</remarks>
    public interface IAzureResponseWithTypeApi : IExpressionApi<AzureResponseWIthTypeApi>
    {
        /// <summary>
        /// Converts response to a value expression with the type of the response.
        /// </summary>
        /// <returns>A value expression representing the response type.</returns>
        ValueExpression CastToType(CSharpType type);
    }
}
