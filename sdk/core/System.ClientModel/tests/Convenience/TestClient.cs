// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace System.ClientModel.Primitives.Tests;

/// <summary>
/// Test client for testing dependency injection integration.
/// </summary>
internal class TestClient
{
    public TestClient(TestClientSettings settings)
    {
        Settings = settings;
    }

    public TestClientSettings Settings { get; }
}
