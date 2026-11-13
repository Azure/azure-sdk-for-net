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

```C# Snippet:ConfidentialLedger_CreateClient
var ledgerClient = new ConfidentialLedgerClient(new Uri("https://my-ledger-url.confidential-ledger.azure.com"), new DefaultAzureCredential());
```

> Security Note: By default when a confidential ledger Client is created it will connect to Azure's confidential ledger Identity Service to obtain the latest TLS service certificate for your Ledger in order to secure connections to Ledger Nodes. The details of this process are available in [this sample][client_construction_sample]. This behavior can be overridden by setting the `options` argument when creating the Ledger Client.
>
> `ConfidentialLedgerClientOptions.VerifyConnection` defaults to `true`, which verifies node TLS certificates against the trusted identity service certificate. Set `VerifyConnection = false` only for development or testing scenarios.

## Key concepts

### Ledger entries

Every write to Azure confidential ledger generates an immutable ledger entry in the service. Writes are uniquely identified by transaction ids that increment with each write.

```C# Snippet:ConfidentialLedger_AppendToLedger
Operation postOperation = ledgerClient.PostLedgerEntry(
    waitUntil: WaitUntil.Completed,
    RequestContent.Create(
        new { contents = "Hello world!" }));

string transactionId = postOperation.Id;
Console.WriteLine($"Appended transaction with Id: {transactionId}");
```

Since Azure confidential ledger is a distributed system, rare transient failures may cause writes to be lost. For entries that must be preserved, it is advisable to verify that the write became durable. Note: It may be necessary to call `GetTransactionStatus` multiple times until it returns a "Committed" status. However, when calling `PostLedgerEntry`, a successful result indicates that the status is "Committed".

```C# Snippet:ConfidentialLedger_GetStatus
Response statusResponse = ledgerClient.GetTransactionStatus(transactionId, new RequestContext());

string status = JsonDocument.Parse(statusResponse.Content)
    .RootElement
    .GetProperty("state")
    .GetString();

Console.WriteLine($"Transaction status: {status}");

// Wait for the entry to be committed
while (status == "Pending")
{
    statusResponse = ledgerClient.GetTransactionStatus(transactionId, new RequestContext());
    status = JsonDocument.Parse(statusResponse.Content)
        .RootElement
        .GetProperty("state")
        .GetString();
}

Console.WriteLine($"Transaction status: {status}");
```

### Redirect handling

The `ConfidentialLedgerClient` automatically follows HTTP 307 and 308 redirects while preserving the `Authorization` header. This is required because Azure confidential ledger routes write operations to the primary node, and non-primary nodes may return redirects.

The SDK also caches the latest primary node URL from redirect responses and reuses it for subsequent non-`GET` requests to reduce extra network round-trips for write-heavy workloads.

No additional configuration is required to enable this behavior.

### Read failover and retry behavior

The client discovers failover ledgers through the configured confidential ledger Identity Service. Failover is limited to the synchronous and asynchronous `GetLedgerEntry` and `GetCurrentLedgerEntry` methods. Writes, receipts, governance operations, transaction status, ranged queries, and all other `GET` operations remain on the primary ledger.

Failover occurs for HTTP 408, 429, and 5xx responses and for retryable transport failures such as connection failures and network timeouts. The primary endpoint first consumes its normal `Retry.MaxRetries` budget. Each discovered failover endpoint then receives a fresh, independent retry budget. Caller-requested cancellation stops immediately and never triggers discovery or failover. If discovery is unavailable, metadata is malformed, or every failover fails, the original primary response or exception is surfaced.

```C#
var options = new ConfidentialLedgerClientOptions
{
    Failover = ConfidentialLedgerClientOptions.FailoverSelection.Ordered,
    FailoverNetworkTimeout = TimeSpan.FromSeconds(30),
};
options.Retry.MaxRetries = 3;

var ledgerClient = new ConfidentialLedgerClient(ledgerEndpoint, credential, options);
```

`Ordered` uses the Identity Service order. `Random` shuffles candidates independently for each request. `FailoverNetworkTimeout`, when set, replaces the network timeout for each failover endpoint attempt; it does not create an overall operation deadline. Use the request `CancellationToken` for an overall deadline.

`GetLedgerEntry` automatically re-polls a successful response whose state is `Loading`. The configured `Retry.MaxRetries` bounds the additional loading polls and `Retry.Delay` controls their spacing.

Collection pruning can remove the live value while retaining its history. Archived fallback is disabled by default because the service returns the same 404 for a pruned collection and a collection that never existed, and searching ledger history can be expensive on a ledger with a long transaction history. To transparently query history and return the latest retained entry, including tags, explicitly set `EnableArchivedCollectionFallback = true`. A missing collection still surfaces the original 404 when history contains no entry.

