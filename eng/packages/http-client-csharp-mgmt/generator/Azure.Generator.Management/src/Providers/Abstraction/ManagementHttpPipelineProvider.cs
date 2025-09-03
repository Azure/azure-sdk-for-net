// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Pipeline;
using Azure.Generator.Providers;
using Azure.Generator.Providers.Abstraction;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Expressions;
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

        public override MethodBodyStatement[] CreateMessage(
            HttpRequestOptionsApi requestOptions,
            ValueExpression uri,
            ScopedApi<string> method,
            ValueExpression responseClassifier,
            out HttpMessageApi message,
            out HttpRequestApi request)
        {
            var declareMessage = Declare(
                "message",
                Original.Invoke(nameof(HttpPipeline.CreateMessage))
                    .ToApi<HttpMessageApi>(),
                out message);
            var declareRequest = Declare("request", message.Request(), out request);
            var requestProvider = new HttpRequestProvider(request);

            return
            [
                declareMessage,
                declareRequest,
                requestProvider.SetUri(uri),
                requestProvider.SetMethod(method),
            ];
        }

        /// <inheritdoc/>
        public override ClientPipelineApi FromExpression(ValueExpression expression)
            => new ManagementHttpPipelineProvider(expression);
    }
}
