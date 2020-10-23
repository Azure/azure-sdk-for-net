// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Azure.Security.KeyVault.Storage;
using Azure.Security.KeyVault.Storage.Models;
using System;
using System.Collections.Generic;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.CommandLine.IO;
using System.CommandLine.Parsing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

internal static class Program
{
    private static async Task<int> RunAsync(
        Uri vaultUri,
        string storageAccountName,
        int days,
        bool readOnly,
        IConsole console)
    {
        // Allow only credentials appropriate for this interactive tool sample.
        DefaultAzureCredential credential = new DefaultAzureCredential(
            new DefaultAzureCredentialOptions
            {
                ExcludeEnvironmentCredential = true,
                ExcludeManagedIdentityCredential = true,
            });

        // Use the same options for both clients, which allow logging of some other non-PII headers.
        SecretClientOptions options = new SecretClientOptions();

        // Create the Key Vault-managed Storage client to find the specified managed storage account.
        ManagedStorageRestClient storageClient = ManagedStorageRestClient.Create(vaultUri, credential, options);

        // Find the specified manage storage account.
        StorageAccountItem storageAccount = await FindStorageAccountAsync(storageClient, storageAccountName);

        if (storageAccount is null)
        {
            console.Error.WriteLine($"Error: '{storageAccountName}' is not currently managed by {vaultUri}");
            return 1;
        }

        // Build our SAS template, get an existing SAS definition, or create a new one.
        string sasTemplate = BuildSasDefinitionTemplate(readOnly);
        string sasDefinitionName = await GetOrCreateSasDefinitionAsync(storageClient, storageAccountName, sasTemplate, days, readOnly);

        // Now we can create a SecretClient and generate a new SAS token from the storage account and SAS definition names.
        SecretClient secretClient = new SecretClient(vaultUri, credential, options);
        KeyVaultSecret sasToken = await secretClient.GetSecretAsync($"{storageAccountName}-{sasDefinitionName}", cancellationToken: s_cancellationTokenSource.Token);

        console.Out.WriteLine(sasToken.Value);
        return 0;
    }

    private static async Task<StorageAccountItem> FindStorageAccountAsync(
        ManagedStorageRestClient storageClient,
        string storageAccountName)
    {
        for (StorageListResult result = await storageClient.GetStorageAccountsAsync(cancellationToken: s_cancellationTokenSource.Token); ;
             result = await storageClient.GetStorageAccountsNextPageAsync(result.NextLink, cancellationToken: s_cancellationTokenSource.Token))
        {
            foreach (StorageAccountItem storageAccount in result.Value)
            {
                // The storage account name is the segment of the ResourceId.
                int pos = storageAccount.ResourceId.AsSpan().TrimEnd('/').LastIndexOf('/');
                string name = storageAccount.ResourceId.Substring(pos + 1);

                if (string.Equals(storageAccountName, name, StringComparison.InvariantCultureIgnoreCase))
                {
                    return storageAccount;
                }
            }

            if (result.NextLink is null)
            {
                // No more results.
                return null;
            }
        }
    }

    private static string BuildSasDefinitionTemplate(bool readOnly) =>
        new StringBuilder("sv=2018-03-28")  // service version
            .Append("&spr=https")           // HTTPS only
            .Append("&ss=bf")               // blobs and files only
            .Append("&srt=o")               // applies to objects only
            .Append(readOnly ? "&sp=r" : "&sp=rw")  // read-only or read-write
            .ToString();

