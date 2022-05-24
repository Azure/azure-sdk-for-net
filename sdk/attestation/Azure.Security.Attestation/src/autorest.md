# Azure.Security.Attestation

### AutoRest Configuration
> see https://aka.ms/autorest

Run `dotnet build /t:GenerateCode` in src directory to re-generate.

``` yaml
title: Azure.Security.Attestation
require:
    - https://github.com/Azure/azure-rest-api-specs/blob/988d42ee7d8ca3243df17bfbc134e0c1f21b481e/specification/attestation/data-plane/readme.md
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
