// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Microsoft.Generator.CSharp.ClientModel.Providers;
using Microsoft.Generator.CSharp.Expressions;
using Microsoft.Generator.CSharp.Snippets;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using static Microsoft.Generator.CSharp.Snippets.Snippet;

namespace Azure.Generator.Providers
{
    internal record HttpRequestProvider : HttpRequestApi
    {
        private static HttpRequestApi? _instance;
        internal static HttpRequestApi Instance => _instance ??= new HttpRequestProvider();
        private HttpRequestProvider() : base(typeof(Request), Empty)
        {
        }

        public HttpRequestProvider(ValueExpression original) : base(typeof(Request), original)
        {
        }

        public override ValueExpression Content()
            => Original.Property(nameof(Request.Content));

        public override HttpRequestApi FromExpression(ValueExpression original)
            => new HttpRequestProvider(original);

        public override InvokeMethodExpression SetHeaders(IReadOnlyList<ValueExpression> arguments)
            => Original.Property(nameof(PipelineRequest.Headers)).Invoke(nameof(RequestHeaders.Add), arguments);

        public override AssignmentExpression SetMethod(string httpMethod)
            => Original.Property(nameof(PipelineRequest.Method)).Assign(New.Instance(typeof(RequestMethod), [Literal(httpMethod)]));

        public override AssignmentExpression SetUri(ValueExpression value)
            => Original.Property("Uri").Assign(value);

        public override HttpRequestApi ToExpression() => this;
    }
}
