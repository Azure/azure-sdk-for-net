// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Providers;
using Microsoft.Generator.CSharp.ClientModel;
using Microsoft.Generator.CSharp.ClientModel.Providers;
using Microsoft.Generator.CSharp.Expressions;
using Microsoft.Generator.CSharp.Primitives;

namespace Azure.Generator
{
    /// <inheritdoc/>
    public class AzureTypeFactory : ScmTypeFactory
    {
        /// <inheritdoc/>
        public override CSharpType ClientResponseExceptionType => typeof(RequestFailedException);

        /// <inheritdoc/>
        public override CSharpType ClientResponseType => typeof(Response);

        /// <inheritdoc/>
        public override CSharpType ClientResponseOfTType => typeof(Response<>);

        /// <inheritdoc/>
        public override CSharpType HttpResponseType => typeof(Response);

        /// <inheritdoc/>
        public override ClientResponseApi CreateClientResponse(ValueExpression original) => new AzureClientResponseProvider(original.As<Response>());

        /// <inheritdoc/>
        public override HttpResponseApi CreateHttpResponse(ValueExpression original) => new AzureResponseProvider(original.As<Response>());
    }
}
