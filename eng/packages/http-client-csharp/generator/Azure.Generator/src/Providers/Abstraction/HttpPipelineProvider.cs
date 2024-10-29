// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Pipeline;
using Microsoft.Generator.CSharp.ClientModel.Providers;
using Microsoft.Generator.CSharp.Expressions;
using Microsoft.Generator.CSharp.Primitives;
using Microsoft.Generator.CSharp.Statements;
using static Microsoft.Generator.CSharp.Snippets.Snippet;

namespace Azure.Generator.Providers.Abstraction
{
    internal record HttpPipelineProvider : ClientPipelineApi
    {
        private static ClientPipelineApi? _instance;
        internal static ClientPipelineApi Instance => _instance ??= new HttpPipelineProvider(Empty);

        public HttpPipelineProvider(ValueExpression original) : base(typeof(HttpPipeline), original)
        {
        }

        public override CSharpType ClientPipelineType => typeof(HttpPipeline);

        public override CSharpType ClientPipelineOptionsType => typeof(ClientOptions);

        public override CSharpType PipelinePolicyType => typeof(HttpPipelinePolicy);

        public override ValueExpression Create(ValueExpression options, ValueExpression perRetryPolicies)
            => Static(typeof(HttpPipelineBuilder)).Invoke(nameof(HttpPipelineBuilder.Build), [options, perRetryPolicies]);

        public override ValueExpression CreateMessage(HttpRequestOptionsApi requestOptions, ValueExpression responseClassifier)
            => Original.Invoke(nameof(HttpPipeline.CreateMessage), requestOptions, responseClassifier).As<HttpMessage>();

        public override ClientPipelineApi FromExpression(ValueExpression expression)
            => new HttpPipelineProvider(expression);

        public override ValueExpression PerRetryPolicy(params ValueExpression[] arguments)
            => Empty; // TODO: implement with default retry policy for Azure

        public override ClientPipelineApi ToExpression() => this;

        public override MethodBodyStatement Send(HttpMessageApi message, HttpRequestOptionsApi options)
            => Original.Invoke(nameof(HttpPipeline.Send), [message, options.Property(nameof(RequestContext.CancellationToken))]).Terminate();

        public override MethodBodyStatement SendAsync(HttpMessageApi message, HttpRequestOptionsApi options)
            => Original.Invoke(nameof(HttpPipeline.SendAsync), [message, options.Property(nameof(RequestContext.CancellationToken))], true).Terminate();
    }
}
