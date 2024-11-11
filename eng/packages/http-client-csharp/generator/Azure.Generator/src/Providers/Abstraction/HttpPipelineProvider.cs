// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Pipeline;
using Microsoft.Generator.CSharp.ClientModel.Providers;
using Microsoft.Generator.CSharp.Expressions;
using Microsoft.Generator.CSharp.Primitives;
using Microsoft.Generator.CSharp.Providers;
using Microsoft.Generator.CSharp.Snippets;
using Microsoft.Generator.CSharp.Statements;
using System.Threading;
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

        public override MethodBodyStatement[] ProcessMessage(HttpMessageApi message, HttpRequestOptionsApi options)
        {
            var userCacellationToken = new ParameterProvider("userCancellationToken", $"", new CSharpType(typeof(CancellationToken)));
            var statusOption = new ParameterProvider("statusOption", $"", new CSharpType(typeof(ErrorOptions)));
            return new MethodBodyStatement[]
            {
                new VariableTupleExpression(false, userCacellationToken, statusOption).Assign(options.Invoke("Parse")).Terminate(),
                Original.Invoke(nameof(HttpPipeline.Send), [message, userCacellationToken]).Terminate(),
                MethodBodyStatement.EmptyLine,
                new IfStatement(message.Response().IsError().And(new BinaryOperatorExpression("&", options.NullConditional().Property("ErrorOptions"), options.NoThrow()).NotEqual(options.NoThrow())))
                {
                    Throw(New.Instance(AzureClientPlugin.Instance.TypeFactory.ClientResponseApi.ClientResponseExceptionType, message.Response()))
                },
                MethodBodyStatement.EmptyLine,
                Return(message.Response())
            };
        }

        public override MethodBodyStatement[] ProcessMessageAsync(HttpMessageApi message, HttpRequestOptionsApi options)
        {
            var userCacellationToken = new ParameterProvider("userCancellationToken", $"", new CSharpType(typeof(CancellationToken)));
            var statusOption = new ParameterProvider("statusOption", $"", new CSharpType(typeof(ErrorOptions)));
            return new MethodBodyStatement[]
            {
                new VariableTupleExpression(false, userCacellationToken, statusOption).Assign(options.Invoke("Parse")).Terminate(),
                Original.Invoke(nameof(HttpPipeline.SendAsync), [message, userCacellationToken], true).Terminate(),
                MethodBodyStatement.EmptyLine,
                new IfStatement(message.Response().IsError().And(new BinaryOperatorExpression("&", options.NullConditional().Property("ErrorOptions"), options.NoThrow()).NotEqual(options.NoThrow())))
                {
                    Throw(AzureClientPlugin.Instance.TypeFactory.ClientResponseApi.ToExpression().CreateAsync(message.Response()))
                },
                MethodBodyStatement.EmptyLine,
                Return(message.Response())
            };
        }
    }
}
