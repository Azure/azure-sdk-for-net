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

        public AuthenticationFailedException FailAndWrap(Exception ex)
        {
            if (!(ex is AuthenticationFailedException))
            {
                ex = new AuthenticationFailedException($"{_name.Substring(0, _name.IndexOf('.'))} authentication failed.", ex);
            }

            return (AuthenticationFailedException)Failed(ex);
        }


        public Exception Failed(Exception ex)
        {
            AzureIdentityEventSource.Singleton.GetTokenFailed(_name, _context, ex);

            _scope.Failed(ex);

            return ex;
        }


        public void Dispose()
        {
            _scope.Dispose();
        }
    }
}
