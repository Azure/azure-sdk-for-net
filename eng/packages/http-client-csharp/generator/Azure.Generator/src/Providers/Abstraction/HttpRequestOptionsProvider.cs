// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Primitives;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Azure.Generator.Providers.Abstraction
{
    internal record HttpRequestOptionsProvider : HttpRequestOptionsApi
    {
        private static HttpRequestOptionsApi? _instance;
        internal static HttpRequestOptionsApi Instance => _instance ??= new HttpRequestOptionsProvider(Empty);

        public HttpRequestOptionsProvider(ValueExpression original) : base(typeof(RequestContext), original)
        {
        }

        public override CSharpType HttpRequestOptionsType => typeof(RequestContext);

        public override string ParameterName => "context";

        public override ValueExpression ErrorOptions()
            => Original.NullConditional().Property(nameof(RequestContext.ErrorOptions));

        public override HttpRequestOptionsApi FromExpression(ValueExpression original)
            => new HttpRequestOptionsProvider(original);

        public override ValueExpression NoThrow()
            => FrameworkEnumValue(Azure.ErrorOptions.NoThrow);

        public override HttpRequestOptionsApi ToExpression() => this;
    }
}
