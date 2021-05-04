# Azure Confidential Ledger client library for .NET

Azure Confidential Ledger provides a service for logging to an immutable, tamper-proof ledger. As part of the [Azure Confidential Computing][azure_confidential_computing]
portfolio, Azure Confidential Ledger runs in SGX enclaves. It is built on Microsoft Research's [Confidential Consortium Framework][ccf].

  [Source code][client_src] | [Package (NuGet)][client_nuget_package] <!--| [API reference documentation][api_reference] | [Samples][samples] -->

## Getting started

This section should include everything a developer needs to do to install and create their first client connection *very quickly*.

### Install the package
Install the Azure Tables client library for .NET with [NuGet][table_client_nuget_package]:

```
dotnet add package Azure.Storage.ConfidentialLedger --prerelease
```

### Prerequisites
* An [Azure subscription][azure_sub].
* A running instance of Azure Confidential Ledger.
* A registered user in the Confidential Ledger (typically assigned during [ARM](azure_resource_manager) resource creation) with `Administrator` privileges.

### Authenticate the client

#### Using Azure Active Directory

This document demonstrates using [DefaultAzureCredential][default_cred_ref] to authenticate to the Confidential Ledger via Azure Active Directory.
However, `ConfidentialLedgerClient` accepts any [Azure.Identity][azure_identity] token credential. See the [Azure.Identity][azure_identity] documentation
for more information about other credentials.

#### Using a client certificate

As an alternative to Azure Active Directory, clients may choose to use a client certificate to authenticate via mutual TLS.

### Create a client
`DefaultAzureCredential` will automatically handle most Azure SDK client scenarios. To get started, set environment variables for the AAD identity registered with your Confidential Ledger.
```bash
export AZURE_CLIENT_ID="generated app id"
export AZURE_CLIENT_SECRET="random password"
export AZURE_TENANT_ID="tenant id"
```
Then, `DefaultAzureCredential` will be able to authenticate the `ConfidentialLedgerClient`.

Constructing the client also requires your Confidential Ledger's URL and id, which you can get from the Azure CLI or the Azure Portal. When you have retrieved those values, please replace instances of `"my-ledger-id"` and `"https://my-ledger-url.confidential-ledger.azure.com"` in the examples below

Because Confidential Ledgers use self-signed certificates securely generated and stored in an SGX enclave, the certificate for each Confidential Ledger must first be retrieved from the Confidential Ledger Identity Service.

```python
from azure.identity import DefaultAzureCredential
from azure.confidentialledger import ConfidentialLedgerClient
from azure.confidentialledger.identity_service import ConfidentialLedgerIdentityServiceClient

identity_client = ConfidentialLedgerIdentityServiceClient("https://identity.accledger.azure.com")
network_identity = identity_client.get_ledger_identity(
    ledger_id="my-ledger-id"
)

ledger_tls_cert_file_name = "ledger_certificate.pem"
with open(ledger_tls_cert_file_name, "w") as cert_file:
    cert_file.write(network_identity.ledger_tls_certificate)

credential = DefaultAzureCredential()
ledger_client = ConfidentialLedgerClient(
    endpoint="https://my-ledger-url.confidential-ledger.azure.com", 
    credential=credential,
    ledger_certificate_path=ledger_tls_cert_file_name
)
```

## Key concepts
### Ledger entries
Every write to Confidential Ledger generates an immutable ledger entry in the service. Writes are uniquely identified by transaction ids that increment with each write.
```python
append_result = ledger_client.append_to_ledger(entry_contents="Hello world!")
print(append_result.transaction_id)
```

Since Confidential Ledger is a distributed system, rare transient failures may cause writes to be lost. For entries that must be preserved, it is advisable to verify that the write became durable. Waits are blocking calls.
```python
from azure.confidentialledger import TransactionState
ledger_client.wait_until_durable(transaction_id=append_result.transaction_id)
assert ledger_client.get_transaction_status(
    transaction_id=append_result.transaction_id
) is TransactionState.COMMITTED

# Alternatively, a client may wait when appending.
append_result = ledger_client.append_to_ledger(
    entry_contents="Hello world, again!", wait_for_commit=True
)
assert ledger_client.get_transaction_status(
    transaction_id=append_result.transaction_id
) is TransactionState.COMMITTED
```

