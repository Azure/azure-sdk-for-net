// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Core.TestFramework;
using Microsoft.Extensions.Configuration;

namespace Azure.Identity.Tests.ConfigurableCredentials.VisualStudio
{
    /// <summary>
    /// Tests for VisualStudioCredential accessed through ConfigurableCredential.
    /// Inherits from Tests.VisualStudioCredentialTests to get all VS-specific test cases.
    /// Overrides factory methods to create credentials via IConfiguration.
    /// </summary>
    [RunOnlyOnPlatforms(Windows = true)] // VisualStudioCredential works only on Windows
    internal class VisualStudioCredentialTests : Tests.VisualStudioCredentialTests
    {
        private readonly ConfigurableCredentialTestHelper<VisualStudioCredential> _helper;

        public VisualStudioCredentialTests(bool isAsync) : base(isAsync)
        {
            _helper = new ConfigurableCredentialTestHelper<VisualStudioCredential>(
                "VisualStudio",
                CredentialTestHelpers.CreateTokenForVisualStudio().Json,
                CredentialTestHelpers.CreateFileSystemForVisualStudio(),
                InstrumentClient);
        }

        public override TokenCredential GetTokenCredential(TokenCredentialOptions options)
            => _helper.GetTokenCredential(options, TenantId);

        public override TokenCredential GetTokenCredential(CommonCredentialTestConfig config)
            => _helper.GetTokenCredential(config);

        private TokenCredential CreateConfiguredCredential(IProcessService processService = null, IFileSystemService fileSystem = null, string tenantId = null, bool addTenantIdHint = false)
        {
            IConfiguration config = _helper.GetConfiguration();
            if (tenantId != null)
            {
                config["MyClient:Credential:TenantId"] = tenantId;
            }
            if (addTenantIdHint)
            {
                config["MyClient:Credential:AdditionallyAllowedTenants:0"] = TenantIdHint;
            }

            ConfigurableCredential credential;
            using (new TestEnvVar("AZURE_TENANT_ID", null))
            {
                credential = _helper.GetCredentialFromConfig(config);
            }

            return _helper.InstrumentCredential(credential, processService, fileSystem);
        }

        protected override TokenCredential CreateCredential(IProcessService processService, IFileSystemService fileSystem, string tenantId = null, bool addTenantIdHint = false)
            => CreateConfiguredCredential(processService, fileSystem, tenantId, addTenantIdHint);

        protected override TokenCredential CreateCredentialWithTimeout(IProcessService processService, IFileSystemService fileSystem, TimeSpan timeout)
        {
            IConfiguration config = _helper.GetConfiguration();
            config["MyClient:Credential:CredentialProcessTimeout"] = timeout.ToString();

            ConfigurableCredential credential;
            using (new TestEnvVar("AZURE_TENANT_ID", null))
            {
                credential = _helper.GetCredentialFromConfig(config);
            }

            return _helper.InstrumentCredential(credential, processService, fileSystem);
        }

        protected override TokenCredential CreateCredentialWithChainedOption(IProcessService processService, IFileSystemService fileSystem, bool isChained)
            => CreateConfiguredCredential(processService, fileSystem);

        protected override bool IsChainedCredentialSupported => false;
    }
}
