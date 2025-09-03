// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Statements;
using System;
using System.Collections.Generic;
using Microsoft.TypeSpec.Generator.Snippets;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Azure.Generator.Providers
{
    internal record HttpRequestProvider : HttpRequestApi
    {
        private static HttpRequestApi? _instance;
        internal static HttpRequestApi Instance => _instance ??= new HttpRequestProvider(Empty);

        public HttpRequestProvider(ValueExpression original) : base(typeof(Request), original)
        {
        }

        public override Type UriBuilderType => typeof(RawRequestUriBuilder);

        public override ValueExpression Content()
            => Original.Property(nameof(Request.Content));

        public override HttpRequestApi FromExpression(ValueExpression original)
            => new HttpRequestProvider(original);

        public override MethodBodyStatement SetHeaders(IReadOnlyList<ValueExpression> arguments)
            => Original.Property(nameof(Request.Headers)).Invoke(nameof(RequestHeaders.SetValue), arguments).Terminate();

        public MethodBodyStatement SetMethod(ScopedApi<string> httpMethod)
            => Original.Property(nameof(Request.Method)).Assign(CreateRequestMethod(httpMethod)).Terminate();

        public MethodBodyStatement SetUri(ValueExpression value)
            => Original.Property("Uri").Assign(value).Terminate();

        public override HttpRequestApi ToExpression() => this;

        private ValueExpression CreateRequestMethod(ScopedApi<string> httpMethod)
        {
            var httpMethodString = ParseHttpMethodString(httpMethod);
            return httpMethodString is null
                ? New.Instance(typeof(RequestMethod), [httpMethod])
                : Static<RequestMethod>().Property(httpMethodString);
        }

        private string? ParseHttpMethodString(ScopedApi<string> method)
        {
            string? methodString;
            if (method.Original is LiteralExpression literal)
            {
                methodString = literal.Literal as string;
            }
            else
            {
                methodString = method.ToDisplayString();
            }
            if (methodString == null)
            {
                throw new ArgumentNullException(nameof(method));
            }
            if (methodString.Length == 3)
            {
                if (string.Equals(methodString, "GET", StringComparison.OrdinalIgnoreCase))
                {
                    return "Get";
                }

                if (string.Equals(methodString, "PUT", StringComparison.OrdinalIgnoreCase))
                {
                    return "Put";
                }
            }
            else if (methodString.Length == 4)
            {
                if (string.Equals(methodString, "POST", StringComparison.OrdinalIgnoreCase))
                {
                    return "Post";
                }

                if (string.Equals(methodString, "HEAD", StringComparison.OrdinalIgnoreCase))
                {
                    return "Head";
                }
            }
            else
            {
                if (string.Equals(methodString, "PATCH", StringComparison.OrdinalIgnoreCase))
                {
                    return "Patch";
                }

                if (string.Equals(methodString, "DELETE", StringComparison.OrdinalIgnoreCase))
                {
                    return "Delete";
                }

                if (string.Equals(methodString, "OPTIONS", StringComparison.OrdinalIgnoreCase))
                {
                    return "Options";
                }

                if (string.Equals(methodString, "TRACE", StringComparison.OrdinalIgnoreCase))
                {
                    return "Trace";
                }
            }

            return null;
        }
    }
}
