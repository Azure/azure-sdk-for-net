// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using System.Threading;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Azure.Security.ConfidentialLedger.Models;
using NUnit.Framework;

namespace Azure.Security.ConfidentialLedger.Tests.samples
{
    public class HelloWorldSamples : SamplesBase<ConfidentialLedgerEnvironment>
    {
        [Test]
        public void HelloWorld()
        {
            #region Snippet:ConfidentialLedger_CreateClient

#if SNIPPET
            var ledgerClient = new ConfidentialLedgerClient(new Uri("https://my-ledger-url.confidential-ledger.azure.com"), new DefaultAzureCredential());
#else
            var ledgerClient = new ConfidentialLedgerClient(TestEnvironment.ConfidentialLedgerUrl, TestEnvironment.Credential);
#endif
            #endregion
            #region Snippet:ConfidentialLedger_AppendToLedger

            Operation<LedgerWriteResult> postOperation = ledgerClient.PostLedgerEntry(
                waitUntil: WaitUntil.Completed,
                new LedgerEntry("Hello world!"));

            string transactionId = postOperation.Value.TransactionId;
            Console.WriteLine($"Appended transaction with Id: {transactionId} to collection {postOperation.Value.CollectionId}");

            #endregion

            #region Snippet:ConfidentialLedger_GetStatus

            TransactionStatus transactionStatus = ledgerClient.GetTransactionStatus(transactionId).Value;
            TransactionState status = transactionStatus.State;

            Console.WriteLine($"Transaction status: {status}");

            // Wait for the entry to be committed
            while (status == TransactionState.Pending)
            {
                status = ledgerClient.GetTransactionStatus(transactionId).Value.State;
            }

            Console.WriteLine($"Transaction status: {status}");

            #endregion

            #region Snippet:ConfidentialLedger_GetReceipt

            Response receiptResponse = ledgerClient.GetReceipt(transactionId, new RequestContext());
            string receiptJson = new StreamReader(receiptResponse.ContentStream).ReadToEnd();

            Console.WriteLine(receiptJson);

            #endregion

            #region Snippet:ConfidentialLedger_Collection

            ledgerClient.PostLedgerEntry(
                waitUntil: WaitUntil.Completed,
                new LedgerEntry("Hello from Chris!"),
                collectionId: "Chris' messages");

            ledgerClient.PostLedgerEntry(
                waitUntil: WaitUntil.Completed,
                new LedgerEntry("Hello from Allison!"),
                collectionId: "Allison's messages");

            #endregion

            #region Snippet:ConfidentialLedger_NoCollectionId
            postOperation = ledgerClient.PostLedgerEntry(
                waitUntil: WaitUntil.Completed,
                new LedgerEntry("Hello world!"));

            transactionId = postOperation.Value.TransactionId;
            string collectionId = postOperation.Value.CollectionId; // "subledger:0"

            // Try fetching the ledger entry until it is "loaded".
            LedgerQueryResult queryResult;
            do
            {
                // Provide both the transactionId and collectionId.
                queryResult = ledgerClient.GetLedgerEntry(transactionId, collectionId).Value;
            }
            while (queryResult.State == ConfidentialLedgerQueryState.Loading);

            string contents = queryResult.Entry.Contents;

            Console.WriteLine(contents); // "Hello world!"

            // Now just provide the transactionId.
            queryResult = ledgerClient.GetLedgerEntry(transactionId).Value;

            string collectionId2 = queryResult.Entry.CollectionId;

            Console.WriteLine($"{collectionId} == {collectionId2}");

            #endregion

            #region Snippet:ConfidentialLedger_GetEnteryWithNoTransactionId

            Operation<LedgerWriteResult> firstPostOperation = ledgerClient.PostLedgerEntry(
                waitUntil: WaitUntil.Completed,
                new LedgerEntry("Hello world 0"));
            ledgerClient.PostLedgerEntry(
                waitUntil: WaitUntil.Completed,
                new LedgerEntry("Hello world 1"));
            Operation<LedgerWriteResult> collectionPostOperation = ledgerClient.PostLedgerEntry(
                waitUntil: WaitUntil.Completed,
                new LedgerEntry("Hello world collection 0"),
                collectionId: "my collection");
            ledgerClient.PostLedgerEntry(
                waitUntil: WaitUntil.Completed,
                new LedgerEntry("Hello world collection 1"),
                collectionId: "my collection");

            transactionId = firstPostOperation.Value.TransactionId;

            // The ledger entry written at the transactionId in firstPostOperation is retrieved from the default collection.
            // Try until the entry is available.
            do
            {
                queryResult = ledgerClient.GetLedgerEntry(transactionId).Value;
            }
            while (queryResult.State == ConfidentialLedgerQueryState.Loading);

            string firstEntryContents = queryResult.Entry.Contents;

            Console.WriteLine(firstEntryContents); // "Hello world 0"

            // This will return the latest entry available in the default collection.
            LedgerEntry latestDefaultCollection = ledgerClient.GetCurrentLedgerEntry().Value;

            Console.WriteLine($"The latest ledger entry from the default collection is {latestDefaultCollection.Contents}"); //"Hello world 1"

            // The ledger entry written at collectionTransactionId is retrieved from the collection 'collection'.
            string collectionTransactionId = collectionPostOperation.Value.TransactionId;

            // Try until the entry is available.
            do
            {
                queryResult = ledgerClient.GetLedgerEntry(collectionTransactionId, "my collection").Value;
            }
            while (queryResult.State == ConfidentialLedgerQueryState.Loading);

            Console.WriteLine(queryResult.Entry.Contents); // "Hello world collection 0"

            // This will return the latest entry available in the collection.
            string latestCollection = ledgerClient.GetCurrentLedgerEntry("my collection").Value.Contents;

            Console.WriteLine($"The latest ledger entry from the collection is {latestCollection}"); // "Hello world collection 1"

            #endregion

            #region Snippet:ConfidentialLedger_RangedQuery

            ledgerClient.GetLedgerEntries(fromTransactionId: "2.1", toTransactionId: collectionTransactionId);

            #endregion

            #region Snippet:ConfidentialLedger_NewUser

#if SNIPPET
            string newUserAadObjectId = "<some AAD user or service principal object Id>";
#else
            string newUserAadObjectId = Guid.NewGuid().ToString();
#endif
            LedgerUserMultipleRoles newUser = ledgerClient.CreateOrUpdateLedgerUser(
                newUserAadObjectId,
                new LedgerUserMultipleRoles(new[] { ConfidentialLedgerUserRoleName.Reader })).Value;

            Console.WriteLine($"User {newUser.UserId} has roles: {string.Join(", ", newUser.AssignedRoles)}");

            #endregion

            #region Snippet:ConfidentialLedger_Consortium

            Pageable<BinaryData> consortiumResponse = ledgerClient.GetConsortiumMembers(new RequestContext());
            foreach (var page in consortiumResponse)
            {
                string membersJson = page.ToString();
                // Consortium members can manage and alter the confidential ledger, such as by replacing unhealthy nodes.
                Console.WriteLine(membersJson);
            }

            // The constitution is a collection of JavaScript code that defines actions available to members,
            // and vets proposals by members to execute those actions.
            Response constitutionResponse = ledgerClient.GetConstitution(new RequestContext());
            string constitutionJson = new StreamReader(constitutionResponse.ContentStream).ReadToEnd();

            Console.WriteLine(constitutionJson);

            // Enclave quotes contain material that can be used to cryptographically verify the validity and contents of an enclave.
            Response enclavesResponse = ledgerClient.GetEnclaveQuotes(new RequestContext());
            string enclavesJson = new StreamReader(enclavesResponse.ContentStream).ReadToEnd();

            Console.WriteLine(enclavesJson);

            #endregion
        }

