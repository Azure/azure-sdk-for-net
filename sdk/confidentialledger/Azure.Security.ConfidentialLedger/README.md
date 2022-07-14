# Azure confidential ledger client library for .NET

Azure confidential ledger provides a service for logging to an immutable, tamper-proof ledger. As part of the [Azure Confidential Computing][azure_confidential_computing]
portfolio, Azure confidential ledger runs in SGX enclaves. It is built on Microsoft Research's [Confidential Consortium Framework][ccf].

  [Source code][client_src] | [Package (NuGet)][client_nuget_package] <!--| [API reference documentation][api_reference] | [Samples][samples] -->

## Getting started

This section should include everything a developer needs to do to install and create their first client connection *very quickly*.

### Install the package

Install the Azure confidential ledger client library for .NET with [NuGet][client_nuget_package]:

```dotnetcli
dotnet add package Azure.Security.ConfidentialLedger --prerelease
```

### Prerequisites

* An [Azure subscription][azure_sub].
* A running instance of Azure confidential ledger.
* A registered user in the confidential ledger with `Administrator` privileges.

### Authenticate the client

#### Using Azure Active Directory

This document demonstrates using [DefaultAzureCredential][default_cred_ref] to authenticate to the confidential ledger via Azure Active Directory. However, any of the credentials offered by the [Azure.Identity][azure_identity] will be accepted.  See the [Azure.Identity][azure_identity] documentation for more information about other credentials.

#### Using a client certificate

As an alternative to Azure Active Directory, clients may choose to use a client certificate to authenticate via mutual TLS.

### Create a client

`DefaultAzureCredential` will automatically handle most Azure SDK client scenarios. To get started, set environment variables for the AAD identity registered with your confidential ledger.
```bash
export AZURE_CLIENT_ID="generated app id"
export AZURE_CLIENT_SECRET="random password"
export AZURE_TENANT_ID="tenant id"
```
Then, `DefaultAzureCredential` will be able to authenticate the `ConfidentialLedgerClient`.

Constructing the client also requires your confidential ledger's URL and id, which you can get from the Azure CLI or the Azure Portal.  When you have retrieved those values, please replace instances of `"my-ledger-id"` and `"https://my-ledger-url.confidential-ledger.azure.com"` in the examples below

Because Azure confidential ledger uses self-signed certificates securely generated and stored in an SGX enclave, the certificate for each confidential ledger  must first be retrieved from the Azur confidential ledger Identity Service.

```C# Snippet:GetIdentity
Uri identityServiceEndpoint = new("https://identity.confidential-ledger.core.azure.com") // The hostname from the identityServiceUri
var identityClient = new ConfidentialLedgerIdentityServiceClient(identityServiceEndpoint);

// Get the ledger's  TLS certificate for our ledger.
string ledgerId = "<the ledger id>"; // ex. "my-ledger" from "https://my-ledger.eastus.cloudapp.azure.com"
Response response = identityClient.GetLedgerIdentity(ledgerId);
X509Certificate2 ledgerTlsCert = ConfidentialLedgerIdentityServiceClient.ParseCertificate(response);
```

Now we can construct the `ConfidentialLedgerClient` with a transport configuration that trusts the `ledgerTlsCert`.

```C# Snippet:CreateClient
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
var ledgerClient = new ConfidentialLedgerClient(TestEnvironment.ConfidentialLedgerUrl, new DefaultAzureCredential(), options);
```

## Key concepts

### Ledger entries

Every write to a confidential ledger generates an immutable ledger entry in the service. Writes are uniquely identified by transaction ids that increment with each write.

```C# Snippet:AppendToLedger
PostLedgerEntryOperation postOperation = ledgerClient.PostLedgerEntry(
    waitUntil: WaitUntil.Completed,
    RequestContent.Create(
        new { contents = "Hello world!" })) as PostLedgerEntryOperation;

string transactionId = postOperation.Id;
Console.WriteLine($"Appended transaction with Id: {transactionId}");
```

Since Azure confidential ledger is a distributed system, rare transient failures may cause writes to be lost. For entries that must be preserved, it is advisable to verify that the write became durable. Note: It may be necessary to call `GetTransactionStatus` multiple times until it returns a "Committed" status. However, when calling `PostLedgerEntry`, a successful result indicates that the status is "Committed".

```C# Snippet:GetStatus
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
```

#### Receipts

State changes to the confidential ledger are saved in a data structure called a Merkle tree. To cryptographically verify that writes were correctly saved, a Merkle proof, or receipt, can be retrieved for any transaction id.

