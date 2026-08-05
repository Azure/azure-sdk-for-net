// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;

namespace Azure.Security.ConfidentialLedger.Tests
{
    public class ConfidentialLedgerEnvironment : TestEnvironment
    {
        public Uri ConfidentialLedgerUrl => new(GetRecordedVariable("CONFIDENTIALLEDGER_URL"));
        public Uri ConfidentialLedgerIdentityUrl => new(GetRecordedVariable("CONFIDENTIALLEDGER_IDENTITY_URL"));

        /// <summary>
        /// Whether a Ledger Gateway endpoint has been configured via <c>CONFIDENTIALLEDGER_WEBFE_URL</c>.
        /// The Ledger Gateway recorded tests self-skip when this is <c>false</c> so they never run against a
        /// non-gateway ledger (for example in the live-test pipeline).
        /// </summary>
        public bool IsLedgerGatewayConfigured => !string.IsNullOrEmpty(GetRecordedOptionalVariable("CONFIDENTIALLEDGER_WEBFE_URL"));

        /// <summary>
        /// The Ledger Gateway endpoint used by the gateway recorded tests
        /// (<c>CONFIDENTIALLEDGER_WEBFE_URL</c>). Guard with <see cref="IsLedgerGatewayConfigured"/> first.
        /// </summary>
        public Uri ConfidentialLedgerGatewayUrl => new(GetRecordedVariable("CONFIDENTIALLEDGER_WEBFE_URL"));

        /// <summary>
        /// A Ledger Gateway operation id captured from a write that was queued while CCF was offline
        /// (<c>CONFIDENTIALLEDGER_WEBFE_OPERATION_ID</c>). The resume-to-committed recorded test polls this
        /// existing operation to completion after the ledger recovers. Empty when not configured.
        /// </summary>
        public string LedgerGatewayQueuedOperationId => GetRecordedOptionalVariable("CONFIDENTIALLEDGER_WEBFE_OPERATION_ID");

        public string ConfidentialLedgerAdminOid => GetRecordedVariable("CONFIDENTIALLEDGER_CLIENT_OBJECTID");
        public string ClientPEM => GetRecordedOptionalVariable("CONFIDENTIALLEDGER_CLIENT_PEM");
        public string ClientPEMPk => GetRecordedOptionalVariable("CONFIDENTIALLEDGER_CLIENT_PEM_PK");
    }
}
