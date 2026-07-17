// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.ClientModel.Tests.Proxy.OpenAILike;
using System.ClientModel.Tests.Proxy.OpenAILike.Mocks;
using System.ClientModel.Tests.Proxy.ThirdPartyA;
using System.ClientModel.Tests.Proxy.ThirdPartyB;

// A real, runnable end-to-end program for the MRW proxy feature. It performs the exact loop Michael
// described (notes 17 & 18): a customer app depends on TWO independent third-party DLLs that each
// extend OpenAI with their own tool + proxy, registers BOTH proxies on its client, and the mocked
// responses route to the right third-party type. It: (1) registers the proxies, (2) mocks the
// response, (3) makes a real client call through a ClientPipeline, and (4) verifies the expected
// derived type is returned. Exits 0 on success, 1 on failure.

int failures = 0;

Console.WriteLine("MRW proxy — end-to-end demo");
Console.WriteLine("===========================");

// The customer app has BOTH third-party DLLs and registers one proxy from each (note 18).
static ModelReaderWriterOptions CustomerOptions()
    => new ModelReaderWriterOptions("J").AddAzureTools().AddBingTools();

// --- Case 1: both proxies registered -> ThirdPartyA (Azure) handles "azure_search" ---
{
    var transport = new CannedResponseTransport("{\"type\":\"azure_search\",\"index_name\":\"docs\"}");
    var client = new ResponseToolsClient(new ClientPipelineOptions { Transport = transport }, CustomerOptions());

    ResponseTool tool = client.GetTool("tool-1");

    if (tool is AzureSearchTool azure && tool.GetType().Assembly == typeof(AzureSearchTool).Assembly)
    {
        Console.WriteLine($"PASS  azure_search  -> {tool.GetType().FullName} (IndexName={azure.IndexName}) " +
                          $"from {tool.GetType().Assembly.GetName().Name}.dll");
    }
    else
    {
        Console.Error.WriteLine($"FAIL  azure_search  -> expected AzureSearchTool from ThirdPartyA, got {tool.GetType().FullName}");
        failures++;
    }
}

// --- Case 2: both proxies registered -> ThirdPartyB (Bing) handles "bing_grounding" ---
// Proves the two independent DLLs coexist and each proxy only claims its own discriminator.
{
    var transport = new CannedResponseTransport("{\"type\":\"bing_grounding\",\"market\":\"en-US\"}");
    var client = new ResponseToolsClient(new ClientPipelineOptions { Transport = transport }, CustomerOptions());

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

// --- Case 3: no proxy -> base fallback (proves the proxy is what changes behavior) ---
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
    ? "END-TO-END OK: both registered proxies routed their mocked responses to the right third-party DLL."
    : $"END-TO-END FAILED: {failures} check(s) failed.");

return failures == 0 ? 0 : 1;
