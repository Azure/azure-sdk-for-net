// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Identity
{
    internal readonly struct CredentialDiagnosticScope : IDisposable
    {
        private readonly string _name;
        private readonly DiagnosticScope _scope;
        private readonly TokenRequestContext _context;

        public CredentialDiagnosticScope(string name, DiagnosticScope scope, TokenRequestContext context)
        {
            _name = name;

            _scope = scope;

            _context = context;
        }

        public void Start()
        {
            _scope.Start();
        }

        public AccessToken Succeeded(AccessToken token)
        {
            AzureIdentityEventSource.Singleton.GetTokenSucceeded(_name, _context, token.ExpiresOn);

            return token;
        }

        public AuthenticationFailedException Failed(string message)
        {
            var exception = new AuthenticationFailedException(message);

            AzureIdentityEventSource.Singleton.GetTokenFailed(_name, _context, exception);

            _scope.Failed(exception);

            return exception;
        }

        public AuthenticationFailedException Failed(Exception ex)
        {
            if (!(ex is AuthenticationFailedException))
            {
                ex = new AuthenticationFailedException(Constants.AuthenticationUnhandledExceptionMessage, ex);
            }

            AzureIdentityEventSource.Singleton.GetTokenFailed(_name, _context, ex);

            _scope.Failed(ex);

            return (AuthenticationFailedException)ex;
        }

        public void Dispose()
        {
            _scope.Dispose();
        }
    }
}
