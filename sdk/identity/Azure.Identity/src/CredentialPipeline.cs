// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Azure.Core;
using Azure.Core.Diagnostics;
using Azure.Core.Pipeline;
using Microsoft.Identity.Client;

namespace Azure.Identity
{
   internal class CredentialPipeline
    {
        private static readonly Lazy<CredentialPipeline> s_singleton = new Lazy<CredentialPipeline>(() => new CredentialPipeline(new TokenCredentialOptions()));

        private static readonly AsyncLocal<IScopeHandler> s_scopeHandler = new AsyncLocal<IScopeHandler>();

        private readonly ScopeHandler _defaultScopeHandler;

        private CredentialPipeline(TokenCredentialOptions options)
        {
            AuthorityHost = options.AuthorityHost;

            HttpPipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), Array.Empty<HttpPipelinePolicy>(), new CredentialResponseClassifier());

            Diagnostics = new ClientDiagnostics(options);

            _defaultScopeHandler = new ScopeHandler(Diagnostics);
        }

        public static CredentialPipeline GetInstance(TokenCredentialOptions options)
        {
            return options is null ? s_singleton.Value : new CredentialPipeline(options);
        }

        public Uri AuthorityHost { get; }

        public HttpPipeline HttpPipeline { get; }

        public ClientDiagnostics Diagnostics { get; }

        public IConfidentialClientApplication CreateMsalConfidentialClient(string tenantId, string clientId, string clientSecret)
        {
            return ConfidentialClientApplicationBuilder.Create(clientId).WithHttpClientFactory(new HttpPipelineClientFactory(HttpPipeline)).WithTenantId(tenantId).WithClientSecret(clientSecret).Build();
        }

        public CredentialDiagnosticScope StartGetTokenScope(string fullyQualifiedMethod, TokenRequestContext context)
        {
            IScopeHandler scopeHandler = s_scopeHandler.Value ?? _defaultScopeHandler;

            CredentialDiagnosticScope scope = new CredentialDiagnosticScope(fullyQualifiedMethod, context, scopeHandler);
            scope.Start();
            return scope;
        }

        public CredentialDiagnosticScope StartGetTokenScopeGroup(string fullyQualifiedMethod, TokenRequestContext context)
        {
            var scopeHandler = new ScopeGroupHandler(Diagnostics, fullyQualifiedMethod);

            CredentialDiagnosticScope scope = new CredentialDiagnosticScope(fullyQualifiedMethod, context, scopeHandler);
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
            private readonly ClientDiagnostics _diagnostics;

            public ScopeHandler(ClientDiagnostics diagnostics)
            {
                _diagnostics = diagnostics;
            }

            public DiagnosticScope CreateScope(string name) => _diagnostics.CreateScope(name);
            public void Start(string name, in DiagnosticScope scope) => scope.Start();
            public void Dispose(string name, in DiagnosticScope scope) => scope.Dispose();
            public void Fail(string name, in DiagnosticScope scope, Exception exception) => scope.Failed(exception);
        }

        private class ScopeGroupHandler : IScopeHandler
        {
            private readonly ClientDiagnostics _diagnostics;
            private readonly string _groupName;
            private Dictionary<string, (DateTime StartDateTime, Exception Exception)> _childScopes;

            public ScopeGroupHandler(ClientDiagnostics diagnostics, string groupName)
            {
                _diagnostics = diagnostics;
                _groupName = groupName;
            }

            public DiagnosticScope CreateScope(string name)
            {
                if (IsGroup(name))
                {
                    s_scopeHandler.Value = this;
                    return _diagnostics.CreateScope(name);
                }

                _childScopes ??= new Dictionary<string, (DateTime startDateTime, Exception exception)>();
                _childScopes[name] = default;
                return default;
            }

            public void Start(string name, in DiagnosticScope scope)
            {
                if (IsGroup(name))
                {
                    scope.Start();
                }
                else
                {
                    _childScopes[name] = (DateTimeHelpers.GetUtcNow(), default);
                }
            }

            public void Dispose(string name, in DiagnosticScope scope)
            {
                if (!IsGroup(name))
                {
                    return;
                }

                var succeededScope = _childScopes.LastOrDefault(kvp => kvp.Value.Exception == default);
                if (succeededScope.Key != default)
                {
                    SucceedChildScope(succeededScope.Key, succeededScope.Value.StartDateTime);
                }

                scope.Dispose();
                s_scopeHandler.Value = default;
            }

            public void Fail(string name, in DiagnosticScope scope, Exception exception)
            {
                if (IsGroup(name))
                {
                    if (exception is OperationCanceledException)
                    {
                        var canceledScope = _childScopes.Last(kvp => kvp.Value.Exception == exception);
                        FailChildScope(canceledScope.Key, canceledScope.Value.StartDateTime, canceledScope.Value.Exception);
                    }
                    else
                    {
                        foreach (var childScope in _childScopes)
                        {
                            FailChildScope(childScope.Key, childScope.Value.StartDateTime, childScope.Value.Exception);
                        }
                    }
                    scope.Failed(exception);
                }
                else
                {
                    _childScopes[name] = (_childScopes[name].StartDateTime, exception);
                }
            }

            private void SucceedChildScope(string name, DateTime dateTime)
            {
                using DiagnosticScope scope = _diagnostics.CreateScope(name);
                scope.SetStartTime(dateTime);
                scope.Start();
            }

            private void FailChildScope(string name, DateTime dateTime, Exception exception)
            {
                using DiagnosticScope scope = _diagnostics.CreateScope(name);
                scope.SetStartTime(dateTime);
                scope.Start();
                scope.Failed(exception);
            }

            private bool IsGroup(string name) => string.Equals(name, _groupName, StringComparison.Ordinal);
        }
    }
}
