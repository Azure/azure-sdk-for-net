// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Identity;

namespace Azure.Storage.ConfidentialLedger.Tests
{
    public class ConfidentialLedgerTestBase
    {
        protected TokenCredential Credential;
        protected ConfidentialLedgerClientOptions Options;

        public ConfidentialLedgerTestBase()
        {
            Credential = new AzureCliCredential();

            var httpHandler = new HttpClientHandler();
            httpHandler.ServerCertificateCustomValidationCallback = (message, certificateToValidate, arg3, arg4) =>
            {
                var eccPem = File.ReadAllBytes("c:\\users\\chriss\\Downloads\\networkcert.pem");
                var authority = new X509Certificate2(eccPem);

                X509Chain chain = new();
                chain.ChainPolicy.RevocationMode = X509RevocationMode.NoCheck;
                chain.ChainPolicy.RevocationFlag = X509RevocationFlag.ExcludeRoot;
                chain.ChainPolicy.VerificationFlags = X509VerificationFlags.AllowUnknownCertificateAuthority;
                chain.ChainPolicy.VerificationTime = DateTime.Now;
                chain.ChainPolicy.UrlRetrievalTimeout = new TimeSpan(0, 0, 0);

// This part is very important. You're adding your known root here.
// It doesn't have to be in the computer store at all. Neither certificates do.
                chain.ChainPolicy.ExtraStore.Add(authority);

                bool isChainValid = chain.Build(certificateToValidate);
                var valid = chain.ChainElements
                    .Cast<X509ChainElement>()
                    .Any(x => x.Certificate.Thumbprint == authority.Thumbprint);

                return valid && isChainValid;
            };

            Options = new ConfidentialLedgerClientOptions() { Transport = new HttpClientTransport(httpHandler) };
        }
    }
}
