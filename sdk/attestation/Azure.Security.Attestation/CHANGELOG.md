# Release History

## 1.0.0-beta.2 (2021-04-06)

- Fixed bug #19708, handle JSON values that are not just simple integers.
- Fixed bug #18183, Significant cleanup of README.md.
- Fixed bug #18739, reference the readme.md file in the azure-rest-apis directory instead of referencing the attestation JSON file directly. Also updated to the most recent version of the dataplane swagger files.

### Breaking Changes since 1.0.0-beta.1:
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

