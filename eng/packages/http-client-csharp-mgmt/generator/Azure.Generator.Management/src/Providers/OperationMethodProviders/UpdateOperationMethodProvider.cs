// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Azure.Generator.Management.Utilities;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;

namespace Azure.Generator.Management.Providers.OperationMethodProviders
{
    internal class UpdateOperationMethodProvider(
        ResourceClientProvider resource,
        ClientProvider restClient,
        InputServiceMethod method,
        MethodProvider convenienceMethod,
        FieldProvider clientDiagnosticsField,
        FieldProvider restClientField,
        bool isAsync) : ResourceOperationMethodProvider(resource, resource, restClient, method, convenienceMethod, clientDiagnosticsField, restClientField, isAsync)
    {
        protected override MethodSignature CreateSignature()
        {
            return new MethodSignature(
                _isAsync ? "UpdateAsync" : "Update",
                $"Update a {_resource.ResourceName}",
                _convenienceMethod.Signature.Modifiers,
                _serviceMethod.GetOperationMethodReturnType(_isAsync, _resource.Type, _resource.ResourceData.Type),
                _convenienceMethod.Signature.ReturnDescription,
                GetOperationMethodParameters(),
                _convenienceMethod.Signature.Attributes,
                _convenienceMethod.Signature.GenericArguments,
                _convenienceMethod.Signature.GenericParameterConstraints,
                _convenienceMethod.Signature.ExplicitInterface,
                _convenienceMethod.Signature.NonDocumentComment);
        }
    }
}
