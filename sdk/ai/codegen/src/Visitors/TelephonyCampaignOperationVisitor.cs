// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.TypeSpec.Generator.ClientModel;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Providers;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Extensions.Plugin.Visitors;

/// <summary> Uses the initiating operation ID for campaign polling and final reads. </summary>
public class TelephonyCampaignOperationVisitor : ScmLibraryVisitor
{
    protected override ValueExpression VisitInvokeMethodExpression(InvokeMethodExpression expression, MethodProvider method)
    {
        if (method.EnclosingType.Type.Namespace == "Azure.AI.Projects.Agents" &&
            method.EnclosingType.Name == "TelephonyCampaigns" &&
            method.Signature.Name is "Create" or "CreateAsync" or "Cancel" or "CancelAsync" &&
            expression.MethodName is "ProcessMessage" or "ProcessMessageAsync")
        {
            if (expression.Arguments.Count != 5 || method.Signature.Parameters.Count < 3 ||
                !method.Signature.Parameters[0].Type.Equals(typeof(bool)) ||
                !method.Signature.Parameters[1].Type.Equals(typeof(string)) ||
                !method.Signature.Parameters[2].Type.Equals(typeof(string)))
            {
                throw new InvalidOperationException("Unexpected campaign long-running operation helper signature.");
            }
            InvokeMethodExpression invocation = new(This,
                expression.MethodName == "ProcessMessageAsync" ? "ProcessCampaignOperationAsync" : "ProcessCampaignOperation",
                [
                expression.Arguments[1],
                expression.Arguments[2],
                expression.Arguments[4],
                method.Signature.Parameters[1].AsVariable(),
                method.Signature.Parameters[2].AsVariable()
                ]);
            invocation.Update(callAsAsync: expression.CallAsAsync, addConfigureAwaitFalse: expression.AddConfigureAwaitFalse);
            return invocation;
        }
        return base.VisitInvokeMethodExpression(expression, method);
    }
}
