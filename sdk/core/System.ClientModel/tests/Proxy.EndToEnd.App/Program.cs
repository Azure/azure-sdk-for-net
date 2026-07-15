// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.ClientModel.Tests.Proxy.OpenAILike;
using System.ClientModel.Tests.Proxy.OpenAILike.Mocks;
using System.ClientModel.Tests.Proxy.ThirdPartyA;

// A real, runnable end-to-end program for the MRW proxy feature. It performs the exact loop Michael
// described: (1) register the proxy, (2) mock the response, (3) make a real client call through a
// ClientPipeline, and (4) verify the expected derived type is returned. Exits 0 on success, 1 on failure.

int failures = 0;

Console.WriteLine("MRW proxy — end-to-end demo");
Console.WriteLine("===========================");

// --- Case 1: proxy registered -> deserialization is routed to the third-party type ---
{
    // 1. ADD THE PROXY (a consumer registers Foundry's proxy when configuring its client).
    ModelReaderWriterOptions options = new ModelReaderWriterOptions("J").AddAzureTools();

    // 2. MOCK THE RESPONSE (the JSON body the service would return).
    var transport = new CannedResponseTransport("{\"type\":\"azure_search\",\"index_name\":\"docs\"}");

    // A real client with a real pipeline; only the transport is mocked.
    var client = new ResponseToolsClient(new ClientPipelineOptions { Transport = transport }, options);

    // 3. CALL — a real client call flows request -> transport -> response -> deserialize.
    ResponseTool tool = client.GetTool("tool-1");

    // 4. VERIFY — the proxy handled it and produced ThirdPartyA's AzureSearchTool.
    if (tool is AzureSearchTool azure && tool.GetType().Assembly == typeof(AzureSearchTool).Assembly)
    {
        Console.WriteLine($"PASS  with proxy    -> {tool.GetType().FullName} (IndexName={azure.IndexName}) " +
                          $"from {tool.GetType().Assembly.GetName().Name}.dll");
    }
    else
    {
        Console.Error.WriteLine($"FAIL  with proxy    -> expected AzureSearchTool from ThirdPartyA, got {tool.GetType().FullName}");
        failures++;
    }
}

// --- Case 2: no proxy -> base fallback (proves the proxy is what changes behavior) ---
{
    ModelReaderWriterOptions options = new ModelReaderWriterOptions("J"); // no proxy registered
    var transport = new CannedResponseTransport("{\"type\":\"azure_search\",\"index_name\":\"docs\"}");
    var client = new ResponseToolsClient(new ClientPipelineOptions { Transport = transport }, options);

    ResponseTool tool = client.GetTool("tool-2");

    if (tool is UnknownResponseTool)
    {
        Console.WriteLine($"PASS  without proxy -> {tool.GetType().FullName} (base fallback, as expected)");
    }
    else
    {
        Console.Error.WriteLine($"FAIL  without proxy -> expected UnknownResponseTool, got {tool.GetType().FullName}");
        failures++;
    }
}

Console.WriteLine();
Console.WriteLine(failures == 0
    ? "END-TO-END OK: the registered proxy routed the mocked response to the third-party type."
    : $"END-TO-END FAILED: {failures} check(s) failed.");

return failures == 0 ? 0 : 1;
