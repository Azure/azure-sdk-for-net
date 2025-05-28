// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Azure.Generator.Management.Utilities;

namespace Azure.Generator.Management.Providers
{
    internal class UpdateOperationMethodProvider(
        ResourceClientProvider resourceClientProvider,
        InputServiceMethod method,
        MethodProvider convenienceMethod,
        bool isAsync) : ResourceOperationMethodProvider(resourceClientProvider, method, convenienceMethod, isAsync)
    {
        protected override MethodSignature CreateSignature()
        {
            return new MethodSignature(
                _isAsync ? "UpdateAsync" : "Update",
                $"Update a {_resourceClientProvider.SpecName}",
                _convenienceMethod.Signature.Modifiers,
                _serviceMethod.GetOperationMethodReturnType(_isAsync, _resourceClientProvider.ResourceClientCSharpType, _resourceClientProvider.ResourceData.Type),
                _convenienceMethod.Signature.ReturnDescription,
                GetOperationMethodParameters(_convenienceMethod, _serviceMethod.IsLongRunningOperation(), _resourceClientProvider.ImplicitParameterNames),
                _convenienceMethod.Signature.Attributes,
                _convenienceMethod.Signature.GenericArguments,
                _convenienceMethod.Signature.GenericParameterConstraints,
                _convenienceMethod.Signature.ExplicitInterface,
                _convenienceMethod.Signature.NonDocumentComment);
        }
    }
}
