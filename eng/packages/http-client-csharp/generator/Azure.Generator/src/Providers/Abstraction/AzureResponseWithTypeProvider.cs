// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Primitives;

namespace Azure.Generator.Providers.Abstraction
{
    internal record AzureResponseWithTypeProvider : AzureResponseWIthTypeApi
    {
        public AzureResponseWithTypeProvider(ValueExpression value) : base(typeof(AzureResponseWithTypeProvider), value)
        {
        }

        private static AzureResponseWIthTypeApi? _instance;
        internal static AzureResponseWIthTypeApi Instance => _instance ??= new AzureResponseWithTypeProvider(Empty);

        public override AzureResponseWIthTypeApi FromExpression(ValueExpression original)
            => new AzureResponseWithTypeProvider(original);

        public override AzureResponseWIthTypeApi ToExpression() => this;

        public override ValueExpression CastToType(CSharpType type) => Original.CastTo(type);
    }
}
