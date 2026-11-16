// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text.Json;
using Microsoft.TypeSpec.Generator.ClientModel;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Statements;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Extensions.Plugin.Visitors;

/// <summary> Preserves the direction and termination contract of voice-agent telephony cursor pages. </summary>
public class VoiceAgentTelephonyPaginationVisitor : ScmLibraryVisitor
{
    private const string AgentsNamespace = "Azure.AI.Projects.Agents";
    private const string CallJobsScope = "BetaVoiceAgentsTelephony.GetTelephonyCallJobs";
    private const string CallHistoryScope = "BetaVoiceAgentsTelephony.GetTelephonyCalls";
    private const string CursorMethodName = "GetTelephonyContinuationCursor";
    private readonly Dictionary<string, CSharpType> _pageTypes = new(StringComparer.Ordinal);

    protected override ModelProvider PreVisitModel(InputModelType model, ModelProvider type)
    {
        if (type?.Type.Namespace == AgentsNamespace &&
            type.Name is "TelephonyCampaignPageTelephonyCampaign" or "TelephonyCampaignValidationErrorPage" or "AgentsPagedResultTelephonyCallJob" or "AgentsPagedResultTelephonyCallSummary")
        {
            _pageTypes[type.Name] = type.Type;
        }
        return type;
    }

    protected override TypeProvider VisitType(TypeProvider type)
    {
        if (IsTelephonyPager(type))
        {
            if (type is CollectionResultDefinition { ScopeName: "TelephonyCampaigns.GetAll" or "TelephonyCampaigns.GetValidationErrors" } &&
                !type.Attributes.Concat(type.CustomCodeView?.Attributes ?? []).Any(attribute => attribute.Type.Name == nameof(ExperimentalAttribute)))
            {
                type.Update(attributes: [.. type.Attributes, new AttributeStatement(typeof(ExperimentalAttribute), Literal("AAIP001"))]);
            }
            type.Update(methods: [.. type.Methods, BuildCursorMethod(type)]);
        }
        return base.VisitType(type);
    }

    protected override ValueExpression VisitMemberExpression(MemberExpression expression, MethodProvider method)
    {
        if (IsTelephonyPager(method.EnclosingType) &&
            method.Signature.Name is "GetRawPages" or "GetRawPagesAsync" or "GetContinuationToken" &&
            expression is { MemberName: "LastId", Inner: not null })
        {
            return This.Invoke(CursorMethodName, expression.Inner);
        }
        return base.VisitMemberExpression(expression, method);
    }

    protected override ValueExpression VisitInvokeMethodExpression(InvokeMethodExpression expression, MethodProvider method)
    {
        if (IsTelephonyPager(method.EnclosingType) &&
            method.Signature.Name is "GetRawPages" or "GetRawPagesAsync" &&
            expression.MethodName is "CreateGetAllRequest" or "CreateGetValidationErrorsRequest" or "CreateGetTelephonyCallJobsRequest" or "CreateGetTelephonyCallsRequest")
        {
            // Collection result constructors keep the request parameters after their client parameter.
            ParameterProvider[] parameters = method.EnclosingType.Constructors.Single().Signature.Parameters.Skip(1).ToArray();
            int afterIndex = Array.FindIndex(parameters, parameter => parameter.Name == "after");
            int beforeIndex = Array.FindIndex(parameters, parameter => parameter.Name == "before");
            if (afterIndex < 0 || beforeIndex < 0 || expression.Arguments.Count != parameters.Length)
            {
                throw new InvalidOperationException($"Unexpected telephony paging request shape in {method.EnclosingType.Name}.");
            }

            // Leave the initial request untouched; only the continuation call uses nextToken.
            if (expression.Arguments[afterIndex] is VariableExpression { Declaration.RequestedName: "nextToken" } cursor)
            {
                ValueExpression[] arguments = expression.Arguments.ToArray();
                arguments[afterIndex] = new TernaryConditionalExpression(IsBackward, Null, cursor);
                arguments[beforeIndex] = new TernaryConditionalExpression(IsBackward, cursor, Null);
                expression.Update(arguments: arguments);
            }
        }
        return base.VisitInvokeMethodExpression(expression, method);
    }

    private MethodProvider BuildCursorMethod(TypeProvider pager)
    {
        string scope = ((CollectionResultDefinition)pager).ScopeName;
        string pageName = scope switch
        {
            "TelephonyCampaigns.GetAll" => "TelephonyCampaignPageTelephonyCampaign",
            "TelephonyCampaigns.GetValidationErrors" => "TelephonyCampaignValidationErrorPage",
            CallJobsScope => "AgentsPagedResultTelephonyCallJob",
            CallHistoryScope => "AgentsPagedResultTelephonyCallSummary",
            _ => throw new InvalidOperationException($"Unexpected telephony paging scope {scope}.")
        };
        string pageKind = scope switch
        {
            CallJobsScope => "telephony call-job",
            CallHistoryScope => "telephony call-history",
            _ => "telephony campaign"
        };
        ParameterProvider page = new("page", $"The current telephony page.", _pageTypes[pageName]);
        ValueExpression value = page.AsVariable();
        return new MethodProvider(
            new MethodSignature(CursorMethodName, $"Gets the boundary cursor only when more results exist.",
                MethodSignatureModifiers.Private, typeof(string), null, [page]),
            new MethodBodyStatement[]
            {
                new IfStatement(Not(value.Property("HasMore"))) { Return(Null) },
                Declare("cursor", typeof(string),
                    new TernaryConditionalExpression(IsBackward, value.Property("FirstId"), value.Property("LastId")), out var cursor),
                new IfStatement(Static<string>().Invoke(nameof(string.IsNullOrEmpty), cursor))
                {
                    Throw(New.Instance<JsonException>(new TernaryConditionalExpression(IsBackward,
                        Literal($"A backward {pageKind} page with has_more=true must include a non-empty first_id."),
                        Literal($"A forward {pageKind} page with has_more=true must include a non-empty last_id."))))
                },
                Return(cursor)
            }, pager);
    }

    private static ValueExpression IsBackward => This.Property("_before").NotEqual(Null);

    private static bool IsTelephonyPager(TypeProvider type)
        => type.Type.Namespace == AgentsNamespace && type is CollectionResultDefinition
        {
            ScopeName: "TelephonyCampaigns.GetAll" or "TelephonyCampaigns.GetValidationErrors" or CallJobsScope or CallHistoryScope
        };
}
