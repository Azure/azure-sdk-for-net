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

namespace Azure.Storage.ConfidentialLedger.Tests.samples
{
    public class HelloWorldSamples : SamplesBase<ConfidentialLedgerEnvironment>
    {
        [Test]
        public void HelloWorld()
        {
            #region Snippet:GetIdentity

#if SNIPPET
            Uri identityServiceUri = "<the identity service uri>";
#else
            Uri identityServiceUri = TestEnvironment.ConfidentialLedgerIdentityUrl;
#endif
            var identityClient = new ConfidentialLedgerIdentityServiceClient(identityServiceUri, new Identity.DefaultAzureCredential());

            // Get the ledger's  TLS certificate for our ledger.
#if SNIPPET
            string ledgerId = "<the ledger id>"; // ex. "my-ledger" from "https://my-ledger.eastus.cloudapp.azure.com"
#else
            var ledgerId = TestEnvironment.ConfidentialLedgerUrl.Host;
            ledgerId = ledgerId.Substring(0, ledgerId.IndexOf('.'));
#endif
            Response response = identityClient.GetLedgerIdentity(ledgerId);

            // extract the ECC PEM value from the response.
            var eccPem = JsonDocument.Parse(response.Content)
                .RootElement
                .GetProperty("ledgerTlsCertificate")
                .GetString();

            // construct an X509Certificate2 with the ECC PEM value.
            X509Certificate2 ledgerTlsCert = new X509Certificate2(Encoding.UTF8.GetBytes(eccPem));

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
            var ledgerClient = new ConfidentialLedgerClient(TestEnvironment.ConfidentialLedgerUrl, new DefaultAzureCredential(), options);

            #endregion

            #region Snippet:AppendToLedger

            Response postResponse = ledgerClient.PostLedgerEntry(
                RequestContent.Create(
                    new { contents = "Hello world!" }));

            postResponse.Headers.TryGetValue(ConfidentialLedgerConstants.TransactionIdHeaderName, out string transactionId);
            Console.WriteLine($"Appended transaction with Id: {transactionId}");

            #endregion

            #region Snippet:GetStatus

            Response statusResponse = ledgerClient.GetTransactionStatus(transactionId);

            string status = JsonDocument.Parse(statusResponse.Content)
                .RootElement
                .GetProperty("state")
                .GetString();

            Console.WriteLine($"Transaction status: {status}");

            #endregion

            #region Snippet:GetReceipt

            Response receiptResponse = ledgerClient.GetReceipt(transactionId);
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
            string subLedgerId = JsonDocument.Parse(statusResponse.Content)
                .RootElement
                .GetProperty("subLedgerId")
                .GetString();

            // Provide both the transactionId and subLedgerId.
            Response getBySubledgerResponse = ledgerClient.GetLedgerEntry(transactionId, subLedgerId);

            string contents = JsonDocument.Parse(getBySubledgerResponse.Content)
                .RootElement
                .GetProperty("contents")
                .GetString();

            Console.WriteLine(contents); // "Hello world!"

            // Now just provide the transactionId.
            getBySubledgerResponse = ledgerClient.GetLedgerEntry(transactionId);

            string subLedgerId2 = JsonDocument.Parse(getBySubledgerResponse.Content)
                .RootElement
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

            // The ledger entry written at the transactionId in firstResponse is retrieved from the default sub-ledger.
            Response getResponse = ledgerClient.GetLedgerEntry(transactionId);
            string firstEntryContents = JsonDocument.Parse(getResponse.Content)
                .RootElement
                .GetProperty("contents")
                .GetString();

            Console.WriteLine(firstEntryContents); // "Hello world 0"

            // This will return the latest entry available in the default sub-ledger.
            getResponse = ledgerClient.GetCurrentLedgerEntry();
            string latestDefaultSubLedger = JsonDocument.Parse(getResponse.Content)
                .RootElement
                .GetProperty("contents")
                .GetString();

            Console.WriteLine($"The latest ledger entry from the default sub-ledger is {latestDefaultSubLedger}"); //"Hello world 1"

            // The ledger entry written at subLedgerTransactionId is retrieved from the sub-ledger 'sub-ledger'.
            subLedgerPostResponse.Headers.TryGetValue(ConfidentialLedgerConstants.TransactionIdHeaderName, out string subLedgerTransactionId);
            getResponse = ledgerClient.GetLedgerEntry(subLedgerTransactionId, "my sub-ledger");
            string subLedgerEntry = JsonDocument.Parse(getResponse.Content)
                .RootElement
                .GetProperty("contents")
                .GetString();

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

            ledgerClient.GetLedgerEntries(fromTransactionId: "2.1", toTransactionId: "4.5");

            #endregion

            #region Snippet:NewUser

            string newUserAadObjectId = "<some AAD user or service princpal object Id>";
            ledgerClient.CreateOrUpdateUser(
                newUserAadObjectId,
                RequestContent.Create(new { assignedRole = "Reader" }));

            #endregion

            #region Snippet:Consortium

            Response consortiumResponse = ledgerClient.GetConsortiumMembers();
            string membersJson = new StreamReader(consortiumResponse.ContentStream).ReadToEnd();

            // Consortium members can manage and alter the Confidential Ledger, such as by replacing unhealthy nodes.
            Console.WriteLine(membersJson);

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
