# Azure.Security.Attestation

### AutoRest Configuration
> see https://aka.ms/autorest

Run `dotnet build /t:GenerateCode` in src directory to re-generate.

``` yaml
title: Azure.Security.Attestation
require:
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/45c7ae94a46920c94b5e03e6a7d128d6cb7a364e/specification/attestation/data-plane/readme.md
namespace: Azure.Security.Attestation
generation1-convenience-client: true
tag: package-2020-10-01
azure-arm: false


directive:
- from: swagger-document
  where: $.definitions
  transform: >
    for (var path in $)
    {
      if (path.endsWith("AttestationCertificateManagementBody") ||
        path.endsWith("PolicyCertificatesModificationResult"))
      {
        $[path]["x-csharp-usage"] = "model,output,input,converter";
        $[path]["x-csharp-formats"] = "json";
      }
      else if (path.endsWith("PolicyResult") ||
        path.endsWith("AttestationResult") ||
        path.endsWith("PolicyCertificatesResult"))
      {
        $[path]["x-csharp-usage"] = "model,output,converter";
        $[path]["x-csharp-formats"] = "json";
      }
    }
```
