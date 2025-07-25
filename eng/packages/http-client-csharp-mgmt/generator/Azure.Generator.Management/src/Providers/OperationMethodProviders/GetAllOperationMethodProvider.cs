// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Models;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Statements;
using System;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Azure.Generator.Management.Providers.OperationMethodProviders
{
    internal class GetAllOperationMethodProvider(
        ResourceCollectionClientProvider collection,
        RestClientInfo restClientInfo,
        InputServiceMethod method,
        MethodProvider convenienceMethod,
        bool isAsync) : ResourceOperationMethodProvider(collection, collection.ContextualPath, restClientInfo, method, convenienceMethod, isAsync)
    {
        protected override MethodSignature CreateSignature()
        {
            var resourceType = _resource!.Type;
            var returnType = _isAsync
                ? new CSharpType(typeof(AsyncPageable<>), resourceType)
                : new CSharpType(typeof(Pageable<>), resourceType);

            return new MethodSignature(
            _isAsync ? "GetAllAsync" : "GetAll",
            _convenienceMethod.Signature.Description,
            _convenienceMethod.Signature.Modifiers,
            returnType,
            _convenienceMethod.Signature.ReturnDescription,
            GetOperationMethodParameters(),
            _convenienceMethod.Signature.Attributes,
            _convenienceMethod.Signature.GenericArguments,
            _convenienceMethod.Signature.GenericParameterConstraints,
            _convenienceMethod.Signature.ExplicitInterface,
            _convenienceMethod.Signature.NonDocumentComment);
        }

        protected override MethodBodyStatement[] BuildBodyStatements()
        {
            // TODO: implement paging method properly
            return [((KeywordExpression)ThrowExpression(New.Instance(typeof(NotImplementedException)))).Terminate()];
        }
    }
}