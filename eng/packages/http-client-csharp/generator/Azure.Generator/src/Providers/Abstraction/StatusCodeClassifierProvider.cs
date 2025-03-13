// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Primitives;
using System.Collections.Generic;
using System.Linq;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Azure.Generator.Providers.Abstraction
{
    internal record StatusCodeClassifierProvider : StatusCodeClassifierApi
    {
        private static StatusCodeClassifierApi? _instance;
        internal static StatusCodeClassifierApi Instance => _instance ??= new StatusCodeClassifierProvider(Empty);

        public StatusCodeClassifierProvider(ValueExpression original) : base(typeof(StatusCodeClassifier), original)
        {
        }

        public override CSharpType ResponseClassifierType => typeof(ResponseClassifier);

        public override ValueExpression Create(int code)
            => New.Instance(typeof(StatusCodeClassifier), [New.Array(typeof(ushort), true, true, [Literal(code)])]);

        public override ValueExpression Create(IEnumerable<int> codes)
        {
            var codeArgs = codes.Select(Literal).ToArray();
            return New.Instance(typeof(StatusCodeClassifier), New.Array(typeof(ushort), true, true, codeArgs));
        }

        public override StatusCodeClassifierApi FromExpression(ValueExpression original)
            => new StatusCodeClassifierProvider(original);

        public override StatusCodeClassifierApi ToExpression() => this;
    }
}
