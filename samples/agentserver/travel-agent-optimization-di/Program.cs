// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Optimization;
using Azure.AI.AgentServer.Optimization.Configuration.Samples;
using Azure.AI.AgentServer.Responses;
using Azure.AI.OpenAI;
using Azure.Identity;
using Microsoft.Agents.AI;
using Microsoft.Extensions.AI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

// ──────────────────────────────────────────────────────────────────────
// This sample demonstrates the DI / IConfiguration integration provided
// by Azure.AI.AgentServer.Optimization.Configuration.
//
// Instead of calling OptimizationOptionsLoader.LoadAsync() procedurally,
// it registers AddOptimizationConfigSource() on the IConfigurationBuilder
// and reads the bound OptimizationOptions from IConfiguration. This gives
// you first-class integration with ASP.NET's configuration pipeline:
//   - Reload semantics (via IOptionsMonitor<OptimizationOptions>)
//   - Layering with other configuration sources (appsettings, env, etc.)
//   - Consistent with the rest of the DI container
// ──────────────────────────────────────────────────────────────────────

ResponsesServer.Run<TravelHandler>(args, builder =>
{
    // ── 1. Add the optimization configuration source ────────────
    // AddOptimizationConfigSource() requires IConfigurationBuilder.
    // AgentHostBuilder.WebApplicationBuilder.Configuration is a ConfigurationManager
    // which implements both IConfiguration and IConfigurationBuilder.
    builder.WebApplicationBuilder.Configuration.AddOptimizationConfigSource();

    // ── 2. Read the bound options from IConfiguration ───────────
    OptimizationOptions config = builder.Configuration.GetOptimizationOptions();

    LogStartupConfig(config);

    // ── 3. Build the Azure OpenAI client ────────────────────────
    string aoaiEndpoint = ResolveAzureOpenAIEndpoint();
    Console.Error.WriteLine($"[Startup] AzureOpenAI endpoint: {aoaiEndpoint}");
    var aoaiClient = new AzureOpenAIClient(new Uri(aoaiEndpoint), new DefaultAzureCredential());

    // ── 4. Build the Microsoft Agent Framework AIAgent ──────────
    string instructions = config.ComposeInstructions()
        is { Length: > 0 } composed
            ? composed
            : "You are a helpful travel assistant.";
    string model = config.Model ?? "gpt-4.1-mini";
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

    // ── 5. Register services in DI ──────────────────────────────
    builder.Services.AddSingleton(aoaiClient);
    builder.Services.AddSingleton(agent);
    builder.Services.AddSingleton(config);
});

static string ResolveAzureOpenAIEndpoint()
{
    // Try explicit OpenAI endpoint first, then fall back to project endpoint.
    // Always strip to host-only — AzureOpenAIClient appends /openai/... itself.
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

static void LogStartupConfig(OptimizationOptions config)
{
    if (string.IsNullOrEmpty(config.Instructions) && string.IsNullOrEmpty(config.Model))
    {
        Console.Error.WriteLine("[Startup] No optimization config found — using defaults.");
        return;
    }

    Console.Error.WriteLine("[Startup] ── Optimization Config (via IConfiguration) ──");
    Console.Error.WriteLine($"[Startup] Source:       {config.Source ?? "(bound via config)"}");
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
    Console.Error.WriteLine("[Startup] ──────────────────────────────────────────────");
}
