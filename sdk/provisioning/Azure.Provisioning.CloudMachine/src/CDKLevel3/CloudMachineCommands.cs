// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System;
using System.ClientModel.TypeSpec;
using System.ClientModel.Primitives;
using Azure.AI.OpenAI;
using Azure.Core;
using Azure.Identity;
using System.Text.Json;

namespace Azure.CloudMachine;

public class CloudMachineCommands
{
    public static bool Execute(string[] args, Action<CloudMachineInfrastructure>? configure = default, bool exitProcessIfHandled = true)
    {
        if (args.Length < 1) return false;

        string cmid = AzdHelpers.ReadOrCreateCmid();
        CloudMachineInfrastructure cmi = new(cmid);
        if (configure != default)
        {
            configure(cmi);
        }

        if (args[0] == "-bicep")
        {
            GenerateBicep(cmi);
            return Handled(exitProcessIfHandled);
        }

        if (args[0] == "-tsp")
        {
            GenerateTsp(cmi);
            return Handled(exitProcessIfHandled);
        }

        if (args[0] == "-ai")
        {
            string? option = (args.Length > 1) ? args[1] : default;
            ListAzureOpenaAIModels(cmid, option);
            return Handled(exitProcessIfHandled);
        }

        return false;

        bool Handled(bool exitProcessIfHandled)
        {
            if (exitProcessIfHandled) Environment.Exit(0);
            return true;
        }
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
        RestClient client = new RestClient(auth);
        string uri = $"https://{cmid}.openai.azure.com/openai/models?api-version=2024-10-21";
        RequestOptions options = new RequestOptions();
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
                if (caps.GetProperty("embeddings"u8).GetBoolean() == true)                                  {
                    scenario = "embeddings";
                }
                if (caps.GetProperty("inference"u8).GetBoolean() == false)
                {
                    scenario = default; // inference==false means model cannot be deployed
                }

                if (scenario == default) continue;

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

    private static void GenerateTsp(CloudMachineInfrastructure cmi)
    {
        foreach (Type endpoints in cmi.Endpoints)
        {
            string name = endpoints.Name;
            if (name.StartsWith("I"))
                name = name.Substring(1);
            string directory = Path.Combine(".", "tsp");
            string tspFile = Path.Combine(directory, $"{name}.tsp");
            Directory.CreateDirectory(Path.GetDirectoryName(tspFile));
            if (File.Exists(tspFile))
                File.Delete(tspFile);
            using FileStream stream = File.OpenWrite(tspFile);
            TypeSpecWriter.WriteServer(stream, endpoints);
        }
    }

    private static void GenerateBicep(CloudMachineInfrastructure cmi)
    {
        string infraDirectory = Path.Combine(".", "infra");
        AzdHelpers.Init(infraDirectory, cmi);
    }
}
