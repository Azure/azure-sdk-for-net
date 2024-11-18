﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Microsoft.Generator.CSharp.ClientModel.Providers;
using Microsoft.Generator.CSharp.Expressions;
using Microsoft.Generator.CSharp.Statements;
using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using static Microsoft.Generator.CSharp.Snippets.Snippet;

namespace Azure.Generator.Providers
{
    internal record HttpRequestProvider : HttpRequestApi
    {
        private static HttpRequestApi? _instance;
        internal static HttpRequestApi Instance => _instance ??= new HttpRequestProvider(Empty);

        public HttpRequestProvider(ValueExpression original) : base(typeof(Request), original)
        {
        }

        public override ValueExpression Content()
            => Original.Property(nameof(Request.Content));

        public override HttpRequestApi FromExpression(ValueExpression original)
            => new HttpRequestProvider(original);

        public override MethodBodyStatement SetHeaders(IReadOnlyList<ValueExpression> arguments)
            => Original.Property(nameof(PipelineRequest.Headers)).Invoke(nameof(RequestHeaders.SetValue), arguments).Terminate();

        public override MethodBodyStatement SetMethod(string httpMethod)
            => Original.Property(nameof(PipelineRequest.Method)).Assign(CreateRequestMethod(httpMethod)).Terminate();

        public override MethodBodyStatement SetUri(ValueExpression value)
            => Original.Property("Uri").Assign(value).Terminate();

        public override HttpRequestApi ToExpression() => this;

        private ValueExpression CreateRequestMethod(string httpMethod)
        {
            var httpMethodString = ParseHttpMethodString(httpMethod);
            return httpMethodString is null
                ? New.Instance(typeof(RequestMethod), [Literal(httpMethod)])
                : Static<RequestMethod>().Property(httpMethodString);
        }

        private string? ParseHttpMethodString(string method)
        {
            if (method == null)
            {
                throw new ArgumentNullException(nameof(method));
            }
            if (method.Length == 3)
            {
                if (string.Equals(method, "GET", StringComparison.OrdinalIgnoreCase))
                {
                    return "Get";
                }

                if (string.Equals(method, "PUT", StringComparison.OrdinalIgnoreCase))
                {
                    return "Put";
                }
            }
            else if (method.Length == 4)
            {
                if (string.Equals(method, "POST", StringComparison.OrdinalIgnoreCase))
                {
                    return "Post";
                }

                if (string.Equals(method, "HEAD", StringComparison.OrdinalIgnoreCase))
                {
                    return "Head";
                }
            }
            else
            {
                if (string.Equals(method, "PATCH", StringComparison.OrdinalIgnoreCase))
                {
                    return "Patch";
                }

                if (string.Equals(method, "DELETE", StringComparison.OrdinalIgnoreCase))
                {
                    return "Delete";
                }

                if (string.Equals(method, "OPTIONS", StringComparison.OrdinalIgnoreCase))
                {
                    return "Options";
                }

                if (string.Equals(method, "TRACE", StringComparison.OrdinalIgnoreCase))
                {
                    return "Trace";
                }
            }

            return null;
        }
    }
}
