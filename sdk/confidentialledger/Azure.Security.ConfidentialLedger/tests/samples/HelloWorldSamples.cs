// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using Azure.Core;
using Azure.Core.Dynamic;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Security.ConfidentialLedger.Tests.samples
{
    public class HelloWorldSamples : SamplesBase<ConfidentialLedgerEnvironment>
    {
        [Test]
        public void HelloWorld()
        {
            #region Snippet:CreateClient

#if SNIPPET
            var ledgerClient = new ConfidentialLedgerClient(new Uri("https://my-ledger-url.confidential-ledger.azure.com"), new DefaultAzureCredential());
#else
            var ledgerClient = new ConfidentialLedgerClient(TestEnvironment.ConfidentialLedgerUrl, TestEnvironment.Credential);
#endif
            #endregion
            #region Snippet:AppendToLedger

            Operation postOperation = ledgerClient.PostLedgerEntry(
                waitUntil: WaitUntil.Completed,
                RequestContent.Create(
                    new { contents = "Hello world!" }));

            string transactionId = postOperation.Id;
            Console.WriteLine($"Appended transaction with Id: {transactionId}");

            #endregion

            #region Snippet:GetStatus

            Response statusResponse = ledgerClient.GetTransactionStatus(transactionId);

            string status = statusResponse.Content.ToDynamic().state;

            Console.WriteLine($"Transaction status: {status}");

            // Wait for the entry to be committed
            while (status == "Pending")
            {
                statusResponse = ledgerClient.GetTransactionStatus(transactionId);
                status = statusResponse.Content.ToDynamic().state;
            }

            Console.WriteLine($"Transaction status: {status}");

            #endregion

            #region Snippet:GetReceipt

            Response receiptResponse = ledgerClient.GetReceipt(transactionId);
            string receiptJson = new StreamReader(receiptResponse.ContentStream).ReadToEnd();

            Console.WriteLine(receiptJson);

            #endregion

            #region Snippet:Collection

            ledgerClient.PostLedgerEntry(
                waitUntil: WaitUntil.Completed,
                RequestContent.Create(
                    new { contents = "Hello from Chris!", collectionId = "Chris' messages" }));

            ledgerClient.PostLedgerEntry(
                waitUntil: WaitUntil.Completed,
                RequestContent.Create(
                    new { contents = "Hello from Allison!", collectionId = "Allison's messages" }));

            #endregion

            #region Snippet:NoCollectionId

#if SNIPPET
            Response postResponse = ledgerClient.PostLedgerEntry(
#else
            postOperation = ledgerClient.PostLedgerEntry(
#endif
            waitUntil: WaitUntil.Completed,
                RequestContent.Create(
                    new { contents = "Hello world!" }));

            string content = postOperation.GetRawResponse().Content.ToString();
#if SNIPPET
            string transactionId = postOperation.Id;
#else
            transactionId = postOperation.Id;
#endif
            string collectionId = "subledger:0";

            // Try fetching the ledger entry until it is "loaded".
            Response getByCollectionResponse = default;
            dynamic ledgerEntry = default;
            bool loaded = false;

            while (!loaded)
            {
                // Provide both the transactionId and collectionId.
                getByCollectionResponse = ledgerClient.GetLedgerEntry(transactionId, collectionId);
                ledgerEntry = getByCollectionResponse.Content.ToDynamic();
                loaded = ledgerEntry.state != "Loading";
            }

			string contents = ledgerEntry.entry.contents;
            Console.WriteLine(contents); // "Hello world!"

            // Now just provide the transactionId.
            getByCollectionResponse = ledgerClient.GetLedgerEntry(transactionId);

            string collectionId2 = ledgerEntry.entry.collectionId;

            Console.WriteLine($"{collectionId} == {collectionId2}");

            #endregion

            #region Snippet:GetEnteryWithNoTransactionId

            Operation firstPostOperation = ledgerClient.PostLedgerEntry(
                waitUntil: WaitUntil.Completed,
                RequestContent.Create(new { contents = "Hello world 0" }));
            ledgerClient.PostLedgerEntry(
                waitUntil: WaitUntil.Completed,
                RequestContent.Create(new { contents = "Hello world 1" }));
            Operation collectionPostOperation = ledgerClient.PostLedgerEntry(
                waitUntil: WaitUntil.Completed,
                RequestContent.Create(new { contents = "Hello world collection 0" }),
                "my collection");
            ledgerClient.PostLedgerEntry(
                waitUntil: WaitUntil.Completed,
                RequestContent.Create(new { contents = "Hello world collection 1" }),
                "my collection");
#if SNIPPET
            string transactionId = firstPostOperation.Id;
#else
            transactionId = firstPostOperation.Id;
#endif

            // Wait for the entry to be committed
            status = "Pending";
            while (status == "Pending")
            {
                statusResponse = ledgerClient.GetTransactionStatus(transactionId);
                status = statusResponse.Content.ToDynamic().state;
            }

            // The ledger entry written at the transactionId in firstResponse is retrieved from the default collection.
            Response getResponse = ledgerClient.GetLedgerEntry(transactionId);

            // Try until the entry is available.
            loaded = false;
            contents = null;
            while (!loaded)
            {
                dynamic json = getResponse.Content.ToDynamic();

                // TODO: Not currently handled
                //loaded = (LedgerEntry)json.entry != null;

                try
                {
                    loaded = (LedgerEntry)json.entry != null;
                }
                catch (InvalidOperationException)
                {
                    loaded = false;
                }

                if (loaded)
                {
                    contents = json.entry.contents;
                }
                else
                {
                    getResponse = ledgerClient.GetLedgerEntry(transactionId, collectionId);
                }
            }

            string firstEntryContents = ledgerEntry.entry.contents;
            Console.WriteLine(firstEntryContents); // "Hello world 0"

            // This will return the latest entry available in the default collection.
            getResponse = ledgerClient.GetCurrentLedgerEntry();

            // Try until the entry is available.
            loaded = false;
            string latestDefaultCollection = null;
            while (!loaded)
            {
                dynamic json = getResponse.Content.ToDynamic();

                loaded = (string)json.contents != null;
                if (loaded)
                {
                    latestDefaultCollection = json.contents;
                }
                else
                {
                    getResponse = ledgerClient.GetCurrentLedgerEntry();
                }
            }

            Console.WriteLine($"The latest ledger entry from the default collection is {latestDefaultCollection}"); //"Hello world 1"

            // The ledger entry written at collectionTransactionId is retrieved from the collection 'collection'.
            string collectionTransactionId = collectionPostOperation.Id;

            getResponse = ledgerClient.GetLedgerEntry(collectionTransactionId, "my collection");
            // Try until the entry is available.
            loaded = false;
            string collectionEntry = null;
            while (!loaded)
            {
                dynamic json = getResponse.Content.ToDynamic();

                // TODO: Not currently handled
                //loaded = (LedgerEntry)json.entry != null;

                try
                {
                    loaded = (LedgerEntry)json.entry != null;
                }
                catch (InvalidOperationException)
                {
                    loaded = false;
                }

                if (loaded)
                {
                    collectionEntry = json.entry.contents;
                }
                else
                {
                    getResponse = ledgerClient.GetLedgerEntry(collectionTransactionId, "my collection");
                }
            }

            Console.WriteLine(collectionEntry); // "Hello world collection 0"

            // This will return the latest entry available in the collection.
            getResponse = ledgerClient.GetCurrentLedgerEntry("my collection");
            string latestCollection = getResponse.Content.ToDynamic().contents;

            Console.WriteLine($"The latest ledger entry from the collection is {latestCollection}"); // "Hello world collection 1"

            #endregion

            #region Snippet:RangedQuery

            ledgerClient.GetLedgerEntries(fromTransactionId: "2.1", toTransactionId: collectionTransactionId);

            #endregion

            #region Snippet:NewUser

#if SNIPPET
            string newUserAadObjectId = "<some AAD user or service princpal object Id>";
#else
            string newUserAadObjectId = Guid.NewGuid().ToString();
#endif
            ledgerClient.CreateOrUpdateUser(
                newUserAadObjectId,
                RequestContent.Create(new { assignedRole = "Reader" }));

            #endregion

            #region Snippet:Consortium

            Pageable<BinaryData> consortiumResponse = ledgerClient.GetConsortiumMembers();
            foreach (var page in consortiumResponse)
            {
                string membersJson = page.ToString();
                // Consortium members can manage and alter the confidential ledger, such as by replacing unhealthy nodes.
                Console.WriteLine(membersJson);
            }

            // The constitution is a collection of JavaScript code that defines actions available to members,
            // and vets proposals by members to execute those actions.
            Response constitutionResponse = ledgerClient.GetConstitution();
            string constitutionJson = new StreamReader(constitutionResponse.ContentStream).ReadToEnd();

            Console.WriteLine(constitutionJson);

            // Enclave quotes contain material that can be used to cryptographically verify the validity and contents of an enclave.
            Response enclavesResponse = ledgerClient.GetEnclaveQuotes();
            string enclavesJson = new StreamReader(enclavesResponse.ContentStream).ReadToEnd();

            Console.WriteLine(enclavesJson);

            #endregion
        }

        private class LedgerEntry
        {
            public string contents { get; set; }
        }
    }
}
