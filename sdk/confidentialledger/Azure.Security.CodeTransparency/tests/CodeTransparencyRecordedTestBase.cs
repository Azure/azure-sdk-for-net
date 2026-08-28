// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Azure.Core.TestFramework.Models;
using NUnit.Framework;

namespace Azure.Security.CodeTransparency.Tests
{
    public class CodeTransparencyRecordedTestBase : RecordedTestBase<CodeTransparencyTestEnvironment>
    {
        protected CodeTransparencyClient Client { get; private set; }

        public CodeTransparencyRecordedTestBase(bool isAsync) : base(isAsync)
        {
            // Code Transparency exchanges binary COSE/CBOR payloads, not JSON.
            TestDiagnostics = false;
        }

        [SetUp]
        public async Task Setup()
        {
            var options = InstrumentClientOptions(new CodeTransparencyClientOptions());

            if (Mode == RecordedTestMode.Playback)
            {
                // In Playback mode, skip TLS cert download by using the internal
                // constructor that doesn't call CreateTlsCertAndTrustVerifier.
                Client = InstrumentClient(
                    new CodeTransparencyClient(
                        authenticationPolicy: null,
                        TestEnvironment.Endpoint,
                        options));
            }
            else
            {
                // In Live/Record mode, use the full constructor with TLS cert download.
                string identityEndpoint = TestEnvironment.IdentityClientEndpoint;
                if (!string.IsNullOrEmpty(identityEndpoint))
                {
                    options.IdentityClientEndpoint = identityEndpoint;
                }

                // Fetch TLS cert and configure the test proxy to trust it (for Record mode).
                var certClient = new CodeTransparencyCertificateClient(
                    new Uri(options.IdentityClientEndpoint));
                string ledgerName = TestEnvironment.Endpoint.Host.Split('.')[0];
                var certResponse = certClient.GetServiceIdentity(ledgerName);
                string pem = certResponse.Value.TlsCertificatePem;

                if (Mode == RecordedTestMode.Record && !string.IsNullOrEmpty(pem))
                {
                    await SetProxyOptionsAsync(new ProxyOptions
                    {
                        Transport = new ProxyOptionsTransport
                        {
                            TLSValidationCert = pem,
                            AllowAutoRedirect = false
                        }
                    });
                }

                Client = InstrumentClient(
                    new CodeTransparencyClient(
                        TestEnvironment.Endpoint,
                        options));
            }
        }
    }
}
