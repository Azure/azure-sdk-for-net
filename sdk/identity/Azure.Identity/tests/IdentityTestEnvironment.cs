// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Testing;

namespace Azure.Identity.Tests
{
    public class IdentityTestEnvironment : TestEnvironment
    {
        public IdentityTestEnvironment() : base("identity")
        {
        }

        public string IdentityTenantId => GetRecordedVariable("AZURE_IDENTITY_TEST_TENANTID");
        public string Username => GetRecordedVariable("AZURE_IDENTITY_TEST_USERNAME");
        public string Password => GetVariable("AZURE_IDENTITY_TEST_PASSWORD");
        public string IMDSEnable => GetOptionalVariable("IDENTITYTEST_IMDSTEST_ENABLE");
        public string IMDSClientId => GetVariable("IDENTITYTEST_IMDSTEST_CLIENTID");
        public string SystemAssignedVault => GetVariable("IDENTITYTEST_IMDSTEST_SYSTEMASSIGNEDVAULT");
        public string TestPassword => GetOptionalVariable("AZURE_IDENTITY_TEST_PASSWORD") ?? "SANITIZED";
        public string TestTenantId => GetRecordedOptionalVariable("TENANT_ID") ?? GetRecordedVariable("AZURE_IDENTITY_TEST_TENANTID");
    }
}