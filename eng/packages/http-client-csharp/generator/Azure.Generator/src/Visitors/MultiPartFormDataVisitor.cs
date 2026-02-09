// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Pipeline;
using Microsoft.TypeSpec.Generator.ClientModel;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Statements;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Azure.Generator.Visitors
{
    internal class MultiPartFormDataVisitor : ScmLibraryVisitor
    {
        protected override MethodBodyStatement VisitExpressionStatement(ExpressionStatement statement, MethodProvider method)
        {
            if (method is { EnclosingType: MultiPartFormDataBinaryContentDefinition, Signature.Name: "WriteTo" })
            {
                // Replaces GetAwaiter().GetResult() with EnsureCompleted() for the sync over async path.
                if (statement.Expression is InvokeMethodExpression invokeMethod)
                {
                    if (invokeMethod.InstanceReference is InvokeMethodExpression innerInvoke)
                    {
                        invokeMethod.Update(
                            instanceReference: innerInvoke.InstanceReference,
                            methodName: nameof(TaskExtensions.EnsureCompleted),
                            extensionType: typeof(TaskExtensions));
                        return new SuppressionStatement(statement, Literal("AZC0107"),
                            "Public asynchronous method shouldn't be called in synchronous scope. Use synchronous version of the method if it is available.");
                    }
                }
            }

            return statement;
        }
    }
}