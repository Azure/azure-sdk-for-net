# Guide for migrating to `Azure.Security.Attestation` 2.0.0 from 1.0.0

Version 2.0.0 changes how attestation tokens are validated. The public API is unchanged, so code built against 1.0.0 still compiles, but some code that ran with 1.0.0 now throws or rejects tokens. This guide describes each change and how to update your code. For the full list of changes, see the [CHANGELOG](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/attestation/Azure.Security.Attestation/CHANGELOG.md).

Most applications that only call `AttestationClient` and `AttestationAdministrationClient` need no changes. The change most likely to affect you is to code that calls `AttestationToken.ValidateToken` or `ValidateTokenAsync` directly, for example in a relying party.

## Table of contents

- [Validating a token yourself](#validating-a-token-yourself)
- [Client endpoints must use https](#client-endpoints-must-use-https)
- [Token signing keys must be RSA](#token-signing-keys-must-be-rsa)
- [Time validation slack defaults to 5 seconds](#time-validation-slack-defaults-to-5-seconds)
- [Unsigned tokens are rejected](#unsigned-tokens-are-rejected)
- [Any TokenValidated handler can reject a token](#any-tokenvalidated-handler-can-reject-a-token)

## Validating a token yourself

When you call `AttestationToken.ValidateToken` or `ValidateTokenAsync`, 2.0.0 requires two things that 1.0.0 did not:

- **Signing certificates.** You must pass the signing certificates of the attestation provider you trust as `attestationSigningCertificates`. Retrieve them with `AttestationClient.GetSigningCertificates`. `ValidateToken` throws `ArgumentNullException` if you pass `null` and `ArgumentException` if you pass an empty list. In 1.0.0, passing `null` validated the token against the certificates in its own header; 2.0.0 never uses certificates or keys from the token's header to validate it.
- **The expected issuer.** `AttestationTokenValidationOptions.ValidateIssuer` now defaults to `true`, so you must set `ExpectedIssuer` to the base URI of the attestation provider the token must come from. `ValidateToken` throws `ArgumentNullException` if `ValidateIssuer` is `true` and `ExpectedIssuer` isn't set, and, as for an expired token, throws an exception if the token's issuer doesn't match. The comparison ignores case and a trailing `/`. To skip the issuer check, set `ValidateIssuer` to `false`.

1.0.0:

```C#
AttestationToken token = AttestationToken.Deserialize(serializedToken);
if (!token.ValidateToken(new AttestationTokenValidationOptions(), null))
{
    throw new InvalidOperationException("The attestation token is not valid.");
}
```

2.0.0:

```C#
// The attestation provider you trust to have issued the token.
string attestationEndpoint = "https://myprovider.attest.azure.net";

var certificateClient = new AttestationClient(new Uri(attestationEndpoint), new DefaultAzureCredential());
IReadOnlyList<AttestationSigner> signers = certificateClient.GetSigningCertificates().Value;

AttestationToken token = AttestationToken.Deserialize(serializedToken);
var validationOptions = new AttestationTokenValidationOptions { ExpectedIssuer = attestationEndpoint };
if (!token.ValidateToken(validationOptions, signers))
{
    throw new InvalidOperationException("The attestation token is not valid.");
}
```

`AttestationClient` and `AttestationAdministrationClient` validate the tokens they return the same way. They retrieve the provider's signing certificates themselves and, when `ExpectedIssuer` isn't set, use their endpoint as the expected issuer, so code that only calls the clients needs no changes for this. If you set `ExpectedIssuer` in the `AttestationTokenValidationOptions` passed to `AttestationClientOptions`, it must match the issuer of the tokens your provider returns.

## Client endpoints must use https

`AttestationClient` and `AttestationAdministrationClient` now throw `ArgumentException` when the endpoint doesn't use `https`. Use the provider's `https` URI, for example `https://myprovider.attest.azure.net`.

## Token signing keys must be RSA

`AttestationTokenSigningKey` now supports only RSA keys and certificates. Its constructors throw `ArgumentException` for other keys, such as ECDSA keys. In 1.0.0 they threw `NotSupportedException` or `NullReferenceException`. If you catch `NotSupportedException` from these constructors, catch `ArgumentException` instead.

Tokens signed with an `AttestationTokenSigningKey` now carry `RS256` in their `alg` header instead of `RSA256`. If you check the `alg` header of these tokens, for example in a test, expect `RS256`.

## Time validation slack defaults to 5 seconds

`AttestationTokenValidationOptions.TimeValidationSlack` now defaults to 5 seconds instead of 0, so a token is accepted up to 5 seconds before its `nbf` time and after its `exp` time. The service sets these times with its own clock, which can be slightly ahead of yours, so with no slack a token returned by the service was occasionally rejected as not yet valid. To restore exact time checks, set `TimeValidationSlack` to 0.

## Unsigned tokens are rejected

`ValidateToken` and `ValidateTokenAsync` now return `false` for unsigned tokens, whose `alg` header is `none`, and for tokens with no `alg` header. A `TokenValidated` handler can't accept them. Tokens returned by the Attestation service are signed, except for the response to an attestation request that sets `DraftPolicyForAttestation`, which the clients still return as in 1.0.0.

## Any TokenValidated handler can reject a token

When several handlers are attached to `AttestationTokenValidationOptions.TokenValidated`, the token is now rejected if any of them sets `IsValid` to `false`. In 1.0.0, only the value set by the last handler was used. If you rely on a later handler overriding an earlier one, combine their checks into a single handler.
