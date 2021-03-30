# Azure Attestation client library for .NET

The Microsoft Azure Attestation (MAA) service is a unified solution for remotely verifying the trustworthiness of a platform and integrity of the binaries running inside it. The service supports attestation of the platforms backed by Trusted Platform Modules (TPMs) alongside the ability to attest to the state of Trusted Execution Environments (TEEs) such as Intel® Software Guard Extensions (SGX) enclaves and Virtualization-based Security (VBS) enclaves.

Attestation is a process for demonstrating that software binaries were properly instantiated on a trusted platform. Remote relying parties can then gain confidence that only such intended software is running on trusted hardware. Azure Attestation is a unified customer-facing service and framework for attestation.

Azure Attestation enables cutting-edge security paradigms such as Azure Confidential computing and Intelligent Edge protection. Customers have been requesting the ability to independently verify the location of a machine, the posture of a virtual machine (VM) on that machine, and the environment within which enclaves are running on that VM. Azure Attestation will empower these and many additional customer requests.

Azure Attestation receives evidence from compute entities, turns them into a set of claims, validates them against configurable policies, and produces cryptographic proofs for claims-based applications (for example, relying parties and auditing authorities).

> NOTE: This is a preview SDK for the Microsoft Azure Attestation service. It provides all the essential functionality to access the Azure Attestation service, it should be considered 'as-is" and is subject to changes in the future which may break compatibility with previous versions.

  [Source code](https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/attestation) | [Package (NuGet)](https://www.nuget.org/packages/Azure.Security.Attestation) | [API reference documentation][API_reference] | [Product documentation](https://docs.microsoft.com/azure/attestation/)

## Getting started

### Prerequisites
* An Azure subscription.  To use Azure services, including the Microsoft Azure Attestation service, you'll need a subscription.  If you do not have an existing Azure account, you may sign up for a [free trial][azure_sub] or use your [Visual Studio Subscription](https://visualstudio.microsoft.com/subscriptions/) benefits when you [create an account](https://account.windowsazure.com/Home/Index).
* An existing Azure Attestation Instance, or you can use the "shared provider" available in each Azure region. If you need to create an Azure Attestation service instance, you can use the Azure Portal or [Azure CLI][azure_cli].

### Install the package
Install the Microsoft Azure Attestation client library for .NET with [NuGet][nuget]:

```PowerShell
dotnet add package Azure.Security.Attestation --prerelease
```

### Authenticate the client
In order to interact with the Microsoft Azure Attestation service, you'll need to create an instance of the [Attestation Client][key_client_class] class. You need a **attestation instance url**, which you may see as "DNS Name" in the portal,
 and **client secret credentials (client id, client secret, tenant id)** to instantiate a client object.

Client secret credential authentication is being used in this getting started section but you can find more ways to authenticate with [Azure identity][azure_identity]. To use the [DefaultAzureCredential][DefaultAzureCredential] provider shown below,
or other credential providers provided with the Azure SDK, you should install the Azure.Identity package:

```PowerShell
dotnet add package Azure.Identity
```

#### Create/Get credentials
Use the [Azure CLI][azure_cli] snippet below to create/get client secret credentials.

 * Create a service principal and configure its access to Azure resources:
    ```PowerShell
    az ad sp create-for-rbac -n <your-application-name> --skip-assignment
    ```
    Output:
    ```json
    {
        "appId": "generated-app-ID",
        "displayName": "dummy-app-name",
        "name": "http://dummy-app-name",
        "password": "random-password",
        "tenant": "tenant-ID"
    }
    ```
* Take note of the service principal objectId
    ```PowerShell
    az ad sp show --id <appId> --query objectId
    ```
    Output:
    ```
    "<your-service-principal-object-id>"
    ```
* Use the returned credentials above to set  **AZURE_CLIENT_ID** (appId), **AZURE_CLIENT_SECRET** (password), and **AZURE_TENANT_ID** (tenant) environment variables. The following example shows a way to do this in Powershell:
    ```PowerShell
    $Env:AZURE_CLIENT_ID="generated-app-ID"
    $Env:AZURE_CLIENT_SECRET="random-password"
    $Env:AZURE_TENANT_ID="tenant-ID"
    ```


## Key concepts

There are four major families of functionality provided in this preview SDK: 
- [SGX and TPM enclave attestation.](#attestation)
- [MAA Attestation Token signing certificate discovery and validation.](#attestation-token-signing-certificate-discovery-and-validation)  
- [Attestation Policy management.](#policy-management)
- [Attestation policy management certificate management](#policy-management-certificate-management) (yes, policy management management).

The Microsoft Azure Attestation service runs in two separate modes: "Isolated" and "AAD". When the service is running in "Isolated" mode, the customer needs to 
provide additional information beyond their authentication credentials to verify that they are authorized to modify the state of an attestation instance.

Finally, each region in which the Microsoft Azure Attestation service is available supports a "shared" instance, which
can be used to attest SGX enclaves which only need verification against the azure baseline (there are no policies applied to the shared instance). TPM attestation is not available in the shared instance.
While the shared instance requires AAD authentication, it does not have any RBAC policies - any customer with a valid AAD bearer token can attest using the shared instance.

### Attestation
SGX or TPM attestation is the process of validating evidence collected from 
a trusted execution environment to ensure that it meets both the Azure baseline for that environment and customer defined policies applied to that environment.

### Attestation token signing certificate discovery and validation
Most responses from the MAA service are expressed in the form of a JSON Web Token. This token will be signed by a signing certificate
issued by the MAA service for the specified instance. If the MAA service instance is running in a region where the service runs in an SGX enclave, then
the certificate issued by the server can be verified using the [oe_verify_attestation_certificate() API](https://openenclave.github.io/openenclave/api/enclave_8h_a3b75c5638360adca181a0d945b45ad86.html). 

### Policy Management
Each attestation service instance has a policy applied to it which defines additional criteria which the customer has defined.

For more information on attestation policies, see [Attestation Policy](https://docs.microsoft.com/azure/attestation/author-sign-policy)

### Policy Management certificate management.
When an attestation instance is running in "Isolated" mode, the customer who created the instance will have provided
a policy management certificate at the time the instance is created. All policy modification operations require that the customer sign
the policy data with one of the existing policy management certificates. The Policy Management Certificate Management APIs enable 
clients to "roll" the policy management certificates.

### Isolated Mode and AAD Mode.
Each Microsoft Azure Attestation service instance operates in either "AAD" mode or "Isolated" mode. When an MAA instance is operating in AAD mode, it means that the customer which created the attestation instance allows Azure Active Directory and Azure Role Based Access control policies to verify access to the attestation instance.  
### *AttestationType*
The Microsoft Azure Attestation service supports attesting different types of evidence depending on the environment.
Currently, MAA supports the following Trusted Execution environments:
* OpenEnclave - An Intel(tm) Processor running code in an SGX Enclave where the attestation evidence was collected using the OpenEnclave [`oe_get_report`](https://openenclave.io/apidocs/v0.14/enclave_8h_aefcb89c91a9078d595e255bd7901ac71.html#aefcb89c91a9078d595e255bd7901ac71) or [`oe_get_evidence`](https://openenclave.io/apidocs/v0.14/attester_8h_a7d197e42468636e95a6ab97b8e74c451.html#a7d197e42468636e95a6ab97b8e74c451) API.
* SgxEnclave - An Intel(tm) Processor running code in an SGX Enclave where the attestation evidence was collected using the Intel SGX SDK.
* Tpm - A Virtualization Based Security environment where the Trusted Platform Module of the processor is used to provide the attestation evidence.

### Runtime Data and Inittime Data
RuntimeData refers to data which is presented to the Intel SGX Quote generation logic or the `oe_get_report`/`oe_get_evidence` APIs. The Azure Attestation service will validate that the first 32 bytes of the `report_data` field in the SGX Quote/OE Report/OE Evidence matches the SHA256 hash of the RuntimeData.

InitTime data refers to data which is used to configure the SGX enclave being attested.


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

* [Create an attestation client instance](#create-client-instance)
* [Attest an SGX enclave](#attest-sgx-enclave)
* [Get attestation policy](#get-attestation-policy)
* [Retrieve token validation certificates](#retrieve-token-certificates)
* [Create an attestation client instance](#create-client-instance)

### Create client instance.
Creates an instance of the Attestation Client at uri `endpoint`.
```C# Snippet:CreateAttestationClient
var options = new AttestationClientOptions();
return new AttestationClient(new Uri(endpoint), new DefaultAzureCredential(), options);
```

### Attest SGX Enclave

Use the `AttestSgxEnclave` method to attest an SGX enclave.

This example assumes that you have an existing `AttestationClient` object which is configured with the base URI for your endpoint. It also assumes that you have an SGX Quote (`binaryQuote`) generated from within the SGX enclave you are attesting, and "Runtime Data" (`runtimeData`) which is referenced in the SGX Quote.

```C# Snippet:AttestSgxEnclave
// Collect quote and runtime data from OpenEnclave enclave.

var attestationResult = client.AttestSgxEnclave(binaryQuote, null, false, BinaryData.FromBytes(binaryRuntimeData), false).Value;
Assert.AreEqual(binaryRuntimeData, attestationResult.DeprecatedEnclaveHeldData);
// VERIFY ATTESTATIONRESULT.
// Encrypt Data using DeprecatedEnclaveHeldData
// Send to enclave.
```

### Get attestation policy

The `GetPolicy` method retrieves the attestation policy from the service.
Attestation Policies are instanced on a per-attestation type basis, the `AttestationType` parameter defines the type to retrieve. 

The response to the `GetPolicy` API is an 'AttestationResponse<StoredAttestationPolicy>'.

The `StoredAttestationPolicy` attestation policy document is a JSON Web Signature object, with a single field named `AttestationPolicy`, whose value is the actual policy document encoded using the [Base64Url][base64url_encoding] encoding scheme.

### Get an attestation policy for a specified attestation type.

The `GetPolicy` method retrieves an attestation policy from the service. The `attestationType` parameter is the type of attestation to retrieve.
```C# Snippet:GetPolicy
var client = new AttestationAdministrationClient(new Uri(endpoint), new DefaultAzureCredential());

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

### Retrieve Token Certificates

Use `GetSigningCertificatesAsync` to retrieve the certificates which can be used to validate the token returned from the attestation service.

```C# Snippet:GetSigningCertificates
var client = GetAttestationClient();

IReadOnlyList<AttestationSigner> signingCertificates = (await client.GetSigningCertificatesAsync()).Value;
```

## Troubleshooting

Troubleshooting information for the MAA service can be found [here](https://docs.microsoft.com/azure/attestation/troubleshoot-guide)

## Next steps
For more information about the Microsoft Azure Attestation service, please see our [documentation page](https://docs.microsoft.com/azure/attestation/). 

## Contributing
This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit https://cla.microsoft.com.

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (e.g., label, comment). Simply follow the instructions provided by the bot. You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct][microsoft_code_of_conduct]. For more information see the Code of Conduct FAQ or contact <opencode@microsoft.com> with any additional questions or comments.

See [CONTRIBUTING.md][contributing] for details on building, testing, and contributing to these libraries.

<!-- LINKS -->
[style-guide-msft]: https://docs.microsoft.com/style-guide/capitalization
[style-guide-cloud]: https://aka.ms/azsdk/cloud-style-guide
[API_reference]: https://docs.microsoft.com/dotnet/api/azure.security.attestation?view=azure-dotnet-preview
[azure_cli]: https://docs.microsoft.com/cli/azure
[azure_identity]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/identity/Azure.Identity
[azure_sub]: https://azure.microsoft.com/free/
[code_of_conduct]: https://opensource.microsoft.com/codeofconduct/
[JWK]: https://tools.ietf.org/html/rfc7517
[base64url_encoding]: https://tools.ietf.org/html/rfc4648#section-5
[nuget]: https://www.nuget.org/
[DefaultAzureCredential]: https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/identity/Azure.Identity/README.md#defaultazurecredential
[contributing]: https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/keyvault/CONTRIBUTING.md
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/

![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net%2Fsdk%2Ftemplate%2FAzure.Template%2FREADME.png)
