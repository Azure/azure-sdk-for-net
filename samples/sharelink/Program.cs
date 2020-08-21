// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.Linq;
using System.Threading.Tasks;

internal static class Program
{
    internal static readonly RootCommand Command;
    
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

            new Option<string>(
                alias: "--resource-id",
                description: "Optional blob or file resource ID"
            ),

            new Option<int?>(
                aliases: new[] { "-d", "--days" },
                description: "Optional number of days the link is valid"
            ),

            new Option<bool>(
                aliases: new[] { "-r", "--read-only" },
                description: "Optionally make the sharable link read-only"
            ),
        };

        Command.Handler = CommandHandler.Create<Uri, string, string, int?, bool, IConsole>(RunAsync);
    }

    private static async Task<int> Main(string[] args) => await Command.InvokeAsync(args);

    private static Task<int> RunAsync(
        Uri vaultUri,
        string storageAccountName,
        string resourceId,
        int? days,
        bool readOnly,
        IConsole console)
    {
        console.Out.Write($"vaultUri: {vaultUri}, storageAccountName:{storageAccountName}, resourceId: {resourceId}, days: {days}, readOnly: {readOnly}\n");

        return Task.FromResult(0);
    }
}