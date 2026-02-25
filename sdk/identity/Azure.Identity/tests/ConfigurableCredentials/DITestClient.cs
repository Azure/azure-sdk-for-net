// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Identity.Tests.ConfigurableCredentials
{
    /// <summary>
    /// Simulates a real Azure SDK client with standard constructor patterns.
    /// Used by DI integration tests to verify AddClient/AddKeyedClient flows.
    /// </summary>
    internal class DITestClient
    {
        public Uri Endpoint { get; }
        public TokenCredential Credential { get; }
        public TestOptions Options { get; }

        public DITestClient(Uri endpoint, TokenCredential credential, TestOptions options = null)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(credential, nameof(credential));

            Endpoint = endpoint;
            Credential = credential;
            Options = options ?? new TestOptions();
        }

        public DITestClient(E2ETestSettings settings)
            : this(
                  settings?.Endpoint != null ? new Uri(settings.Endpoint) : null,
                  settings?.CredentialProvider as TokenCredential,
                  null)
        {
        }

        /// <summary>
        /// Minimal options type for DITestClient.
        /// </summary>
        internal class TestOptions
        {
        }
    }
}
