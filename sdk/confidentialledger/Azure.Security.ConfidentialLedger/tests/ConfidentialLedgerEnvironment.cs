// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Security.ConfidentialLedger.Certificate;
using NUnit.Framework;

namespace Azure.Security.ConfidentialLedger.Tests
{
    public class ConfidentialLedgerEnvironment : TestEnvironment
    {
        public Uri ConfidentialLedgerUrl => new(GetRecordedVariable("CONFIDENTIALLEDGER_URL"));
        public Uri ConfidentialLedgerIdentityUrl => new(GetRecordedVariable("CONFIDENTIALLEDGER_IDENTITY_URL"));

        /// <summary>
        /// Whether a Web Frontend Gateway endpoint has been configured via <c>CONFIDENTIALLEDGER_WEBFE_URL</c>.
        /// The WebFE recorded tests self-skip when this is <c>false</c> so they never run against a
        /// non-gateway ledger (for example in the live-test pipeline).
        /// </summary>
        public bool IsWebFrontendConfigured => !string.IsNullOrEmpty(GetRecordedOptionalVariable("CONFIDENTIALLEDGER_WEBFE_URL"));

        /// <summary>
        /// The Web Frontend Gateway endpoint used by the WebFE recorded tests
        /// (<c>CONFIDENTIALLEDGER_WEBFE_URL</c>). Guard with <see cref="IsWebFrontendConfigured"/> first.
        /// </summary>
        public Uri ConfidentialLedgerWebFrontendUrl => new(GetRecordedVariable("CONFIDENTIALLEDGER_WEBFE_URL"));

        public string ConfidentialLedgerAdminOid => GetRecordedVariable("CONFIDENTIALLEDGER_CLIENT_OBJECTID");
        public string ClientPEM => GetRecordedOptionalVariable("CONFIDENTIALLEDGER_CLIENT_PEM");
        public string ClientPEMPk => GetRecordedOptionalVariable("CONFIDENTIALLEDGER_CLIENT_PEM_PK");

        protected override async ValueTask<bool> IsEnvironmentReadyAsync()
        {
            try
            {
                var IdentityClient = new ConfidentialLedgerCertificateClient(ConfidentialLedgerIdentityUrl);
                var serviceCert = ConfidentialLedgerClient.GetIdentityServerTlsCert(ConfidentialLedgerUrl, new ConfidentialLedgerCertificateClientOptions(), IdentityClient);
                var client = new ConfidentialLedgerClient(
                       ConfidentialLedgerUrl,
                       credential: Credential,
                       clientCertificate: null,
                       identityServiceCert: serviceCert.Cert);
                var result = await client.GetEnclaveQuotesAsync(new());
                var stringResult = new StreamReader(result.ContentStream).ReadToEnd();

                return (int)HttpStatusCode.OK == result.Status;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"IsEnvironmentReadyAsync: {ex.Message}");
                return false;
            }
        }
    }
}
