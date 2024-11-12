// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Core.Pipeline;
using Microsoft.Identity.Client;

namespace Azure.Identity
{
    internal class CredentialPipeline
    {
        private static readonly Lazy<CredentialPipeline> s_singleton = new Lazy<CredentialPipeline>(() => new CredentialPipeline(new TokenCredentialOptions()));

        private static readonly IScopeHandler _defaultScopeHandler = new ScopeHandler();

        private CredentialPipeline(TokenCredentialOptions options)
        {
            HttpPipeline = HttpPipelineBuilder.Build(new HttpPipelineOptions(options) { RequestFailedDetailsParser = new ManagedIdentityRequestFailedDetailsParser() });
            Diagnostics = new ClientDiagnostics(options);
        }

        public CredentialPipeline(HttpPipeline httpPipeline, ClientDiagnostics diagnostics)
        {
            HttpPipeline = httpPipeline;
            Diagnostics = diagnostics;
        }

        public static CredentialPipeline GetInstance(TokenCredentialOptions options, bool IsManagedIdentityCredential = false)
        {
            return options switch
            {
                _ when IsManagedIdentityCredential => configureOptionsForManagedIdentity(options),
                not null => new CredentialPipeline(options),
                _ => s_singleton.Value,

            };
        }

        private static CredentialPipeline configureOptionsForManagedIdentity(TokenCredentialOptions options)
        {
            var clonedOptions = options switch
            {
                DefaultAzureCredentialOptions dac => dac.Clone<DefaultAzureCredentialOptions>(),
                _ => options?.Clone<TokenCredentialOptions>() ?? new TokenCredentialOptions(),
            };
            // Set the custom retry policy
            clonedOptions.Retry.MaxRetries = 5;
            clonedOptions.RetryPolicy ??= new DefaultAzureCredentialImdsRetryPolicy(clonedOptions.Retry);
            clonedOptions.IsChainedCredential = clonedOptions is DefaultAzureCredentialOptions;
            return new CredentialPipeline(clonedOptions);
        }

        public HttpPipeline HttpPipeline { get; }

        public ClientDiagnostics Diagnostics { get; }

        public IConfidentialClientApplication CreateMsalConfidentialClient(string tenantId, string clientId, string clientSecret)
        {
            return ConfidentialClientApplicationBuilder.Create(clientId).WithHttpClientFactory(new HttpPipelineClientFactory(HttpPipeline)).WithTenantId(tenantId).WithClientSecret(clientSecret).Build();
        }

        public CredentialDiagnosticScope StartGetTokenScope(string fullyQualifiedMethod, TokenRequestContext context)
        {
            IScopeHandler scopeHandler = ScopeGroupHandler.Current ?? _defaultScopeHandler;

            CredentialDiagnosticScope scope = new CredentialDiagnosticScope(Diagnostics, fullyQualifiedMethod, context, scopeHandler);
            scope.Start();
            return scope;
        }
        public CredentialDiagnosticScope StartGetTokenScopeGroup(string fullyQualifiedMethod, TokenRequestContext context)
        {
            var scopeHandler = new ScopeGroupHandler(fullyQualifiedMethod);

            CredentialDiagnosticScope scope = new CredentialDiagnosticScope(Diagnostics, fullyQualifiedMethod, context, scopeHandler);
            scope.Start();
            return scope;
        }

        private class CredentialResponseClassifier : ResponseClassifier
        {
            public override bool IsRetriableResponse(HttpMessage message)
            {
                return base.IsRetriableResponse(message) || message.Response.Status == 404;
            }
        }

        private class ScopeHandler : IScopeHandler
        {
            public DiagnosticScope CreateScope(ClientDiagnostics diagnostics, string name) => diagnostics.CreateScope(name);
            public void Start(string name, in DiagnosticScope scope) => scope.Start();
            public void Dispose(string name, in DiagnosticScope scope) => scope.Dispose();
            public void Fail(string name, in DiagnosticScope scope, Exception exception) => scope.Failed(exception);
        }
    }
}
