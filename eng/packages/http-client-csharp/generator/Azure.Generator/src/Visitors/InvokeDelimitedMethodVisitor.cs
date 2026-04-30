// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.ClientModel;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Statements;

namespace Azure.Generator.Visitors
{
    // Switches Append/SetDelimited method calls to use the extension methods generated in Azure libraries
    internal class InvokeDelimitedMethodVisitor : ScmLibraryVisitor
    {
        protected override MethodBodyStatement? VisitExpressionStatement(ExpressionStatement statement, MethodProvider method)
        {
            if (statement.Expression is InvokeMethodExpression invokeMethod)
            {
                if (invokeMethod.MethodName == "AppendQueryDelimited")
                {
                    invokeMethod.Update(extensionType: AzureClientGenerator.Instance
                        .RawRequestUriBuilderExtensionsDefinition.Type);
                }
                else if (invokeMethod.MethodName == "SetDelimited")
                {
                    invokeMethod.Update(extensionType: AzureClientGenerator.Instance
                        .RequestHeaderExtensionsDefinition.Type);
                }
            }

            return statement;
        }
    }
}