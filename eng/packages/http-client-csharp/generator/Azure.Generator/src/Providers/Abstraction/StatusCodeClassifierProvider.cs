// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Microsoft.Generator.CSharp.ClientModel.Providers;
using Microsoft.Generator.CSharp.Expressions;
using Microsoft.Generator.CSharp.Primitives;
using static Microsoft.Generator.CSharp.Snippets.Snippet;

namespace Azure.Generator.Providers.Abstraction
{
    internal record StatusCodeClassifierProvider : StatusCodeClassifierApi
    {
        private static StatusCodeClassifierApi? _instance;
        internal static StatusCodeClassifierApi Instance => _instance ??= new StatusCodeClassifierProvider();
        private StatusCodeClassifierProvider() : base(typeof(StatusCodeClassifier), Empty)
        {
        }

        public StatusCodeClassifierProvider(ValueExpression original) : base(typeof(StatusCodeClassifier), original)
        {
        }

        public override CSharpType ResponseClassifierType => typeof(ResponseClassifier);

        public override ValueExpression Create(int code)
            => New.Instance(typeof(StatusCodeClassifier), [New.Array(typeof(ushort), true, true, [Literal(code)])]);

        public override StatusCodeClassifierApi FromExpression(ValueExpression original)
            => new StatusCodeClassifierProvider(original);

        public override StatusCodeClassifierApi ToExpression() => this;
    }
}
