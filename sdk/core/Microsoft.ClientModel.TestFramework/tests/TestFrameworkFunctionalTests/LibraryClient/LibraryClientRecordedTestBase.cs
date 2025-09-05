// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using Microsoft.ClientModel.TestFramework.Tests.MockClient;

namespace Microsoft.ClientModel.TestFramework.Tests.LibraryClient.Tests;

public class LibraryClientRecordedTestBase : RecordedTestBase<LibraryClientTestEnvironment>
{
    public LibraryClientRecordedTestBase(bool isAsync, RecordedTestMode? mode = null) : base(isAsync, mode)
    {
        SanitizedHeaders.Add("X-Request-ID");
    }

    /// <summary>
    /// Creates a proxied FakeFileClient that will work with the test recording framework
    /// </summary>
    internal LibraryClient GetProxiedFakeFileClient()
    {
        Uri endpoint = new Uri("https://api.fakefiles.test/");

        // Set up the client pipeline with proxy instrumentation
        var options = new ClientPipelineOptions();
        var proxiedOptions = InstrumentClientOptions(options);

        // Create the client with the appropriate endpoint
        var client = new LibraryClient(endpoint, proxiedOptions);

        // Proxy the client to enable recording/playback
        LibraryClient proxiedClient = CreateProxyFromClient<LibraryClient>(client, null);
        return proxiedClient;
    }
}
