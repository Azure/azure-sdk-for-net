// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading;
using Azure.Core;
using Azure.Core.TestFramework;

namespace Azure.Containers.Apps.Sandbox.Tests
{
    internal static class SandboxClientTestHelpers
    {
        internal const string Endpoint = "https://management.eastus2.azuredevcompute.io";
        internal const string SubscriptionId = "00000000-0000-0000-0000-000000000000";
        internal const string ResourceGroupName = "test-rg";
        internal const string SandboxGroupName = "test-group";

        internal static SandboxGroupClient CreateSandboxGroupClient(MockTransport transport)
        {
            SandboxGroupClientOptions options = new SandboxGroupClientOptions
            {
                Transport = transport
            };
            return new SandboxGroupClient(
                new Uri(Endpoint),
                SubscriptionId,
                ResourceGroupName,
                SandboxGroupName,
                new MockCredential(),
                options);
        }

        internal static MockResponse CreateJsonResponse(int status, string content)
        {
            MockResponse response = new MockResponse(status);
            response.SetContent(content);
            return response;
        }

        internal static string ReadContent(MockRequest request)
        {
            using MemoryStream stream = new MemoryStream();
            request.Content.WriteTo(stream, CancellationToken.None);
            return BinaryData.FromBytes(stream.ToArray()).ToString();
        }
    }
}
