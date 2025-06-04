# Release History

## 1.1.0-beta.1 (Unreleased)


## 1.0.0 (2021-05-11)

### Changed

- Final changes for Azure Attestation Service for .Net, including API review feedback. Mostly code cleanups, but significant improvements to the `AttestationToken` class.

### Breaking change

- Clients no longer need to instantiate `SecuredAttestationToken` or `UnsecuredAttestationToken` objects to validate the token hash. All of the functionality associated with `SecuredAttestationToken` and `UnsecuredAttestationToken` has been folded into the `AttestationToken` class.
As a result, the `SecuredAttestationToken` and `UnsecuredAttestationToken` types have been removed.

```C# Snippet:VerifySigningHash
// The SetPolicyAsync API will create an AttestationToken signed with the TokenSigningKey to transmit the policy.
// To verify that the policy specified by the caller was received by the service inside the enclave, we
// verify that the hash of the policy document returned from the Attestation Service matches the hash
// of an attestation token created locally.
TokenSigningKey signingKey = new TokenSigningKey(<Customer provided signing key>, <Customer provided certificate>)
var policySetToken = new AttestationToken(
    BinaryData.FromObjectAsJson(new StoredAttestationPolicy { AttestationPolicy = attestationPolicy }),
    signingKey);

using var shaHasher = SHA256.Create();
byte[] attestationPolicyHash = shaHasher.ComputeHash(Encoding.UTF8.GetBytes(policySetToken.Serialize()));

Debug.Assert(attestationPolicyHash.SequenceEqual(setResult.Value.PolicyTokenHash.ToArray()));
```

- The JSON Web Token associated properties in the `AttestationToken` class have been converted to nullable types to allow the AttestationToken class to express JSON Web Signature objects.
- The token validation related properties in the `AttestationClientOptions` class (validateAttestationTokens, validationCallback) have been moved into the new `TokenValidationOptions` class.
- The `TokenValidationOptions` class contains a number of options to tweak the JSON Web Token validation process, modeled extremely loosely after constructs in [Nimbus JWT](https://connect2id.com/products/nimbus-jose-jwt) and [PyJWT](https://pypi.org/project/PyJWT/).
- The validationCallback in the `TokenValidationOptions` object has been moved to a `TokenValidated` event on the `TokenValidationOptions` class. The `TokenValidated` event derives from the [SyncAsyncEventHandler](https://learn.microsoft.com/dotnet/api/azure.core.syncasynceventhandler-1) class, enabling both synchronous and asynchronous event handlers.
- The `TokenBody` and `TokenHeader` properties have been removed from the [AttestationToken](https://learn.microsoft.com/dotnet/api/azure.security.attestation.attestationtoken) object since they were redundant.
- The `TokenSigningKey` type has been renamed `AttestationTokenSigningKey`.
- The `PolicyResult` type has been renamed `PolicyModificationResult`.
- The constructor for the `AttestationToken` class has been changed from taking an `object` to taking a `BinaryData`. This allows callers to use their preferred serialization
mechanism. The constructor for `AttestationToken` will ensure that the `body` parameter is in fact a serialized JSON object to ensure it is compatible wih the JSON Web Signature encoding algorithms.
- The inputs to the AttestSgxEnclave and AttestOpenEnclave APIs have been restructured
to reduce the number of parameters passed into the API.
- When creating an `AttestationData` object specifying that the body type is "JSON", the binary data passed in will be verified that it contains a JSON object.
- The return value of `GetPolicyManagementCertificates` has been changed from `AttestationResult<PolicyCertificatesResult>` to `AttestationResult<IReadOnlyList<X509Certificate2>>` to simplify the experience of retrieving the certificate list. As a consequence of this change, the `PolicyCertificatesResult` type has been removed.
- The unused `TpmAttestationRequest` and `TpmAttestationResponse` types have been removed.
- The `AttestationTokenSigningKey` will now ensure that the public key in the provided certificate is the public key corresponding to the private key.
- `AttestTpm` and `AttestTpmAsync` are changed to accept a new `TpmAttestationRequest` and return a `TpmAttestationResponse` instead of accepting and returning a `BinaryData`. The semantics of the API do not change, just the encapsulation of the BinaryData.

## 1.0.0-beta.2 (2021-04-06)

### Fixed

- [19708](https://github.com/Azure/azure-sdk-for-net/issues/19708), handle JSON values that are not just simple integers.
- [18183](https://github.com/Azure/azure-sdk-for-net/issues/18183), Significant cleanup of README.md.
- [18739](https://github.com/Azure/azure-sdk-for-net/issues/18739), reference the readme.md file in the azure-rest-apis directory instead of referencing the attestation JSON file directly. Also updated to the most recent version of the dataplane swagger files.

### Breaking Change

- It is no longer necessary to manually Base64Url encode the AttestationPolicy property in the StoredAttestationPolicy model.
This dramatically simplifies the user experience for interacting with the saved attestation policies - developers can treat attestation policies as string values.
- The `SecuredAttestationToken` and `UnsecuredAttestationToken` parameters have been removed from the APIs which took them. Instead those APIs directly take the underlying type.

Before:

``` C#
    string attestationPolicy = "version=1.0; authorizationrules{=> permit();}; issuancerules{};";

    var policyTokenSigner = TestEnvironment.PolicyCertificate0;

    AttestationToken policySetToken = new SecuredAttestationToken(
        new StoredAttestationPolicy { AttestationPolicy = attestationPolicy, },
        TestEnvironment.PolicySigningKey0,
        policyTokenSigner);

    var setResult = client.SetPolicy(AttestationType.SgxEnclave, policySetToken);
```

After:

```C# Snippet:SetPolicy
string attestationPolicy = "version=1.0; authorizationrules{=> permit();}; issuancerules{};";

X509Certificate2 policyTokenCertificate = new X509Certificate2(<Attestation Policy Signing Certificate>);
AsymmetricAlgorithm policyTokenKey = <Attestation Policy Signing Key>;

var setResult = client.SetPolicy(AttestationType.SgxEnclave, attestationPolicy, new AttestationTokenSigningKey(policyTokenKey, policyTokenCertificate));
```

- The `GetPolicy` API has been changed to directly return the policy requested instead of a `StoredAttestationPolicy` object.
  
Before:

``` C#
    var policyResult = await client.GetPolicyAsync(AttestationType.SgxEnclave);
    var result = policyResult.Value.AttestationPolicy;
```

After:

```C# Snippet:GetPolicy
var client = new AttestationAdministrationClient(new Uri(endpoint), new DefaultAzureCredential());

AttestationResponse<string> policyResult = await client.GetPolicyAsync(AttestationType.SgxEnclave);
string result = policyResult.Value;
```

The net result of these changes is a significant reduction in the complexity of interacting with the attestation administration APIs.

## 1.0.0-beta.1 (2021-01-15)

Released as beta, not alpha.

## 1.0.0-alpha.1 (2020-12-08)

Created.
