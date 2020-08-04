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
            _scope.Failed(ex);
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

        public void Dispose()
        {
            _scope.Dispose();
        }
    }
}
