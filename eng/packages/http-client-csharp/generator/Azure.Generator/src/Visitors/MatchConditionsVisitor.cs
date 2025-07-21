// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Generator.Primitives;
using Azure.Generator.Snippets;
using Microsoft.TypeSpec.Generator.ClientModel;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Snippets;
using Microsoft.TypeSpec.Generator.Statements;
using System;
using System.Collections.Generic;
using System.Linq;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Azure.Generator.Visitors
{
    /// <summary>
    /// Visitor that modifies service methods to group conditional request headers into MatchConditions/RequestConditions types.
    /// </summary>
    internal class MatchConditionsVisitor : ScmLibraryVisitor
    {
        private static CSharpType ETagType => new CSharpType(typeof(ETag)).WithNullable(true);
        private const string IfMatch = "If-Match";
        private const string IfNoneMatch = "If-None-Match";
        private const string IfModifiedSince = "If-Modified-Since";
        private const string IfUnmodifiedSince = "If-Unmodified-Since";

        private static readonly HashSet<string> _matchConditionsHeaders = new(StringComparer.OrdinalIgnoreCase)
        {
            IfMatch, IfNoneMatch, IfModifiedSince, IfUnmodifiedSince
        };

        protected override ScmMethodProvider? VisitMethod(ScmMethodProvider method)
        {
            if (method.ServiceMethod == null)
            {
                return base.VisitMethod(method);
            }

            // Check if there are any optional match condition parameters to process
            if (!ContainsOptionalMatchConditionParameters(method.ServiceMethod))
            {
                return base.VisitMethod(method);
            }

            var matchConditionParams = GetMatchConditionParameters(method.Signature.Parameters);
            if (matchConditionParams.Count == 1)
            {
                // Handle the case where only a single IfMatch or IfNoneMatch parameter exists
                // In this case, replace with ETag? type instead of RequestConditions/MatchConditions
                matchConditionParams[0].Update(type: ETagType);
            }
            else if (matchConditionParams.Count > 1)
            {
                // Handle the case where both IfMatch/IfNoneMatch parameters are present
                // Group them into a single MatchConditions parameter
                var matchConditionsParameter = KnownAzureParameters.MatchConditionsParameter;
                matchConditionsParameter.Update(wireInfo: matchConditionParams[0].WireInfo);

                // Remove the other match condition parameters
                var updatedParams = new List<ParameterProvider>();
                bool addedMatchConditionsParameter = false;
                foreach (var param in method.Signature.Parameters)
                {
                    if (IsMatchConditionHeader(param.WireInfo.SerializedName) && !addedMatchConditionsParameter)
                    {
                        updatedParams.Add(matchConditionsParameter);
                        addedMatchConditionsParameter = true;
                    }
                    else if (!IsMatchConditionHeader(param.WireInfo.SerializedName))
                    {
                        updatedParams.Add(param);
                    }
                }

                // Update the method signature with the new parameters
                method.Signature.Update(parameters: updatedParams);
            }

            // Update the CreateRequest method body if this is a RestClient method
            if (IsCreateRequestMethod(method))
            {
                UpdateCreateRequestMethodBody(method, matchConditionParams);
            }
            else if (matchConditionParams.Count > 1 && method.IsProtocolMethod)
            {
                UpdateProtocolMethod(method);
            }

            return method;
        }

        private static void UpdateProtocolMethod(ScmMethodProvider method)
        {
            if (method.BodyStatements == null)
            {
                return;
            }

            var updatedStatements = new List<MethodBodyStatement>();

            foreach (var statement in method.BodyStatements)
            {
                var updatedStatement = UpdateCreateRequestInvocationStatement(statement);
                updatedStatements.Add(updatedStatement);
            }

            method.Update(bodyStatements: updatedStatements, signature: method.Signature);
        }

        private static MethodBodyStatement UpdateCreateRequestInvocationStatement(MethodBodyStatement statement)
        {
            if (statement is TryCatchFinallyStatement tryCatchFinallyStatement)
            {
                foreach (var tryBodyStatement in tryCatchFinallyStatement.Try.Body)
                {
                    if (tryBodyStatement is ExpressionStatement expressionStatement)
                    {
                        if (expressionStatement.Expression is AssignmentExpression assignmentExpression &&
                            assignmentExpression.Value is InvokeMethodExpression invokeExpression &&
                            IsCreateRequestMethodInvocation(invokeExpression))
                        {
                            var updatedArguments = new List<ValueExpression>();
                            bool addedMatchConditions = false;
                            foreach (var argument in invokeExpression.Arguments)
                            {
                                if (argument is VariableExpression variable)
                                {
                                    if (variable.Declaration.RequestedName == "ifMatch" ||
                                        variable.Declaration.RequestedName == "ifNoneMatch")
                                    {
                                        if (addedMatchConditions)
                                        {
                                            continue;
                                        }

                                        updatedArguments.Add(KnownAzureParameters.MatchConditionsParameter);
                                        addedMatchConditions = true;
                                    }
                                    else
                                    {
                                        updatedArguments.Add(argument);
                                    }
                                }
                                else
                                {
                                    updatedArguments.Add(argument);
                                }
                            }
                            invokeExpression.Update(arguments: updatedArguments);
                            var updatedAssignment = new AssignmentExpression(
                                assignmentExpression.Variable,
                                invokeExpression);
                            expressionStatement.Update(expression: updatedAssignment);
                        }
                    }
                }
            }

            return statement;
        }

        private static bool IsCreateRequestMethodInvocation(InvokeMethodExpression invocation)
        {
            // Check if the method name suggests it's a CreateRequest method
            var methodName = invocation.MethodSignature?.Name;
            return methodName?.StartsWith("Create") == true &&
                   methodName?.EndsWith("Request") == true;
        }

        private static void UpdateCreateRequestMethodBody(ScmMethodProvider method, List<ParameterProvider> matchConditionParams)
        {
            if (method.BodyStatements == null)
            {
                return;
            }

            var updatedStatements = new List<MethodBodyStatement>();
            bool updatedIfStatement = false;

            foreach (var statement in method.BodyStatements)
            {
                if (!TryUpdateIfStatementForMatchConditions(statement, matchConditionParams, out var updatedStatement))
                {
                    updatedStatements.Add(statement);
                }
                else if (!updatedIfStatement)
                {
                    updatedIfStatement = true;
                    updatedStatements.Add(updatedStatement);
                }
            }

            method.Update(bodyStatements: updatedStatements);
        }

        private static bool TryUpdateIfStatementForMatchConditions(
            MethodBodyStatement statement,
            List<ParameterProvider> matchConditionParams,
            out MethodBodyStatement updatedStatement)
        {
            updatedStatement = statement;
            if (statement is not IfStatement ifStatement)
            {
                return false;
            }

            var updatedIfStatement = ifStatement;
            var ifBody = updatedIfStatement.Body;
            if (ifBody == null)
            {
                return false;
            }

            foreach (var bodyStatement in ifBody)
            {
                if (bodyStatement is ExpressionStatement expressionStatement &&
                    expressionStatement.Expression is InvokeMethodExpression invokeExpression &&
                    invokeExpression.InstanceReference is MemberExpression { Inner: VariableExpression variableExpression })
                {
                    if (variableExpression.Type.Equals(variableExpression.ToApi<HttpRequestApi>().Type))
                    {
                        var headerInfo = ExtractHeaderInfo(invokeExpression);
                        if (headerInfo.HasValue)
                        {
                            var (headerName, headerValue) = headerInfo.Value;

                            if (IsMatchConditionHeader(headerName))
                            {
                                if (matchConditionParams.Count > 1)
                                {
                                    // For MatchConditions, use AddHeader which will handle the header addition appropriately
                                    updatedIfStatement.Update(
                                        condition: KnownAzureParameters.MatchConditionsParameter.NotEqual(Null),
                                        body: variableExpression.As<Request>().AddHeader(KnownAzureParameters.MatchConditionsParameter));
                                    return true;
                                }
                                else if (matchConditionParams.Count == 1)
                                {
                                    // For single ETag parameter, use AddHeaderValue with the header name and Value property
                                    updatedIfStatement.Update(body: variableExpression.As<Request>().AddHeaderValue(
                                        headerName,
                                        headerValue.Property("Value")));
                                    return true;
                                }
                            }
                        }
                    }
                }
            }

            return false;
        }

        private static bool IsCreateRequestMethod(ScmMethodProvider method)
        {
            return method.EnclosingType is RestClientProvider &&
                method.ServiceMethod != null &&
                !method.IsProtocolMethod &&
                method.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Internal) &&
                method.Signature.ReturnType?.Equals(typeof(HttpMessage)) == true;
        }

        private static bool IsMatchConditionHeader(string headerName)
        {
            return string.Equals(headerName, IfMatch, StringComparison.OrdinalIgnoreCase) ||
                   string.Equals(headerName, IfNoneMatch, StringComparison.OrdinalIgnoreCase);
        }

        private static List<ParameterProvider> GetMatchConditionParameters(IReadOnlyList<ParameterProvider> parameters)
        {
            var matchConditionParams = new List<ParameterProvider>();

            foreach (var parameter in parameters)
            {
                if (IsMatchConditionParameter(parameter))
                {
                    matchConditionParams.Add(parameter);
                }
            }

            return matchConditionParams;
        }

        private static (string HeaderName, ValueExpression HeaderValue)? ExtractHeaderInfo(InvokeMethodExpression invokeExpression)
        {
            if (invokeExpression.Arguments.FirstOrDefault() is ScopedApi<string> scopedApi &&
                scopedApi.Original is LiteralExpression literalExpression &&
                literalExpression.Literal is string headerName &&
                _matchConditionsHeaders.Contains(headerName))
            {
                var headerValue = invokeExpression.Arguments.Count > 1
                    ? invokeExpression.Arguments[1]
                    : null;

                if (headerValue != null)
                {
                    return (headerName, headerValue);
                }
            }

            return null;
        }

        private static bool IsMatchConditionParameter(ParameterProvider parameter)
        {
            return parameter.Type.IsNullable &&
                   parameter.Location == ParameterLocation.Header &&
                   IsMatchConditionHeader(parameter.WireInfo.SerializedName);
        }

        private static bool ContainsOptionalMatchConditionParameters(InputServiceMethod inputServiceMethod)
        {
            return inputServiceMethod.Parameters.Any(IsOptionalMatchConditionParameter) ||
                   inputServiceMethod.Operation.Parameters.Any(IsOptionalMatchConditionParameter);
        }

        private static bool IsOptionalMatchConditionParameter(InputParameter parameter)
        {
            return !parameter.IsRequired &&
                parameter.Location == InputRequestLocation.Header &&
                _matchConditionsHeaders.Contains(parameter.NameInRequest);
        }
    }
}