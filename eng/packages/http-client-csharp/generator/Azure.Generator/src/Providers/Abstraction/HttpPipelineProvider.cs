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
    /// <inheritdoc/>
    public record HttpPipelineProvider : ClientPipelineApi
    {
        private static ClientPipelineApi? _instance;
        internal static ClientPipelineApi Instance => _instance ??= new HttpPipelineProvider(Empty);

        /// <inheritdoc/>
        public HttpPipelineProvider(ValueExpression original) : base(typeof(HttpPipeline), original)
        {
        }

        /// <inheritdoc/>
        public override CSharpType ClientPipelineType => typeof(HttpPipeline);

        /// <inheritdoc/>
        public override CSharpType ClientPipelineOptionsType => typeof(ClientOptions);

        /// <inheritdoc/>
        public override CSharpType PipelinePolicyType => typeof(HttpPipelinePolicy);

        /// <inheritdoc/>
        public override CSharpType? KeyCredentialType => typeof(AzureKeyCredential);

        /// <inheritdoc/>
        public override CSharpType? TokenCredentialType => typeof(TokenCredential);

        /// <inheritdoc/>
        public override ValueExpression Create(ValueExpression options, ValueExpression perRetryPolicies)
            => Static(typeof(HttpPipelineBuilder)).Invoke(nameof(HttpPipelineBuilder.Build), [options, perRetryPolicies]);

        /// <inheritdoc/>
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
                InvokeCreateMessage(requestOptions, responseClassifier)
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

        /// <summary>
        /// The expression representing the HttpPipeline.CreateMessage invocation.
        /// </summary>
        public virtual ValueExpression InvokeCreateMessage(
            HttpRequestOptionsApi requestOptions,
            ValueExpression responseClassifier)
            => Original.Invoke(nameof(HttpPipeline.CreateMessage), requestOptions, responseClassifier);

        /// <inheritdoc/>
        public override ClientPipelineApi FromExpression(ValueExpression expression)
            => new HttpPipelineProvider(expression);

        /// <inheritdoc/>
        public override ValueExpression KeyAuthorizationPolicy(ValueExpression credential, ValueExpression headerName, ValueExpression? keyPrefix = null)
            => New.Instance(typeof(AzureKeyCredentialPolicy), keyPrefix != null ? [credential, headerName, keyPrefix] : [credential, headerName]);

        /// <inheritdoc/>
        public override ValueExpression TokenAuthorizationPolicy(ValueExpression credential, ValueExpression scopes)
            => New.Instance(typeof(BearerTokenAuthenticationPolicy), credential, scopes);

        /// <inheritdoc/>
        public override ClientPipelineApi ToExpression() => this;

        /// <inheritdoc/>
        public override MethodBodyStatement[] SendMessage(HttpMessageApi message, HttpRequestOptionsApi options)
            => BuildProcessMessage(message, options, false);

        /// <inheritdoc/>
        public override MethodBodyStatement[] SendMessageAsync(HttpMessageApi message, HttpRequestOptionsApi options)
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
                    ? Throw(AzureClientGenerator.Instance.TypeFactory.ClientResponseApi.ToExpression().CreateAsync(message.Response()))
                    : Throw(New.Instance(AzureClientGenerator.Instance.TypeFactory.ClientResponseApi.ClientResponseExceptionType, message.Response()))
                },
                MethodBodyStatement.EmptyLine,
                Return(message.Response())
            ];
        }
    }
}
