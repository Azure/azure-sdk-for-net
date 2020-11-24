---
page_type: sample
languages:
- csharp
products:
- azure
- azure-key-vault
urlFragment: share-link
name: ShareLink
description: Demonstrates how to generate a client for Key Vault-managed storage accounts and generate SAS tokens.
extendedZipContent:
# Shared/AutoRest
- path: /sdk/core/Azure.Core/src/Shared/AutoRest/ArmOperationHelpers.cs
  target: /Shared/AutoRest/ArmOperationHelpers.cs
- path: /sdk/core/Azure.Core/src/Shared/AutoRest/ChangeTrackingDictionary.cs
  target: /Shared/AutoRest/ChangeTrackingDictionary.cs
- path: /sdk/core/Azure.Core/src/Shared/AutoRest/ChangeTrackingList.cs
  target: /Shared/AutoRest/ChangeTrackingList.cs
- path: /sdk/core/Azure.Core/src/Shared/AutoRest/CodeGenClientAttribute.cs
  target: /Shared/AutoRest/CodeGenClientAttribute.cs
- path: /sdk/core/Azure.Core/src/Shared/AutoRest/CodeGenMemberAttribute.cs
  target: /Shared/AutoRest/CodeGenMemberAttribute.cs
- path: /sdk/core/Azure.Core/src/Shared/AutoRest/CodeGenModelAttribute.cs
  target: /Shared/AutoRest/CodeGenModelAttribute.cs
- path: /sdk/core/Azure.Core/src/Shared/AutoRest/CodeGenSuppressAttribute.cs
  target: /Shared/AutoRest/CodeGenSuppressAttribute.cs
- path: /sdk/core/Azure.Core/src/Shared/AutoRest/CodeGenTypeAttribute.cs
  target: /Shared/AutoRest/CodeGenTypeAttribute.cs
- path: /sdk/core/Azure.Core/src/Shared/AutoRest/IOperationSource.cs
  target: /Shared/AutoRest/IOperationSource.cs
- path: /sdk/core/Azure.Core/src/Shared/AutoRest/IUtf8JsonSerializable.cs
  target: /Shared/AutoRest/IUtf8JsonSerializable.cs
- path: /sdk/core/Azure.Core/src/Shared/AutoRest/IXmlSerializable.cs
  target: /Shared/AutoRest/IXmlSerializable.cs
- path: /sdk/core/Azure.Core/src/Shared/AutoRest/JsonElementExtensions.cs
  target: /Shared/AutoRest/JsonElementExtensions.cs
- path: /sdk/core/Azure.Core/src/Shared/AutoRest/ManagementPipelineBuilder.cs
  target: /Shared/AutoRest/ManagementPipelineBuilder.cs
- path: /sdk/core/Azure.Core/src/Shared/AutoRest/OperationFinalStateVia.cs
  target: /Shared/AutoRest/OperationFinalStateVia.cs
- path: /sdk/core/Azure.Core/src/Shared/AutoRest/Optional.cs
  target: /Shared/AutoRest/Optional.cs
- path: /sdk/core/Azure.Core/src/Shared/AutoRest/Page.cs
  target: /Shared/AutoRest/Page.cs
- path: /sdk/core/Azure.Core/src/Shared/AutoRest/PageableHelpers.cs
  target: /Shared/AutoRest/PageableHelpers.cs
- path: /sdk/core/Azure.Core/src/Shared/AutoRest/RawRequestUriBuilder.cs
  target: /Shared/AutoRest/RawRequestUriBuilder.cs
- path: /sdk/core/Azure.Core/src/Shared/AutoRest/RequestHeaderExtensions.cs
  target: /Shared/AutoRest/RequestHeaderExtensions.cs
- path: /sdk/core/Azure.Core/src/Shared/AutoRest/RequestUriBuilderExtensions.cs
  target: /Shared/AutoRest/RequestUriBuilderExtensions.cs
- path: /sdk/core/Azure.Core/src/Shared/AutoRest/ResponseHeadersExtensions.cs
  target: /Shared/AutoRest/ResponseHeadersExtensions.cs
- path: /sdk/core/Azure.Core/src/Shared/AutoRest/ResponseWithHeaders.cs
  target: /Shared/AutoRest/ResponseWithHeaders.cs
- path: /sdk/core/Azure.Core/src/Shared/AutoRest/ResponseWithHeaders{T,THeaders}.cs
  target: /Shared/AutoRest/ResponseWithHeaders{T,THeaders}.cs
- path: /sdk/core/Azure.Core/src/Shared/AutoRest/ResponseWithHeaders{THeaders}.cs
  target: /Shared/AutoRest/ResponseWithHeaders{THeaders}.cs
- path: /sdk/core/Azure.Core/src/Shared/AutoRest/StringRequestContent.cs
  target: /Shared/AutoRest/StringRequestContent.cs
- path: /sdk/core/Azure.Core/src/Shared/AutoRest/TypeFormatters.cs
  target: /Shared/AutoRest/TypeFormatters.cs
- path: /sdk/core/Azure.Core/src/Shared/AutoRest/Utf8JsonRequestContent.cs
  target: /Shared/AutoRest/Utf8JsonRequestContent.cs
- path: /sdk/core/Azure.Core/src/Shared/AutoRest/Utf8JsonWriterExtensions.cs
  target: /Shared/AutoRest/Utf8JsonWriterExtensions.cs
- path: /sdk/core/Azure.Core/src/Shared/AutoRest/XElementExtensions.cs
  target: /Shared/AutoRest/XElementExtensions.cs
- path: /sdk/core/Azure.Core/src/Shared/AutoRest/XmlWriterContent.cs
  target: /Shared/AutoRest/XmlWriterContent.cs
