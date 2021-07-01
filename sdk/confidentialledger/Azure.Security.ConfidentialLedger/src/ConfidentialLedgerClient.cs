// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Security.ConfidentialLedger
{
    public partial class ConfidentialLedgerClient
    {
        /// <summary> A sub-ledger id may optionally be specified. </summary>
        /// <remarks>
        /// Schema for <c>Request Body</c>:
        /// <list type="table">
        ///   <listheader>
        ///     <term>Name</term>
        ///     <term>Type</term>
        ///     <term>Required</term>
        ///     <term>Description</term>
        ///   </listheader>
        ///   <item>
        ///     <term>contents</term>
        ///     <term>string</term>
        ///     <term>Yes</term>
        ///     <term> Contents of the ledger entry. </term>
        ///   </item>
        ///   <item>
        ///     <term>subLedgerId</term>
        ///     <term>string</term>
        ///     <term></term>
        ///     <term> Identifier for sub-ledgers. </term>
        ///   </item>
        ///   <item>
        ///     <term>transactionId</term>
        ///     <term>string</term>
        ///     <term></term>
        ///     <term> A unique identifier for the state of the ledger. If returned as part of a LedgerEntry, it indicates the state from which the entry was read. </term>
        ///   </item>
        /// </list>
        /// </remarks>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="subLedgerId"> The sub-ledger id. </param>
        /// <param name="waitForCompletion"> If <c>true</c>, the <see cref="PostLedgerEntryOperation"/> will not be returned until the ledger entry is committed.
        /// If <c>false</c>, <see cref="PostLedgerEntryOperation.Wai"/></param>
        /// <param name="options"> The request options. </param>
#pragma warning disable AZC0002
        public virtual PostLedgerEntryOperation PostLedgerEntry(RequestContent content, string subLedgerId = null, bool waitForCompletion = true , RequestOptions options = null)
#pragma warning restore AZC0002
        {
            var response = PostLedgerEntry(content, subLedgerId, options);

        }
    }
}
