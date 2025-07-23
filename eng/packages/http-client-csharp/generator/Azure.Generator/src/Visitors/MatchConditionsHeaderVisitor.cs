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
    internal class MatchConditionsHeaderVisitor : ScmLibraryVisitor
    {
        private static CSharpType ETagType => new CSharpType(typeof(ETag)).WithNullable(true);
        private const string IfMatch = "If-Match";
        private const string IfMatchMemberName = "IfMatch";
        private const string IfNoneMatch = "If-None-Match";
        private const string IfNoneMatchMemberName = "IfNoneMatch";
        private const string IfModifiedSince = "If-Modified-Since";
        private const string IfModifiedSinceMemberName = "IfModifiedSince";
        private const string IfUnmodifiedSince = "If-Unmodified-Since";
        private const string IfUnmodifiedSinceMemberName = "IfUnmodifiedSince";

        private static readonly HashSet<string> _matchConditionsHeaders = new(StringComparer.OrdinalIgnoreCase)
        {
            IfMatch,
            IfMatchMemberName,
            IfNoneMatch,
            IfNoneMatchMemberName,
            IfModifiedSince,
            IfModifiedSinceMemberName,
            IfUnmodifiedSince,
            IfUnmodifiedSinceMemberName,
        };

        private static readonly Dictionary<RequestConditionHeaders, string> _requestConditionsHeaders = new()
        {
            { RequestConditionHeaders.None, string.Empty },
            { RequestConditionHeaders.IfMatch, IfMatch },
            { RequestConditionHeaders.IfNoneMatch, IfNoneMatch },
            { RequestConditionHeaders.IfModifiedSince, IfModifiedSince },
            { RequestConditionHeaders.IfUnmodifiedSince, IfUnmodifiedSince }
        };

        protected override ScmMethodProvider? VisitMethod(ScmMethodProvider method)
        {
            if (method.ServiceMethod == null || !ContainsOptionalMatchConditionParameters(method.ServiceMethod))
            {
                return base.VisitMethod(method);
            }

            var headerFlags = ParseMatchConditionHeaders(method);
            if (headerFlags == RequestConditionHeaders.None)
            {
                return base.VisitMethod(method);
            }

            var matchConditionParams = GetMatchConditionParameters(method.Signature.Parameters);
            if (matchConditionParams.Count == 0)
            {
                return base.VisitMethod(method);
            }

            // Update method parameters
            switch (headerFlags)
            {
                case RequestConditionHeaders.IfMatch:
                case RequestConditionHeaders.IfNoneMatch:
                    // Handle the case where only a single IfMatch or IfNoneMatch parameter exists
                    // In this case, replace with ETag? type instead of RequestConditions/MatchConditions
                    matchConditionParams[0].Update(type: ETagType);
                    break;

                case RequestConditionHeaders.IfMatch | RequestConditionHeaders.IfNoneMatch:
                    // Handle the case where both IfMatch/IfNoneMatch parameters are present
                    // Group them into a single MatchConditions parameter
                    UpdateMethodSignatureWithMatchConditionParameter(method, matchConditionParams);
                    break;

                case var flags when (flags & (RequestConditionHeaders.IfModifiedSince | RequestConditionHeaders.IfUnmodifiedSince)) != 0:
                    // Handle date-based conditions (If-Modified-Since, If-Unmodified-Since)
                    // These would require RequestConditions type
                    UpdateMethodSignatureWithRequestConditionsParameter(method, matchConditionParams);
                    break;
            }

            // Update method body if necessary
            if (IsCreateRequestMethod(method))
            {
                UpdateCreateRequestMethodBody(method, headerFlags);
            }
            else
            {
                UpdateClientMethod(method, headerFlags);
            }

            return method;
        }

        private static RequestConditionHeaders ParseMatchConditionHeaders(ScmMethodProvider method)
        {
            var flags = RequestConditionHeaders.None;

            var allParameters = method.IsProtocolMethod || IsCreateRequestMethod(method)
                ? method.ServiceMethod!.Operation.Parameters
                : method.ServiceMethod!.Parameters;

            foreach (var parameter in allParameters)
            {
                if (!parameter.IsRequired && parameter.Location == InputRequestLocation.Header)
                {
                    switch (parameter.NameInRequest.ToLowerInvariant())
                    {
                        case "if-match":
                            flags |= RequestConditionHeaders.IfMatch;
                            break;
                        case "if-none-match":
                            flags |= RequestConditionHeaders.IfNoneMatch;
                            break;
                        case "if-modified-since":
                            flags |= RequestConditionHeaders.IfModifiedSince;
                            break;
                        case "if-unmodified-since":
                            flags |= RequestConditionHeaders.IfUnmodifiedSince;
                            break;
                    }
                }
            }

            return flags;
        }

        private static string? ParseRequestConditionsSerializationFormat(ScmMethodProvider method)
        {
            foreach (var parameter in method.Signature.Parameters)
            {
                if (parameter.Location == ParameterLocation.Header && IsRequestConditionHeader(parameter.WireInfo.SerializedName))
                {
                    var wireName = parameter.WireInfo.SerializedName.ToLowerInvariant();
                    switch (wireName)
                    {
                        case "if-modified-since":
                        case "if-unmodified-since":
                            return parameter.WireInfo.SerializationFormat.ToFormatSpecifier();
                    }
                }
            }

            return null;
        }

        private static bool IsSingleRequestConditionHeader(RequestConditionHeaders flags)
        {
            return flags == RequestConditionHeaders.IfMatch || flags == RequestConditionHeaders.IfNoneMatch;
        }

        private static bool HasMultipleRequestConditionHeaders(RequestConditionHeaders flags)
        {
            return (flags & RequestConditionHeaders.IfMatch) != 0 && (flags & RequestConditionHeaders.IfNoneMatch) != 0;
        }

        private static bool HasModificationTimeHeaders(RequestConditionHeaders headers)
        {
            return headers.HasFlag(RequestConditionHeaders.IfModifiedSince) || headers.HasFlag(RequestConditionHeaders.IfUnmodifiedSince);
        }

        private static void UpdateMethodSignatureWithMatchConditionParameter(ScmMethodProvider method, List<ParameterProvider> matchConditionParams)
        {
            ParameterProvider matchConditionsParameter = (method.IsProtocolMethod || IsCreateRequestMethod(method)) &&
                method.Signature.Parameters.FirstOrDefault(p => p.Name == "context")?.DefaultValue == null
                    ? KnownAzureParameters.MatchConditionsParameter
                    : KnownAzureParameters.OptionalMatchConditionsParameter;

            matchConditionsParameter.Update(wireInfo: matchConditionParams[0].WireInfo);

            // Remove the other match condition parameters
            var updatedParams = new List<ParameterProvider>();
            bool addedMatchConditionsParameter = false;
            List<XmlDocParamStatement> xmlParameterDocs = [];

            foreach (var param in method.Signature.Parameters)
            {
                if (IsRequestConditionHeader(param.WireInfo.SerializedName) && !addedMatchConditionsParameter)
                {
                    updatedParams.Add(matchConditionsParameter);
                    xmlParameterDocs.Add(new XmlDocParamStatement(matchConditionsParameter));
                    addedMatchConditionsParameter = true;
                }
                else if (!IsRequestConditionHeader(param.WireInfo.SerializedName))
                {
                    updatedParams.Add(param);
                    xmlParameterDocs.Add(new XmlDocParamStatement(param));
                }
            }

            // Update the method signature & xml docs with the new parameters
            if (!IsCreateRequestMethod(method))
            {
                method.XmlDocs.Update(parameters: xmlParameterDocs);
            }

            // Update the method signature with the new parameters
            method.Signature.Update(parameters: updatedParams);
        }

        private static void UpdateMethodSignatureWithRequestConditionsParameter(
            ScmMethodProvider method,
            List<ParameterProvider> matchConditionParams)
        {
            ParameterProvider requestConditionsParameter = (method.IsProtocolMethod || IsCreateRequestMethod(method)) &&
               method.Signature.Parameters.FirstOrDefault(p => p.Name == "context")?.DefaultValue == null
                   ? KnownAzureParameters.RequestConditionsParameter
                   : KnownAzureParameters.OptionalRequestConditionsParameter;

            requestConditionsParameter.Update(wireInfo: matchConditionParams[0].WireInfo);

            // Remove the other match condition parameters
            var updatedParams = new List<ParameterProvider>();
            bool addedRequestConditionsParameter = false;
            List<XmlDocParamStatement> xmlParameterDocs = [];

            foreach (var param in method.Signature.Parameters)
            {
                if (IsRequestConditionHeader(param.WireInfo.SerializedName) && !addedRequestConditionsParameter)
                {
                    updatedParams.Add(requestConditionsParameter);
                    xmlParameterDocs.Add(new XmlDocParamStatement(requestConditionsParameter));
                    addedRequestConditionsParameter = true;
                }
                else if (!IsRequestConditionHeader(param.WireInfo.SerializedName))
                {
                    updatedParams.Add(param);
                    xmlParameterDocs.Add(new XmlDocParamStatement(param));
                }
            }

            // Update the method signature & xml docs with the new parameters
            if (!IsCreateRequestMethod(method))
            {
                method.XmlDocs.Update(parameters: xmlParameterDocs);
            }

            method.Signature.Update(parameters: updatedParams);
        }

        private static void UpdateClientMethod(ScmMethodProvider method, RequestConditionHeaders headerFlags)
        {
            if (method.BodyStatements == null || (!HasMultipleRequestConditionHeaders(headerFlags) && !HasModificationTimeHeaders(headerFlags)))
            {
                return;
            }

            var updatedStatements = new List<MethodBodyStatement>();
            if (method.IsProtocolMethod && HasModificationTimeHeaders(headerFlags))
            {
                ParameterProvider requestConditionsParameter = method.Signature.Parameters.FirstOrDefault(p => p.Name == "context")?.DefaultValue == null
                      ? KnownAzureParameters.RequestConditionsParameter
                      : KnownAzureParameters.OptionalRequestConditionsParameter;
                List<MethodBodyStatement> validations = [];

                foreach (RequestConditionHeaders val in Enum.GetValues(typeof(RequestConditionHeaders)).Cast<RequestConditionHeaders>())
                {
                    if (!headerFlags.HasFlag(val))
                    {
                        string? requestConditionsPropertyName = val switch
                        {
                            RequestConditionHeaders.IfMatch => nameof(RequestConditions.IfMatch),
                            RequestConditionHeaders.IfNoneMatch => nameof(RequestConditions.IfNoneMatch),
                            RequestConditionHeaders.IfModifiedSince => nameof(RequestConditions.IfModifiedSince),
                            RequestConditionHeaders.IfUnmodifiedSince => nameof(RequestConditions.IfUnmodifiedSince),
                            _ => null
                        };

                        if (requestConditionsPropertyName == null)
                        {
                            continue;
                        }

                        var validationStatement = new IfStatement(requestConditionsParameter.Property(requestConditionsPropertyName).NotEqual(Null))
                        {
                            Throw(
                                New.Instance(new CSharpType(typeof(ArgumentNullException)),
                                Literal($"Service does not support the {_requestConditionsHeaders[val]} header for this operation.")))
                        };
                        validations.Add(validationStatement);
                    }
                }

                if (validations.Count > 0)
                {
                    validations.Add(MethodBodyStatement.EmptyLine);
                }
                updatedStatements.AddRange(validations);
            }

            foreach (var statement in method.BodyStatements)
            {
                MethodBodyStatement updatedStatement = statement;
                if (method.IsProtocolMethod)
                {
                    updatedStatement = UpdateCreateRequestInvocationStatement(method, statement, headerFlags);
                }
                else
                {
                    updatedStatement = UpdateProtocolMethodInvocationStatement(statement, headerFlags);
                }

                updatedStatements.Add(updatedStatement);
            }

            method.Update(bodyStatements: updatedStatements);
        }

        private static MethodBodyStatement UpdateCreateRequestInvocationStatement(
            ScmMethodProvider method,
            MethodBodyStatement statement,
            RequestConditionHeaders headerFlags)
        {
            if (statement is not TryCatchFinallyStatement tryCatchFinallyStatement)
            {
                return statement;
            }

            var replacementParameter = GetReplacementParameter(method, headerFlags);

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
                                if (_matchConditionsHeaders.Contains(variable.Declaration.RequestedName))
                                {
                                    if (addedMatchConditions)
                                    {
                                        continue;
                                    }

                                    updatedArguments.Add(replacementParameter);
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

            return statement;
        }

        private static MethodBodyStatement UpdateProtocolMethodInvocationStatement(
            MethodBodyStatement statement,
            RequestConditionHeaders headerFlags)
        {
            var replacementParameter = (headerFlags.HasFlag(RequestConditionHeaders.IfModifiedSince) ||
                headerFlags.HasFlag(RequestConditionHeaders.IfUnmodifiedSince))
                    ? KnownAzureParameters.OptionalRequestConditionsParameter
                    : KnownAzureParameters.OptionalMatchConditionsParameter;

            if (statement is ExpressionStatement expressionStatement)
            {
                if (expressionStatement.Expression is KeywordExpression keywordExpression &&
                    keywordExpression.Expression is InvokeMethodExpression invokeExpression)
                {
                    var updatedArguments = new List<ValueExpression>();
                    bool addedMatchConditions = false;
                    foreach (var argument in invokeExpression.Arguments)
                    {
                        if (argument is VariableExpression variable)
                        {
                            if (_matchConditionsHeaders.Contains(variable.Declaration.RequestedName))
                            {
                                if (addedMatchConditions)
                                {
                                    continue;
                                }

                                updatedArguments.Add(replacementParameter);
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
                    keywordExpression.Update(keywordExpression.Keyword, invokeExpression);
                    expressionStatement.Update(expression: keywordExpression);
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

        private static void UpdateCreateRequestMethodBody(ScmMethodProvider method, RequestConditionHeaders headerFlags)
        {
            if (method.BodyStatements == null)
            {
                return;
            }

            var updatedStatements = new List<MethodBodyStatement>();
            bool updatedIfStatement = false;

            foreach (var statement in method.BodyStatements)
            {
                if (!TryUpdateIfStatementForMatchConditions(method, statement, headerFlags, out var updatedStatement))
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
            ScmMethodProvider method,
            MethodBodyStatement statement,
            RequestConditionHeaders headerFlags,
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
                                if (HasMultipleRequestConditionHeaders(headerFlags))
                                {
                                    // For MatchConditions, use AddHeader which will handle the header addition appropriately
                                    updatedIfStatement.Update(
                                         condition: KnownAzureParameters.MatchConditionsParameter.NotEqual(Null),
                                         body: variableExpression.As<Request>().AddHeader(KnownAzureParameters.MatchConditionsParameter));
                                    return true;
                                }
                                else if (IsSingleRequestConditionHeader(headerFlags))
                                {
                                    // For single ETag parameter, use AddHeaderValue with the header name and Value property
                                    updatedIfStatement.Update(body: variableExpression.As<Request>().AddHeaderValue(
                                        headerName,
                                        headerValue.Property("Value")));
                                    return true;
                                }
                                else if (HasModificationTimeHeaders(headerFlags))
                                {
                                    // For date-based conditions, use AddHeader with RequestConditions parameter and serialization format
                                    string? serializationFormat = ParseRequestConditionsSerializationFormat(method);
                                    updatedIfStatement.Update(
                                        condition: KnownAzureParameters.RequestConditionsParameter.NotEqual(Null),
                                        body: variableExpression.As<Request>().AddHeader(KnownAzureParameters.RequestConditionsParameter, serializationFormat));
                                    return true;
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

        private static bool IsRequestConditionHeader(string headerName)
        {
            return string.Equals(headerName, IfMatch, StringComparison.OrdinalIgnoreCase) ||
                   string.Equals(headerName, IfNoneMatch, StringComparison.OrdinalIgnoreCase) ||
                     string.Equals(headerName, IfModifiedSince, StringComparison.OrdinalIgnoreCase) ||
                     string.Equals(headerName, IfUnmodifiedSince, StringComparison.OrdinalIgnoreCase);
        }

        private static List<ParameterProvider> GetMatchConditionParameters(IReadOnlyList<ParameterProvider> parameters)
        {
            var matchConditionParams = new List<ParameterProvider>();

            foreach (var parameter in parameters)
            {
                if (IsRequestConditionParameter(parameter))
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

        private static bool IsRequestConditionParameter(ParameterProvider parameter)
        {
            return parameter.Type.IsNullable &&
                   parameter.Location == ParameterLocation.Header &&
                   IsRequestConditionHeader(parameter.WireInfo.SerializedName);
        }

        private static ParameterProvider GetReplacementParameter(ScmMethodProvider method, RequestConditionHeaders headerFlags)
        {
            bool hasContext = method.Signature.Parameters.FirstOrDefault(p => p.Name == "context")?.DefaultValue == null;
            bool hasDateHeaders = headerFlags.HasFlag(RequestConditionHeaders.IfModifiedSince) ||
                headerFlags.HasFlag(RequestConditionHeaders.IfUnmodifiedSince);

            return (hasDateHeaders, hasContext) switch
            {
                (true, true) => KnownAzureParameters.RequestConditionsParameter,
                (true, false) => KnownAzureParameters.OptionalRequestConditionsParameter,
                (false, true) => KnownAzureParameters.MatchConditionsParameter,
                (false, false) => KnownAzureParameters.OptionalMatchConditionsParameter
            };
        }

        [Flags]
        private enum RequestConditionHeaders
        {
            None = 0,
            IfMatch = 1,
            IfNoneMatch = 2,
            IfModifiedSince = 4,
            IfUnmodifiedSince = 8
        }
    }
}