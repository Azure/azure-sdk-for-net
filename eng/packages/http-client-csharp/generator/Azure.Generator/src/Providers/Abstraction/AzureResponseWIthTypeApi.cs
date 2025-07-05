// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Snippets;
using System;

namespace Azure.Generator.Providers.Abstraction
{
    /// <summary>
    /// Represents an Azure response API that can be used to operate with the response from an Azure service.
    /// </summary>
    public abstract record AzureResponseWIthTypeApi : ScopedApi, IAzureResponseWithTypeApi
    {
        /// <summary>
        /// Constructs an instance of <see cref="AzureResponseWIthTypeApi"/>.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="original">The original value expression.</param>
        protected AzureResponseWIthTypeApi(Type type, ValueExpression original) : base(type, original)
        {
        }

        /// <inheritdoc />
        public abstract AzureResponseWIthTypeApi FromExpression(ValueExpression original);

        /// <inheritdoc />
        public abstract AzureResponseWIthTypeApi ToExpression();

        /// <inheritdoc />
        public abstract ValueExpression CastToType(CSharpType type);
    }
}
