// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using Azure.Core;
using Azure.Core.Pipeline;
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

            string status = JsonDocument.Parse(statusResponse.Content)
                .RootElement
                .GetProperty("state")
                .GetString();

            Console.WriteLine($"Transaction status: {status}");

            // Wait for the entry to be committed
            while (status == "Pending")
            {
                statusResponse = ledgerClient.GetTransactionStatus(transactionId);
                status = JsonDocument.Parse(statusResponse.Content)
                    .RootElement
                    .GetProperty("state")
                    .GetString();
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
            postOperation = ledgerClient.PostLedgerEntry(
                waitUntil: WaitUntil.Completed,
                RequestContent.Create(
                    new { contents = "Hello world!" }));

            string content = postOperation.GetRawResponse().Content.ToString();
            transactionId = postOperation.Id;
            string collectionId = "subledger:0";

            // Try fetching the ledger entry until it is "loaded".
            Response getByCollectionResponse = default;
            JsonElement rootElement = default;
            bool loaded = false;

            while (!loaded)
            {
                // Provide both the transactionId and collectionId.
                getByCollectionResponse = ledgerClient.GetLedgerEntry(transactionId, collectionId);
                rootElement = JsonDocument.Parse(getByCollectionResponse.Content).RootElement;
                loaded = rootElement.GetProperty("state").GetString() != "Loading";
            }

            string contents = rootElement
                .GetProperty("entry")
                .GetProperty("contents")
                .GetString();

            Console.WriteLine(contents); // "Hello world!"

            // Now just provide the transactionId.
            getByCollectionResponse = ledgerClient.GetLedgerEntry(transactionId);

            string collectionId2 = JsonDocument.Parse(getByCollectionResponse.Content)
                .RootElement
                .GetProperty("entry")
                .GetProperty("collectionId")
                .GetString();

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

            transactionId = firstPostOperation.Id;

            // Wait for the entry to be committed
            status = "Pending";
            while (status == "Pending")
            {
                statusResponse = ledgerClient.GetTransactionStatus(transactionId);
                status = JsonDocument.Parse(statusResponse.Content)
                    .RootElement
                    .GetProperty("state")
                    .GetString();
            }

            // The ledger entry written at the transactionId in firstResponse is retrieved from the default collection.
            Response getResponse = ledgerClient.GetLedgerEntry(transactionId);

            // Try until the entry is available.
            loaded = false;
            JsonElement element = default;
            contents = null;
            while (!loaded)
            {
                loaded = JsonDocument.Parse(getResponse.Content)
                    .RootElement
                    .TryGetProperty("entry", out element);
                if (loaded)
                {
                    contents = element.GetProperty("contents").GetString();
                }
                else
                {
                    getResponse = ledgerClient.GetLedgerEntry(transactionId, collectionId);
                }
            }

            string firstEntryContents = JsonDocument.Parse(getResponse.Content)
                .RootElement
                .GetProperty("entry")
                .GetProperty("contents")
                .GetString();

            Console.WriteLine(firstEntryContents); // "Hello world 0"

            // This will return the latest entry available in the default collection.
            getResponse = ledgerClient.GetCurrentLedgerEntry();

            // Try until the entry is available.
            loaded = false;
            element = default;
            string latestDefaultCollection = null;
            while (!loaded)
            {
                loaded = JsonDocument.Parse(getResponse.Content)
                    .RootElement
                    .TryGetProperty("contents", out element);
                if (loaded)
                {
                    latestDefaultCollection = element.GetString();
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
            element = default;
            string collectionEntry = null;
            while (!loaded)
            {
                loaded = JsonDocument.Parse(getResponse.Content)
                    .RootElement
                    .TryGetProperty("entry", out element);
                if (loaded)
                {
                    collectionEntry = element.GetProperty("contents").GetString();
                }
                else
                {
                    getResponse = ledgerClient.GetLedgerEntry(collectionTransactionId, "my collection");
                }
            }

            Console.WriteLine(collectionEntry); // "Hello world collection 0"

            // This will return the latest entry available in the collection.
            getResponse = ledgerClient.GetCurrentLedgerEntry("my collection");
            string latestCollection = JsonDocument.Parse(getResponse.Content)
                .RootElement
                .GetProperty("contents")
                .GetString();

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
    }
}