    private static async Task<string> GetOrCreateSasDefinitionAsync(
        ManagedStorageRestClient storageClient,
        string storageAccountName,
        string sasTemplate,
        int days,
        bool readOnly)
    {
        const string Tag = "ShareLinkSample";

        // Format the duration using ISO 8601.
        string duration = days > 0 ? XmlConvert.ToString(TimeSpan.FromDays(days)) : null;

        // Try to find an existing definition based on the template and duration, since the formatted name may have changed.
        for (SasDefinitionListResult result = await storageClient.GetSasDefinitionsAsync(storageAccountName, cancellationToken: s_cancellationTokenSource.Token); ;
             result = await storageClient.GetSasDefinitionsNextPageAsync(result.NextLink, storageAccountName, cancellationToken: s_cancellationTokenSource.Token))
        {
            foreach (SasDefinitionItem sasDefinitionInfo in result.Value.Where(d => d.Tags.ContainsKey(Tag)))
            {
                // The SAS definition name is the segment of the Id.
                int pos = sasDefinitionInfo.Id.AsSpan().TrimEnd('/').LastIndexOf('/');
                string name = sasDefinitionInfo.Id.Substring(pos + 1);

                SasDefinitionBundle foundSasDefinition = await storageClient.GetSasDefinitionAsync(storageAccountName, name, cancellationToken: s_cancellationTokenSource.Token);
                if (string.Equals(sasTemplate, foundSasDefinition.TemplateUri, StringComparison.OrdinalIgnoreCase) &&
                    string.Equals(duration, foundSasDefinition.ValidityPeriod, StringComparison.OrdinalIgnoreCase))
                {
                    return name;
                }
            }

            if (result.NextLink is null)
            {
                // No more results.
                break;
            }
        }

        // Create a new SAS definition since we didn't find an existing definition.
        string sasDefinitionName = BuildSasDefinitionName(Tag, readOnly, duration);
        SasDefinitionAttributes sasDefinitionAttributes = new SasDefinitionAttributes
        {
            Enabled = true,
        };

        Dictionary<string, string> tags = new Dictionary<string, string>
        {
            [Tag] = "1",
        };

        SasDefinitionBundle createdSasDefinition = await storageClient.SetSasDefinitionAsync(
            storageAccountName,
            sasDefinitionName,
            sasTemplate,
            SasTokenType.Account,
            duration,
            sasDefinitionAttributes,
            tags,
            s_cancellationTokenSource.Token);

        return sasDefinitionName;
    }

    private static string BuildSasDefinitionName(
        string prefix,
        bool readOnly,
        string duration)
    {
        StringBuilder sb = new StringBuilder(prefix)
            .Append(readOnly ? "ReadOnly" : "ReadWrite");

        if (duration is { })
        {
            sb.Append(duration);
        }

        return sb.ToString();
    }

    #region Configuration
    // Expose RootCommand for invoking directly via optional tests.
    internal static readonly RootCommand Command;
    private static readonly CancellationTokenSource s_cancellationTokenSource;

    static Program()
    {
        Command = new RootCommand("Generates a shareable link to a blob or file")
        {
            new Option<Uri>(
                alias: "--vault-name",
                description: "Key Vault name or URI, e.g. my-vault or https://my-vault-vault.azure.net",
                parseArgument: result =>
                {
                    string value = result.Tokens.Single().Value;
                    if (Uri.TryCreate(value, UriKind.Absolute, out Uri vaultUri) ||
                        Uri.TryCreate($"https://{value}.vault.azure.net", UriKind.Absolute, out vaultUri))
                    {
                        return vaultUri;
                    }

                    result.ErrorMessage = "Must specify a vault name or URI";
                    return null!;
                }
            )
            {
                Name = "vaultUri",
                IsRequired = true,
            },

            new Option<string>(
                alias: "--storage-account-name",
                description: "Storage account name managed by Key Vault"
            )
            {
                IsRequired = true,
            },

            new Option<int>(
                aliases: new[] { "-d", "--days" },
                description: "Number of days the link is valid; must be > 0",
                getDefaultValue: () => 0
            )
            {
                IsRequired = true,
            }.GreaterThan(0),

            new Option<bool>(
                aliases: new[] { "-r", "--read-only" },
                description: "Make the sharable link read-only"
            ),
        };

        Command.Handler = CommandHandler.Create<Uri, string, int, bool, IConsole>(RunAsync);

        s_cancellationTokenSource = new CancellationTokenSource();
    }

    private static async Task<int> Main(string[] args)
    {
        Console.CancelKeyPress += (_, args) =>
        {
            Console.Error.WriteLine("Canceling...");
            s_cancellationTokenSource.Cancel();

            args.Cancel = true;
        };

        return await Command.InvokeAsync(args);
    }
    #endregion

    #region Extensions
    internal static Option<int> GreaterThan(this Option<int> option, int value)
    {
        option.AddValidator(r =>
            r.Tokens
                .Select(t => t.Value)
                .Where(v => !int.TryParse(v, out int i) || i <= value)
                .Select(_ => $"Option '{r.Symbol.Name}' must be greater than {value}")
                .FirstOrDefault());

        return option;
    }
   #endregion
}