        [Test]
        public void LedgerGatewayQueuedSubmission()
        {
            #region Snippet:CreateClientLedgerGateway

#if SNIPPET
            var ledgerClient = new ConfidentialLedgerClient(
                ledgerEndpoint: new Uri("https://my-ledger-url.confidential-ledger.azure.com"),
                credential: new DefaultAzureCredential(),
                options: new ConfidentialLedgerClientOptions { UseLedgerGateway = true });
#else
            var ledgerClient = new ConfidentialLedgerClient(
                ledgerEndpoint: TestEnvironment.ConfidentialLedgerUrl,
                credential: TestEnvironment.Credential,
                options: new ConfidentialLedgerClientOptions { UseLedgerGateway = true });
#endif

            #endregion

            #region Snippet:PostLedgerEntryWaitUntilStarted

            // When UseLedgerGateway = true and waitUntil is Started, the SDK accepts a 202 Accepted
            // response and returns an operation whose Id is the gateway-assigned operationId.
            Operation operation = ledgerClient.PostLedgerEntry(
                waitUntil: WaitUntil.Started,
                RequestContent.Create(new { contents = "Hello from the Ledger Gateway!" }));

            string operationId = operation.Id;
            Console.WriteLine($"Submitted ledger entry. Operation Id: {operationId}");

            // The application can persist operationId and exit. The submission is durable on the
            // server for the gateway's operation-record retention period.

            #endregion

            #region Snippet:RehydratePostLedgerEntryOperation

            // Later, in a different process or after a restart, resume polling with the saved
            // operation Id. Rehydration performs no I/O until you start polling.
            Operation resumed = ledgerClient.RehydratePostLedgerEntryOperation(operationId);

            // The Ledger Gateway write queue can stay pending for an extended period during an outage.
            // Always bound the wait with a CancellationToken so the call cannot hang indefinitely.
            using var cts = new CancellationTokenSource(TimeSpan.FromMinutes(5));
            Response completed = resumed.WaitForCompletionResponse(cts.Token);

            // Once committed, Operation.Id flips to the CCF transaction Id.
            string transactionId = resumed.Id;
            Console.WriteLine($"Operation {operationId} committed as transaction {transactionId}");
            Console.WriteLine($"Final status: {completed.Status}");

            #endregion
        }
    }
}
