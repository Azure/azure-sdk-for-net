// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Snippets;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Azure.Generator.Management.Snippets;

internal static class ResponseSnippets
{
    public static ValueExpression FromValue(ValueExpression value, ValueExpression response)
        => Static(typeof(Response)).Invoke(nameof(Response.FromValue), [value, response]);

    public static ScopedApi<Response> GetRawResponse(this ScopedApi<Response> response)
        => response.Invoke(nameof(Response<object>.GetRawResponse)).As<Response>();

    public static ValueExpression Value(this ScopedApi<Response> response)
        => response.Property(nameof(Response<object>.Value));
}
