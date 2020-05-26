// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Runtime.ExceptionServices;
using Azure.Core;
using Azure.Core.Pipeline;
using Microsoft.Identity.Client;

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

        public Exception FailWrapAndThrow(Exception ex)
        {
            if (ex is OperationCanceledException || ex is AuthenticationFailedException)
            {
                var info = ExceptionDispatchInfo.Capture(ex);
                RegisterFailed(ex);
                info.Throw();
            }

            ex = new AuthenticationFailedException($"{_name.Substring(0, _name.IndexOf('.'))} authentication failed.", ex);
            RegisterFailed(ex);
            throw ex;
        }

        private void RegisterFailed(Exception ex)
        {
            AzureIdentityEventSource.Singleton.GetTokenFailed(_name, _context, ex);
            _scope.Failed(ex);
        }

        public void Dispose()
        {
            _scope.Dispose();
        }
    }
}
