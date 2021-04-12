# Release History
## 1.0.0-beta.3 (Unreleased)
### Changed
- Hopefully the final changes for Azure Attestation Service for .Net. Mostly code cleanups, but significant improvements to the `AttestationToken` class.

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
    new StoredAttestationPolicy { AttestationPolicy = attestationPolicy },
    signingKey);

using var shaHasher = SHA256Managed.Create();
var attestationPolicyHash = shaHasher.ComputeHash(Encoding.UTF8.GetBytes(policySetToken.ToString()));

Debug.Assert(attestationPolicyHash.SequenceEqual(setResult.Value.PolicyTokenHash));
```
- The JSON Web Token associated properties in the `AttestationToken` class have been converted to nullable types to allow the AttestationToken class to express JSON Web Signature objects.
- The token validation related properties in the `AttestationClientOptions` class (validateAttestationTokens, validationCallback) have been moved into the new `TokenValidationOptions` class.
- The `TokenValidationOptions` class contains a number of options to tweak the JSON Web Token validation process, modeled extremely loosely after constructs in [Nimbus JWT](https://connect2id.com/products/nimbus-jose-jwt) and [PyJWT](https://pypi.org/project/PyJWT/).

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
``` C#
    string attestationPolicy = "version=1.0; authorizationrules{=> permit();}; issuancerules{};";
    var setResult = client.SetPolicy(AttestationType.SgxEnclave,
        attestationPolicy,
        TestEnvironment.PolicySigningKey0, policyTokenSigner);
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

var policyResult = await client.GetPolicyAsync(AttestationType.SgxEnclave);
var result = policyResult.Value;
```

The net result of these changes is a significant reduction in the complexity of interacting with the attestation administration APIs.

## 1.0.0-beta.1 (2021-01-15)
Released as beta, not alpha.

## 1.0.0-alpha.1 (2020-12-08)

Created.
