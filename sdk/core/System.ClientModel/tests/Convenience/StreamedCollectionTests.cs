// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using ClientModel.Tests.Collections;
using ClientModel.Tests.Mocks;
using NUnit.Framework;

namespace System.ClientModel.Tests.Results;

/// <summary>
/// Scenario tests for sync and async streamed collections.
/// These tests use a reference implementation of a client that calls streaming
/// service endpoints.
/// </summary>
public class StreamedCollectionTests
{
    // Tests:
    //  1. Protocol/Sync
    //    a. Can enumerate pages (only one response for now)
    //  2. Protocol/Async
    //    a. Can enumerate pages
    //  3. Convenience/Sync
    //    a. Can get values from response stream
    //    b. Response stream is disposed
    //  4. Convenience/Async
    //    a. Can get values from response stream
    //    b. Response stream is disposed

    [Test]
    public void CanEnumerateRawPages()
    {
        StreamedCollectionClient client = new();
        CollectionResult collection = client.GetValues();
        IEnumerable<ClientResult> pages = collection.GetRawPages();


    }
}
