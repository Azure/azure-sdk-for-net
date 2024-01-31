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
# Package sources for AutoRest support
- path: /nuget.config
  target: /nuget.config

# Shared
- path: /sdk/core/Azure.Core/src/Shared/AuthorizationChallengeParser.cs
  target: /Shared/Core/AuthorizationChallengeParser.cs
- path: /sdk/keyvault/Azure.Security.KeyVault.Shared/src/ChallengeBasedAuthenticationPolicy.cs
  target: /Shared/KeyVault/ChallengeBasedAuthenticationPolicy.cs
---

# Share links to Storage objects using Azure Key Vault-managed storage accounts

This sample demonstrates how to generate a client library for [Azure Key Vault-managed storage accounts](https://learn.microsoft.com/azure/key-vault/secrets/overview-storage-keys) and use it to generate [Shared Access Signature (SAS)](https://learn.microsoft.com/azure/storage/common/storage-sas-overview) tokens to Storage blobs or files.

> [!NOTE]
> We recommend you use [role-based access control (RBAC)](https://learn.microsoft.com/azure/role-based-access-control/overview) to secure access to your storage accounts. You can centrally manage access for users and applications to resources in a way that is consistent across Azure, and [works with Azure Active Directory](https://learn.microsoft.com/azure/storage/common/storage-auth-aad).

If you want to manage secrets, keys, or certificates, you can use our existing supported SDKs:

- [Azure.Security.KeyVault.Certificates](https://www.nuget.org/packages/Azure.Security.KeyVault.Certificates)
- [Azure.Security.KeyVault.Keys](https://www.nuget.org/packages/Azure.Security.KeyVault.Keys)
- [Azure.Security.KeyVault.Secrets](https://www.nuget.org/packages/Azure.Security.KeyVault.Secrets)

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

For more detail about this process, read [Manage storage account keys with Key Vault and the Azure CLI](https://learn.microsoft.com/azure/key-vault/secrets/overview-storage-keys).

## Building the sample

This sample not only demonstrates how to generate SAS definitions and tokens using Key Vault, but defines a REST client using our source generator we use for many other Azure SDKs. To build the project either as a standalone sample or within the [Azure/azure-sdk-for-net](https://github.com/Azure/azure-sdk-for-net) repository using [.NET Core 3.1](https://dot.net) or newer, simply run:

```dotnetcli
dotnet build
```

We have no plans to ship a package for Key Vault-managed storage accounts since RBAC is recommended, but if you need support for managed storage accounts you can copy the REST client source into your own projects by running:

```dotnetcli
dotnet build /t:CopySource /p:Destination=<ProjectDirectory>
```

The sample project file and _Program.cs_ are not copied automatically. Only the source necessary to build the REST client is copied. You are welcome to copy and modify the rest of the sample source as needed.

You also need to add references to Azure.Core and Microsoft.Azure.AutoRest.CSharp in your project. In your project directory where you just copied source run:

```dotnetcli
dotnet add package Azure.Core
dotnet add package Microsoft.Azure.AutoRest.CSharp --prerelease
```

## Using the sample

Once you have registered your storage account to be managed by Key Vault and built the sample, you can generate a SAS token by running the application directly:

```bash
sharelink --vault-name <KeyVaultName> --storage-account-name <StorageAccountName> --days 2
```

For more options, run `sharelink --help`.

You can also run the application from source using `dotnet run --`, passing any arguments after `--` to the program directly:

```dotnetcli
dotnet run -- --vault-name <KeyVaultName> --storage-account-name <StorageAccountName> --days 2
```

## Links

- [About Azure Key Vault secrets](https://learn.microsoft.com/azure/key-vault/secrets/about-secrets)
- [Azure Key Vault samples](https://aka.ms/azsdk/net/keyvault/samples)
- [Manage storage account keys with Key Vault and the Azure CLI](https://learn.microsoft.com/azure/key-vault/secrets/overview-storage-keys)
