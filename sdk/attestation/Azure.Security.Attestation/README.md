# README.md template

Use the guidelines in each section of this template to ensure consistency and readability of your README. The README resides in your package's GitHub repository at the root of its directory within the repo. It's also used as the package distribution page (NuGet, PyPi, npm, etc.) and as a Quickstart on docs.microsoft.com. See [Azure.Template/README.md](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/template/Azure.Template/README.md) for an example following this template.

**Title**: The H1 of your README should be in the format: `# [Product Name] client library for [Language]`

* All headings, including the H1, should use **sentence-style capitalization**. Refer to the [Microsoft Style Guide][style-guide-msft] and [Microsoft Cloud Style Guide][style-guide-cloud] for more information.
* Example: `# Azure Batch client library for Python`

# Azure Attestation client library for .NET

**Introduction**: The introduction appears directly under the title (H1) of your README.

* **DO NOT** use an "Introduction" or "Overview" heading (H2) for this section.
* First sentence: **Describe the service** briefly. You can usually use the first line of the service's docs landing page for this (Example: [Cosmos DB docs landing page](https://docs.microsoft.com/azure/cosmos-db/)).
* Next, add a **bulleted list** of the **most common tasks** supported by the package or library, prefaced with "Use the client library for [Product Name] to:". Then, provide code snippets for these tasks in the [Examples](#examples) section later in the document. Keep the task list short but include those tasks most developers need to perform with your package.
* Include this single line of links targeting your product's content at the bottom of the introduction, making any adjustments as necessary (for example, NuGet instead of PyPi):

  [Source code](https://github.com/Azure/azure-sdk-for-python/tree/master/sdk/batch/azure-batch) | [Package (PyPi)](https://pypi.org/project/azure-batch/) | [API reference documentation](https://docs.microsoft.com/python/api/overview/azure/batch?view=azure-python) | [Product documentation](https://docs.microsoft.com/azure/batch/)

> TIP: Your README should be as **brief** as possible but **no more brief** than necessary to get a developer new to Azure, the service, or the package up and running quickly. Keep it brief, but include everything a developer needs to make their first API call successfully.

## Getting started

This section should include everything a developer needs to do to install and create their first client connection *very quickly*.

### Install the package

First, provide instruction for obtaining and installing the package or library. This section might include only a single line of code, like `pip install package-name`, but should enable a developer to successfully install the package from NuGet, pip, npm, Maven, or even cloning a GitHub repository.

### Prerequisites

Include a section after the install command that details any requirements that must be satisfied before a developer can [authenticate](#authenticate-the-client) and test all of the snippets in the [Examples](#examples) section. For example, for Cosmos DB:

> You must have an [Azure subscription](https://azure.microsoft.com/free/), [Cosmos DB account](https://docs.microsoft.com/azure/cosmos-db/account-overview) (SQL API), and [Python 3.6+](https://www.python.org/downloads/) to use this package.

### Authenticate the client

If your library requires authentication for use, such as for Azure services, include instructions and example code needed for initializing and authenticating.

For example, include details on obtaining an account key and endpoint URI, setting environment variables for each, and initializing the client object.

## Key concepts
### Isolated Mode and AAD Mode.
Each Microsoft Azure Attestation service instance operates in either "AAD" mode or "Isolated" mode. When an MAA instance is operating in AAD mode, it means that the customer which created the attestation instance allows Azure Active Directory and Azure Role Based Access control policies to verify access to the attestation instance.  
### *AttestationType*
The Microsoft Azure Attestation service supports attesting different types of evidence depending on the environment.
Currently, MAA supports the following Trusted Execution environments:
* OpenEnclave - An Intel(tm) Processor running code in an SGX Enclave where the attestation evidence was collected using the OpenEnclave `oe_get_report` or `oe_get_evidence` API.
* SgxEnclave - An Intel(tm) Processor running code in an SGX Enclave where the attestation evidence was collected using the Intel SGX SDK.
* Tpm - A Virtualization Based Security environment where the Trusted Platform Module of the processor is used to provide the attestation evidence.

### Attestation Policy
Each Attestation Type has an associated attestation policy which can be used to perform 

The *Key concepts* section should describe the functionality of the main classes. Point out the most important and useful classes in the package (with links to their reference pages) and explain how those classes work together. Feel free to use bulleted lists, tables, code blocks, or even diagrams for clarity.

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

### Get an attestation policy for a specified attestation type.

The `GetPolicy` method retrieves an attestation policy from the service. The `attestationType` parameter is the type of attestation to retrieve.
```C# Snippet:GetPolicy
var client = new AttestationAdministrationClient(new Uri(endpoint), new DefaultAzureCredential());
var attestClient = new AttestationClient(new Uri(endpoint), new DefaultAzureCredential(),
    new AttestationClientOptions(validationCallback: (attestationToken, signer) => true));
var policyResult = await client.GetPolicyAsync(AttestationType.SgxEnclave);
var result = policyResult.Value.AttestationPolicy;
```

### Set an attestation policy for a specified attestation type.
```C# Snippet:SetPolicy
string attestationPolicy = "version=1.0; authorizationrules{=> permit();}; issuancerules{};";

var policyTokenSigner = TestEnvironment.PolicyCertificate0;

AttestationToken policySetToken = new SecuredAttestationToken(
    new StoredAttestationPolicy { AttestationPolicy = Base64Url.EncodeString(attestationPolicy), },
    TestEnvironment.PolicySigningKey0,
    policyTokenSigner);

var setResult = client.SetPolicy(AttestationType.SgxEnclave, policySetToken);
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

![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net%2Fsdk%2Ftemplate%2FAzure.Template%2FREADME.png)