- path: /sdk/core/Azure.Core/src/Shared/AutoRest/XmlWriterExtensions.cs
  target: /Shared/AutoRest/XmlWriterExtensions.cs

# Shared/Core
- path: /sdk/core/Azure.Core/src/Shared/ClientDiagnostics.cs
  target: /Shared/Core/ClientDiagnostics.cs
- path: /sdk/core/Azure.Core/src/Shared/ContentTypeUtilities.cs
  target: /Shared/Core/ContentTypeUtilities.cs
- path: /sdk/core/Azure.Core/src/Shared/DiagnosticScope.cs
  target: /Shared/Core/DiagnosticScope.cs
- path: /sdk/core/Azure.Core/src/Shared/DiagnosticScopeFactory.cs
  target: /Shared/Core/DiagnosticScopeFactory.cs
- path: /sdk/core/Azure.Core/src/Shared/HashCodeBuilder.cs
  target: /Shared/Core/HashCodeBuilder.cs
- path: /sdk/core/Azure.Core/src/Shared/HttpMessageSanitizer.cs
  target: /Shared/Core/HttpMessageSanitizer.cs
- path: /sdk/core/Azure.Core/src/Shared/OperationHelpers.cs
  target: /Shared/Core/OperationHelpers.cs
- path: /sdk/core/Azure.Core/src/Shared/TaskExtensions.cs
  target: /Shared/Core/TaskExtensions.cs

# Share
- path: /sdk/keyvault/Azure.Security.KeyVault.Shared/src/ChallengeBasedAuthenticationPolicy.cs
  target: /Shared/ChallengeBasedAuthenticationPolicy.cs
---

# Share links to Storage objects using Azure Key Vault-managed storage accounts

This sample demonstrates how to generate a client library for [Azure Key Vault-managed storage accounts](https://docs.microsoft.com/azure/key-vault/secrets/overview-storage-keys) and use it to generate [Shared Access Signature (SAS)](https://docs.microsoft.com/azure/storage/common/storage-sas-overview) tokens to Storage blobs or files.

> [!NOTE]
> We recommend you use [role-based access control (RBAC)](https://docs.microsoft.com/azure/role-based-access-control/overview) to secure access to your storage accounts. You can centrally manage access for users and applications to resources in a way that is consistent across Azure, and [works with Azure Active Directory](https://docs.microsoft.com/azure/storage/common/storage-auth-aad).

## Getting started

Before you can use this sample to create SAS tokens to share storage objects, you need to register the storage account with Key Vault. The following instructions require installing the [Azure CLI](https://aka.ms/azure-cli).

1. Log into Azure using the CLI:

   ```bash
   az login
   ```

2. Find your storage account ID given the storage account name:

   ```bash
   az storage account show --name <StorageAccountName> --query id
   ```

3. Give Key Vault access to your storage account using the ID retrieved above:

   ```bash
   az role assignment create --role "Storage Account Key Operator Service Role" --assignee "https://vault.azure.net" --scope "/subscriptions/<SubscriptionID>/resourceGroups/<StorageAccountResourceGroupName>/providers/Microsoft.Storage/storageAccounts/<StorageAccountName>"
   ```

4. Make sure your user account has permissions to manage storage accounts. Use the same account with which you logged into Azure in step 1.

   ```bash
   az keyvault set-policy --name <KeyVaultName> --upn <user@domain.com> --storage-permissions get list set update regeneratekey getsas listsas setsas
   ```

5. Register your storage account with Key Vault. Key Vault will take over management of storage account keys and regenerate them automatically as specified, e.g. every 90 days.

   ```bash
   az keyvault storage add --vault-name <KeyVaultName> -n <StorageAccountName> --active-key-name key1 --auto-regenerate-key --regeneration-period P90D --resource-id "/subscriptions/<SubscriptionID>/resourceGroups/<StorageAccountResourceGroupName>/providers/Microsoft.Storage/storageAccounts/<StorageAccountName>"
   ```

For more detail about this process, read [Manage storage account keys with Key Vault and the Azure CLI](https://docs.microsoft.com/azure/key-vault/secrets/overview-storage-keys).

## Building the sample

This sample not only demonstrates how to generate SAS definitions and tokens using Key Vault, but defines a REST client using our source generator we use for many other Azure SDKs. To build the project either as a standalone sample or within the [Azure/azure-sdk-for-net](https://github.com/Azure/azure-sdk-for-net) repository using [.NET Core 3.1](https://dot.net) or newer, simply run:

```bash
dotnet build
```

We have no plans to ship a package for Key Vault-managed storage accounts since RBAC is recommended, but if you need support for managerd storage accounts you can copy the REST client source into your own projects by running:

```bash
dotnet msbuild /t:CopySource /p:Destination=<ProjectDirectory>
```

The sample project file and _Program.cs_ are not copied automatically - only the source necessary to build the REST client. You are welcome to copy and modify the rest of the sample source as needed.

## Using the sample

Once you have registered your storage account to be managed by Key Vault and built the sample, you can generate a SAS token by running the application directly:

```bash
sharelink --vault-name <KeyVaultName> --storage-account-name <StorageAccountName> --days 2
```

For more options, run `sharelink --help`.

You can also run the application from source using `dotnet run --`, passing any arguments after `--` to the program directly:

```bash
dotnet run -- --vault-name <KeyVaultName> --storage-account-name <StorageAccountName> --days 2
```

## Links

- [About Azure Key Vault secrets](https://docs.microsoft.com/azure/key-vault/secrets/about-secrets)
- [Azure Key Vault samples](https://aka.ms/azsdk/net/keyvault/samples)
- [Manage storage account keys with Key Vault and the Azure CLI](https://docs.microsoft.com/azure/key-vault/secrets/overview-storage-keys)
