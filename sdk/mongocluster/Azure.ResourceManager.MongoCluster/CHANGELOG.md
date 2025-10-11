# Release History

## 1.0.0-beta.2 (2025-09-30)

### Features Added
- Upgraded api-version tag to 'package-2025-08-01-preview'. Tag detail available at https://github.com/Azure/azure-rest-api-specs/blob/main/specification/mongocluster/resource-manager/Microsoft.DocumentDB/MongoCluster/readme.md#tag-package-2025-08-01-preview.
  - Added DataApi support on MongoClusterProperties
  - Added AuthConfig support on MongoClusterProperties
  - Added Encryption support on MongoClusterProperties
  - Added Identity support on MongoClusterData
  - Added property type to StorageProperties
  - Added model AuthConfigProperties
  - Added model AuthenticationMode
  - Added model CustomerManagedKeyEncryptionProperties
  - Added model DataApiMode
  - Added model DataApiProperties
  - Added model DatabaseRole
  - Added model EncryptionProperties
  - Added model EntraIdentityProvider
  - Added model EntraIdentityProviderProperties
  - Added model EntraPrincipalType 
  - Added model IdentityProvider
  - Added model IdentityProviderType
  - Added model KeyEncryptionKeyIdentity
  - Added model KeyEncryptionKeyIdentityType
  - Added model StorageType
  - Added new resource User
  - Added User operations on MongoClusterResource
  - Added model UserProperties
  - Added model UserRole

## 1.0.0-beta.1 (2024-08-30)

### Features Added

This package follows the [new Azure SDK guidelines](https://azure.github.io/azure-sdk/general_introduction.html), and provides many core capabilities:

    - Support MSAL.NET, Azure.Identity is out of box for supporting MSAL.NET.
    - Support [OpenTelemetry](https://opentelemetry.io/) for distributed tracing.
    - HTTP pipeline with custom policies.
    - Better error-handling.
    - Support uniform telemetry across all languages.

This package is a Public Preview version, so expect incompatible changes in subsequent releases as we improve the product. To provide feedback, submit an issue in our [Azure SDK for .NET GitHub repo](https://github.com/Azure/azure-sdk-for-net/issues).

> NOTE: For more information about unified authentication, please refer to [Microsoft Azure Identity documentation for .NET](https://learn.microsoft.com/dotnet/api/overview/azure/identity-readme?view=azure-dotnet).
