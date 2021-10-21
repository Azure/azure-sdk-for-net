// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
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
            #region Snippet:GetIdentity

#if SNIPPET
            Uri identityServiceEndpoint = new("https://identity.confidential-ledger.core.azure.com") // The hostname from the identityServiceUri
#else
            Uri identityServiceEndpoint = TestEnvironment.ConfidentialLedgerIdentityUrl;
#endif
            var identityClient = new ConfidentialLedgerIdentityServiceClient(identityServiceEndpoint);

            // Get the ledger's  TLS certificate for our ledger.
#if SNIPPET
            string ledgerId = "<the ledger id>"; // ex. "my-ledger" from "https://my-ledger.eastus.cloudapp.azure.com"
#else
            var ledgerId = TestEnvironment.ConfidentialLedgerUrl.Host;
            ledgerId = ledgerId.Substring(0, ledgerId.IndexOf('.'));
#endif
            Response response = identityClient.GetLedgerIdentity(ledgerId, new());
            X509Certificate2 ledgerTlsCert = ConfidentialLedgerIdentityServiceClient.ParseCertificate(response);
            #endregion

            #region Snippet:CreateClient

            // Create a certificate chain rooted with our TLS cert.
            X509Chain certificateChain = new();
            certificateChain.ChainPolicy.RevocationMode = X509RevocationMode.NoCheck;
            certificateChain.ChainPolicy.RevocationFlag = X509RevocationFlag.ExcludeRoot;
            certificateChain.ChainPolicy.VerificationFlags = X509VerificationFlags.AllowUnknownCertificateAuthority;
            certificateChain.ChainPolicy.VerificationTime = DateTime.Now;
            certificateChain.ChainPolicy.UrlRetrievalTimeout = new TimeSpan(0, 0, 0);
            certificateChain.ChainPolicy.ExtraStore.Add(ledgerTlsCert);

            var f = certificateChain.Build(ledgerTlsCert);
            // Define a validation function to ensure that the ledger certificate is trusted by the ledger identity TLS certificate.
            bool CertValidationCheck(HttpRequestMessage httpRequestMessage, X509Certificate2 cert, X509Chain x509Chain, SslPolicyErrors sslPolicyErrors)
            {
                bool isChainValid = certificateChain.Build(cert);
                if (!isChainValid) return false;

                var isCertSignedByTheTlsCert = certificateChain.ChainElements.Cast<X509ChainElement>()
                    .Any(x => x.Certificate.Thumbprint == ledgerTlsCert.Thumbprint);
                return isCertSignedByTheTlsCert;
            }

            // Create an HttpClientHandler to use our certValidationCheck function.
            var httpHandler = new HttpClientHandler();
            httpHandler.ServerCertificateCustomValidationCallback = CertValidationCheck;

            // Create the ledger client using a transport that uses our custom ServerCertificateCustomValidationCallback.
            var options = new ConfidentialLedgerClientOptions { Transport = new HttpClientTransport(httpHandler) };

#if SNIPPET
            var ledgerClient = new ConfidentialLedgerClient(new Uri($"https://{ledgerId}.confidential-ledger.azure.com"), new DefaultAzureCredential(), options);
#else
            var ledgerClient = new ConfidentialLedgerClient(TestEnvironment.ConfidentialLedgerUrl, new DefaultAzureCredential(), options);
