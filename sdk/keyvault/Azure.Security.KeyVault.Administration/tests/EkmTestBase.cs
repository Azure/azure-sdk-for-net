// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.Security.KeyVault.Administration.Tests
{
    [ClientTestFixture(KeyVaultAdministrationClientOptions.ServiceVersion.V2026_01_01_Preview)]
    public abstract class EkmTestBase : AdministrationTestBase
    {
        public EkmTestBase(bool isAsync, KeyVaultAdministrationClientOptions.ServiceVersion serviceVersion, RecordedTestMode? mode)
            : base(isAsync, serviceVersion, mode)
        { }

        public KeyVaultEkmClient Client { get; private set; }

        internal KeyVaultEkmClient GetClient() =>
            InstrumentClient(new KeyVaultEkmClient(
                Uri,
                TestEnvironment.Credential,
                InstrumentClientOptions(new KeyVaultAdministrationClientOptions(ServiceVersion)
                {
                    Diagnostics = { LoggedHeaderNames = { "x-ms-request-id" } },
                })));

        protected override void Start()
        {
            TestEnvironment.AssertEkmEnabled();
            Client = GetClient();
            base.Start();
        }
    }
}