```C# Snippet:GetReceipt
Response receiptResponse = ledgerClient.GetReceipt(transactionId);
string receiptJson = new StreamReader(receiptResponse.ContentStream).ReadToEnd();

Console.WriteLine(receiptJson);
```

#### Collections

While most use cases will involve one ledger, we provide the "collections" feature in case different logical groups of data need to be stored in the same confidential ledger.

```C# Snippet:Collection
ledgerClient.PostLedgerEntry(
    waitUntil: WaitUntil.Completed,
    RequestContent.Create(
        new { contents = "Hello from Chris!", collectionId = "Chris' messages" }));

ledgerClient.PostLedgerEntry(
    waitUntil: WaitUntil.Completed,
    RequestContent.Create(
        new { contents = "Hello from Allison!", collectionId = "Allison's messages" }));
```

When no collection id is specified on method calls, the Azure confidential ledger service will assume a constant, service-determined collection id.

```C# Snippet:NocollectionId
Response postResponse = ledgerClient.PostLedgerEntry(
waitUntil: WaitUntil.Completed,
    RequestContent.Create(
        new { contents = "Hello world!" })) as PostLedgerEntryOperation;
string transactionId = postOperation.Id;
string collectionId = "collection:0";

// Provide both the transactionId and collectionId.
Response getByCollectionResponse = ledgerClient.GetLedgerEntry(transactionId,  collectionId);

// Try until the entry is available.
bool loaded = false;
JsonElement element = default;
string contents = null;
while (!loaded)
{
    loaded = JsonDocument.Parse(getByCollectionResponse.Content)
        .RootElement
        .TryGetProperty("entry", out element);
    if (loaded)
    {
        contents = element.GetProperty("contents").GetString();
    }
    else
    {
        getByCollectionResponse = ledgerClient.GetLedgerEntry(transactionId, collectionId);
    }
}

Console.WriteLine(contents); // "Hello world!"

// Now just provide the transactionId.
getByCollectionResponse = ledgerClient.GetLedgerEntry(transactionId);

string collectionId2 = JsonDocument.Parse(getByCollectionResponse.Content)
    .RootElement
    .GetProperty("entry")
    .GetProperty("collectionId")
    .GetString();

Console.WriteLine($"{collectionId} == {collectionId2}");
```

Ledger entries are retrieved from collections. When a transaction id is specified, the returned value is the value contained in the specified collection at the point in time identified by the transaction id. If no transaction id is specified, the latest available value is returned.

```C# Snippet:GetEnteryWithNoTransactionId
PostLedgerEntryOperation firstPostOperation = ledgerClient.PostLedgerEntry(
    waitUntil: WaitUntil.Completed,
    RequestContent.Create(new { contents = "Hello world 0" })) as PostLedgerEntryOperation;
ledgerClient.PostLedgerEntry(
    waitUntil: WaitUntil.Completed,
    RequestContent.Create(new { contents = "Hello world 1" }));
PostLedgerEntryOperation subLedgerPostOperation = ledgerClient.PostLedgerEntry(
    waitUntil: WaitUntil.Completed,
    RequestContent.Create(new { contents = "Hello world collection 0" }),
    "my collection") as PostLedgerEntryOperation;
ledgerClient.PostLedgerEntry(
    waitUntil: WaitUntil.Completed,
    RequestContent.Create(new { contents = "Hello world collection 1" }),
    "my collection");
string transactionId = firstPostOperation.Id;

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

Console.WriteLine($"The latest ledger entry from the default collection is {latestDefaultSubLedger}"); //"Hello world 1"

// The ledger entry written at subLedgerTransactionId is retrieved from the collection 'collection'.
string subLedgerTransactionId = subLedgerPostOperation.Id;

getResponse = ledgerClient.GetLedgerEntry(subLedgerTransactionId, "my collection");
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
        getResponse = ledgerClient.GetLedgerEntry(subLedgerTransactionId, "my collection");
    }
}

Console.WriteLine(subLedgerEntry); // "Hello world collection 0"

// This will return the latest entry available in the collection.
getResponse = ledgerClient.GetCurrentLedgerEntry("my collection");
string latestSubLedger = JsonDocument.Parse(getResponse.Content)
    .RootElement
    .GetProperty("contents")
    .GetString();

Console.WriteLine($"The latest ledger entry from the collection is {latestSubLedger}"); // "Hello world collection 1"
```

##### Ranged queries

Ledger entries in a collection may be retrieved over a range of transaction ids.
Note: Both ranges are optional; they can be provided individually or not at all.

