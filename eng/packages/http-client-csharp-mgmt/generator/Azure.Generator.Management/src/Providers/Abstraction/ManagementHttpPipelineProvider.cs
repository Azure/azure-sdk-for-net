// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Generator.Providers.Abstraction;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Snippets;
using Microsoft.TypeSpec.Generator.Statements;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

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
        public override MethodBodyStatement[] CreateMessage(
            HttpRequestOptionsApi requestOptions,
            ValueExpression uri,
            ScopedApi<string> method,
            ValueExpression responseClassifier,
            out HttpMessageApi message,
            out HttpRequestApi request)
        {
            var statements = base.CreateMessage(requestOptions, uri, method, responseClassifier, out message, out request);
            return [.. statements, This.Property("_userAgent").Invoke(nameof(TelemetryDetails.Apply), message).Terminate()];
        }

        /// <inheritdoc/>
        public override ClientPipelineApi FromExpression(ValueExpression expression)
            => new ManagementHttpPipelineProvider(expression);
    }
}
