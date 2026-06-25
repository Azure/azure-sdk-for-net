// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Optimization;
using Azure.AI.AgentServer.Optimization.Samples;
using Azure.AI.AgentServer.Responses;
using Azure.AI.OpenAI;
using Azure.Identity;
using Microsoft.Agents.AI;
using Microsoft.Extensions.AI;
using Microsoft.Extensions.DependencyInjection;

var credential = new DefaultAzureCredential();
string? projectEndpoint = Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT")
    ?? Environment.GetEnvironmentVariable("AZURE_AI_PROJECT_ENDPOINT");

AgentOptimizationClient optimizationClient = !string.IsNullOrEmpty(projectEndpoint)
    ? new AgentOptimizationClient(new Uri(projectEndpoint), credential)
    : new LocalFallbackAgentOptimizationClient();

OptimizationOptions? config = await optimizationClient.ResolveOptionsAsync(new LoadOptions
{
    Credential = credential,
}).ConfigureAwait(false);

LogStartupConfig(config);

IReadOnlyList<OptimizationSkill>? loadedSkills = null;
if (config?.SkillsDirectory is not null)
{
    loadedSkills = AgentOptimizationClient.LoadSkillsFromDirectory(config.SkillsDirectory);
    Console.WriteLine($"[Startup] Loaded {loadedSkills.Count} skill(s) from {config.SkillsDirectory}");
}

string aoaiEndpoint = ResolveAzureOpenAIEndpoint();
Console.Error.WriteLine($"[Startup] AzureOpenAI endpoint: {aoaiEndpoint}");
var aoaiClient = new AzureOpenAIClient(new Uri(aoaiEndpoint), credential);

string instructions = config?.ComposeInstructions() ?? "You are a helpful travel assistant.";
string model = config?.Model ?? "gpt-4.1-mini";
Console.Error.WriteLine($"[Startup] Building MAF agent — model={model}, instructionsLen={instructions.Length}");

AIAgent agent = aoaiClient
    .GetChatClient(model)
    .AsIChatClient()
    .AsAIAgent(
        name: "TravelPlanAgent",
        instructions: instructions,
        tools:
        [
            AIFunctionFactory.Create((Func<string>)TravelTools.GetRandomDestination),
            AIFunctionFactory.Create((Func<string, string, string, string>)TravelTools.SearchFlights),
            AIFunctionFactory.Create((Func<string, string, string, string>)TravelTools.GetHotelPrices),
        ]);

ResponsesServer.Run<TravelHandler>(args, builder =>
{
    builder.Services.AddSingleton(aoaiClient);
    builder.Services.AddSingleton(agent);
    if (config is not null)
    {
        builder.Services.AddSingleton(config);
    }
    if (loadedSkills is not null)
    {
        builder.Services.AddSingleton(loadedSkills);
    }
});

static string ResolveAzureOpenAIEndpoint()
{
    var explicitEndpoint = Environment.GetEnvironmentVariable("AZURE_AI_OPENAI_ENDPOINT");
    if (!string.IsNullOrWhiteSpace(explicitEndpoint))
    {
        var uri = new Uri(explicitEndpoint);
        return $"{uri.Scheme}://{uri.Host}/";
    }

    var projectEndpoint = Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT")
        ?? Environment.GetEnvironmentVariable("AZURE_AI_PROJECT_ENDPOINT");
    if (!string.IsNullOrWhiteSpace(projectEndpoint))
    {
        var uri = new Uri(projectEndpoint);
        return $"{uri.Scheme}://{uri.Host}/";
    }

    throw new InvalidOperationException(
        "Cannot resolve Azure OpenAI endpoint. Set AZURE_AI_OPENAI_ENDPOINT or FOUNDRY_PROJECT_ENDPOINT.");
}

static void LogStartupConfig(OptimizationOptions? config)
{
    if (config is null)
    {
        Console.Error.WriteLine("[Startup] No optimization config found — using defaults.");
        return;
    }

    Console.Error.WriteLine("[Startup] ── Optimization Config ──────────────────────");
    Console.Error.WriteLine($"[Startup] Source:       {config.Source}");
    Console.Error.WriteLine($"[Startup] Model:        {config.Model ?? "(not set)"}");
    Console.Error.WriteLine($"[Startup] Temperature:  {config.Temperature?.ToString() ?? "(not set)"}");
    Console.Error.WriteLine($"[Startup] CandidateId:  {config.CandidateId ?? "(none)"}");
    Console.Error.WriteLine($"[Startup] HasSkills:    {config.HasSkills}");
    Console.Error.WriteLine($"[Startup] Skills:       {config.Skills.Count}");
    foreach (var skill in config.Skills)
    {
        Console.Error.WriteLine($"[Startup]   • {skill.Name}: {skill.Description}");
    }
    Console.Error.WriteLine($"[Startup] Tools:        {config.ToolDefinitions.Count}");
    foreach (var tool in config.ToolDefinitions)
    {
        Console.Error.WriteLine($"[Startup]   🔧 {tool.Name}: {(string.IsNullOrEmpty(tool.Description) ? "(no desc)" : tool.Description)}");
    }
    Console.Error.WriteLine($"[Startup] SkillsDir:    {config.SkillsDirectory ?? "(none)"}");
    Console.Error.WriteLine("[Startup] ── Instructions ─────────────────────────────");
    Console.Error.WriteLine(config.Instructions ?? "(no instructions)");
    Console.Error.WriteLine("[Startup] ── Composed Instructions (with skills) ─────");
    Console.Error.WriteLine(config.ComposeInstructions());
    Console.Error.WriteLine("[Startup] ────────────────────────────────────────────");
}

file sealed class LocalFallbackAgentOptimizationClient : AgentOptimizationClient
{
}
