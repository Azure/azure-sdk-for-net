# Migration Blocker: Azure.Communication.ProgrammableConnectivity

## Issue

Azure.Communication.ProgrammableConnectivity cannot be migrated from the legacy emitter (`@azure-tools/typespec-csharp` v0.2.0) to the new emitter (`@azure-typespec/http-client-csharp` v1.0.0) due to lack of support for HTTP 302 redirect responses in the new generator.

## Root Cause

The TypeSpec specification for this service includes an operation (`verifyWithoutCode`) that returns an HTTP 302 (redirect) response as part of its OAuth-style frontend authorization flow:

```typespec
verifyWithoutCode is Operations.ResourceAction<
  NumberVerificationEndpoint,
  BodyParameter<NumberVerificationWithoutCodeContent>,
  TypeSpec.Http.Response<302> & {},
  TraitOverride<ResponseHeadersTrait<{
    @doc("The URI of the network's authorization endpoint...")
    @header
    location: url;
  } & RequestIdResponseHeader>>
>;
```

This is the correct and intended API design - the service redirects users to the mobile operator's network for authentication. See `specification/programmableconnectivity/Azure.ProgrammableConnectivity/apis/number.tsp` in azure-rest-api-specs for details.

## Error When Attempting Migration

When attempting to generate with the new emitter, the following error occurs:

```
Unexpected status codes for operation VerifyWithoutCode
   at Microsoft.TypeSpec.Generator.ClientModel.Providers.RestClientProvider.GetClassifier(InputOperation operation)
```

The new generator's `RestClientProvider.GetClassifier` method does not handle 3xx status codes.

## Current State

- The library remains on the **legacy emitter** (`eng/legacy-emitter-package.json`)
- The legacy emitter generates a `ResponseClassifier302` to properly handle the redirect:
  ```csharp
  private static ResponseClassifier ResponseClassifier302 => 
      _responseClassifier302 ??= new StatusCodeClassifier(stackalloc ushort[] { 302 });
  ```

## Path Forward

This library can be migrated once either:

1. **Preferred**: The new TypeSpec http-client-csharp generator adds support for 3xx HTTP status codes (particularly 302 redirects)
   - Issue should be filed at: https://github.com/microsoft/typespec/issues
   - This affects the `Microsoft.TypeSpec.Generator.ClientModel` component

2. **Alternative**: The TypeSpec spec is redesigned to avoid using 302 redirects (NOT RECOMMENDED as this changes the API design)

## References

- TypeSpec spec: `specification/programmableconnectivity/Azure.ProgrammableConnectivity/apis/number.tsp` in Azure/azure-rest-api-specs
- Generator error location: `RestClientProvider.GetClassifier()` in Microsoft.TypeSpec.Generator.ClientModel
- Related discussion: https://github.com/microsoft/typespec/discussions/2907 (Adding HTTP status codes responses)
- Legacy generator dependency: `@azure-tools/typespec-csharp` v0.2.0-beta.20251023.1
- New generator dependency: `@azure-typespec/http-client-csharp` v1.0.0-alpha.20260127.1

## Testing

To verify the blocker:

```bash
# Edit tsp-location.yaml to use: eng/azure-typespec-http-client-csharp-emitter-package.json
cd sdk/communication/Azure.Communication.ProgrammableConnectivity/src
dotnet build /t:GenerateCode
# Will fail with "Unexpected status codes for operation VerifyWithoutCode"
```

---

**Last Updated**: 2026-01-28
**Status**: BLOCKED - Awaiting generator support for 3xx status codes
