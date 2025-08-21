// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Generator.Primitives;
using Azure.Generator.Providers;
using Azure.Generator.Snippets;
using Microsoft.TypeSpec.Generator.ClientModel;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Input.Extensions;
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
    /// Visitor that modifies service methods to group conditional request headers into <see cref="MatchConditions"/>/<see cref="RequestConditions"/> types.
    /// </summary>
    internal class MatchConditionsHeadersVisitor : ScmLibraryVisitor
    {
        private static CSharpType ETagType => new CSharpType(typeof(ETag)).WithNullable(true);
        private const string IfMatch = "If-Match";
        private const string IfNoneMatch = "If-None-Match";
        private const string IfModifiedSince = "If-Modified-Since";
        private const string IfUnmodifiedSince = "If-Unmodified-Since";

        private static readonly HashSet<string> _conditionalHeaders = new(StringComparer.OrdinalIgnoreCase)
        {
            IfMatch,
            IfMatch.ToIdentifierName(),
            IfNoneMatch,
            IfNoneMatch.ToIdentifierName(),
            IfModifiedSince,
            IfModifiedSince.ToIdentifierName(),
            IfUnmodifiedSince,
            IfUnmodifiedSince.ToIdentifierName(),
        };

        private static readonly Dictionary<RequestConditionHeaders, string> _requestConditionsFlagMap = new()
        {
            { RequestConditionHeaders.None, string.Empty },
            { RequestConditionHeaders.IfMatch, IfMatch },
            { RequestConditionHeaders.IfNoneMatch, IfNoneMatch },
            { RequestConditionHeaders.IfModifiedSince, IfModifiedSince },
            { RequestConditionHeaders.IfUnmodifiedSince, IfUnmodifiedSince }
        };

        /// <summary>
        /// Visits a method and modifies it to handle request condition headers.
        /// </summary>
        protected override ScmMethodProvider? VisitMethod(ScmMethodProvider method)
        {
            if (!TryGetMethodRequestConditionInfo(method, out var headerFlags, out var matchConditionParams))
            {
                return base.VisitMethod(method);
            }

            bool isCreateRequestMethod = IsCreateRequestMethod(method);
            // Update method parameters
            UpdateMethodParameters(method, headerFlags, matchConditionParams);

            // Update method body
            if (isCreateRequestMethod)
            {
                UpdateCreateRequestMethodBody(method, headerFlags, matchConditionParams);
            }
            else if (!HasSingleRequestConditionHeader(headerFlags))
            {
                UpdateClientMethodBody(method, headerFlags, matchConditionParams);
            }

            return method;
        }

        protected override TypeProvider? VisitType(TypeProvider type)
        {
            // reset the collection definition if it exists so any changes are properly reflected
            if (type is CollectionResultDefinition)
            {
                type.Reset();
            }

            return base.VisitType(type);
        }

        private static bool TryGetMethodRequestConditionInfo(
            ScmMethodProvider method,
            out RequestConditionHeaders headerFlags,
            out IReadOnlyList<ParameterProvider> matchConditionParams)
        {
            headerFlags = RequestConditionHeaders.None;
            matchConditionParams = [];

            if (method.ServiceMethod == null || !ContainsOptionalMatchConditionParameters(method.ServiceMethod))
            {
                return false;
            }

            // Parse header flags from the method
            headerFlags = ParseMatchConditionHeaders(method);
            if (headerFlags == RequestConditionHeaders.None)
            {
                return false;
            }

            matchConditionParams = GetMatchConditionParameters(method.Signature.Parameters);
            return matchConditionParams.Count > 0;
        }

        private static void UpdateMethodParameters(
            ScmMethodProvider method,
            RequestConditionHeaders headerFlags,
            IReadOnlyList<ParameterProvider> matchConditionParams)
        {
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
                    UpdateMethodWithConditionsParameter(method, matchConditionParams[0], headerFlags);
                    break;

                default:
                    // Default to RequestConditions type
                    UpdateMethodWithConditionsParameter(method, matchConditionParams[0], headerFlags);
                    break;
            }
        }

        private static void UpdateMethodWithConditionsParameter(
            ScmMethodProvider method,
            ParameterProvider originalMatchConditionsParameter,
            RequestConditionHeaders headerFlags)
        {
            var updatedConditionsParameter = GetConditionsParameter(
                originalMatchConditionsParameter,
                headerFlags);

            updatedConditionsParameter.Update(wireInfo: originalMatchConditionsParameter.WireInfo);

            var updatedParams = new List<ParameterProvider>();
            var xmlParameterDocs = new List<XmlDocParamStatement>();
            bool addedConditionsParameter = false;

            foreach (var param in method.Signature.Parameters)
            {
                if (_conditionalHeaders.Contains(param.WireInfo.SerializedName))
                {
                    if (!addedConditionsParameter)
                    {
                        updatedParams.Add(updatedConditionsParameter);
                        xmlParameterDocs.Add(new XmlDocParamStatement(updatedConditionsParameter));
                        addedConditionsParameter = true;
                    }
                    // Skip all conditional header parameters
                }
                else
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

        private static RequestConditionHeaders ParseMatchConditionHeaders(ScmMethodProvider method)
        {
            var flags = RequestConditionHeaders.None;

            var allParameters = method.IsProtocolMethod || IsCreateRequestMethod(method)
                ? method.ServiceMethod!.Operation.Parameters
                : method.ServiceMethod!.Parameters;

            foreach (var parameter in allParameters)
            {
                // skip optional or non-header parameters
                if (parameter.IsRequired ||
                    ((parameter is InputMethodParameter inputParameter && inputParameter.Location != InputRequestLocation.Header) ||
                     (parameter is not InputMethodParameter && parameter is not InputHeaderParameter)))
                {
                    continue;
                }

                var headerName = parameter.SerializedName;
                if (!_conditionalHeaders.Contains(headerName))
                {
                    continue;
                }

                // Map header names to flags using string comparison
                if (string.Equals(headerName, IfMatch, StringComparison.OrdinalIgnoreCase) ||
                    string.Equals(headerName, IfMatch.ToIdentifierName(), StringComparison.OrdinalIgnoreCase))
                {
                    flags |= RequestConditionHeaders.IfMatch;
                }
                else if (string.Equals(headerName, IfNoneMatch, StringComparison.OrdinalIgnoreCase) ||
                         string.Equals(headerName, IfNoneMatch.ToIdentifierName(), StringComparison.OrdinalIgnoreCase))
                {
                    flags |= RequestConditionHeaders.IfNoneMatch;
                }
                else if (string.Equals(headerName, IfModifiedSince, StringComparison.OrdinalIgnoreCase) ||
                         string.Equals(headerName, IfModifiedSince.ToIdentifierName(), StringComparison.OrdinalIgnoreCase))
                {
                    flags |= RequestConditionHeaders.IfModifiedSince;
                }
                else if (string.Equals(headerName, IfUnmodifiedSince, StringComparison.OrdinalIgnoreCase) ||
                         string.Equals(headerName, IfUnmodifiedSince.ToIdentifierName(), StringComparison.OrdinalIgnoreCase))
                {
                    flags |= RequestConditionHeaders.IfUnmodifiedSince;
                }
            }

            return flags;
        }

        private static string? ParseRequestConditionsSerializationFormat(IReadOnlyList<ParameterProvider> matchConditionParams)
        {
            foreach (var parameter in matchConditionParams)
            {
                var wireName = parameter.WireInfo.SerializedName;
                if (string.Equals(wireName, IfModifiedSince, StringComparison.OrdinalIgnoreCase) ||
                    string.Equals(wireName, IfUnmodifiedSince, StringComparison.OrdinalIgnoreCase))
                {
                    return parameter.WireInfo.SerializationFormat.ToFormatSpecifier();
                }
            }

            return null;
        }

        private static bool HasSingleRequestConditionHeader(RequestConditionHeaders headers) =>
            headers is RequestConditionHeaders.IfMatch or RequestConditionHeaders.IfNoneMatch;

        private static bool HasMultipleRequestConditionHeaders(RequestConditionHeaders headers) =>
            headers.HasFlag(RequestConditionHeaders.IfMatch) && headers.HasFlag(RequestConditionHeaders.IfNoneMatch);

        private static bool HasModificationTimeHeaders(RequestConditionHeaders headers) =>
            headers.HasFlag(RequestConditionHeaders.IfModifiedSince) || headers.HasFlag(RequestConditionHeaders.IfUnmodifiedSince);

        private static ParameterProvider GetConditionsParameter(ParameterProvider originalMatchConditionsParameter, RequestConditionHeaders headerFlags)
        {
            bool isRequired = originalMatchConditionsParameter.DefaultValue == null;
            bool useRequestConditions = HasModificationTimeHeaders(headerFlags);

            return (useRequestConditions, isRequired) switch
            {
                (true, true) => KnownAzureParameters.RequestConditionsParameter,
                (true, false) => KnownAzureParameters.OptionalRequestConditionsParameter,
                (false, true) => KnownAzureParameters.MatchConditionsParameter,
                (false, false) => KnownAzureParameters.OptionalMatchConditionsParameter
            };
        }

        private static void UpdateClientMethodBody(
            ScmMethodProvider method,
            RequestConditionHeaders headerFlags,
            IReadOnlyList<ParameterProvider> matchConditionParams)
        {
            if (method.BodyStatements == null)
            {
                return;
            }

            var updatedStatements = new List<MethodBodyStatement>();
            var requestConditionsParameter = GetConditionsParameter(matchConditionParams[0], headerFlags);

            if (method.IsProtocolMethod && HasModificationTimeHeaders(headerFlags))
            {
                // Add validation statements for unsupported headers
                var unsupportedHeaders = new[]
                {
                    (RequestConditionHeaders.IfMatch, nameof(RequestConditions.IfMatch)),
                    (RequestConditionHeaders.IfNoneMatch, nameof(RequestConditions.IfNoneMatch)),
                    (RequestConditionHeaders.IfModifiedSince, nameof(RequestConditions.IfModifiedSince)),
                    (RequestConditionHeaders.IfUnmodifiedSince, nameof(RequestConditions.IfUnmodifiedSince))
                };

                foreach (var (flag, propertyName) in unsupportedHeaders)
                {
                    if (!headerFlags.HasFlag(flag))
                    {
                        var validationStatement = new IfStatement(requestConditionsParameter.Property(propertyName).NotEqual(Null))
                        {
                            Throw(New.Instance(new CSharpType(typeof(ArgumentException)),
                                Literal($"Service does not support the {_requestConditionsFlagMap[flag]} header for this operation.")))
                        };
                        updatedStatements.Add(validationStatement);
                    }
                }

                if (updatedStatements.Count > 0)
                {
                    updatedStatements.Add(MethodBodyStatement.EmptyLine);
                }
            }

            foreach (var statement in method.BodyStatements)
            {
                var updatedStatement = UpdateMethodInvocationStatement(
                    method.IsProtocolMethod,
                    statement,
                    requestConditionsParameter);
                updatedStatements.Add(updatedStatement);
            }

            method.Update(bodyStatements: updatedStatements);
        }

        private static MethodBodyStatement UpdateMethodInvocationStatement(
            bool isProtocolMethod,
            MethodBodyStatement statement,
            ParameterProvider replacementParameter)
        {
            switch (statement)
            {
                case TryCatchFinallyStatement tryCatch when isProtocolMethod:
                    foreach (var tryBodyStatement in tryCatch.Try.Body)
                    {
                        if (tryBodyStatement is ExpressionStatement { Expression: AssignmentExpression { Value: InvokeMethodExpression invoke } } expr &&
                            IsCreateRequestMethodInvocation(invoke))
                        {
                            UpdateInvokeMethodArguments(invoke, replacementParameter);
                            expr.Update(expression: new AssignmentExpression(((AssignmentExpression)expr.Expression).Variable, invoke));
                        }
                        else if (tryBodyStatement is ExpressionStatement { Expression: KeywordExpression { Expression: NewInstanceExpression newInstanceExpression } keyword } expr1)
                        {
                            var updatedNewInstanceExpression1 = GetNewInstanceExpression(newInstanceExpression, replacementParameter);
                            keyword.Update(keyword.Keyword, updatedNewInstanceExpression1);
                            expr1.Update(expression: keyword);
                        }
                    }
                    break;

                case ExpressionStatement { Expression: KeywordExpression { Expression: InvokeMethodExpression invoke } keyword } expr:
                    UpdateInvokeMethodArguments(invoke, replacementParameter);
                    keyword.Update(keyword.Keyword, invoke);
                    expr.Update(expression: keyword);
                    break;
                case ExpressionStatement { Expression: AssignmentExpression { Value: ClientResponseApi { Original: InvokeMethodExpression invoke } } }:
                    UpdateInvokeMethodArguments(invoke, replacementParameter);
                    break;
                case ExpressionStatement { Expression: KeywordExpression { Expression: NewInstanceExpression newInstanceExpression } keyword } expr:
                    var updatedNewInstanceExpression = GetNewInstanceExpression(newInstanceExpression, replacementParameter);
                    keyword.Update(keyword.Keyword, updatedNewInstanceExpression);
                    expr.Update(expression: keyword);
                    break;
            }

            return statement;

            static void UpdateInvokeMethodArguments(InvokeMethodExpression invokeExpression, ParameterProvider replacementParameter)
            {
                var updatedArguments = ReplaceConditionalHeaderArguments(invokeExpression.Arguments, replacementParameter);
                invokeExpression.Update(arguments: updatedArguments);
            }

            static NewInstanceExpression GetNewInstanceExpression(NewInstanceExpression newInstanceExpression, ParameterProvider replacementParameter)
            {
                var updatedArguments = ReplaceConditionalHeaderArguments(newInstanceExpression.Parameters, replacementParameter);
                return new NewInstanceExpression(newInstanceExpression.Type, updatedArguments, newInstanceExpression.InitExpression);
            }

            static List<ValueExpression> ReplaceConditionalHeaderArguments(IReadOnlyList<ValueExpression> arguments, ParameterProvider replacementParameter)
            {
                var updatedArguments = new List<ValueExpression>();
                bool addedMatchConditions = false;

                foreach (var argument in arguments)
                {
                    if (argument is VariableExpression variable && _conditionalHeaders.Contains(variable.Declaration.RequestedName))
                    {
                        if (!addedMatchConditions)
                        {
                            updatedArguments.Add(replacementParameter);
                            addedMatchConditions = true;
                        }
                    }
                    else
                    {
                        updatedArguments.Add(argument);
                    }
                }

                return updatedArguments;
            }
        }

        private static bool IsCreateRequestMethodInvocation(InvokeMethodExpression invocation)
            => invocation.MethodSignature?.Name is { } methodName &&
                methodName.StartsWith("Create") &&
                methodName.EndsWith("Request");

        private static void UpdateCreateRequestMethodBody(
            ScmMethodProvider method,
            RequestConditionHeaders headerFlags,
            IReadOnlyList<ParameterProvider> matchConditionParams)
        {
            if (method.BodyStatements == null)
            {
                return;
            }

            var updatedStatements = new List<MethodBodyStatement>();
            bool updatedIfStatement = false;

            foreach (var statement in method.BodyStatements)
            {
                if (!TryUpdateIfStatement(statement, headerFlags, matchConditionParams, out var updatedStatement))
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

        private static bool TryUpdateIfStatement(
            MethodBodyStatement statement,
            RequestConditionHeaders headerFlags,
            IReadOnlyList<ParameterProvider> matchConditionParams,
            out MethodBodyStatement updatedStatement)
        {
            updatedStatement = statement;
            if (statement is not IfStatement ifStatement || ifStatement.Body == null)
            {
                return false;
            }

            foreach (var bodyStatement in ifStatement.Body)
            {
                if (bodyStatement is ExpressionStatement expressionStatement &&
                    expressionStatement.Expression is InvokeMethodExpression invokeExpression &&
                    invokeExpression.InstanceReference is MemberExpression { Inner: VariableExpression variableExpression } &&
                    variableExpression.Type.Equals(variableExpression.ToApi<HttpRequestApi>().Type))
                {
                    var headerInfo = ExtractHeaderInfo(invokeExpression);
                    if (headerInfo.HasValue)
                    {
                        var (headerName, headerValue) = headerInfo.Value;
                        switch (headerFlags)
                        {
                            case var flags when HasSingleRequestConditionHeader(flags):
                                ifStatement.Update(body: variableExpression.As<Request>().AddHeaderValue(headerName, headerValue.Property("Value")));
                                break;
                            case var flags when HasModificationTimeHeaders(flags):
                                string? serializationFormat = ParseRequestConditionsSerializationFormat(matchConditionParams);
                                ifStatement.Update(
                                    condition: KnownAzureParameters.RequestConditionsParameter.NotEqual(Null),
                                    body: variableExpression.As<Request>().AddHeader(KnownAzureParameters.RequestConditionsParameter, serializationFormat));
                                break;
                            case var flags when HasMultipleRequestConditionHeaders(flags):
                                ifStatement.Update(
                                    condition: KnownAzureParameters.MatchConditionsParameter.NotEqual(Null),
                                    body: variableExpression.As<Request>().AddHeader(KnownAzureParameters.MatchConditionsParameter));
                                break;
                            default:
                                return false;
                        }

                        updatedStatement = ifStatement;
                        return true;
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

        private static List<ParameterProvider> GetMatchConditionParameters(IReadOnlyList<ParameterProvider> parameters)
        {
            var matchConditionParams = new List<ParameterProvider>();

            foreach (var parameter in parameters)
            {
                if (parameter.Location == ParameterLocation.Header &&
                   _conditionalHeaders.Contains(parameter.WireInfo.SerializedName))
                {
                    matchConditionParams.Add(parameter);
                }
            }

            return matchConditionParams;
        }

        private static (string HeaderName, ValueExpression HeaderValue)? ExtractHeaderInfo(InvokeMethodExpression invokeExpression)
        {
            if (invokeExpression.Arguments.FirstOrDefault() is ScopedApi<string> { Original: LiteralExpression { Literal: string headerName } } &&
                _conditionalHeaders.Contains(headerName) &&
                invokeExpression.Arguments.Count > 1)
            {
                return (headerName, invokeExpression.Arguments[1]);
            }

            return null;
        }

        private static bool ContainsOptionalMatchConditionParameters(InputServiceMethod inputServiceMethod)
        {
            return inputServiceMethod.Parameters.Concat(inputServiceMethod.Operation.Parameters)
                .Any(parameter => !parameter.IsRequired &&
                    ((parameter is InputMethodParameter inputMethodParameter && inputMethodParameter.Location == InputRequestLocation.Header) ||
                     parameter is InputHeaderParameter) &&
                    _conditionalHeaders.Contains(parameter.SerializedName));
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