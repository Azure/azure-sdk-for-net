# Release History

## 1.1.0 (Unreleased)

### Features Added

- Updated the client library to target the `2025-06-01` Azure Attestation service API version.
- Added `AttestationClientOptions.ServiceVersion.V2025_06_01`, which is now the default service version. `V2020_10_01` remains available for callers that need to continue targeting the previous service API version.
- Added the `AttestationType.AzureGuest`, `AttestationType.SevSnpVm`, and `AttestationType.TdxVm` values. `TdxVm` requires service version `V2025_06_01`.
- Added `AttestationClient.AttestTdxVm` and `AttestationClient.AttestSevSnpVm` (and their async counterparts) to attest Intel TDX and AMD SEV-SNP confidential virtual machines. `AttestTdxVm` requires service version `V2025_06_01`.
- Added `AttestationRequest.Nonce`, which the service returns in the `nonce` claim of the attestation token.
- Added `AttestationResult.AdditionalClaims`, which exposes the token's claims that have no dedicated property, such as the TDX and SEV-SNP claims and claims issued by attestation policy. `AttestationModelFactory.AttestationResult` accepts them as `additionalClaims` for mocking.
- Added `AttestationClient.GetOpenIdMetadata` (and its async counterpart), which retrieves the attestation provider's OpenID Connect discovery document as an `AttestationOpenIdMetadata`.
- Added `AttestationClient.AttestAzureGuest` (and its async counterpart) to attest Azure confidential and Trusted Launch virtual machines. It returns a `SealedAttestationResult` whose token is encrypted to the virtual machine's TPM, so the client does not validate it.
- Added `AttestationAdministrationClient.GetTcbBaselines` (and its async counterpart), which lists the SGX trusted computing base (TCB) baselines an attestation policy can require, as `TcbBaselineResult` and `TcbBaseline`. It requires service version `V2025_06_01`.
- Model types now implement `IJsonModel<T>` and `IPersistableModel<T>`, and `AzureSecurityAttestationContext` was added, for use with `System.ClientModel.Primitives.ModelReaderWriter`.

### Bugs Fixed

- Fixed `GetPolicy` throwing instead of returning a null policy when the requested attestation type has no policy configured.
- `AttestationClient.GetSigningCertificatesAsync`, which the async operations also use to fetch the keys that validate tokens, no longer makes a blocking network call.
- `AttestationToken.ExpirationTime`, `NotBeforeTime`, and `IssuedAtTime` no longer truncate fractional seconds in the token's `exp`, `nbf`, and `iat` claims.
- With a nonzero `AttestationTokenValidationOptions.TimeValidationSlack`, token validation compared only the seconds component of the time elapsed since `exp` (or remaining until `nbf`) with the slack, so a token outside the slack by a whole number of minutes could pass. It now compares the total elapsed time.
- `AttestationToken.ValidateToken` and `AttestationToken.ValidateTokenAsync` now return `false` for unsecured tokens, that is, tokens whose `alg` header is `none`. Such tokens carry no signature, so no signature verification was performed and validation previously succeeded by default. The `AttestationTokenValidationOptions.TokenValidated` handler is no longer invoked for these tokens and cannot be used to accept them. Tokens returned by the Attestation service are signed and are unaffected, except for the response to an attestation request that sets `DraftPolicyForAttestation`: the service never signs it, so the client still returns it, as before, after checking its time claims and invoking the `TokenValidated` handler. Unsecured tokens sent to the service by `SetPolicy` and `ResetPolicy` are also unaffected, as they are never validated by the client.
- Attestation tokens are now validated against their issuer by default. `AttestationTokenValidationOptions.ValidateIssuer` defaults to `true`, and `AttestationClient` and `AttestationAdministrationClient` use their endpoint as the expected issuer when `ExpectedIssuer` is not set. While issuer validation is enabled, a token without an issuer is rejected. Callers of `AttestationToken.ValidateToken` and `AttestationToken.ValidateTokenAsync` must set `ExpectedIssuer` to the base URI of the attestation provider the token must come from, or set `ValidateIssuer` to `false`.
- `AttestationToken.ValidateToken` and `AttestationToken.ValidateTokenAsync` now accept a signed token only if one of the signing certificates passed as `attestationSigningCertificates` signed it. Previously, when no signing certificates were passed, the token was checked against the certificates in its own header. They now throw `ArgumentNullException` when `attestationSigningCertificates` is `null` and `ArgumentException` when it is empty; use `AttestationClient.GetSigningCertificates` to retrieve the attestation provider's signing certificates. Certificates and keys in a token's header are no longer used to select a signer in any case.
- `AttestationToken.X509CertificateChain` now decodes the base64-encoded certificates in the token's `x5c` header on all target frameworks, and returns an empty array when the header has none. On .NET 9 and earlier, and on .NET Framework, it treated each entry as a file name, so it could not read the certificates in tokens returned by the service.
- `AttestationClient` and `AttestationAdministrationClient` now throw `ArgumentException` when the endpoint does not use `https`. An `AttestationClient` created without a credential previously sent its requests, including the request for the certificates that validate tokens, without TLS.
- When several handlers are attached to `AttestationTokenValidationOptions.TokenValidated`, the token is now rejected if any of them sets `IsValid` to `false`. Previously only the value set by the last handler was used.
- `AttestationAdministrationClient.SetPolicy`, `GetPolicyManagementCertificates`, and `GetPolicyManagementCertificatesAsync` no longer throw when a `TokenValidated` handler is attached; they now invoke it like the other operations.
- A token without a `kid` header is now checked against every signing certificate passed to `ValidateToken` and `ValidateTokenAsync`. Previously only the first was tried, so a token signed by another of them was rejected.
- `AttestationTokenSigningKey` now throws `ArgumentException` for keys and certificates that are not RSA, such as ECDSA keys, instead of `NotSupportedException` or `NullReferenceException`. Only RSA signing keys are supported.
- Tokens signed with an `AttestationTokenSigningKey` now carry the standard JWS algorithm `RS256` in their `alg` header, instead of `RSA256`.
- Tokens signed with an `AttestationTokenSigningKey` created from a certificate alone now use the certificate's private key. Previously, on .NET 8 and later, signing failed with a `CryptographicException`.
- `ValidateToken` and `ValidateTokenAsync` now throw `ArgumentNullException` when `options` is `null` or `attestationSigningCertificates` contains `null`, throw `ArgumentException` when one of the signers has no certificate, and return `false` for a token without an `alg` header, instead of throwing `NullReferenceException` or `ArgumentOutOfRangeException`.
- `AttestationToken.ExpirationTime`, `NotBeforeTime`, and `IssuedAtTime` now return `DateTimeOffset.MaxValue` or `DateTimeOffset.MinValue` for claims outside the range of `DateTimeOffset`, instead of throwing `ArgumentOutOfRangeException`, so such tokens are validated against those values.
- `AttestationTokenValidationOptions.TimeValidationSlack` now defaults to 5 seconds instead of 0. The service sets a token's `nbf` claim with its own clock, which can be slightly ahead of the caller's, so with no slack a token returned by the service was intermittently rejected as not yet valid. Set `TimeValidationSlack` to 0 to restore exact time checks.

### Other Changes

- Migrated the code generation from AutoRest/Swagger to TypeSpec.

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
