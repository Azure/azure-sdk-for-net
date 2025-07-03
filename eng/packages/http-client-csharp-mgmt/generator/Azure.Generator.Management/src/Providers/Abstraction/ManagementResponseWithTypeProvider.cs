// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Providers.Abstraction;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Primitives;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Azure.Generator.Management.Providers.Abstraction
{
    internal record ManagementResponseWithTypeProvider : AzureResponseWIthTypeApi
    {
        private static ManagementResponseWithTypeProvider? _instance;
        internal static ManagementResponseWithTypeProvider Instance => _instance ??= new ManagementResponseWithTypeProvider(Empty);

        public ManagementResponseWithTypeProvider(ValueExpression value) : base(typeof(ManagementResponseWithTypeProvider), value)
        {
        }

        public override ValueExpression CastToType(CSharpType type)
            => Static(type).Invoke(SerializationVisitor.FromResponseMethodName, [Original]);

        public override AzureResponseWIthTypeApi FromExpression(ValueExpression original)
            => new ManagementResponseWithTypeProvider(original);

        public override AzureResponseWIthTypeApi ToExpression() => this;
    }
}
