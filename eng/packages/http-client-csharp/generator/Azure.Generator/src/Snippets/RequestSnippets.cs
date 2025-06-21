// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using Azure.Core;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Snippets;
using Microsoft.TypeSpec.Generator.Statements;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Azure.Generator.Snippets
{
    internal static class RequestSnippets
    {
        public static MethodBodyStatement SetHeaderValue(this ScopedApi<Request> request, string name, ValueExpression value)
            => request.Property(nameof(PipelineRequest.Headers)).Invoke(nameof(RequestHeaders.SetValue), Literal(name), value).Terminate();
    }
}