// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Pipeline;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Snippets;
using Microsoft.TypeSpec.Generator.Statements;
using System.Threading;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

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

        public override CSharpType? KeyCredentialType => typeof(AzureKeyCredential);

        public override CSharpType? TokenCredentialType => typeof(TokenCredential);

        public override ValueExpression Create(ValueExpression options, ValueExpression perRetryPolicies)
            => Static(typeof(HttpPipelineBuilder)).Invoke(nameof(HttpPipelineBuilder.Build), [options, perRetryPolicies]);

        public override ValueExpression CreateMessage(HttpRequestOptionsApi requestOptions, ValueExpression responseClassifier)
            => Original.Invoke(nameof(HttpPipeline.CreateMessage), requestOptions, responseClassifier).As<HttpMessage>();

        public override ClientPipelineApi FromExpression(ValueExpression expression)
            => new HttpPipelineProvider(expression);

        public override ValueExpression KeyAuthorizationPolicy(ValueExpression credential, ValueExpression headerName, ValueExpression? keyPrefix = null)
            => New.Instance(typeof(AzureKeyCredentialPolicy), keyPrefix != null ? [credential, headerName, keyPrefix] : [credential, headerName]);

        public override ValueExpression TokenAuthorizationPolicy(ValueExpression credential, ValueExpression scopes)
            => New.Instance(typeof(BearerTokenAuthenticationPolicy), credential, scopes);

        public override ClientPipelineApi ToExpression() => this;

        public override MethodBodyStatement[] ProcessMessage(HttpMessageApi message, HttpRequestOptionsApi options)
            => BuildProcessMessage(message, options, false);

        public override MethodBodyStatement[] ProcessMessageAsync(HttpMessageApi message, HttpRequestOptionsApi options)
            => BuildProcessMessage(message, options, true);

        private MethodBodyStatement[] BuildProcessMessage(HttpMessageApi message, HttpRequestOptionsApi options, bool isAsync)
        {
            var userCancellationToken = new ParameterProvider("userCancellationToken", $"", new CSharpType(typeof(CancellationToken)));
            var statusOption = new ParameterProvider("statusOption", $"", new CSharpType(typeof(ErrorOptions)));
            return
            [
                new VariableTupleExpression(false, userCancellationToken, statusOption).Assign(options.Invoke("Parse")).Terminate(),
                Original.Invoke(isAsync ? nameof(HttpPipeline.SendAsync) : nameof(HttpPipeline.Send), [message, userCancellationToken], isAsync).Terminate(),
                MethodBodyStatement.EmptyLine,
                new IfStatement(message.Response().IsError().And(new BinaryOperatorExpression("&", options.NullConditional().Property("ErrorOptions"), options.NoThrow()).NotEqual(options.NoThrow())))
                {
                    isAsync
                    ? Throw(AzureClientPlugin.Instance.TypeFactory.ClientResponseApi.ToExpression().CreateAsync(message.Response()))
                    : Throw(New.Instance(AzureClientPlugin.Instance.TypeFactory.ClientResponseApi.ClientResponseExceptionType, message.Response()))
                },
                MethodBodyStatement.EmptyLine,
                Return(message.Response())
            ];
        }
    }
}
