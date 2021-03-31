# Azure.Security.Attestation

### AutoRest Configuration
> see https://aka.ms/autorest

Run `dotnet build /t:GenerateCode` in src directory to re-generate.

``` yaml
title: Azure.Security.Attestation
input-file:
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/f0356ad28dd559e4d52b2aa679242a42fa3dc176/specification/attestation/data-plane/Microsoft.Attestation/stable/2020-10-01/attestation.json
namespace: Azure.Security.Attestation

directive:
- from: swagger-document
  where: $.definitions.PolicyResult
  transform: >
      $["x-csharp-usage"] = "model,output";
      $["x-csharp-formats"] = "json";
- from: swagger-document
  where: $.definitions.AttestationResult
  transform: >
      $["x-csharp-usage"] = "model,output";
      $["x-csharp-formats"] = "json";
- from: swagger-document
  where: $.definitions.PolicyCertificatesResult
  transform: >
      $["x-csharp-usage"] = "model,output";
      $["x-csharp-formats"] = "json";
- from: swagger-document
  where: $.definitions.AttestationCertificateManagementBody
  transform: >
      $["x-csharp-usage"] = "model,output";
      $["x-csharp-formats"] = "json";
- from: swagger-document
  where: $.definitions.PolicyCertificatesModificationResult
  transform: >
      $["x-csharp-usage"] = "model,output";
      $["x-csharp-formats"] = "json";
```
