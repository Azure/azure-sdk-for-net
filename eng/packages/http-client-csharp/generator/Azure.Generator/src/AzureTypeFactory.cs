// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Primitives;
using Azure.Generator.Providers;
using Microsoft.Generator.CSharp.ClientModel;
using Microsoft.Generator.CSharp.ClientModel.Providers;
using Microsoft.Generator.CSharp.Expressions;
using Microsoft.Generator.CSharp.Input;
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

        protected override CSharpType? CreateCSharpTypeCore(InputType inputType)
        {
            if (inputType is InputPrimitiveType inputPrimitiveType)
            {
                var result = CreateKnownPrimitiveType(inputPrimitiveType);
                if (result != null)
                {
                    return result;
                }
            }
            return base.CreateCSharpTypeCore(inputType);
        }

        private CSharpType? CreateKnownPrimitiveType(InputPrimitiveType inputType)
        {
            InputPrimitiveType? primitiveType = inputType;
            while (primitiveType != null)
            {
                if (KnownAzureTypes.PrimitiveTypes.TryGetValue(primitiveType.CrossLanguageDefinitionId, out var knownType))
                {
                    return knownType;
                }

                primitiveType = primitiveType.BaseType;
            }

            return null;
        }
    }
}
