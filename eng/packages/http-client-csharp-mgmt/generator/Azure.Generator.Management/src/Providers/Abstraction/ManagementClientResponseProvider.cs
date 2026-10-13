// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;

namespace Azure.Generator.Management.Providers.Abstraction
{
    // Delegate response handling to the Azure provider, changing only management paging helper names.
    internal sealed class ManagementClientResponseProvider(IClientResponseApi inner) : IClientResponseApi
    {
        public CSharpType ClientResponseExceptionType => inner.ClientResponseExceptionType;
        public CSharpType ClientResponseType => inner.ClientResponseType;
        public CSharpType ClientResponseOfTType => inner.ClientResponseOfTType;
        public CSharpType ClientCollectionResponseType => inner.ClientCollectionResponseType;
        public CSharpType ClientCollectionAsyncResponseType => inner.ClientCollectionAsyncResponseType;
        public CSharpType ClientCollectionResponseOfTType => inner.ClientCollectionResponseOfTType;
        public CSharpType ClientCollectionAsyncResponseOfTType => inner.ClientCollectionAsyncResponseOfTType;
        public string ResponseParameterName => inner.ResponseParameterName;

        public ClientResponseApi FromExpression(ValueExpression original) => inner.FromExpression(original);
        public ClientResponseApi ToExpression() => inner.ToExpression();

        public TypeProvider CreateClientCollectionResultDefinition(ClientProvider client, InputPagingServiceMethod serviceMethod, CSharpType? type, bool isAsync)
        {
            var helper = inner.CreateClientCollectionResultDefinition(client, serviceMethod, type, isAsync);
            // Keep explicit package customizations and existing hand-written helper references.
            var library = ManagementClientGenerator.Instance.OutputLibrary;
            var customizedName = helper.CustomCodeView is not null || library.IsCollectionResultReferencedByCustomization(helper) ? helper.Name : null;
            var name = library.GetRegularCollectionResultName(client, serviceMethod.Operation, type, isAsync, helper.Name, customizedName);
            if (customizedName is not null)
            {
                return helper;
            }

            library.RegisterRegularCollectionResultName(helper, name);
            return helper;
        }
    }
}