```C# Snippet:RangedQuery
ledgerClient.GetLedgerEntries(fromTransactionId: "2.1", toTransactionId: subLedgerTransactionId);
```

### User management

Users are managed directly with the confidential ledger instead of through Azure. New users may be AAD-based or certificate-based.

```C# Snippet:NewUser
string newUserAadObjectId = "<some AAD user or service princpal object Id>";
ledgerClient.CreateOrUpdateUser(
    newUserAadObjectId,
    RequestContent.Create(new { assignedRole = "Reader" }));
```


### Confidential consortium and enclave verifications

One may want to validate details about the confidential ledger for a variety of reasons. For example, you may want to view details about how Microsoft may manage your confidential ledger as part of [Confidential Consortium Framework governance](https://microsoft.github.io/CCF/main/governance/index.html), or verify that your confidential ledger is indeed running in SGX enclaves. A number of client methods are provided for these use cases.

```C# Snippet:Consortium
Response consortiumResponse = ledgerClient.GetConsortiumMembers();
string membersJson = new StreamReader(consortiumResponse.ContentStream).ReadToEnd();

// Consortium members can manage and alter the confidential ledger, such as by replacing unhealthy nodes.
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
```

[Microsoft Azure Attestation Service](https://azure.microsoft.com/services/azure-attestation/) is one provider of SGX enclave quotes.

### Thread safety

We guarantee that all client instance methods are thread-safe and independent of each other ([guideline](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-service-methods-thread-safety)). This ensures that the recommendation of reusing client instances is always safe, even across threads.

### Additional concepts

<!-- CLIENT COMMON BAR -->
[Client options](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#configuring-service-clients-using-clientoptions) |
[Accessing the response](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#accessing-http-response-details-using-responset) |
[Long-running operations](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#consuming-long-running-operations-using-operationt) |
[Handling failures](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#reporting-errors-requestfailedexception) |
[Diagnostics](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Diagnostics.md) |
[Mocking](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#mocking) |
[Client lifetime](https://devblogs.microsoft.com/azure-sdk/lifetime-management-and-thread-safety-guarantees-of-azure-sdk-net-clients/)
<!-- CLIENT COMMON BAR -->

## Examples

Coming Soon...

## Troubleshooting

Response values returned from Azure confidential ledger client methods are `Response` objects, which contain information about the http response such as the http `Status` property and a `Headers` object containing more information about the failure.

### Setting up console logging

The simplest way to see the logs is to enable the console logging.
To create an Azure SDK log listener that outputs messages to console use AzureEventSourceListener.CreateConsoleLogger method.

```C#
// Setup a listener to monitor logged events.
using AzureEventSourceListener listener = AzureEventSourceListener.CreateConsoleLogger();
```

To learn more about other logging mechanisms see [here][logging].

## Next steps

For more extensive documentation on Azure confidential ledger, see the API [reference documentation](https://azure.github.io/azure-sdk-for-net/).
You may also read more about Microsoft Research's open-source Confidential [Consortium Framework][ccf].

## Contributing

This project welcomes contributions and suggestions.  Most contributions require
you to agree to a Contributor License Agreement (CLA) declaring that you have
the right to, and actually do, grant us the rights to use your contribution. For
details, visit [cla.microsoft.com][cla].

This project has adopted the [Microsoft Open Source Code of Conduct][coc].
For more information see the [Code of Conduct FAQ][coc_faq] or contact
[opencode@microsoft.com][coc_contact] with any additional questions or comments.

<!-- LINKS -->
[style-guide-msft]: https://docs.microsoft.com/style-guide/capitalization
[style-guide-cloud]: https://aka.ms/azsdk/cloud-style-guide
[client_src]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/confidentialledger/Azure.Security.ConfidentialLedger
[client_nuget_package]: https://www.nuget.org/packages?q=Azure.Security.ConfidentialLedger
[azure_cli]: https://docs.microsoft.com/cli/azure
[azure_cloud_shell]: https://shell.azure.com/bash
[azure_confidential_computing]: https://azure.microsoft.com/solutions/confidential-compute
[azure_sub]: https://azure.microsoft.com/free/dotnet/
[ccf]: https://github.com/Microsoft/CCF
[azure_identity]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/identity/Azure.Identity
[default_cred_ref]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md#defaultazurecredential
[logging]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Diagnostics.md
[coc]: https://opensource.microsoft.com/codeofconduct/
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq
[cla]: https://cla.microsoft.com
[coc_contact]: mailto:opencode@microsoft.com

![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net%2Fsdk%2Fconfidentialledger%2FAzure.Template%2FREADME.png)
