// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;

namespace Azure.Identity.Tests.ConfigurableCredentials.VisualStudioCode
{
    /// <summary>
    /// Tests for VisualStudioCodeCredential accessed through ConfigurableCredential.
    /// Inherits from Tests.VisualStudioCodeCredentialTests to get all VS Code-specific test cases.
    /// Overrides factory methods to create credentials via IConfiguration.
    /// </summary>
    internal class VisualStudioCodeCredentialTests : Tests.VisualStudioCodeCredentialTests
    {
        private readonly ConfigurableCredentialTestHelper<VisualStudioCodeCredential> _helper;

        public VisualStudioCodeCredentialTests()
        {
            _helper = new ConfigurableCredentialTestHelper<VisualStudioCodeCredential>(
                "VisualStudioCode");
        }

        protected override void CreateBareCredential()
        {
            IConfiguration config = _helper.GetConfiguration();

            using (new TestEnvVar("AZURE_TENANT_ID", null))
            {
                _helper.GetCredentialFromConfig(config);
            }
        }

        protected override void CreateCredentialWithOptions(string tenantId = null, Uri authorityHost = null, bool isUnsafeSupportLoggingEnabled = false)
        {
            IConfiguration config = _helper.GetConfiguration();

            if (tenantId != null)
            {
                config["MyClient:Credential:TenantId"] = tenantId;
            }
            if (authorityHost != null)
            {
                config["MyClient:Credential:AuthorityHost"] = authorityHost.ToString();
            }
            config["MyClient:Credential:IsUnsafeSupportLoggingEnabled"] = isUnsafeSupportLoggingEnabled.ToString();

            using (new TestEnvVar("AZURE_TENANT_ID", null))
            {
                _helper.GetCredentialFromConfig(config);
            }
        }
    }
}