#### Receipts
State changes to the Confidential Ledger are saved in a data structure called a Merkle tree. To cryptographically verify that writes were correctly saved, a Merkle proof, or receipt, can be retrieved for any transaction id.
```python
receipt = ledger_client.get_transaction_receipt(
    transaction_id=append_result.transaction_id
)
print(receipt.contents)
```

#### Sub-ledgers
While most use cases will involve one ledger, we provide the sub-ledger feature in case different logical groups of data need to be stored in the same Confidential Ledger.
```python
ledger_client.append_to_ledger(
    entry_contents="Hello from Alice", sub_ledger_id="Alice's messages"
)
ledger_client.append_to_ledger(
    entry_contents="Hello from Bob", sub_ledger_id="Bob's messages"
)
```

When no sub-ledger id is specified on method calls, the Confidential Ledger service will assume a constant, service-determined sub-ledger id.
```python
append_result = ledger_client.append_to_ledger(entry_contents="Hello world?")

entry_by_subledger = ledger_client.get_ledger_entry(
    transaction_id=append_result.transaction_id,
    sub_ledger_id=append_result.sub_ledger_id
)
assert entry_by_subledger.contents == "Hello world?"

entry = ledger_client.get_ledger_entry(transaction_id=append_result.transaction_id)
assert entry.contents == entry_by_subledger.contents
assert entry.sub_ledger_id == entry_by_subledger.sub_ledger_id
```

Ledger entries are retrieved from sub-ledgers. When a transaction id is specified, the returned value is the value contained in the specified sub-ledger at the point in time identified by the transaction id. If no transaction id is specified, the latest available value is returned.
```python
append_result = ledger_client.append_to_ledger(entry_contents="Hello world 0")
ledger_client.append_to_ledger(entry_contents="Hello world 1")

subledger_append_result = ledger_client.append_to_ledger(
    entry_contents="Hello world sub-ledger 0"
)
ledger_client.append_to_ledger(entry_contents="Hello world sub-ledger 1")

entry = ledger_client.get_ledger_entry(transaction_id=append_result.transaction_id)
assert entry.contents == "Hello world 0"

latest_entry = ledger_client.get_ledger_entry()
assert latest_entry.contents == "Hello world 1"

subledger_entry = ledger_client.get_ledger_entry(
    transaction_id=append_result.transaction_id,
    sub_ledger_id=append_result.sub_ledger_id
)
assert subledger_entry.contents == "Hello world sub-ledger 0"

subledger_latest_entry = ledger_client.get_ledger_entry(
    sub_ledger_id=subledger_append_result.sub_ledger_id
)
assert subledger_latest_entry.contents == "Hello world sub-ledger 1"
```

##### Ranged queries
Ledger entries in a sub-ledger may be retrieved over a range of transaction ids.
```python
ranged_result = ledger_client.get_ledger_entries(
    from_transaction_id="12.3"
)
for entry in ranged_result:
    print(f"Transaction id {entry.transaction_id} contents: {entry.contents}")
```

### User management
Users are managed directly with the Confidential Ledger instead of through Azure. New users may be AAD-based or certificate-based.
```python
from azure.confidentialledger import LedgerUserRole
user_id = "some AAD object id"
user = ledger_client.create_or_update_user(
    user_id, LedgerUserRole.CONTRIBUTOR
)
# A client may now be created and used with AAD credentials for the user identified by `user_id`.

user = ledger_client.get_user(user_id)
assert user.id == user_id
assert user.role == LedgerUserRole.CONTRIBUTOR

ledger_client.delete_user(user_id)

# For a certificated-based user, their user ID is the fingerprint for their PEM certificate.
user_id = "PEM certificate fingerprint"
user = ledger_client.create_or_update_user(
    user_id, LedgerUserRole.READER
)
```