#endif

            #endregion

            #region Snippet:AppendToLedger

            Response postResponse = ledgerClient.PostLedgerEntry(
                RequestContent.Create(
                    new { contents = "Hello world!" }));

            postResponse.Headers.TryGetValue(ConfidentialLedgerConstants.TransactionIdHeaderName, out string transactionId);
            Console.WriteLine($"Appended transaction with Id: {transactionId}");

            #endregion

            #region Snippet:GetStatus

            Response statusResponse = ledgerClient.GetTransactionStatus(transactionId, new());

            string status = JsonDocument.Parse(statusResponse.Content)
                .RootElement
                .GetProperty("state")
                .GetString();

            Console.WriteLine($"Transaction status: {status}");

            // Wait for the entry to be committed
            while (status == "Pending")
            {
                statusResponse = ledgerClient.GetTransactionStatus(transactionId, new());
                status = JsonDocument.Parse(statusResponse.Content)
                    .RootElement
                    .GetProperty("state")
                    .GetString();
            }

            Console.WriteLine($"Transaction status: {status}");

            #endregion

            #region Snippet:GetReceipt

            Response receiptResponse = ledgerClient.GetReceipt(transactionId, new());
            string receiptJson = new StreamReader(receiptResponse.ContentStream).ReadToEnd();

            Console.WriteLine(receiptJson);

            #endregion

            #region Snippet:SubLedger

            ledgerClient.PostLedgerEntry(
                RequestContent.Create(
                    new { contents = "Hello from Chris!", subLedgerId = "Chris' messages" }));

            ledgerClient.PostLedgerEntry(
                RequestContent.Create(
                    new { contents = "Hello from Allison!", subLedgerId = "Allison's messages" }));

            #endregion

            #region Snippet:NoSubLedgerId

#if SNIPPET
            Response postResponse = ledgerClient.PostLedgerEntry(
#else
            postResponse = ledgerClient.PostLedgerEntry(
#endif
                RequestContent.Create(
                    new { contents = "Hello world!" }));
#if SNIPPET
            postResponse.Headers.TryGetValue(ConfidentialLedgerConstants.Headers.TransactionId, out string transactionId);
#else
            postResponse.Headers.TryGetValue(ConfidentialLedgerConstants.TransactionIdHeaderName, out transactionId);
#endif
            string subLedgerId = JsonDocument.Parse(postResponse.Content)
                .RootElement
                .GetProperty("subLedgerId")
                .GetString();

            // Wait for the entry to be available.
            status = "Pending";
            while (status == "Pending")
            {
                statusResponse = ledgerClient.GetTransactionStatus(transactionId, new());
                status = JsonDocument.Parse(statusResponse.Content)
                    .RootElement
                    .GetProperty("state")
                    .GetString();
            }

            Console.WriteLine($"Transaction status: {status}");

            // Provide both the transactionId and subLedgerId.
            Response getBySubledgerResponse = ledgerClient.GetLedgerEntry(transactionId, new(), subLedgerId);

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
                    getBySubledgerResponse = ledgerClient.GetLedgerEntry(transactionId, new(), subLedgerId);
                }
            }

            Console.WriteLine(contents); // "Hello world!"

            // Now just provide the transactionId.
            getBySubledgerResponse = ledgerClient.GetLedgerEntry(transactionId, new());

            string subLedgerId2 = JsonDocument.Parse(getBySubledgerResponse.Content)
                .RootElement
                .GetProperty("entry")
                .GetProperty("subLedgerId")
                .GetString();

            Console.WriteLine($"{subLedgerId} == {subLedgerId2}");

            #endregion

            #region Snippet:GetEnteryWithNoTransactionId

            Response firstPostResponse = ledgerClient.PostLedgerEntry(
                RequestContent.Create(new { contents = "Hello world 0" }));
            ledgerClient.PostLedgerEntry(
                RequestContent.Create(new { contents = "Hello world 1" }));
            Response subLedgerPostResponse = ledgerClient.PostLedgerEntry(
                RequestContent.Create(new { contents = "Hello world sub-ledger 0" }),
                "my sub-ledger");
            ledgerClient.PostLedgerEntry(
                RequestContent.Create(new { contents = "Hello world sub-ledger 1" }),
                "my sub-ledger");

#if SNIPPET
            firstPostResponse.Headers.TryGetValue(ConfidentialLedgerConstants.Headers.TransactionId, out string transactionId);