```C#
var options = new ConfidentialLedgerClientOptions
{
    EnableArchivedCollectionFallback = true,
};
var ledgerClient = new ConfidentialLedgerClient(ledgerEndpoint, credential, options);
```

Each endpoint uses its own transport pipeline and the TLS identity certificate returned by the independently validated Identity Service is pinned specifically to that endpoint's ledger id. A certificate trusted for one ledger is not accepted for another ledger, including during concurrent failover. Custom transports remain in use; their TLS behavior remains the custom transport owner's responsibility. Do not disable `VerifyConnection` in production.

#### Receipts

State changes to the a confidential ledger are saved in a data structure called a Merkle tree. To cryptographically verify that writes were correctly saved, a Merkle proof, or receipt, can be retrieved for any transaction id.

```C# Snippet:ConfidentialLedger_GetReceipt
Response receiptResponse = ledgerClient.GetReceipt(transactionId, new RequestContext());
string receiptJson = new StreamReader(receiptResponse.ContentStream).ReadToEnd();

Console.WriteLine(receiptJson);
```

#### Collections

While most use cases will involve one ledger, we provide the collections feature in case different logical groups of data need to be stored in the same confidential ledger.

```C# Snippet:ConfidentialLedger_Collection
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

```C# Snippet:ConfidentialLedger_NoCollectionId
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
    getByCollectionResponse = ledgerClient.GetLedgerEntry(transactionId, collectionId, new RequestContext());
    rootElement = JsonDocument.Parse(getByCollectionResponse.Content).RootElement;
    loaded = rootElement.GetProperty("state").GetString() != "Loading";
}

string contents = rootElement
    .GetProperty("entry")
    .GetProperty("contents")
    .GetString();

Console.WriteLine(contents); // "Hello world!"

// Now just provide the transactionId.
getByCollectionResponse = ledgerClient.GetLedgerEntry(transactionId, null, new RequestContext());

string collectionId2 = JsonDocument.Parse(getByCollectionResponse.Content)
    .RootElement
    .GetProperty("entry")
    .GetProperty("collectionId")
    .GetString();

Console.WriteLine($"{collectionId} == {collectionId2}");
```

Ledger entries are retrieved from collections. When a transaction id is specified, the returned value is the value contained in the specified collection at the point in time identified by the transaction id. If no transaction id is specified, the latest available value is returned.

```C# Snippet:ConfidentialLedger_GetEnteryWithNoTransactionId
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
    statusResponse = ledgerClient.GetTransactionStatus(transactionId, new RequestContext());
    status = JsonDocument.Parse(statusResponse.Content)
        .RootElement
        .GetProperty("state")
        .GetString();
}

// The ledger entry written at the transactionId in firstResponse is retrieved from the default collection.
Response getResponse = ledgerClient.GetLedgerEntry(transactionId, null, new RequestContext());

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
        getResponse = ledgerClient.GetLedgerEntry(transactionId, collectionId, new RequestContext());
    }
}

string firstEntryContents = JsonDocument.Parse(getResponse.Content)
    .RootElement
    .GetProperty("entry")
    .GetProperty("contents")
    .GetString();

Console.WriteLine(firstEntryContents); // "Hello world 0"

// This will return the latest entry available in the default collection.
getResponse = ledgerClient.GetCurrentLedgerEntry(null, new RequestContext());

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
        getResponse = ledgerClient.GetCurrentLedgerEntry(null, new RequestContext());
    }
}

Console.WriteLine($"The latest ledger entry from the default collection is {latestDefaultCollection}"); //"Hello world 1"

// The ledger entry written at collectionTransactionId is retrieved from the collection 'collection'.
string collectionTransactionId = collectionPostOperation.Id;

getResponse = ledgerClient.GetLedgerEntry(collectionTransactionId, "my collection", new RequestContext());
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
        getResponse = ledgerClient.GetLedgerEntry(collectionTransactionId, "my collection", new RequestContext());
    }
}

Console.WriteLine(collectionEntry); // "Hello world collection 0"

// This will return the latest entry available in the collection.
getResponse = ledgerClient.GetCurrentLedgerEntry("my collection", new RequestContext());
string latestCollection = JsonDocument.Parse(getResponse.Content)
    .RootElement
    .GetProperty("contents")
    .GetString();

Console.WriteLine($"The latest ledger entry from the collection is {latestCollection}"); // "Hello world collection 1"
```

##### Ranged queries

Ledger entries in a collection may be retrieved over a range of transaction ids.
Note: Both ranges are optional; they can be provided individually or not at all.

```C# Snippet:ConfidentialLedger_RangedQuery
ledgerClient.GetLedgerEntries(fromTransactionId: "2.1", toTransactionId: collectionTransactionId);
```
#### Tags
It is possible to further organize data within a collection as part of the latest preview version dated `2024-12-09-preview` or newer.

Specify the `tags` parameter as part of the create entry operation. Multiple tags can be specified using commas. There is a limit of five tags per transaction.

```C# Snippet:ConfidentialLedger_CreateLedgerEntryWithTags
RequestContent content = RequestContent.Create(new { contents = "Hello world with tags!" });
string collectionId = "my-collection";
string tags = "tag1,tag2";

