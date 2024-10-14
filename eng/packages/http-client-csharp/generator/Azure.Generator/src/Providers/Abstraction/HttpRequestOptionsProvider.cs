// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Generator.CSharp.ClientModel.Providers;
using Microsoft.Generator.CSharp.Expressions;
using Microsoft.Generator.CSharp.Primitives;
using static Microsoft.Generator.CSharp.Snippets.Snippet;

namespace Azure.Generator.Providers.Abstraction
{
    internal record HttpRequestOptionsProvider : HttpRequestOptionsApi
    {
        private static HttpRequestOptionsApi? _instance;
        internal static HttpRequestOptionsApi Instance => _instance ??= new HttpRequestOptionsProvider();
        private HttpRequestOptionsProvider() : base(typeof(RequestContext), Empty)
        {
        }

        public HttpRequestOptionsProvider(ValueExpression original) : base(typeof(RequestContext), original)
        {
        }

        public override CSharpType HttpRequestOptionsType => typeof(RequestContext);

        public override ValueExpression ErrorOptions()
            => Original.NullConditional().Property(nameof(RequestContext.ErrorOptions));

        public override HttpRequestOptionsApi FromExpression(ValueExpression original)
            => new HttpRequestOptionsProvider(original);

        public override ValueExpression NoThrow()
            => FrameworkEnumValue(Azure.ErrorOptions.NoThrow);

        public override HttpRequestOptionsApi ToExpression() => this;
    }
}
