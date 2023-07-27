// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;
using Azure.Security.KeyVault.Tests;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Keys.Samples
{
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
    public partial class GetKeys : SampleFixture { }
    public partial class Sample4_EncryptDecypt : SampleFixture { }
    public partial class Sample5_SignVerify : SampleFixture { }
    public partial class Sample6_WrapUnwrap : SampleFixture { }
    public partial class Sample7_SerializeJsonWebKey : SampleFixture { }
    public partial class Sample8_KeyRotation : SampleFixture { }
    public partial class Snippets : SampleFixture { }
#pragma warning restore SA1402 // File may only contain a single type
}
