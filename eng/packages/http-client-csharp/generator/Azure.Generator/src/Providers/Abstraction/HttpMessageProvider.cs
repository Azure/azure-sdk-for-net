// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Microsoft.Generator.CSharp.ClientModel.Providers;
using Microsoft.Generator.CSharp.Expressions;
using Microsoft.Generator.CSharp.Primitives;
using Microsoft.Generator.CSharp.Statements;
using static Microsoft.Generator.CSharp.Snippets.Snippet;

namespace Azure.Generator.Providers
{
    internal record HttpMessageProvider : HttpMessageApi
    {
        private static HttpMessageApi? _instance;
        internal static HttpMessageApi Instance => _instance ??= new HttpMessageProvider(Empty);

        public HttpMessageProvider(ValueExpression original) : base(typeof(HttpMessage), original)
        {
        }

        public override CSharpType HttpMessageType => typeof(HttpMessage);

        public override ValueExpression BufferResponse()
            => Original.Property(nameof(HttpMessage.BufferResponse));

        public override HttpMessageApi FromExpression(ValueExpression original)
            => new HttpMessageProvider(original);

        public override HttpRequestApi Request()
            => new HttpRequestProvider(Original.Property(nameof(HttpMessage.Request)));

        public override HttpResponseApi Response()
            => new AzureResponseProvider(Original.Property(nameof(HttpMessage.Response)));

        public override HttpMessageApi ToExpression() => this;

        public override MethodBodyStatement ApplyResponseClassifier(StatusCodeClassifierApi statusCodeClassifier)
            => MethodBodyStatement.Empty;

        public override MethodBodyStatement ApplyRequestOptions(HttpRequestOptionsApi options)
            => MethodBodyStatement.Empty;
    }
}
