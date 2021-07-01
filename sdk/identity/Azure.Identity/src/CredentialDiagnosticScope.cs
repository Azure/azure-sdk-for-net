// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Runtime.ExceptionServices;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Identity
{
    internal readonly struct CredentialDiagnosticScope : IDisposable
    {
        private readonly string _name;
        private readonly DiagnosticScope _scope;
        private readonly TokenRequestContext _context;
        private readonly IScopeHandler _scopeHandler;

        public CredentialDiagnosticScope(ClientDiagnostics diagnostics, string name, TokenRequestContext context, IScopeHandler scopeHandler)
        {
            _name = name;
            _scope = scopeHandler.CreateScope(diagnostics, name);
            _context = context;
            _scopeHandler = scopeHandler;
        }

        public void Start()
        {
            AzureIdentityEventSource.Singleton.GetToken(_name, _context);
            _scopeHandler.Start(_name, _scope);
        }

        public AccessToken Succeeded(AccessToken token)
        {
            AzureIdentityEventSource.Singleton.GetTokenSucceeded(_name, _context, token.ExpiresOn);
            return token;
        }

        public Exception FailWrapAndThrow(Exception ex)
        {
            var wrapped = TryWrapException(ref ex);
            RegisterFailed(ex);

            if (!wrapped)
            {
                ExceptionDispatchInfo.Capture(ex).Throw();
            }

            throw ex;
        }

        private void RegisterFailed(Exception ex)
        {
            AzureIdentityEventSource.Singleton.GetTokenFailed(_name, _context, ex);
            _scopeHandler.Fail(_name, _scope, ex);
        }

        private bool TryWrapException(ref Exception exception)
        {
            if (exception is OperationCanceledException || exception is AuthenticationFailedException)
            {
                return false;
            }

            if (exception is AggregateException aex)
            {
                CredentialUnavailableException firstCredentialUnavailable = aex.Flatten().InnerExceptions.OfType<CredentialUnavailableException>().FirstOrDefault();
                if (firstCredentialUnavailable != default)
                {
                    exception = new CredentialUnavailableException(firstCredentialUnavailable.Message, aex);
                    return true;
                }
            }

            exception = new AuthenticationFailedException($"{_name.Substring(0, _name.IndexOf('.'))} authentication failed: {exception.Message}", exception);
            return true;
        }

        public void Dispose() => _scopeHandler.Dispose(_name, _scope);
    }
}
