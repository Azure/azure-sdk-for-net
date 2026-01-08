// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Pipeline;
using Azure.Generator.Providers.Abstraction;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Expressions;

namespace Azure.Generator.Management.Providers.Abstraction
{
    internal record ManagementHttpPipelineProvider : HttpPipelineProvider
    {
        private static ClientPipelineApi? _instance;
        internal static ClientPipelineApi Instance => _instance ??= new ManagementHttpPipelineProvider(Empty);

        protected ManagementHttpPipelineProvider(ValueExpression original) : base(original)
        {
        }

        public override ValueExpression InvokeCreateMessage(HttpRequestOptionsApi requestOptions, ValueExpression responseClassifier)
            => Original.Invoke(nameof(HttpPipeline.CreateMessage));

        /// <inheritdoc/>
        public override ClientPipelineApi FromExpression(ValueExpression expression)
            => new ManagementHttpPipelineProvider(expression);
    }
}
