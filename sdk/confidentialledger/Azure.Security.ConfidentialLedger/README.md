# Azure confidential ledger client library for .NET

Azure confidential ledger provides a service for logging to an immutable, tamper-proof ledger. As part of the [Azure Confidential Computing][azure_confidential_computing]
portfolio, Azure confidential ledger runs in SGX enclaves. It is built on Microsoft Research's [Confidential Consortium Framework][ccf].

  [Source code][client_src] | [Package (NuGet)][client_nuget_package] <!--| [API reference documentation][api_reference] | [Samples][samples] -->

## Getting started

This section should include everything a developer needs to do to install and create their first client connection *very quickly*.

### Install the package

Install the Azure confidential ledger client library for .NET with [NuGet][client_nuget_package]:

```dotnetcli
dotnet add package Azure.Security.ConfidentialLedger
```

### Prerequisites

* An [Azure subscription][azure_sub].
* A running instance of Azure confidential ledger.
* A registered user in the Azure confidential ledger with `Administrator` privileges.

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

Constructing the client also requires your confidential ledger's URI, which you can obtain from the Azure Portal page for your confidential ledger in the `Ledger URI` field under the `Properties` section. When you have retrieved the `Ledger URI`, please use it to replace `"https://my-ledger-url.confidential-ledger.azure.com"` in the example below.

```C# Snippet:CreateClient
var ledgerClient = new ConfidentialLedgerClient(new Uri("https://my-ledger-url.confidential-ledger.azure.com"), new DefaultAzureCredential());
```

> Security Note: By default when a confidential ledger Client is created it will connect to Azure's confidential ledger Identity Service to obtain the latest TLS service certificate for your Ledger in order to secure connections to Ledger Nodes. The details of this process are available in [this sample][client_construction_sample]. This behavior can be overridden by setting the `options` argument when creating the Ledger Client.

## Key concepts

### Ledger entries

Every write to Azure confidential ledger generates an immutable ledger entry in the service. Writes are uniquely identified by transaction ids that increment with each write.

```C# Snippet:AppendToLedger
Operation postOperation = ledgerClient.PostLedgerEntry(
    waitUntil: WaitUntil.Completed,
    RequestContent.Create(
        new { contents = "Hello world!" }));

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

State changes to the a confidential ledger are saved in a data structure called a Merkle tree. To cryptographically verify that writes were correctly saved, a Merkle proof, or receipt, can be retrieved for any transaction id.

```C# Snippet:GetReceipt
Response receiptResponse = ledgerClient.GetReceipt(transactionId);
string receiptJson = new StreamReader(receiptResponse.ContentStream).ReadToEnd();

Console.WriteLine(receiptJson);
```

#### Collections

While most use cases will involve one ledger, we provide the collections feature in case different logical groups of data need to be stored in the same confidential ledger.

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

```C# Snippet:NoCollectionId
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
```

Ledger entries are retrieved from collections. When a transaction id is specified, the returned value is the value contained in the specified collection at the point in time identified by the transaction id. If no transaction id is specified, the latest available value is returned.

```C# Snippet:GetEnteryWithNoTransactionId
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
```

##### Ranged queries

Ledger entries in a collection may be retrieved over a range of transaction ids.
Note: Both ranges are optional; they can be provided individually or not at all.

```C# Snippet:RangedQuery
ledgerClient.GetLedgerEntries(fromTransactionId: "2.1", toTransactionId: collectionTransactionId);
```
#### Tags
It is possible to further organize data within a collection as part of the latest preview version dated `2024-12-09-preview` or newer.

Specify the `tags` parameter as part of the create entry operation. Multiple tags can be specified using commas. There is a limit of five tags per transaction.

```C#
string tags = "tag1,tag2";

Response result = await Client.CreateLedgerEntryAsync(content, collectionId, tags);
```

```C#

// Specify collection ID and tag. Optionally add a range of transaction IDs.
// Only one tag is permitted in each retrieval operation.
var result = Client.GetLedgerEntriesAsync(collectionId, "tag1");
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
[Mocking](https://learn.microsoft.com/dotnet/azure/sdk/unit-testing-mocking) |
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
[style-guide-msft]: https://learn.microsoft.com/style-guide/capitalization
[style-guide-cloud]: https://aka.ms/azsdk/cloud-style-guide
[client_src]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/confidentialledger/Azure.Security.ConfidentialLedger
[client_nuget_package]: https://www.nuget.org/packages?q=Azure.Security.ConfidentialLedger
[azure_cli]: https://learn.microsoft.com/cli/azure
[azure_cloud_shell]: https://shell.azure.com/bash
[azure_confidential_computing]: https://azure.microsoft.com/solutions/confidential-compute
[client_construction_sample]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/confidentialledger/Azure.Security.ConfidentialLedger/tests/samples/CertificateServiceSample.md
[azure_sub]: https://azure.microsoft.com/free/dotnet/
[ccf]: https://github.com/Microsoft/CCF
[azure_identity]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/identity/Azure.Identity
[default_cred_ref]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md#defaultazurecredential
[logging]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Diagnostics.md
[coc]: https://opensource.microsoft.com/codeofconduct/
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq
[cla]: https://cla.microsoft.com
[coc_contact]: mailto:opencode@microsoft.com
