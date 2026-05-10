// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Xunit;
using Xunit.Sdk;

namespace AzureSamples.Security.KeyVault.Proxy
{
    /// <summary>
    /// Test attribute to run tests synchronously or asynchronously in conjunction with a <see cref="SecretsFixture"/>.
    /// </summary>
    [XunitTestCaseDiscoverer("AzureSamples.Security.KeyVault.Proxy.LiveFactDiscoverer", "AzureSamples.Security.KeyVault.Proxy.Tests")]
    public class LiveFactAttribute : FactAttribute
    {
        /// <summary>
        /// Gets or sets whether to run only synchronously, asynchronously, or both.
        /// </summary>
        public Synchronicity Synchronicity { get; set; }
    }

    /// <summary>
    /// Options to run methods synchronously, asynchronously, or both (default).
    /// </summary>
    public enum Synchronicity
    {
        Both,
        Synchronous,
        Asynchronous,
    }
}