#else
            firstPostResponse.Headers.TryGetValue(ConfidentialLedgerConstants.TransactionIdHeaderName, out transactionId);
#endif

            // Wait for the entry to be committed
            status = "Pending";
            while (status == "Pending")
            {
                statusResponse = ledgerClient.GetTransactionStatus(transactionId, new());
                status = JsonDocument.Parse(statusResponse.Content)
                    .RootElement
                    .GetProperty("state")
                    .GetString();
            }

            // The ledger entry written at the transactionId in firstResponse is retrieved from the default sub-ledger.
            Response getResponse = ledgerClient.GetLedgerEntry(transactionId, new());

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
                    getResponse = ledgerClient.GetLedgerEntry(transactionId, new(), subLedgerId);
                }
            }

            string firstEntryContents = JsonDocument.Parse(getResponse.Content)
                .RootElement
                .GetProperty("entry")
                .GetProperty("contents")
                .GetString();

            Console.WriteLine(firstEntryContents); // "Hello world 0"

            // This will return the latest entry available in the default sub-ledger.
            getResponse = ledgerClient.GetCurrentLedgerEntry(new());

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
                    getResponse = ledgerClient.GetCurrentLedgerEntry(new());
                }
            }

            Console.WriteLine($"The latest ledger entry from the default sub-ledger is {latestDefaultSubLedger}"); //"Hello world 1"

            // The ledger entry written at subLedgerTransactionId is retrieved from the sub-ledger 'sub-ledger'.
            subLedgerPostResponse.Headers.TryGetValue(ConfidentialLedgerConstants.TransactionIdHeaderName, out string subLedgerTransactionId);

            // Wait for the entry to be committed
            status = "Pending";
            while (status == "Pending")
            {
                statusResponse = ledgerClient.GetTransactionStatus(subLedgerTransactionId, new());
                status = JsonDocument.Parse(statusResponse.Content)
                    .RootElement
                    .GetProperty("state")
                    .GetString();
            }

            getResponse = ledgerClient.GetLedgerEntry(subLedgerTransactionId, new(), "my sub-ledger");
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
                    getResponse = ledgerClient.GetLedgerEntry(subLedgerTransactionId, new(), "my sub-ledger");
                }
            }

            Console.WriteLine(subLedgerEntry); // "Hello world sub-ledger 0"

            // This will return the latest entry available in the sub-ledger.
            getResponse = ledgerClient.GetCurrentLedgerEntry(new(), "my sub-ledger");
            string latestSubLedger = JsonDocument.Parse(getResponse.Content)
                .RootElement
                .GetProperty("contents")
                .GetString();

            Console.WriteLine($"The latest ledger entry from the sub-ledger is {latestSubLedger}"); // "Hello world sub-ledger 1"

            #endregion

            #region Snippet:RangedQuery

            ledgerClient.GetLedgerEntries(new(), fromTransactionId: "2.1", toTransactionId: subLedgerTransactionId);

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

            Response consortiumResponse = ledgerClient.GetConsortiumMembers(new());
            string membersJson = new StreamReader(consortiumResponse.ContentStream).ReadToEnd();

            // Consortium members can manage and alter the Confidential Ledger, such as by replacing unhealthy nodes.
            Console.WriteLine(membersJson);

            // The constitution is a collection of JavaScript code that defines actions available to members,
            // and vets proposals by members to execute those actions.
            Response constitutionResponse = ledgerClient.GetConstitution(new());
            string constitutionJson = new StreamReader(constitutionResponse.ContentStream).ReadToEnd();

            Console.WriteLine(constitutionJson);

            // Enclave quotes contain material that can be used to cryptographically verify the validity and contents of an enclave.
            Response enclavesResponse = ledgerClient.GetEnclaveQuotes(new());
            string enclavesJson = new StreamReader(enclavesResponse.ContentStream).ReadToEnd();

            Console.WriteLine(enclavesJson);

            #endregion
        }
    }
}
