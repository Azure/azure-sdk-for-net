# Azure.Security.Attestation

### AutoRest Configuration
> see https://aka.ms/autorest

Run `dotnet build /t:GenerateCode` in src directory to re-generate.

``` yaml
title: Azure.Security.Attestation
require:
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/45c7ae94a46920c94b5e03e6a7d128d6cb7a364e/specification/attestation/data-plane/readme.md
namespace: Azure.Security.Attestation
tag: package-2020-10-01
azure-arm: false


directive:
- from: swagger-document
  where: $.definitions.PolicyResult
  transform: >
      $["x-csharp-usage"] = "model,input,output,converter";
      $["x-csharp-formats"] = "json";
- from: swagger-document
  where: $.definitions.AttestationResult
  transform: >
      $["x-csharp-usage"] = "model,input,output,converter";
      $["x-csharp-formats"] = "json";
- from: swagger-document
  where: $.definitions.PolicyCertificatesResult
  transform: >
      $["x-csharp-usage"] = "model,input,output,converter";
      $["x-csharp-formats"] = "json";
- from: swagger-document
  where: $.definitions.AttestationCertificateManagementBody
  transform: >
      $["x-csharp-usage"] = "model,input,output,converter";
      $["x-csharp-formats"] = "json";
- from: swagger-document
  where: $.definitions.PolicyCertificatesModificationResult
  transform: >
      $["x-csharp-usage"] = "model,input,output,converter";
      $["x-csharp-formats"] = "json";
- from: swagger-document
  where: $.definitions.PolicyCertificatesModification
  transform: >
      $["x-csharp-usage"] = "model,converter,input,output";
      $["x-csharp-formats"] = "json";
```
