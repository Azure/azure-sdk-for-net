// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Pipeline;
using Azure.Generator.Providers.Abstraction;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Expressions;

namespace Azure.Generator.Management.Providers.Abstraction
{
    internal record MgmtHttpPipelineProvider : HttpPipelineProvider
    {
        private static ClientPipelineApi? _instance;
        internal static ClientPipelineApi Instance => _instance ??= new MgmtHttpPipelineProvider(Empty);

        protected MgmtHttpPipelineProvider(ValueExpression original) : base(original)
        {
        }

        public override ValueExpression CreateMessage(HttpRequestOptionsApi requestOptions, ValueExpression responseClassifier)
            => Original.Invoke(nameof(HttpPipeline.CreateMessage));

        /// <inheritdoc/>
        public override ClientPipelineApi FromExpression(ValueExpression expression)
            => new MgmtHttpPipelineProvider(expression);
    }
}
