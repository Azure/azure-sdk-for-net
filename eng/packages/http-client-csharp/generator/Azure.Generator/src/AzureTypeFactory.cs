// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Generator.Primitives;
using Azure.Generator.Providers;
using Azure.Generator.Providers.Abstraction;
using Microsoft.Generator.CSharp.ClientModel;
using Microsoft.Generator.CSharp.ClientModel.Providers;
using Microsoft.Generator.CSharp.Input;
using Microsoft.Generator.CSharp.Primitives;

namespace Azure.Generator
{
    /// <inheritdoc/>
    public class AzureTypeFactory : ScmTypeFactory
    {
        /// <inheritdoc/>
        public override CSharpType ClientUriBuilderBaseType => typeof(RequestUriBuilder);

        /// <inheritdoc/>
        public override IClientResponseApi ClientResponseApi => AzureClientResponseProvider.Instance;

        /// <inheritdoc/>
        public override IHttpResponseApi HttpResponseApi => AzureResponseProvider.Instance;

        /// <inheritdoc/>
        public override IClientPipelineApi ClientPipelineApi => HttpPipelineProvider.Instance;

        /// <inheritdoc/>
        public override IHttpMessageApi HttpMessageApi => HttpMessageProvider.Instance;

        /// <inheritdoc/>
        public override IHttpRequestApi HttpRequestApi => HttpRequestProvider.Instance;

        /// <inheritdoc/>
        public override IStatusCodeClassifierApi StatusCodeClassifierApi => StatusCodeClassifierProvider.Instance;

        /// <inheritdoc/>
        public override IRequestContentApi RequestContentApi => RequestContentProvider.Instance;

        /// <inheritdoc/>
        public override IHttpRequestOptionsApi HttpRequestOptionsApi => HttpRequestOptionsProvider.Instance;

        /// <inheritdoc/>
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
