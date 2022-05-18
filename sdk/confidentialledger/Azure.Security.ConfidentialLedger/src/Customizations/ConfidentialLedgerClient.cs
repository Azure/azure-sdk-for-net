// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Security.ConfidentialLedger.Models;

namespace Azure.Security.ConfidentialLedger
{
    /// <summary> The ConfidentialLedger service client. </summary>
    public partial class ConfidentialLedgerClient
    {
        /// <summary> LedgerCollection ids are user-created collections of ledger entries. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<IReadOnlyList<LedgerCollection>>> GetCollectionsValueAsync(CancellationToken cancellationToken = default)
        {
            Response response = await GetCollectionsAsync(new RequestContext { CancellationToken = cancellationToken }).ConfigureAwait(false);
            using var document = JsonDocument.Parse(response.ContentStream);

            IReadOnlyList<LedgerCollection> value = default;
            List<LedgerCollection> array = new List<LedgerCollection>();

            foreach (var item in document.RootElement.EnumerateArray())
            {
                array.Add(LedgerCollection.DeserializeCollection(item));
            }

            value = array;
            return Response.FromValue(value, response);
        }

        /// <summary> LedgerCollection ids are user-created collections of ledger entries. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<IReadOnlyList<LedgerCollection>> GetCollectionsValue(CancellationToken cancellationToken = default)
        {
            Response response = GetCollections(new RequestContext { CancellationToken = cancellationToken });
            using var document = JsonDocument.Parse(response.ContentStream);

            IReadOnlyList<LedgerCollection> value = default;
            List<LedgerCollection> array = new List<LedgerCollection>();

            foreach (var item in document.RootElement.EnumerateArray())
            {
                array.Add(LedgerCollection.DeserializeCollection(item));
            }

            value = array;
            return Response.FromValue(value, response);
        }

        /// <summary> The constitution is a script that assesses and applies proposals from consortium members. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<LedgerConstitution>> GetConstitutionValueAsync(CancellationToken cancellationToken = default)
        {
            Response response = await GetConstitutionAsync(new RequestContext { CancellationToken = cancellationToken }).ConfigureAwait(false);

            LedgerConstitution constitution = LedgerConstitution.FromResponse(response);

            return Response.FromValue(constitution, response);
        }

        /// <summary> The constitution is a script that assesses and applies proposals from consortium members. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<LedgerConstitution> GetConstitutionValue(CancellationToken cancellationToken = default)
        {
            Response response = GetConstitution(new RequestContext { CancellationToken = cancellationToken });

            LedgerConstitution constitution = LedgerConstitution.FromResponse(response);

            return Response.FromValue(constitution, response);
        }

        /// <summary> Gets the status of an entry identified by a transaction id. </summary>
        /// <param name="transactionId"> Identifies a write transaction. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="transactionId"/> is null. </exception>

        public virtual async Task<Response<TransactionReceipt>> GetReceiptValueAsync(string transactionId, CancellationToken cancellationToken = default)
        {
            Response response = await GetReceiptAsync(transactionId, new RequestContext { CancellationToken = cancellationToken }).ConfigureAwait(false);

            TransactionReceipt value = TransactionReceipt.FromResponse(response);

            return Response.FromValue(value, response);
        }

        /// <summary> Gets the status of an entry identified by a transaction id. </summary>
        /// <param name="transactionId"> Identifies a write transaction. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="transactionId"/> is null. </exception>
        public virtual Response<TransactionReceipt> GetReceiptValue(string transactionId, CancellationToken cancellationToken = default)
        {
            Response response = GetReceipt(transactionId, new RequestContext { CancellationToken = cancellationToken });

            TransactionReceipt value = TransactionReceipt.FromResponse(response);

            return Response.FromValue(value, response);
        }

        /// <summary> A collection id may optionally be specified. Only entries in the specified (or default) collection will be returned. </summary>
        /// <param name="collectionId"> The collection id. </param>
        /// <param name="fromTransactionId"> Specify the first transaction ID in a range. </param>
        /// <param name="toTransactionId"> Specify the last transaction ID in a range. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        public virtual AsyncPageable<LedgerEntry> GetLedgerEntriesValueAsync(string collectionId = null, string fromTransactionId = null, string toTransactionId = null, CancellationToken cancellationToken = default)
        {
            AsyncPageable<BinaryData> pageableBinaryData = GetLedgerEntriesAsync(collectionId, fromTransactionId, toTransactionId, new RequestContext{ CancellationToken = cancellationToken});

            return PageableHelpers.Select(pageableBinaryData, response => PagedLedgerEntries.FromResponse(response).Entries);
        }

        /// <summary> A collection id may optionally be specified. Only entries in the specified (or default) collection will be returned. </summary>
        /// <param name="collectionId"> The collection id. </param>
        /// <param name="fromTransactionId"> Specify the first transaction ID in a range. </param>
        /// <param name="toTransactionId"> Specify the last transaction ID in a range. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        public virtual Pageable<LedgerEntry> GetLedgerEntriesValue(string collectionId = null, string fromTransactionId = null, string toTransactionId = null, CancellationToken cancellationToken = default)
        {
            Pageable<BinaryData> pageableBinaryData = GetLedgerEntries(collectionId, fromTransactionId, toTransactionId, new RequestContext{ CancellationToken = cancellationToken});

            return PageableHelpers.Select(pageableBinaryData, response => PagedLedgerEntries.FromResponse(response).Entries);
        }
    }
}