Response result = await client.CreateLedgerEntryAsync(content, collectionId, tags);
```

```C# Snippet:ConfidentialLedger_GetLedgerEntriesWithTags
string collectionIdForQuery = "my-collection";

// Specify collection ID and tag. Optionally add a range of transaction IDs.
// Only one tag is permitted in each retrieval operation.
var queryResult = client.GetLedgerEntriesAsync(collectionIdForQuery, tag: "tag1");
```
### User management

Users are managed directly with the confidential ledger instead of through Azure. New users may be AAD-based or certificate-based.

```C# Snippet:ConfidentialLedger_NewUser
string newUserAadObjectId = "<some AAD user or service principal object Id>";
ledgerClient.CreateOrUpdateLedgerUser(
    newUserAadObjectId,
    RequestContent.Create(new { assignedRoles = new[] { "Reader" } }));
```


### Confidential consortium and enclave verifications

One may want to validate details about the confidential ledger for a variety of reasons. For example, you may want to view details about how Microsoft may manage your confidential ledger as part of [Confidential Consortium Framework governance](https://microsoft.github.io/CCF/main/governance/index.html), or verify that your confidential ledger is indeed running in SGX enclaves. A number of client methods are provided for these use cases.

```C# Snippet:ConfidentialLedger_Consortium
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
```

[Microsoft Azure Attestation Service](https://azure.microsoft.com/services/azure-attestation/) is one provider of SGX enclave quotes.

### Ledger Gateway (opt-in)

The confidential ledger can be fronted by the **Ledger Gateway**, which terminates TLS with publicly-rooted certificates and can queue write submissions so callers can submit-and-disconnect instead of holding a connection open against a CCF primary node. Opt in by setting `ConfidentialLedgerClientOptions.UseLedgerGateway = true`. When enabled, the SDK skips the CCF identity-service TLS bootstrap (the OS trust store is sufficient), and only `TokenCredential` authentication is supported (client-certificate / mTLS is rejected).

```C# Snippet:CreateClientLedgerGateway
var ledgerClient = new ConfidentialLedgerClient(
    ledgerEndpoint: new Uri("https://my-ledger-url.confidential-ledger.azure.com"),
    credential: new DefaultAzureCredential(),
    options: new ConfidentialLedgerClientOptions { UseLedgerGateway = true });
```

When the underlying CCF cluster is temporarily unreachable, `PostLedgerEntry` may return `202 Accepted`: the write is queued and the returned `Operation.Id` is the gateway-assigned `operationId`. Submit with `WaitUntil.Started` and persist the `operationId` so you can resume later:

```C# Snippet:PostLedgerEntryWaitUntilStarted
// When UseLedgerGateway = true and waitUntil is Started, the SDK accepts a 202 Accepted
// response and returns an operation whose Id is the gateway-assigned operationId.
Operation operation = ledgerClient.PostLedgerEntry(
    waitUntil: WaitUntil.Started,
    RequestContent.Create(new { contents = "Hello from the Ledger Gateway!" }));

string operationId = operation.Id;
Console.WriteLine($"Submitted ledger entry. Operation Id: {operationId}");

// The application can persist operationId and exit. The submission is durable on the
// server for the gateway's operation-record retention period.
```

Later — in a different process or after a restart — resume polling with the saved `operationId`. Rehydration performs no I/O until you start polling, and once the write commits `Operation.Id` flips to the CCF transaction id. Always bound the wait with a `CancellationToken`:

```C# Snippet:RehydratePostLedgerEntryOperation
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
```

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

The [samples directory][samples] includes end-to-end usage patterns:

- [Hello World — Create a client, append entries and check status](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/confidentialledger/Azure.Security.ConfidentialLedger/samples/Sample1_HelloWorld.md)
- [Collections — Organize entries by collection](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/confidentialledger/Azure.Security.ConfidentialLedger/samples/Sample2_Collections.md)
- [Tags — Create and query entries with tags](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/confidentialledger/Azure.Security.ConfidentialLedger/samples/Sample3_Tags.md)
- [Users and Consortium — Manage users and view consortium info](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/confidentialledger/Azure.Security.ConfidentialLedger/samples/Sample4_UsersAndConsortium.md)
- [Advanced — Custom TLS certificate validation](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/confidentialledger/Azure.Security.ConfidentialLedger/samples/Sample5_Advanced.md)

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
[samples]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/confidentialledger/Azure.Security.ConfidentialLedger/samples
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
