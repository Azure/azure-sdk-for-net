// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.Security.KeyVault.Administration.Tests
{
    public abstract class SettingsTestBase : AdministrationTestBase
    {
        public SettingsTestBase(bool isAsync, KeyVaultAdministrationClientOptions.ServiceVersion serviceVersion, RecordedTestMode? mode)
            : base(isAsync, serviceVersion, mode)
        { }

        public KeyVaultSettingsClient Client { get; private set; }

        internal KeyVaultSettingsClient GetClient()
        {
            return InstrumentClient
                (new KeyVaultSettingsClient(
                    Uri,
                    TestEnvironment.Credential,
                    InstrumentClientOptions(new KeyVaultAdministrationClientOptions(ServiceVersion)
                    {
                        Diagnostics =
                        {
                            LoggedHeaderNames =
                            {
                                "x-ms-request-id",
                            },
                        },
                    })));
        }

        protected override void Start()
        {
            Client = GetClient();

            base.Start();
        }
    }
}