#### Certificate-based users
Clients may authenticate with a client certificate in mutual TLS instead of via Azure Active Directory. `ConfidentialLedgerCertificateCredential` is provided for such clients.
```python
from azure.confidentialledger import ConfidentialLedgerClient, ConfidentialLedgerCertificateCredential
from azure.confidentialledger.identity_service import ConfidentialLedgerIdentityServiceClient

identity_client = ConfidentialLedgerIdentityServiceClient("https://identity.accledger.azure.com")
network_identity = identity_client.get_ledger_identity(
    ledger_id="my-ledger-id"
)

ledger_tls_cert_file_name = "ledger_certificate.pem"
with open(ledger_tls_cert_file_name, "w") as cert_file:
    cert_file.write(network_identity.ledger_tls_certificate)

credential = ConfidentialLedgerCertificateCredential("path to user certificate PEM")
ledger_client = ConfidentialLedgerClient(
    endpoint="https://my-ledger-url.confidential-ledger.azure.com", 
    credential=credential,
    ledger_certificate_path=ledger_tls_cert_file_name
)
```

### Confidential consortium and enclave verifications
One may want to validate details about the Confidential Ledger for a variety of reasons. For example, you may want to view details about how Microsoft may manage your Confidential Ledger as part of [Confidential Consortium Framework governance](https://microsoft.github.io/CCF/main/governance/index.html), or verify that your Confidential Ledger is indeed running in SGX enclaves. A number of client methods are provided for these use cases.
```python
consortium = ledger_client.get_consortium()
# Consortium members can manage and alter the Confidential Ledger, such as by replacing unhealthy
# nodes.
for member in consortium.members:
    print(member.certificate)
    print(member.id)

import hashlib
# The constitution is a collection of JavaScript code that defines actions available to members,
# and vets proposals by members to execute those actions.
constitution = ledger_client.get_constitution()
assert constitution.digest.lower() == hashlib.sha256(constitution.contents.encode()).hexdigest().lower()
print(constitution.contents)
print(constitution.digest)

# SGX enclave quotes contain material that can be used to cryptographically verify the validity and
# contents of an enclave.
ledger_enclaves = ledger_client.get_enclave_quotes()
assert ledger_enclaves.source_node in ledger_enclaves.quotes
for node_id, quote in ledger_enclaves.quotes.items():
    assert node_id == quote.node_id
    print(quote.node_id)
    print(quote.mrenclave)
    print(quote.raw_quote)
    print(quote.version)
```

[Microsoft Azure Attestation Service](https://azure.microsoft.com/en-us/services/azure-attestation/) is one provider of SGX enclave quotes.

### Async API
This library includes a complete async API supported on Python 3.5+. To use it, you must first install an async transport, such as [aiohttp](https://pypi.org/project/aiohttp). See [azure-core documentation](https://github.com/Azure/azure-sdk-for-python/blob/master/sdk/core/azure-core/CLIENT_LIBRARY_DEVELOPER.md#transport) for more information.

Async clients should be closed when they're no longer needed. These objects are async context managers and define async `close` methods. For example:

```python
from azure.identity.aio import DefaultAzureCredential
from azure.confidentialledger.aio import ConfidentialLedgerClient
from azure.confidentialledger.identity_service.aio import ConfidentialLedgerIdentityServiceClient

identity_client = ConfidentialLedgerIdentityServiceClient("https://identity.accledger.azure.com")
network_identity = await identity_client.get_ledger_identity(
    ledger_id="my-ledger-id"
)

ledger_tls_cert_file_name = "ledger_certificate.pem"
with open(ledger_tls_cert_file_name, "w") as cert_file:
    cert_file.write(network_identity.ledger_tls_certificate)

credential = DefaultAzureCredential()
ledger_client = ConfidentialLedgerClient(
    endpoint="https://my-ledger-url.confidential-ledger.azure.com", 
    credential=credential,
    ledger_certificate_path=ledger_tls_cert_file_name
)

# Call close when the client and credential are no longer needed.
await client.close()
await credential.close()

# Alternatively, use them as async context managers (contextlib.AsyncExitStack can help).
ledger_client = ConfidentialLedgerClient(
    endpoint="https://my-ledger-url.confidential-ledger.azure.com", 
    credential=credential,
    ledger_certificate_path=ledger_tls_cert_file_name
)
async with client:
    async with credential:
        pass
```


### Thread safety

We guarantee that all client instance methods are thread-safe and independent of each other ([guideline](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-service-methods-thread-safety)). This ensures that the recommendation of reusing client instances is always safe, even across threads.

### Additional concepts

<!-- CLIENT COMMON BAR -->
[Client options](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/core/Azure.Core/README.md#configuring-service-clients-using-clientoptions) |
[Accessing the response](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/core/Azure.Core/README.md#accessing-http-response-details-using-responset) |
[Long-running operations](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/core/Azure.Core/README.md#consuming-long-running-operations-using-operationt) |
[Handling failures](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/core/Azure.Core/README.md#reporting-errors-requestfailedexception) |
[Diagnostics](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/core/Azure.Core/samples/Diagnostics.md) |
[Mocking](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/core/Azure.Core/README.md#mocking) |
[Client lifetime](https://devblogs.microsoft.com/azure-sdk/lifetime-management-and-thread-safety-guarantees-of-azure-sdk-net-clients/)
<!-- CLIENT COMMON BAR -->

## Examples

Include code snippets and short descriptions for each task you listed in the [Introduction](#introduction) (the bulleted list). Briefly explain each operation, but include enough clarity to explain complex or otherwise tricky operations.

If possible, use the same example snippets that your in-code documentation uses. For example, use the snippets in your `examples.py` that Sphinx ingests via its [literalinclude](https://www.sphinx-doc.org/en/1.5/markup/code.html?highlight=code%20examples#includes) directive. The `examples.py` file containing the snippets should reside alongside your package's code, and should be tested in an automated fashion.

Each example in the *Examples* section starts with an H3 that describes the example. At the top of this section, just under the *Examples* H2, add a bulleted list linking to each example H3. Each example should deep-link to the types and/or members used in the example.

* [Create the thing](#create-the-thing)
* [Get the thing](#get-the-thing)
* [List the things](#list-the-things)

### Create the thing

Use the `create_thing` method to create a Thing reference; this method does not make a network call. To persist the Thing in the service, call `Thing.save`.

```Python
thing = client.create_thing(id, name)
thing.save()
```

### Get the thing

The `get_thing` method retrieves a Thing from the service. The `id` parameter is the unique ID of the Thing, not its "name" property.

```C# Snippet:GetSecret
var client = new MiniSecretClient(new Uri(endpoint), new DefaultAzureCredential());

SecretBundle secret = client.GetSecret("TestSecret");

Console.WriteLine(secret.Value);
```Python
things = client.list_things()
```

## Troubleshooting

Describe common errors and exceptions, how to "unpack" them if necessary, and include guidance for graceful handling and recovery.

Provide information to help developers avoid throttling or other service-enforced errors they might encounter. For example, provide guidance and examples for using retry or connection policies in the API.

If the package or a related package supports it, include tips for logging or enabling instrumentation to help them debug their code.

## Next steps

* Provide a link to additional code examples, ideally to those sitting alongside the README in the package's `/samples` directory.
* If appropriate, point users to other packages that might be useful.
* If you think there's a good chance that developers might stumble across your package in error (because they're searching for specific functionality and mistakenly think the package provides that functionality), point them to the packages they might be looking for.

## Contributing

This is a template, but your SDK readme should include details on how to contribute code to the repo/package.

<!-- LINKS -->
[style-guide-msft]: https://docs.microsoft.com/style-guide/capitalization
[style-guide-cloud]: https://aka.ms/azsdk/cloud-style-guide
[client_src]: https://github.com/azure/azure-sdk-for-net/sdk/confidentialledger
[client_nuget_package]: https://www.nuget.org/packages?q=Azure.Data.ConfidentialLedger
[azure_cli]: https://docs.microsoft.com/en-us/cli/azure
[azure_cloud_shell]: https://shell.azure.com/bash
[azure_confidential_computing]: https://azure.microsoft.com/en-us/solutions/confidential-compute
[azure_sub]: https://azure.microsoft.com/free
[ccf]: https://github.com/Microsoft/CCF
[azure_identity]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/identity/Azure.Identity
[azure_resource_manager]: https://docs.microsoft.com/en-us/azure/azure-resource-manager/management/overview
[code_of_conduct]: https://opensource.microsoft.com/codeofconduct
[code_of_conduct_faq]: https://opensource.microsoft.com/codeofconduct/faq
![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net%2Fsdk%2Fconfidentialledger%2FAzure.Template%2FREADME.png)
