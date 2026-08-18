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
        /// Whether a pruning-enabled ledger and a known pruned collection have been configured for
        /// archived-fallback recording.
        /// </summary>
        public bool IsPruningLedgerConfigured =>
            !string.IsNullOrEmpty(GetRecordedOptionalVariable("CONFIDENTIALLEDGER_PRUNING_URL")) &&
            !string.IsNullOrEmpty(GetRecordedOptionalVariable("CONFIDENTIALLEDGER_PRUNING_IDENTITY_URL")) &&
            !string.IsNullOrEmpty(GetRecordedOptionalVariable("CONFIDENTIALLEDGER_PRUNED_COLLECTION_ID"));

        /// <summary> The pruning-enabled ledger endpoint used by archived-fallback recorded tests. </summary>
        public Uri ConfidentialLedgerPruningUrl => new(GetRecordedVariable("CONFIDENTIALLEDGER_PRUNING_URL"));

        /// <summary> The Identity Service endpoint for the pruning-enabled ledger. </summary>
        public Uri ConfidentialLedgerPruningIdentityUrl => new(GetRecordedVariable("CONFIDENTIALLEDGER_PRUNING_IDENTITY_URL"));

        /// <summary> A collection known to have been removed from live state but retained in ledger history. </summary>
        public string ConfidentialLedgerPrunedCollectionId => GetRecordedVariable("CONFIDENTIALLEDGER_PRUNED_COLLECTION_ID");

        /// <summary>
        /// Whether a primary ledger, Identity Service endpoint, and secondary marker have been configured for
        /// cross-ledger failover recording.
        /// </summary>
        public bool IsFailoverLedgerConfigured =>
            !string.IsNullOrEmpty(GetRecordedOptionalVariable("CONFIDENTIALLEDGER_FAILOVER_PRIMARY_URL")) &&
            !string.IsNullOrEmpty(GetRecordedOptionalVariable("CONFIDENTIALLEDGER_FAILOVER_SECONDARY_URL")) &&
            !string.IsNullOrEmpty(GetRecordedOptionalVariable("CONFIDENTIALLEDGER_FAILOVER_IDENTITY_URL")) &&
            !string.IsNullOrEmpty(GetRecordedOptionalVariable("CONFIDENTIALLEDGER_FAILOVER_COLLECTION_ID")) &&
            !string.IsNullOrEmpty(GetRecordedOptionalVariable("CONFIDENTIALLEDGER_FAILOVER_EXPECTED_CONTENT"));

        /// <summary> The primary ledger endpoint used by the cross-ledger failover recorded test. </summary>
        public Uri ConfidentialLedgerFailoverPrimaryUrl => new(GetRecordedVariable("CONFIDENTIALLEDGER_FAILOVER_PRIMARY_URL"));

        /// <summary> The secondary ledger endpoint used by the cross-ledger failover recorded test. </summary>
        public Uri ConfidentialLedgerFailoverSecondaryUrl => new(GetRecordedVariable("CONFIDENTIALLEDGER_FAILOVER_SECONDARY_URL"));

        /// <summary> The Identity Service endpoint used to discover the secondary ledger. </summary>
        public Uri ConfidentialLedgerFailoverIdentityUrl => new(GetRecordedVariable("CONFIDENTIALLEDGER_FAILOVER_IDENTITY_URL"));

        /// <summary> The collection containing a distinguishable entry on the secondary ledger. </summary>
        public string ConfidentialLedgerFailoverCollectionId => GetRecordedVariable("CONFIDENTIALLEDGER_FAILOVER_COLLECTION_ID");

        /// <summary> The entry contents expected from the secondary ledger. </summary>
        public string ConfidentialLedgerFailoverExpectedContent => GetRecordedVariable("CONFIDENTIALLEDGER_FAILOVER_EXPECTED_CONTENT");

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
