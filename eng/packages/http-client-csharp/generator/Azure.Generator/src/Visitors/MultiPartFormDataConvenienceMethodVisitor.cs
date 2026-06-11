// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Generator.Snippets;
using Microsoft.TypeSpec.Generator.ClientModel;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Statements;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Azure.Generator.Visitors
{
    /// <summary>
    /// Rewrites the generated multipart convenience methods (both <c>multipart/form-data</c> and other multipart
    /// subtypes such as <c>multipart/mixed</c>) so the multipart payload produced by the upstream generator is wrapped
    /// in a <c>RequestContent</c> via the <c>RequestContent.Create</c> factory method before being passed to the
    /// protocol method.
    /// </summary>
    internal class MultiPartFormDataConvenienceMethodVisitor : ScmLibraryVisitor
    {
        private const string MultipartMediaTypePrefix = "multipart/";
        private const string RequestContentVariableName = "requestContent";
        private string? _protocolMethodName;
        private VariableExpression? _requestContentVariable;
        private VariableExpression? _multipartContentVariable;

        protected override MethodProvider? VisitMethod(MethodProvider method)
        {
            _protocolMethodName = method is ScmMethodProvider { Kind: ScmMethodKind.Convenience, ServiceMethod: { } serviceMethod } scmMethod
                && IsMultipartOperation(serviceMethod.Operation)
                    ? scmMethod.Signature.Name
                    : null;
            _requestContentVariable = null;
            _multipartContentVariable = null;
            return base.VisitMethod(method);
        }

        private static bool IsMultipartOperation(InputOperation operation)
            => operation.IsMultipartFormData
                || (operation.RequestMediaTypes?.Any(mediaType =>
                    mediaType.StartsWith(MultipartMediaTypePrefix, StringComparison.OrdinalIgnoreCase)) ?? false);

        protected override MethodBodyStatement VisitStatements(MethodBodyStatements statements, MethodProvider method)
        {
            if (_protocolMethodName is null)
            {
                return statements;
            }

            // Find the statement that declares the multipart payload
            // (using MultiPartFormContent content = body.ToMultipartFormContent();) so the wrapped RequestContent can be
            // declared immediately after it.
            var contentDeclarationIndex = FindMultipartContentDeclaration(statements.Statements, out var multipartContent);
            if (contentDeclarationIndex < 0)
            {
                return statements;
            }

            _multipartContentVariable = multipartContent;
            var requestContentType = AzureClientGenerator.Instance.TypeFactory.RequestContentApi.RequestContentType;

            // using RequestContent requestContent = RequestContent.Create(content);
            var requestContentDeclaration = UsingDeclare(
                RequestContentVariableName,
                requestContentType,
                RequestContentApiSnippets.Create(multipartContent!),
                out _requestContentVariable);

            var updatedStatements = new List<MethodBodyStatement>(statements.Statements);
            updatedStatements.Insert(contentDeclarationIndex + 1, requestContentDeclaration);
            return new MethodBodyStatements(updatedStatements);
        }

        protected override ValueExpression? VisitInvokeMethodExpression(InvokeMethodExpression expression, MethodProvider method)
        {
            if (_requestContentVariable is not null
                && _multipartContentVariable is not null
                && (expression.MethodName == _protocolMethodName || expression.MethodSignature?.Name == _protocolMethodName)
                && expression.Arguments.Any(argument => IsMultipartContentReference(argument)))
            {
                var rewrittenArguments = expression.Arguments
                    .Select(argument => IsMultipartContentReference(argument) ? _requestContentVariable : argument)
                    .ToList();
                expression.Update(arguments: rewrittenArguments);
                _requestContentVariable = null;
            }

            return base.VisitInvokeMethodExpression(expression, method);
        }

        private bool IsMultipartContentReference(ValueExpression argument)
            => argument is VariableExpression variable
                && ReferenceEquals(variable.Declaration, _multipartContentVariable!.Declaration);

        private static int FindMultipartContentDeclaration(IReadOnlyList<MethodBodyStatement> statements, out VariableExpression? multipartContent)
        {
            for (var i = 0; i < statements.Count; i++)
            {
                if (statements[i] is ExpressionStatement
                    {
                        Expression: AssignmentExpression
                        {
                            Variable: DeclarationExpression { Variable: { } contentVariable },
                            Value: InvokeMethodExpression { MethodName: "ToMultipartFormContent" }
                        }
                    })
                {
                    multipartContent = contentVariable;
                    return i;
                }
            }

            multipartContent = null;
            return -1;
        }
    }
}
