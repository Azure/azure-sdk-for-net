// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.ClientModel;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Providers;
using System;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Azure.Generator.Management.Visitors;

/// <summary>
/// Aligns the pinned base generator's query replacement helper with AppendQuery's
/// escaping contract without changing data-plane output or pre-escaping request arguments.
/// </summary>
internal class RawRequestUriBuilderVisitor : ScmLibraryVisitor
{
    protected override ValueExpression? VisitInvokeMethodExpression(InvokeMethodExpression expression, MethodProvider method)
    {
        if (method.EnclosingType.Name == "RawRequestUriBuilderExtensions"
            && method.Signature.Name == "UpdateQuery"
            && method.Signature.Parameters.Count == 3
            && expression.MethodName == "Concat"
            && expression.Arguments.Count == 3
            && ReferenceEquals(expression.Arguments[1], (VariableExpression)method.Signature.Parameters[2]))
        {
            // Only the replacement branch concatenates the raw value into an existing
            // query. The missing-key branch already escapes through AppendQuery(..., true).
            // Matching the unmodified parameter also makes this repair idempotent and
            // leaves an already-escaped implementation from a future base version alone.
            expression.Update(arguments:
            [
                expression.Arguments[0],
                Static(typeof(Uri)).Invoke(nameof(Uri.EscapeDataString), expression.Arguments[1]),
                expression.Arguments[2]
            ]);
        }
        return expression;
    }
}
