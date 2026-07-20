// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.ClientModel.Tests.Proxy.FirstPartyA;
using System.ClientModel.Tests.Proxy.OpenAILike;
using System.ClientModel.Tests.Proxy.OpenAILike.Mocks;
using System.ClientModel.Tests.Proxy.ThirdPartyB;

// A real, runnable end-to-end program for the MRW proxy feature. It shows the two injection styles:
//   - FirstPartyA is a Microsoft library that extends OpenAI and hides its proxy INSIDE its own
//     client (FirstPartyToolsClient) — the end user never registers or even sees a proxy.
//   - ThirdPartyB is an independent third-party library whose proxy the customer registers explicitly.
// Each case: mock the response, make a real client call through a ClientPipeline, and verify the
// expected derived type comes back. Exits 0 on success, 1 on failure.

int failures = 0;

Console.WriteLine("MRW proxy — end-to-end demo");
Console.WriteLine("===========================");

// --- Case 1: FirstPartyA hides its proxy -> the end user just uses the client, "azure_search" routes ---
{
    var transport = new CannedResponseTransport("{\"type\":\"azure_search\",\"index_name\":\"docs\"}");

    // The end user constructs the first-party client and never registers a proxy.
    var client = new FirstPartyToolsClient(new ClientPipelineOptions { Transport = transport });

    ResponseTool tool = client.GetTool("tool-1");

    if (tool is AzureSearchTool azure && tool.GetType().Assembly == typeof(AzureSearchTool).Assembly)
    {
        Console.WriteLine($"PASS  azure_search  -> {tool.GetType().FullName} (IndexName={azure.IndexName}) " +
                          $"from {tool.GetType().Assembly.GetName().Name}.dll (proxy hidden by first party)");
    }
    else
    {
        Console.Error.WriteLine($"FAIL  azure_search  -> expected AzureSearchTool from FirstPartyA, got {tool.GetType().FullName}");
        failures++;
    }
}

// --- Case 2: first-party (hidden) proxy + an explicit third-party proxy coexist; "bing_grounding" routes to ThirdPartyB ---
// Proves the two independent DLLs coexist and each proxy only claims its own discriminator (note 18).
{
    var transport = new CannedResponseTransport("{\"type\":\"bing_grounding\",\"market\":\"en-US\"}");

    // The customer layers the third-party Bing proxy on top; the first-party proxy stays hidden.
    var client = new FirstPartyToolsClient(new ClientPipelineOptions { Transport = transport }, o => o.AddBingTools());

    ResponseTool tool = client.GetTool("tool-2");

    if (tool is BingGroundingTool bing && tool.GetType().Assembly == typeof(BingGroundingTool).Assembly)
    {
        Console.WriteLine($"PASS  bing_grounding-> {tool.GetType().FullName} (Market={bing.Market}) " +
                          $"from {tool.GetType().Assembly.GetName().Name}.dll");
    }
    else
    {
        Console.Error.WriteLine($"FAIL  bing_grounding-> expected BingGroundingTool from ThirdPartyB, got {tool.GetType().FullName}");
        failures++;
    }
}

// --- Case 3: plain OpenAI client, no proxy -> base fallback (proves the proxy is what changes behavior) ---
{
    ModelReaderWriterOptions options = new ModelReaderWriterOptions("J"); // no proxy registered
    var transport = new CannedResponseTransport("{\"type\":\"azure_search\",\"index_name\":\"docs\"}");
    var client = new ResponseToolsClient(new ClientPipelineOptions { Transport = transport }, options);

    ResponseTool tool = client.GetTool("tool-3");

    if (tool is UnknownResponseTool)
    {
        Console.WriteLine($"PASS  no proxy      -> {tool.GetType().FullName} (base fallback, as expected)");
    }
    else
    {
        Console.Error.WriteLine($"FAIL  no proxy      -> expected UnknownResponseTool, got {tool.GetType().FullName}");
        failures++;
    }
}

Console.WriteLine();
Console.WriteLine(failures == 0
    ? "END-TO-END OK: the first-party client routed its hidden proxy and coexisted with an explicit third-party proxy."
    : $"END-TO-END FAILED: {failures} check(s) failed.");

return failures == 0 ? 0 : 1;
