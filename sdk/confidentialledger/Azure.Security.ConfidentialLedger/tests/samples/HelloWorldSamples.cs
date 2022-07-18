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

            #region Snippet:SubLedger

            ledgerClient.PostLedgerEntry(
                waitUntil: WaitUntil.Completed,
                RequestContent.Create(
                    new { contents = "Hello from Chris!", subLedgerId = "Chris' messages" }));

            ledgerClient.PostLedgerEntry(
                waitUntil: WaitUntil.Completed,
                RequestContent.Create(
                    new { contents = "Hello from Allison!", subLedgerId = "Allison's messages" }));

            #endregion

            #region Snippet:NoSubLedgerId

#if SNIPPET
            Response postResponse = ledgerClient.PostLedgerEntry(
#else
            postOperation = ledgerClient.PostLedgerEntry(
#endif
            waitUntil: WaitUntil.Completed,
                RequestContent.Create(
                    new { contents = "Hello world!" }));
#if SNIPPET
            string transactionId = postOperation.Id;
#else
            transactionId = postOperation.Id;
#endif
            string subLedgerId = "subledger:0";

            // Provide both the transactionId and subLedgerId.
            Response getBySubledgerResponse = ledgerClient.GetLedgerEntry(transactionId, subLedgerId);

            // Try until the entry is available.
            bool loaded = false;
            JsonElement element = default;
            string contents = null;
            while (!loaded)
            {
                loaded = JsonDocument.Parse(getBySubledgerResponse.Content)
                    .RootElement
                    .TryGetProperty("entry", out element);
                if (loaded)
                {
                    contents = element.GetProperty("contents").GetString();
                }
                else
                {
                    getBySubledgerResponse = ledgerClient.GetLedgerEntry(transactionId, subLedgerId);
                }
            }

            Console.WriteLine(contents); // "Hello world!"

            // Now just provide the transactionId.
            getBySubledgerResponse = ledgerClient.GetLedgerEntry(transactionId);

            string subLedgerId2 = JsonDocument.Parse(getBySubledgerResponse.Content)
                .RootElement
                .GetProperty("entry")
                .GetProperty("collectionId")
                .GetString();

            Console.WriteLine($"{subLedgerId} == {subLedgerId2}");

            #endregion

            #region Snippet:GetEnteryWithNoTransactionId

            Operation firstPostOperation = ledgerClient.PostLedgerEntry(
                waitUntil: WaitUntil.Completed,
                RequestContent.Create(new { contents = "Hello world 0" }));
            ledgerClient.PostLedgerEntry(
                waitUntil: WaitUntil.Completed,
                RequestContent.Create(new { contents = "Hello world 1" }));
            Operation subLedgerPostOperation = ledgerClient.PostLedgerEntry(
                waitUntil: WaitUntil.Completed,
                RequestContent.Create(new { contents = "Hello world sub-ledger 0" }),
                "my sub-ledger");
            ledgerClient.PostLedgerEntry(
                waitUntil: WaitUntil.Completed,
                RequestContent.Create(new { contents = "Hello world sub-ledger 1" }),
                "my sub-ledger");
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
                status = JsonDocument.Parse(statusResponse.Content)
                    .RootElement
                    .GetProperty("state")
                    .GetString();
            }

            // The ledger entry written at the transactionId in firstResponse is retrieved from the default sub-ledger.
            Response getResponse = ledgerClient.GetLedgerEntry(transactionId);

            // Try until the entry is available.
            loaded = false;
            element = default;
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
                    getResponse = ledgerClient.GetLedgerEntry(transactionId, subLedgerId);
                }
            }

            string firstEntryContents = JsonDocument.Parse(getResponse.Content)
                .RootElement
                .GetProperty("entry")
                .GetProperty("contents")
                .GetString();

            Console.WriteLine(firstEntryContents); // "Hello world 0"

            // This will return the latest entry available in the default sub-ledger.
            getResponse = ledgerClient.GetCurrentLedgerEntry();

            // Try until the entry is available.
            loaded = false;
            element = default;
            string latestDefaultSubLedger = null;
            while (!loaded)
            {
                loaded = JsonDocument.Parse(getResponse.Content)
                    .RootElement
                    .TryGetProperty("contents", out element);
                if (loaded)
                {
                    latestDefaultSubLedger = element.GetString();
                }
                else
                {
                    getResponse = ledgerClient.GetCurrentLedgerEntry();
                }
            }

            Console.WriteLine($"The latest ledger entry from the default sub-ledger is {latestDefaultSubLedger}"); //"Hello world 1"

            // The ledger entry written at subLedgerTransactionId is retrieved from the sub-ledger 'sub-ledger'.
            string subLedgerTransactionId = subLedgerPostOperation.Id;

            getResponse = ledgerClient.GetLedgerEntry(subLedgerTransactionId, "my sub-ledger");
            // Try until the entry is available.
            loaded = false;
            element = default;
            string subLedgerEntry = null;
            while (!loaded)
            {
                loaded = JsonDocument.Parse(getResponse.Content)
                    .RootElement
                    .TryGetProperty("entry", out element);
                if (loaded)
                {
                    subLedgerEntry = element.GetProperty("contents").GetString();
                }
                else
                {
                    getResponse = ledgerClient.GetLedgerEntry(subLedgerTransactionId, "my sub-ledger");
                }
            }

            Console.WriteLine(subLedgerEntry); // "Hello world sub-ledger 0"

            // This will return the latest entry available in the sub-ledger.
            getResponse = ledgerClient.GetCurrentLedgerEntry("my sub-ledger");
            string latestSubLedger = JsonDocument.Parse(getResponse.Content)
                .RootElement
                .GetProperty("contents")
                .GetString();

            Console.WriteLine($"The latest ledger entry from the sub-ledger is {latestSubLedger}"); // "Hello world sub-ledger 1"

            #endregion

            #region Snippet:RangedQuery

            ledgerClient.GetLedgerEntries(fromTransactionId: "2.1", toTransactionId: subLedgerTransactionId);

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
                // Consortium members can manage and alter the Confidential Ledger, such as by replacing unhealthy nodes.
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
