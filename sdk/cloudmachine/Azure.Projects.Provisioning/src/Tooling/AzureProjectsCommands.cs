// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using Azure.Core;
using Azure.Core.Rest;
using Azure.Identity;

namespace Azure.Projects;

public static class AzureProjectsCommands
{
    public static bool TryExecuteCommand(this ProjectInfrastructure infrastructure, string[] args)
    {
        if (args.Length < 1)
            return false;

        string cmid = ProjectClient.ReadOrCreateProjectId();

        if (args[0] == "-bicep")
        {
            Azd.Init(infrastructure);
            return true;
        }

        if (args[0] == "-init")
        {
            Azd.Init(infrastructure);

            string? projName = default;
            if (args.Length > 1)
            {
                projName = args[1];
            }
            Azd.InitDeployment(infrastructure, projName);
            return true;
        }

        if (args[0] == "-ai")
        {
            string? option = (args.Length > 1) ? args[1] : default;
            ListAzureOpenaAIModels(cmid, option);
            return true;
        }

        return false;
    }

    // this implements: https://learn.microsoft.com/en-us/rest/api/azureopenai/models/list
    private static void ListAzureOpenaAIModels(string cmid, string? option)
    {
        // TODO: we should dedup these, i.e. CM code should always use the same default creds
        TokenCredential credential = new ChainedTokenCredential(
            new AzureCliCredential(),
            new AzureDeveloperCliCredential()
        );
        string audience = "https://cognitiveservices.azure.com/.default";
        TokenCredentialAuthenticationPolicy auth = new(credential, [audience]);
        RestClient client = new(auth);
        string uri = $"https://{cmid}.openai.azure.com/openai/models?api-version=2024-10-21";
        PipelineResponse response = client.Get(uri);
        if (response.Status != 200)
        {
            throw new Exception($"Failed to list models: {response.Status}");
        }

        using JsonDocument json = JsonDocument.Parse(response.Content);
        JsonElement root = json.RootElement;
        JsonElement data = root.GetProperty("data");
        Console.WriteLine("deprecated | model ID");
        Console.WriteLine("------------------------------------------");
        foreach (JsonElement model in data.EnumerateArray())
        {
            if (model.GetProperty("status").ValueEquals("succeeded"u8))
            {
                JsonElement caps = model.GetProperty("capabilities"u8);
                string? scenario = default;
                if (caps.GetProperty("chat_completion"u8).GetBoolean() == true)
                {
                    scenario = "chat";
                }
                if (caps.GetProperty("embeddings"u8).GetBoolean() == true)
                {
                    scenario = "embeddings";
                }
                if (caps.GetProperty("inference"u8).GetBoolean() == false)
                {
                    scenario = default; // inference==false means model cannot be deployed
                }

                if (scenario == default)
                    continue;

                if (scenario != default)
                {
                    string modelId = model.GetProperty("id"u8).GetString()!;
                    JsonElement deprecation = model.GetProperty("deprecation");
                    long ticks = deprecation.GetProperty("inference"u8).GetInt64();
                    var dto = DateTimeOffset.FromUnixTimeSeconds(ticks);
                    var deprecatedAt = dto.ToString("yyyy-MM-dd");

                    if (option == default)
                        Console.WriteLine($"{deprecatedAt} | {modelId} ({scenario})");
                    else if (option == scenario)
                        Console.WriteLine($"{deprecatedAt} | {modelId}");
                }
            }
        }
    }
}
