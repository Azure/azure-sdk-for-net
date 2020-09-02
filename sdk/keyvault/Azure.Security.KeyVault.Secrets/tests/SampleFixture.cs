// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;
using Azure.Security.KeyVault.Tests;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Secrets.Samples
{
    [LiveOnly]
    [NonParallelizable]
    public class SampleFixture: SamplesBase<KeyVaultTestEnvironment>
    {
        private KeyVaultTestEventListener _listener;

        [SetUp]
        public void SetUp() => _listener = new KeyVaultTestEventListener();

        [TearDown]
        public void TearDown() => _listener?.Dispose();
    }

#pragma warning disable SA1402 // File may only contain a single type
    public partial class HelloWorld : SampleFixture { }
    public partial class BackupAndRestore : SampleFixture { }
    public partial class GetSecrets : SampleFixture { }
    public partial class Snippets : SampleFixture { }
#pragma warning restore SA1402 // File may only contain a single type
}
